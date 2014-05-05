using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class OrderBLO
    {
        public enum OrderStatus
        {
            created,
            shipped,
            finished,
        };

        public static bool AddNewOrder(Order order)
        {
            return OrderDAO.AddNewOrder(order);
        }

        public static bool RemoveOrderByOrderId(int orderId)
        {
            return OrderDAO.RemoveOrderByOrderId(orderId);
        }

        public static bool ModifyOneOrder(Order order)
        {
            return OrderDAO.ModifyOneOrder(order);
        }

        public static List<Order> GetAllOrder()
        {
            return OrderDAO.GetAllOrder();
        }

        public static bool UpdateOrderStatus(int orderId, int status)
        {
            return OrderDAO.UpdateOrderStatus(orderId, status);
        }

        public static List<Order> GetAllOrderByUserId(int userid)
        {
            return OrderDAO.GetAllOrderByUserId(userid);
        }
    }
}
