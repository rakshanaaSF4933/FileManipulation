using System;
using System.Runtime.InteropServices;
namespace ECommerceList
{
    /// <summary>
    /// Class <see cref="Shopping"/> used to do shopping
    /// </summary>
    public static class Shopping
    {
        /// <summary>
        /// List orders used to store orders list 
        /// </summary>
        /// <typeparam name="OrderDetails"></typeparam>
        /// <returns>orders</returns>
        public static CustomList<OrderDetails> orders = new CustomList<OrderDetails>();

        /// <summary>
        /// List products used to store product list 
        /// </summary>
        /// <typeparam name="ProductDetails"></typeparam>
        /// <returns>products</returns>
        public static CustomList<ProductDetails> products = new CustomList<ProductDetails>();

        /// <summary>
        /// List customers used to store customer details
        /// </summary>
        /// <typeparam name="CustomerDetails"></typeparam>
        /// <returns>customers</returns>
        public static CustomList<CustomerDetails> customers = new CustomList<CustomerDetails>();

        /// <summary>
        /// Object productStock creates instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <returns></returns>
        public static ProductDetails productStock = new ProductDetails();

        public static CustomerDetails customer;

        /// <summary>
        /// Method DefaultData used to add default values
        /// </summary>
        public static void DefaultData()
        {
            customers.Add(new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com"));
            customers.Add(new CustomerDetails("Baskaran", "Chennai", "9888475757", "baskaran@mail.com"));

            products.Add(new ProductDetails("Mobile (Samsung)", 10, 10000, 3));
            products.Add(new ProductDetails("Tablet (Lenovo)", 5, 15000, 2));
            products.Add(new ProductDetails("Camara (Sony)", 3, 20000, 4));
            products.Add(new ProductDetails("iPhone", 5, 50000, 6));
            products.Add(new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3));
            products.Add(new ProductDetails("HeadPhone (Boat)", 5, 1000, 2));
            products.Add(new ProductDetails("Speakers (Boat)", 4, 500, 2));

            orders.Add(new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orders.Add(new OrderDetails("CID3001", "PID2002", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orders.Add(new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered));
        }

        /// <summary>
        /// Method Operation used to perform shopping
        /// </summary>
        public static void Operation()
        {
            try
            {
                string repeat = "yes";
                do
                {
                    Console.WriteLine("***************MAIN MENU***************");
                    Console.WriteLine("    1.Customer Registration\n    2.Customer Login\n    3.Exit");
                    int option;
                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid...Try Again\n    1. CustomerRegistration\n    2. Customer Login\n    3. Exit");
                    }
                    switch (option)
                    {
                        case 1:
                            {
                                GetDetails();
                                break;
                            }
                        case 2:
                            {
                                CustomerLogin();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Thank You :)");
                                repeat = "no";
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter valid option...");
                                break;
                            }
                    }
                } while (repeat == "yes");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Method GetDetails used to get customer details
        /// </summary>
        public static void GetDetails()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter mobile number: ");
            string mobile = Console.ReadLine();
            Console.WriteLine("Enter mail id: ");
            string mailID = Console.ReadLine();

            customer = new CustomerDetails(name, city, mobile, mailID);
            customers.Add(customer);

            Console.WriteLine($"Customer details registered successfully...\nCustomerID : {customer.CustomerID}\n");
        }

        /// <summary>
        /// Method CustomerLogin used to do shopping
        /// </summary>
        public static void CustomerLogin()
        {
            System.Console.WriteLine("Enter Customer ID : ");
            string customerID = Console.ReadLine().ToUpper();
            BinarySearch<CustomerDetails> binarySearch = new BinarySearch<CustomerDetails>();
            int found = binarySearch.Search(customers, customerID, out customer);
            if (found == -1)
            {
                Console.WriteLine("Customer ID not found");
            }
            else
            {
                SubMenu();
            }
        }

        public static void SubMenu()
        {
            int showAgain = 1;
            do
            {
                Console.WriteLine("***************MENU***************");
                Console.WriteLine("    a.Purchase\n    b.Order History\n    c.Cancel Order\n    d.Wallet Balance\n    e.Wallet Recharge\n    f.Exit\n");
                char option;
                while (!char.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid...Try Again \n    a.Purchase\n    b.Order History\n    c.Cancel Order\n    d.Wallet Balance\n    e.WalletRecharge\n    f.Exit\n");
                }
                switch (option)
                {
                    case 'a':
                        {
                            //Purchase
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            //Order History
                            showOrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            //Cancel Order
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            //Wallet Balance
                            CheckBalance();
                            break;
                        }
                    case 'e':
                        {
                            //Wallet Recharge
                            WalletRecharge();
                            break;
                        }
                    case 'f':
                        {
                            //Exit
                            showAgain = 0;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter valid option...");
                            break;
                        }
                }
            } while (showAgain == 1);
        }

        /// <summary>
        /// Method Purchase used to purchase products
        /// </summary>
        /// <param name="customer">instance of current customer</param>
        public static void Purchase()
        {
            // Show list of products
            ShowProducts();

            // Ask the customer to select a product using the Product ID.
            Console.WriteLine("\nEnter Product ID : ");
            string productID = Console.ReadLine().ToUpper();
            ProductDetails product;
            BinarySearch<ProductDetails> binarySearch = new BinarySearch<ProductDetails>();
            int found = binarySearch.Search(products, productID, out product);
            if (found == -1)
            {
                System.Console.WriteLine("Product ID not found");
            }
            else
            {

                //Get count he wishes to purchase.
                Console.WriteLine("Enter Count you need to purchase : ");
                int count;
                while (!int.TryParse(Console.ReadLine(), out count))
                {
                    Console.WriteLine("Enter correct number");
                }
                if (count > product.Stock)
                {
                    //Not enough stock
                    Console.WriteLine($"Required count not available. Current availability is {product.Stock}.");
                }
                else
                {
                    //calculate the total amount
                    double total = (count * product.Price) + 50;
                    //Sufficient balance
                    if (customer.WalletBalance >= total)
                    {
                        //Deduct balance
                        customer.DeductBalance(total);
                        //Decrease stock count
                        product.Stock -= count;
                        //add it to the order list
                        OrderDetails order = new OrderDetails(customer.CustomerID, product.ProductID, total, DateTime.Now, count, OrderStatus.Ordered);
                        orders.Add(order);
                        Console.WriteLine($"\nOrder Placed Successfully. Order ID: {order.OrderID}");
                        Console.WriteLine($"Order placed successfully.Your order will be delivered on {order.PurchaseDate.AddDays(product.Duration)}.\n");

                    }
                    //Insufficient balance
                    else
                    {
                        Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do the purchase again.");
                    }
                }
            }
        }

        /// <summary>
        /// Method ShowProducts used to show list of products
        /// </summary>
        public static void ShowProducts()
        {
            //Product details
            Grid<ProductDetails> productGrid = new Grid<ProductDetails>();
            productGrid.ShowTable(products);
        }

        /// <summary>
        /// Method showOrders used to list all orders of customer
        /// </summary>
        public static void showOrderHistory()
        {
            //Show all orders
            CustomList<OrderDetails> customerOrders = new CustomList<OrderDetails>();
            Grid<OrderDetails> orderGrid = new Grid<OrderDetails>();
            foreach (OrderDetails order in orders)
            {
                if (order.CustomerID.Equals(customer.CustomerID))
                {
                    customerOrders.Add(order);
                }
            }
            if (customerOrders.Count <= 0)
            {
                System.Console.WriteLine("NO ORDER HISTORY");
            }
            else
            {
                orderGrid.ShowTable(customerOrders);
            }
        }

        /// <summary>
        /// Method showOrder used to show details of products ordered by the customer
        /// </summary>
        public static int showOrder()
        {
            //Show all orders placed by the current logged-in customer whose order status is Ordered.
            CustomList<OrderDetails> customerOrders = new CustomList<OrderDetails>();
            Grid<OrderDetails> orderGrid = new Grid<OrderDetails>();

            foreach (OrderDetails order in orders)
            {
                if (order.OrderStatus == OrderStatus.Ordered && order.CustomerID.Equals(customer.CustomerID))
                {
                    customerOrders.Add(order);
                }
            }
            if (customerOrders.Count <= 0)
            {
                System.Console.WriteLine("NO ORDER HISTORY");
                return -1;
            }

            orderGrid.ShowTable(customerOrders);
            return 1;
        }

        /// <summary>
        /// Method CheckBalance used to check the wallet balance
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void CheckBalance()
        {
            Console.WriteLine($"WalletBalance : {customer.WalletBalance}");
        }

        /// <summary>
        /// Method WalletRecharge used to recgarge the wallet amount
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void WalletRecharge()
        {
            //Ask the customer whether he wishes to recharge the wallet. 
            int repeat;
            string ask;
            do
            {
                Console.WriteLine("Do you want to recharge your wallet? yes or no : ");
                ask = Console.ReadLine().ToLower();
                if (ask == "yes" || ask == "no")
                {
                    repeat = 0;
                }
                else
                {
                    Console.WriteLine("Please answer yes or no.");
                    repeat = 1;
                }
            } while (repeat == 1);
            if (ask.Equals("yes"))
            {
                //Get amount
                Console.WriteLine("Enter amount : ");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Enter valid amount.");
                }
                customer.WalletRecharge(amount);
                Console.WriteLine($"WalletBalance : {customer.WalletBalance}");
            }

        }

