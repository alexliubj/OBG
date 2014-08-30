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
    <div id ="PermissionDenied" runat="server" visible="false">
    This section currently is empty.    
    </div>
    <div id="TiresFilter" runat="server" visible="true">

        <fieldset class="TiresInfo">
            <legend>Choose your tires</legend>
            <table>
                <tr>
                    <td class="style2">
                        <asp:Label ID="partLabel" runat="server">Brand:  </asp:Label>
                    </td>
                    <%--<td class="auto-style6">
                        <asp:LinkButton ID="Button2" runat="server" Text="All"  OnClick="Button2_Click" />
                        </td>--%>
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
                        <asp:Label ID="SizeLabel" runat="server">Size:  </asp:Label>
                    </td>
                    <%--<td class="auto-style6">
                        <asp:LinkButton ID="Button1" runat="server" Text="All"  OnClick="Button3_Click" />
                        </td>--%>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource2" DataTextField="Size"
                            DataValueField="Size" CssClass="CBLayout" ID="ChkSize" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged" />



                    </td>
                </tr>




                <tr>
                    <td>
                        <asp:Label ID="SeasonLabel" runat="server">Season:  </asp:Label>
                    </td>
                    <%--<td class="auto-style6">
                        <asp:LinkButton ID="Button3" runat="server" Text="All"  OnClick="Button4_Click"/>
                        </td>--%>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource3" DataTextField="Season"
                            DataValueField="Season" CssClass="CBLayout" ID="ChkSeason" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged" />
                    </td>

                </tr>
                <tr>
                    <asp:LinkButton ID="Button4" runat="server" Text="Reset" OnClick="Button1_Click" />
                    </tr>

            </table>
        </fieldset>
    </div>


    <div id="divtire" runat="server" visible="true">
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
    <asp:GridView ID="GridView2" runat="server" GridLines="Both" align="center"
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="TireId" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
        OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating"
        OnRowCancelingEdit="GridView2_RowCancelingEdit"
        OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView2_RowDataBound"
        AllowSorting="false" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
           
            <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
      
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
  
            <asp:TemplateField HeaderText="Brand" ItemStyle-HorizontalAlign="Center" SortExpression="Brand">
       
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
   
                <ItemTemplate>
                    <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' OnClientClick = "return LoadDiv(this.src);" Height="100px" Width="100px"></asp:ImageButton>
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
                height: 400px;width: 420px" />
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

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Size" ItemStyle-HorizontalAlign="Center" SortExpression="Size">
              
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Season" ItemStyle-HorizontalAlign="Center" SortExpression="Season">
           
                <ItemTemplate>
                    <asp:Label ID="SeasonLabel" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="Pricing">
         
                <ItemTemplate>
                    <asp:Label ID="PricingLabel" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial1" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial1" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Bind("Special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="sPriceLabel" runat="server"  Visible='<%#  (float)Convert.ToSingle(((Label)((GridViewRow)Container).FindControl("LBSpecial1")).Text)<1?true:false%>'   ForeColor='<%#  (float)Convert.ToSingle(((Label)((GridViewRow)Container).FindControl("LBSpecial1")).Text)<1?System.Drawing.Color.Red:System.Drawing.Color.Black%>'  Font-Bold='<%# ((Label)((GridViewRow)Container).FindControl("sPriceLabel")).ForeColor==System.Drawing.Color.Red?true:false%>'  Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                <asp:Label ID="lbPrice" runat="server" Visible='<%#  (float)Convert.ToSingle(((Label)((GridViewRow)Container).FindControl("LBSpecial1")).Text)<1?false:true%>'  Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>

                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="4"></asp:TextBox>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>

            </asp:TemplateField>
             

            <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center" SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' OnClientClick="return confirm('Add the tire to the shoppingcart?')" ImageUrl="../Pictures/images.jpg" OnClick="AddBt_Click"></asp:ImageButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
        </div>
</asp:Content>

