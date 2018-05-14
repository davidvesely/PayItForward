namespace PayItForward.ConsoleClient.DataSeed
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<PayItForward.Data.Models.User, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<PayItForward.Data.Models.User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(PayItForward.Data.Models.User user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                {
                    new Claim(ClaimTypes.GivenName, user.FirstName)
                });
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                {
                     new Claim(ClaimTypes.Surname, user.LastName),
                });
            }

            return principal;
        }
    }
}
