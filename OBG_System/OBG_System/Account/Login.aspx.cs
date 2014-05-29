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
        LoginRet userLogin = UserBLO.ClientLogin(newUser.UserName, newUser.Userpwd);

        if (userLogin.UserId > 0)
        {
            //check status 
            if (userLogin.Us == LoginRet.UserStatus.active) //active
            {
                Session["userID"] = userLogin.UserId;
                Session["login"] = true;
                Session["role"] = userLogin.Rs;

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                             "err_msg",
                             "alert('Login Success.');",
                             true);
                Response.Redirect("~/Default.aspx");
            }
            else //inactive
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('Sorry, Your account is not actived yet.');", true);
            }
        }
        else if (newUser.UserName.Contains("@"))
        {
            
            newUser.Email = LoginUser.UserName;
            LoginRet emailLogin = UserBLO.ClientEmailLogin(newUser.Email, newUser.Userpwd);
            if (emailLogin.UserId > 0)
            {
                //check status 
                if (emailLogin.Us == LoginRet.UserStatus.active) //active
                {
                    Session["userID"] = emailLogin.UserId;
                    Session["login"] = true;
                    Session["role"] = emailLogin.Rs;

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                 "err_msg",
                                 "alert('Login Success.');",
                                 true);
                    Response.Redirect("~/Default.aspx");
                }
                else //inactive
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                           "err_msg",
                                           "alert('Sorry, Your account is not actived yet.');", true);
                }
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Invalid log in or server error. Please try again.');", true);
        }
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {

    }
}
