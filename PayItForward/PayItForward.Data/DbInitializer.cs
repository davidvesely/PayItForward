namespace PayItForward.Data
{
    using System.Linq;

    public static class DbInitializer
    {
        public static void Initialize(PayItForwardDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
        }
    }
}
