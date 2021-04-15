using System;
using Xunit;
using PosTerminal;

namespace PosTerminalTests
{
    public class ShoppingCartTests
    {
        [Theory]
        [InlineData("Beans", "Canned goods", 23)]
        [InlineData("Pineapples", "Canned goods", 23)]
        [InlineData("Rice", "Bulk", 23)]
        [InlineData("Soup", "Canned goods", 23)]
        [InlineData("Mangoes", "Fruit", 23)]
        public void AddTocart_WillAddItemsToShoppingCart(string itemName, string category, decimal price)
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddItem(new Product(itemName, category, price), 1);

            int cSize = cart.Cart.Count;

            Assert.Equal(1, cSize);
        }
    }
}