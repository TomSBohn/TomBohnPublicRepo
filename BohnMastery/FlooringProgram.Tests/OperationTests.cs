using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using NUnit.Framework;
using FlooringProgram.Models;

namespace FlooringProgram.Tests
{
    [TestFixture]
    class OperationTests
    {
        [Test]
        public void ShouldBeAbleToAddOrder()
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);

            OrderInfo newOrder = new OrderInfo();
            newOrder.CustomerName = "Joe";
            newOrder.Area = 10;
            newOrder.OrderDate = DateTime.Now;

            List<OrderInfo> allOrders = new List<OrderInfo>();
            allOrders = orderRepo.GetOrdersByDate(newOrder.OrderDate);

            int beforeAdd = allOrders.Count;

            ops.CreateNewOrder(newOrder);
            allOrders = orderRepo.GetOrdersByDate(newOrder.OrderDate);
            int afterAdd = allOrders.Count;

            Assert.AreEqual(beforeAdd+1, afterAdd);
        }

        [Test]
        public void ShouldBeAbleToEditOrder()
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);

            var orderToEdit = new OrderInfo()
            {
                OrderID = 1,
                Area = 100,
                CustomerName = "John",
                MaterialCost = 6,
                OrderDate = DateTime.Parse("01/01/2016"),
                TaxTotal = .06m,
                Total = 636
            };
           //List<OrderInfo> orderList = new List<OrderInfo>();
           // orderList = orderRepo.
            //orderList.Add(new OrderInfo() { OrderID = 1, Area = 100, CustomerName = "Don", MaterialCost = 6, OrderDate = DateTime.Parse("01/01/2016"), Tax = .06m, Total = 636 });

            ops.EditOrder(orderToEdit);
            var editedOrder = orderRepo.FindOrderByID(orderToEdit.OrderID, orderToEdit.OrderDate);

            Assert.AreEqual("John", editedOrder.CustomerName);

            //Not sure how to compare the two values


        }

        [Test]
        public void ShouldBeAbleToRemoveOrder()
        {
            var orderRepo = OrderRepositoryFactory.CreateOrderRepo();
            var productRepo = OrderRepositoryFactory.CreateProductRepo();
            var stateTaxInfoRepo = OrderRepositoryFactory.CreateStateTaxInfoRepo();
            var ops = new OrderOperation(productRepo, orderRepo, stateTaxInfoRepo);
            var response = new Response();

            List<OrderInfo> allOrders = new List<OrderInfo>();
            allOrders = orderRepo.GetOrdersByDate(DateTime.Parse("01/01/2016"));
            //int beforeRemove = allOrders.Count;
            
            response = ops.RemoveOrder(1, DateTime.Parse("01/01/2016"));
            //allOrders = orderRepo.GetOrdersByDate(DateTime.Parse("01/01/2016"));
            int afterRemove = response.OrderInfo.Count;

            Assert.AreEqual(0, afterRemove);          
        }


    }
}

