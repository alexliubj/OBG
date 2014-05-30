using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // TestSQLQueries();
        Bind();
    }
    public void Bind()
    {
        HomeImage homeImage = HomePageBLO.GetHomePageInformation();
        Image1.ImageUrl = homeImage.Image1;
        Image2.ImageUrl = homeImage.Image2;
        Image1.ToolTip = homeImage.Des1;
        Image2.ToolTip = homeImage.Des2;
    }

    private void TestSQLQueries()
    {
        int ret = -1;
       
        //user
        //common user login
        LoginRet cLogin = UserBLO.ClientLogin(@"username", @"password");
        //admin user login
        LoginRet login = UserBLO.AdminLogin(@"username", @"password");
        
        User aUser =new User();
        //active a user
        ret = UserBLO.AdminActiveUserStatus(1, 2);
        //forget password
        ret = UserBLO.ForgetPasswordRequest(@"alexliubo@gmail.com");
        
        //delete user
        ret = UserBLO.RemoveUserById(2);
        //get all user
        DataTable dt = UserBLO.GetAllUsers();
        //reset password
       // ret = UserBLO.ResetPassword(2, @"newpassowrd");
        //validate user information
        ret = UserBLO.ValideCheckRequest(@"emai", @"key");
        //registration
        ret = UserBLO.Registration(aUser);
        //update user info
        ret = UserBLO.UpdateUserInfo(aUser);
        //cateogry
        DataTable cateogrydt = CategoryBLO.GetAllCategory();
        ret = CategoryBLO.AddNewCategory("newcategoty");
        ret = CategoryBLO.ModifyCategoryNameById(2, "oldcategory");
        ret = CategoryBLO.RemoveCategoryById(2);
    }
}
