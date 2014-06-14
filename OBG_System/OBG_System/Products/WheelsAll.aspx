<%@ Page Title="View All Wheels" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsAll.aspx.cs" Inherits="Products_wheelall" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
            width: 69px;
        }

        .auto-style5
        {
            width: 69px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/jquery-1.2.6.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#chkAll').click(
             function () {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
        });

    </script>

    <div id="wheelFilter" runat="server" visible="true">

        <fieldset class="wheelInfo">
            <legend>Choose your wheels</legend>
            <table style="width: 852px">
                <tr>
                    <td>
                        <asp:Label ID="sizeLB" class="label" runat="server" Text="Size"></asp:Label></td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource1" DataTextField="Size"
                            DataValueField="Size"
                            CssClass="CBLayout" ID="chkSize" runat="server" AutoPostBack="true" TextAlign="Right" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
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
                    <td class="auto-style5">PCD:</td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource2" DataTextField="PCD"
                            DataValueField="PCD" CssClass="CBLayout" ID="chkPCD" runat="server" AutoPostBack="true" TextAlign="Right" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style3">Finish:</td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource3" DataTextField="Finish"
                            DataValueField="Finish" CssClass="CBLayout" ID="chkFinish" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">Offset:</td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource4" DataTextField="Offset"
                            DataValueField="Offset" CssClass="CBLayout" ID="chkOffset" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">Seat:</td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource5" DataTextField="Seat"
                            DataValueField="Seat" CssClass="CBLayout" ID="chkSeat" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">Bore:</td>
                    <td>
                        <asp:CheckBoxList DataSourceID="SqlDataSource6" DataTextField="Bore"
                            DataValueField="Bore" CssClass="CBLayout" ID="chkBore" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="10" OnSelectedIndexChanged="chkPCD_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>

            </table>
        </fieldset>
    </div>

    <asp:GridView ID="GridView1" runat="server" GridLines="Both" 
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
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' onclick="DisplayImageInNewWidnow();"></asp:Image>
                    <div id="ladiv" style="position: absolute; visibility: hidden; overflow: hidden;"></div>
                    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js" type="text/javascript">
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
                <%--<EditItemTemplate>
                    <asp:TextBox ID="StyleTextBox" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="StyleLabel" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Brand" ItemStyle-HorizontalAlign="Center" SortExpression="Brand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" ItemStyle-HorizontalAlign="Center" SortExpression="Size">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SizeTextBox" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcd" ItemStyle-HorizontalAlign="Center" SortExpression="Pcd">
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="PCDTextBox" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PCDLabel" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Finish" ItemStyle-HorizontalAlign="Center" SortExpression="Finish">
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="FinishTextBox" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="FinishLabel" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Offset" ItemStyle-HorizontalAlign="Center" SortExpression="Offset">
                <%-- <EditItemTemplate>
                    <asp:TextBox ID="OffsetTextBox" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OffsetLabel" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Seat" ItemStyle-HorizontalAlign="Center" SortExpression="Seat">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SeatTextBox" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SeatLabel" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bore" ItemStyle-HorizontalAlign="Center" SortExpression="Bore">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BoreTextBox" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BoreLabel" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight" ItemStyle-HorizontalAlign="Center" SortExpression="Weight">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Onhand" ItemStyle-HorizontalAlign="Center" SortExpression="Onhand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="OnhandTextBox" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>                
                        <asp:LinkButton ID="DesBt"  Width="30" runat="server" CommandName="Description" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' Text="Description" />         
                    </ItemTemplate>   
                </asp:TemplateField>
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
                    <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
                </ItemTemplate>
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


</asp:Content>

