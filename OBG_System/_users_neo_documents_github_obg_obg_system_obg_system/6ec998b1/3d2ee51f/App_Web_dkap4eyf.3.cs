#pragma checksum "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\Login.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76CFDC5F21F42AE3DCB64036F4D169982ADA20B3"

#line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\Login.aspx.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;

public partial class Account_Login : System.Web.UI.Page
{
    User newUser = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        newUser.UserName = LoginUser.UserName;
        newUser.Userpwd = LoginUser.Password;
        LoginRet userlogin = UserBLO.ClientLogin(newUser.UserName, newUser.Userpwd);

        if (userlogin.UserId > 0)
        {
            //check status 
            if (userlogin.Us == LoginRet.UserStatus.active) //active
            {
                Session["userID"] = userlogin.UserId;
                Session["login"] = true;

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                             "err_msg",
                             "alert('success.');",
                             true);
                Response.Redirect("~/Default.aspx");
            }
            else //inactive
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('wrong.');", true);
            }
           
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('wrong.');", true);
        }
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e) 
    {
        
    }
}


#line default
#line hidden
