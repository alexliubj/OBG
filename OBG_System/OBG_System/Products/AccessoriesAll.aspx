<%@ Page Title="View All Accessories" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccessoriesAll.aspx.cs" Inherits="Products_accAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="TiresFilter" runat="server" visible="true">

        <fieldset class="AccInfo">
            <legend>Choose your Accessory</legend>
            <table>
                <tr>
                    <td class="style2">
                        <asp:Label ID="NameLabel" runat="server">Product Name:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource1" DataTextField="Name"
                            DataValueField="Name" CssClass="CBLayout" ID="ChkName" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="7" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
                    </td>

                </tr>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct name FROM [Accessories]"></asp:SqlDataSource>
            </table>
        </fieldset>
    </div>



    <asp:GridView ID="GridView6" runat="server" GridLines="None" AllowPaging="True" 
    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" 
    ForeColor="#333333"
        AllowSorting="true"  OnPageIndexChanging="GridView6_PageIndexChanging" OnSorting="GridView6_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="AccId" HeaderText="Acc ID" InsertVisible="False" ReadOnly="True" SortExpression="AccId" visible="false"/>

            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <ItemTemplate>
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'  onclick="DisplayImageInNewWidnow();"></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Des" SortExpression="Des">
                <ItemTemplate>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
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
</asp:Content>

