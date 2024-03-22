using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WsdlServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    // Define an interface for WSDL services.
    [ServiceContract]
    public interface IWsdlServices
    {
        // Define a method to retrieve a restaurant's menu.
        [OperationContract]
        Dictionary<string, double> GetMenu(string restaurantId);

        // Define a method to add items to a shopping cart.
        [OperationContract]
        void AddToCart(string itemName, double price, int quantity);

        // Define a method to view the items in the shopping cart.
        [OperationContract]
        List<CartItem> ViewCart();

        // Define a method to get the total amount in the shopping cart.
        [OperationContract]
        double GetTotalAmount();

        // Define a method to apply a coupon to the shopping cart.
        [OperationContract]
        double ApplyCoupon(string couponCode);

        // Define a method to place an order with an email address.
        [OperationContract]
        void PlaceOrder(string emailAddress);

        [OperationContract]
        string ReviewAndRate(int value, string lateornot);

        [OperationContract]
        string DoPayment(string cardNumber, string expiry, string CVV);

        [OperationContract]
        void NotifyPayment(string emailId, string restaurantName);

        [OperationContract]
        Task<List<RestaurantDetails>> GetRestaurantsByAddress(string address);

        [OperationContract]
        void StoreOrder(string orderId, string customerName, string restaurantName, string customerAddress, double amount);

        [OperationContract]
        List<Order> LoadOrders();

        [OperationContract]
        Task<DeliveryDeatils> GetDeliveryDetails(string userAddress, string restaurantAddress);
    }

    [DataContract]
    public class RestaurantDetails
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }

    [DataContract]
    public class Order
    {
        [DataMember]
        public string OrderId { get; set; }
        
        [DataMember]
        public string CustomerName { get; set; }
        
        [DataMember]
        public string RestaurantName { get; set; }
        
        [DataMember]
        public string CustomerAddress { get; set; }
        
        [DataMember]
        public double Amount { get; set; }
    }

    [DataContract]
    public class DeliveryDeatils
    {
        [DataMember]
        public string Distance { get; set; }

        [DataMember]
        public string Time { get; set; }
    }
}
