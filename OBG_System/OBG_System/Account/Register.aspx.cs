using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;



public partial class Account_Register : System.Web.UI.Page
{
    User newUser = new User();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {

    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {

        newUser.UserName = UserName.Text;
        newUser.Userpwd = Password.Text;
        newUser.CompanyName = Company.Text;
        newUser.Phone = Phone.Text;
        newUser.ShippingAddress = ShippingAddress.Text;
        newUser.ShippingPostCode = ShippingPostCode.Text;
        newUser.FirstName = FirstName.Text;
        newUser.LastName = LastName.Text;
        newUser.Email = Email.Text;

        int newId = UserBLO.Registration(newUser);

        if (newId > 0 && RoleBLO.AddUserToRole(newId, 1, "des") > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                            "err_msg",
                            "alert('success.');", true);
            Response.Redirect("~/Account/RegisterSuccess.aspx");

            //add To role

        }
    }

    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        string userName = UserName.Text;

        if (UserBLO.CheckUserNameExists(userName))
        {
            UserName.Focus();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                     "err_msg",
                     "alert('Sorry, the user name has been used by other user.');", true);
        }
        else
        {
            Email.Focus();
        }
    }

    protected void Email_TextChanged(object sender, EventArgs e)
    {
        string email = Email.Text;

        if (UserBLO.CheckEmailExists(email))
        {
            Email.Focus();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Sorry, the email has been used by other user.');", true);
        }
        else
        {
            Password.Focus();
        }
    }
}
