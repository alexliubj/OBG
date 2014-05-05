using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class PermissionBLO
    {
        public static bool AddPermission(int prodId, int roleId)
        {
            return PermissionDAO.AddPermission(prodId, roleId);
        }
        public static bool DeletePermission(int prodId, int roleId)
        {
            return PermissionDAO.DeletePermission(prodId, roleId);
        }
        public static List<Role> GetPermissionByProductId(int prodId)
        {
            return PermissionDAO.GetPermissionByProductId(prodId);
        }
    }
}
