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
                    lastIPAddress = reader.GetString(1);
                }
            }
            return lastIPAddress;
        }

        public static DataTable GetAllAddress(int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"select u.ipid, u.userid,i.allip,i.logintimes
                                    from userip u
                                    inner join allip i
                                    on u.userid = i.userid
                                    where u.userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);

            return dt;
        }

        public static int UpdateIpAddress(string ipAddress, int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select count(*) from [IPAddress] where userId = @userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userId)};
            command.Parameters.AddRange(paras);

            int result = (int)db.ExecuteScalar(command);
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
                            insert into [IPAddress] ([UserID], [UserLastIP]) values (@userId,@userIP)");
                SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@userIP", ipAddress),
                new SqlParameter("@userId", userId)};
                command2.Parameters.AddRange(paras2);
                return db.ExecuteNonQuery(command2);
            }

        }

        public static int GetLoginTimes(int userId)
        {
            int loginTimes = 0;
            DbCommand command = db.GetSqlStringCommond(@"
                            select * from [IPAddress] where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@userid",userId)};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    loginTimes = reader.GetInt32(2);
                }
            }
            return loginTimes;
        }

        public static int UpdateLoginTimes(int userId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select * from [IPAddress] where userId = @userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userId)};
            command.Parameters.AddRange(paras);
            int loginTimes=0;
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(2) == false)
                    {
                        loginTimes = reader.GetInt32(2);
                    }
                }
            }

            DbCommand command2 = db.GetSqlStringCommond(@"
                            update IPAddress set [LoginTimes] = @LoginTimes where userid = @userId");
            SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@LoginTimes", loginTimes+1),
                new SqlParameter("@userId", userId)};
            command2.Parameters.AddRange(paras2);
            return db.ExecuteNonQuery(command2);
        }
    }
}
