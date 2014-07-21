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

        public static int InsertImages(HomeImage hi)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [HomePage]
                                                           ([ImageUrl]
                                                           ,[ImageDes])
                                                     VALUES
                                                           (@image
                                                           ,@des)");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@image", hi.Image1),
                new SqlParameter("@des",hi.Des1)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteImages(int imageID)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete [HomePage] where [ImageID] = @imageID");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@imageID", imageID),
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateReturnPolicy(string policyString)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE ReturnPolicy
                                       SET [Policy] = @policy");

            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@policy", policyString)
            };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static string GetReturnPolicy()
        { 
            string retSTring = string.Empty;
            DbCommand command = db.GetSqlStringCommond("select policy from ReturnPolicy");
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    retSTring = reader.GetString(0);
                }
            }
            return retSTring;
        }


        public static List<HomeImage> GetHomePageInformation()
        {
            List<HomeImage> his = new List<HomeImage>();

            DbCommand command = db.GetSqlStringCommond("select [ImageID],[ImageUrl],[ImageDes] from [HomePage] order by [ImageID] DESC");
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    HomeImage hi = new HomeImage();
                    hi.ImageID = reader.GetInt32(0);
                    hi.Image1 = reader.GetString(1);
                    hi.Des1 = reader.GetString(2);
                    his.Add(hi);
                }
            }
            return his;
        }
    }
}
