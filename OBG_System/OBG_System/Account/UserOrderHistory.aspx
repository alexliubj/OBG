<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserOrderHistory.aspx.cs" Inherits="Default2" ErrorPage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style2
        {
            width: 123px;
        }
        .auto-style3
        {
            width: 102px;
        }
        .auto-style4
        {
            width: 120px;
        }
        #updatebutton
        {
            width: 116px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <br />
    <p>Your orders:</p>
    <div runat="server" align ="center">
    <asp:GridView ID="GridView1" runat="server" GridLines="Both"  AllowPaging="True" AllowSorting="true" Width="80%" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
           OnPageIndexChanging="GridView1_PageIndexChanging"
         OnSorting="GridView1_Sorting">
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
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("OrderDate","{0:MM/dd/yyyy}") %>'></asp:Label>
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
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" ItemStyle-HorizontalAlign="Center" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" Visible="true" />
                <asp:BoundField DataField="ProductId" HeaderText="ProductId"  InsertVisible="False" ReadOnly="True" SortExpression="ProductId" Visible="false" />
                <asp:TemplateField HeaderText="ProductID" SortExpression="ProductID">
                    <ItemTemplate>
                        <asp:Label ID="LBProductID" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
                <ItemTemplate>
                    <asp:Image ID="imageLabel" class="Imagehub" runat="server" ImageUrl='<%# Eval("Image") %>'></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Width="20" Text='<%# Bind("Qty") %>'></asp:TextBox>
                    </ItemTemplate>
                    <%--                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                        </ItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Price" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DiscountRate","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("finalPrice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" Visible="true" ButtonType="Button" DeleteText="Delete" ControlStyle-CssClass="myButton" />--%>
                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" ItemStyle-HorizontalAlign="Center" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this order?');" CssClass="myButton" />
                </ItemTemplate>
            </asp:TemplateField>
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
                <td class="auto-style2" >
                   <asp:Label ID="LabelTotalText" runat="server" Font-Bold="true" Font-Size="Large" align="left" Text="Order Total: "></asp:Label>
                    </td>
                <td>
                    <asp:Label ID="lblTatil" Visible="true" Font-Bold="true" Font-Size="Large" align="left" runat="server" ForeColor="#FF8080"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style3"><asp:Label ID="lbHST" runat="server" Font-Bold="true" Font-Size="Large" Text="HST: "></asp:Label><asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Large" Text="HST: "></asp:Label>
                    </td>
                <td><asp:Label ID="Label2" Visible="true" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="#FF8080" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style2"><asp:Label ID="sfLabel" runat="server" Font-Bold="true" Font-Size="Large" Text="Shipping Fee: "></asp:Label>
                    </td>
                <td><asp:Label ID="Label10" Visible="true" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="#FF8080" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style4"><asp:Label ID="Totalprice" runat="server" Font-Bold="true" Font-Size="Large" Text="Total Price: "></asp:Label></td>
                <td><asp:Label ID="Label7" Visible="true" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="#FF8080" ></asp:Label></td>
                </tr>
                <tr text-align: right">
                    <td/><td/><td/><td/><td/><td/>
                    <tr/><td/><td/><td/><td/><td/><td/>
                    <td style="text-align: right">
                <div id="updatebutton" runat="server" visible="false" > <asp:LinkButton ID="LBUpdate" runat="server" Font-Bold="True" Font-Size="11pt" OnClick="LBUpdate_Click">Update</asp:LinkButton></div>
                </td>
                <td style="text-align: right">
                    <asp:LinkButton ID="LBConfirm" runat="server" Font-Bold="True" Font-Size="11pt" OnClick="Confirm_Click" >Confirm</asp:LinkButton>
                    </td>
                    
            </tr>
        </table>
        <br/>
    </div>
</asp:Content>

