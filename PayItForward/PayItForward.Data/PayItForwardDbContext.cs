namespace PayItForward.Data
{
    using Microsoft.EntityFrameworkCore;
    using PayItForward.Data.Models;

    public class PayItForwardDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Donation> Donations { get; set; }

        public virtual DbSet<Story> Stories { get; set; }
    }
}
