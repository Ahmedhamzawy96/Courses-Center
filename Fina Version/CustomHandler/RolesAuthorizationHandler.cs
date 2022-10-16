using Courses_Center.Models;
using Courses_Center.Repositories.BuyerRepositry;
using Courses_Center.Services.BuyerService;
using Courses_Center.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;


namespace Courses_Center.CustomHandler
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly IUserService _userService;
        private readonly IBuyerService _buyerService;
        public RolesAuthorizationHandler(IUserService userService, IBuyerService buyerService)
        {
            _userService = userService;
            _buyerService = buyerService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            RolesAuthorizationRequirement requirement)
        {

            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            var validRole2 = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
                validRole2 = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
                var roles = requirement.AllowedRoles;
                if (claims.ToList()[3].Value == "Admin")
                    validRole = _userService.getOneAdminRole(p => roles.Contains("Admin") && p.UserName == userName).Any();
                else
                    validRole = _userService.getOneAdminRole(p => roles.Contains("Owner") && p.UserName == userName).Any();
                 //   _centerContext.Users.Where(p => roles.Contains("Admin") && p.UserName == userName).Any();
                validRole2 = _buyerService.getOneBuyerRole(p => roles.Contains("Buyer") && p.UserName == userName).Any();
               // _centerContext.Buyers.Where(p => roles.Contains("Buyer") && p.UserName == userName).Any();


            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else if (validRole2)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
    }

