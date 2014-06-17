using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;

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

        public static DataTable GetOrderLineByOrderId(int orderId)
        {
            return OrderDAO.GetOrderLineByOrderId(orderId);
        }

        public static int AddNewOrder(Order order, List<OrderLine> listOrderLine)
        {
            return OrderDAO.AddNewOrder(order, listOrderLine);
        }

        public static int RemoveOrderByOrderId(int orderId)
        {
            return OrderDAO.RemoveOrderByOrderId(orderId);
        }

        public static int ModifyOneOrder(Order order, List<OrderLine> listOrderLine)
        {
            return OrderDAO.ModifyOneOrder(order, listOrderLine);
        }

        public static DataTable GetAllOrder()
        {
            return OrderDAO.GetAllOrder();
        }

        public static int UpdateOrderStatus(int orderId, int status)
        {
            return OrderDAO.UpdateOrderStatus(orderId, status);
        }

        public static DataTable GetAllOrderByUserId(int userid)
        {
            return OrderDAO.GetAllOrderByUserId(userid);
        }

        public static bool UpdateQtybyProid(int productid, int qty)
        {
            return OrderDAO.qtyUpdate(productid, qty);
        }
    }
}
