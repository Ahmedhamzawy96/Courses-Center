using Microsoft.AspNetCore.Authorization;

namespace Courses_Center.CustomHandler
{
    public class CustomUserRequireClaim: IAuthorizationRequirement
    {
        public string ClaimType { get; }
        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
}
