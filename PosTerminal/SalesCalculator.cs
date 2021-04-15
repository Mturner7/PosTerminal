using System;
using System.Collections.Generic;

namespace PosTerminal
{
    public static class SalesCalculator
    {
        public static decimal SalesTax { get; } = 0.06m;

        public static decimal CalculateGrandTotal(decimal subTotal)
        {
            return subTotal + (subTotal * SalesTax);
        }

        public static decimal CalculateSubtotal(ShoppingCart shoppingCart)
        {
            decimal subTotal = 0m;

            foreach (Product item in shoppingCart.Cart)
            {
                subTotal += (item.Price * shoppingCart.Values[item.id]);
            }

            return subTotal;
        }
    }
}
