<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mycustompage.aspx.cs" Inherits="mycustompage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Error Page</h1>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Back to Home Page</asp:HyperLink>
    </div>
    </form>
</body>
</html>
