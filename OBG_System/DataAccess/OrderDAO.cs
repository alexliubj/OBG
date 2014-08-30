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

    //should be change to transaction 
    public static class OrderDAO
    {
        private static DbHelper db = new DbHelper();

        public static int AddNewOrder(Order order, List<OrderLine> listOrderLine)
        {
            int newOrderId = 0;
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Order]
                                                       ([UserId]
                                                       ,[OrderDate]
                                                       ,[Status]
                                                       ,[PO])
                                                 VALUES
                                                       (@userId
                                                       ,@datetime
                                                       ,@status
                                                       ,@PO);Select @@IDENTITY;");

                    SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userId", order.UserId),
            new SqlParameter("@datetime", order.OrderDate),
            new SqlParameter("@status", order.Status),
            new SqlParameter("@PO", order.PO)};
                    command.Parameters.AddRange(paras);
                    newOrderId = Convert.ToInt32(db.ExecuteScalar(command, t));
                    if (newOrderId > 0)
                    {
                        foreach (OrderLine line in listOrderLine)
                        {
                            DbCommand command2 = db.GetSqlStringCommond(@"INSERT INTO [OrderLine]
                                               ([ProductId]
                                               ,[Qty]
                                               ,[DiscountRate]
                                               ,[Image]
                                               ,[OrderId],[ProductType],[ProductName],[PartNO])
                                         VALUES
                                               (@ProductId
                                               ,@Qty
                                               ,@DiscountRate
                                               ,@Image
                                               ,@OrderId,@ProductType,@ProductName,@PartNO)");
                            SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@ProductId", line.ProductId),
                new SqlParameter("@Qty", line.Qty),
                new SqlParameter("@Image", line.Image),
            new SqlParameter("@DiscountRate", line.DiscountRate),
                new SqlParameter("@OrderId", newOrderId),
                    new SqlParameter("@ProductType",line.ProductType),
                    new SqlParameter("@ProductName",line.ProductName),
                    new SqlParameter("@PartNO",line.PartNO)
                            };
                            command2.Parameters.AddRange(paras2);
                            db.ExecuteNonQuery(command2, t);
                        }
                    }

                    t.Commit();
                    return newOrderId;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        public static int RemoveOrderByOrderId(int orderId)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"delete [order] where orderId = @orderId");
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@orderId", orderId) };
                    command.Parameters.AddRange(paras);
                    int ret = db.ExecuteNonQuery(command, t);

                    DbCommand command2 = db.GetSqlStringCommond(@"delete [orderline] where orderId = @orderId;");
                    SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@orderId", orderId) };
                    command2.Parameters.AddRange(paras2);

                    db.ExecuteNonQuery(command2, t);
                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        public static bool qtyUpdate(int productid, int proQty)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [OBG_].[dbo].[OrderLine]
                                   SET [Qty] = @proQty
                                 WHERE productid = @productid");
            SqlParameter[] paras = new SqlParameter[] { 
               
                new SqlParameter("@productid",productid),
                new SqlParameter("@proQty",proQty)
            };
            command.Parameters.AddRange(paras);
            return (db.ExecuteNonQuery(command) > 0) ? true : false;
        }

        public static int ModifyOneOrder(Order order, List<OrderLine> listOrderLine)
        {
            int newOrderId = -1;
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"UPDATE [Order]
                                               SET [UserId] = @userId
                                                  ,[OrderDate] = @datetime
                                                  ,[Status] = @status
                                                  ,[PO] = @PO
                                             WHERE OrderId=@OrderId");

                    SqlParameter[] paras = new SqlParameter[] { 
                                            new SqlParameter("@userId", order.UserId),
                                            new SqlParameter("@datetime", order.OrderDate),
                                            new SqlParameter("@status", order.Status),
                                            new SqlParameter("@PO", order.PO),
                                             new SqlParameter("@OrderId", order.OrderId)
                                    };
                    command.Parameters.AddRange(paras);
                    newOrderId = Convert.ToInt32(db.ExecuteScalar(command,t));
                    if (newOrderId > 0)
                    {
                        foreach (OrderLine line in listOrderLine)
                        {
                            DbCommand command2 = db.GetSqlStringCommond(@"UPDATE [OrderLine]
                                           SET [ProductId] = @ProductId
                                              ,[Qty] = @Qty
                                              ,[DiscountRate] = @DiscountRate, [ProductType]=@ProductType, [Image] = @Image,
                                            [ProductName]=@ProductName, [PartNO] = @PartNO 
                                         WHERE OrderId=@OrderId
                                        ");
                            SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@ProductId", line.OrderId),
                new SqlParameter("@Qty", line.Qty),
                new SqlParameter("@Image", line.Image),
            new SqlParameter("@DiscountRate", line.DiscountRate),
                new SqlParameter("@OrderId", newOrderId),
                            new SqlParameter("@ProductType",line.ProductType),
                            new SqlParameter("@ProductName",line.ProductName),
                            new SqlParameter("PartNO",line.PartNO)};
                            command.Parameters.AddRange(paras2);
                            db.ExecuteNonQuery(command2,t);
                        }
                    }
                    t.Commit();
                    return newOrderId;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        public static DataTable GetAllOrder()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [OrderId]
                                                      ,[UserId]
                                                      ,[OrderDate]
                                                      ,[Status]
                                                      ,[PO]
                                                  FROM [Order] Order by orderid desc");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

//        public static DataTable GetAllOrders()
//        {
//            DbCommand command = db.GetSqlStringCommond(@"SELECT o.OrderId
//                                                      ,o.UserId
//                                                      ,o.OrderDate
//                                                      ,o.Status
//                                                      ,o.PO
//                                                      ,u.companyname
//                                                  FROM Order o inner join users u on o.userid = u.userid where");
//            DataTable dt = db.ExecuteDataTable(command);
//            return dt;
//        }


        public static int UpdateOrderStatus(int orderId, int status)
        {
            DbCommand command = db.GetSqlStringCommond(@"update [order] set [Status]=@status where orderId = @orderId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@status", status)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command); 
        }

//        select o.orderid, o.orderdate, o.customerid,c.custfname, 
//c.custlname, sum( ol.unitprice * ol.quantity) as amount,o.DISCOUNT "
//                                    + " from orders o"
//                                    + " inner join orderline ol"
//                                    + " on o.orderid = ol.orderid"
//                                    + " inner join customers c"
//                                    + " on o.customerid = c.customerid";
        public static DataTable GetOrderLineByOrderId(int orderId)
        {
            DbCommand command = db.GetSqlStringCommond(@"select ol.productId, ol.qty, ol.discountRate, ol.image,
                                                   ol.orderId,ol.productType,ol.productName,ol.partNo,ol.discountRate*ol.qty finalprice
                                                 from [Order] o inner join OrderLine ol
                                                 on o.orderId = ol.OrderId where ol.OrderId = @OrderId");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@OrderId", orderId),
            };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static DataTable GetAllOrderByUserId(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [OrderId]
                                                      ,[UserId]
                                                      ,[OrderDate]
                                                      ,[Status]
                                                      ,[PO]
                                                  FROM [Order] 
                                                   where UserId = @UserId ORDER BY OrderId desc");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@UserId", userid),
            };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int DeleteProductById(int prodId)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"delete [orderline] where productid = @productid");
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@productid", prodId) };
                    command.Parameters.AddRange(paras);
                    int ret = db.ExecuteNonQuery(command, t);

                    //db.ExecuteNonQuery(command2, t);
                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

    }
}
