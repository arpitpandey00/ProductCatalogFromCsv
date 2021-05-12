using product.Data;
using product.Data.Entities;
using product.Data.OperationOnEntities;
using System;
using System.Collections.Generic;
using prod = product.Data.Entities;

namespace AllProducts.solution
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Catalog catalog = new Catalog();
            catalog.DisplayCatalog();

            
           
            //CsvFileProcessor.ReadProductsData();
            //CsvFileProcessor.ReadCategoriesData();
        }
    }
    
}
