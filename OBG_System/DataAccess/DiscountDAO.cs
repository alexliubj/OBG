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
            DbCommand command = db.GetSqlStringCommond(@"select d.userid,d.disrate,u.username
                                                        from [discount] d inner join [users] u
                                                        on d.userid = u.userid");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int AddDiscount(int userId, float rate)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Discount]
                                                   ([UserId]
                                                   ,[DisRate])
                                             VALUES
                                                   (@UserId
                                                   ,@DisRate)");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@UserId", userId) ,
            new SqlParameter("@DisRate",rate)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateDiscount(int userId, float rate)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Discount]
                                                   SET [DisRate] = @rate
                                                 WHERE userId=@userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userId", userId),
            new SqlParameter("@rate", rate)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteDiscount(int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from discount where userId = @userId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userId", userId) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
