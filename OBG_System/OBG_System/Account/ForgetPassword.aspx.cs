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
    //protected void PasswordRecovery1_VerifyingUser(object sender, LoginCancelEventArgs e)
    //{
    //    ////need getUserNamebyEmail
    //    ////PasswordRecovery1.UserName = Membership.GetUserNameByEmail(PasswordRecovery1.UserName);
    //    //if (PasswordRecovery1.UserName == null || PasswordRecovery1.UserName.Length == 0)
    //    //{
    //    //    PasswordRecovery1.UserNameInstructionText = "The Entered Email Address is wrong, this address is not registered yet.";
    //    //    e.Cancel = true;
    //    //}

    //}

    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        e.Cancel = true;
    }

    protected void PasswordRecovery1_VerifyingUser(object sender, LoginCancelEventArgs e)
    {
        if (ValidationUtility.IsEmailAddress(PasswordRecovery1.UserName))
        {
            string email = PasswordRecovery1.UserName.ToString().Trim();
            int userID = 0;
            string securityKey = "";

            userID = UserBLO.GetUserIDByEmail(email);
            if (userID <= 0)
            {
                PasswordRecovery1.UserName = " ";
                PasswordRecovery1.UserNameFailureText = "The Entered Email Address is wrong, this address is not registered yet.";
            }
            else
            {
                securityKey = UserBLO.ForgetPasswordRequest(email);
                if (securityKey != "")
                {
                    if (SendMail(email, securityKey))
                    {
                        PasswordRecovery1.UserNameFailureText = "Request has been recieved, please login your email to finish the process";
                    }
                    else
                    {
                        PasswordRecovery1.UserName = " ";
                        PasswordRecovery1.UserNameFailureText = "Sending email failed";
                    }
                }
                else
                {
                    PasswordRecovery1.UserName = " ";
                    PasswordRecovery1.UserNameFailureText = "Password reset request failed";
                }
            }
        }
        else
        {
            PasswordRecovery1.UserName = " ";
            PasswordRecovery1.UserNameFailureText = "Please enter a valid e-mail";
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
        string Email = "noreply@centennialsoft.ca ";
        string password = "obgtest";
        Encoding EnCode = Encoding.UTF8;
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        Message.From = new MailAddress(Email, "OBG Master", EnCode);
        Message.To.Add(new MailAddress(ToEmail, "Dear Customer", EnCode));
        Message.Subject = "Reset Password Request";
        Message.SubjectEncoding = EnCode;
 
        StringBuilder MailContent = new StringBuilder();
        MailContent.Append("Dear Customer：<br/>");
        MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        MailContent.Append(DateTime.Now.ToLongTimeString());
        MailContent.Append("通过<a href='#'>新郑网购</a>管理中心审请找回密码。");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;为了安全起见，请用户点击以下链接重设个人密码：");
        string url = "http://obg.techbester.com/Account/ResetPassword.aspx?securityKey=" + securityKey + "&email=" + ToEmail;
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='" + url + "'>" + url + "</a>");
        Message.Body = MailContent.ToString();
        Message.BodyEncoding = EnCode;
        Message.IsBodyHtml = true;

        try
        {
            SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 80);
            smtp.Credentials = new NetworkCredential(Email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(Message);
        }
        catch (Exception e)
        {
            //this.RegisterClientScriptBlock("key", string.Format("alert('{0}');", e.Message));
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