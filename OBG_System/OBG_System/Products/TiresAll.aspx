<%@ Page Title="View All Tires" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiresAll.aspx.cs" Inherits="Products_tireall" %>

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
                            DataValueField="Brand" CssClass="CBLayout" ID="ChkBrand" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
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
                            DataValueField="Size" CssClass="CBLayout" ID="ChkSize" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="chk_SelectedIndexChanged" />



                    </td>
                </tr>




                <tr>
                    <td>
                        <asp:Label ID="SeasonLabel" runat="server">Season:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource3" DataTextField="Season"
                            DataValueField="Season" CssClass="CBLayout" ID="ChkSeason" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
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
        OnRowDataBound="GridView2_RowDataBound"
        AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="TireId" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />
            <asp:TemplateField HeaderText="Choose">

             <ItemTemplate>

            <asp:CheckBox id="cbxId" runat="Server" />

            </ItemTemplate>

    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Image" SortExpression="Image">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>--%>
            <%--<ItemTemplate>
                   <asp:Image ID="ImageLable" runat="server" ImageUrl='<%# Eval("Image") %>' ></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' onclick="DisplayImageInNewWidnow();"></asp:Image>
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
            <%-- <asp:TemplateField HeaderText="Width" SortExpression="rimWith">--%>
            <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("rimWith") %>'></asp:TextBox>
                </EditItemTemplate>--%>
            <%--<ItemTemplate>
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
                <%-- <EditItemTemplate>
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

