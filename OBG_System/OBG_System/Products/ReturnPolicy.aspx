<%@ Page Title="Policy" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReturnPolicy.aspx.cs" Inherits="Products_ReturnPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p style=" text-align:center;font-family: Arial, Helvetica, sans-serif; font-size: 32px; font-weight: normal; text-decoration: underline; font-style: normal; color: #0000FF">Policy
    </p>
    <p><span style="color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: 700; letter-spacing: normal; line-height: 20.479999542236328px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
        RETURN &amp; EXCHANGE:<span class="Apple-converted-space">&nbsp;</span></span></p>
    <p><asp:Label ID="policy" runat="server" style="font-size: medium"></asp:Label></p>
    <p class="style2"><strong style="font-size: 16px">Others:</strong></p>
    <asp:Label ID="others" runat="server" style="font-size: medium"></asp:Label>
</asp:Content>

