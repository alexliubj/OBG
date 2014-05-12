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
