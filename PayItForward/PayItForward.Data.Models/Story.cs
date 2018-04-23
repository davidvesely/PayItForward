namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Story
    {
        public int StoryId { get; set;  }

        public string Tittle { get; set;  }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string GoalAmount { get; set; }

        public string CollectedAmount { get; set; }

        public string IsClosed { get; set; }

        public string IsAccepted { get; set;  }

        public DateTime DateCreated { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Category { get; set; }

        public User User { get; set; }

        public User UserId { get; set; }

        public string DocumentUrl { get; set; }

        public List<Donation> Donations { get; set; }

        public bool IsRemoved { get; set; }
    }
}
