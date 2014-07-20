<%@ Page Title="View Wheels By Vehicle" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsByVehicle.aspx.cs" Inherits="Products_viewByVehicle" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
            <div id ="PermissionDenied" runat="server" visible="false">
    This section currently is empty.    
    </div>
            <div id="TiresFilter" runat="server" visible="true">
       
        <fieldset class="TiresInfo">
            <legend>Choose your vehicles</legend>
            <table>
                <tr>
                    
                    <td>
                         <asp:RadioButtonList DataSourceID="SqlDataSource1" DataTextField="VehicleName"
                            DataValueField="Vehicleid"
                            CssClass="CBLayout" ID="rdVehicle" runat="server" AutoPostBack="true" TextAlign="Right" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chk_SelectedIndexChanged">
                        </asp:RadioButtonList>
                    </td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="select * from [vehicles]"></asp:SqlDataSource>
                </tr>
               
            </table>
        </fieldset>
    </div>

    <div id="divWheel" runat="server" visible="true">
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
    <asp:GridView ID="GridView4" runat="server"   GridLines="Both"  align="center"
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDataBound="GridView1_RowDataBound"
        OnRowCommand="GridView1_RowCommand"
        AllowSorting="true"  OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
        >
        
    <AlternatingRowStyle BackColor="White" />
            <Columns>
       
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
            
                <ItemTemplate>
                   <asp:ImageButton class="Imagehub" ID="ImageLable" runat="server" ImageUrl='<%# Eval("Image") %>' OnClientClick = "return LoadDiv(this.src);" ></asp:ImageButton>
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
                   <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js" type="text/javascript">
                 </script>
                <script>
                    $(function () {
                        $("img.Imagehub").click(function () {


                            var background = $("<div></div>");

                            $(background).attr("id", "overlaybackground").animate({
                                'opacity': '.6'
                            }, 1000).css({
                                "width": $(document).width(),
                                'height': $(document).height(),
                                'background': '#656565',
                                'z-index': '100',
                                'position': 'absolute',
                                'top': '0px',
                                'left': '0px'
                            });
                            $("body").append(background);



                            var newimage = $("<img/>");
                            var width = $('body').width();
                            $(newimage).attr("src", $(this).attr("src")).attr("id", "largeimage").css({
                                'left': width / 2 - 200,
                                'top': '360px',
                                'position': 'absolute',
                                'z-index': '300',
                                'display': 'none',
                                'width': '300px',
                                'height': '300px',
                                'border': '30px solid #fff'
                            });
                            $("body").append(newimage);



                            $("#largeimage").fadeIn(2000, function () {
                                $(this).click(function () {
                                    $(this).fadeOut(1000);
                                    $("div#overlaybackground").fadeOut(1000, function () {
                                        $(this).remove();
                                    })
                                })
                            })


                        });
                    })
</script>--%>
                </ItemTemplate>
                 
            </asp:TemplateField>
                <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="StyleTextBox" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style" ItemStyle-HorizontalAlign="Center" SortExpression="Style">

                <ItemTemplate>
                    <asp:Label ID="StyleLabel" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Brand" ItemStyle-HorizontalAlign="Center" SortExpression="Brand">
           
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" ItemStyle-HorizontalAlign="Center" SortExpression="Size">
 
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcd" ItemStyle-HorizontalAlign="Center" SortExpression="Pcd">
      
                <ItemTemplate>
                    <asp:Label ID="PcdLabel" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Finish" ItemStyle-HorizontalAlign="Center" SortExpression="Finish">
       
                <ItemTemplate>
                    <asp:Label ID="FinishLabel" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Offset(mm)" ItemStyle-HorizontalAlign="Center" SortExpression="Offset">
            
                <ItemTemplate>
                    <asp:Label ID="OffsetLabel" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Seat" ItemStyle-HorizontalAlign="Center" SortExpression="Seat">
 
                <ItemTemplate>
                    <asp:Label ID="SeatLabel" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Bore(mm)" ItemStyle-HorizontalAlign="Center" SortExpression="Bore">
  
                <ItemTemplate>
                    <asp:Label ID="BoreLabel" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Weight(LBS)" ItemStyle-HorizontalAlign="Center" SortExpression="Weight">
     
                <ItemTemplate>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onhand" ItemStyle-HorizontalAlign="Center" SortExpression="Onhand">
     
                <ItemTemplate>
                    <asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Price" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
     
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial1" Visible="false" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial1" runat="server"  Visible="false" ForeColor="Red" Font-Bold="true" Text='<%# Bind("Special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Special Price" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="sPriceLabel" runat="server" ForeColor='<%#  (float)Convert.ToSingle(((Label)((GridViewRow)Container).FindControl("LBSpecial1")).Text)<1?System.Drawing.Color.Red:System.Drawing.Color.Black%>'  Font-Bold='<%# ((Label)((GridViewRow)Container).FindControl("sPriceLabel")).ForeColor==System.Drawing.Color.Red?true:false%>'   Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="4"></asp:TextBox>
                </ItemTemplate>
                
           <%-- </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>                
                        <asp:LinkButton ID="DesBt"  Width="30" runat="server"  CommandName="DesVClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' Text="Description" />         --%>
                   <%--<div id="desDiv" style="display:none;z-index:2000;position:absolute;left:3px;top:23px;border:1px solid #06c;padding:0px;background:#fff;"><asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("des") %>'></asp:Label></div>
                        <div style="background:#0184de;text-align:right;padding-right:3px;"><span style="width:12;border-width:0px;color:white;font-family:webdings; cursor:hand; left:-200;" onclick="hidden('desDiv')">r</span></div>
                    <script type="text/javascript" language="javascript">
                        function show(checkbox_list) {
                            var checkbox_list = document.getElementById(checkbox_list);
                            checkbox_list.style.display = "block";
                        }
                        function hidden(checkbox_list) {
                            var checkbox_list = document.getElementById(checkbox_list);
                            checkbox_list.style.display = "none";
                        }
</script>     --%>
                   <%-- </ItemTemplate>  --%> 
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center" SortExpression="ADD">
            <ItemTemplate>
            <asp:ImageButton ID="AddBt" runat="server" ImageUrl="../Pictures/images.jpg"  OnClientClick="return confirm('Add the wheel to the shoppingcart?')"  CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'></asp:ImageButton>
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
    <div id="divDes" runat="server" visible="false">
         <fieldset class="accountInfo">
            <legend>Wheel Description</legend>
         <asp:Label ID="lblDes" runat="server" ></asp:Label>
             </fieldset>
         </div>
</asp:Content>