        /// <summary>
        /// Method CancelOrder used to cancel order of the customer
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void CancelOrder()
        {
            // Show all orders placed by the current logged-in customer whose order status is Ordered.
            int noOrder = showOrder();
            //If(order is Present calcel order)
            if (noOrder == 1)
            {
                //Ask the customer to select an order to be cancelled by the OrderID.
                Console.WriteLine("\nEnter order ID : ");
                string orderID = Console.ReadLine().ToUpper();
                OrderDetails order;
                BinarySearch<OrderDetails> binarySearch = new BinarySearch<OrderDetails>();
                int orderFound = binarySearch.Search(orders, orderID, out order);

                if (orderFound == -1)
                {
                    Console.WriteLine("Invalid OrderID...");
                }
                else
                {
                    if (orders[orderFound].OrderStatus == OrderStatus.Ordered)
                    {
                        //Increase the available stock quantity by the count of products purchased in the current order to be cancelled.
                        productStock.Stock += orders[orderFound].Quantity;
                        //Refund the amount to the customer’s wallet balance.
                        customer.WalletRecharge(orders[orderFound].TotalPrice);
                        //Change the order status to “Cancelled”
                        orders[orderFound].OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"\nOrder:{orders[orderFound].OrderID} cancelled successfully.");
                    }
                    else
                    {
                        System.Console.WriteLine("NO SUCH ORDER AVAILABLE....");
                    }
                }
            }
        }
    }
}