using Microsoft.AspNetCore.Mvc;
using SingleSession.ModelLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSessionApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login() => View();

        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp() => View();
    }
}
