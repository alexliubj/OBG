using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public static class CategoryBLO
    {
        public static List<Category> GetAllCategory()
        {
            return CategoryDAO.GetAllCategory();
        }

        public static bool ModifyCategoryNameById(int categoryId)
        {
            return CategoryDAO.ModifyCategoryNameById(categoryId);
        }

        public static bool AddNewCategory(string categoryName)
        {
            return CategoryDAO.AddNewCategory(categoryName);
        }

        public static bool RemoveCategoryById(int categoryId)
        {
            return CategoryDAO.RemoveCategoryById(categoryId);
        }
    }
}
