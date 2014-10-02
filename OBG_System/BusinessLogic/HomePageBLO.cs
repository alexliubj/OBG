using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public class HomePageBLO
    {
        public static int UpdateImages(HomeImage hi)
        {
            return HomePageDAO.UpdateImages(hi);
        }

        public static int UpdateReturnPolicy(ReturnPolicy retp)
        {
            return HomePageDAO.UpdateReturnPolicy(retp);
        }

        public static ReturnPolicy GetReturnPolicy()
        {
            return HomePageDAO.GetReturnPolicy();
        }
        public static List<HomeImage> GetHomePageInformation()
        {
            return HomePageDAO.GetHomePageInformation();
        }

        public static int InsertImages(HomeImage hi)
        {
            return HomePageDAO.InsertImages(hi);
        }

        public static int DeleteImages(int imageID)
        {
            return HomePageDAO.DeleteImages(imageID);
        }
                
    }
}
