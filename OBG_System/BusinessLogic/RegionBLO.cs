using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class RegionBLO
    {
        public static List<Shipping> GetAllShipping()
        {
            return RegionDAO.GetAllShipping();
        }

        public static bool UpdateShipping(Shipping ship)
        {
            return RegionDAO.UpdateShipping(ship);
        }

        public static bool RemoveShippingById(int shipId)
        {
            return RegionDAO.RemoveShippingById(shipId);
        }

        public static bool AddNewShippping(Shipping ship)
        {
            return RegionDAO.AddNewShippping(ship);
        }
    }
}
