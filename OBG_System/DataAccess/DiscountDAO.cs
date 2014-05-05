using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class DiscountDAO
    {
        public static List<Discount> GetAllDiscount()
        {
            List<Discount> listDiscount = new List<Discount>();
            return listDiscount;
        }

        public static bool AddDiscount(int roleId, float rate)
        {
            return true;
        }

        public static bool UpdateDiscount(int roleId, float rate)
        {
            return true;
        }

        public static bool DeleteDiscount(int roleId)
        {
            return true;
        }
    }
}
