namespace PayItForward.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class PayItForwardContextFactory : IDesignTimeDbContextFactory<PayItForwardDbContext>
    {
        public PayItForwardDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PayItForwardDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PayItForward;Integrated Security=true");

            return new PayItForwardDbContext(optionsBuilder.Options);
        }
    }
}
