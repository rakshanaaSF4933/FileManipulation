namespace ECommerceList
{
    ///<summary>
    /// Class <see cref="CustomerDetails" /> used to get Customers Details and calculate wallet balance of the customer
    /// </summary>
    public class CustomerDetails
    {
        /// <summary>
        /// Field s_customerID used increasing and providing unique customer ID for all customers
        /// </summary>
        public static int s_customerID = 3000;

        /// <summary>
        /// Field _wallerBalance provide wallet balance for customer
        /// </summary> 
        private double _walletBalance = 0.0;

        /// <summary>
        /// Property CustomerID provide unique customer ID for all customers
        /// </summary>
        /// <value>ID int string</value>
        public string CustomerID { get; set; }

         /// <summary>
        /// Property CustomerName provide name for all customers
        /// </summary>
        /// <value>name in string</value>
        public string CustomerName { get; set; }

         /// <summary>
        /// Property City provide city for all customers
        /// </summary>
        /// <value>city in string</value>
        public string City { get; set; }

        /// <summary>
        /// Property MobileNumber provide mobile number for all customers
        /// </summary>
        /// <value>mobile number</value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Property WalletBalance provide wallet balance for all customers
        /// </summary>
        /// <value>mobile number</value>
        public double WalletBalance { get { return _walletBalance; } }

        /// <summary>
        /// Property EmailID provide mail ID for all customers
        /// </summary>
        /// <value>mail ID in string</value>
        public string EmailID { get; set; }

        /// <summary>
        /// Constructor CustomerDetails <see cref="CustomerDetails"/> used to assign values to the customer details
        /// </summary>
        /// <param name="customerName">used to store customer name</param>
        /// <param name="city">used to store customer city</param>
        /// <param name="mobileNumber">used to store customer mobile number</param>
        /// <param name="emailID">used to store customer email ID</param>
        public CustomerDetails(string customerName, string city, string mobileNumber, string emailID)
        {
            CustomerID = $"CID{++s_customerID}";
            CustomerName = customerName;
            City = city;
            MobileNumber = mobileNumber;
            EmailID = emailID;
        }

        public CustomerDetails(string customer)
        {
            string [] data = customer.Split(",");
            CustomerID = data[0];
            s_customerID = int.Parse(data[0].Remove(0,3));
            CustomerName = data[1];
            City = data[2];
            MobileNumber = data[3];
            EmailID = data[4];
        }

        /// <summary>
        /// Method WalletRecharge <see cref="CustomerDetails"/>used to recharge customer wallet 
        /// </summary>
        /// <param name="amount">used to add to wallet</param>
        public void WalletRecharge(double amount)
        {
            _walletBalance += amount;
        }

        /// <summary>
        /// Method DeductBalance <see cref="CustomerDetails"/>used to detuct amount from customer wallet 
        /// </summary>
        /// <param name="amount">used to detuct amount to wallet</param>
        public void DeductBalance(double amount)
        {
            _walletBalance += amount;
        }
    }
}