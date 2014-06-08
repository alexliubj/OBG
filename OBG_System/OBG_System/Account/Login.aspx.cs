using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    User newUser = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string account = LoginUser.UserName;

        newUser.Userpwd = LoginUser.Password;

        if (ValidationUtility.IsEmailAddress(account))
        {
            newUser.Email = account;
            LoginRet emailLogin = UserBLO.ClientEmailLogin(newUser.Email, newUser.Userpwd);
            if (emailLogin.UserId > 0)
            {
                //check status 
                if (emailLogin.Us == LoginRet.UserStatus.active) //active
                {
                    Session["UserID"] = emailLogin.UserId;
                   // Session["login"] = true;
                    Session["Role"] = emailLogin.Rs;

                    //if (LoginUser.RememberMeSet)
                    //{
                    //    // Clear any other tickets that are already in the response
                    //    Response.Cookies.Clear();

                    //    // Set the new expiry date - to thirty days from now
                    //    DateTime expiryDate = DateTime.Now.AddDays(30);

                    //    // Create a new forms auth ticket
                    //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, LoginUser.UserName, DateTime.Now, expiryDate, true, String.Empty);

                    //    // Encrypt the ticket
                    //    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    //    // Create a new authentication cookie - and set its expiration date
                    //    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    //    authenticationCookie.Expires = ticket.Expiration;

                    //    // Add the cookie to the response.
                    //    Response.Cookies.Add(authenticationCookie);
                    //}

                    Response.Redirect("~/Default.aspx");
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
        else
        {
            newUser.UserName = account;
            LoginRet userLogin = UserBLO.ClientLogin(newUser.UserName, newUser.Userpwd);

            if (userLogin.UserId > 0)
            {
                //check status 
                if (userLogin.Us == LoginRet.UserStatus.active) //active
                {
                    Session["UserID"] = userLogin.UserId;
                    //Session["login"] = true;
                    Session["Role"] = userLogin.Rs;

                    //if (LoginUser.RememberMeSet)
                    //{
                    //    // Clear any other tickets that are already in the response
                    //    Response.Cookies.Clear();

                    //    // Set the new expiry date - to thirty days from now
                    //    DateTime expiryDate = DateTime.Now.AddDays(30);

                    //    // Create a new forms auth ticket
                    //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, LoginUser.UserName, DateTime.Now, expiryDate, true, String.Empty);

                    //    // Encrypt the ticket
                    //    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    //    // Create a new authentication cookie - and set its expiration date
                    //    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    //    authenticationCookie.Expires = ticket.Expiration;

                    //    // Add the cookie to the response.
                    //    Response.Cookies.Add(authenticationCookie);
                    //}

                    Response.Redirect("~/Default.aspx");
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
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {

    }
}
