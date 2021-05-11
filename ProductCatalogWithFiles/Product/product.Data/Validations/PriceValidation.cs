using System;
using System.Collections.Generic;
using System.Text;

namespace product.Data.Validations
{
    public class PriceValidation
    {

        public int PriceValidating()
        {
            int ProductPrice = 0;
            try
            {
                ProductPrice = Convert.ToInt32(Console.ReadLine());
                if (ProductPrice <= 0)
                {
                    Console.WriteLine("Price should be greter than 0");
                    PriceValidating();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Price should be a number and greater than 0");
                Console.WriteLine("\nEnter Price Again : ");
                PriceValidating();
            }
            return ProductPrice;
        }
    }
}
