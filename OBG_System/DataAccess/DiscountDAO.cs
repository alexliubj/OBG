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
            DbCommand command = db.GetSqlStringCommond(@"select d.userid,d.wheelsRate,d.tiresRate,d.accRate,u.username
                                                        from [discount] d inner join [users] u
                                                        on d.userid = u.userid");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static bool getDiscountExists(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select count(*) from discount where userid=@userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid) };
            command.Parameters.AddRange(paras);
            if ((int)db.ExecuteScalar(command) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int AddDiscount(int userId, float wheelsRate, float tiresRate, float accRate)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Discount]
                                                   ([UserId]
                                                   ,[wheelsRate],[tiresRate],[accRate])
                                             VALUES
                                                   (@UserId
                                                   ,@wheelsRate,@tiresRate,@accRate)");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@UserId", userId) ,
            new SqlParameter("@wheelsRate",wheelsRate),
            new SqlParameter("@tiresRate",tiresRate),
            new SqlParameter("@accRate",accRate)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateDiscount(int userId, float wheelsRate, float tiresRate, float accRate)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Discount]
                                                   SET [wheelsRate] = @wheelsRate, [tiresRate] = @tiresRate, [accRate] = @accRate
                                                 WHERE userId=@userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userId", userId),
            new SqlParameter("@wheelsRate",wheelsRate),
            new SqlParameter("@tiresRate",tiresRate),
            new SqlParameter("@accRate",accRate)};
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
