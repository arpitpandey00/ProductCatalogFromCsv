using product.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using prod=product.Data.Entities;

namespace product.Data
{
    public  class CsvFileProcessor
    {
        public string InputFilePath { get;  }
        public string OutputFiliePath { get;  }
       
        public static void WriteProductData(prod.Product product)
        {
            string newFileName = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllProductsData.csv";
            string clientDetails = "\n"+ product.Id+","+ product.Name + "," + product.Manufacturer + "," + product.ProductCategory + "," + product.ShortCode + "," + product.SellingPrice + "," + product.Description +",";


            if (!File.Exists(newFileName))
            {
                string clientHeader = "Id" + "," + "Name" + "," + "Manufacturer" + "," + "Product Category" + "," + "Short Code" + "," + "Selling Price" +"," +"Description" + Environment.NewLine;

                File.WriteAllText(newFileName, clientHeader);
            }

            File.AppendAllText(newFileName, clientDetails);

        }
        public static void WriteCategoryData(Category category)
        {
            string newFileName = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllcategoriesData.csv";
            string clientDetails = "\n" + category.Id + "," + category.Name +  "," + category.ShortCode + ","  + category.Description + ",";


            if (!File.Exists(newFileName))
            {
                string clientHeader = "Id" + "," + "Name" +  "," + "Short Code" +  "," + "Description" + Environment.NewLine;

                File.WriteAllText(newFileName, clientHeader);
            }

            File.AppendAllText(newFileName, clientDetails);

        }
       
        public static List<string> ReadProductsData()
            {
            string ProductDataPath = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllProductsData.csv";
            using (StreamReader reader = new StreamReader(ProductDataPath))
            {
                List<string> str = new List<string>();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    str.Add(reader.ReadLine());
                }
                return str;
            }
        }
        public static List<string> ReadCategoriesData()
        {
            string CategoryDataPath = @"C:\work\day 2 revision\ProductCatalogWithFiles\Product\Product.solution\Data\AllCategoriesData.csv";

            using (StreamReader reader = new StreamReader(CategoryDataPath))
            {
                List<string> str = new List<string>();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                      str.Add(reader.ReadLine());
                }
                return str;
            }
        }
    }
    }

