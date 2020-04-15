using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        Vending_Machine vm = new Vending_Machine();       

        public void StartVendingMachine()
        {
            vm.newInventory.FillTheVendingMachine();
        }

        public void OpenMainMenu()
        {
            vm.MainMenu();
        }

        public void DisplayItemList()
        {
            Console.Clear();
            Console.WriteLine("    --------------------------------");
            Console.WriteLine("            Vendo-Matic 600");
            Console.WriteLine("    --------------------------------");
            Console.WriteLine();
            vm.ItemList();
        }

        public void UsingMainMenu()
        {
            int input = 0;
            while (input != 3)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
                if (input == 1)
                {
                    DisplayItemList();
                    Console.WriteLine();
                    Console.WriteLine("Press enter to return to the main menu");
                    Console.ReadLine();
                    Console.Clear();
                    vm.MainMenu();
                }
                if (input == 2)
                {
                    UsingPurchaseMenu();
                }
                if (input == 4)
                {
                    vm.GenerateSalesReport();
                    Console.WriteLine("Sales Report Generated. Press enter to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    vm.MainMenu();
                }
                if (input > 4 || input < 1)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");

                }
            }
        }

        public void UsingPurchaseMenu()
        {
            int userSelection = 0;
            bool isUsingPurhcaseMenu = true;

            while (isUsingPurhcaseMenu)
            {
                Console.Clear();
                DisplayItemList();
                Console.WriteLine();
                Console.WriteLine($"Your Balance: ${Math.Round(vm.UserBalance, 2)}");
                Console.WriteLine();
                vm.PurchaseMenu();
                try
                {
                    userSelection = int.Parse(Console.ReadLine());
                    if (userSelection == 1)
                    {
                        FeedingVendingMachine();
                        continue;
                    }
                    if (userSelection == 2)
                    {
                        SelectingItem();
                        continue;
                    }
                    if (userSelection == 3)
                    {
                        vm.FinishTransaction();
                        Console.WriteLine($"Your Balance: ${vm.UserBalance}");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the menu");
                        Console.ReadLine();
                        Console.Clear();
                        vm.MainMenu();
                        UsingMainMenu();
                        Environment.Exit(0);
                    }
                    if (userSelection == 5)
                    {
                        break;
                    }
                    if (userSelection < 1 || userSelection > 5)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
            }           
        }               
       
        public void FeedingVendingMachine()
        {
            Console.Clear();
            DisplayItemList();
            Console.WriteLine();
            Console.WriteLine("Please add money in whole dollar amounts.");

            decimal money = 0;
            bool isInvalidInput = true;
            while (isInvalidInput)
            {
                try
                {
                    money = decimal.Parse(Console.ReadLine());
                    if (money < 0)
                    {
                        Console.WriteLine("You must enter a positive number.");
                        continue;
                    }
                    if (money > Math.Floor(money))
                    {
                        Console.WriteLine("You must enter whole dollar amounts");
                        continue;
                    }
                    isInvalidInput = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine("You must enter money in whole dollar amounts");
                    continue;
                }
            }
            vm.AddMoney(money);
        }

        public void SelectingItem()
        {           
            string itemSelectedAsStr = "";
            bool isInvalidInput = true;
            Item selection = null;

            while (isInvalidInput)
            {
                Console.Clear();
                DisplayItemList();
                Console.WriteLine();
                Console.WriteLine($"Your Balance: ${vm.UserBalance}");
                Console.WriteLine();
                Console.WriteLine("Please select a product");
                try
                {
                    itemSelectedAsStr = Console.ReadLine().ToUpper();
                    if (!vm.newInventory.kvp.ContainsKey(itemSelectedAsStr))
                    {
                        Console.WriteLine("Invalid item.");
                        Console.WriteLine("Press enter to return to the menu.");
                        Console.ReadLine();
                        UsingPurchaseMenu();  
                    }
                    selection = vm.newInventory.kvp[itemSelectedAsStr];
                    if (selection.Quanity == 0)
                    {
                        Console.WriteLine("SOLD OUT");
                        Console.WriteLine();
                        Console.WriteLine("Please enter to return to the menu.");
                        Console.ReadLine();
                        UsingPurchaseMenu();
                    }
                    isInvalidInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("You must enter a valid key.");
                    continue;
                }
            }
            if (selection.Cost > vm.UserBalance)
            {
                Console.Clear();
                DisplayItemList();
                Console.WriteLine();
                Console.WriteLine($"Your Balance: ${vm.UserBalance}");
                Console.WriteLine();
                Console.WriteLine("Insufficient funds. Please feed money into the vending machine to purchase this item.");
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();              
            }
            else
            {
                vm.PurchaseItem(selection);
                Console.Clear();
                DisplayItemList();
                Console.WriteLine();
                Console.WriteLine("Vending Item...");
                Console.WriteLine(selection.PurchaseMessage);
                Console.WriteLine();
                Console.WriteLine($"Your Balance: ${vm.UserBalance}");
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
                UsingPurchaseMenu();
            }
        }


    }
}
