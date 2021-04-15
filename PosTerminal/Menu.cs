using System;
using System.Collections.Generic;

namespace PosTerminal
{
    public class Menu
    {
        public List<Product> Inventory { get; } = new List<Product>();

        public void AddItem(string name, string category, decimal price, string desc)
        {
            Inventory.Add(new Product(name, category, price, desc));
        }

        public void AddItem(string name, string category, decimal price)
        {
            Inventory.Add(new Product(name, category, price));
        }

        public Menu() { }
    }
}
