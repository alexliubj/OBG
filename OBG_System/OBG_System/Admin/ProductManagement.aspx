<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="ProductManagement.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" OnMenuItemClick="NavigationMenu_MenuItemClick">
                    <Items>
                        <asp:MenuItem  Text="Wheels"></asp:MenuItem>
                        <asp:MenuItem  Text="Tires"></asp:MenuItem>         
                        <asp:MenuItem  Text="Accessories"></asp:MenuItem>
                    </Items>
                </asp:Menu>
<asp:GridView ID="GridView1" runat="server"  GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" Visible="False">
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style" SortExpression="Style">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" SortExpression="Size">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcd" SortExpression="Pcd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Finish" SortExpression="Finish">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Offset" SortExpression="Offset">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Seat" SortExpression="Seat">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Bore" SortExpression="Bore">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onhand" SortExpression="Onhand">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />--%>
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

    <asp:GridView ID="GridView2" runat="server"  GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TireId" ForeColor="#333333"  OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
         OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" Visible="False">
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="TireId" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />
            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" SortExpression="Size">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Width" SortExpression="Width">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("rimWith") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("rimWith") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Height" SortExpression="Height">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("rimHeight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("rimHeight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pricing") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Season" SortExpression="Season">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Season") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />--%>
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


    <asp:GridView ID="GridView3" runat="server"  GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" ForeColor="#333333"  OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
         OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
        OnRowUpdating="GridView3_RowUpdating" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDataBound="GridView3_RowDataBound" Visible="False">
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="AccId" HeaderText="Acc ID" InsertVisible="False" ReadOnly="True" SortExpression="AccId" />
            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Img" SortExpression="Img">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Des" SortExpression="Des">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Pricing") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />--%>
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
</asp:Content>

