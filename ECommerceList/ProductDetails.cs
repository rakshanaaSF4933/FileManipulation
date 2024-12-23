using System;

namespace ECommerceList
{
    /// <summary>
    /// Class <see cref="ProductDetails"/> used to product details
    /// </summary>
    public class ProductDetails
    {
        
        /// <summary>
        /// Field s_productID provides unique id for instances of <see cref="ProductDetails"/>
        /// </summary>
        public static int s_productID = 2000;

        /// <summary>
        /// Property ProductID provide unique id for instances of <see cref="ProductDetails"/>
        /// </summary>
        /// <value>String Product ID</value>
        public string ProductID{get;set;}

        /// <summary>
        /// Property ProductName provides product name for instances of <see cref="ProductDetails"/>
        /// </summary>
        /// <value>String PRoduct Name</value>
        public string ProductName{get;set;}

        /// <summary>
        /// Property Stock provides stock balance for instances of <see cref="ProductDetails"/>
        /// </summary>
        /// <value>int Stock</value>
        public int Stock{get;set;}

        /// <summary>
        /// Property Price provides Price for instances of <see cref="ProductDetails"/>
        /// </summary>
        /// <value>double Price</value>
        public double Price{get;set;}

        /// <summary>
        /// Property Duration provides Shipping Duration for instances of <see cref="ProductDetails"/>
        /// </summary>
        /// <value>double Duration</value>
        public double Duration{get;set;}

        /// <summary>
        /// Consructor to assign instance of <see cref="ProductDetails"
        /// </summary>
        public ProductDetails()
        {

        }

        /// <summary>
        /// Constructor <see cref="PropertyDetails"/> used to assign product details 
        /// </summary>
        /// <param name="productName">used to store product name</param>
        /// <param name="stock">used to store product stock</param>
        /// <param name="price">used to store product price</param>
        /// <param name="duration">used to store product shipping duration</param>
        public ProductDetails(string productName,int stock,double price,double duration)
        {
            ProductID = $"PID{++s_productID}";
            ProductName = productName;
            Stock = stock;
            Price = price;
            Duration = duration;
        }
        public ProductDetails(string products)
        {
            string[] data = products.Split(",");
            ProductID = data[0];
            s_productID=int.Parse(data[0].Remove(0,3));
            ProductName = data[1];
            Stock = int.Parse(data[2]);
            Price = double.Parse(data[3]);
            Duration = double.Parse(data[4]);
        }
    }
}