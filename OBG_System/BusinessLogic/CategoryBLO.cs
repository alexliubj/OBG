using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public static class CategoryBLO
    {
        public static DataTable GetAllCategory()
        {
            return CategoryDAO.GetAllCategory();
        }

        public static int ModifyCategoryNameById(int categoryId, string newName)
        {
            return CategoryDAO.ModifyCategoryNameById(categoryId, newName);
        }

        public static int AddNewCategory(string categoryName)
        {
            return CategoryDAO.AddNewCategory(categoryName);
        }

        public static int RemoveCategoryById(int categoryId)
        {
            return CategoryDAO.RemoveCategoryById(categoryId);
        }
    }
}
