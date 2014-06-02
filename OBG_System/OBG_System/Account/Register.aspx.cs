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
        newUser.CompanyName = Company.Text.ToString().Trim();
        newUser.Phone = Phone.Text.ToString().Trim();
        newUser.ShippingHouseNo = ShippingHouseNo.Text.ToString().Trim();
        newUser.ShippingPostCode = ShippingPostCode.Text.ToString().Trim();
        newUser.ShippingCity = ShippingCity.Text.ToString().Trim();
        newUser.ShippingProvince = ShippingPro.SelectedValue;
        newUser.ShippingStreet = ShippingStreet.Text.ToString().Trim();
        newUser.FirstName = FirstName.Text.ToString().Trim();
        newUser.LastName = LastName.Text.ToString().Trim();
        newUser.Email = Email.Text.ToString().Trim();
        newUser.BillingHouseNo = BillingHouseNo.Text.ToString().Trim();
        newUser.BillPostCode = BillingPostCode.Text.ToString().Trim();
        newUser.BillingCity = BillingCity.Text.ToString().Trim();
        newUser.BillingProvince = BillingPro.SelectedValue;
        newUser.BillingStreet = BillingStreet.Text.ToString().Trim();
        //need change later
        newUser.IsSameAddress = false;
        newUser.RegionId = 1;
        //

        int newId = UserBLO.Registration(newUser);

        if (newId > 0)
        {
            Response.Redirect("~/Account/RegisterSuccess.aspx");
        }
        else
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
                     "alert('Username already exists.\\nPlease choose a different username.');", true);
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
                      "alert('Supplied email address has already been used.');", true);
        }
        else
        {
            Password.Focus();
        }
    }
    protected void CheckBoxIsSameAddress_Clicked(Object sender, EventArgs e)
    {
        if (checkBoxIsSameAddress.Checked == true)
        {
            BillingHouseNo.Text = ShippingHouseNo.Text.ToString().Trim();
            BillingPostCode.Text = ShippingPostCode.Text.ToString().Trim();
            BillingCity.Text = ShippingCity.Text.ToString().Trim();
            BillingPro.SelectedValue = ShippingPro.SelectedValue;
            BillingStreet.Text = ShippingStreet.Text.ToString().Trim();
            //billingAddressDiv.Visible = false;
        }
        else if (checkBoxIsSameAddress.Checked == false)
        {
            BillingHouseNo.Text = null;
            BillingPostCode.Text = null;
            BillingCity.Text = null;
            BillingPro.SelectedValue = "";
            BillingStreet.Text = null;
            billingAddressDiv.Visible = true;
        }
    }
}
