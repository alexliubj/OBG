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
    int userId;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        //for test purpose
        Session["userId"] = 1;

        if (Session["userId"] != null)
        {
            userId = (int)Session["userId"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        String newPassword = ChangeUserPassword.NewPassword;
        bool resetPassword = UserBLO.ResetPassword(userId,newPassword);

        if (resetPassword == true)
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
