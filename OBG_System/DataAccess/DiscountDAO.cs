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
    public static class DiscountDAO
    {
        private static DbHelper db = new DbHelper();
        public static DataTable GetAllDiscount()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [RoleId]
                                                      ,[DisRate]
                                                  FROM [Discount]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int AddDiscount(int roleId, float rate)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Discount]
                                                   ([RoleId]
                                                   ,[DisRate])
                                             VALUES
                                                   (@RoleId
                                                   ,@DisRate)");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@roleId", roleId) ,
            new SqlParameter("@roleId",roleId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateDiscount(int roleId, float rate)
        {

            DbCommand command = db.GetSqlStringCommond(@"UPDATE  [Discount]
                                                   SET [DisRate] = @rate
                                                 WHERE roleId=@roleId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@roleId", roleId) ,
            new SqlParameter("@roleId",roleId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteDiscount(int roleId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from discount where roleId = @roleId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@roleId", roleId) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
