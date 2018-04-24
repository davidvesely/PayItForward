// <copyright file="Story.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Story
    {
        private readonly List<Donation> donations;

        public Story()
        {
            this.donations = new List<Donation>();
        }

        public int? StoryId { get; private set;  }

        public string Tittle { get; set;  }

        [Column(TypeName = "varchar(200)")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal GoalAmount { get; set; }

        public decimal? CollectedAmount { get; set; }

        public bool IsClosed { get; set; }

        public bool IsAccepted { get; set;  }

        public DateTime DateCreated { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public User User { get; }

        public int UserId { get; }

        [Column(TypeName = "varchar(200)")]
        public string DocumentUrl { get; set; }

        public ICollection<Donation> Donations => this.donations;

        public bool IsRemoved { get; set; }
    }
}
