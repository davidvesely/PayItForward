namespace PayItForward.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public List<Story> Stories { get; set; }

        public bool IsRemoved { get; set; }
    }
}
