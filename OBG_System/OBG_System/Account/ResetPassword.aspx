<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Account_ResetPassword" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     
    <div class="accountInfo" id="changePasswordDiv" runat="server" visible="false">
                <%--    <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>--%>
        <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="ChangeUserPasswordValidationGroup" />
        <fieldset class="changePassword">
            <legend>Reset Password</legend>
            <p>
                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                    CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                    ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="PasswordExpression" runat="SERVER"
                    ControlToValidate="NewPassword"
                    CssClass="failureNotification"
                    ErrorMessage="Password should have at least one number, one letter with at least six characters."
                    ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-zA-Z]).*$"
                    ValidationGroup="RegisterUserValidationGroup">*
                </asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                    ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>

                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                    ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="ConfirmButton" runat="server" CommandName="Confirm" Text="Confirm"
                ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="ConfrimButton_Click1"  CssClass="myButton"/>
        </p>
    </div>
    <div id="errorDiv" runat="server">
        Invalid Request!
    </div>
</asp:Content>

