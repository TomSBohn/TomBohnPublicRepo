using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public OrderInfo _currentOrderDate;

       

        public void DisplayOrderInfo(DateTime orderDate)
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var AO = new OrderOperation(productRepo, orderRepo,stateTaxInfoRepo);
            var responses = AO.DisplayOrder(orderDate);

            if (responses.Success)
            {
                foreach (OrderInfo Order in responses.OrderInfo)
                {
                    PrintOrderInfo(Order);
                }

            }
            else
            {
                Console.WriteLine("Error");
                Console.WriteLine(responses.Message);
                Console.ReadLine();
            }
        }

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
            ConsoleIO.PromptString("Hit any key to continue",false);
        }

        
    }
}
