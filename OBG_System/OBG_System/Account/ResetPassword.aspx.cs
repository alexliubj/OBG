using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;

public partial class Account_ResetPassword : System.Web.UI.Page
{
    string securityKey = null;
    string email = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["email"] != null)
        {
            email = Request.QueryString["email"].ToString();

            if (Request.QueryString["securityKey"] != null)
            {
                securityKey = Request.QueryString["securityKey"].ToString();

                if (UserBLO.ValideCheckRequest(email, securityKey) > 0)
                {
                    changePasswordDiv.Visible = true;
                    errorDiv.Visible = false;
                }
                else
                {
                    changePasswordDiv.Visible = false;
                    errorDiv.Visible = true;
                }
            }
            else
            {
                changePasswordDiv.Visible = false;
                errorDiv.Visible = true;
            }
        }
        else
        {
            changePasswordDiv.Visible = false;
            errorDiv.Visible = true;
        }

        if (!IsPostBack)
        {

        }
    }
    protected void ConfrimButton_Click1(object sender, EventArgs e)
    {

        string password = NewPassword.Text.ToString().Trim();

        UserBLO.ResetPassword(email, password);
        Response.Write("<script>alert('Your password has been reset！');window.location.href='../login.aspx';</script>");

    }
}