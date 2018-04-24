// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<int>
    {
        private readonly List<Story> stories;
        private readonly List<Donation> donations;

        public User()
        {
            this.donations = new List<Donation>();
            this.stories = new List<Story>();
        }

        [Key]
        public override int Id { get; set; }

        public string FirstNmae { get; set; }

        public string LastName { get; set; }

        public double AvilableMoneyAmount { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string AvatarUrl { get; set; }

        public ICollection<Story> Stories => this.stories;

        public ICollection<Donation> Donations => this.donations;
    }
}
