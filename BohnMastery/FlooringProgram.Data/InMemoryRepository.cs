using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class InMemoryRepo : IOrderRepo, IProductRepo, IStateTaxInfoRepo
    {
        List<OrderInfo> orderList;
        List<ProductInfo> productList;
        List<StateTaxInfo> stateTaxList;

        public InMemoryRepo()
        {
            
            orderList = new List<OrderInfo>();
            orderList.Add(new OrderInfo() {OrderID = 1, Area = 100, CustomerName = "Don", MaterialCost = 6, OrderDate = DateTime.Parse("01/01/2016"), TaxTotal = .06m});
            orderList.Add(new OrderInfo() { OrderID = 2, Area = 200, CustomerName = "Bob", MaterialCost = 5, OrderDate = DateTime.Parse("02/02/2016"), TaxTotal = .05m });

            productList = new List<ProductInfo>();
            productList.Add(new ProductInfo() {ProductType = "Tile", CostPerSquareFoot = 5M,LaborCostPerSquareFoot = 10M});

            stateTaxList = new List<StateTaxInfo>();
            stateTaxList.Add(new StateTaxInfo() {StateAbb = "OH", StateName = "Ohio", TaxRate = .05M});
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            return (from orderInfo in orderList
                where orderInfo.OrderDate == orderdate
                select orderInfo).ToList();
        }

        public OrderInfo CreateOrder(OrderInfo newOrder)
        {
            newOrder.OrderID = CreateNextOrderNumber(newOrder.OrderDate);
            orderList.Add(newOrder);
            return newOrder;
        }

        public int CreateNextOrderNumber(DateTime date)
        {
            int orderNumber = 1;

            if (orderList.Count != 0)
            {
                orderNumber = orderList.Max(x => x.OrderID) + 1;
            }

            return orderNumber;
        }

        public void RemoveOrder(DateTime orderDate, int orderID)
        {
            var orderToRemove = orderList.FirstOrDefault(o => o.OrderID == orderID);
            orderList.Remove(orderToRemove);
        }

        public void EditOrder(OrderInfo order)
        {
            var oldOrder = orderList.FirstOrDefault(m => m.OrderID == order.OrderID && m.OrderDate == order.OrderDate);
            orderList.Remove(oldOrder);

            orderList.Add(order);
           
        }

        public OrderInfo FindOrderByID(int orderID, DateTime date)
        {
            //return (OrderInfo) (from orderInfo in orderList
                //where orderInfo.OrderID == orderID && orderInfo.OrderDate == date
                //select orderInfo);

            return orderList.FirstOrDefault(m => m.OrderID == orderID && m.OrderDate == date);
        }


        public List<OrderInfo> FindOrderById(int orderId, DateTime date)
        {
            return (from orderInfo in orderList
                    where orderInfo.OrderID == orderId && orderInfo.OrderDate == date
                    select orderInfo).ToList();
        }
        

        public List<ProductInfo> GetAllProducts()
        {
            return productList;
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            return stateTaxList;
        }
    }
}
