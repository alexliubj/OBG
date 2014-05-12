﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class AccessoryBLO
    {
        public static DataTable GetAllAccessories()
        {
            return AccessoriesDAO.GetAllAccessories();
        }

        public static int UpdateAccessory(Accessories acc)
        {
            return AccessoriesDAO.UpdateAccessory(acc);
        }

        public static int CreateNewAccessory(Accessories acc)
        {
            return AccessoriesDAO.CreateNewAccessory(acc);
        }

        public static int DeleteOneAccessory(int accId)
        {
            return AccessoriesDAO.DeleteOneAccessory(accId);
        }
    }
}