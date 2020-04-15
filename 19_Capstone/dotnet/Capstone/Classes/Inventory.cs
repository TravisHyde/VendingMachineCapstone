using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Inventory
    {
        public List<Item> availableItems = new List<Item>();

        public Dictionary<string, Item> kvp = new Dictionary<string, Item>();
        public void FillTheVendingMachine()
        {
            

            string path = @"C:\Users\Student\workspace\week-4-pair-exercises-c-team-2\19_Capstone\dotnet\Capstone\bin\Debug\netcoreapp2.1";
            string file = "VendingMachine.txt";
            string filePath = Path.Combine(path, file);

            while (!File.Exists(filePath))
            {
                Console.WriteLine("Unable to fill vending machine. Please select a file path to a valid inventory.");
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    string[] splitLine = line.Split("|");


                    //Assigning each element in the array
                    string slot = splitLine[0];
                    string itemName = splitLine[1];
                    decimal itemPrice = decimal.Parse(splitLine[2]);
                    string itemType = splitLine[3];


                    //Add slot from each line to list:

                    Item newItem = new Item(slot, itemName, itemPrice, itemType);
                    availableItems.Add(newItem);

                    kvp.Add(splitLine[0], newItem);


                }
            }
        }
    }
}
