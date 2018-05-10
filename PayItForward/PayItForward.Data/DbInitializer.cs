namespace PayItForward.Data
{
    using Microsoft.AspNetCore.Identity;
    using PayItForward.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DbInitializer
    {
        public static void Initialize(PayItForwardDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>()
            {
                new User { FirstName = "Viktoria", LastName = "Penkova" },
                new User { FirstName = "Aleksandra", LastName = "Stoicheva" },
                new User { FirstName = "Peter", LastName = "Petkov" },
                new User { FirstName = "Single", LastName = "Mingle" }
            };

            var categories = new List<Category>()
            {
                new Category { Name = "Education", IsRemoved = false },
                new Category { Name = "Health", IsRemoved = false },
                new Category { Name = "Sponsorship", IsRemoved = false }
            };

            var stories = new List<Story>()
            {
                new Story { Title = "Education support", IsClosed = false, Category = categories.ElementAtOrDefault<Category>(0), IsRemoved = false, GoalAmount = 900,  IsAccepted = true, User = users.ElementAtOrDefault<User>(0) },
                new Story { Title = "Help me! My daughter is sick!", IsClosed = false, Category = categories.ElementAtOrDefault<Category>(1), IsRemoved = false, GoalAmount = 1500, IsAccepted = true, User = users.ElementAtOrDefault<User>(1) },
                new Story { Title = "Sponsor me! I'm really talented!", IsClosed = false, Category = categories.ElementAtOrDefault<Category>(2), IsRemoved = false, GoalAmount = 700, IsAccepted = true, User = users.ElementAtOrDefault<User>(2) }
            };

            var donations = new List<Donation>()
            {
                new Donation { Amount = 300, User = users.ElementAtOrDefault<User>(0) },
                new Donation { Amount = 800, User = users.ElementAtOrDefault<User>(1) },
                new Donation { Amount = 3006, User = users.ElementAtOrDefault<User>(2) }
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
