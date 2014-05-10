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
    int userID;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        //for test purpose
        Session["userID"] = 1;

        if (Session["userID"] != null)
        {
            userID = (int)Session["userID"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        String newPassword = ChangeUserPassword.NewPassword;
        int resetPassword = UserBLO.ResetPassword(userID,newPassword);

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
}
