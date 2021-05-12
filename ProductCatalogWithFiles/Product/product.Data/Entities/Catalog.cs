using CsvHelper;
using CsvHelper.Configuration;
using product.Data.OperationOnEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace product.Data.Entities
{
    public class Catalog
    { 
    OperationOnCategories OperationOnCategories = new OperationOnCategories();
    OperationOnProducts operationOnProducts = new OperationOnProducts();
    public void DisplayCatalog()
    {

        //var input = Console.ReadLine().ToLower();
        bool exit = false;
        while (exit != true)
        {
            Console.WriteLine("_______-----Welcome Home-----______");
            Console.WriteLine("\na. Category");
            Console.WriteLine("\nb. Product");
            Console.WriteLine("\nc. Exit");

            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.Clear();
                    this.CategoryCatalog();
                    exit = true;
                    break;
                case "b":
                    Console.Clear();
                    this.ProductCatalog();
                    exit = true;
                    break;
                case "c":
                    exit = true;
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            TrimOptions = TrimOptions.Trim,
                            Comment = '@',
                            AllowComments = true,

                        };
                        string CategoryDataPath = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllCategoriesData.csv";
                        using (StreamWriter write = new StreamWriter(CategoryDataPath))
                        using (CsvWriter writing = new CsvWriter(write,config) )
                        {
                            writing.WriteRecords(OperationOnCategories.categoryList);
                        }
                        string ProductDataPath = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllProductsData.csv";
                        using (StreamWriter writeprod  = new StreamWriter(ProductDataPath))
                        using (CsvWriter writingprod = new CsvWriter(writeprod, config))
                        {
                            writingprod.WriteRecords(OperationOnProducts.ProductsList);
                        }

                        Console.WriteLine("See You Soon\n Stay Safe");
                    break;
                default:
                    Console.WriteLine("Invalid Operatoin\nTry Again");
                    break;
            }
        }
    }
    public void ProductCatalog()
    {

        //var input = Console.ReadLine().ToLower();
        bool ExitProduct = false;
        while (ExitProduct != true)
        {
            Console.WriteLine("------- Product Catalog --------\n");
            Console.WriteLine("a. Enter a Product \n");
            Console.WriteLine("b. List all products\n");
            Console.WriteLine("c. Delete a Product(Enter Short Code or ID to delete)\n");
            Console.WriteLine("d. Search a Product(By Id, Name, Short Code, Selling Price Greater than / Less Than / Equal To entered price)\n");
            Console.WriteLine("e. Exit\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    operationOnProducts.AddProduct();
                    break;
                case "b":
                    try
                    {
                        operationOnProducts.DisplayAllProducts();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("No Products Avaliable");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }
                    break;
                case "c":
                    try
                    {
                        operationOnProducts.DeleteAProduct();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Products Not Avaliable Or Already Deteted");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }
                    break;
                case "d":
                    try
                    {
                        operationOnProducts.SearchAProduct();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Products Not Avaliable of this kind");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }

                    break;
                case "e":
                    ExitProduct = true;
                    Console.WriteLine("Exiting..............");
                    Console.Clear();
                    this.DisplayCatalog();
                    break;
                default:
                    Console.WriteLine("Invalid Operation\nTry Again");

                    break;
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void CategoryCatalog()
    {
        bool ExitCategory = false;
        while (ExitCategory != true)
        {
            Console.WriteLine("-------- Category Catalog --------\n");
            Console.WriteLine("a. Enter a Category\n");
            Console.WriteLine("b. List all Categories\n");
            Console.WriteLine("c. Delete a Category(Enter Short Code or ID to delete)\n");
            Console.WriteLine("d. Search a Category(By Id, Name or Short Code)\n");
            Console.WriteLine("e. Exit\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    OperationOnCategories.AddCategory();
                    break;
                case "b":
                    try
                    {
                        OperationOnCategories.DisplayCategories();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("No category Avaliable");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }
                    break;
                case "c":
                    try
                    {
                        OperationOnCategories.DeleteCategory();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("No category Avaliable or Already Deleted");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }
                    break;
                case "d":
                    try
                    {
                        OperationOnCategories.SearchCategory();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("No category Avaliable of this kind");
                        Console.WriteLine("Press Enter For Main Menu");
                        Console.ReadKey();
                        Console.Clear();
                        this.DisplayCatalog();
                    }
                    break;
                case "e":
                    ExitCategory = true;
                    Console.WriteLine("Exiting..............");
                    Console.Clear();
                    this.DisplayCatalog();
                    break;
                default:
                    Console.WriteLine("Invalid Operation\nTry Again");
                    break;

            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
}
