using Microsoft.AspNetCore.Http;
using SingleSession.BusinessLayer.Interface;
using SingleSession.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSessionApp.Services
{
    public class StaticDependencyService
    {
        public static IUserService userService;
        public static IUserRepository userRepository;
        public static IHttpContextAccessor _httpContextAccessor;
    }
}
