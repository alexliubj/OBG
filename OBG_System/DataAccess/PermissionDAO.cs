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
    public static class PermissionDAO
    {
        private static DbHelper db = new DbHelper();

        public static DataTable GetPermissions()
        {
            // List<int> permissions = new List<int>();

            DbCommand command = db.GetSqlStringCommond(@"
                            select p.*, u.[UserName] from [Permission] p join [Users]u on u.userid = p.userid");

            DataTable dt = db.ExecuteDataTable(command);

            //using (DbDataReader reader = db.ExecuteReader(command))
            //{
            //    while (reader.Read())
            //    {
            //        permissions.Add(reader.GetInt32(1));
            //        permissions.Add(reader.GetInt32(2));
            //        permissions.Add(reader.GetInt32(3));
            //    }
            //}

            //return permissions;
            return dt;
        }

        public static List<int> GetPermissionByUserID(int userId)
        {
            List<int> permissions = new List<int>();

            DbCommand command = db.GetSqlStringCommond(@"
                            select * from [Permission] where userid = @userid");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userId", userId)};
            command.Parameters.AddRange(paras);

            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    permissions.Add(reader.GetInt32(1));
                    permissions.Add(reader.GetInt32(2));
                    permissions.Add(reader.GetInt32(3));
                }
            }

            return permissions;

        }

        public static int UpdatePermission(int userId, List<int> permissions)
        {

            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Permission]
                                                   SET [WheelPermission] = @WheelPermission,
                                                       [TirePermission] = @TirePermission,
                                                       [AccPermission] = @AccPermission
                                                 WHERE userId=@userId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userId", userId),
            new SqlParameter("@WheelPermission", permissions[0]),
            new SqlParameter("@TirePermission", permissions[1]),
            new SqlParameter("@AccPermission", permissions[2])};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
    }
}
