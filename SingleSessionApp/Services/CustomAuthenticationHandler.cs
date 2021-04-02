using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SingleSession.BusinessLayer.Interface;
using SingleSession.ModelLayer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SingleSessionApp.Services
{
    public class CustomAuthenticationHandler : IAuthorizationHandler, IAuthorizationRequirement
    {

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userId = context.User.FindFirst(ClaimTypes.Sid).Value;
                var sessionId = context.User.FindFirst(ClaimTypes.Hash).Value;
                if (StaticDependencyService.userService.UpdateSessionDetails(int.Parse(userId),sessionId).Result)
                {
                    context.Succeed(this);
                    return Task.CompletedTask;
                }
            }
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
