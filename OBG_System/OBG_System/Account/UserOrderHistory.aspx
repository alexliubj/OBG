<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserOrderHistory.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--<asp:DataList ID="DataListOrder" runat="server" RepeatColumns="1"  OnItemCommand="DataListOrder_ItemCommand" Width="100%" SkinID="DataListSkin">
                <ItemTemplate>
                  <tr><td colspan="5"><hr /></td></tr>
                        <tr>
                            <td>
                                <%#Eval("OrderId") %>
                            </td>
                            <td>
                                <%#Eval("OrderDate") %>
                            </td>
                            <td>
                                <%#Eval("Status") %>
                            </td>
                            <td>
                                <%#Eval("PO") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="LBsee" runat="server" CommandArgument='<%#Eval("OrderId") %>'>Detail</asp:LinkButton></td>
                        </tr>                
                </ItemTemplate>
                <HeaderTemplate>
                    <tr>
                        <td>
                            OrderID</td>
                        <td>
                           Date
                        </td>
                        <td>
                            status
                        </td>
                        <td>
                            po
                        </td>
                        <td>Detail</td>
                    </tr>
                </HeaderTemplate>
            </asp:DataList>--%>
            <br />
            <p>Your orders:</p>
    <asp:GridView ID="GridView1" runat="server" GridLines="Both" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333" 
          
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />

                <asp:TemplateField HeaderText="UserID" ItemStyle-HorizontalAlign="Center" Visible="false" SortExpression="UserID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelOrderID" runat="server"  Visible="false" Text='<%# Bind("OrderID") %>'></asp:Label>
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
                <asp:CommandField HeaderText="View Order Detail" ShowSelectButton="True" ButtonType="Button" SelectText="View Order Detail" ControlStyle-CssClass="myButton"/>
                
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








<div id="divOrderDetail" runat="server" visible="false">
            <br />
            <br />
            <p>Order Detail:</p>
    <asp:GridView ID="OrderGridView" runat="server" GridLines="None" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderId" ForeColor="#333333"
                Visible="true" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" Visible="true" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" Visible="false" />
                    <asp:TemplateField HeaderText="OrderDate" SortExpression="OrderDate">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="PO" SortExpression="PO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("DiscountRate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DiscountRate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <%--<asp:LinkButton ID="LBsee" runat="server" CommandArgument='<%#Eval("OrderID") %>'>查看订单信息</asp:LinkButton>--%>
                    
                    <%--<asp:TemplateField HeaderText="Detail">
                <ItemTemplate>
                    <asp:Button ID="LBsee" runat="server" CommandName="Detail" CommandArgument='<%#Eval("OrderId") %>' Text="Check Detail"
                         CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="DiscountRate" SortExpression="DiscountRate">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# string.Format("{0:0.###}", Eval("DiscountRate")) %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# string.Format("{0:0.### %}", Eval("DiscountRate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

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
</asp:Content>

