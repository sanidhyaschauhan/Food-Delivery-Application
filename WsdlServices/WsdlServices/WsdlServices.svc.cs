using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace WsdlServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WsdlServices : IWsdlServices
    {

        // Define a method to retrieve a restaurant's menu.
        public Dictionary<string, double> GetMenu(string restaurantId)
        {
            var menu = new Dictionary<string, double>();

            // Get the path to the XML file in the App_Data folder
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/menu.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Find the restaurant node by its Id
            XmlNode restaurantNode = doc.SelectSingleNode($"/Restaurants/Restaurant[Id='{restaurantId}']");
            if (restaurantNode != null)
            {
                // Parse the menu items
                XmlNodeList menuItems = restaurantNode.SelectNodes("Menu/Item");
                foreach (XmlNode item in menuItems)
                {
                    string name = item.SelectSingleNode("Name").InnerText;
                    double price = Convert.ToDouble(item.SelectSingleNode("Price").InnerText.TrimStart('$'));
                    menu[name] = price;
                }
            }

            return menu;
        }

        // Define a method to add items to a shopping cart.
        public void AddToCart(string itemName, double price, int quantity)
        {
            string cartFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Cart.xml");

            XDocument doc;
            if (!File.Exists(cartFilePath))
            {
                doc = new XDocument(new XElement("Cart"));
                doc.Save(cartFilePath);
            }
            else
            {
                doc = XDocument.Load(cartFilePath);
            }

            XElement newItem = new XElement("Item",
                new XElement("Name", itemName),
                new XElement("Price", price),
                new XElement("Quantity", quantity)
            );

            doc.Root.Add(newItem);
            doc.Save(cartFilePath);
        }

        // Define a method to view the items in the shopping cart.
        public List<CartItem> ViewCart()
        {
            string cartFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Cart.xml");
            var cartItems = new List<CartItem>();

            if (File.Exists(cartFilePath))
            {
                XDocument doc = XDocument.Load(cartFilePath);
                foreach (XElement item in doc.Root.Elements("Item"))
                {
                    cartItems.Add(new CartItem()
                    {
                        ItemName = item.Element("Name").Value,
                        Price = Convert.ToDouble(item.Element("Price").Value),
                        Quantity = Convert.ToInt32(item.Element("Quantity").Value)
                    });
                }
            }

            return cartItems;
        }

        // Define a method to get the total amount of items in the shopping cart.
        public double GetTotalAmount()
        {
            return ViewCart().Sum(item => item.Price * item.Quantity);
        }

        // Define a method to apply a coupon to the shopping cart and calculate the discounted amount.
        public double ApplyCoupon(string couponCode)
        {
            double discountPercentage = GetDiscountPercentage(couponCode);
            double total = GetTotalAmount();
            double discountedAmount = total * (1 - (discountPercentage / 100));
            return discountedAmount;
        }

        // Define a method to retrieve the discount percentage from a coupon code.
        private double GetDiscountPercentage(string couponCode)
        {
            if (couponCode.ToLower() == "asu")
            {
                return 10.0;
            }
            return 0.0;
        }

        // Define a method to place an order with the given email address.
        public void PlaceOrder(string emailAddress)
        {
            double totalAmount = GetTotalAmount();

            // Prepare email body.
            StringBuilder emailBodyBuilder = new StringBuilder();
            emailBodyBuilder.AppendLine("<p>Cart Details:</p>");
            emailBodyBuilder.AppendLine("<ul>");
            foreach (var item in ViewCart())
            {
                emailBodyBuilder.AppendLine($"<li>{item.ItemName}: ${item.Price} x {item.Quantity}</li>");
            }
            emailBodyBuilder.AppendLine("</ul>");
            emailBodyBuilder.AppendLine($"<p>Total Amount: ${totalAmount}.</p>");

            // Send a confirmation email with the order details.
            SendEmail(emailAddress, emailBodyBuilder.ToString(), "Order Details");
        }

        // Define a method to send an email.
        private void SendEmail(string emailAddress, string emailBody, string subject)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "deliveryfoodapp.123@gmail.com";
            string smtpPassword = "wvys mwlg zulc ynpl";

            // Create the SmtpClient with the Gmail settings.
            SmtpClient smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
            };
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername),
                Subject = "Delivery Food App - " + subject,
                Body = emailBody,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(emailAddress);
            try
            {
                // Send the email and clear the shopping cart.
                smtpClient.Send(mailMessage);
                string cartFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Cart.xml");
                XDocument doc = XDocument.Load(cartFilePath);
                doc.Root.RemoveAll();
                doc.Save(cartFilePath);
            }
            catch (Exception ex)
            {
                // Handle email sending errors.
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public string ReviewAndRate(int value, string lateornot)
        {
            string ans = "";
            if (value >= 4)
            {
                ans = "Awesome! We would continue to be of service to you. Thank you for using us!";
            }
            else if (lateornot == "Late" && value >= 1 && value <= 3)
            {
                ans = "We are sorry for the late delivery. We will check with our delivery partner and make sure this doesn't happen again. If there is something else you'd like to say, please comment in the box below. Thankyou :)";
            }
            else if (value >= 1 && value <= 3)
            {
                ans = "Please tell us what can we improve in the below box. We will try to be better for you :)";
            }
            return ans;
        }


        //2nd
        public string DoPayment(string cardNumber, string expiry, string CVV)
        {
            if (cardNumber.Length < 15 || cardNumber.Length > 16)
            {
                return ("Card number is invalid");
            }

            // Parse the year and month from the expiry date
            string[] dateParts = expiry.Split('/');
            if (dateParts.Length != 2)
            {
                return ("Faulty: Invalid date format");
            }

            if (!int.TryParse(dateParts[0], out int month) || !int.TryParse(dateParts[1], out int year))
            {
                return ("Faulty: Invalid month or year");
            }

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Check if the year is not less than the current year
            if (year < currentDate.Year)
            {
                return ("Faulty: Year is in the past");
            }
            else if (year == currentDate.Year)
            {
                // If the year is the current year, check the month
                if (month < currentDate.Month)
                {
                    return ("Faulty: Month is in the past");
                }
            }
            else if (year > currentDate.Year && month < 1 || month > 12)
            {
                return ("Valid: Expiry date is invalid");
            }

            if (CallCreditCardVerificationAPI(cardNumber))
            {
                return ("Card number has been validated. Your transaction is successful.");
            }
            else
            {
                return ("Card number has NOT been validated. Your transaction is NOT successful.");
            }

        }

        private bool CallCreditCardVerificationAPI(string cardNumber)
        {
            // Set the Request URL
            string apiURL = "https://card-validator.p.rapidapi.com/validate";

            using (HttpClient client = new HttpClient())
            {
                // Converting the request type as expected by the API
                // No need to convert it into JSON right now, just send it as string to be understoon as JSON using "application/json"
                string request_body = "{\"cardNumber\":" + cardNumber + "}";

                // Creating the content to be understood as JSON
                var content = new StringContent(request_body, Encoding.UTF8, "application/json");

                //Adding the headers in the same content as needed by the API
                content.Headers.Add("X-RapidAPI-Host", "card-validator.p.rapidapi.com");
                content.Headers.Add("X-RapidAPI-Key", "69987885bemshf3664bac3baf003p15d715jsnaa9a83c56c83");


                // Send a request to the API
                HttpResponseMessage response = client.PostAsync(apiURL, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the API response to determine if the card is valid
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    bool isCardValid = ParseApiResponse(apiResponse);
                    return isCardValid;
                }
                else
                {
                    // Returning false even when the API is call is unsuccessful
                    return false;
                }
            }
        }
        private bool ParseApiResponse(string apiResponse)
        {
            // Parse the API response and determine if the card is valid
            // Deserialize the JSON response to extract the "isValid" value
            var responseData = JsonConvert.DeserializeObject<dynamic>(apiResponse);
            bool isValid = responseData.isValid;

            return isValid;
        }

        public void NotifyPayment(string emailId, string restaurantName)
        {
            StringBuilder emailBodyBuilder = new StringBuilder();
            emailBodyBuilder.AppendLine("<p>Payment Confirmation</p>");
            emailBodyBuilder.AppendLine($"Your order from restaurant - {restaurantName} has been successfully placed");
            // Send payment confirmation email
            SendEmail(emailId, emailBodyBuilder.ToString(), "Payment Confirmation");
        }

        public async Task<List<RestaurantDetails>> GetRestaurantsByAddress(string address)
        {
            // Retrieve Yelp API details from configuration.
            string baseUrl = "https://api.yelp.com/v3/businesses/search";
            string apiKey = "xrB9HTy33jLJdweK8_IlisJzDrvjjm6kPMc86j_z5I1sBlkgEZI245JU3557apsmV8YOlVKtFKGq89DvcrNLj_pKvYwo_jsM3LUbFyKM9mn5cWkRSeibOfR9qEUrZXYx";
            var restaurants = new List<RestaurantDetails>();

            // Using HttpClient to send HTTP requests.
            using (HttpClient client = new HttpClient())
            {
                // Setup client base address and headers.
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // Send GET request to Yelp API and retrieve the response.
                var response = await client.GetAsync($"?term=restaurants&location={address}&sort_by=best_match&limit=20");

                // Process the response if it's successful.
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<dynamic>();
                    var businesses = result["businesses"];

                    // Iterate through each business in the response.
                    foreach (var business in businesses)
                    {
                        RestaurantDetails restaurantDetails = new RestaurantDetails
                        {
                            Name = (string)business["name"],
                            Address = string.Join(", ", business["location"]["display_address"])
                        };

                        restaurants.Add(restaurantDetails);
                    }

                    // Return the list of restaurant names.
                    return restaurants;
                }
                else
                {
                    // Return error if the API call was not successful.
                    return null;
                }
            }
        }

        private string AppDataFolderPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/App_Data");
            }
        }

        public void StoreOrder(string orderId, string customerName, string restaurantName, string customerAddress, double amount)
        {
            List<Order> orders = LoadOrders();

            // Create an instance of the Order class with the provided data
            Order order = new Order
            {
                OrderId = orderId,
                CustomerName = customerName,
                RestaurantName = restaurantName,
                CustomerAddress = customerAddress,
                Amount = amount
            };

            // Add the new order to the list
            orders.Add(order);

            // Serialize the list of orders to XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            string filePath = Path.Combine(AppDataFolderPath, "Orders.xml");

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, orders);
            }
        }

        public List<Order> LoadOrders()
        {
            string filePath = Path.Combine(AppDataFolderPath, "Orders.xml");

            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return (List<Order>)serializer.Deserialize(fs);
                }
            }
            else
            {
                return new List<Order>();
            }
        }

        public async Task<DeliveryDeatils> GetDeliveryDetails(string userAddress, string restaurantAddress)
        {
            DeliveryHandler _deliveryHandler = new DeliveryHandler(new ApiInterceptor(new HttpClient()));
            var result = await _deliveryHandler.GetDeliveryDetails(restaurantAddress, userAddress);
            return result;
        }
    }

    public class DeliveryHandler
    {
        private readonly ApiInterceptor _apiInterceptor;

        public DeliveryHandler(ApiInterceptor apiInterceptor)
        {
            _apiInterceptor = apiInterceptor;
        }

        public async Task<DeliveryDeatils> GetDeliveryDetails(string restaurantAddress, string userAddress)
        {
           (string distance, string time) = await _apiInterceptor.GetDistanceAndTime(restaurantAddress, userAddress);
            DeliveryDeatils deliveryDeatils = new DeliveryDeatils();
            deliveryDeatils.Distance = distance;
            deliveryDeatils.Time = time;
            return deliveryDeatils;
        }
    }

    // Define the ApiInterceptor class for intercepting API requests and handling distance and time calculations.
    public class ApiInterceptor
    {
        private readonly HttpClient _client;

        public ApiInterceptor(HttpClient client)
        {
            _client = client;
        }

        // Get distance and time between two addresses.
        public async Task<(string distance, string time)> GetDistanceAndTime(string fromAddress, string toAddress)
        {
            string apiKey = "wyrwlAQlTm7XgD5JkEIvzERwViie44YJX8P9j3saWQMVVYVMHQh7xgZeEPPBnfKF";
            string requestUri = $"https://api.distancematrix.ai/maps/api/distancematrix/json?origins={Uri.EscapeDataString(fromAddress)}&destinations={Uri.EscapeDataString(toAddress)}&key={apiKey}";

            try
            {
                // Send a GET request and retrieve the response.
                var response = await _client.GetStringAsync(requestUri);

                // Deserialize the JSON response.
                var jsonResponse = JObject.Parse(response);

                // Extract distance and time from the JSON response.
                var element = jsonResponse["rows"][0]["elements"][0];
                string distance = element["distance"]["text"].Value<string>();
                string time = element["duration"]["text"].Value<string>();

                return (distance, time);
            }
            catch (Exception ex)
            {
                return ("0", "0");
            }
        }
    }
}