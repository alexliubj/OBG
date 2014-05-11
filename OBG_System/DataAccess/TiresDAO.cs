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
    public static class TiresDAO
    {
        public static DataTable GetAllTires()
        {
            return new DataTable();
        }

        public static int CreateNewTire(Tire tire)
        {
            return 0;
        }

        public static int DeleteTire(int tireId)
        {
            return 0;
        }

        public static int UpdateTire(Tire tire)
        {
            return 0;
        }
    }
}
