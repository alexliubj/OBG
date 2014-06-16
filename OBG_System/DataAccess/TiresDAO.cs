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
    public static class TiresDAO
    {
        private static DbHelper db = new DbHelper();
        public static DataTable GetAllTires()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [tireId]
                                                      ,[partNo]
                                                      ,[image]
                                                      ,[size]
                                                      ,[pricing]
                                                      ,[season]
                                                      ,[brand]
                                                      ,[des]
                                                  FROM [Tires]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }
        public static DataTable GetAllTires(int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [tireId]
                                                      ,[partNo]
                                                      ,[image]
                                                      ,[size]
                                                      ,[pricing]
                                                      ,[season]
                                                      ,[brand]
                                                      ,[des]
                                                  ,d.tiresRate,t.pricing*d.tiresRate finalprice
                                                  FROM dbo.[Tires] t ,[discount] d where d.userid=@userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int CreateNewTire(Tire tire)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Tires]
                                                       ([partNo]
                                                       ,[image]
                                                       ,[size]                                                      
                                                       ,[pricing]
                                                       ,[season],[brand],[des])
                                                 VALUES
                                                       (@partNo
                                                       ,@image
                                                       ,@size
                                                       ,@pricing
                                                       ,@season
                                                       ,@brand
                                                       ,@des)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", tire.PartNo),
                new SqlParameter("@size",tire.Size),
                new SqlParameter("@image",tire.Image),
                //new SqlParameter("@rimWith",tire.Width),
                //new SqlParameter("@rimHeight",tire.Height),
                new SqlParameter("@pricing",tire.Pricing),
                new SqlParameter("@season",tire.Season),
                new SqlParameter("@des",tire.Des),
                new SqlParameter("@brand",tire.Brand)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteTire(int tireId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from Tires where tireId =@tireId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@tireId", tireId) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateTire(Tire tire)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [OBG_].[dbo].[Tires]
                                   SET [partNo] = @partNo
                                      ,[image] = @image
                                      ,[size] = @size
                                      ,[pricing] = @pricing
                                      ,[season] = @season
                                      ,[brand] = @brand
                                      ,[des] = @des
                                 WHERE tireId = @tireId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", tire.PartNo),
                new SqlParameter("@size",tire.Size),
                new SqlParameter("@image", tire.Image),
                //new SqlParameter("@rimWith",tire.Width),
                new SqlParameter("@des",tire.Des),
                new SqlParameter("@pricing",tire.Pricing),
                new SqlParameter("@season",tire.Season),
                new SqlParameter("@tireId",tire.TireId),
                new SqlParameter("@brand",tire.Brand)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
