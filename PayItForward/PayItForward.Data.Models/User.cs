// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        private readonly ICollection<Story> stories;
        private readonly ICollection<Donation> donations;

        public User()
        {
            this.donations = new HashSet<Donation>();
            this.stories = new HashSet<Story>();
        }

        [Required]
        public string FirstNmae { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double AvilableMoneyAmount { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string AvatarUrl { get; set; }

        public ICollection<Story> Stories => this.stories;

        public ICollection<Donation> Donations => this.donations;
    }
}
