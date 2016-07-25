using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    /// <summary>
    /// This is for doing calculations
    /// </summary>
    public class OrderOperation
    {

        private readonly IProductRepo _productRepo;
        private IOrderRepo _orderRepo;
        private readonly IStateTaxInfoRepo _stateTaxInfoRepo;


        public OrderOperation(IProductRepo productRepo, IOrderRepo orderRepo, IStateTaxInfoRepo stateTaxInfoRepo)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _stateTaxInfoRepo = stateTaxInfoRepo;
        }

        /// <summary>
        /// Displays all the orders for a specific date if it exists
        /// </summary>
        /// <param name="orderDate">takes a date from user in MMDDYYYY</param>
        /// <returns>Orders</returns>
        public Response DisplayOrder(DateTime orderDate)
        {
            var response = new Response();
            try
            {
   

                List<OrderInfo> orders = _orderRepo.GetOrdersByDate(orderDate);

                if (orders == null)
                {
                    response.Success = false;
                    response.Message = "There are no orders for that date.";
                }
                else
                {
                    response.Success = true;
                    response.OrderInfo = orders;
                   
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
            }

            return response;
        }

        /// <summary>
        /// Creates a new order as a new line in existing Orders.txt or generates a new one
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public Response CreateNewOrder(OrderInfo newOrder)
        {
            var response = new Response();
            try
            {
                

                newOrder.MaterialCost = newOrder.Area * newOrder.ProductType.CostPerSquareFoot;
                newOrder.LaborCost = newOrder.Area*newOrder.ProductType.LaborCostPerSquareFoot;
                newOrder.TaxTotal = (newOrder.MaterialCost + newOrder.LaborCost)*newOrder.Tax.TaxRate; //state tax ;

                newOrder.Total = newOrder.MaterialCost + newOrder.LaborCost + newOrder.TaxTotal;


                newOrder.OrderDate = DateTime.Today;


                newOrder.OrderID = _orderRepo.CreateNextOrderNumber(newOrder.OrderDate);

                _orderRepo.CreateOrder(newOrder);

                response.Success = true;
                response.OrderInfo = new List<OrderInfo>() {newOrder};
                {
                    response.Success = false;
                    response.Message = "Failed to create order.";
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
            }


            return response;
        }

        
        

        private Response CheckIfOrderDateTxtExist(DateTime orderDate)
        {
            var response = new Response();

            try
            {
                bool ordersFileExists = false;
                if (File.Exists($@"\Orders_{orderDate}.txt")== true)
                {
                    ordersFileExists = true;
                    response.Success = true;                    
                }
                response.Success = false;
                response.Message = "Sorry, but there are no orders for that date.";
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
            }
            return response;
        }

        /// <summary>
        /// Edits an order in the existing Orders.txt
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Response EditOrder(OrderInfo order)
        {
            var response = new Response();
            try
            {
                var orderToedit = _orderRepo.FindOrderByID(order.OrderID, order.OrderDate);
                if (orderToedit == null)
                {
                    response.Success = false;
                    response.Message = "This order does not match our records.";
                }
                else
                {
                    response.Success = true;
                    _orderRepo.EditOrder(order);
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
                response.Success = false;
                response.Message = "edit failed.";
            }
            return response;

        }

        public OrderInfo DisplayOrder(int orderID, DateTime date)
        
           
            {
                OrderInfo orderToRemove = null;
                var orders = _orderRepo.GetOrdersByDate(date);
                int index = orders.FindIndex(o => o.OrderID == orderID);
                orderToRemove = orders[index];

                return orderToRemove;

            }


        

        /// <summary>
        /// Removes an order in the .txt file
        /// </summary>
        /// <param name="orderID">The ID # of the order</param>
        /// <param name="date">The date the order was made</param>
        /// <returns></returns>
        public Response RemoveOrder(int orderID, DateTime date)
        {
            var response = new Response();
            try
            {

                var repo = OrderRepositoryFactory.CreateOrderRepo();

                OrderInfo order = repo.FindOrderByID(orderID, date);

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "This order does not match our records.";
                }
                else
                {
                    response.Success = true;
                    repo.RemoveOrder(order.OrderDate,order.OrderID);
                    response.OrderInfo = repo.GetOrdersByDate(order.OrderDate);
                    //response.OrderInfo = new List<OrderInfo>() {order};
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
            }

            return response;

        }
        /// <summary>
        /// Lists all of the products
        /// </summary>
        /// <returns></returns>
        public ProductResponse GetAllProducts()
        {
            ProductResponse result = new ProductResponse();
            
            return result;
        }
    }
}
