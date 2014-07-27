<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

     <asp:Panel ID="p" runat="server" DefaultButton="BtnSubmit">
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" />
                <div id="accountInfo" class="accountInfo">
                    <fieldset class="login">
                        <legend>Enter your email to receive your password.</legend>
                        <p>
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            <asp:Label ID="EmailAddressLabel" runat="server" AssociatedControlID="EmailAddress">Email Address:</asp:Label>
                            <asp:TextBox ID="EmailAddress" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailAddressRequired" runat="server" ControlToValidate="EmailAddress"
                                CssClass="failureNotification" ErrorMessage="Email Address is required." ToolTip="Email Address is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                    <br />
                    <p class="submitButton">
                        <asp:Button ID="BtnSubmit" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="LoginUserValidationGroup" OnClick="BtnSubmit_Click"  CssClass="myButton"/>
                    </p>
                        </fieldset>
                </div>
            </asp:Panel>
</asp:Content>

