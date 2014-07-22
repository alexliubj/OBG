<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Order_shoppingcart, App_Web_arsculu0" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <title>shoppingcart 
</title> 
<meta http-equiv="Content-Type" content="text/html; 
charset=gb2312"> <LINK href="mycss.css" type="text/css" rel="stylesheet"> 
<meta name="vs_defaultClientScript" content="JavaScript"> 
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"> </HEAD> 
<body> <center> 
<form id="Form1" runat="server"> <table width="500" border="0" cellspacing="0" cellpadding="0"> <tr> <td> 
<asp:DataGrid id="ShoppingCartDlt" runat="server" Width="500" BackColor="white" BorderColor="black" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#cecfd6" AutoGenerateColumns="false" MaintainState="true"> <Columns> 
<asp:TemplateColumn HeaderText="Delete"> 
<ItemTemplate> <center> 
<asp:CheckBox id="chkProductID" runat="server" /> </center> 
</ItemTemplate> </asp:TemplateColumn> 
<asp:BoundColumn DataField="ProdID" HeaderText="ID" /> 
<asp:BoundColumn DataField="ProName" HeaderText="Product Name" /> 
<asp:BoundColumn DataField="UnitPrice" HeaderText="Price" /> 
<asp:TemplateColumn HeaderText="Quatity"> 
<ItemTemplate> 
<asp:TextBox id="CountTb" runat="server" Text='<%#DataBinder.Eval( Container.DataItem,"ProdCount" )%>'> </asp:TextBox> 
</ItemTemplate> </asp:TemplateColumn> 
<asp:BoundColumn DataField="TotalPrice" HeaderText="Price" /> </Columns> </asp:DataGrid></td> </tr> </table> <br> <table width="500" border="0" cellspacing="0" cellpadding="0"> <tr> <td> 
<asp:Button id="update" runat="server" Text="Update My Shopping Cart" CssClass="button2" /></td> <td> 
<asp:Button id="CheckOut" runat="server" Text="Check Out" CssClass="button5" /> 
<input type="button" name="close2" value="Continue My Shopping" onClick="window.close( ); 
return false; 
" class="button2"></td> <td align="right"><br> 
<asp:Label id="label" runat="server" Width="100px" Visible="True" ForeColor="#FF8080" Height="18px"></asp:Label></td> </tr> </table> 
</form> </center> 
</body>



</asp:Content>

