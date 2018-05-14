namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PayItForward.Common;
    using PayItForward.ConsoleClient.DataSeed;
    using PayItForward.Data;
    using PayItForward.Data.Models;

    public class DbInitializer
    {
        private List<PayItForward.Data.Models.User> users;
        private List<PayItForward.Data.Models.Story> stories;
        private List<PayItForward.Data.Models.Category> categories;
        private List<PayItForward.Data.Models.Donation> donations;

        public async Task Initialize(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            // context.Database.EnsureCreated();
            await this.SeedRoleAdmin(context, serviceProvider);
            await this.SeedRoleUser(context, serviceProvider);

            // this.SeedStories(context);
            // this.SeedCategories(context);
            // this.SeedDonations(context);
        }

        private async Task SeedRoleAdmin(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            if (!context.Roles.Any())
            {
                var adminRole = new IdentityRole<Guid>
                {
                    Name = GlobalConstants.AdminRole,
                };

                context.Roles.Add(adminRole);

                var adminViki = new PayItForward.Data.Models.User
                {
                    FirstName = "Viktoria",
                    LastName = "Penkova",
                    PasswordHash = "1234",
                    NormalizedEmail = "vicky.penkova@gmail.com" // Normalization stops people registering user names which only differ in letter casing.
                };

                context.UserRoles.Add(new IdentityUserRole<Guid>()
                {
                    RoleId = adminRole.Id,
                    UserId = adminViki.Id
                });
            }

            context.SaveChanges();
        }

        private async Task SeedRoleUser(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            if (!context.Roles.Any())
            {
                var userRole = new IdentityRole<Guid>
                {
                    Name = GlobalConstants.UserRole
                };
                context.Roles.Add(userRole);

                this.users = new List<PayItForward.Data.Models.User>()
             {
                new PayItForward.Data.Models.User
                {
                    FirstName = "Aleksandra",
                    LastName = "Stoicheva",
                },
                 new PayItForward.Data.Models.User
                 {
                     FirstName = "Peter",
                     LastName = "Petkov"
                 },
                 new PayItForward.Data.Models.User
                 {
                     FirstName = "Single",
                     LastName = "Mingle"
                 }
             };
                var userStore = new UserStore<IdentityUser<Guid>, IdentityRole<Guid>, PayItForwardDbContext, Guid>(context);
                foreach (PayItForward.Data.Models.User user in this.users)
                {
                    context.Users.Add(user);
                    await userStore.CreateAsync(user);
                    context.UserRoles.Add(new IdentityUserRole<Guid>()
                    {
                        RoleId = userRole.Id,
                        UserId = user.Id
                    });
                }
            }

            context.SaveChanges();
        }

        private void SeedStories(PayItForwardDbContext context)
        {
            this.stories = new List<PayItForward.Data.Models.Story>()
            {
                new PayItForward.Data.Models.Story
                {
                    Title = "Education support",
                    IsClosed = false,
                    Category = this.categories.ElementAtOrDefault<Category>(0),
                    IsRemoved = false, GoalAmount = 900,
                    IsAccepted = true,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(0)
                },
                new PayItForward.Data.Models.Story
                {
                    Title = "Help me! My daughter is sick!",
                    IsClosed = false,
                    Category = this.categories.ElementAtOrDefault<Category>(1),
                    IsRemoved = false,
                    GoalAmount = 1500,
                    IsAccepted = true,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(1)
                },
                new PayItForward.Data.Models.Story
                {
                    Title = "Sponsor me! I'm really talented!",
                    IsClosed = false,
                    Category = this.categories.ElementAtOrDefault<Category>(2),
                    IsRemoved = false,
                    GoalAmount = 700,
                    IsAccepted = true,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(2)
                }
            };

            if (context.Stories.Any())
            {
                return;   // DB has been seeded
            }
        }

        private void SeedCategories(PayItForwardDbContext context)
        {
            this.categories = new List<PayItForward.Data.Models.Category>()
            {
                new PayItForward.Data.Models.Category
                {
                    Name = "Education",
                    IsRemoved = false
                },
                new PayItForward.Data.Models.Category
                {
                    Name = "Health",
                    IsRemoved = false
                },
                new PayItForward.Data.Models.Category
                {
                    Name = "Sponsorship",
                    IsRemoved = false
                }
            };

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }
        }

        private void SeedDonations(PayItForwardDbContext context)
        {
            this.donations = new List<PayItForward.Data.Models.Donation>()
            {
                new PayItForward.Data.Models.Donation
                {
                    Amount = 300,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(0)
                },
                new PayItForward.Data.Models.Donation
                {
                    Amount = 800,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(1)
                },
                new PayItForward.Data.Models.Donation
                {
                    Amount = 3006,
                    User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(2)
                }
            };

            if (context.Donations.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}
