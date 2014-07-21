<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="PolicyManagement.aspx.cs" Inherits="Admin_PolicyManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Policy</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="284px" Width="594px" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />&nbsp;</p>
</asp:Content>

