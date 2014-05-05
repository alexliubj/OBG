using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using OBGModel;

namespace BusinessLogic
{
    public static class ProductBLO
    {
        public static List<Product> GetAllProducts()
        {
            return ProductDAO.GetAllProducts();
        }

        public static bool DeleteProductById(int prodId)
        {
            return ProductDAO.DeleteProductById(prodId);
        }

        public static bool UpdateProduct(Product prod)
        {
            return ProductDAO.UpdateProduct(prod);
        }

        public static bool AddNewProduct(Product prod)
        {
            return ProductDAO.AddNewProduct(prod);
        }
    }
}
