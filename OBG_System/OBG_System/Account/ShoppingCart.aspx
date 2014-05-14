<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:GridView ID="GVShoppingCart" runat="server" AutoGenerateColumns="False" SkinID="ShoppingCart"
    Width="100%" OnRowDeleting="GVShoppingCart_RowDeleting" DataKeyNames="ProductID" OnDataBound="GVShoppingCart_DataBound">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="AccountPrice" HeaderText="Price" />
        <asp:BoundField DataField="Account" HeaderText="Discount" />
        <asp:BoundField DataField="Date" HeaderText="Date" />
        <asp:TemplateField HeaderText="QTY">
            <ItemTemplate>
                <asp:TextBox ID="txtCount" runat="server" Width="35px" Text='<%# Eval("Quantity") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="delete" Text="Delete" />
    </Columns>
</asp:GridView>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <strong>Total：</strong></td>
        <td>
            <asp:Label ID="lblTatil" runat="server" Style="font-weight: bold; color: #cc0033">0</asp:Label></td>
       <td style="text-align: right">
            <asp:LinkButton ID="LBUpdate" runat="server" Font-Bold="True" Font-Size="11pt" OnClick="LBUpdate_Click">Update</asp:LinkButton></td>
        <td style="text-align: right">
            <asp:LinkButton ID="LBRepost" runat="server" Font-Bold="True" Font-Size="11pt"  OnClick="LBRepost_Click">Continue</asp:LinkButton></td>
        <td style="text-align: right">
            <asp:ImageButton ID="IBTatil" runat="server" ImageUrl="~/Pictures/checkoutButton.png" OnClick="IBTatil_Click" /></td>
    </tr>
</table>
        </asp:Content>

