using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class RoleBLO
    {
        public static List<Role> GetAllRoleList()
        {
            return RoleDAO.GetAllRoleList();
        }

        public static bool DeleteOneRoleById(int roleId)
        {
            return RoleDAO.DeleteOneRoleById(roleId);
        }

        public static bool ModifyRoleName(int roleId, string roleName)
        {
            return RoleDAO.ModifyRoleName(roleId, roleName);
        }

        public static bool DeleteRoleByRoleId(int roleId)
        {
            return RoleDAO.DeleteOneRoleById(roleId);
        }

        public static bool AddUserToRole(int userid, int roleId)
        {
            return RoleDAO.AddUserToRole(userid, roleId);
        }

        public static Role GetRoleByUserId(int userid)
        {
            return RoleDAO.GetRoleByUserId(userid);
        }

        public static bool DeleteUserFromRole(int userid, int roleId)
        {
            return RoleDAO.DeleteUserFromRole(userid, roleId);
        }
        public static List<UserRole> GetAllUsersWithRole()
        {
            return RoleDAO.GetAllUsersWithRole();
        }
    }
}