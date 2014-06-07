using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using OBGModel;
using System.Data;
namespace BusinessLogic
{
    public static class WheelsBLO
    {
        public static DataTable GetAllProducts()
        {
            return WheelsDAO.GetAllProducts();
        }

        public static int DeleteProductById(int prodId)
        {
            return WheelsDAO.DeleteProductById(prodId);
        }

        public static int UpdateProduct(Wheels prod, List<Vehicle> vehicles)
        {
            return WheelsDAO.UpdateProduct(prod,vehicles);
        }

        public static int AddNewProduct(Wheels prod, List<Vehicle> vehicles)
        {
            return WheelsDAO.AddNewProduct(prod,vehicles);
        }

        public static DataTable GetAllWheelsVehiclesByWheelsId(int wheelsId)
        {
            return WheelsDAO.GetAllWheelsVehiclesByWheelsId(wheelsId);
        }

        public static DataTable GetAllWheelsVehicles()
        {
            return WheelsDAO.GetAllWheelsVehicles();
        }

        public static DataTable GetAllWheelsVehicles()
        {
            return WheelsDAO.GetAllWheelsVehicles();
        }
    }
}
