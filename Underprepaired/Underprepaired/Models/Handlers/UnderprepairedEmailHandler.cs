using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Underprepaired.Models.Handlers
{
    public class UnderprepairedEmailHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if (!context.User.HasClaim(e => e.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }

            var userEmail = context.User.FindFirst(email => email.Type == ClaimTypes.Email).Value;

            if (userEmail.Contains("@underprepaired.shop"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
