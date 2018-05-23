namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PayItForward.Common;
    using PayItForward.Data;
    using PayItForward.Data.Models;
    using Dbmodel = PayItForward.Data.Models;

    public class DbInitializer
    {
        private List<Dbmodel.Story> stories;
        private List<Dbmodel.Category> categories;
        private List<Dbmodel.Donation> donations;

        public void Initialize(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            context.Database.Migrate();

            this.AddRoles(context);

            var users = this.SeedUsers(context);

            this.AddUsersToUserRole(context, users);

            this.SeedAdmin(context, users.First());

            this.SeedCategories(context);

            this.SeedStories(context, this.SeedCategories(context));

            this.SeedDonations(context);
        }

        private void AddRoles(PayItForwardDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var userRole = new IdentityRole<Guid>
            {
                Name = GlobalConstants.UserRole
            };
            var adminRole = new IdentityRole<Guid>
            {
                Name = GlobalConstants.AdminRole
            };

            context.Roles.Add(userRole);
            context.Roles.Add(adminRole);
            context.SaveChanges();
        }

        private List<Dbmodel.User> SeedUsers(PayItForwardDbContext context)
        {
            if (context.Users.Any())
            {
                return context.Users.ToList();
            }

            if (context.Roles.Any(r => r.Name == GlobalConstants.UserRole))
            {
                var users = new List<Dbmodel.User>()
                    {
                        new Dbmodel.User
                        {
                            FirstName = "Aleksandra",
                            LastName = "Stoicheva"
                        },
                        new Dbmodel.User
                        {
                            FirstName = "Peter",
                            LastName = "Petkov"
                        },
                        new Dbmodel.User
                        {
                            FirstName = "Single",
                            LastName = "Mingle"
                        }
                    };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return context.Users.ToList();
        }

        private void AddUsersToUserRole(PayItForwardDbContext context, List<Dbmodel.User> users)
        {
            if (!context.Users.Any())
            {
                return;
            }

            // Don't seed if there are no roles
            if (!context.Roles.Any())
            {
                return;
            }

            var userRole = context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.UserRole);

            if (userRole != null)
            {
                foreach (Dbmodel.User user in users)
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
        }

        private void SeedAdmin(PayItForwardDbContext context, Dbmodel.User user)
        {
            if (!context.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                return;
            }

            var adminRole = context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.AdminRole);

            if (adminRole != null)
            {
                if (!context.UserRoles.Any(a => a.UserId == user.Id && a.RoleId == adminRole.Id))
                {
                    context.UserRoles.Add(new IdentityUserRole<Guid>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    });
                }

                context.SaveChanges();
            }
        }

        private List<Category> SeedCategories(PayItForwardDbContext context)
        {
            // iF there there are categories in the database do not seed more
            if (context.Categories.Any())
            {
                this.categories = context.Categories.ToList();
                return this.categories;
            }

            this.categories = new List<Dbmodel.Category>()
            {
                new Dbmodel.Category
                {
                    Name = "Education",
                    IsRemoved = false
                },
                new Dbmodel.Category
                {
                    Name = "Health",
                    IsRemoved = false
                },
                new Dbmodel.Category
                {
                    Name = "Sponsorship",
                    IsRemoved = false
                }
            };
            context.Categories.AddRange(this.categories);

            context.SaveChanges();

            // Update local List of categories
            this.categories = context.Categories.ToList();

            return this.categories;
        }

        private void SeedStories(PayItForwardDbContext context, List<Category> categories)
        {
            this.stories = context.Stories.ToList();
            if (!context.Stories.Any())
            {
                this.stories = new List<Dbmodel.Story>()
             {
                new Dbmodel.Story
                {
                    Title = "Help me!",
                    IsClosed = false,
                    UserId = context.Users.FirstOrDefault(u => u.FirstName == "Aleksandra").Id,
                    CategoryId = this.categories.FirstOrDefault(c => c.Name == "Health").CategoryId,
                    IsRemoved = false,
                    GoalAmount = 1500,
                    IsAccepted = true,
                    CollectedAmount = 0,
                    ExpirationDate = new DateTime(2018, 9, 9, 16, 5, 7, 123)
                },
                new Dbmodel.Story
                {
                    Title = "Education support",
                    IsClosed = false,
                    UserId = context.Users.FirstOrDefault(u => u.FirstName == "Viktoria").Id,
                    CategoryId = this.categories.FirstOrDefault(c => c.Name == "Education").CategoryId,
                    IsRemoved = false,
                    GoalAmount = 900,
                    IsAccepted = true,
                    DateCreated = DateTime.Now,
                    CollectedAmount = 30,
                    ExpirationDate = new DateTime(2018, 9, 9, 16, 5, 7, 123)
                },
                new Dbmodel.Story
                {
                    Title = "Sponsor me!",
                    IsClosed = false,
                    UserId = context.Users.FirstOrDefault(u => u.FirstName == "Single").Id,
                    CategoryId = this.categories.FirstOrDefault(c => c.Name == "Sponsorship").CategoryId,
                    IsRemoved = false,
                    GoalAmount = 700,
                    IsAccepted = true,
                    DateCreated = DateTime.Now,
                    CollectedAmount = 80,
                    ExpirationDate = new DateTime(2018, 9, 9, 16, 5, 7, 123)
                }
             };

                context.Stories.AddRange(this.stories);
            }

            context.SaveChanges();
        }

        private void SeedDonations(PayItForwardDbContext context)
        {
            if (!context.Donations.Any())
            {
                this.donations = new List<Dbmodel.Donation>()
                {
                    new Dbmodel.Donation
                    {
                        Amount = 300,
                        UserId = context.Users.ElementAtOrDefault<Dbmodel.User>(0).Id,
                        StoryId = this.stories.ElementAtOrDefault<Dbmodel.Story>(0).StoryId
                    },
                    new Dbmodel.Donation
                    {
                        Amount = 800,
                        UserId = context.Users.ElementAtOrDefault<Dbmodel.User>(1).Id,
                        StoryId = this.stories.ElementAtOrDefault<Dbmodel.Story>(0).StoryId
                    },
                    new Dbmodel.Donation
                    {
                        Amount = 3006,
                        User = context.Users.ElementAtOrDefault<Dbmodel.User>(2),
                        StoryId = this.stories.ElementAtOrDefault<Dbmodel.Story>(1).StoryId
                    }
                };

                context.Donations.AddRange(this.donations);

                context.SaveChanges();
            }
        }
    }
}
