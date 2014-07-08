<%@ Page Title="View Tires By Vehicle" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiresByVehicle.aspx.cs" Inherits="Products_tireByVehicle" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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


<asp:GridView ID="GridView5" runat="server"  GridLines="None" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="TireId" ForeColor="#333333"  OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
          OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating" 
        OnRowCancelingEdit="GridView2_RowCancelingEdit" 
        OnRowDataBound="GridView2_RowDataBound">
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <%--<asp:BoundField DataField="TireId" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />--%>
            

            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                   <asp:Image CssClass="Imagehub" ID="ImageLable" runat="server" ImageUrl='<%# Eval("Image") %>' ></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Size" SortExpression="Size">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Width" SortExpression="rimWith">--%>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("rimWith") %>'></asp:TextBox>
                </EditItemTemplate>--%>
               <%-- <ItemTemplate>
                    <asp:Label ID="WidthLabel" runat="server" Text='<%# Bind("rimWith") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Height" SortExpression="rimHeight">--%>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("rimHeight") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <%--<ItemTemplate>
                    <asp:Label ID="HeightLabel" runat="server" Text='<%# Bind("rimHeight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pricing") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Season" SortExpression="Season">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Season") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SeasonLabel" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ADD" SortExpression="ADD">
            <ItemTemplate>
            <asp:ImageButton ID="AddBt" runat="server" ImageUrl="../Pictures/images.jpg" OnClick="AddBt_Click"></asp:ImageButton>
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

