<%@ Page Title="View Wheels By Vehicle" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WheelsByVehicle.aspx.cs" Inherits="Products_viewByVehicle" ErrorPage="~/mycustompage.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
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


    <asp:GridView ID="GridView4" runat="server"   GridLines="Both"  
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ProductId" ForeColor="#333333"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDataBound="GridView1_RowDataBound"
        AllowSorting="true"  OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
        >
        
    <AlternatingRowStyle BackColor="White" />
            <Columns>
       
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" SortExpression="Image">
            
                <ItemTemplate>
                   <asp:Image class="Imagehub" ID="ImageLable" runat="server" ImageUrl='<%# Eval("Image") %>' ></asp:Image>
                   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js" type="text/javascript">
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
                 <asp:TemplateField HeaderText="Offset" ItemStyle-HorizontalAlign="Center" SortExpression="Offset">
            
                <ItemTemplate>
                    <asp:Label ID="OffsetLabel" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Seat" ItemStyle-HorizontalAlign="Center" SortExpression="Seat">
 
                <ItemTemplate>
                    <asp:Label ID="SeatLabel" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Bore" ItemStyle-HorizontalAlign="Center" SortExpression="Bore">
  
                <ItemTemplate>
                    <asp:Label ID="BoreLabel" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Weight" ItemStyle-HorizontalAlign="Center" SortExpression="Weight">
     
                <ItemTemplate>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onhand" ItemStyle-HorizontalAlign="Center" SortExpression="Onhand">
     
                <ItemTemplate>
                    <asp:Label ID="OnhandLabel" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center" SortExpression="Price">
     
                <ItemTemplate>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center" SortExpression="ADD">
            <ItemTemplate>
            <asp:ImageButton ID="AddBt" runat="server" ImageUrl="../Pictures/images.jpg"  CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'></asp:ImageButton>
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

