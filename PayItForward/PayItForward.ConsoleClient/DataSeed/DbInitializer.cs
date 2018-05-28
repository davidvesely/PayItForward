namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PayItForward.Common;
    using PayItForward.Data;
    using PayItForward.Data.Models;
    using Dbmodel = PayItForward.Data.Models;

    public class DbInitializer
    {
        private IServiceProvider serviceProvider;
        private PayItForwardDbContext context;

        public DbInitializer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.context = this.serviceProvider.GetRequiredService<PayItForwardDbContext>();
        }

        public void Initialize()
        {
            this.context.Database.Migrate();

            this.AddRoles();

            this.SeedUsers();

            var categories = this.SeedCategories();

            this.SeedStories(categories);

            this.SeedDonations();
        }

        private void AddRoles()
        {
            var roleManager = this.serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleCheck = roleManager.RoleExistsAsync(GlobalConstants.AdminRole).Result;

            if (!roleCheck)
            {
                roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRole)).Wait();
            }

            roleCheck = roleManager.RoleExistsAsync(GlobalConstants.UserRole).Result;
            if (!roleCheck)
            {
                roleManager.CreateAsync(new IdentityRole(GlobalConstants.UserRole)).Wait();
            }
        }

        private void SeedUsers()
        {
            if (this.context.Users.Any())
            {
                return;
            }

            var userManager = this.serviceProvider.GetRequiredService<UserManager<Dbmodel.User>>();
            var adminUser = new Dbmodel.User
            {
                UserName = "Aleks",
                Email = "aleks@gmail.com",
                FirstName = "Aleksandra",
                LastName = "Stoicheva",
                SecurityStamp = "blabvla"
            };

            var result = userManager.CreateAsync(adminUser, "qwerty123@").Result;
            userManager.AddToRoleAsync(adminUser, GlobalConstants.AdminRole).Wait();

            var users = new List<Dbmodel.User>()
            {
                new Dbmodel.User
                {
                    UserName = "peter",
                    Email = "peter@gmail.com",
                    FirstName = "Peter",
                    LastName = "Petkov",
                    SecurityStamp = "sfkjhsfd"
                },
                new Dbmodel.User
                {
                        UserName = "single",
                    Email = "single@gmail.com",
                    FirstName = "Single",
                    LastName = "Mingle",
                    SecurityStamp = "saujhfsaofuh"
                }
            };

            foreach (var user in users)
            {
                userManager.CreateAsync(user, "qwerty123@").Wait();
                userManager.AddToRoleAsync(user, GlobalConstants.UserRole).Wait();
            }
        }

        private List<Category> SeedCategories()
        {
            // if there are categories in the database do not seed more
            if (this.context.Categories.Any())
            {
                return this.context.Categories.ToList();
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

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();

            return this.context.Categories.ToList();
        }

        private void SeedStories(List<Dbmodel.Category> categories)
        {
            if (this.context.Stories.Any())
            {
                return;
            }

            List<Dbmodel.Story> stories = new List<Dbmodel.Story>()
            {
                new Dbmodel.Story
                {
                    Title = "Help me!",
                    IsClosed = false,
                    UserId = this.context.Users.FirstOrDefault(u => u.FirstName == "Aleksandra").Id,
                    CategoryId = this.context.Categories.FirstOrDefault(c => c.Name == "Health").CategoryId,
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
                    UserId = this.context.Users.FirstOrDefault(u => u.FirstName == "Peter").Id,
                    CategoryId = this.context.Categories.FirstOrDefault(c => c.Name == "Education").CategoryId,
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
                    UserId = this.context.Users.FirstOrDefault(u => u.FirstName == "Single").Id,
                    CategoryId = this.context.Categories.FirstOrDefault(c => c.Name == "Sponsorship").CategoryId,
                    IsRemoved = false,
                    GoalAmount = 700,
                    IsAccepted = true,
                    DateCreated = DateTime.Now,
                    CollectedAmount = 80,
                    ExpirationDate = new DateTime(2018, 9, 9, 16, 5, 7, 123)
                }
            };

            this.context.Stories.AddRange(stories);

            this.context.SaveChanges();
        }

        private void SeedDonations()
        {
            if (this.context.Donations.Any())
            {
                return;
            }

            List<Dbmodel.Donation> donations = new List<Dbmodel.Donation>()
            {
                new Dbmodel.Donation
                {
                    Amount = 300,
                    UserId = this.context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Aleksandra").Id,
                    StoryId = this.context.Stories.FirstOrDefault(c => c.Title == "Help me!").StoryId
                },
                new Dbmodel.Donation
                {
                    Amount = 800,
                    UserId = this.context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Aleksandra").Id,
                    StoryId = this.context.Stories.FirstOrDefault(c => c.Title == "Education support").StoryId
                },
                new Dbmodel.Donation
                {
                    Amount = 3006,
                    UserId = this.context.Users.FirstOrDefault<Dbmodel.User>(u => u.FirstName == "Single").Id,
                    StoryId = this.context.Stories.FirstOrDefault(c => c.Title == "Sponsor me!").StoryId
                }
            };

            this.context.Donations.AddRange(donations);

            this.context.SaveChanges();
        }
    }
}
