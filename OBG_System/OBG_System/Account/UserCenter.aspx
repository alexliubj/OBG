<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
                    <h2>
                 My Account
                    </h2>
    <fieldset class="accountInfo">
    <legend>Account Information</legend>
         <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            
                            <p>
                                <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                                <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" 
                                     CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                             <p>
                                <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                                <asp:TextBox ID="LastName" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" 
                                     CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                             <p>
                                <asp:Label ID="CompanyLabel" runat="server" AssociatedControlID="Company">Company:</asp:Label>
                                <asp:TextBox ID="Company" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Company" 
                                     CssClass="failureNotification" ErrorMessage="Company is required." ToolTip="Company is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                             <p>
                                <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone">Phone Number:</asp:Label>
                                <asp:TextBox ID="Phone" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Phone" 
                                     CssClass="failureNotification" ErrorMessage="Phone Number is required." ToolTip="Phone Number is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                             <p>
                                <asp:Label ID="ShippingAddressLabel" runat="server" AssociatedControlID="ShippingAddress">Shipping Address:</asp:Label>
                                <asp:TextBox ID="ShippingAddress" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ShippingAddress" 
                                     CssClass="failureNotification" ErrorMessage="Shipping Address is required." ToolTip="Shipping Address is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ShippingPostCodeLabel" runat="server" AssociatedControlID="ShippingPostCode">Shipping Post Code:</asp:Label>
                                <asp:TextBox ID="ShippingPostCode" runat="server" CssClass="textEntry" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ShippingPostCode" 
                                     CssClass="failureNotification" ErrorMessage="Shipping Post Code is required." ToolTip="Shipping Post Code is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
        <p>
                                &nbsp;</p>
        <p>
                                <asp:Button ID="BtnEdit" runat="server" OnClick="BtnEdit_Click" Text="Edit" Width="37px" />
                            </p>
        <p>
                                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="False" />
                                <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancle" Visible="False" />
                            </p>
        </fieldset>
</asp:Content>

