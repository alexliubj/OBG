using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public static class DiscountBLO
    {
        public static DataTable GetAllDiscount()
        {
            return DiscountDAO.GetAllDiscount();
        }

        public static int AddDiscount(int roleId, float wheels, float tires, float acc)
        {
            return DiscountDAO.AddDiscount(roleId,wheels,tires,acc);
        }

        public static int UpdateDiscount(int roleId, float wheels, float tires, float acc)
        {
            return DiscountDAO.UpdateDiscount(roleId, wheels, tires, acc);
        }

        public static int DeleteDiscount(int userId)
        {
            return DiscountDAO.DeleteDiscount(userId);
        }

        public static double GetDiscountByUserId(int userId)
        {
            return DiscountDAO.getDisccountByUserID(userId);
        }
    }
}
