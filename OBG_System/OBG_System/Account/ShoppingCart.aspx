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
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
     <a href="~/Default.aspx">< Back to Products</a>
        <asp:GridView ID="ShoppingCartGridView" runat="server" Visible="true"  EmptyDataText="There is nothing in your shopping cart." AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4" SkinID="ShoppingCart"
            Width="100%" DataKeyNames="ProductId">
            <Columns>
                <%--<asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <ItemTemplate>
                        <asp:Label ID="ProductNameLable" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="ProductID" SortExpression="ProductID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <ItemTemplate>
                    <asp:Label ID="imageLabel" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <ItemTemplate>
                    <asp:Label ID="PartNoLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCount" runat="server" Width="35px" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField> --%>
                <asp:ButtonField CommandName="delete" Text="Delete" />
            </Columns>
        </asp:GridView>

    
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="Label1" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
        <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Right"
                        ImageUrl="~/Pictures/checkoutButton.png" OnClick="IBTCheckout_Click" />
    </div>
        <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style1">
                    <strong>Total：</strong></td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Style="font-weight: bold; color: #cc0033">0</asp:Label></td>
                <td style="text-align: right" class="style2">
                    <asp:LinkButton ID="LBRepost" runat="server" Font-Bold="True" Font-Size="11pt"
                        OnClick="LBRepost_Click">Continue</asp:LinkButton></td>
                <td style="text-align: right">
                    <asp:ImageButton ID="IBTCheckout" runat="server"
                        ImageUrl="~/Pictures/checkoutButton.png" OnClick="IBTCheckout_Click" /></td>
            </tr>
        </table>--%>
    

    

   
    <%--<div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="font-size: 10pt;
            width: 637px;">
            <tr>
                <td style="vertical-align: top; text-align: center; background-image: url(Image/购物车/子页中间.jpg); width: 637px; height: 341px;">
                    <asp:DataList ID="dlShoppingCart" runat="server"
                        OnItemDataBound="dlShoppingCart_ItemDataBound"
                        OnDeleteCommand="dlShoppingCart_DeleteCommand"
                        OnItemCommand="dlShoppingCart_ItemCommand" CellPadding="4" ForeColor="#333333">
                        <ItemTemplate>
                            <table style="width: 368px; font-size: 10pt;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 88px; height: 26px;">
                                        <asp:Label ID="labGoodName" runat="server" Text='<%# Eval("ProName") %>'></asp:Label></td>
                                    <td style="width: 102px; height: 26px;">
                                        <asp:Label ID="labGoodsPrice" runat="server" Text='<%# Eval("ProPrice") %>'></asp:Label></td>
                                     <td style="width: 102px; height: 26px;">
                                        <asp:Label ID="labDiscount" runat="server" Text='<%# Eval("Discount") %>' Width="33px"></asp:Label></td>
                                    <td style="width: 50px; height: 26px;">
                                        <asp:TextBox ID="txtGoodsNum" runat="server" Text='<%# Eval("num") %>' Width="33px"></asp:TextBox></td>
                                    <td style="width: 76px; height: 26px">
                                        <asp:LinkButton ID="lnkbtnUpdateCart" runat="server" CommandArgument='<%# Eval("ProId") %>'
                                            CommandName="updateNum" ForeColor="Black">Update</asp:LinkButton></td>
                                    <td style="height: 26px">
                                        &nbsp;<asp:LinkButton ID="lnkbtnDel" runat="server" CommandArgument='<%# Eval("ProId") %>'
                                            CommandName="delete" ForeColor="Black"  OnClientClick="return confirm('Do you want to delete？')">Delete</asp:LinkButton></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderTemplate><table style="width: 368px; font-size: 10pt;" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 88px; height: 26px;">
                                        Product Name</td>
                                <td style="width: 102px; height: 26px;">
                                        Price</td>   
                                <td style="width: 102px; height: 26px;">
                                        Discount</td>                               
                                <td style="width: 50px; height: 26px;">
                                        QTY</td>
                                <td style="width: 76px; height: 26px">
                                </td>
                                <td style="height: 26px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </HeaderTemplate>
                        <FooterTemplate>
                            <table style="width: 368px; font-size: 10pt;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" colspan="4">
                                        Total：<%=M_str_Count %>$</td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                    <br />
                    <%--<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update" />--%>
               <%-- </td>
            </tr>
            <tr>
                <td style="height: 140px; text-align: right; background-image: url(Image/购物车/子页底.jpg); width: 637px;">
                    &nbsp;</td>
            </tr>
        </table>--%>
   
    <%--</div>--%>
   


</asp:Content>

