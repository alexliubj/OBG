﻿<%@ Page Title="User Center" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>My Account
    </h2>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />
    <div class="accountInfo">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <fieldset >
                        <legend>Account Information</legend>
                        <asp:Table ID="Table2" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Style="white-space: nowrap">User Name:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Style="white-space: nowrap">E-mail:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
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
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" Style="white-space: nowrap">First Name:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
                                        CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" Style="white-space: nowrap">Last Name:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="LastName" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                                        CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="CompanyLabel" runat="server" AssociatedControlID="Company" Style="white-space: nowrap">Company:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="Company" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Company"
                                        CssClass="failureNotification" ErrorMessage="Company is required." ToolTip="Company is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone" Style="white-space: nowrap">Phone Number:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="Phone" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
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
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Button ID="BtnEdit" runat="server" CommandName="MoveNext" OnClick="BtnEdit_Click" Text="Edit" CssClass="myButton"/>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CssClass="myButton"/>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="False" ValidationGroup="RegisterUserValidationGroup"  CssClass="myButton"/>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancel" Visible="False"  CssClass="myButton"/>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell>
                                    <asp:Button  ID="BtnOrderHistory" runat="server"  Visible="True"  CssClass="myButton"  OnClick="BtnOrderHistory_Click" Text="Order History"></asp:Button>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </fieldset>
                </asp:TableCell>
                <asp:TableCell>

                    <fieldset class="Address">
                        <legend>Address</legend>
                        <fieldset class="shippingAddress">
                            <legend>Shipping Address</legend>
                            <asp:Table ID="Table3" runat="server">
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="ShippingHouseNoLabel" runat="server" AssociatedControlID="ShippingHouseNo" Style="white-space: nowrap">Apt/Suite Number:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="ShippingHouseNo" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ShippingHouseNo"
                                            CssClass="failureNotification" ErrorMessage="Shipping Apt/Suite Number is required." ToolTip="Shipping Apt/Suite Number is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="ShippingHouseNoExpression" runat="SERVER"
                                            ControlToValidate="ShippingHouseNo"
                                            CssClass="failureNotification"
                                            ErrorMessage="Enter a Number for shipping Apt/Suite Number."
                                            ValidationExpression="\d+"
                                            ValidationGroup="RegisterUserValidationGroup">*
                                        </asp:RegularExpressionValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="ShippingStreetLabel" runat="server" AssociatedControlID="ShippingStreet" Style="white-space: nowrap">Street:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="ShippingStreet" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ShippingStreet"
                                            CssClass="failureNotification" ErrorMessage="Shipping Street is required." ToolTip="Shipping Street is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="ShippingCityLabel" runat="server" AssociatedControlID="ShippingCity">City:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="ShippingCity" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ShippingCity"
                                            CssClass="failureNotification" ErrorMessage="Shipping City is required." ToolTip="Shipping City is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top" Height="45">
                                    <asp:TableCell>
                                        <asp:Label ID="ShippingProLabel" runat="server" AssociatedControlID="ShippingPro" Style="white-space: nowrap">Province:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ShippingPro" runat="server" Enabled="false">
                                            <asp:ListItem Value="" Selected="true">Select Province</asp:ListItem>
                                            <asp:ListItem Value="AB">Alberta</asp:ListItem>
                                            <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                                            <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                                            <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                                            <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                                            <asp:ListItem Value="NT">Northwest Territories</asp:ListItem>
                                            <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                                            <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                                            <asp:ListItem Value="ON">Ontario</asp:ListItem>
                                            <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                                            <asp:ListItem Value="QC">Quebec</asp:ListItem>
                                            <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                                            <asp:ListItem Value="YT">Yukon</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ShippingPro"
                                            CssClass="failureNotification" ErrorMessage="Shipping Province is required." ToolTip="Shipping Province is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="ShippingPostCodeLabel" runat="server" AssociatedControlID="ShippingPostCode" Style="white-space: nowrap">Post Code:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="ShippingPostCode" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
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
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                        <fieldset class="billingAddress">
                            <legend>Billing Address</legend>
                            <asp:Table ID="Table4" runat="server">
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="BillingHouseNoLabel" runat="server" AssociatedControlID="BillingHouseNo" Style="white-space: nowrap">Apt/Suite Number:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="BillingHouseNo" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="BillingHouseNo"
                                            CssClass="failureNotification" ErrorMessage="Billing Apt/Suite Number is required." ToolTip="Billing Apt/Suite Number is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="SERVER"
                                            ControlToValidate="BillingHouseNo"
                                            CssClass="failureNotification"
                                            ErrorMessage="Enter a Number for shipping Apt/Suite Number."
                                            ValidationExpression="\d+"
                                            ValidationGroup="RegisterUserValidationGroup">*
                                        </asp:RegularExpressionValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="BillingStreetLabel" runat="server" AssociatedControlID="BillingStreet" Style="white-space: nowrap">Street:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="BillingStreet" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="BillingStreet"
                                            CssClass="failureNotification" ErrorMessage="Billing Street is required." ToolTip="Billing Street is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="BillingCityLabel" runat="server" AssociatedControlID="BillingCity" Style="white-space: nowrap">City:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="BillingCity" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="BillingCity"
                                            CssClass="failureNotification" ErrorMessage="Billing City is required." ToolTip="Billing City is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top" Height="45">
                                    <asp:TableCell>
                                        <asp:Label ID="BillingProLabel" runat="server" AssociatedControlID="BillingPro" Style="white-space: nowrap">Province:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="BillingPro" runat="server" Enabled="false">
                                            <asp:ListItem Value="" Selected="true">Select Province</asp:ListItem>
                                            <asp:ListItem Value="AB">Alberta</asp:ListItem>
                                            <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                                            <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                                            <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                                            <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                                            <asp:ListItem Value="NT">Northwest Territories</asp:ListItem>
                                            <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                                            <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                                            <asp:ListItem Value="ON">Ontario</asp:ListItem>
                                            <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                                            <asp:ListItem Value="QC">Quebec</asp:ListItem>
                                            <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                                            <asp:ListItem Value="YT">Yukon</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="BillingPro"
                                            CssClass="failureNotification" ErrorMessage="Billing Province is required." ToolTip="Billing Province is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow VerticalAlign="Top">
                                    <asp:TableCell>
                                        <asp:Label ID="BillingPostCodeLabel" runat="server" AssociatedControlID="BillingPostCode" Style="white-space: nowrap">Post Code:</asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="BillingPostCode" runat="server" CssClass="textEntry" Width="200" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="BillingPostCode"
                                            CssClass="failureNotification" ErrorMessage="Billing Post Code is required." ToolTip="Billing Post Code is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator2" runat="SERVER"
                                            ControlToValidate="BillingPostCode"
                                            CssClass="failureNotification"
                                            ErrorMessage="Enter a valid Post Code."
                                            ValidationExpression="\d{5}((-)?\d{4})?|([A-Za-z]\d[A-Za-z]( )?\d[A-Za-z]\d)"
                                            ValidationGroup="RegisterUserValidationGroup">*
                                        </asp:RegularExpressionValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                    </fieldset>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>

