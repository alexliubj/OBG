<%@ Page Title="Region Management" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="RegionManagement.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RegionId" ForeColor="#333333"
        GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting"
        OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="RegionId" HeaderText="RegionId" InsertVisible="False" ReadOnly="True" SortExpression="RegionId" />
            <asp:TemplateField HeaderText="Region Name" SortExpression="RegionName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RegionName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RegionName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="RegionPrice">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegionPrice") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("RegionPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Method" SortExpression="DevMethods">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DevMethods") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("DevMethods") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
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
    <asp:Button ID="btnAddRegion" runat="server" Text="Add New Region" OnClick="btnAddRegion_Click" align="right"/>

    <div id="regionInformation" runat="server" visible="True">
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="RegisterUserValidationGroup" />
        <fieldset class="regionInfo">
            <legend>Region Information</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="RegionNameLabel" runat="server" AssociatedControlID="RegionName">Region Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="RegionName" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RegionNameRequired" runat="server" ControlToValidate="RegionName"
                            CssClass="failureNotification" ErrorMessage="Region Name is required." ToolTip="Region Name is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" AssociatedControlID="Price">Price:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Price" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price"
                            CssClass="failureNotification" ErrorMessage="Price is required." ToolTip="Price is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="DevMethodsLabel" runat="server" AssociatedControlID="DevMethods">Method:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="DevMethods" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DevMethods"
                            CssClass="failureNotification" ErrorMessage="Method is required." ToolTip="Method is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" />
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

