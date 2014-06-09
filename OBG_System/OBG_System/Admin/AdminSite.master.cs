using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            int adminID = (int)Session["AdminID"];
            String userName = null;
            User user = new User();
            user = UserBLO.GetUserInfoWithUserId(adminID);
            userName = user.UserName;
            btnLogin.Text = "Log Out";
            lblWelcome.Text = "Welcome back, " + userName + "!";
        }
        else
        {
            btnLogin.Text = "Log In";
            lblWelcome.Text = "Welcome, please ";
        }

        MenuItem ms = NavigationMenu.FindItem(Page.Header.Title);
        if (ms != null)
        {
            ms.Selectable = false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (btnLogin.Text == "Log Out")
        {
            Session.Clear();
            Response.Redirect("~/Admin/Login.aspx");
        }
        else if (btnLogin.Text == "Log In")
        {
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}
