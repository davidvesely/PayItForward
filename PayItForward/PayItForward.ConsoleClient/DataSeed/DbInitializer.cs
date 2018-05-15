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
    using PayItForward.Data;
    using PayItForward.Data.Models;

    public class DbInitializer
    {
        private List<PayItForward.Data.Models.User> users;
        private List<PayItForward.Data.Models.Story> stories;
        private List<PayItForward.Data.Models.Category> categories;
        private List<PayItForward.Data.Models.Donation> donations;

        public void Initialize(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();
            this.SeedUsers(context);
            this.AddUserRole(context);
            this.SeedUsersToRole(context);
            this.AddAdminRole(context);
            this.SeedAdmin(context);

            // this.SeedStories(context);
            // this.SeedCategories(context);
            // this.SeedDonations(context);
        }

        private void AddAdminRole(PayItForwardDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                var adminRole = new IdentityRole<Guid>
                {
                    Name = GlobalConstants.AdminRole,
                };

                context.Roles.Add(adminRole);
                context.SaveChangesAsync();
            }
        }

        private void AddUserRole(PayItForwardDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == GlobalConstants.UserRole))
            {
                var userRole = new IdentityRole<Guid>
                {
                    Name = GlobalConstants.UserRole
                };

                context.Roles.Add(userRole);
                context.SaveChangesAsync();
            }
        }

        private List<PayItForward.Data.Models.User> SeedUsers(PayItForwardDbContext context)
        {
            try
            {
                if (!context.Roles.Any(r => r.Name == GlobalConstants.UserRole))
                    {
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

                    context.Users.AddRange(this.users);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return this.users;
        }

        private void SeedAdmin(PayItForwardDbContext context)
        {
            if (!context.UserRoles.Any())
            {
                var adminViki = new PayItForward.Data.Models.User
                {
                    FirstName = "Viktoria",
                    LastName = "Penkova",
                    PasswordHash = "1234",
                    NormalizedEmail = "vicky.penkova@gmail.com" // Normalization stops people registering user names which only differ in letter casing.
                };

                context.UserRoles.Add(new IdentityUserRole<Guid>()
                {
                    RoleId = context.Roles.FirstOrDefault<IdentityRole<Guid>>().Id,
                    UserId = adminViki.Id
                });

                context.SaveChangesAsync();
            }
        }

        // Call after SeedUsers
        private void SeedUsersToRole(PayItForwardDbContext context)
        {
            var userRole = context.Roles.FirstOrDefault<IdentityRole<Guid>>(r => r.Name == GlobalConstants.UserRole);

            if (userRole.Name == GlobalConstants.UserRole)
            {
                foreach (PayItForward.Data.Models.User user in this.users)
                {
                    context.UserRoles.Add(new IdentityUserRole<Guid>()
                    {
                        RoleId = userRole.Id,
                        UserId = user.Id
                    });
                }

                context.SaveChanges();
            }
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
