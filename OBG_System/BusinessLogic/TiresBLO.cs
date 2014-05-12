﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class TiresBLO
    {
        public static DataTable GetAllTires()
        {
            return TiresDAO.GetAllTires();
        }

        public static int CreateNewTire(Tire tire)
        {
            return TiresDAO.CreateNewTire(tire);
        }

        public static int DeleteTire(int tireId)
        {
            return TiresDAO.DeleteTire(tireId);
        }

        public static int UpdateTire(Tire tire)
        {
            return TiresDAO.UpdateTire(tire);
        }
    }
}