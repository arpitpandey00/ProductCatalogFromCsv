using System;
using System.Collections.Generic;
using System.Text;

namespace product.Data.Entities
{
    public class Category
    {
        public static int AutoIncrement = 0;
        public int Id { get; }
        public string Name { get; set; }

        public string ShortCode { get; set; }
        public string Description { get; set; }

        public Category()
        {
            AutoIncrement++;
            Id = AutoIncrement;
        }
        public override string ToString()
        {
            return $"ID: {this.Id}\nName: {this.Name}\nShortCode: {this.ShortCode}\nDescription: {this.Description}\n";
        }
    }
}

