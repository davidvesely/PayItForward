// <copyright file="Category.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayItForward.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private readonly List<Story> stories;

        public Category()
        {
            this.stories = new List<Story>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Story> Stories => this.stories;

        public bool IsRemoved { get; set; }
    }
}
