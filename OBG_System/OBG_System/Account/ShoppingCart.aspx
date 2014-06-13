<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Account_ShoppingCart" ErrorPage="~/mycustompage.aspx" %>

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
     <script type="text/javascript">
         //点击+号图，数量+1
         function Plus(obj) {
             obj.value = parseInt(obj.value) + 1;
         }
         //数量-1
         function Reduce(obj) {
             if (obj.value > 1) {
                 obj.value = obj.value - 1;
             }
         }

    </script>
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h1>Shopping Cart</h1>
    </div>
    <a href="~/Default.aspx">< Back to Products</a>
    <br />
    <asp:GridView ID="ShoppingCartGridView" runat="server" Visible="true" ForeColor="#333333" EmptyDataText="There is nothing in your shopping cart." AutoGenerateColumns="False" ShowFooter="True" CellPadding="4" SkinID="ShoppingCart"
        DataKeyNames="ProductId"  OnRowCommand="checkout_DataBound" OnRowDeleting="gvCart_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>

            <asp:BoundField DataField="OrderId" HeaderText="OrderId" InsertVisible="False" ReadOnly="True" SortExpression="OrderId" Visible="False" />
            <asp:TemplateField HeaderText="ProductID" SortExpression="ProductID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <ItemTemplate>
                    <asp:Image ID="imageLabel" class="Imagehub" runat="server" ImageUrl='<%# Eval("Image") %>'></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <ItemTemplate>
                    <asp:Label ID="PartNoLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Price" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="Price" runat="server" Text='<%# Convert.ToDouble(Eval("Price")).ToString("c2") %>'></asp:Label>
                   
                </ItemTemplate>
            </asp:TemplateField>

           
            <asp:TemplateField HeaderText="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="txtCount" runat="server" Width="35px" Text='<%# Eval("Quantity") %>' onkeyup="CheckValue(this)"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="ItemPrice" runat="server" Text='<%# Convert.ToDouble(Eval("itemTotal")).ToString("c2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField> --%>
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true">
                        <ItemStyle Width="30px" />
                    </asp:CommandField>
            <%--<asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this?');" CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>--%>

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
    <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
    <asp:Label ID="LabelTotalPrice" Visible="true" runat="server" ForeColor="#FF8080" ></asp:Label>

    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Right" 
        ImageUrl="~/Pictures/checkoutButton.png" OnClick="IBTCheckout_Click" />




</asp:Content>

