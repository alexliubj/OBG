using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Web.Security;
using DataAccess;

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
        string account = UserName.Text.ToString().Trim();

        newUser.Userpwd = Password.Text.ToString().Trim();

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

                string IP = IPUtility.GetIPAddress();
                IPAddress.UpdateIpAddress(IP, userLogin.UserId);
                IPAddress.UpdateLoginTimes(userLogin.UserId);

                if (RememberMe.Checked == true)
                {
                    // Clear any other tickets that are already in the response
                    Response.Cookies.Clear();

                    // Set the new expiry date - to thirty days from now
                    DateTime expiryDate = DateTime.Now.AddDays(30);

                    // Create a new forms auth ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, account, DateTime.Now, expiryDate, true, String.Empty);

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
                                       "alert('Sorry, This account is currently not active.');", true);
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
