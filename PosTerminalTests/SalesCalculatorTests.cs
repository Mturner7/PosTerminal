using System;
using Xunit;
using PosTerminal;
using System.Collections.Generic;

namespace PosTerminalTests
{
    public class SalesCalculatorTests
    {
        [Theory]
        [InlineData(5, 5.3)]
        [InlineData(50, 53)]
        [InlineData(16, 16.96)]
        [InlineData(1.23, 1.3038)]
        [InlineData(112.58, 119.3348)]
        [InlineData(596.674, 632.47444)]
        public void CalculateGrandTotal_ReturnsTotalWithSalesTax(decimal input, decimal expectation)
        {
            decimal result = SalesCalculator.CalculateGrandTotal(input);

            Assert.Equal(result, expectation);
        }

        [Fact]
        public void CalculateSubTotal_ReturnsSumOfProductPrices()
        {
            ShoppingCart TestData = new ShoppingCart();

            TestData.AddItem(new Product("Beans", "Beans", 4.99m), 1);
            TestData.AddItem(new Product("Beans", "Beans", 44.67m), 1);
            TestData.AddItem(new Product("Beans", "Beans", 13.29m), 1);
            TestData.AddItem(new Product("Beans", "Beans", 712.93m), 1);
            TestData.AddItem(new Product("Beans", "Beans", .23m), 1);

            decimal expected = 776.11m;
            decimal result = SalesCalculator.CalculateSubtotal(TestData);

            Assert.Equal(result, expected);
        }
    }
}
