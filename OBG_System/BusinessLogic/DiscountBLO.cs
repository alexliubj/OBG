using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class DiscountBLO
    {

        public static List<Discount> GetAllDiscount()
        {
            return DiscountDAO.GetAllDiscount();
        }

        public static bool AddDiscount(int roleId, float rate)
        {
            return DiscountDAO.AddDiscount(roleId,rate);
        }

        public static bool UpdateDiscount(int roleId, float rate)
        {
            return DiscountDAO.UpdateDiscount(roleId, rate);
        }

        public static bool DeleteDiscount(int roleId)
        {
            return DiscountDAO.DeleteDiscount(roleId);
        }
    }
}
