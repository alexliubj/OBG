using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class CategoryDAO
    {
        public static List<Category> GetAllCategory()
        {
            List<Category> listCategory = new List<Category>();
            return listCategory;
        }

        public static bool ModifyCategoryNameById(int categoryId)
        {
            bool ret = false;
            return ret;
        }

        public static bool AddNewCategory(string categoryName)
        {

            bool ret = false;
            return ret;
        }

        public static bool RemoveCategoryById(int categoryId)
        {
            bool ret = false;
            return ret;
        }
    }
}
