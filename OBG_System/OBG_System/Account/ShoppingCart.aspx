<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Account_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 72px;
        }

        .style2
        {
            width: 610px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="Form2" runat="server">
        <asp:GridView ID="ShoppingCartGridView" runat="server" AutoGenerateColumns="False" SkinID="ShoppingCart"
            Width="100%" DataKeyNames="ProductID" OnRowDataBound="ShoppingCartGridView_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <ItemTemplate>
                        <asp:Label ID="ProductNameLable" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AccountPrice" HeaderText="Price" />
                <asp:BoundField DataField="Account" HeaderText="Discount" />
                <%-- <asp:BoundField DataField="Date" HeaderText="Date" />--%>
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
                <td class="style1">
                    <strong>Total：</strong></td>
                <td>
                    <asp:Label ID="lblTatil" runat="server" Style="font-weight: bold; color: #cc0033">0</asp:Label></td>
                <td style="text-align: right" class="style2">
                    <asp:LinkButton ID="LBRepost" runat="server" Font-Bold="True" Font-Size="11pt"
                        OnClick="LBRepost_Click">Continue</asp:LinkButton></td>
                <td style="text-align: right">
                    <asp:ImageButton ID="IBTCheckout" runat="server"
                        ImageUrl="~/Pictures/checkoutButton.png" OnClick="IBTCheckout_Click" /></td>
            </tr>
        </table>
    </form>

    <form id="Form1" runat="server">
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:DataGrid ID="ShoppingCartDlt" runat="server" Width="500" BackColor="white" BorderColor="black" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#cecfd6" AutoGenerateColumns="false" MaintainState="true">
                        <Columns>
                            <asp:TemplateColumn HeaderText="删除">
                                <ItemTemplate>
                                    <center> 
<asp:CheckBox id="chkProductID" runat="server" /> </center>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="ProdID" HeaderText="ID" />
                            <asp:BoundColumn DataField="ProName" HeaderText="商品名称" />
                            <asp:BoundColumn DataField="UnitPrice" HeaderText="单价" />
                            <asp:TemplateColumn HeaderText="数量">
                                <ItemTemplate>
                                    <asp:TextBox ID="CountTb" runat="server" Text='<%#DataBinder.Eval( Container.DataItem,"ProdCount" )%>'> </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="TotalPrice" HeaderText="小计( 元 )" />
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
        </table>
        <br>
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:Button ID="update" runat="server" Text="更新我的购物车" CssClass="button2" /></td>
                <td>
                    <asp:Button ID="CheckOut" runat="server" Text="结算" CssClass="button5" />
                    <input type="button" name="close2" value="继续购物" onclick="window.close();
    return false;
"
                        class="button2"></td>
                <td align="right">
                    <br>
                    <asp:Label ID="label" runat="server" Width="100px" Visible="True" ForeColor="#FF8080" Height="18px"></asp:Label></td>
            </tr>
        </table>
    </form>

</asp:Content>

