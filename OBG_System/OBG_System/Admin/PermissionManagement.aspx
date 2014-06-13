<%@ Page Title="Permission Management" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="PermissionManagement.aspx.cs" Inherits="Admin_Default" ErrorPage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
       <asp:Label ID="Label1" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserID" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" Visible="False" />
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
            <asp:TemplateField HeaderText="Wheel Permission">
                <ItemTemplate>
                    <asp:CheckBox ID="checkBoxWheel" runat="server" Text="Wheel" OnCheckedChanged="checkBoxWheel_CheckedChanged"  AutoPostBack="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tire Permission">
                <ItemTemplate>
                    <asp:CheckBox ID="checkBoxTire" runat="server" Text="Tire"  OnCheckedChanged="checkBoxTire_CheckedChanged" AutoPostBack="true"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Accessory Permission">
                <ItemTemplate>
                    <asp:CheckBox ID="checkBoxAccessory" runat="server" Text="Accessory"  OnCheckedChanged="checkBoxAccessory_CheckedChanged" AutoPostBack="true"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="myButton" />
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
</asp:Content>

