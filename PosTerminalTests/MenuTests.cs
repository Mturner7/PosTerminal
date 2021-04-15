using System;
using Xunit;
using PosTerminal;

namespace PosTerminalTests
{
    public class MenuTests
    {
        [Theory]
        [InlineData("Beans", "Canned goods", 23)]
        [InlineData("Pineapples", "Canned goods", 23)]
        [InlineData("Rice", "Bulk", 23)]
        [InlineData("Soup", "Canned goods", 23)]
        [InlineData("Mangoes", "Fruit", 23)]
        public void AddItem_WillAddItemsToInventory(string itemName, string category, decimal price)
        {
            Menu menu = new Menu();

            menu.AddItem(itemName, category, price);

            int iSize = menu.Inventory.Count;

            Assert.Equal(1, iSize);
        }
    }
}