using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    int userID = 0;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        String newPassword = NewPassword.Text.ToString().Trim();
        String oldPassword = CurrentPassword.Text.ToString().Trim();

        int resetPassword = UserBLO.UpdatePassword(oldPassword, newPassword, userID);

        if (resetPassword == 1)
        {
            Response.Redirect("~/Account/ChangePasswordSuccess.aspx");
        }

        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, reset password failed.');",
                        true);
        }
    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/UserCenter.aspx");
    }
}
