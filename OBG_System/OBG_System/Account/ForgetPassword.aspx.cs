using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessLogic;
using OBGModel;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {

        if (ValidationUtility.IsEmailAddress(EmailAddress.Text.ToString().Trim()))
        {
            string email = EmailAddress.Text.ToString().Trim();
            int userID = 0;
            string securityKey = "";

            userID = UserBLO.GetUserIDByEmail(email);
            if (userID <= 0)
            {
                EmailAddress.Text = " ";
                FailureText.Text = "The Entered Email Address is wrong, this address is not registered yet.";
            }
            else
            {
                securityKey = UserBLO.ForgetPasswordRequest(email);
                if (securityKey != "")
                {
                    if (SendMail(email, securityKey))
                    {
                        FailureText.Text = "Request has been recieved, please login your email to finish the process";
                    }
                    else
                    {
                        EmailAddress.Text = " ";
                        FailureText.Text = "Sending email failed";
                    }
                }
                else
                {
                    EmailAddress.Text = " ";
                    FailureText.Text = "Password reset request failed";
                }
            }
        }
        else
        {
            EmailAddress.Text = " ";
            FailureText.Text = "Please enter a valid e-mail";
        }
    }


    #region 找回密码
    ///<summary>
    /// 功能：用户找回密码
    ///</summary>
    ///<param name="ToEmail">目的地地址</param>
    ///<param name="memberid">会员ID</param>
    ///<returns></returns>
    public bool SendMail(string ToEmail, string securityKey)
    {
        string Email = "alexliu0506@126.com";
        string password = "5631247";
        Encoding EnCode = Encoding.UTF8;
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        Message.From = new MailAddress(Email, "OBG Master", EnCode);
        Message.To.Add(new MailAddress(ToEmail, "Dear Customer", EnCode));
        Message.Subject = "Reset Password Request";
        Message.SubjectEncoding = EnCode;
 
        StringBuilder MailContent = new StringBuilder();
        MailContent.Append("Dear Customer：<br/>");
        MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At ");
        MailContent.Append(DateTime.Now.ToLongTimeString());
        string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have requested forget password at <a href='" + host + "'>OBG Order System</a>.");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For security purpose，please click the link below to reset your password：");

        
        string url = host + "Account/ResetPassword.aspx?securityKey=" + securityKey + "&email=" + ToEmail;
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='" + url + "'>" + url + "</a>");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If you did not request a password reset you do not need to take any action.</p>");
        Message.Body = MailContent.ToString();
        Message.BodyEncoding = EnCode;
        Message.IsBodyHtml = true;

        try
        {
            SmtpClient smtp = new SmtpClient("smtp.126.com", 25);
            smtp.Credentials = new NetworkCredential(Email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(Message);
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            Message.Dispose();
        }
        return true;
    }
    #endregion
}