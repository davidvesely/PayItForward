namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using PayItForward.Data;
    using PayItForward.Data.Models;

    public static class DbInitializer
    {
        public static void Initialize(PayItForwardDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<PayItForward.Data.Models.User>()
            {
                new PayItForward.Data.Models.User { FirstName = "Viktoria", LastName = "Penkova" },
                new PayItForward.Data.Models.User { FirstName = "Aleksandra", LastName = "Stoicheva" },
                new PayItForward.Data.Models.User { FirstName = "Peter", LastName = "Petkov" },
                new PayItForward.Data.Models.User { FirstName = "Single", LastName = "Mingle" }
            };

            var categories = new List<PayItForward.Data.Models.Category>()
            {
                new PayItForward.Data.Models.Category { Name = "Education", IsRemoved = false },
                new PayItForward.Data.Models.Category { Name = "Health", IsRemoved = false },
                new PayItForward.Data.Models.Category { Name = "Sponsorship", IsRemoved = false }
            };

            var stories = new List<PayItForward.Data.Models.Story>()
            {
                new PayItForward.Data.Models.Story
                {
                    Title = "Education support",
                    IsClosed = false,
                    Category = categories.ElementAtOrDefault<Category>(0),
                    IsRemoved = false, GoalAmount = 900,
                    IsAccepted = true,
                    User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(0)
                },
                new PayItForward.Data.Models.Story
                {
                    Title = "Help me! My daughter is sick!",
                    IsClosed = false,
                    Category = categories.ElementAtOrDefault<Category>(1),
                    IsRemoved = false,
                    GoalAmount = 1500,
                    IsAccepted = true,
                    User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(1)
                },
                new PayItForward.Data.Models.Story
                {
                    Title = "Sponsor me! I'm really talented!",
                    IsClosed = false,
                    Category = categories.ElementAtOrDefault<Category>(2),
                    IsRemoved = false,
                    GoalAmount = 700,
                    IsAccepted = true,
                    User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(2)
                }
            };

            var donations = new List<PayItForward.Data.Models.Donation>()
            {
                new PayItForward.Data.Models.Donation { Amount = 300, User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(0) },
                new PayItForward.Data.Models.Donation { Amount = 800, User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(1) },
                new PayItForward.Data.Models.Donation { Amount = 3006, User = users.ElementAtOrDefault<PayItForward.Data.Models.User>(2) }
            };

            foreach (PayItForward.Data.Models.User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
