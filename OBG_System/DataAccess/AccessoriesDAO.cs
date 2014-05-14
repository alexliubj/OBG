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
                                              ,[categoryId]
                                              ,[name]
                                                ,[brand]
                                          FROM [Accessories]");
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
                                          ,[categoryId] = @categoryId
                                          ,[name] = @name
                                          ,[brand] = @brand
                                     WHERE accId= @accId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", acc.PartNo),
                new SqlParameter("@image",acc.Img),
                new SqlParameter("@des",acc.Des),
                new SqlParameter("@pricing",acc.Pricing),
                new SqlParameter("@categoryId",acc.CategoryId),
                new SqlParameter("@name",acc.Name),
                 new SqlParameter("@accId",acc.AccId),
                 new SqlParameter("@brand",acc.Brand)
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
                                                   ,[categoryId]
                                                   ,[name]
                                                   ,[brand])
                                             VALUES
                                                   @partNo
                                                   ,@image
                                                   ,@des
                                                   ,@pricing
                                                   ,@categoryId
                                                   ,@name
                                                    ,@brand");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@partNo", acc.PartNo),
                new SqlParameter("@image",acc.Img),
                new SqlParameter("@des",acc.Des),
                new SqlParameter("@pricing",acc.Pricing),
                new SqlParameter("@categoryId",acc.CategoryId),
                new SqlParameter("@name",acc.Name),
                new SqlParameter("@brand",acc.Brand)
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
