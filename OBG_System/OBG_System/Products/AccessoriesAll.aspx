<%@ Page Title="View All Accessories" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccessoriesAll.aspx.cs" Inherits="Products_accAll" ErrorPage="~/mycustompage.aspx"%>

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


    <div id="divacc" runat="server" visible="true">
                <asp:Label ID="Label2" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>
    <asp:GridView ID="GridView6" runat="server" GridLines="Both" AllowPaging="True" align="center"
    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" 
    ForeColor="#333333"
        AllowSorting="true" OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="GridView6_PageIndexChanging" OnSorting="GridView6_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="AccId" HeaderText="Acc ID" InsertVisible="False" ReadOnly="True" SortExpression="AccId" visible="false"/>

            <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
                <ItemTemplate>
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'  onclick="DisplayImageInNewWidnow();"></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Des" ItemStyle-HorizontalAlign="Center" SortExpression="Des">
                <ItemTemplate>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" ItemStyle-HorizontalAlign="Center" SortExpression="Pricing">
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="1"></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center" SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
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
        </div>
</asp:Content>

