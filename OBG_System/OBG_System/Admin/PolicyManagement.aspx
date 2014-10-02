<%@ Page Title="Policy Management" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="PolicyManagement.aspx.cs" Inherits="Admin_PolicyManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="style1">
        <strong>Policy&amp;return</strong></p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="284px" Width="594px" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p class="style1">
        <strong>Price Match:</strong></p>
    <p>
        <asp:TextBox ID="matchTxt" runat="server" Height="284px" Width="594px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <p class="style1">
        <strong>Defects:</strong></p>
    <p>
        <asp:TextBox ID="defectsTxt" runat="server" Height="284px" Width="594px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <p class="style1">
        <strong>Shipping:</strong></p>
    <p>
        <asp:TextBox ID="shippingTxt" runat="server" Height="284px" Width="594px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <p class="style1">
        <strong>Others:</strong></p>
    <p class="style1">
        <asp:TextBox ID="TextBox2" runat="server" Height="284px" Width="594px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />&nbsp;</p>
</asp:Content>

