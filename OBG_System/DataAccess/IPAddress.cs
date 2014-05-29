using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess
{
    public static class IPAddress
    {
        private static DbHelper db = new DbHelper();
        public static string GetLastIPAddress(int userId)
        {
            string lastIPAddress = string.Empty;
            DbCommand command = db.GetSqlStringCommond(@"
                            select * from [IPAddress] where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@userid",userId)};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    lastIPAddress = reader.GetString(0);
                }
            }
            return lastIPAddress;
        }

        public static int UpdateIpAddress(string ipAddress, int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select count(*) from [IPAddress] where userId = @userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userId)};
            command.Parameters.AddRange(paras);

            int result= (int)db.ExecuteScalar(command);
            if (result > 0) // update 
            {
                DbCommand command2 = db.GetSqlStringCommond(@"
                            update IPAddress set [UserLastIP] = @userIP where userid = @userId");
                SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@userIP", ipAddress),
                new SqlParameter("@userId", userId)};
                command2.Parameters.AddRange(paras2);
                return db.ExecuteNonQuery(command2);
            }
            else // insert
            {
                DbCommand command2 = db.GetSqlStringCommond(@"
                            insert into [UserLastIP] values (@userId,@userIP)");
                SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@userIP", ipAddress),
                new SqlParameter("@userId", userId)};
                command2.Parameters.AddRange(paras2);
                return db.ExecuteNonQuery(command2);
            }
            
        }
    }
}
