using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.Common;

namespace DataAccess
{
    public static class CategoryDAO
    {
        private static DbHelper db = new DbHelper();
        public static DataTable GetAllCategory()
        {
            DbCommand command = db.GetSqlStringCommond("select * from category");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int ModifyCategoryNameById(int categoryId, string newName)
        {
            DbCommand command = db.GetSqlStringCommond("update category set categoryName = '" + newName + "' where categoryId=" + categoryId);
            return db.ExecuteNonQuery(command);
        }

        public static int AddNewCategory(string categoryName)
        {
            DbCommand command = db.GetSqlStringCommond("insert into category(categoryName) values ('" + categoryName + "')");
            return db.ExecuteNonQuery(command);
        }

        public static int RemoveCategoryById(int categoryId)
        {
            DbCommand command = db.GetSqlStringCommond("delete from category where categoryId = " + categoryId);
            return db.ExecuteNonQuery(command);
        }
    }
}
