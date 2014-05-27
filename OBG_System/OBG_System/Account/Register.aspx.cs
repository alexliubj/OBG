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
        newUser.ShippingHouseNo = ShippingAddress.Text;
        newUser.ShippingPostCode = ShippingPostCode.Text;
        newUser.FirstName = FirstName.Text;
        newUser.LastName = LastName.Text;
        newUser.Email = Email.Text;
        newUser.BillingHouseNo = string.Empty;
        newUser.BillPostCode = string.Empty;
        newUser.BillingCity = string.Empty;
        newUser.BillingProvince = string.Empty;
        newUser.BillingStreet = string.Empty;
        newUser.IsSameAddress = false;
        newUser.RegionId = 0;
        newUser.ShippingCity = string.Empty;
        newUser.ShippingProvince = string.Empty;
        newUser.ShippingStreet = string.Empty;

        int newId = UserBLO.Registration(newUser);

        if (newId > 0)
        {
            Response.Redirect("~/Account/RegisterSuccess.aspx");
        }
        else if (newId <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('Registration failed.');", true);
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
