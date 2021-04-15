using System;
using System.Collections.Generic;

namespace PosTerminal
{
    public class Product
    {
        public decimal Price { get; set; }
        public string id { get; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Product(string name, string category, decimal price, string desc)
        {
            Name = name;
            Category = category;
            Price = price;
            Desc = desc;
            id = $"{name}{category}{price:00}";
        } 

        public Product(string name, string category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
            Desc = "No description available.";
            id = $"{name.Substring(0, name.Length / 2)}{category.Substring(0, name.Length / 2)}{price:00}";
        }

        public Product() { }

    }
}
