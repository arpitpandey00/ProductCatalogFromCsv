using System;
using System.Collections.Generic;
using System.Text;

namespace product.Data.Entities
{
    public class Product
    {

        public static int AutoIncrement = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public string ShortCode { get; set; }

        public string ProductCategory { get; set; }

        public string Description { get; set; }

        public int SellingPrice { get; set; }

        public Product()
        {
            AutoIncrement++;
            Id = AutoIncrement;
        }
        public override string ToString()
        {

            return $"ID: {this.Id}\nName: {this.Name}\nManufacutrer: {this.Manufacturer}\nShortCode: {this.ShortCode}\nDescription: {this.Description}\nSelling Price: {this.SellingPrice}\nCategory: {this.ProductCategory}\n";
        }
    }
}
