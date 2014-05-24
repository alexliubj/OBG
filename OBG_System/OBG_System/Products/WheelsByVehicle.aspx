<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsByVehicle.aspx.cs" Inherits="Products_viewByVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--<asp:DataList ID="DataListDepartMent" runat="server">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="LinkDepartMent"
                        
                        Text='<%# Eval("CategoryName")%>'></asp:HyperLink>
                </ItemTemplate>
                <HeaderTemplate>
        <table border="0" cellspacing="0">
            <tr>
                <td style="background-image: url(Image/left2.gif); width:166px; height:26px;">Choose Vehicle->
                </td>
            </tr>
        </table>
    </HeaderTemplate>
            </asp:DataList>--%>
            <div id="TiresFilter" runat="server" visible="true">
       
        <fieldset class="TiresInfo">
            <legend>Choose your vehicles</legend>
            <table>
                <tr>
                    
                    <td>
                         <asp:CheckBox ID="VehicleCheck1" runat="server" Text='All' /></td><td>
                         <asp:CheckBox ID="VehicleCheck2" runat="server" Text='Ford' /></td><td>
                         <asp:CheckBox ID="VehicleCheck3" runat="server" Text='BMW' /></td><td>
                         <asp:CheckBox ID="VehicleCheck4" runat="server" Text='Benz' /></td><td>
                         <asp:CheckBox ID="VehicleCheck5" runat="server" Text='Toyota' /></td><td>
                         <asp:CheckBox ID="VehicleCheck6" runat="server" Text='Honda' /></td><td>
                         <asp:CheckBox ID="VehicleCheck7" runat="server" Text='Hyundai' /></td><td>
                         <asp:CheckBox ID="VehicleCheck8" runat="server" Text='Chevrolet' /></td><td>
                         <asp:CheckBox ID="VehicleCheck9" runat="server" Text='Audi' /></td><td>
                         <asp:CheckBox ID="VehicleCheck10" runat="server" Text='BUICK' /></td><td>
                    </td>
                
                </tr>
               
            </table>
        </fieldset>
    </div>


    <asp:GridView ID="GridView4" runat="server"  GridLines="None" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDataBound="GridView1_RowDataBound"
        OnRowCommand="GridView4_RowCommand>
        
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <%--<asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />--%>
            
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                   <asp:Image ID="ImageLable" runat="server" ImageUrl='<%# Eval("Image") %>' ></asp:Image>
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
                  <asp:TemplateField HeaderText="ADD" SortExpression="ADD">
            <ItemTemplate>
            <asp:ImageButton ID="AddBt" runat="server" ImageUrl="../Pictures/images.jpg" OnClick="AddBt_Click"></asp:ImageButton>
            </ItemTemplate>
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />--%>
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

