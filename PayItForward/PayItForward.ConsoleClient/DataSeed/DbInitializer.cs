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
        public void Initialize(PayItForwardDbContext context, IServiceProvider serviceProvider)
        {
            context.Database.Migrate();

            this.AddRoles(context);

            var users = this.SeedUsers(context);

            this.AddUsersToUserRole(context, users);

            this.SeedAdmin(context, users.First());

            var categories = this.SeedCategories(context);

            this.SeedStories(context, categories);

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
            // if there are categories in the database do not seed more
            if (context.Categories.Any())
            {
                return context.Categories.ToList();
            }

            List<Dbmodel.Category> categories = new List<Dbmodel.Category>()
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

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return context.Categories.ToList();
        }

        private void SeedStories(PayItForwardDbContext context, List<Dbmodel.Category> categories)
        {
            if (context.Stories.Any())
            {
                return;
            }

            List<Dbmodel.Story> stories = new List<Dbmodel.Story>()
              {
                new Dbmodel.Story
                {
                    Title = "Help me!",
                    IsClosed = false,
                    UserId = context.Users.FirstOrDefault(u => u.FirstName == "Aleksandra").Id,
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Health").CategoryId,
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
                    UserId = context.Users.FirstOrDefault(u => u.FirstName == "Peter").Id,
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Education").CategoryId,
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
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Sponsorship").CategoryId,
                    IsRemoved = false,
                    GoalAmount = 700,
                    IsAccepted = true,
                    DateCreated = DateTime.Now,
                    CollectedAmount = 80,
                    ExpirationDate = new DateTime(2018, 9, 9, 16, 5, 7, 123)
                }
              };
            context.Stories.AddRange(stories);

            context.SaveChanges();
        }

        private void SeedDonations(PayItForwardDbContext context)
        {
            if (context.Donations.Any())
            {
                return;
            }

            List<Dbmodel.Donation> donations = new List<Dbmodel.Donation>()
            {
                new Dbmodel.Donation
                {
                    Amount = 300,
                    UserId = context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Aleksandra").Id,
                    StoryId = context.Stories.FirstOrDefault(c => c.Title == "Help me!").StoryId
                },
                new Dbmodel.Donation
                {
                    Amount = 800,
                    UserId = context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Aleksandra").Id,
                    StoryId = context.Stories.FirstOrDefault(c => c.Title == "Education support").StoryId
                },
                new Dbmodel.Donation
                {
                    Amount = 3006,
                    UserId = context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Single").Id,
                    StoryId = context.Stories.FirstOrDefault(c => c.Title == "Sponsor me!").StoryId
                }
            };

            context.Donations.AddRange(donations);

            context.SaveChanges();
        }
    }
}
