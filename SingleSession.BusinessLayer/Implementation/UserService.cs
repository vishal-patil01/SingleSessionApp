using SingleSession.BusinessLayer.Interface;
using SingleSession.DataAccessLayer.Interface;
using SingleSession.ModelLayer.DBModel;
using SingleSession.ModelLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingleSession.BusinessLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(LoginViewModel loginViewModel)
        {
            User user = new User()
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
            return await _userRepository.Login(user);
        }

        public async Task<bool> Register(SignupViewModel signupViewModel)
        {
            User user = new User()
            {
                FirstName = signupViewModel.FirstName,
                LastName = signupViewModel.LastName,
                Email = signupViewModel.Email,
                Password = signupViewModel.Password
            };
            return await _userRepository.Register(user);
        }

        public async Task<bool> UpdateSessionDetails(int userid, string sessionId)
        {
            return await _userRepository.UpdateSessionDetails(userid,sessionId);
        }
    }
}
