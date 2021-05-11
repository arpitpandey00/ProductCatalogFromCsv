using System;
using System.Collections.Generic;
using System.Text;

namespace product.Data.Validations
{
    public class CategoryProductRequired
    {
        public string CategoryNamerequired()
        {
            string Categoryname = "";
            try
            {
                Categoryname = Console.ReadLine();
                if (Categoryname.Length <= 0)
                {
                    Console.WriteLine("Name should be Valid");
                    Console.WriteLine("Enter Again :");
                    CategoryNamerequired();
                }
            }
            catch (Exception)
            {

            }
            return Categoryname;
        }
        public string CategoryDescriptionRequired()
        {
            string Categorydescription = "";
            try
            {
                Categorydescription = Console.ReadLine();
                if (Categorydescription.Length <= 0)
                {
                    Console.WriteLine("Description should be Valid");
                    Console.WriteLine("Enter Again :");
                    CategoryDescriptionRequired();
                }
            }
            catch (Exception)
            {

            }
            return Categorydescription;
        }
    }
}
