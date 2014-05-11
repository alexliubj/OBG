#pragma checksum "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\Register.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D1B8A1DD5F115CFCAD8BF535C82D7E6FD179B6B"

#line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Account\Register.aspx.cs"
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
        
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //if (String.IsNullOrEmpty(continueUrl))
        //{
        //    continueUrl = "~/Account/RegisterSuccess.aspx";
        //}
        //Response.Redirect(continueUrl);
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
       // User newUser = new User();
       // TextBox UserNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
       // TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
       // TextBox PasswordTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
       // TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
       // TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
       // TextBox CompanyTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Company");
       // TextBox PhoneTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Phone");
       // TextBox ShippingAddressTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ShippingAddress");
       // TextBox ShippingPostCodeTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ShippingPostCode");
       // newUser.UserName = UserNameTextBox.Text;
       // newUser.Userpwd = PasswordTextBox.Text;
       // newUser.CompanyName = CompanyTextBox.Text;
       // newUser.Phone = PhoneTextBox.Text;
       // newUser.ShippingAddress = ShippingAddressTextBox.Text;
       // newUser.ShippingPostCode = ShippingPostCodeTextBox.Text;
       // newUser.FirstName = FirstNameTextBox.Text;
       // newUser.LastName = LastNameTextBox.Text;
       // newUser.Email = EmailTextBox.Text;

       //int effectedRow = UserBLO.Registration(newUser);

       //if (effectedRow == 1)
       //{
       //    Response.Redirect("~/Account/RegisterSuccess.aspx");
       //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
       //                 "err_msg",
       //                 "alert('success.');", true);
       //}
        
    }
   
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Account/RegisterSuccess.aspx");
    //}
    protected void btnCreate_Click(object sender, EventArgs e)
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

        int newId = UserBLO.Registration(newUser);

        if (newId > 0 && RoleBLO.AddUserToRole(newId, 1) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                            "err_msg",
                            "alert('success.');", true);
            Response.Redirect("~/Account/RegisterSuccess.aspx");
            
            //add To role
            
        }
    }
}


#line default
#line hidden
