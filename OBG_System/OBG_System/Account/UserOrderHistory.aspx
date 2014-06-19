<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserOrderHistory.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 91px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <br />
    <p>Your orders:</p>
    <div runat="server" align ="center">
    <asp:GridView ID="GridView1" runat="server" GridLines="Both"  AllowPaging="True" AllowSorting="true" Width="80%" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="true" ReadOnly="True" SortExpression="OrderID" />

            <asp:TemplateField HeaderText="UserID" ItemStyle-HorizontalAlign="Center" Visible="false" SortExpression="UserID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelOrderID" runat="server" Visible="false" Text='<%# Bind("OrderID") %>'></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OrderDate" ItemStyle-HorizontalAlign="Center" SortExpression="OrderDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OrderDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PO" ItemStyle-HorizontalAlign="Center" SortExpression="PO">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("PO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="View Order Detail" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" ButtonType="Button" SelectText="View Order Detail" ControlStyle-CssClass="myButton" />

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
        </div>








    <div id="divOrderDetail" runat="server" visible="false">
        <br />
        <br />
        <p>Order Detail:</p>
        <div id="Div1" runat="server" align ="center">
        <asp:GridView ID="OrderGridView" runat="server" GridLines="Both" AllowPaging="True" AllowSorting="true" Width="80%" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderId" ForeColor="#333333"
            Visible="true" OnRowDeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" Visible="true" />
                <%--<asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" Visible="true" />--%>
                <asp:TemplateField HeaderText="ProductID" SortExpression="ProductID">
                    <ItemTemplate>
                        <asp:Label ID="LBProductID" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PartNo" SortExpression="Status">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductName" SortExpression="PartNo">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="ProductName">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Width="20" Text='<%# Bind("Qty") %>'></asp:TextBox>
                    </ItemTemplate>
                    <%--                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                        </ItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="PO">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DiscountRate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" Visible="true" ButtonType="Button" DeleteText="Delete" ControlStyle-CssClass="myButton" />
 
                <%--<asp:LinkButton ID="LBsee" runat="server" CommandArgument='<%#Eval("OrderID") %>'>查看订单信息</asp:LinkButton>--%>

                <%--<asp:TemplateField HeaderText="Detail">
                <ItemTemplate>
                    <asp:Button ID="LBsee" runat="server" CommandName="Detail" CommandArgument='<%#Eval("OrderId") %>' Text="Check Detail"
                         CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>--%>
                <%-- <asp:TemplateField HeaderText="DiscountRate" SortExpression="DiscountRate">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# string.Format("{0:0.###}", Eval("DiscountRate")) %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# string.Format("{0:0.### %}", Eval("DiscountRate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                <%-- <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />--%>
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
            </div>
        <br/>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="auto-style1">
                    Order Total:
                    </td>
                <td>
            <asp:Label ID="lblTatil" runat="server" Style="font-weight: bold; color: #cc0033">0</asp:Label></td>
                <td style="text-align: right">
                <div id="updatebutton" runat="server" visible="false">   <asp:LinkButton ID="LBUpdate" runat="server" Font-Bold="True" Font-Size="11pt" OnClick="LBUpdate_Click">Update</asp:LinkButton></div>
                </td>
                <td style="text-align: right">
                    <asp:LinkButton ID="LBConfirm" runat="server" Font-Bold="True" Font-Size="11pt" OnClick="Confirm_Click" >Confirm</asp:LinkButton>
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

