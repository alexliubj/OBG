using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Web.Security;

public partial class Admin_Default : System.Web.UI.Page
{
    User newUser = new User();
    int adminID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            adminID = (int)Session["AdminID"];
            Response.Redirect("~/Admin/Home.aspx");
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string account = LoginAdmin.UserName;

        newUser.Userpwd = LoginAdmin.Password;

        //if (ValidationUtility.IsEmailAddress(account))
        //{
        //    newUser.Email = account;
        //    LoginRet emailLogin = UserBLO.ClientEmailLogin(newUser.Email, newUser.Userpwd);
        //    if (emailLogin.UserId > 0)
        //    {
        //        //check status 
        //        if (emailLogin.Us == LoginRet.UserStatus.active) //active
        //        {
        //            Session["UserID"] = emailLogin.UserId;
        //           // Session["login"] = true;
        //            Session["Role"] = emailLogin.Rs;

        //            if (LoginAdmin.RememberMeSet)
        //            {
        //                // Clear any other tickets that are already in the response
        //                Response.Cookies.Clear();

        //                // Set the new expiry date - to thirty days from now
        //                DateTime expiryDate = DateTime.Now.AddDays(30);

        //                // Create a new forms auth ticket
        //                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, LoginAdmin.UserName, DateTime.Now, expiryDate, true, String.Empty);

        //                // Encrypt the ticket
        //                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

        //                // Create a new authentication cookie - and set its expiration date
        //                HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        //                authenticationCookie.Expires = ticket.Expiration;

        //                // Add the cookie to the response.
        //                Response.Cookies.Add(authenticationCookie);
        //            }

        //            Response.Redirect("~/Default.aspx");
        //        }
        //        else //inactive
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        //                                   "err_msg",
        //                                   "alert('Sorry, Your account is not actived yet.');", true);
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        //                    "err_msg",
        //                    "alert('Invalid log in or server error. Please try again.');", true);
        //    }
        //}
        newUser.UserName = account;
        LoginRet userLogin = UserBLO.AdminLogin(newUser.UserName, newUser.Userpwd);

        if (userLogin.UserId > 0)
        {
            //check status 
            if (userLogin.Us == LoginRet.UserStatus.active) //active
            {
                Session["AdminID"] = userLogin.UserId;
                //Session["login"] = true;
                Session["Role"] = userLogin.Rs;

                if (LoginAdmin.RememberMeSet)
                {
                    // Clear any other tickets that are already in the response
                    Response.Cookies.Clear();

                    // Set the new expiry date - to thirty days from now
                    DateTime expiryDate = DateTime.Now.AddDays(30);

                    // Create a new forms auth ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, LoginAdmin.UserName, DateTime.Now, expiryDate, true, String.Empty);

                    // Encrypt the ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    // Create a new authentication cookie - and set its expiration date
                    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    authenticationCookie.Expires = ticket.Expiration;

                    // Add the cookie to the response.
                    Response.Cookies.Add(authenticationCookie);
                }

                Response.Redirect("~/Admin/Home.aspx");
            }
            else //inactive
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('Sorry, Your account is not actived yet.');", true);
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
