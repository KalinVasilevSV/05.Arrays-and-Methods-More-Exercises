using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Inventory_Matcher
{

    //Really proud with this one as well.
    //Things to note. Trim() is required becaause input strings may cause extra spaces and therefore extra array elements causing exceptions
    //Prices require a specific output format requiring them to be stored in string[] instead of double[]. Problem wording is tricky about it.

    class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = Console.ReadLine().Trim().Split();
            long[] quantities = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
            string[] prices = Console.ReadLine().Trim().Split().ToArray();

            List<Product> productsList = Product.GetProductsList(productNames, quantities, prices);
            
            while(true)
            {
                string productQuerry = Console.ReadLine();

                if (productQuerry == "done")
                    break;
                else
                {
                    foreach(Product product in productsList)
                    {
                        if(productQuerry==product.name)
                        {
                            Product.PrintProductDetails(product);
                        }
                    }
                }
            }

        }

        class Product
        {
            public string name;
            public long quantity;
            public string price;

            public static List<Product> GetProductsList(string[] productNames, long[] quantities, string[] prices)
            {
                List<Product> ProductsList = new List<Product>();

                for (int i = 0; i < productNames.Length; i++)
                {
                    Product product = new Product();
                    product.name = productNames[i];
                    product.quantity = quantities[i];
                    product.price = prices[i];

                    ProductsList.Add(product);
                }

                return ProductsList;
            }

            public static void PrintProductDetails(Product product)
            {
                Console.WriteLine($"{product.name} costs: {product.price}; Available quantity: {product.quantity}");
            }
        }
    }
}
