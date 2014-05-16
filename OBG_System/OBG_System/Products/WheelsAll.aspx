<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsAll.aspx.cs" Inherits="Products_wheelall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <div id="wheelFilter" runat="server" visible="true">
       
        <fieldset class="wheelInfo">
            <legend>Choose your wheels</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="StyleLabel" runat="server" >Style:</asp:Label>
                    </td>
                    <td>
                         <asp:CheckBox ID="StyleCheck1" runat="server" Text='Europa' />
                         <asp:CheckBox ID="StyleCheck2" runat="server" Text='R117A' />
                         <asp:CheckBox ID="StyleCheck3" runat="server" Text='R133A' />
                         <asp:CheckBox ID="StyleCheck4" runat="server" Text='R152' />
                         <asp:CheckBox ID="StyleCheck5" runat="server" Text='R115' />
                         <asp:CheckBox ID="StyleCheck6" runat="server" Text='Numesis' />
                         <asp:CheckBox ID="StyleCheck7" runat="server" Text='R142' />
                       
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="BrandLabel" runat="server">Brand:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="BrandCheck1" runat="server" Text='Fast Wheels'></asp:CheckBox>
                        <asp:CheckBox ID="BrandCheck2" runat="server" Text='Replika'></asp:CheckBox>
                        
                        
                    </td>
                </tr>

               

                <tr>
                    <td>
                        <asp:Label ID="SizeLabel" runat="server" >Size:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="SizeCheck1" runat="server" Text='18*8.0'></asp:CheckBox>
                        <asp:CheckBox ID="SizeCheck2" runat="server" Text='18*8.5'></asp:CheckBox>
                        <asp:CheckBox ID="SizeCheck3" runat="server" Text='16*7.0'></asp:CheckBox>
                        <asp:CheckBox ID="SizeCheck4" runat="server" Text='19*8.5'></asp:CheckBox>
                        <asp:CheckBox ID="SizeCheck5" runat="server" Text='17*8.0'></asp:CheckBox>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="PcdLabel" runat="server" >Pcd:</asp:Label>
                    </td>
                    <td>
                       
                        <asp:CheckBox ID="PCDCheck1" runat="server" Text='5*112/114.3'></asp:CheckBox>
                        <asp:CheckBox ID="PCDCheck2" runat="server" Text='5*112'></asp:CheckBox>
                        
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="FinishLabel" runat="server" >Finish:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="FinishCheck1" runat="server" Text='Flat Black'></asp:CheckBox>
                        <asp:CheckBox ID="FinishCheck2" runat="server" Text='Hyper Silver'></asp:CheckBox>
                        <asp:CheckBox ID="FinishCheck3" runat="server" Text='Santin Black'></asp:CheckBox>
                       
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="OffsetLabel" runat="server" >Offset:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="OffsetCheck1" runat="server" Text='+45'></asp:CheckBox>
                        <asp:CheckBox ID="OffsetCheck2" runat="server" Text='+50'></asp:CheckBox>
                        <asp:CheckBox ID="OffsetCheck3" runat="server" Text='+35'></asp:CheckBox>
                        <asp:CheckBox ID="OffsetCheck4" runat="server" Text='+42'></asp:CheckBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="SeatLabel" runat="server" >Seat:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="SeatCheck1" runat="server" Text='60°seat'></asp:CheckBox>
                        <asp:CheckBox ID="SeatCheck2" runat="server" Text='R13 Radius Seat'></asp:CheckBox>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="BoreLabel" runat="server" >Bore:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="BoreCheck1" runat="server" Text='73.1'></asp:CheckBox>
                        <asp:CheckBox ID="BoreCheck2" runat="server" Text='66.4'></asp:CheckBox>
                        
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="WeightLabel" runat="server" >Weight:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="WeightCheck1" runat="server" Text='23.1'></asp:CheckBox>
                        <asp:CheckBox ID="WeightCheck2" runat="server" Text='27.0'></asp:CheckBox>
                        <asp:CheckBox ID="WeightCheck3" runat="server" Text='19.0'></asp:CheckBox>
                        <asp:CheckBox ID="WeightCheck4" runat="server" Text='28.2'></asp:CheckBox>
                        <asp:CheckBox ID="WeightCheck5" runat="server" Text='24.8'></asp:CheckBox>
                        <asp:CheckBox ID="WeightCheck6" runat="server" Text='22.2'></asp:CheckBox>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="OnhandLabel" runat="server" >Onhand:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="OnhandCheck1" runat="server" Text='100+'></asp:CheckBox>
                        <asp:CheckBox ID="OnhandCheck2" runat="server" Text='99'></asp:CheckBox>
                        <asp:CheckBox ID="OnhandCheck3" runat="server" Text='66'></asp:CheckBox>
                        <asp:CheckBox ID="OnhandCheck4" runat="server" Text='62'></asp:CheckBox>
                        <asp:CheckBox ID="OnhandCheck5" runat="server" Text='56'></asp:CheckBox>
                       

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server">Price:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text='56'></asp:CheckBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" AssociatedControlID="CategoryId" Visible="false">Category ID:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CategoryId" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CategoryIdRequired" runat="server" ControlToValidate="CategoryId"
                            CssClass="failureNotification" ErrorMessage="CategoryId is required."
                            ToolTip="CategoryId is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
               
            </table>
        </fieldset>
    </div>

<asp:GridView ID="GridView1" runat="server"  GridLines="None" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDataBound="GridView1_RowDataBound">
        
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
            <asp:TemplateField HeaderText="Choose">

        <ItemTemplate>

            <asp:CheckBox id="cbxId" runat="Server" />

        </ItemTemplate>

    </asp:TemplateField>
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

