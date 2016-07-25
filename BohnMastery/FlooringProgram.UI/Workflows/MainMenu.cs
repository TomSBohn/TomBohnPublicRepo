using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class MainMenu
    {
        public void Display()
        {
            string input = "";

            do
            {
                ConsoleIO.Clear();
                ConsoleIO.DisplayMessage(
                    "****************************************************************************\n" +
                    "\n" +
                    "*\n" +
                    "Flooring Program\n" +
                    "*\n" +
                    "\n" +
                    "* 1. Display Orders\n" +
                    "\n" +
                    "* 2. Add an Order\n" +
                    "\n" +
                    "* 3. Edit an Order\n" +
                    "\n" +
                    "* 4. Remove an Order\n" +
                    "\n" +
                    "* 5. Quit\n" +
                    "\n" +
                    "*\n" +
                    "\n" +
                    "*****************************************************************************\n", ConsoleColor.DarkBlue);



                input = ConsoleIO.PromptOptions("Please enter your selection: ", new[] {"1", "2", "3", "4", "5"});

                if (input != "5")
                {
                    ProcessChoice(input);
                }

            } while (input != "5");
        }


        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    DisplayOrdersWorkflow displayOrders = new DisplayOrdersWorkflow();                  
                    DateTime orderDate = ConsoleIO.PromptDateTime("Enter the date for which you would like to see all of the orders, please enter date in MM/DD/YYYY format.");
                    displayOrders.DisplayOrderInfo(orderDate);
                    break;

                case "2":
                    AddOrderWorkflow addOrders = new AddOrderWorkflow();
                    addOrders.Execute();
                    break;

                case "3":                   
                    EditOrderWorkflow editOrders = new EditOrderWorkflow();
                    editOrders.Execute();
                    break;

                case "4":
                    RemoveOrderWorkflow removeOrders = new RemoveOrderWorkflow();
                    removeOrders.Execute();
                    break;        
                default:
                    Console.WriteLine("{0} is not an available option", choice);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
