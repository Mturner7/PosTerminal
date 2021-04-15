using System;
using System.Collections.Generic; 

namespace PosTerminal
{
    class Program
    {
        static Menu MyMenu = new Menu();

        static bool ContinuePrompt(string msg)
        {
            string input;

            do
            {
                Console.Write($"{msg} (y/n): ");
                input = Console.ReadLine().ToLower();

                if (input == "y" || input == "yes") return true;

            } while (input != "n" || input != "no");

            return false;
        }

        static int IntegerPrompt(string msg, int max)
        {
            int input;

            do
            {
                Console.Write($"{msg} (enter an integer 1-{max}): ");
                Int32.TryParse(Console.ReadLine(), out input);

            } while (input < 1 || input > max);

            return input;
        }

        static void ViewReceipt(ShoppingCart userCart)
        {
            string fSeparator = new string('=', 50);

            Console.Clear();
            Console.WriteLine($"{"Name",-20} {"Quantity",10} {"Price",15}");
            Console.WriteLine(fSeparator);

            foreach (Product prod in userCart.Cart)
            {
                Console.WriteLine($"{prod.Name,-20} {$"x{userCart.Values[prod.id]}", 10} " +
                    $"{$"${prod.Price * userCart.Values[prod.id]}", 15}");
            }

            Console.WriteLine(fSeparator);

            decimal subtotal = SalesCalculator.CalculateSubtotal(userCart);
            decimal total = SalesCalculator.CalculateGrandTotal(subtotal);

            Console.WriteLine($"Subtotal: ${subtotal:0.00} \nSales Tax: {SalesCalculator.SalesTax * 100}%" +
                $" \nGrand Total: ${total:0.00}");
        }

        static void ViewMenu()
        {
            string fSeparator = new string('=', 110);
            string itemSeparator = new string('-', 110);

            Console.WriteLine($"   {"Name",-20} {"Price",-10} {"Category",25} {"Description",43}");
            Console.WriteLine(fSeparator);

            for (int i = 0; i < MyMenu.Inventory.Count; i++)
            {
                Product p = MyMenu.Inventory[i];

                Console.WriteLine($"[{i + 1}] {p.Name,-20} {$"${p.Price:0.00}",-10}" +
                                  $"{p.Category,25} {p.Desc,47}");
                Console.WriteLine(itemSeparator);
            }

        }

        static void Run(ShoppingCart userCart)
        {
            Console.Clear();
            Console.WriteLine("Welcome to  Boris' Market!\n");
            
            ViewMenu();

            int decision = IntegerPrompt("\n[1] Order Something \n[2] Get out \n[3] Re-display the menu\n\n", 3);
            
            switch (decision)
            {
                case 1:
                    int index = IntegerPrompt("\nWhich item would you like to order?", MyMenu.Inventory.Count) - 1;
                    int quantity = IntegerPrompt("\nHow much of this item would you like to order?", 500);
                    userCart.AddItem(MyMenu.Inventory[index], quantity);
                    break;

                case 2:
                    ViewReceipt(userCart);
                    userCart = new ShoppingCart();
                    break;

                case 3:
                    Console.Clear();
                    ViewMenu();
                    break;
            }

            
            if (ContinuePrompt("\nWould you like to return the main menu?")) Run(userCart);


        }

        static void Main(string[] args)
        {
            MyMenu.AddItem("Beans", "Canned Goods", 42m);
            MyMenu.AddItem("Lost Souls", "International Cuisine", 2.99m, "100% Organic");
            MyMenu.AddItem("Tomatoes", "Fruit", 4.99m, "50% Organic");
            MyMenu.AddItem("Flour", "Bulk", .99m);
            MyMenu.AddItem("Crackers", "Snacks", 5.29m, "Almost Healthy!");
            MyMenu.AddItem("Pineapple", "Fruit", 22.45m);
            MyMenu.AddItem("Milk", "Necessities", 6.99m, "ALWAYS Fresh (sometimes still warm)");
            MyMenu.AddItem("Swag", "Necessities", 100m);
            MyMenu.AddItem("Coffee Grounds", "Bulk", .99m, "Farmed somewhere in South America");
            MyMenu.AddItem("Lettuce", "Vegetables", 4.21m);
            MyMenu.AddItem("Caviar", "Seafood", 2.99m, "Fish eggs. So sad but so delicious");

            Run(new ShoppingCart());
        }
    }
}
