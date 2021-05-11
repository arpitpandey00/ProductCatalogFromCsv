using System;
using System.Collections.Generic;
using System.Text;

namespace product.Data.Validations
{
    public class ProductPropertyRequired
    {
        public string ProductNameRequired()
        {
            string Productname = "";
            try
            {
                Productname = Console.ReadLine();
                if (Productname.Length <= 0)
                {
                    Console.WriteLine("Name should be Valid");
                    Console.WriteLine("Enter Again :");
                    ProductNameRequired();
                }
            }
            catch (Exception)
            {

            }
            return Productname;
        }
        public string ProductManufacturerRequired()
        {
            string Productmanufacturer = "";
            try
            {
                Productmanufacturer = Console.ReadLine();
                if (Productmanufacturer.Length <= 0)
                {
                    Console.WriteLine("Manufacturer should be Valid");
                    Console.WriteLine("Enter Again :");
                    ProductManufacturerRequired();
                }
            }
            catch (Exception)
            {

            }
            return Productmanufacturer;
        }
        public string ProductDescriptionRequired()
        {
            string Productdescription = "";
            try
            {
                Productdescription = Console.ReadLine();
                if (Productdescription.Length <= 0)
                {
                    Console.WriteLine("Description should be Valid");
                    Console.WriteLine("Enter Again :");
                    ProductDescriptionRequired();
                }
            }
            catch (Exception)
            {

            }
            return Productdescription;
        }
    }
}
