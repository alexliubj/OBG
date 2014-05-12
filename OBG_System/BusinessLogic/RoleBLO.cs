using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

using System.Data;
namespace BusinessLogic
{
    public static class RoleBLO
    {
        public static DataTable GetAllRoleList()
        {
            return RoleDAO.GetAllRoleList();
        }

        public static int DeleteOneRoleById(int roleId)
        {
            return RoleDAO.DeleteRoleByRoleId(roleId);
        }

        public static int ModifyRoleName(int roleId, string roleName,string description)
        {
            return RoleDAO.ModifyRoleName(roleId, roleName, description);
        }

        public static int AddNewRole(Role role)
        {
            return RoleDAO.CreateNewRole(role);
        }

        public static int AddUserToRole(int userid, int roleId, string des)
        {
            return RoleDAO.AddUserToRole(userid, roleId, des);
        }

        public static Role GetRoleByUserId(int userid)
        {
            return RoleDAO.GetRoleByUserId(userid);
        }

        public static int DeleteUserFromRole(int userid, int roleId)
        {
            return RoleDAO.DeleteUserFromRole(userid, roleId);
        }
        public static DataTable GetAllUsersWithRole(int roleId)
        {
            return RoleDAO.GetAllUsersWithRole(roleId);
        }
    }
}