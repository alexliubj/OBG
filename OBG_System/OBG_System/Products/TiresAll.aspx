<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiresAll.aspx.cs" Inherits="Products_tireall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="TiresFilter" runat="server" visible="true">
       
        <fieldset class="TiresInfo">
            <legend>Choose your tires</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="partLabel" runat="server" >PartNo:</asp:Label>
                    </td>
                    <td>
                         <asp:CheckBox ID="partCheck1" runat="server" Text='All' /></td><td>
                         <asp:CheckBox ID="partCheck2" runat="server" Text='Europa' /></td><td>
                         <asp:CheckBox ID="partCheck3" runat="server" Text='R117A' /></td><td>
                         <asp:CheckBox ID="partCheck4" runat="server" Text='R133A' /></td><td>
                         <asp:CheckBox ID="partCheck5" runat="server" Text='R152' /></td><td>
                         <asp:CheckBox ID="partCheck6" runat="server" Text='R115' /></td><td>
                         <asp:CheckBox ID="partCheck7" runat="server" Text='Numesis' /></td><td>
                         <asp:CheckBox ID="partCheck8" runat="server" Text='R142' /></td><td>
                       
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="SizeLabel" runat="server">Size:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="SizeCheck1" runat="server" Text='All'></asp:CheckBox></td><td> 
                        <asp:CheckBox ID="SizeCheck2" runat="server" Text='Fast Wheels'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SizeCheck3" runat="server" Text='Replika'></asp:CheckBox></td><td>
                        
                        
                    </td>
                </tr>

               

                <tr>
                    <td>
                        <asp:Label ID="WidthLabel" runat="server" >Width:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="WidthChcek1" runat="server" Text='All'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="WidthChcek2" runat="server" Text='18*8.0'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="WidthChcek3" runat="server" Text='18*8.5'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="WidthChcek4" runat="server" Text='16*7.0'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="WidthChcek5" runat="server" Text='19*8.5'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="WidthChcek6" runat="server" Text='17*8.0'></asp:CheckBox></td><td>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="HeightLabel" runat="server" >Height:</asp:Label>
                    </td>
                    <td>
                       <asp:CheckBox ID="HeightCheck1" runat="server" Text='All'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="HeightCheck2" runat="server" Text='5*112/114.3'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="HeightCheck3" runat="server" Text='5*112'></asp:CheckBox></td><td>
                        
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="SeasonLabel" runat="server" >Season:</asp:Label>
                    </td>
                    <td>
                    <asp:CheckBox ID="SeasonCheck1" runat="server" Text='All'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SeasonCheck2" runat="server" Text='Flat Black'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SeasonCheck3" runat="server" Text='Hyper Silver'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SeasonCheck4" runat="server" Text='Santin Black'></asp:CheckBox></td><td>
                       
                    </td>
                </tr>
               
            </table>
        </fieldset>
    </div>



<asp:GridView ID="GridView2" runat="server"  GridLines="None" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="TireId" ForeColor="#333333"  OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
          OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating" 
        OnRowCancelingEdit="GridView2_RowCancelingEdit" 
        OnRowDataBound="GridView2_RowDataBound">
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="TireId" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />
            <asp:TemplateField HeaderText="Choose">

             <ItemTemplate>

            <asp:CheckBox id="cbxId" runat="Server" />

            </ItemTemplate>

    </asp:TemplateField>
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
                 <%--<asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
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

