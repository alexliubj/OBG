using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public static class PermissionBLO
    {
        public static DataTable GetPermissions()
        {
            return PermissionDAO.GetPermissions();
        }

        public static int UpdatePermission(int userId, List<int> permissions)
        {
            return PermissionDAO.UpdatePermission(userId, permissions);
        }

        public static List<int> GetPermissionByUserID(int userId)
        {
            return PermissionDAO.GetPermissionByUserID(userId);
        }
    }
}
