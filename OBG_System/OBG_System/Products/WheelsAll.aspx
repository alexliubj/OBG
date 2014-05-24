<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsAll.aspx.cs" Inherits="Products_wheelall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <div id="wheelFilter" runat="server" visible="true">
       
        <fieldset class="wheelInfo">
            <legend>Choose your wheels</legend>
            <table>
                <tr>
                    <td class="style11">
                        <asp:Label ID="StyleLabel" runat="server" >Style:</asp:Label>
                    </td>
                    <td class="style12">
                         <asp:CheckBox ID="StyleCheck1" runat="server" Text='All' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck2" runat="server" Text='Europa' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck3" runat="server" Text='R117A' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck4" runat="server" Text='R133A' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck5" runat="server" Text='R152' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck6" runat="server" Text='R115' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck7" runat="server" Text='Numesis' /></td>
                    <td class="style11">
                         <asp:CheckBox ID="StyleCheck8" runat="server" Text='R142' /></td>
                    <td class="style11">
                       
                    </td>
                </tr>

                <tr>
                    <td class="style11">
                        <asp:Label ID="BrandLabel" runat="server">Brand:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="BrandCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="BrandCheck2" runat="server" Text='Fast Wheels'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="BrandCheck3" runat="server" Text='Replika'></asp:CheckBox></td>
                    <td class="style11">
                        
                        
                    </td>
                </tr>

               

                <tr>
                    <td class="style11">
                        <asp:Label ID="SizeLabel" runat="server" >Size:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="SizeCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SizeCheck2" runat="server" Text='18*8.0'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SizeCheck3" runat="server" Text='18*8.5'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SizeCheck4" runat="server" Text='16*7.0'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SizeCheck5" runat="server" Text='19*8.5'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SizeCheck6" runat="server" Text='17*8.0'></asp:CheckBox></td>
                    <td class="style11">
                        
                    </td>
                </tr>

                <tr>
                    <td class="style11">
                        <asp:Label ID="PcdLabel" runat="server" >Pcd:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="PCDCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="PCDCheck2" runat="server" Text='5*112/114.3'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="PCDCheck3" runat="server" Text='5*112'></asp:CheckBox></td>
                    <td class="style11">
                        
                        
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        <asp:Label ID="FinishLabel" runat="server" >Finish:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="FinishCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="FinishCheck2" runat="server" Text='Flat Black'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="FinishCheck3" runat="server" Text='Hyper Silver'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="FinishCheck4" runat="server" Text='Santin Black'></asp:CheckBox></td>
                    <td class="style11">
                       
                    </td>
                </tr>

                <tr>
                    <td class="style11">
                        <asp:Label ID="OffsetLabel" runat="server" >Offset:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="OffsetCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OffsetCheck2" runat="server" Text='+45'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OffsetCheck3" runat="server" Text='+50'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OffsetCheck4" runat="server" Text='+35'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OffsetCheck5" runat="server" Text='+42'></asp:CheckBox></td>
                    <td class="style11">
                        
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        <asp:Label ID="SeatLabel" runat="server" >Seat:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="SeatCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SeatCheck2" runat="server" Text='60°seat'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="SeatCheck3" runat="server" Text='R13 Radius Seat'></asp:CheckBox></td>
                    <td class="style11">
                        
                    </td>
                </tr>

                <tr>
                    <td class="style11">
                        <asp:Label ID="BoreLabel" runat="server" >Bore:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="BoreCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="BoreCheck2" runat="server" Text='73.1'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="BoreCheck3" runat="server" Text='66.4'></asp:CheckBox></td>
                    <td class="style11">
                        
                       
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        <asp:Label ID="WeightLabel" runat="server" >Weight:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="WeightCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck2" runat="server" Text='23.1'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck3" runat="server" Text='27.0'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck4" runat="server" Text='19.0'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck5" runat="server" Text='28.2'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck6" runat="server" Text='24.8'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="WeightCheck7" runat="server" Text='22.2'></asp:CheckBox></td>
                    <td class="style11">
                       
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        <asp:Label ID="OnhandLabel" runat="server" >Onhand:</asp:Label>
                    </td>
                    <td class="style12">
                        <asp:CheckBox ID="OnhandCheck1" runat="server" Text='All'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OnhandCheck2" runat="server" Text='100+'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OnhandCheck3" runat="server" Text='99'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OnhandCheck4" runat="server" Text='66'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OnhandCheck5" runat="server" Text='62'></asp:CheckBox></td>
                    <td class="style11">
                        <asp:CheckBox ID="OnhandCheck6" runat="server" Text='56'></asp:CheckBox></td>
                    <td class="style11">
                       

                    </td>
                </tr>
                
               
            </table>
        </fieldset>
    </div>
   
<asp:GridView ID="GridView1" runat="server"  GridLines="None" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDataBound="GridView1_RowDataBound"
         OnRowCommand="GridView1_RowCommand">

        
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" visible="False"/>
            
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="ImageTextBox" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Image class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'  onclick="DisplayImageInNewWidnow();"></asp:Image>
                      <div id="ladiv" style="position: absolute;visibility: hidden;overflow: hidden;"></div>
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
$(function() {
    $("img.Imagehub").click(function () {
       
       
        var background = $("<div></div>");
       
        $(background).attr("id","overlaybackground").animate({
            'opacity':'.6'
        },1000).css({
            "width"  : $(document).width(),
            'height' : $(document).height(),
            'background' : '#656565',
            'z-index' : '100',
            'position': 'absolute',
            'top' : '0px',
            'left' : '0px'
            });
        $("body").append(background);

       
        
        var newimage = $("<img/>");
        var width = $('body').width();
        $(newimage).attr("src",$(this).attr("src")).attr("id","largeimage").css({
            'left' : width/2-200,
            'top' : '360px',
            'position': 'absolute',
            'z-index' : '300',
            'display' : 'none',
            'width': '300px',
            'height': '300px',
            'border' : '30px solid #fff'
        });
        $("body").append(newimage);


       
        $("#largeimage").fadeIn(2000,function(){
            $(this).click(function(){
                $(this).fadeOut(1000);
                $("div#overlaybackground").fadeOut(1000,function(){
                    $(this).remove();
                })
            })
        })

       
    });
})
</script>




                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style" SortExpression="Style">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="StyleTextBox" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="StyleLabel" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size" SortExpression="Size">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SizeTextBox" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcd" SortExpression="Pcd">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="PCDTextBox" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PCDLabel" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Finish" SortExpression="Finish">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="FinishTextBox" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="FinishLabel" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Offset" SortExpression="Offset">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="OffsetTextBox" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OffsetLabel" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Seat" SortExpression="Seat">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="SeatTextBox" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="SeatLabel" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Bore" SortExpression="Bore">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="BoreTextBox" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="BoreLabel" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onhand" SortExpression="Onhand">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="OnhandTextBox" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
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
            <asp:TemplateField HeaderText="ADD" SortExpression="ADD">
            <ItemTemplate>
            <asp:ImageButton ID="AddBt" runat="server" CommandName="MyButtonClick" CommandArgument='<%# Container.DataItemIndex %>' ImageUrl="../Pictures/images.jpg" ></asp:ImageButton>
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

