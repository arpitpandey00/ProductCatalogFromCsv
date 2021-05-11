using product.Data.Entities;
using System;

namespace Product.solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Catalog catalog = new Catalog();
            catalog.DisplayCatalog();
        }
    }
}
