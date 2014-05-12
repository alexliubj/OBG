using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class OrderDAO
    {
        private static DbHelper db = new DbHelper();
        public static bool AddNewOrder(Order order)
        {
            bool ret = false;
            return ret;
        }

        public static bool RemoveOrderByOrderId(int orderId)
        {
            bool ret = false;
            return ret;
        }

        public static bool ModifyOneOrder(Order order)
        {
            bool ret = false;
            return ret;
        }

        public static List<Order> GetAllOrder()
        {
            List<Order> listOrder = new List<Order>();
            return listOrder;
        }

        public static bool UpdateOrderStatus(int orderId, int status)
        {
            bool ret = false;
            return ret;
        }

        public static List<Order> GetAllOrderByUserId(int userid)
        {
            List<Order> listOrder = new List<Order>();
            return listOrder;
        }
    }
}
