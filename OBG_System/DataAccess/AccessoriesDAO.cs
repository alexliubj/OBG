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
    public static class AccessoriesDAO
    {
        public static DataTable GetAllAccessories()
        {
            return new DataTable();
        }

        public static int UpdateAccessory(Accessories acc)
        {
            return 0;
        }

        public static int CreateNewAccessory(Accessories acc)
        {
            return 0;
        }

        public static int DeleteOneAccessory(int accId)
        {
            return 0;
        }
    }
}
