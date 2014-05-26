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

        public static HomeImage GetHomePageInformation()
        {
            return HomePageDAO.GetHomePageInformation();
        }
    }
}
