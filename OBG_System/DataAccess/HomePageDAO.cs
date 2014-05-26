using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class HomePageDAO
    {
        private static DbHelper db = new DbHelper();

        //Default set 2 images;
        //Only can be update;
        //No delete, no insert methods;
        public static int UpdateImages(HomeImage hi)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [HomePage]
                                       SET [Image1] = @image1
                                          ,[Des1] = @des1
                                          ,[Image2] = @image2
                                          ,[Des2] = @des2");
                        
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@image1", hi.Image1),
                new SqlParameter("@des1",hi.Des1),
                new SqlParameter("@image2",hi.Image2),
                new SqlParameter("@des2",hi.Des2)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static HomeImage GetHomePageInformation()
        {
            HomeImage hi = new HomeImage();
            DbCommand command = db.GetSqlStringCommond(@"select image1,des1,image2,des2 from homepage;;");
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    hi.Image1 = reader.GetString(0);
                    hi.Image2 = reader.GetString(1);
                    hi.Des1 = reader.GetString(2);
                    hi.Des2 = reader.GetString(3);
                }
            }
            return hi;
        }
    }
}
