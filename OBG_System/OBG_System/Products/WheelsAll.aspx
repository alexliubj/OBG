<%@ Page Title="View All Wheels" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsAll.aspx.cs" Inherits="Products_wheelall" ErrorPage="~/mycustompage.aspx"%>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
    <style type="text/css">
        .style1
        {
            width: 65px;
        }

        .style11
        {
            height: 24px;
        }

        .style12
        {
            width: 54px;
            height: 24px;
        }

        .auto-style3
        {
            height: 28px;
            width: 61px;
        }

        .auto-style6
        {
            width: 45px;
        }
        .auto-style8
        {
            width: 1px;
        }
        .auto-style9
        {
            width: 61px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/jquery-1.2.6.js" type="text/javascript"></script>

   <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('#chkSelectAll').click(
             function () {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
        });

    </script>

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script> --%>
<%--<script type="text/javascript">
    $(function () {
        $("#<%=chkSelectAll.ClientID %>").click(function () {
        $("#<%=chkSize.ClientID %> input[type=checkbox]").attr("checked", $("#<%=chkSelectAll.ClientID %>").is(":checked"));
});
});
</script> --%>

      <div id ="PermissionDenied" runat="server" visible="false">
    This section currently is empty.    
    </div>

    <div id="wheelFilter" runat="server" visible="true">
        
        <fieldset class="wheelInfo">
            <legend>Choose your wheels</legend>
            <table style="width: 852px">
                <tr>
                    <td class="auto-style9" >
                        <asp:Label ID="sizeLB"  runat="server" Text="Size:"></asp:Label></td>
                   <%-- <td class="auto-style8">
                        <asp:LinkButton ID="Button2" runat="server" Text="All"  OnClick="Button2_Click" />
                        </td>--%>

                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource1" DataTextField="Size"
                            DataValueField="Size"
                            CssClass="CBLayout" ID="chkSize" runat="server"  AutoPostBack="true" TextAlign="Right" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct Size FROM [Wheels] "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct pcd FROM [Wheels] "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct Finish FROM [Wheels] "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct Offset FROM [Wheels] "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct seat FROM [Wheels] "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server"
                    ConnectionString="<%$ ConnectionStrings:OBG_Local %>"
                    SelectCommand="SELECT distinct bore FROM [Wheels] "></asp:SqlDataSource>


                <tr>
                    <td class="auto-style9">PCD:</td>
                    <%--<td class="auto-style8">
                        <asp:LinkButton ID="Button3" runat="server" Text="All"  OnClick="Button3_Click"/>
                        </td>--%>
                    <td class="auto-style6">
                        <asp:CheckBoxList DataSourceID="SqlDataSource2" DataTextField="PCD"
                            DataValueField="PCD" CssClass="CBLayout" ID="chkPCD"  runat="server" AutoPostBack="true" TextAlign="Right" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

               
                <tr>
                    <td class="auto-style9">Offset:</td>
                   <%-- <td class="auto-style8">
                        <asp:LinkButton ID="Button4" runat="server" Text="All" OnClick="Button4_Click"/>
                        </td>--%>
                    <td class="auto-style6">
                        <asp:CheckBoxList DataSourceID="SqlDataSource4" DataTextField="Offset"
                            DataValueField="Offset" CssClass="CBLayout" ID="chkOffset" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style9">Seat:</td>
                    <%--<td class="auto-style8">
                        <asp:LinkButton ID="Button5" runat="server" Text="All" OnClick="Button5_Click"  />
                        </td>--%>
                    <td class="auto-style6">
                        <asp:CheckBoxList DataSourceID="SqlDataSource5" DataTextField="Seat"
                            DataValueField="Seat" CssClass="CBLayout" ID="chkSeat" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style9">Bore:</td>
                   <%-- <td class="auto-style8">
                        <asp:LinkButton ID="Button6" runat="server" Text="All" OnClick="Button6_Click"  />
                        </td>--%>
                    <td class="auto-style6">
                        <asp:CheckBoxList DataSourceID="SqlDataSource6" DataTextField="Bore"
                            DataValueField="Bore" CssClass="CBLayout" ID="chkBore" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Finish:</td>
                    <%--<td class="auto-style8">
                        <asp:LinkButton ID="Button7" runat="server" Text="All" OnClick="Button7_Click" />
                        </td>--%>
                    <td class="auto-style6">
                        <asp:CheckBoxList DataSourceID="SqlDataSource3" DataTextField="Finish"
                            DataValueField="Finish"  ID="chkFinish" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <asp:LinkButton ID="Button1" runat="server" Text="Reset" OnClick="Button1_Click" />
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
    <asp:GridView ID="GridView1" runat="server" GridLines="Both" align="center"
        AllowPaging="True" AutoGenerateColumns="False"  CellPadding="4" AllowSorting="true"
        DataKeyNames="ProductId" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
       
        OnRowCommand="GridView1_RowCommand"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">


        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" Visible="False" />
            <%--<asp:TemplateField HeaderText ="PartNo" SortExpression="PartNo">
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="ImageTextBox" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' OnClientClick = "return LoadDiv(this.src);" Height="100px" Width="100px"></asp:ImageButton>
                    <%--<div id="ladiv" style="position: absolute; visibility: hidden; overflow: hidden;"></div>
                    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js" type="text/javascript">
                    </script>--%>
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
                height: 420px;width: 420px" />
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
                    <%--<script type="text/javascript">
                     function DisplayImageInNewWidnow() {
                         var image = document.getElementById('<%= Image1.ClientID %>');

                         htmlcode = "<HTML><HEAD></HEAD>"
        + "<BODY TOPMARGIN=0 LEFTMARGIN=0 "
        + "MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"
        + "<IMG src='" + image.src + "'"
        + "BORDER=0 NAME=FullSizeImage "
        + "onload='window.resizeTo(document.FullSizeImage.width, document.FullSizeImage.height)'>"
        + "</CENTER>"
        + "</BODY></HTML>";

                         newWindow = window.open('', 'FullSizeImage', 'toolbar=0,location=0,directories=0,menuBar=0,scrollbars=0,resizable=0,width=1,hight=1');
                         newWindow.document.open();
                         newWindow.document.write(htmlcode);
                         newWindow.document.focus();
                         newWindow.document.close();
                     }
</script>--%>
                    <%--<script type="text/javascript">
                         $(function () {
                             $("img.Imagehub").click(function (e) {
                                 var newImg = '<img src='
                                  + $(this).attr("src") + '></img>';
                                 $('#ladiv')
                                 .html($(newImg)
                              .animate({ height: '300', width: '300' }, 1500)); 
                              $()
                             });
                      });
                      function openLogin() {
                          document.getElementById("ladiv");
                      }  
                 </script>--%>

                    <%--                 <script src="jquery-1.8.3.min.js"></script> 
<script>
    var isopen = false;
    var newImg;
    var w = 200; 
    var h = 200; 
    $(document).ready(function () {
        $("img.Imagehub").bind("click", function () {
            newImg = this;
            if (!isopen) {
                isopen = true;
                $(this).width($(this).width() + w);
                $(this).height($(this).height() + h);
                moveImg(10, 10);
            }
            else {
                isopen = false;
                $(this).width($(this).width() - w);
                $(this).height($(this).height() - h);
                moveImg(-10, -10);
            }
            
        });
    });
    //移位 
//    i = 0;
    function moveImg(left, top) {
           

    newWindow = window.open('', 'FullSizeImage', 'toolbar=0,location=0,directories=0,menuBar=0,scrollbars=0,resizable=0,width=1,hight=1');
    newWindow.document.open();
    newWindow.document.write(htmlcode);
    newWindow.document.focus();
    newWindow.document.close();
    } 
</script> --%>


                    <script>
                        $(document).ready(function () {
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
                    </script>

<%--<style type="text/css">
         .imgthumb
         {
              height:100px;
             width:100px;
          }
         .imgdiv
         {
              background-color:White;
           margin-left:auto;
             margin-right:auto;
              padding:10px;
             border:solid 1px #c6cfe1;
              height:500px;
              width:450px;
          }
  </style>--%>
   <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js" type="text/javascript">
  </script>
       <script type="text/javascript">
                          $(function () {
                                 $("img.imgthumb").click(function (e) {
                                       var newImg = '<img src='
                                                      + $(this).attr("src") + '></img>';
                                      $('#ladiv')
                                            .html($(newImg)
                                            .animate({ height: '400', width: '300' }, 1500));
                                       });
                              });     
                  </script>--%>


                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PartNo" ItemStyle-HorizontalAlign="Center" SortExpression="PartNo">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="StyleTextBox" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PNLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style" ItemStyle-HorizontalAlign="Center" SortExpression="Style">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="StyleTextBox" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="StyleLabel" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Brand" ItemStyle-HorizontalAlign="Center" SortExpression="Brand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" ItemStyle-HorizontalAlign="Center" SortExpression="Size">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SizeTextBox" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcd" ItemStyle-HorizontalAlign="Center" SortExpression="Pcd">
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="PCDTextBox" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PCDLabel" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Finish" ItemStyle-HorizontalAlign="Center" SortExpression="Finish">
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="FinishTextBox" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="FinishLabel" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Offset(mm)" ItemStyle-HorizontalAlign="Center" SortExpression="Offset" >
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="OffsetTextBox" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OffsetLabel" runat="server" Text='<%# Bind("Offset") %>' ></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Seat" ItemStyle-HorizontalAlign="Center" SortExpression="Seat">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SeatTextBox" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SeatLabel" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bore(mm)" ItemStyle-HorizontalAlign="Center" SortExpression="Bore">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BoreTextBox" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BoreLabel" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight(LBS)" ItemStyle-HorizontalAlign="Center" SortExpression="Weight">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock" ItemStyle-HorizontalAlign="Center" SortExpression="Onhand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="OnhandTextBox" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="finalPrice" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial1" Visible="false" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial1" runat="server"  Visible="false" ForeColor="Red" Font-Bold="true" Text='<%# Bind("Special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="Price" >
                <%--<EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                   <%-- <asp:Label ID="sPriceLabel" runat="server" Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>--%>
                     <asp:Label ID="sPriceLabel" runat="server"  ForeColor='<%#  (float)Convert.ToSingle(((Label)((GridViewRow)Container).FindControl("LBSpecial1")).Text)<1?System.Drawing.Color.Red:System.Drawing.Color.Black%>'  Font-Bold='<%# ((Label)((GridViewRow)Container).FindControl("sPriceLabel")).ForeColor==System.Drawing.Color.Red?true:false%>'     Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                </ItemTemplate>
                
                <%--<ItemTemplate>
                    <asp:Label ID="sPriceLabel2" runat="server" Visible="false" Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                </ItemTemplate>--%>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="4"></asp:TextBox>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

           <%-- <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>                
                        <asp:LinkButton ID="DesBt"  Width="30" runat="server"  CommandName="DesClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' Text="Description" />         --%>
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
                   <%-- </ItemTemplate>   
                </asp:TemplateField>--%>
            
            <%-- <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center"  SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' OnClientClick="return confirm('Add the wheel to the shoppingcart?')" ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
        </div>
     <div id="divDes" runat="server" visible="false">
         <fieldset class="accountInfo">
            <legend>Wheel Description</legend>
         <asp:Label ID="lblDes" runat="server" ></asp:Label>
             </fieldset>
         </div>
</asp:Content>

