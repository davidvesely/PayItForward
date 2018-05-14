namespace PayItForward.ConsoleClient.DataSeed
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using PayItForward.Data;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyIdentityRoleStore : RoleStore<IdentityRole<Guid>, PayItForwardDbContext, Guid>
    {
        public MyIdentityRoleStore(PayItForwardDbContext context)
            : base(context)
        {
        }
    }
}
