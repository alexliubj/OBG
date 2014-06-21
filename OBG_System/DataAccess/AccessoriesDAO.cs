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
    
    public static class AccessoriesDAO
    {
        private static DbHelper db = new DbHelper();
        public static DataTable GetAllAccessories()
        {
            DbCommand command = db.GetSqlStringCommond(@"
                                        SELECT [partNo]
                                              ,[accId]
                                              ,[image]
                                              ,[des]
                                              ,[pricing]
                                              ,[name]
                                                ,[brand],[special]
                                          FROM [Accessories]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static DataTable GetSpecialAllAccessories()
        {
            DbCommand command = db.GetSqlStringCommond(@"
                                        SELECT [partNo]
                                              ,[accId]
                                              ,[image]
                                              ,[des]
                                              ,[pricing]
                                              ,[name]
                                                ,[brand],[special]
                                          FROM [Accessories] where special!=1.0");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static DataTable GetAllAccessories(int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [partNo]
                                              ,[accId]
                                              ,[image]
                                              ,[des]
                                              ,[pricing]
                                              ,[name]
                                                ,[brand]
                                                  ,d.accRate,t.pricing*d.accRate finalprice
                                                  FROM dbo.[Accessories] t ,[discount] d where d.userid=@userid;");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int UpdateAccessory(Accessories acc)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Accessories]
                                       SET [partNo] = @partNo
                                          ,[image] = @image
                                          ,[des] = @des
                                          ,[pricing] = @pricing
                                          ,[name] = @name
                                          ,[brand] = @brand,[special]=@special
                                     WHERE accId= @accId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", acc.PartNo),
                new SqlParameter("@image",acc.Img),
                new SqlParameter("@des",acc.Des),
                new SqlParameter("@pricing",acc.Pricing),
                new SqlParameter("@name",acc.Name),
                 new SqlParameter("@accId",acc.AccId),
                 new SqlParameter("@brand",acc.Brand),
                 new SqlParameter("@special",acc.Special)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int CreateNewAccessory(Accessories acc)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Accessories]
                                                   ([partNo]
                                                   ,[image]
                                                   ,[des]
                                                   ,[pricing]
                                                   ,[name]
                                                   ,[brand],[special])
                                             VALUES
                                                   (@partNo
                                                   ,@image
                                                   ,@des
                                                   ,@pricing
                                                   ,@name
                                                    ,@brand,@special)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", acc.PartNo),
                new SqlParameter("@image",acc.Img),
                new SqlParameter("@des",acc.Des),
                new SqlParameter("@pricing",acc.Pricing),
                new SqlParameter("@name",acc.Name),
                new SqlParameter("@brand",acc.Brand),
                 new SqlParameter("@special",1.0)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteOneAccessory(int accId)
        {
            DbCommand command = db.GetSqlStringCommond(@"  delete from [Accessories] where accId = @accId;");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@accId", accId) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
