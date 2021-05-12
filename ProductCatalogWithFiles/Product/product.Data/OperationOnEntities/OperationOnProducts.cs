using product.Data.Entities;
using product.Data.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace product.Data.OperationOnEntities
{
    public class OperationOnProducts
    {

        public static List<Product> ProductsList = new List<Product>();
        public OperationOnProducts()
        {
            ProductsList.Clear();
            List<string> ProductDataFromFile = CsvFileProcessor.ReadProductsData();
            foreach (var Productdata in ProductDataFromFile)
            {
                var values = Productdata.Split(',');
                ProductsList.Add(new Product { Name = values[1], Manufacturer = values[2], ShortCode = values[3], ProductCategory = values[4], Description = values[5], SellingPrice = Convert.ToInt32(values[6]) });
            }
        }
        ShortCodeValidation shortCodeValidation = new ShortCodeValidation();
        PriceValidation priceValidation = new PriceValidation();
        
        ProductPropertyRequired necessary = new ProductPropertyRequired();

        public void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter Product Details :\n");
            Console.WriteLine("Enter Product Name : ");
            string name = necessary.ProductNameRequired();
            Console.WriteLine("\nEnter Manufacturer Name : ");
            string manufacturer = necessary.ProductManufacturerRequired(); ;
            Console.WriteLine("\nEnter Description : ");
            string description = necessary.ProductDescriptionRequired();
            Console.WriteLine("\nEnter Selling Price : ");
            int sellingprice = priceValidation.PriceValidating();
            Console.WriteLine("\nEnter Short Code : ");
            string shortCode = shortCodeValidation.ShortCodeValidatingproducts();
            Console.WriteLine("\nEnter category Of Product");
            string category = Console.ReadLine();
            bool iscategoryPresent = false;
            foreach (Category c in OperationOnCategories.categoryList)
            {
                if (c.Name.ToLower() == category.ToLower())
                    iscategoryPresent = true;
            }
            if (iscategoryPresent == false)
            {
                Console.WriteLine("\nThis category is not Added You Have To Add This Category\n");
                OperationOnCategories operationCategory = new OperationOnCategories();
                operationCategory.AddCategory();
            }
          
            ProductsList.Add(new Product
            {
                Name = name,
                Manufacturer = manufacturer,
                Description = description,
                SellingPrice = sellingprice,
                ProductCategory = category,
                ShortCode = shortCode

            });
            Console.WriteLine("Product Added succesfully\n");
            Console.WriteLine("Press Enter TO Continue:");
            
        }
        public void DisplayAllProducts()
        {
            Console.Clear();
            Console.WriteLine("Products Are:");
            foreach (Product products in ProductsList)
            {
                Console.WriteLine(products.ToString());
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();

        }
        public void DeleteAProduct()
        {
            Console.Clear();
            bool ExitDelete = false;
            while (ExitDelete != true)
            {
                Console.WriteLine("----- Deleting Product");
                Console.WriteLine("a. Delete by Short Code");
                Console.WriteLine("b. Delete by Id ");
                Console.WriteLine("c. Exit");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.WriteLine("Enter ShortCode : ");
                        string ShortcodeToFind = Console.ReadLine();
                        var findproduct = ProductsList.Single(single => ShortcodeToFind == single.ShortCode);
                        ProductsList.Remove(findproduct);
                        Console.WriteLine("Removed Successfully");
                        ExitDelete = true;
                        break;
                    case "b":
                        Console.WriteLine("Enter Id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var findid = ProductsList.Single(single => id == single.Id);
                        ProductsList.Remove(findid);
                        Console.WriteLine("Removed Successfully");
                        ExitDelete = true;
                        break;
                    case "c":
                        ExitDelete = true;
                        Console.WriteLine("Exiting..............");
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
        public List<Product> ProductGreaterThan = new List<Product>();
        public List<Product> ProductLessThan = new List<Product>();

        public void SearchAProduct()
        {
            Console.Clear();
            bool ExitSearch = false;
            while (ExitSearch != true)
            {
                Console.WriteLine("----- Search A Product -----");
                Console.WriteLine("a. By Id");
                Console.WriteLine("b. By Name");
                Console.WriteLine("c. By Selling Price Greater Than");
                Console.WriteLine("d. By Selling Price less Than");
                Console.WriteLine("e. By Selling Price Equal To");
                Console.WriteLine("f. By Short Code");
                Console.WriteLine("g. Exit");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.WriteLine("Enter Id To Search");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(id.ToString());
                        Console.WriteLine("Found Succesfully");
                        break;
                    case "b":
                        Console.WriteLine("Enter Name ");
                        string name = Console.ReadLine();
                        var findname = ProductsList.Single(single => name == single.Name);
                        Console.WriteLine(findname.ToString());
                        break;
                    case "c":
                        Console.WriteLine("Enter Selling Price Greater Than");
                        int InputGreater = Convert.ToInt32(Console.ReadLine());
                        foreach (Product prod in ProductsList)
                        {
                            if (prod.SellingPrice > InputGreater)
                            {
                                this.ProductGreaterThan.Add(prod);
                            }
                        }
                        foreach (Product output in ProductGreaterThan)
                        {
                            Console.WriteLine(output.ToString());
                        }
                        break;
                    case "d":
                        Console.WriteLine("Enter Selling Price Less Than");
                        int InputLess = Convert.ToInt32(Console.ReadLine());
                        foreach (Product prod in ProductsList)
                        {
                            if (prod.SellingPrice < InputLess)
                            {
                                this.ProductLessThan.Add(prod);
                            }
                        }
                        foreach (Product output1 in ProductLessThan)
                        {
                            Console.WriteLine(output1.ToString());
                        }
                        break;
                    case "e":
                        Console.WriteLine("Enter Search Price Equal TO");
                        int Equal = Convert.ToInt32(Console.ReadLine());
                        var PriceEqualsTO = ProductsList.Where(s => s.SellingPrice == Equal).ToList();
                        foreach (Product products in PriceEqualsTO)
                        {
                            Console.WriteLine(products.ToString());
                        }
                        break;
                    case "f":
                        Console.WriteLine("Enter Short Code : ");
                        string shotcodeToFind = Console.ReadLine();
                        var findshortcode = ProductsList.Single(single => shotcodeToFind == single.ShortCode);
                        Console.WriteLine(findshortcode.ToString());
                        break;
                    case "g":
                        ExitSearch = true;
                        Console.WriteLine("Exiting..............");
                        break;
                    default:
                        Console.WriteLine("Invalid Operation\nTry Again");
                        break;

                }

                Console.Clear();


            }

        }
    }
}
