<%@ Page Title="View All Tires" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiresAll.aspx.cs" Inherits="Products_tireall" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div id="TiresFilter" runat="server" visible="true">

        <fieldset class="TiresInfo">
            <legend>Choose your tires</legend>
            <table>
                <tr>
                    <td class="style2">
                        <asp:Label ID="partLabel" runat="server">Brand:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource1" DataTextField="Brand"
                            DataValueField="Brand" CssClass="CBLayout" ID="ChkBrand" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
                    </td>

                </tr>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct Brand FROM [Tires]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct size FROM [Tires]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct season FROM [Tires]"></asp:SqlDataSource>
                <tr>
                    <td>
                        <asp:Label ID="SizeLabel" runat="server">Size:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource2" DataTextField="Size"
                            DataValueField="Size" CssClass="CBLayout" ID="ChkSize" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged" />



                    </td>
                </tr>




                <tr>
                    <td>
                        <asp:Label ID="SeasonLabel" runat="server">Season:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource3" DataTextField="Season"
                            DataValueField="Season" CssClass="CBLayout" ID="ChkSeason" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
                    </td>

                </tr>

            </table>
        </fieldset>
    </div>



    <asp:GridView ID="GridView2" runat="server" GridLines="None"
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="TireId" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
        OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating"
        OnRowCancelingEdit="GridView2_RowCancelingEdit"
        OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView2_RowDataBound"
        AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
           
            <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
      
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
  
            <asp:TemplateField HeaderText="Brand" ItemStyle-HorizontalAlign="Center" SortExpression="Brand">
       
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
   
                <ItemTemplate>
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' onclick="DisplayImageInNewWidnow();"></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Size" ItemStyle-HorizontalAlign="Center" SortExpression="Size">
              
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
   
            <asp:TemplateField HeaderText="Pricing" ItemStyle-HorizontalAlign="Center" SortExpression="Pricing">
         
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Season" ItemStyle-HorizontalAlign="Center" SortExpression="Season">
           
                <ItemTemplate>
                    <asp:Label ID="SeasonLabel" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center" SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg" OnClick="AddBt_Click"></asp:ImageButton>
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

