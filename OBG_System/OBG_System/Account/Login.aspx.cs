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
               // Session["userID"] = ((TextBox)(LoginUser.FindControl("UserName"))).Text;
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
                                       "alert('Sorry, Your account is not actived yet!');", true);
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
