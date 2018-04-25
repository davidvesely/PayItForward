﻿// <copyright file="Story.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Story
    {
        private readonly ICollection<Donation> donations;

        public Story()
        {
            this.donations = new HashSet<Donation>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StoryId { get; set;  }

        [Required]
        public string Title { get; set;  }

        [Column(TypeName = "varchar(200)")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal GoalAmount { get; set; }

        public decimal CollectedAmount { get; set; }

        public bool IsClosed { get; set; }

        public bool IsAccepted { get; set;  }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }

        public Category Category { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public User User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string DocumentUrl { get; set; }

        public ICollection<Donation> Donations => this.donations;

        public bool IsRemoved { get; set; }
    }
}
