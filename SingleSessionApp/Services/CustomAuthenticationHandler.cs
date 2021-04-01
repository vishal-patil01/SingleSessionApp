using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSessionApp.Services
{
    public class CustomAuthenticationHandler : IAuthorizationHandler, IAuthorizationRequirement
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                context.Succeed(this);
                return Task.CompletedTask;
            }
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
