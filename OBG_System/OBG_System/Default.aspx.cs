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
        TestSQLQueries();
    }

    private void TestSQLQueries()
    {
        //cateogry
        DataTable cateogrydt = CategoryBLO.GetAllCategory();
        int ret = CategoryBLO.AddNewCategory("newcategoty");
        ret = CategoryBLO.ModifyCategoryNameById(2, "oldcategory");
        ret = CategoryBLO.RemoveCategoryById(2);
       
        //user
        //common user login
        int cLogin = UserBLO.ClientLogin(@"username", @"password");
        //admin user login
        int login = UserBLO.AdminLogin(@"username", @"password");
        
        User aUser =new User();
        //active a user
        ret = UserBLO.AdminActiveUser(2);
        //registration
        ret = UserBLO.Registration(aUser);
        //forget password
        ret = UserBLO.ForgetPasswordRequest(@"alexliubo@gmail.com");
        //update user info
        ret = UserBLO.UpdateUserInfo(aUser);
        //delete user
        ret = UserBLO.RemoveUserById(2);
        //get all user
        DataTable dt = UserBLO.GetAllUsers();
        //reset password
        ret = UserBLO.ResetPassword(2, @"newpassowrd");
        //validate user information

        ret = UserBLO.ValideCheckRequest(@"emai", @"key");
    }
}
