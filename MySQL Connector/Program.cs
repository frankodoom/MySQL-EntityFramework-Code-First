using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;
using MySQL_Connector;

namespace MySQL_Connector
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductContext())
            {
                Console.WriteLine("Create A New Product");
               
                Product product = new Product();
                Console.WriteLine("Enter Price");
                product.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Quantity");
                product.Quantity = int.Parse(Console.ReadLine());
                context.Products.Add(product);
                if (context.SaveChanges() >0)
                {
                    Console.WriteLine("New Product Created");
                }
              else{
                    Console.WriteLine("Error in Creating Product");
                }
              
            }

        }
    }
}
