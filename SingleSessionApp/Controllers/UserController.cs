using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SingleSession.BusinessLayer.Interface;
using SingleSession.ModelLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SingleSessionApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }

        public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login() => View();

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Login(loginModel);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                    new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
                    new Claim(ClaimTypes.Email,user.Email),
                    };
                    var claimIdenties = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal,
                        new AuthenticationProperties()
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                            IsPersistent = true,
                            AllowRefresh = true
                        });
                    return RedirectToAction("", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View();
        }

        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp() => View();

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignupViewModel signupModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Register(signupModel);
                if (user)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Something Went Wrong");
            }
            return View();
        }
    }
}
