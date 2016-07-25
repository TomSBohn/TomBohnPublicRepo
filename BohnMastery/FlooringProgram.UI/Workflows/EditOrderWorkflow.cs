using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class EditOrderWorkflow
    {
        private OrderInfo _currentOrder;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="Order">Order retrieved to edit</param>
        public EditOrderWorkflow()
        {
        }
        

        private void DisplayOrderInformation(DateTime date, int orderID)
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);
            var response = ops.DisplayOrder(date);

            if (response.Success)
            {
                if (response.OrderInfo != null)
                {
                    _currentOrder = response.OrderInfo.FirstOrDefault(m => m.OrderID == orderID);

                    PromptForEditCustomerName();
                    PromptForEditProductType();
                    PromptForEditArea();
                    PromptToSaveChanges();

                }


                MainMenu menu = new MainMenu();
            }
            else
            {
                ConsoleIO.DisplayMessage("Nothing in our records match your information");
                ConsoleIO.DisplayMessage(response.Message);
                ConsoleIO.DisplayMessage("Sorry about that.");
                Console.ReadLine();
                MainMenu menu = new MainMenu();
                menu.Display();
            }
        }

        private string GetDateOfOrder()
        {
            string date = "";

            do
            {
                Console.Clear();

                Console.Write(
                    "Please type the date of your order in MM/DD/YYYY format (example June, 25th, 2016 is 06/25/2016): ");
                date = Console.ReadLine();

                if (string.IsNullOrEmpty(date))
                {
                   ConsoleIO.DisplayMessage("Please enter a date in the form of MM/DD/YYYY");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(date));

            return date;
        }

        private int PromptForOrderId()
        {
            int orderID = 0;

            do
            {
                ConsoleIO.Clear();

                ConsoleIO.DisplayMessage("Please enter your order ID: ");
                orderID = Convert.ToInt32(Console.ReadLine());


                return orderID;
            } while (orderID == 0);

        }

        private void PrintOrderInformation()
        {
            ConsoleIO.Clear();
           ConsoleIO.DisplayMessage("Order Information");
           ConsoleIO.DisplayMessage("-------------------------");
           ConsoleIO.DisplayMessage($"Name: {_currentOrder.CustomerName}");
           ConsoleIO.DisplayMessage($"Order Number: {_currentOrder.OrderID}");
           ConsoleIO.DisplayMessage($"Area: { _currentOrder.Area}");
           ConsoleIO.DisplayMessage($"-------------------------");
           ConsoleIO.DisplayMessage($"Tax: {_currentOrder.Tax}");
           ConsoleIO.DisplayMessage($"Material Cost: { _currentOrder.MaterialCost}");
           ConsoleIO.DisplayMessage($"Total: {_currentOrder.Total}");
        }

        private void PromptForEditCustomerName()
        {
           ConsoleIO.DisplayMessage($"The customer name is {_currentOrder.CustomerName}, would you like to change it?");
           ConsoleIO.DisplayMessage("*** Instructions ***");
           ConsoleIO.DisplayMessage(">Type in the new information and press Enter to save your changes.");
           ConsoleIO.DisplayMessage(">Leave the field blank and press Enter to skip ahead.");

            string tempCustomerName = "";

            tempCustomerName = Console.ReadLine();

            if (string.IsNullOrEmpty(tempCustomerName))
            {
                _currentOrder.CustomerName = _currentOrder.CustomerName;
            }
            else
            {
                _currentOrder.CustomerName = tempCustomerName;
            }
        }



        private void PromptForEditProductType()
        {
           ConsoleIO.DisplayMessage($"The product is {_currentOrder.ProductType.ProductType}, would you like to change it?");
           ConsoleIO.DisplayMessage("*** Instructions ***");
           ConsoleIO.DisplayMessage(">Type in the new information and press Enter to save your changes.");
           ConsoleIO.DisplayMessage(">Leave the field blank and press Enter to skip ahead.");

            string tempProductType = null;

            tempProductType = Console.ReadLine();

            if (string.IsNullOrEmpty(tempProductType))
            {
                _currentOrder.ProductType.ProductType = _currentOrder.ProductType.ProductType;
            }
            else
            {
                _currentOrder.ProductType.ProductType = tempProductType;
            }
        }

        private void PromptForEditArea()
        {
           ConsoleIO.DisplayMessage($"The area is {_currentOrder.Area}, would you like to change it?");
           ConsoleIO.DisplayMessage("*** Instructions ***");
           ConsoleIO.DisplayMessage(">Type in the new information and press Enter to save your changes.");

            decimal tempArea = _currentOrder.Area;
            var userInput = ConsoleIO.PromptString(">Leave the field blank and press Enter to skip ahead.",false);

            

            if (Decimal.TryParse(userInput, out tempArea))
            {
                _currentOrder.Area = _currentOrder.Area;
            }
            else
            {
                _currentOrder.Area = tempArea;
            }
        }

        private void PromptToSaveChanges()
        {
           ConsoleIO.DisplayMessage("Are you sure that you want to make these changes?");
           ConsoleIO.DisplayMessage("*** Instructions ***");
           ConsoleIO.DisplayMessage(">Type Y to save changes");
           ConsoleIO.DisplayMessage(">Type N to cancel and go back to the main menu");

            string change = ConsoleIO.PromptOptions("Y/N? :", new[] {"Y", "N"});

            if (change.ToUpper() == "Y")
            {
                var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
                var productRepo = OrderRepositoryFactory.CreateProductRepo();
                var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
                var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);
                var response = ops.EditOrder(_currentOrder);
                if (response.Success)
                {
                    ConsoleIO.DisplayMessage("All changes have been made.");

                }
                else
                {
                    ConsoleIO.DisplayMessage("No changes have been made and your order will stay the same.");

                }




            }




        }

        public void Execute()
        {
            string date = GetDateOfOrder();
            int OrderID = PromptForOrderId();

            DisplayOrderInformation(Convert.ToDateTime(date), OrderID);
        
           

        }


    }
}
