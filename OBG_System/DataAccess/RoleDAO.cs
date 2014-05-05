using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class RoleDAO
    {
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

        public static bool AddUserToRole(int userid, int roleId)
        {
            return true;
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
