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
                                                      ,[size]
                                                      ,[rimWith]
                                                      ,[rimHeight]
                                                      ,[pricing]
                                                      ,[season]
                                                      ,[categoryId]
                                                  FROM [Tires]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int CreateNewTire(Tire tire)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Tires]
                                                       ([partNo]
                                                       ,[size]
                                                       ,[rimWith]
                                                       ,[rimHeight]
                                                       ,[pricing]
                                                       ,[season]
                                                       ,[categoryId])
                                                 VALUES
                                                       (@partNo
                                                       ,@size
                                                       ,@rimWith
                                                       ,@rimHeight
                                                       ,@pricing
                                                       ,@season
                                                       ,@categoryId)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", tire.PartNo),
                new SqlParameter("@size",tire.Size),
                new SqlParameter("@rimWith",tire.Width),
                new SqlParameter("@rimHeight",tire.Height),
                new SqlParameter("@pricing",tire.Pricing),
                new SqlParameter("@season",tire.Season),
                new SqlParameter("@categoryId",tire.CategoryId)
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
                                      ,[size] = @size
                                      ,[rimWith] = @rimWith
                                      ,[rimHeight] = @rimHeight
                                      ,[pricing] = @pricing
                                      ,[season] = @season
                                      ,[categoryId] = @categoryId
                                 WHERE tireId = @tireId)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", tire.PartNo),
                new SqlParameter("@size",tire.Size),
                new SqlParameter("@rimWith",tire.Width),
                new SqlParameter("@rimHeight",tire.Height),
                new SqlParameter("@pricing",tire.Pricing),
                new SqlParameter("@season",tire.Season),
                new SqlParameter("@categoryId",tire.CategoryId),
                new SqlParameter("@tireId",tire.TireId)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
