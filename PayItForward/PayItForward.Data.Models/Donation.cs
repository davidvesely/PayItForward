// <copyright file="Donation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System.Collections.Generic;

    public class Donation
    {
        private readonly List<Story> stories;

        public Donation()
        {
            this.stories = new List<Story>();
        }

        public int? DonationId { get; private set; }

        public User User { get; }

        public int UserId { get; }

        public ICollection<Story> Stories => this.stories;

        public int StoryId { get; }

        public decimal Amount { get; set; }
    }
}
