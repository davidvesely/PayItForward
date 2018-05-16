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
            this.AddUserRole(context);

            this.SeedUsers(context);

            this.SeedUsersToRole(context);

            this.AddAdminRole(context);

            this.SeedAdmin(context);

            this.SeedAdminToRole(context);

            this.SeedCategories(context);

            // this.SeedStories(context, this.SeedCategories(context));

            // this.SeedDonations(context);
        }

        private void AddUserRole(PayItForwardDbContext context)
        {
            if (context.Roles.Any(r => r.Name == GlobalConstants.UserRole))
            {
                return;
            }

            var userRole = new IdentityRole<Guid>
            {
                Name = GlobalConstants.UserRole
            };

            context.Roles.Add(userRole);
            context.SaveChanges();
        }

        private List<PayItForward.Data.Models.User> SeedUsers(PayItForwardDbContext context)
        {
            try
            {
                if (context.Roles.Any(r => r.Name == GlobalConstants.UserRole))
                {
                    if (!context.Users.Any())
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

                this.users = context.Users.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return this.users;
        }

        private void SeedUsersToRole(PayItForwardDbContext context)
        {
            if (!context.Roles.Any())
            {
                return;
            }

            if (!context.Users.Any())
            {
                return;
            }

            var userRole = context.Roles.FirstOrDefault<IdentityRole<Guid>>(r => r.Name == GlobalConstants.UserRole);

            if (userRole.Name != GlobalConstants.UserRole)
            {
                return;
            }

            foreach (PayItForward.Data.Models.User user in this.users)
            {
                if (!context.UserRoles.Any(a => a.UserId == user.Id && a.RoleId == userRole.Id))
                {
                    context.UserRoles.Add(new IdentityUserRole<Guid>()
                    {
                        RoleId = userRole.Id,
                        UserId = user.Id
                    });
                }
            }

            context.SaveChanges();
        }

        private void AddAdminRole(PayItForwardDbContext context)
        {
            if (context.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                return;
            }

            var adminRole = new IdentityRole<Guid>
            {
                Name = GlobalConstants.AdminRole,
            };

            context.Roles.Add(adminRole);
            context.SaveChanges();
        }

        private List<PayItForward.Data.Models.User> SeedAdmin(PayItForwardDbContext context)
        {
            if (context.Users.Any())
            {
                if (context.Roles.Any(a => a.Name == GlobalConstants.AdminRole))
                {
                    PayItForward.Data.Models.User adminViki = new PayItForward.Data.Models.User
                    {
                        FirstName = "Viktoria",
                        LastName = "Penkova",
                        PasswordHash = "1234",
                        NormalizedEmail = "vicky.penkova@gmail.com" // Normalization stops people registering user names which only differ in letter casing.
                    };

                    this.users.Add(adminViki);
                    context.Users.Add(adminViki);
                    context.SaveChanges();
                }
            }

            return this.users;
        }

        private void SeedAdminToRole(PayItForwardDbContext context)
        {
            // If there are no users do not assign roles
            if (!context.Users.Any())
            {
                return;
            }

            var adminRole = context.Roles.FirstOrDefault<IdentityRole<Guid>>(r => r.Name == GlobalConstants.AdminRole);

            if (adminRole.Name != GlobalConstants.AdminRole)
            {
                return;
            }

            foreach (PayItForward.Data.Models.User user in this.users)
            {
                if (!context.UserRoles.Any(a => a.UserId == user.Id && a.RoleId == adminRole.Id))
                {
                    if (user.NormalizedEmail == "vicky.penkova@gmail.com")
                    {
                        context.UserRoles.Add(new IdentityUserRole<Guid>()
                        {
                            RoleId = adminRole.Id,
                            UserId = user.Id,
                        });

                        context.SaveChanges();
                    }
                }
            }
        }

        private List<Category> SeedCategories(PayItForwardDbContext context)
        {
            if (!context.Categories.Any())
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

                foreach (PayItForward.Data.Models.Category category in this.categories)
                {
                    context.Categories.Add(category);
                }

                context.SaveChanges();
            }

            this.categories = context.Categories.ToList();

            return this.categories;
        }

        private void SeedStories(PayItForwardDbContext context, List<Category> categories)
        {
            if (!context.Stories.Any())
            {
                this.stories = new List<PayItForward.Data.Models.Story>()
                {
                    new PayItForward.Data.Models.Story
                    {
                        Title = "Education support",
                        IsClosed = false,
                        Category = categories.ElementAtOrDefault<Category>(0),
                        IsRemoved = false, GoalAmount = 900,
                        IsAccepted = true,
                        User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(0)
                    },
                    new PayItForward.Data.Models.Story
                    {
                        Title = "Help me!",
                        IsClosed = false,
                        Category = categories.ElementAtOrDefault<Category>(1),
                        IsRemoved = false,
                        GoalAmount = 1500,
                        IsAccepted = true,
                        User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(1)
                    },
                    new PayItForward.Data.Models.Story
                    {
                        Title = "Sponsor me!",
                        IsClosed = false,
                        Category = categories.ElementAtOrDefault<Category>(2),
                        IsRemoved = false,
                        GoalAmount = 700,
                        IsAccepted = true,
                        User = this.users.ElementAtOrDefault<PayItForward.Data.Models.User>(2)
                    }
                };

                foreach (PayItForward.Data.Models.Story story in this.stories)
                {
                    context.Stories.Add(story);
                }

                context.SaveChanges();
            }
        }

        private void SeedDonations(PayItForwardDbContext context)
        {
            if (!context.Donations.Any())
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
                foreach (PayItForward.Data.Models.Donation donation in this.donations)
                {
                    context.Donations.Add(donation);
                }

                context.SaveChanges();
            }
        }
    }
}
