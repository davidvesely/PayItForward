﻿// <copyright file="Donation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Donation
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DonationId { get; set; }

        public User User { get; set; }

        [Required]
        public string UserId { get; set;  }

        public Story Story { get; set; }

        [Required]
        public Guid StoryId { get; set; }

        public decimal Amount { get; set; }
    }
}
