using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
namespace DataAccess
{
    public static class RegionDAO
    {
        public static List<Shipping> GetAllShipping()
        {
            List<Shipping> listShipping = new List<Shipping>();
            return listShipping;
        }

        public static bool UpdateShipping(Shipping ship)
        {
            return true;
        }

        public static bool RemoveShippingById(int shipId)
        {
            return true;
        }

        public static bool AddNewShippping(Shipping ship)
        {
            return true;
        }
    }
}
