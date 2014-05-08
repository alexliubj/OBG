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


    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["~/Account/RegisterSuccess.aspx"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        Response.Redirect(continueUrl);
    }
    //跳转有问题
    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        User newUser = new User();
        TextBox UserNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
        TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
        TextBox PasswordTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
        TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
        TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
        TextBox CompanyTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Company");
        TextBox PhoneTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Phone");
        TextBox ShippingAddressTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ShippingAddress");
        TextBox ShippingPostCodeTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ShippingPostCode");
        newUser.UserName = UserNameTextBox.Text;
        newUser.Userpwd = PasswordTextBox.Text;
        newUser.CompanyName = CompanyTextBox.Text;
        newUser.Phone = PhoneTextBox.Text;
        newUser.ShippingAddress = ShippingAddressTextBox.Text;
        newUser.ShippingPostCode = ShippingPostCodeTextBox.Text;
        newUser.FirstName = FirstNameTextBox.Text;
        newUser.LastName = LastNameTextBox.Text;
        newUser.Email = EmailTextBox.Text;

       UserBLO.Registration(newUser);
       
        Response.Redirect("~/Account/RegisterSuccess.aspx");
    }
    //这个BUTTON可以跳转
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/RegisterSuccess.aspx");
    }
}
