using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using OBGModel;
using System.Data;
namespace BusinessLogic
{
    public static class ProductBLO
    {
        public static DataTable GetAllProducts()
        {
            return ProductDAO.GetAllProducts();
        }

        public static int DeleteProductById(int prodId)
        {
            return ProductDAO.DeleteProductById(prodId);
        }

        public static int UpdateProduct(Product prod)
        {
            return ProductDAO.UpdateProduct(prod);
        }

        public static int AddNewProduct(Product prod)
        {
            return ProductDAO.AddNewProduct(prod);
        }
    }
}
