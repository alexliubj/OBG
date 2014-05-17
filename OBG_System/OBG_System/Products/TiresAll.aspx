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
                        <asp:Label ID="StyleLabel" runat="server" >PartNo:</asp:Label>
                    </td>
                    <td>
                         <asp:CheckBox ID="StyleCheck1" runat="server" Text='Europa' /></td><td>
                         <asp:CheckBox ID="StyleCheck2" runat="server" Text='R117A' /></td><td>
                         <asp:CheckBox ID="StyleCheck3" runat="server" Text='R133A' /></td><td>
                         <asp:CheckBox ID="StyleCheck4" runat="server" Text='R152' /></td><td>
                         <asp:CheckBox ID="StyleCheck5" runat="server" Text='R115' /></td><td>
                         <asp:CheckBox ID="StyleCheck6" runat="server" Text='Numesis' /></td><td>
                         <asp:CheckBox ID="StyleCheck7" runat="server" Text='R142' /></td><td>
                       
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="BrandLabel" runat="server">Size:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="BrandCheck1" runat="server" Text='Fast Wheels'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="BrandCheck2" runat="server" Text='Replika'></asp:CheckBox></td><td>
                        
                        
                    </td>
                </tr>

               

                <tr>
                    <td>
                        <asp:Label ID="SizeLabel" runat="server" >Width:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="SizeCheck1" runat="server" Text='18*8.0'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SizeCheck2" runat="server" Text='18*8.5'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SizeCheck3" runat="server" Text='16*7.0'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SizeCheck4" runat="server" Text='19*8.5'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="SizeCheck5" runat="server" Text='17*8.0'></asp:CheckBox></td><td>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="PcdLabel" runat="server" >Height:</asp:Label>
                    </td>
                    <td>
                       
                        <asp:CheckBox ID="PCDCheck1" runat="server" Text='5*112/114.3'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="PCDCheck2" runat="server" Text='5*112'></asp:CheckBox></td><td>
                        
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="FinishLabel" runat="server" >Season:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="FinishCheck1" runat="server" Text='Flat Black'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="FinishCheck2" runat="server" Text='Hyper Silver'></asp:CheckBox></td><td>
                        <asp:CheckBox ID="FinishCheck3" runat="server" Text='Santin Black'></asp:CheckBox></td><td>
                       
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
                 <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
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

