<%@ page title="User Management" language="C#" masterpagefile="~/Admin/AdminSite.master" autoeventwireup="true" inherits="Admin_Default, App_Web_vipc33sz" errorpage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="Label2" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>

    <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserId" ForeColor="#333333"
        GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
        OnRowDeleting="GridView1_RowDeleting"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowDataBound="GridView1_RowDataBound"
        OnRowCreated="GridView1_RowCreated"
        OnRowCommand="GridView1_RowCommand">
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
            <asp:TemplateField HeaderText="Current Status" SortExpression="Status">
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
            <asp:TemplateField HeaderText="IP">
                <ItemTemplate>
                    <asp:Button ID="viewIPButton" runat="server" CommandName="ViewIP" Text="View IP Info"
                        CommandArgument='<%#((GridViewRow)Container).RowIndex%>' CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-CssClass="HiddenColumn" HeaderStyle-CssClass="HiddenColumn" FooterStyle-CssClass="none">

                <HeaderStyle CssClass="HiddenColumn" />
                <ItemStyle CssClass="HiddenColumn" />
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                        Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="myButton" />
            <asp:TemplateField HeaderText="Change Status">
                <ItemTemplate>
                    <asp:Button ID="activeButton" runat="server" CommandName="Active" Text="Active"
                        CommandArgument='<%#((GridViewRow)Container).RowIndex%>' OnClientClick="return confirm('Are you sure you want to active this user?');" CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" CssClass="myButton" />
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

    <br />
    <asp:Button ID="btnAddUser" runat="server" Text="Add New User" OnClick="btnAddUser_Click" CssClass="myButton" />
    <br />

    <div id="divIPInfo" runat="server" visible="false">
        <fieldset class="accountInfo">
            <legend>IP Address Information</legend>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUserID" runat="server" AssociatedControlID="txtUserID">User ID:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtUserID" runat="server" CssClass="textEntry" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblLastIP" runat="server" AssociatedControlID="txtLastIP">Last Login IP Address:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLastIP" runat="server" CssClass="textEntry" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblLoginTimes" runat="server" AssociatedControlID="txtLoginTimes">Total Login Times:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLoginTimes" runat="server" CssClass="textEntry" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblIPRegion" runat="server" AssociatedControlID="gvLocation">IP Detail Info:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:GridView ID="gvLocation" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="IPAddress" HeaderText="IP Address" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country" />
                                <asp:BoundField DataField="CityName" HeaderText="City" />
                                <asp:BoundField DataField="RegionName" HeaderText="Region" />
                                <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                                <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                                <asp:BoundField DataField="Longitude" HeaderText="Latitude" />
                                <asp:BoundField DataField="Timezone" HeaderText="Timezone" />
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </fieldset>
    </div>

    <div id="userInformation" runat="server" visible="false">
        <asp:Panel DefaultButton="BtnAdd" runat="server">
            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="RegisterUserValidationGroup" />
            <asp:Table runat="server">
                <asp:TableRow VerticalAlign="Top">
                    <asp:TableCell>
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
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Visible="false">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Visible="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="Password"
                                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="PasswordExpression" runat="SERVER"
                                            ControlToValidate="Password"
                                            CssClass="failureNotification"
                                            ErrorMessage="Password should have at least one number, one letter with at least six characters."
                                            ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-zA-Z]).*$"
                                            ValidationGroup="RegisterUserValidationGroup">*
                                        </asp:RegularExpressionValidator>
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
                                        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                                        <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" CssClass="myButton" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancel" Visible="true" CssClass="myButton" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:TableCell>
                    <asp:TableCell>
                        <fieldset class="Address">
                            <legend>Address</legend>
                            <fieldset class="shippingAddress">
                                <legend>Shipping Address</legend>
                                <asp:Table ID="Table1" runat="server">
                                    <asp:TableRow VerticalAlign="Top">
                                        <asp:TableCell>
                                            <asp:Label ID="ShippingHouseNoLabel" runat="server" AssociatedControlID="ShippingHouseNo" Style="white-space: nowrap">Apt/Suite Number:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="ShippingHouseNo" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ShippingHouseNo"
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
                                            <asp:TextBox ID="ShippingStreet" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ShippingStreet"
                                                CssClass="failureNotification" ErrorMessage="Shipping Street is required." ToolTip="Shipping Street is required."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow VerticalAlign="Top">
                                        <asp:TableCell>
                                            <asp:Label ID="ShippingCityLabel" runat="server" AssociatedControlID="ShippingCity">City:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="ShippingCity" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ShippingCity"
                                                CssClass="failureNotification" ErrorMessage="Shipping City is required." ToolTip="Shipping City is required."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow VerticalAlign="Top" Height="45">
                                        <asp:TableCell>
                                            <asp:Label ID="ShippingProLabel" runat="server" AssociatedControlID="ShippingPro" Style="white-space: nowrap">Province:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:DropDownList ID="ShippingPro" runat="server">
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ShippingPro"
                                                CssClass="failureNotification" ErrorMessage="Shipping Province is required." ToolTip="Shipping Province is required."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow VerticalAlign="Top">
                                        <asp:TableCell>
                                            <asp:Label ID="ShippingPostCodeLabel" runat="server" AssociatedControlID="ShippingPostCode" Style="white-space: nowrap">Post Code:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="ShippingPostCode" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ShippingPostCode"
                                                CssClass="failureNotification" ErrorMessage="Shipping Post Code is required." ToolTip="Shipping Post Code is required."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="SERVER"
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
                            <asp:Label ID="IsSameAddress" runat="server" Text="Billing Address is the same as shipping address?"></asp:Label>
                            <asp:CheckBox ID="checkBoxIsSameAddress" runat="server" OnCheckedChanged="CheckBoxIsSameAddress_Clicked" AutoPostBack="true" Checked="false" />
                            <div id="billingAddressDiv" runat="server">
                                <fieldset class="billingAddress">
                                    <legend>Billing Address</legend>
                                    <asp:Table ID="Table2" runat="server">
                                        <asp:TableRow VerticalAlign="Top">
                                            <asp:TableCell>
                                                <asp:Label ID="BillingHouseNoLabel" runat="server" AssociatedControlID="BillingHouseNo" Style="white-space: nowrap">Apt/Suite Number:</asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="BillingHouseNo" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="BillingHouseNo"
                                                    CssClass="failureNotification" ErrorMessage="Billing Apt/Suite Number is required." ToolTip="Billing Apt/Suite Number is required."
                                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator2" runat="SERVER"
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
                                                <asp:TextBox ID="BillingStreet" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="BillingStreet"
                                                    CssClass="failureNotification" ErrorMessage="Billing Street is required." ToolTip="Billing Street is required."
                                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow VerticalAlign="Top">
                                            <asp:TableCell>
                                                <asp:Label ID="BillingCityLabel" runat="server" AssociatedControlID="BillingCity" Style="white-space: nowrap">City:</asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="BillingCity" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="BillingCity"
                                                    CssClass="failureNotification" ErrorMessage="Billing City is required." ToolTip="Billing City is required."
                                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow VerticalAlign="Top" Height="45">
                                            <asp:TableCell>
                                                <asp:Label ID="BillingProLabel" runat="server" AssociatedControlID="BillingPro" Style="white-space: nowrap">Province:</asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="BillingPro" runat="server">
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="BillingPro"
                                                    CssClass="failureNotification" ErrorMessage="Billing Province is required." ToolTip="Billing Province is required."
                                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow VerticalAlign="Top">
                                            <asp:TableCell>
                                                <asp:Label ID="BillingPostCodeLabel" runat="server" AssociatedControlID="BillingPostCode" Style="white-space: nowrap">Post Code:</asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="BillingPostCode" runat="server" CssClass="textEntry" Width="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="BillingPostCode"
                                                    CssClass="failureNotification" ErrorMessage="Billing Post Code is required." ToolTip="Billing Post Code is required."
                                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator3" runat="SERVER"
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
                            </div>
                        </fieldset>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </div>
</asp:Content>
