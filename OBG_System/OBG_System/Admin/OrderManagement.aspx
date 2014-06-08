<%@ Page Title="Order Management" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="OrderManagement.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div id="divOrder" runat="server" visible="true">
        <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" Visible="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
                <asp:TemplateField HeaderText="UserID" SortExpression="UserID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OrderDate" SortExpression="OrderDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OrderDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PO" SortExpression="PO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PO") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("PO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="View Order Detail" ShowSelectButton="True" ButtonType="Button" SelectText="View Order Detail"/>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this order?');" />
                    </ItemTemplate>
                </asp:TemplateField>
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

        <%--<asp:Button ID="btnAddWheel" runat="server" OnClick="Button1_Click" Text="Add new Wheel" />--%>
        <div id="divOrderDetail" runat="server" visible="false">
            <br />
            <br />
            <p>Order Detail:</p>
            <asp:GridView ID="GridView2" runat="server" GridLines="None" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderID" ForeColor="#333333"
                Visible="true" OnPageIndexChanging="GridView2_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" Visible="false" />
                    <asp:TemplateField HeaderText="ProductID" SortExpression="ProductID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="ProductType" SortExpression="ProductType">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProductType") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("qty") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
    </div>
</asp:Content>

