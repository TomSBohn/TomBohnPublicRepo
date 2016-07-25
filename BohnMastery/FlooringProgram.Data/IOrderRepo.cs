using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IOrderRepo
    {
        List<OrderInfo> GetOrdersByDate(DateTime orderdate);
        OrderInfo CreateOrder(OrderInfo newOrder);
        void EditOrder(OrderInfo order);
        OrderInfo FindOrderByID(int orderID, DateTime date);
        int CreateNextOrderNumber(DateTime orderDate);
        void RemoveOrder(DateTime orderDate, int orderID);

        /* naming conventions CRUD
        OrderInfo Create(OrderInfo order);
        List<OrderInfo> Read(DateTime orderDate);
        void Update(OrderInfo order, int orderId);
        void Delete(DateTime orderDate, int orderId);
        */
    }
}
