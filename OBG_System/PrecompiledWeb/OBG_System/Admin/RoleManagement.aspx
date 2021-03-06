﻿<%@ page title="Role Management" language="C#" masterpagefile="~/Admin/AdminSite.master" autoeventwireup="true" inherits="Admin_Default, App_Web_u2yl50jg" errorpage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" Orientation="Horizontal" OnMenuItemClick="NavigationMenu_MenuItemClick">
         <staticselectedstyle 
                           backcolor="White"
                           ForeColor="#3070d4"
                              borderstyle="Solid"
                              bordercolor="Black" 
                              borderwidth="1"/>
         <Items>
            <asp:MenuItem Text="Role Management"></asp:MenuItem>
            <asp:MenuItem Text="UserRole Management"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <div id="roleManagement" runat="server" visible="true">
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" AllowSorting="True" CellPadding="4" DataKeyNames="RoleId" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound"
            OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="RoleId" HeaderText="Role ID" InsertVisible="False" ReadOnly="True" SortExpression="RoleId" />
                <asp:TemplateField HeaderText="Role Name" SortExpression="RoleName">
                    <EditItemTemplate>
                        <asp:TextBox ID="RoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Des">
                    <EditItemTemplate>
                        <asp:TextBox ID="Des" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button"  ControlStyle-CssClass="myButton"/>
                <%--            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this role?');" CssClass="myButton"/>
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
        <asp:Button ID="btnAddNewRole" runat="server" Text="Create New Role" OnClick="btnAddRole_Click" CssClass="myButton"/>

        <div id="roleInformation" runat="server" visible="false">
            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="RegisterUserValidationGroup" />
            <fieldset class="wheelInfo">
                <legend>Role Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="RoleNameLabel" runat="server" AssociatedControlID="RoleName">Role Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="RoleName" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RoleNameRequired" runat="server" ControlToValidate="RoleName"
                                CssClass="failureNotification" ErrorMessage="Role Name is required." ToolTip="Role Name is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="DesLabel" runat="server" AssociatedControlID="Des">Description:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Des" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Des"
                                CssClass="failureNotification" ErrorMessage="Description is required." ToolTip="Description is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton"/>
                            <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton"/>
                        </td>
                        <td>
                            <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancel" Visible="true" CssClass="myButton"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>

    <div id="userRoleManagement" runat="server" visible="false">
                 <asp:Label ID="Label1" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage2" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage2_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>
        <asp:GridView ID="GridView2" runat="server" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RoleId" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" OnPageIndexChanging="GridView2_PageIndexChanging" OnSorting="GridView2_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Uid" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Uid" Visible="False"/>
                <asp:TemplateField HeaderText="User ID" SortExpression="UserId">
                    <EditItemTemplate>
                        <asp:TextBox ID="UserId" runat="server" Text='<%# Bind("UserId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                    <EditItemTemplate>
                        <asp:TextBox ID="UserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Current Role" SortExpression="RoleName">
                    <EditItemTemplate>
                        <asp:TextBox ID="RoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Des">
                    <EditItemTemplate>
                        <asp:TextBox ID="Des" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button"  ControlStyle-CssClass="myButton"/>
                <asp:TemplateField HeaderText="Change Role">
                    <ItemTemplate>
                        <asp:Label ID="lblSelectRoleID" runat="server" Text='<%# Eval("RoleID") %>' Visible="false" />
                        <asp:DropDownList ID="ddlSelectRoleName" runat="server" OnSelectedIndexChanged="ddlSelectRoleName_Change" AutoPostBack="true"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

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
    </div>
</asp:Content>

