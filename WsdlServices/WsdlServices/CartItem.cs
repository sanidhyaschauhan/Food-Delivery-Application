using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsdlServices
{
    // Define a class to represent items in a shopping cart.
    public class CartItem
    {
        // Represent the name of the item in the shopping cart.
        public string ItemName { get; set; }

        // Represent the price of the item in the shopping cart.
        public double Price { get; set; }

        // Represent the quantity of the item in the shopping cart.
        public int Quantity { get; set; }
    }
}
