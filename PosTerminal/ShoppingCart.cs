using System;
using System.Collections.Generic;

namespace PosTerminal
{
    public class ShoppingCart
    {
        public List<Product> Cart { get; } = new List<Product>();
        public Dictionary<string, int> Values { get; } = new Dictionary<string, int>();

        public ShoppingCart() {}
   
        public void AddItem(Product item, int quantity)
        {
            if (!Values.ContainsKey(item.id))
            {
                Cart.Add(item);
                Values[item.id] = quantity;
            }
            else
            {
                Values[item.id] += quantity;
            }
        }
    }
}
