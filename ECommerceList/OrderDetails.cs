using System;
using System.Data.SqlTypes;

namespace ECommerceList
{
    /// <summary>
    /// Class <see cref="OrderDetails"/> used to store order details
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Field s_orderId used to store unique id for instances of <see cref="OrderDetails"/>
        /// </summary>
        public static int s_orderID = 3000;

        /// <summary>
        /// Property OrderID provides OrderID for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>string OrderID</value>
        public string OrderID{get;set;}

        /// <summary>
        /// Property CustomerId provides customer ID for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>string CustomerID</value>
        public string CustomerID{get;set;}

        /// <summary>
        /// Property ProductID provides product ID for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>string ProductID</value>
        public string ProductID{get;set;}

        /// <summary>
        /// Property TotalPrice provides total price for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>double TotalPrice</value>
        public double TotalPrice{get;set;}

        /// <summary>
        /// Property PurchaceDate provides date of purchace for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>DateTime PurchaseDate</value>
        public DateTime PurchaseDate{get;set;}

        /// <summary>
        /// Property Quantity provides quantity for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>int Quantity</value>
        public int Quantity{get;set;}

        /// <summary>
        /// Property OrderStatus provides order status for instances of <see cref="OrderDetails"/>
        /// </summary>
        /// <value>Order Status</value>
        public OrderStatus OrderStatus{get;set;}

        /// <summary>
        /// Constructor <see cref="OrderDetails"/> used to assign values for order details
        /// </summary>
        /// <param name="customerID">used to store customer ID</param>
        /// <param name="productID">used to store product ID</param>
        /// <param name="totalPrice">used to store total price of product</param>
        /// <param name="purchaseDate">used to store purchasing date</param>
        /// <param name="quantity">used to store quantity</param>
        /// <param name="orderStatus">used to store order status</param>
        public OrderDetails(string customerID,string productID,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            OrderID = $"OID{++s_orderID}";
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string order)
        {
            string [] data = order.Split(",");
            OrderID = data[0];
            s_orderID =int.Parse(data[0].Remove(0,3));
            CustomerID = data[1];
            ProductID = data[2];
            TotalPrice = double.Parse(data[3]);
            PurchaseDate = DateTime.ParseExact(data[4],"dd/MM/yyyy",null);
            Quantity = int.Parse(data[5]);
            OrderStatus = Enum.Parse<OrderStatus>(data[6]);
        }
    }
}