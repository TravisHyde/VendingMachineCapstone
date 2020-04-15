using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Item
    {
        public string Location { get; private set; }
        
        public string Name { get; private set; }

        public decimal Cost { get; private set; }

        public string Type { get; private set; }

        public string PurchaseMessage { get; }

        public int Quanity { get; set; }

        public Item(string location, string name, decimal cost, string type)
        {
            this.Location = location;
            this.Name = name;
            this.Cost = cost;
            this.Type = type;
            this.Quanity = 5;

            if (this.Type == "Chip" && this.Quanity > 0)
            {
                this.PurchaseMessage = "Crunch Crunch, Yum!";
            }
            else if (this.Type == "Candy" && this.Quanity > 0)
            {
                this.PurchaseMessage = "Munch Munch, Yum!";
            }
            else if (this.Type == "Drink" && this.Quanity > 0)
            {
                this.PurchaseMessage = "Glug Glug, Yum!";
            }
            else if (this.Type == "Gum" && this.Quanity > 0)
            {
                this.PurchaseMessage = "Chew Chew, Yum!";
            }
        }

        

    }
}
