using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Upgraded_Matcher
{
    //Very proud with this as well.
    //Second test in Judge required ulong for quantities

    class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = Console.ReadLine().Trim().Split();
            ulong[] quantities = Console.ReadLine().Trim().Split().Select(ulong.Parse).ToArray();
            string[] prices = Console.ReadLine().Trim().Split().ToArray();

            List<Product> productsList = Product.GetProductsList(productNames, quantities, prices);

            while (true)
            {
                Order order = new Order(Console.ReadLine());


                if (order.productName == "done")
                    break;
                else
                {
                    foreach (Product product in productsList)
                    {
                        if (order.productName == product.name)
                        {
                            order.Process(product);
                        }
                    }
                }
            }

        }

        class Order
        {
            public string productName;
            public ulong quantity;

            public Order(string order)
            {
                string[] orderInput = order.Trim().Split();

                this.productName = orderInput[0];
                try
                {
                    this.quantity = ulong.Parse(orderInput[1]);
                }
                catch (IndexOutOfRangeException)
                {
                    this.quantity = 0;
                }
            }

            public void Process(Product product)
            {
                if (product.quantity > 0 && this.quantity <= product.quantity)
                {
                    product.quantity -= this.quantity;

                    Console.WriteLine($"{this.productName} x {this.quantity} costs {(this.quantity*decimal.Parse(product.price)):0.00}");
                }
                else
                {
                    Console.WriteLine($"We do not have enough {this.productName}");
                }
            }
        }

        class Product
        {
            public string name;
            public ulong quantity;
            public string price;

            public static List<Product> GetProductsList(string[] productNames, ulong[] quantities, string[] prices)
            {
                List<Product> ProductsList = new List<Product>();

                for (int i = 0; i < productNames.Length; i++)
                {
                    Product product = new Product();
                    product.name = productNames[i];
                    try
                    {
                        product.quantity = quantities[i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        product.quantity = 0;
                    }
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
