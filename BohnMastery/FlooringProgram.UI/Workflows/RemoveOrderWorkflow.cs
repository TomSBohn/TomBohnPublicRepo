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
    public class RemoveOrderWorkflow
    {
        private OrderInfo  _currentOrder;

        private void DisplayOrderInformation(DateTime date, int orderID)
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);
            var response = ops.DisplayOrder(date);

            if (response.Success)
            {
                _currentOrder = response.OrderInfo[0];

                PrintOrderInfo(_currentOrder);

                PromptForRemove();
            }
            else
            {
                Console.WriteLine("Nothing in our records match your information");
                Console.WriteLine(response.Message);
                Console.WriteLine("Sorry about that.");
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
                    Console.WriteLine("Please enter a date in the form of MM/DD/YYYY");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(date));

            return date;
        }

        private int GetIDOfOrder()
        {
            int orderID = 0;

            do
            {
                Console.Clear();

                Console.Write("Please enter your order ID: ");
                orderID = Convert.ToInt32(Console.ReadLine());


                return orderID;
            } while (orderID == 0);

        }


        //Take in an order
        //private void PrintOrderInfo(OrderInfo _currentOrder)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Order Information");
        //    Console.WriteLine("-------------------------");


        //    Console.WriteLine("Name: {0}", _currentOrder.CustomerName);
        //    Console.WriteLine("Area: {0}", _currentOrder.Area);
        //    Console.WriteLine("Order Number: {0}", _currentOrder.OrderID);
        //    Console.WriteLine("-------------------------");
        //    Console.WriteLine("Tax: {0}", _currentOrder.Tax);
        //    Console.WriteLine("Material Cost: {0}", _currentOrder.MaterialCost);
        //    Console.WriteLine("Total: {0}", _currentOrder.Total);
        //}
        public void PrintOrderInfo(OrderInfo order)
        {
            if (order == null) return;

            ConsoleIO.Clear();
            ConsoleIO.DisplayMessage("Order Information");
            ConsoleIO.DisplayMessage(string.Format("*****************"));
            ConsoleIO.DisplayMessage($"Customer Name: {order.CustomerName}");
            ConsoleIO.DisplayMessage($"Order Date: {order.OrderDate}");
            ConsoleIO.DisplayMessage($"Order ID: {order.OrderID}");
            ConsoleIO.DisplayMessage($"Area: {order.Area}");
            ConsoleIO.DisplayMessage($"Material Cost: {order.MaterialCost}");
            ConsoleIO.DisplayMessage($"Tax: {order.Tax}");
            ConsoleIO.DisplayMessage($"Total: {order.Total}");
            ConsoleIO.PromptString("Hit any key to continue", false);
        }


        public void Execute()
        {
            string date = GetDateOfOrder();
            int OrderID = GetIDOfOrder();
            DisplayOrderInformation(Convert.ToDateTime(date), OrderID);
            
            PromptForRemove();

        }

        private void ProcessRemoveOrder(DateTime date, int orderID)
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);

            Response response = ops.RemoveOrder(orderID, date);

            if (response.Success)
            {
                ConsoleIO.DisplayMessage("Your order has been deleted.");
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadLine();
            }
        }

        private void PromptForRemove()
        {
            string input = "";

            do
            {
                Console.WriteLine("Are you sure that you want to remove your order?");
                Console.WriteLine("Y/N");
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "Y":
                    ProcessRemoveOrder(_currentOrder.OrderDate, _currentOrder.OrderID);

                    break;
                case "N":
                    Console.WriteLine("Okay, we will keep your order in our files.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("{0} is not a valid option. Please enter (Y)es, (N)o, or (Q)uit", choice);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
            MainMenu menu =  new MainMenu();
            menu.Display();
        }
    }
}
