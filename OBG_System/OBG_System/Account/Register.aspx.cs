using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Text;
using System.Net.Mail;
using System.Net;



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
        SendMail(newUser.UserName);


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

    public bool SendMail(string name)
    {
        //MailMessage myMail = new MailMessage();
        //myMail.From = new MailAddress("317844956@qq.com");
        //myMail.To.Add(new MailAddress(""));
        //myMail.Subject = "C#发送Email";
        //myMail.SubjectEncoding = Encoding.UTF8;
        //myMail.Body = "this is a test email from QQ!";
        //myMail.BodyEncoding = Encoding.UTF8;
        //myMail.IsBodyHtml = true;
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.qq.com";
        //smtp.Credentials = new NetworkCredential("", "123456");
        //smtp.Send(myMail);
        //return true;


        //string Email = "alexliu0506@126.com";
        //string Email = "holmeslixu@gmail.com";
        string Email = "orders@optiwheels.ca";
        string password = "orders12345";
        string totoEmail = "min@optiwheels.ca";
        //string password = "5631247";
        //string password = "holmes615";
        Encoding EnCode = Encoding.UTF8;
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        Message.From = new MailAddress(Email, "OBG Master", EnCode);
        //Message.To.Add(new MailAddress(ToEmail, "Dear Customer", EnCode));
        Message.To.Add(new MailAddress(totoEmail, "Dear Admin"));
        Message.Subject = "New customer join ";
        Message.SubjectEncoding = EnCode;

        StringBuilder MailContent = new StringBuilder();
        string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/");
        MailContent.Append("Dear Customer：<br/>");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+ name +"is waiting for your activation! ");
        //MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At ");
        //MailContent.Append(DateTime.Now.ToLongTimeString());

        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have ordered products at <a href='" + host + "'>OBG Order System</a>.");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To check the status of your order, please see your order history: ");
        //MailContent.Append("<br/>Here are your order details: ");
        //MailContent.Append(CKGridView);

        //string url = host + "Account/UserOrderHistory.aspx";
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='" + url + "'>" + url + "</a>");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can modify your order before shipping.</p>");


        Message.Body = MailContent.ToString();
        Message.BodyEncoding = EnCode;
        Message.IsBodyHtml = true;

        try
        {
            //SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587);
            //SmtpClient smtp = new SmtpClient("smtp.qq.com", 25);
            SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            //smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(Email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(Message);

        }
        catch (SmtpException ex)
        {
            string msg = "Mail cannot be sent because of the server problem:";
            msg += ex.Message;
            Label7.Text = msg;
            return false;
        }
        return true;
    }
}
