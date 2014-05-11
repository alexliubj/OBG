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
    public static class WheelsDAO
    {

        private static DbHelper db = new DbHelper();

        public static DataTable GetAllProducts()
        {
            DbCommand command = db.GetSqlStringCommond("SELECT ProductId,Image,Style,Brand,Size,PCD,Finish,Offset,SEAT,BORE,Weight,ONHand,Price,CategoryId FROM Wheels");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int DeleteProductById(int prodId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from wheels where ProductId=@ProductId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ProductId", prodId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateProduct(Wheels prod)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE Wheels
                               SET [Image] = @Image
                                  ,[Style] = @Style
                                  ,[Brand] = @Brand
                                  ,[Size] = @Size
                                  ,[PCD] = @PCD
                                  ,[Finish] = @Finish
                                  ,[Offset] = @Offset
                                  ,[SEAT] = @SEAT
                                  ,[BORE] = @BORE
                                  ,[Weight] = @Weight
                                  ,[ONHand] = @ONHand
                                  ,[Price] = @Price
                                  ,[CategoryId] = @CategoryId
                             WHERE productId = @productId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Image", prod.Image),
                new SqlParameter("@Style",prod.Style),
                new SqlParameter("@Brand",prod.Brand),
                new SqlParameter("@Size",prod.Size),
                new SqlParameter("@PCD",prod.Pcd),
                new SqlParameter("@Finish",prod.Finish),
                new SqlParameter("@Offset",prod.Offset),
                new SqlParameter("@SEAT",prod.Seat),
                new SqlParameter("@BORE",prod.Bore),
                new SqlParameter("@Weight",prod.Weight),
                new SqlParameter("@ONHand",prod.Onhand),
                new SqlParameter("@Price",prod.Price),
                 new SqlParameter("@CategoryId",prod.CategoryId),
                 new SqlParameter("@CategoryId",prod.CategoryId)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int AddNewProduct(Wheels prod)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                    INSERT INTO [Wheels]
                               ([Image]
                               ,[Style]
                               ,[Brand]
                               ,[Size]
                               ,[PCD]
                               ,[Finish]
                               ,[Offset]
                               ,[SEAT]
                               ,[BORE]
                               ,[Weight]
                               ,[ONHand]
                               ,[Price]
                               ,[CategoryId])
                         VALUES
                               (@Image,
                               ,@Style,
                               ,@Brand,
                               ,@Size,
                               ,@PCD, 
                               ,@Finish, 
                               ,@Offset, 
                               ,@SEAT,
                               ,@BORE,
                               ,@Weight,
                               ,@ONHand,
                               ,@Price,
                               ,@CategoryId)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Image", prod.Image),
                new SqlParameter("@Style",prod.Style),
                new SqlParameter("@Brand",prod.Brand),
                new SqlParameter("@Size",prod.Size),
                new SqlParameter("@PCD",prod.Pcd),
                new SqlParameter("@Finish",prod.Finish),
                new SqlParameter("@Offset",prod.Offset),
                new SqlParameter("@SEAT",prod.Seat),
                new SqlParameter("@BORE",prod.Bore),
                new SqlParameter("@Weight",prod.Weight),
                new SqlParameter("@ONHand",prod.Onhand),
                new SqlParameter("@Price",prod.Price),
                 new SqlParameter("@CategoryId",prod.CategoryId)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
