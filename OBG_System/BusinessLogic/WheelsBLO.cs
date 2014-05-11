using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using OBGModel;
using DataAccess;
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

        public static int UpdateProduct(Wheels prod)
        {
            return WheelsDAO.UpdateProduct(prod);
        }

        public static int AddNewProduct(Wheels prod)
        {
            return WheelsDAO.AddNewProduct(prod);
        }
    }
}
