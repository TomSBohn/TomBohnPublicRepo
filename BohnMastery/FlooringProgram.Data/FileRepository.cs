using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class FileRepository : IOrderRepo
    {
        public List<OrderInfo> orders { get; set; }

        public OrderInfo CreateOrder(OrderInfo newOrder)
        {
            orders = GetOrdersByDate(newOrder.OrderDate);
            orders.Add(newOrder);
            WriteOrders(newOrder.OrderDate, orders);
            return newOrder;
        }

        private bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }


        private void WriteOrders(DateTime date, List<OrderInfo> orders) // add list of orders here?
        {

            string filePath = $@"Data/Orders_{date.ToString("MMddyyyy")}.txt";
            //if (File.Exists(filePath))
            //{
            //    orders = GetOrdersByDate(date);

            //}

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var order in orders)
                {
                    writer.WriteLine(
                        $"{order.OrderID},{order.Area},{order.CustomerName},{order.ProductType.ProductType},{order.MaterialCost},{order.OrderDate},{order.Tax.StateAbb},{order.TaxTotal},{order.Total}");
                }

                
            }

        }


 

        public void EditOrder(OrderInfo order)
        {
            string filePath = $@"Data\Orders_{order.OrderDate.ToString("MMddyyyy")}.txt";

            List<OrderInfo> ordersFromFile = GetOrdersByDate(order.OrderDate);
            int index = ordersFromFile.FindIndex(o => o.OrderID == order.OrderID);
            ordersFromFile[index] = order;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var o in ordersFromFile)
                {
                    writer.WriteLine(
                        $"{o.OrderID},{o.Area},{o.CustomerName},{o.ProductType.ProductType},{o.MaterialCost},{o.OrderDate},{o.Tax.StateAbb},{o.TaxTotal},{o.Total}");
                }
            }
        }

        public OrderInfo FindOrderByID(int orderID, DateTime date)
        {
            //var specificOrder = File.ReadLines($@"Order_{date}.txt").Where(l => l == orderID.ToString());
            //return (OrderInfo) specificOrder;

            var orderList = GetOrdersByDate(date);
            return orderList.FirstOrDefault(m => m.OrderID == orderID);
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            List<OrderInfo> ordersByDate = new List<OrderInfo>();

            try
            {
                string filePath = $@"Data/Orders_{orderdate.ToString("MMddyyyy")}.txt";
                if (FileExists(filePath))
                {
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string inputLine = "";
                        string[] inputParts;
                        while ((inputLine = sr.ReadLine()) != null) 
                        {
                            inputParts = inputLine.Split(',');
                            OrderInfo thisOrder = new OrderInfo()
                            {
                                OrderID = Int32.Parse(inputParts[0]),
                                Area = int.Parse(inputParts[1]),
                                CustomerName = inputParts[2],
                                ProductType = new ProductInfo()
                                {
                                    ProductType = inputParts[3]
                                },
                                MaterialCost = Convert.ToDecimal(inputParts[4]),
                                OrderDate = Convert.ToDateTime(inputParts[5]),
                                Tax = new StateTaxInfo()
                                {
                                    StateAbb = inputParts[6]
                                },
                                TaxTotal = Convert.ToDecimal(inputParts[7]),
                                Total = Convert.ToDecimal(inputParts[8]),

                            };

                            ordersByDate.Add(thisOrder);
                        }
                    }
                    return ordersByDate;
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToLogTxt(ex);
            }
            return ordersByDate;
        }

        public void RemoveOrder(DateTime orderDate, int orderID)
        {
            string filePath = $@"Data\Orders_{orderDate.ToString("MMddyyyy")}.txt";

            List<OrderInfo> ordersFromFile = GetOrdersByDate(orderDate);
            //int index = ordersFromFile.FindIndex(o => o.OrderID == orderID);
            //ordersFromFile.RemoveAt(index);

            ordersFromFile.Remove(ordersFromFile.First(o => o.OrderID == orderID));
            File.Delete(filePath);
            using (var writer = File.CreateText(filePath))
            {
                foreach (var o in ordersFromFile)
                {
                    writer.WriteLine(
                        $"{o.OrderID},{o.Area},{o.CustomerName},{o.ProductType.ProductType},{o.MaterialCost},{o.OrderDate},{o.Tax.StateAbb},{o.TaxTotal},{o.Total}");
                }
            }
        }

        public int CreateNextOrderNumber(DateTime orderDate)
        {
            List<OrderInfo> ordersFromFile = GetOrdersByDate(orderDate);

            int orderNumber;
            if (ordersFromFile.Count == 0)
            {
                orderNumber = 0;
            }
            else
            {
                orderNumber = ordersFromFile.Max(x => x.OrderID);
            }
            return ++orderNumber;
        }
    }
}