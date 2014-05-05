using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class ProductDAO
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> listProduct = new List<Product>();
            return listProduct;
        }

        public static bool DeleteProductById(int prodId)
        {
            return true;
        }

        public static bool UpdateProduct(Product prod)
        {
            return true;
        }

        public static bool AddNewProduct(Product prod)
        {
            return true;
        }
    }
}
