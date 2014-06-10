<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script runat="server">

        // Set the field label background color if the user name is not found.
        void PasswordRecovery1_UserLookupError(object sender, System.EventArgs e)
        {
            PasswordRecovery1.LabelStyle.ForeColor = System.Drawing.Color.Red;
        }

        // Reset the field label background color.
        void PasswordRecovery1_Load(object sender, System.EventArgs e)
        {
            PasswordRecovery1.LabelStyle.ForeColor = System.Drawing.Color.Black;
        }
        
        void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            e.Message.IsBodyHtml = false;
            e.Message.Subject = "New password on Web site.";
        }
    </script>
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BorderStyle="Solid" BorderWidth="1px" BackColor="#F7F7DE"
        Font-Size="10pt" Font-Names="Verdana" BorderColor="#CCCC99" HelpPageText="Need help?" HelpPageUrl="recoveryHelp.aspx" OnUserLookupError="PasswordRecovery1_UserLookupError" OnLoad="PasswordRecovery1_Load"
        maildefinition-from="neo.wu2@gmail.com"
         onsendingmail="PasswordRecovery1_SendingMail" UserNameInstructionText="Enter your email to receive your password." UserNameLabelText="Email Address:" UserNameRequiredErrorMessage="Email Address is required." OnVerifyingUser="PasswordRecovery1_VerifyingUser">
        <SuccessTemplate>
            <table border="0" style="font-size: 10pt;">
                <tr>
                    <td>Your password has been sent to you.</td>
                </tr>
            </table>
        </SuccessTemplate>
 
        <TitleTextStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></TitleTextStyle>
    </asp:PasswordRecovery>

</asp:Content>

