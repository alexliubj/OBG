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
        public static DataTable GetAllSpecialWheels()
        {
            return WheelsDAO.GetAllSpecialProducts();
        }

        public static DataTable GetAllSpecialTires()
        {
            return TiresDAO.GetSpecialAllTires();
        }

        public static DataTable GetAllSpecialAcces()
        {
            return AccessoriesDAO.GetSpecialAllAccessories();
        }
    }
}
