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
    public static class RoleDAO
    {

        private static DbHelper db = new DbHelper();

        public static List<Role> GetAllRoleList()
        {
            List<Role> listRole = new List<Role>();
            return listRole;
        }

        public static bool DeleteOneRoleById(int roleId)
        {
            return true;
        }

        public static bool ModifyRoleName(int roleId, string roleName)
        {
            return true;
        }

        public static bool DeleteRoleByRoleId(int roleId)
        {
            return true;
        }

        public static int AddUserToRole(int userid, int roleId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            insert into userrole(roleid,userid,des) values (@roleid,@userid,'customer')");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@roleid", roleId) , 
            new SqlParameter("@userid",userid)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static Role GetRoleByUserId(int userid)
        {
            Role aRole = new Role();
            return aRole;
        }

        public static bool DeleteUserFromRole(int userid, int roleId)
        {
            return true;
        }

        public static List<UserRole> GetAllUsersWithRole()
        {
            List<UserRole> listUserRole = new List<UserRole>();
            return listUserRole;
        }

    }
}
