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
                    <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'  OnClientClick = "return LoadDiv(this.src);"></asp:ImageButton>
                <style type="text/css">
     body
     {
        margin:0;
        padding:0;
        height:100%;
     }
     .modal
     {
        display: none;
        position: absolute;
        top: 0px;
        left: 0px;
        background-color:black;
        z-index:100;
        opacity: 0.8;
        filter: alpha(opacity=60);
        -moz-opacity:0.8;
        min-height: 100%;
     }
     #divImage
     {
        display: none;
        z-index: 1000;
        position: fixed;
        top: 0;
        left: 0;
        background-color:White;
        height: 430px;
        width: 500px;
        padding: 30px;
        border: solid 1px black;
     }
   </style>

                    <div id="divBackground" class="modal">
</div>
<div id="divImage">
    <table style="height: 100%; width: 100%">
        <tr>
            <td valign="middle" align="center">
                <img id="imgLoader" alt=""
                 src="Pictures/1.png" />
                <img id="imgFull" alt="" src=""
                 style="display: none;
                height: 400px;width: 490px" />
            </td>
        </tr>
        <tr>
            <td align="center" valign="bottom">
                <input id="btnClose" type="button" value="close"
                 onclick="HideDiv()"/>
            </td>
        </tr>
    </table>
</div>


                    <script type="text/javascript">
                        function LoadDiv(url) {
                            var img = new Image();
                            var bcgDiv = document.getElementById("divBackground");
                            var imgDiv = document.getElementById("divImage");
                            var imgFull = document.getElementById("imgFull");
                            var imgLoader = document.getElementById("imgLoader");

                            imgLoader.style.display = "block";
                            img.onload = function () {
                                imgFull.src = img.src;
                                imgFull.style.display = "block";
                                imgLoader.style.display = "none";
                            };
                            img.src = url;
                            var width = document.body.clientWidth;
                            if (document.body.clientHeight > document.body.scrollHeight) {
                                bcgDiv.style.height = document.body.clientHeight + "px";
                            }
                            else {
                                bcgDiv.style.height = document.body.scrollHeight + "px";
                            }

                            imgDiv.style.left = (width - 650) / 2 + "px";
                            imgDiv.style.top = "20px";
                            bcgDiv.style.width = "100%";

                            bcgDiv.style.display = "block";
                            imgDiv.style.display = "block";
                            return false;
                        }
                        function HideDiv() {
                            var bcgDiv = document.getElementById("divBackground");
                            var imgDiv = document.getElementById("divImage");
                            var imgFull = document.getElementById("imgFull");
                            if (bcgDiv != null) {
                                bcgDiv.style.display = "none";
                                imgDiv.style.display = "none";
                                imgFull.style.display = "none";
                            }
                        }
</script>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Des" ItemStyle-HorizontalAlign="Center" SortExpression="Des">
                <ItemTemplate>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" ItemStyle-HorizontalAlign="Center" SortExpression="Pricing">
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
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

