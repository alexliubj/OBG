#pragma checksum "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\ChangePassword.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B01087724BD78AB764FD2A5052086650AFDA8068"

#line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\ChangePassword.aspx.cs"
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
       // Session["userID"] = 1;

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


#line default
#line hidden
