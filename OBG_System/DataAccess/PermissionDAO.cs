using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class PermissionDAO
    {
        public static bool AddPermission(int prodId, int roleId)
        {
            return true;
        }
        public static bool DeletePermission(int prodId, int roleId)
        {
            return true;
        }
        public static List<Role> GetPermissionByProductId(int prodId)
        {
            return new List<Role>();
        }
    }
}
