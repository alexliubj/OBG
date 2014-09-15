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
                                                      ,[des],[special]
                                                  FROM [Tires] order by tireId DESC");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static DataTable GetSpecialAllTires(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [tireId]
                                                      ,[partNo]
                                                      ,[image]
                                                      ,[size]
                                                      ,[pricing]
                                                      ,[season]
                                                      ,[brand]
                                                      ,[des],[special],d.tiresRate,t.pricing*d.tiresRate finalprice, t.pricing*t.special specialPrice
                                                  FROM [Tires] t,[discount] d where d.userid=@userid and special != 1.0");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid) };
            command.Parameters.AddRange(paras);
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
                                                      ,[des], [special]
                                                  ,d.tiresRate,t.pricing*d.tiresRate finalprice, t.pricing*t.special specialPrice
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
                                                       ,[season],[brand],[des],[special])
                                                 VALUES
                                                       (@partNo
                                                       ,@image
                                                       ,@size
                                                       ,@pricing
                                                       ,@season
                                                       ,@brand
                                                       ,@des,@special)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", tire.PartNo),
                new SqlParameter("@size",tire.Size),
                new SqlParameter("@image",tire.Image),
                //new SqlParameter("@rimWith",tire.Width),
                //new SqlParameter("@rimHeight",tire.Height),
                new SqlParameter("@pricing",tire.Pricing),
                new SqlParameter("@season",tire.Season),
                new SqlParameter("@des",tire.Des),
                new SqlParameter("@brand",tire.Brand),
                new SqlParameter("@special",tire.Special)
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
                                      ,[des] = @des, [special]=@special
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
                new SqlParameter("@brand",tire.Brand),
                new SqlParameter("@special",tire.Special)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
