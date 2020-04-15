using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Capstone.Classes;
using System.Drawing;



namespace Capstone
{
    class Program
    {

        static void Main(string[] args)
        {
            //Instantiate new vending machine command line interface

            VendingMachineCLI cLI = new VendingMachineCLI();

            cLI.StartVendingMachine();

            cLI.OpenMainMenu();

            cLI.UsingMainMenu();

            /*
            Changes Made: 
            The program kept looping and not working correctly when trying to return to the purchase menu after
            multiple transactions so I separated the menu into a main menu method and a purhcase menu method
            and then each option in the purchase menu method has its own method. This allows for an easier return to the purhcase
            menu after you do something like add money or purhcase an item. And looks a lot cleaner too.  

            I moved the user interaction, like all of the Console.WriteLine's and special formatting, to the vending machine CLI. 
            No major changes to code, just moving between classes and having the vending machine process transactions versus talk to the user.

            I found out that the user was able to add decimal amounts when adding money, so I added a line of code to only accept whole numbers. 

            I tried to break it in all sorts of different ways and it seems fairly strong. Log.TXT and SalesReport.TXT still work!
            
             */






    

    

        }
    }
}
