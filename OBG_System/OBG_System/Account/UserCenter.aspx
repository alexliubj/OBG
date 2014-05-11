<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>My Account
                    </h2>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />
    <fieldset class="accountInfo">
        <legend>Account Information</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                        CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="EmailExpression" runat="SERVER"
                        ControlToValidate="Email"
                        CssClass="failureNotification"
                        ErrorMessage="Enter a valid Email."
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="RegisterUserValidationGroup">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
                        CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                        CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="CompanyLabel" runat="server" AssociatedControlID="Company">Company:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Company" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Company"
                        CssClass="failureNotification" ErrorMessage="Company is required." ToolTip="Company is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone">Phone Number:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Phone"
                        CssClass="failureNotification" ErrorMessage="Phone Number is required." ToolTip="Phone Number is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator
                        ID="PhoneExpression" runat="SERVER"
                        ControlToValidate="Phone"
                        CssClass="failureNotification"
                        ErrorMessage="Enter a valid Phone Number."
                        ValidationExpression="^([0-9\(\)\/\+ \-]*)$"
                        ValidationGroup="RegisterUserValidationGroup">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="ShippingAddressLabel" runat="server" AssociatedControlID="ShippingAddress">Shipping Address:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ShippingAddress" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ShippingAddress"
                        CssClass="failureNotification" ErrorMessage="Shipping Address is required." ToolTip="Shipping Address is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="ShippingPostCodeLabel" runat="server" AssociatedControlID="ShippingPostCode">Shipping Post Code:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ShippingPostCode" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ShippingPostCode"
                        CssClass="failureNotification" ErrorMessage="Shipping Post Code is required." ToolTip="Shipping Post Code is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator
                        ID="ShippingPostCodeExpression" runat="SERVER"
                        ControlToValidate="ShippingPostCode"
                        CssClass="failureNotification"
                        ErrorMessage="Enter a valid Post Code."
                        ValidationExpression="\d{5}((-)?\d{4})?|([A-Za-z]\d[A-Za-z]( )?\d[A-Za-z]\d)"
                        ValidationGroup="RegisterUserValidationGroup">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="BillingAddressLabel" runat="server" AssociatedControlID="BillingAddress">Billing Address:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="BillingAddress" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="BillingAddress"
                        CssClass="failureNotification" ErrorMessage="Billing Address is required." ToolTip="Billing Address is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="BillingPostCodeLabel" runat="server" AssociatedControlID="BillingPostCode">Billing Post Code:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="BillingPostCode" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="BillingPostCode"
                        CssClass="failureNotification" ErrorMessage="Billing Post Code is required." ToolTip="Billing Post Code is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator
                        ID="BillingPostCodeExpression" runat="SERVER"
                        ControlToValidate="BillingPostCode"
                        CssClass="failureNotification"
                        ErrorMessage="Enter a valid Post Code."
                        ValidationExpression="\d{5}((-)?\d{4})?|([A-Za-z]\d[A-Za-z]( )?\d[A-Za-z]\d)"
                        ValidationGroup="RegisterUserValidationGroup">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnEdit" runat="server" CommandName="MoveNext" OnClick="BtnEdit_Click" Text="Edit" Width="37px" />
                    </td><td>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" Width="137px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="False" ValidationGroup="RegisterUserValidationGroup" />
                </td>
                <td>
                    <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancle" Visible="False" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

