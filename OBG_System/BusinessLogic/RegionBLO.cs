using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public static class RegionBLO
    {
        public static DataTable GetAllShipping()
        {
            return RegionDAO.GetAllShipping();
        }

        public static int UpdateShipping(Shipping ship)
        {
            return RegionDAO.UpdateShipping(ship);
        }

        public static int RemoveShippingById(int shipId)
        {
            return RegionDAO.RemoveShippingById(shipId);
        }

        public static int AddNewShippping(Shipping ship)
        {
            return RegionDAO.AddNewShippping(ship);
        }
    }
}
