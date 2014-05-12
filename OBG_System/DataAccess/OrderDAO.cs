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

        //https://github.com/alexliubj/OracleClientForm/blob/master/OracleClient/DataLogic/DataAccessLayer/OrderDAO.cs
        public static int AddNewOrder(Order order, List<OrderLine> listOrderLine)
        {
            return 0;
        }

        //should be update in...a transaction
        public static int RemoveOrderByOrderId(int orderId)
        {
            //remove order 
            DbCommand command = db.GetSqlStringCommond(@"delete from order where orderId =@orderId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@orderId", orderId) };
            command.Parameters.AddRange(paras);
            //remove from orderline
            DbCommand command2 = db.GetSqlStringCommond(@"delete from orderline where orderId = @orderId;");
            SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@orderId", orderId) };
            command2.Parameters.AddRange(paras2);
            db.ExecuteNonQuery(command);
            return db.ExecuteNonQuery(command2);
        }

        public static int ModifyOneOrder(Order order, List<OrderLine> listOrderLine)
        {
            return 0;
        }

        public static DataTable GetAllOrder()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [OrderId]
                                                      ,[UserId]
                                                      ,[OrderDate]
                                                      ,[Status]
                                                      ,[PO]
                                                  FROM [Order]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int UpdateOrderStatus(int orderId, int status)
        {
            DbCommand command = db.GetSqlStringCommond(@"update [order] set [Status]=@status where orderId = @orderId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@status", status)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command); 
        }


        public static DataTable GetOrderLineByOrderId(int orderId)
        {
            return new DataTable();
        }

        public static DataTable GetAllOrderByUserId(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [OrderId]
                                                      ,[UserId]
                                                      ,[OrderDate]
                                                      ,[Status]
                                                      ,[PO]
                                                  FROM [Order]
                                                   where UserId = @UserId");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@UserId", userid),
            };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }
    }
}
