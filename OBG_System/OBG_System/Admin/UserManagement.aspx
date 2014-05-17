<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.master" 
AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
        <asp:Button ID="btnAddUser" runat="server" Text="Add New User" OnClick="btnAddUser_Click" align="right"/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserId" ForeColor="#333333" 
    GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting"
        OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
            <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Text="active"></asp:ListItem>
                        <asp:ListItem Text="inactive"></asp:ListItem>
                    </asp:DropDownList>
                    <%-- <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>--%>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CompanyName" SortExpression="CompanyName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone" SortExpression="Phone">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Change Status">
                <ItemTemplate>
                    <asp:Button ID="activeButton" runat="server" CommandName="Active" Text="Active"
                        OnClick="activeButton_Click" OnClientClick="return confirm('Are you sure you want to active this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />--%>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <div id="userInformation" runat="server" visible="false">
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
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" ReadOnly="true"></asp:TextBox>
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
                        <asp:TextBox ID="Email" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="LastName" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="Company" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="Phone" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="ShippingAddress" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="ShippingPostCode" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="BillingAddress" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:TextBox ID="BillingPostCode" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
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
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Visible="false">Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="Password"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" Visible="false">Confirm Password:</asp:Label>
                         </td>
                    <td>
                        <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm Password is required."
                            ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm Password must match the Password entry."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup"/>  
                        <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" />
                    </td>
                    <td>
                        <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancle" Visible="true" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
