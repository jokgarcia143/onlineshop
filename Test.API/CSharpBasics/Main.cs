using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            //Console.Write("------C# Simple Data Types--------");
            //Primitive
            //CamelCase = Variables
            //Pascal = void ComputeSalary();

            string firstName;
            string lastName = "";
            string discountMessage = string.Empty;
            bool isSingle = false;
            int Age = 0;

            decimal dailyRate = 500.4543434343432m;
            int workDays = 30;
            //
            decimal salary = workDays * dailyRate;
            decimal allowance = 500;
            decimal deductions = 1000;
            int salaryWithAllowance = (Convert.ToInt32(salary + allowance) - Convert.ToInt32(deductions));

            //Console.Write("Enter Your First Name: ");
            //firstName = Console.ReadLine();

            //Console.Write("Enter Your Last Name: ");
            //lastName = Console.ReadLine();

            //Console.Write("Enter Your Age: ");

            //string tempAge = Console.ReadLine();
            //Age = Convert.ToInt32(tempAge);

            if (Age >= 60)
            {
                discountMessage = " Senior Discount is 30% ";
            }
            else if (Age >= 19 && Age <= 59)
            {
                string discountPercentage;
                Console.Write("Enter Discount: ");
                discountPercentage = Console.ReadLine();

                discountMessage = $"with {discountPercentage}% Discount";
            }
            else
            {
                discountMessage = "Minor Age Bracket";
            }
        
            //Console.WriteLine("Hello " + firstName + " Age: " + Age + " Rate: " + dailyRate + " Salary for Jan: " + salaryWithAllowance + " " + discountMessage);

            Console.WriteLine("------C# Collections--------");

            Console.WriteLine("------C# List--------");
            
            List<string> productList = new List<string>()
            {
                "Kojic","Toner","Sunblock"
            };


            Console.WriteLine("Record 2: " + productList[1]);
            
            for (int i = 0; i < productList.Count; i++) { 
                Console.WriteLine($"Record: {i} = " + productList[i]);
            }

            Console.WriteLine("------C# ArrayList--------");
           
            ArrayList employee = new ArrayList();

            employee.Add("Jok");
            employee.Add("Jane");
            employee.Add("Jerry");
            employee.Add(1000.56m);
            employee.Add(false);

            for (int x = 0; x < employee.Count; x++)
            {
                Console.WriteLine($"Employee: {x} = " + employee[x]);
            }

            Console.WriteLine($"Employee #2: " + employee[1]);

            Console.WriteLine("------C# Dictionary--------");
            
            //id / description
            Dictionary<int, string> category = new Dictionary<int, string>();

            //add items to dictionary
            category.Add(1, "Electronics");
            category.Add(2, "Beverages");
            category.Add(3, "Skin Care");
            category.Add(4, "Fruits");

            for (int y = 1; y <= category.Count; y++)
            {
                Console.WriteLine($"Category: = " + category[y]);
            }

            Console.WriteLine($"Category #3: " + category[3]);

            Console.WriteLine("------C# Anonymous--------");
            var supplier = new 
            {
                Id = 1, 
                Company = "XYZ", 
                Contact = "Angie"  
            };

            Console.WriteLine("Supplier:" + supplier);

            Console.WriteLine("------C# Nested Anonymous--------");
            var product = new 
            { 
                Id = 1, 
                SKU = "Valenciaga", 
                Description = "Imported",
                Supplier = new
                {
                    Id = 1,
                    Company = "XYZ",
                    Contact = "Angie"
                }
            };
            
            Console.WriteLine("Contact Person:" + product.Supplier.Contact);

            Console.WriteLine("------C# Object Oriented Programming--------");
            
            //Instantiate Class for multiple purpose
            Product product1 = new Product();
            Product product2 = new Product();
            //Instantiate Order
            OrderTest order1 = new OrderTest();
            OrderTest order2 = new OrderTest();

            product1.Id = 1;
            product1.Name = "Samsung S4";
            product1.Price = 5100.50m;
            var sellingPrice1 = product1.ComputeSellingPrice(150.34m);
            order1.Quantity = 100;
            var totalOrder1 = order1.ComputeTotalOrder(sellingPrice1);

            
            product2.Id = 2;
            product2.Name = "Vivo V40";
            product2.Price = 3000.50m;
            var sellingPrice2 = product2.ComputeSellingPrice(120.34m);
            order2.Quantity = 40;
            var totalOrder2 = order2.ComputeTotalOrder(sellingPrice2);


            Console.WriteLine($"Product 1 {product1.Name} Selling Price : {sellingPrice1} Total1 = {totalOrder1}");
            Console.WriteLine($"Product 2 {product2.Name} Selling Price : {sellingPrice2} Total2 = {totalOrder2}");


        }
    }
}
