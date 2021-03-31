using SingleSession.ModelLayer.DBModel;
using SingleSession.ModelLayer.ViewModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingleSession.BusinessLayer.Interface
{
    public interface IUserService
    {
        public Task<User> Login(LoginViewModel loginViewModel);
        public Task<bool> Register(SignupViewModel signupViewModel);
    }
}
