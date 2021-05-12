using product.Data.Entities;
using product.Data.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace product.Data.OperationOnEntities
{
    public class OperationOnCategories
    {
        public static List<Category> categoryList = new List<Category>();
        public OperationOnCategories()
        {
            categoryList.Clear();
            Category.AutoIncrement = 0;
            List<string> CategoryDataFromFile =CsvFileProcessor.ReadCategoriesData();
            foreach(var categorydata in CategoryDataFromFile)
            {
                var values = categorydata.Split(',');
                categoryList.Add(new Category{ Name = $"{values[1]}", ShortCode = $"{values[2]}", Description = $"{values[3]}" } );
            }
        }
        ShortCodeValidation shortcodevalidation = new ShortCodeValidation();
        CategoryProductRequired necessary = new CategoryProductRequired();
        public void AddCategory()
        {
            Console.Clear();
            Console.WriteLine("Enter Category Details :");
            Console.WriteLine("Enter New Category Name : ");
            string name = necessary.CategoryNamerequired();
            Console.WriteLine("\nEnter Description : ");
            string description = necessary.CategoryDescriptionRequired();
            Console.WriteLine("\nEnter Short Code : ");
            string shortCode = shortcodevalidation.ShortCodeValidatingCategory();
            categoryList.Add(new Category
            {
                Name = name,
                Description = description,
                ShortCode = shortCode
            });
            Console.WriteLine("New Catogery Added succesfully");
        }
        public void DisplayCategories()
        {
            Console.Clear();
            Console.WriteLine("Catogriess Are:");
            foreach (Category category in categoryList)
            {
                Console.WriteLine(category.ToString());
            }
            Console.ReadKey();
            Console.WriteLine("Press enter to continue");
            Console.Clear();

        }
        public void DeleteCategory()
        {
            Console.Clear();
            bool ExitDelete = false;
            while (ExitDelete != true)
            {
                Console.WriteLine("----- Deleting Category");
                Console.WriteLine("a. Delete by Name");
                Console.WriteLine("b. Delete by Id ");
                Console.WriteLine("c. Delete by Short Code ");
                Console.WriteLine("d. Exit");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.WriteLine("Enter Name : ");
                        string inputName = Console.ReadLine();
                        Category findname = categoryList.Single(single => inputName == single.Name);
                        categoryList.Remove(findname);
                        OperationOnProducts.ProductsList.RemoveAll(finding => finding.ProductCategory == inputName);
                        Console.WriteLine("Removed Successfully");
                        break;
                    case "b":
                        Console.WriteLine("Enter Id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var findid = categoryList.Single(single => id == single.Id);
                        categoryList.Remove(findid);
                        OperationOnProducts.ProductsList.RemoveAll(finding => finding.ProductCategory == findid.Name);
                        Console.WriteLine("Removed Successfully");
                        break;
                    case "c":
                        Console.WriteLine("Enter Short Code : ");
                        string ShortCode = Console.ReadLine();
                        Category findshortcode = categoryList.Single(single => ShortCode == single.ShortCode);
                        categoryList.Remove(findshortcode);
                        OperationOnProducts.ProductsList.RemoveAll(finding => finding.ProductCategory == findshortcode.Name);
                        Console.WriteLine("Removed Successfully");
                        break;
                    case "d":
                        ExitDelete = true;
                        Console.WriteLine("Exiting..............");
                        break;
                    default:
                        Console.WriteLine("Invalid Operation\nTry Again");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine("Press enter to continue");
                Console.Clear();
            }


        }
        public void SearchCategory()
        {
            Console.Clear();
            bool ExitSearch = false;
            while (ExitSearch != true)
            {
                Console.WriteLine("----- Search A Product -----");
                Console.WriteLine("a. By Id");
                Console.WriteLine("b. By Name");
                Console.WriteLine("c. By Short Code");
                Console.WriteLine("d. Exit");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.WriteLine("Enter Id To Search");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var category = categoryList.Single(single => id == single.Id);
                        Console.WriteLine(category.ToString());
                        break;
                    case "b":
                        Console.WriteLine("Enter Name ");
                        string name = Console.ReadLine();
                        var findname = categoryList.Single(single => name == single.Name);
                        Console.WriteLine(findname.ToString());
                        break;
                    case "c":
                        Console.WriteLine("Enter Short Code To Search");
                        string ShortCode = Console.ReadLine();
                        var findcategory = categoryList.Single(single => ShortCode == single.ShortCode);
                        Console.WriteLine(findcategory.ToString());
                        Console.WriteLine("Found Succesfully");
                        break;
                    case "d":
                        ExitSearch = true;
                        Console.WriteLine("Exiting..............");
                        Console.Clear();

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
