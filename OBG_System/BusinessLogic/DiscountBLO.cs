﻿using System;
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

        public static int AddDiscount(int roleId, float rate)
        {
            return DiscountDAO.AddDiscount(roleId,rate);
        }

        public static int UpdateDiscount(int roleId, float rate)
        {
            return DiscountDAO.UpdateDiscount(roleId, rate);
        }

        public static int DeleteDiscount(int userId)
        {
            return DiscountDAO.DeleteDiscount(userId);
        }
    }
}
