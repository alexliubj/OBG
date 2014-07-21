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
        if (Session["userID"] != null)
        {
            int userID = (int)Session["userID"];
            String userName = null;
            User user = new User();
            user = UserBLO.GetUserInfoWithUserId(userID);
            userName = user.UserName;
            btnLogin.Text = "Log Out";
            lblWelcome.Text = "Welcome back, " + userName + "!";
        }
        else
        {
            btnLogin.Text = "Log In";
            lblWelcome.Text = "Welcome, please ";
        }

        foreach (MenuItem item in NavigationMenu.Items)
        {
            string tempString = Request.Url.AbsoluteUri.ToLower();
            string itemValue = item.Value;
            if (Request.Url.AbsoluteUri.ToLower().Contains(item.Value.ToLower()))
            {

                item.Selectable = false;
                //  item.Selected
            }
            else
            {
                item.Selectable = true;

            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (btnLogin.Text == "Log Out")
        {
            Session.Clear();
            Response.Redirect("~/Account/Login.aspx");
        }
        else if (btnLogin.Text == "Log In")
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

}
