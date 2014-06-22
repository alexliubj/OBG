using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public static class SpecialBLO
    {
        public static DataTable GetAllSpecialWheels(int userid)
        {
            return WheelsDAO.GetAllSpecialProducts(userid);
        }

        public static DataTable GetAllSpecialTires(int userid)
        {
            return TiresDAO.GetSpecialAllTires(userid);
        }

        public static DataTable GetAllSpecialAcces(int userid)
        {
            return AccessoriesDAO.GetSpecialAllAccessories(userid);
        }
    }
}
