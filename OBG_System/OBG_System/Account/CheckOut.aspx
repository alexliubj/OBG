<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="CKGridView" runat="server" GridLines="Both" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333"
                Visible="true" OnPageIndexChanging="CKGridView_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" SortExpression="OrderID" Visible="true" />
                   <%-- <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" Visible="false" />--%>
                    <asp:TemplateField HeaderText="ProductID" ItemStyle-HorizontalAlign="Center" Visible="true" SortExpression="ProductID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
                <ItemTemplate>
                    <asp:Image ID="imageLabel" class="Imagehub" runat="server" ImageUrl='<%# Eval("Image") %>'></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
                      <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="ProductType" ItemStyle-HorizontalAlign="Center" SortExpression="ProductType">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProductType") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="qty">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("qty") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="Price" runat="server" Text='<%# Convert.ToDouble(Eval("Price")).ToString("c2") %>'></asp:Label>
                   
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Price" ItemStyle-HorizontalAlign="Center" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="ItemPrice" runat="server" Text='<%# Convert.ToDouble(Eval("itemTotal")).ToString("c2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="DiscountRate" SortExpression="DiscountRate">
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
    <asp:Label ID="LabelTotalText" runat="server"  align="Right" Text="Order Total: "></asp:Label>
    <asp:Label ID="LabelTotalPrice" Visible="true" align="Right" runat="server" ForeColor="#FF8080" ></asp:Label>
    <table>
        <tr>
            <td>
                     <asp:Label ID="lbPO" runat="server" AssociatedControlID="txtPO">PO:</asp:Label>                         
                     <asp:TextBox ID="txtPO" runat="server" CssClass="textEntry" ></asp:TextBox>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
    <asp:Button ID="confirmBt" runat="server" align="Right" Text="Confirm" ControlStyle-CssClass="myButton" OnClick="BtnConfirm_Click" />
                </td>
            </tr>
        </table>
</asp:Content>

