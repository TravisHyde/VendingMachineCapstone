using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Vending_Machine
    {
        public Inventory newInventory = new Inventory();

        public Log log = new Log();

        public SalesReport hiddenSalesReport = new SalesReport();

        public decimal VendingMachineBalance { get; private set; }

        public decimal UserBalance { get; set; }

        public Vending_Machine()
        {
            this.UserBalance = 0;
            this.VendingMachineBalance = 0;
        }
       
        //Display List of Items
        public void MainMenu ()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(" Welcome to the Vendo-Matic 600");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Display items");
            Console.WriteLine("2. Purchase items");
            Console.WriteLine("3. Exit");
            
        }
        
        public void ItemList()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{"Location",-10} {"Item",-20} {"Price",-20}");
            Console.WriteLine("-----------------------------------------");
            foreach (Item item in newInventory.availableItems)
            {
                if (item.Quanity > 0)
                {
                    
                    Console.WriteLine($"{item.Location, -10} {item.Name, -20} ${item.Cost, -20}");
                }
                else
                {
                    Console.WriteLine($"{item.Location} {item.Name} ${item.Cost} SOLD OUT");
                }
            }
        }

        public void PurchaseMenu()
        {           
            Console.WriteLine("1. Feed Money");
            Console.WriteLine("2. Select Product");
            Console.WriteLine("3. Finish Transaction");
        }

        public void AddMoney(decimal money)
        {                               
            UserBalance += money;           
            using (StreamWriter sw = new StreamWriter(log.filePath, true))
            {
                string line = ($"{DateTime.Now} FEED MONEY: ${money} ${UserBalance}");
                sw.WriteLine(line);
            }
            //Console.WriteLine($"Your Balance: ${UserBalance}");
        }

        public void PurchaseItem(Item selection)
        {          
            this.UserBalance -= selection.Cost;
            this.VendingMachineBalance += selection.Cost;
            selection.Quanity--;

            using (StreamWriter sw = new StreamWriter(log.filePath, true))
            {
                string line = ($"{DateTime.Now} {selection.Name} {selection.Location} ${selection.Cost} ${UserBalance}");
                sw.WriteLine(line);
            }
        }

        public void FinishTransaction()
        {
            using (StreamWriter sw = new StreamWriter(log.filePath, true))
            {
                string line = ($"{DateTime.Now} GIVE CHANGE: ${UserBalance} $0.00");
                sw.WriteLine(line);
            }

            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;

            if (UserBalance > 0)
            {
                while (UserBalance >= 0.25m)
                {
                    UserBalance -= 0.25m;
                    quarters++;
                }
                while (UserBalance >= 0.1m)
                {
                    UserBalance -= 0.10m;
                    dimes++;
                }
                while (UserBalance >= 0.05m)
                {
                    UserBalance -= 0.05m;
                    nickels++;
                }
                while (UserBalance >= 0.01m)
                {
                    UserBalance -= 0.01m;
                    pennies++;
                }
                Console.WriteLine($"Here's your change: {quarters} quarter(s), {dimes} dime(s), {nickels} nickel, {pennies} pennies");
                return;

                
            }
            Console.WriteLine("No Change");
            return;
        }

        public void GenerateSalesReport()
        {
            for (int i = 0; i < newInventory.availableItems.Count; i++)
            {
                const int maxQuanity = 5;
                using (StreamWriter sw = new StreamWriter(hiddenSalesReport.filePath, false))
                {
                    foreach (Item salesItem in newInventory.availableItems)
                    {
                        string line = ($"{salesItem.Name}|{maxQuanity - salesItem.Quanity}");
                        sw.WriteLine(line);
                    }
                    sw.WriteLine($"**TOTAL SALES** ${VendingMachineBalance}");
                }
            }
        }




    }
}
