using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ECommerceList
{
    public class FileHandling
    {
        public static void CreateFile()
        {
            if(!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
            if(!File.Exists("Files/Customers.csv"))
            {
                File.Create("Files/Customers.csv").Close();
            }
            if(!File.Exists("Files/Orders.csv"))
            {
                File.Create("Files/Orders.csv").Close();
            }
            if(!File.Exists("Files/Products.csv"))
            {
                File.Create("Files/Products.csv").Close();
            }
        }
        public static void WriteCSV()
        {
            string[] customers = new string[Shopping.customers.Count];
            for(int i=0;i<customers.Length;i++)
            {
                customers[i]= Shopping.customers[i].CustomerID + "," + Shopping.customers[i].CustomerName+ "," +Shopping.customers[i].City+ "," +Shopping.customers[i].MobileNumber+ "," +Shopping.customers[i].EmailID;
            }
            File.WriteAllLines("Files/Customers.csv",customers);

            string [] orders =new string[Shopping.orders.Count];
            for(int i=0;i< orders.Length;i++)
            {
                orders[i]=Shopping.orders[i].OrderID +","+ Shopping.orders[i].CustomerID +","+Shopping.orders[i].ProductID +","+Shopping.orders[i].TotalPrice +","+Shopping.orders[i].PurchaseDate.ToString("dd/MM/yyyy") +","+Shopping.orders[i].Quantity +","+Shopping.orders[i].OrderStatus ;
            }
            File.WriteAllLines("Files/Orders.csv",orders);

            string[] products = new string[Shopping.products.Count];
            for(int i=0;i<products.Length;i++)
            {
                products[i]= Shopping.products[i].ProductID + "," +Shopping.products[i].ProductName + "," +Shopping.products[i].Stock + "," +Shopping.products[i].Price + "," +Shopping.products[i].Duration;
            }
            File.WriteAllLines("Files/Products.csv",products);
        }
        public static void ReadCSV()
        {
            string [] customers = File.ReadAllLines("Files/Customers.csv");
            foreach(string customer in customers)
            {
                CustomerDetails customerDetails = new CustomerDetails(customer);
                Shopping.customers.Add(customerDetails);
            }
            string [] orders = File.ReadAllLines("Files/Orders.csv");
            foreach(string order in orders)
            {
                OrderDetails orderDetails = new OrderDetails(order);
                Shopping.orders.Add(orderDetails);
            }
            string [] products = File.ReadAllLines("Files/Products.csv");
            foreach(string product in products)
            {
                ProductDetails productDetails = new ProductDetails(product);
                Shopping.products.Add(productDetails);
            }
        }
    }
}