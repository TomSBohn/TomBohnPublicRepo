using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);
            //var response = ops.CreateNewOrder(new OrderInfo());
            //response.OrderInfo = new List<OrderInfo>();            

            ConsoleIO.Clear();
            string customerName = ConsoleIO.PromptString("Please enter a name for the order", true);
            //response.OrderInfo = ConsoleIO.PromptString("Please enter a name for the order", true);
            ConsoleIO.Clear();

            string inputState = ConsoleIO.PromptString("Please enter the full name of what state this order is for", true);
            ConsoleIO.Clear();
            var taxInfoToReturn = new StateTaxInfo();

            if (stateTaxInfoRepo.GetAllStateTaxInfos().Any(x => x.StateName.ToLower() == inputState.ToLower()))
            {
                
                List<StateTaxInfo> stateTaxList = stateTaxInfoRepo.GetAllStateTaxInfos();
                foreach (var state in stateTaxList)
                {
                    if (state.StateName.ToUpper() == inputState.ToUpper())
                    {
                        taxInfoToReturn = state;
                    }
                }
            }
            else
            {
                ConsoleIO.DisplayMessage($"Sorry but {inputState} is not a state that we service.");
                MainMenu menu = new MainMenu();
                menu.Display();
            }


           string inputArea = ConsoleIO.PromptString("Please enter how many square feet of flooring you need: ");
            ConsoleIO.Clear();

            

            decimal area = decimal.Parse(inputArea);
            ConsoleIO.Clear();


            string inputProductType = ConsoleIO.PromptString("Please enter the type of product that you want: ", true);
            ConsoleIO.Clear();
            ProductInfo productInfoToReturn = new ProductInfo();

            if (productRepo.GetAllProducts().Any(x => x.ProductType.ToLower() == inputProductType.ToLower()))
            {
                List<ProductInfo> productList = productRepo.GetAllProducts();
                foreach (var product in productList)
                {
                    if (product.ProductType.ToUpper() == inputProductType.ToUpper())
                    {
                        productInfoToReturn = product;
                    }
                }
            }
            else
            {
                ConsoleIO.DisplayMessage($"Sorry but {inputProductType} is not a product that we carry.");
                MainMenu menu = new MainMenu();
                menu.Display();
            }

            

            ConsoleIO.DisplayMessage($"The customer name is: {customerName} \n" +
                                     $"This order is in: {inputState} \n" +
                                     $"This order is for: {area} square feet of {inputProductType} " +
                                     "\n");

            string PlaceOrder =ConsoleIO.PromptOptions("Is this information correct? Press Y to place order. Press N to return to the main menu.", new[] { "Y", "N" });

            if (PlaceOrder == "N")
            {
                ConsoleIO.Clear();
                MainMenu backToMenu = new MainMenu();
                backToMenu.Display();
            }
            else
            {

                var newOrder = new OrderInfo();
                var productType = new ProductInfo();
                newOrder.CustomerName = customerName;
                newOrder.Area = area;
                newOrder.ProductType = productInfoToReturn;
                newOrder.Tax = taxInfoToReturn;       
                var response = ops.CreateNewOrder(newOrder);

                
                
                ConsoleIO.DisplayMessage("Your order has been placed. Press any key to go back to the main menu.");
                Console.ReadLine();

                MainMenu backToMenu = new MainMenu();
                backToMenu.Display();
            }


        }
    }
}


