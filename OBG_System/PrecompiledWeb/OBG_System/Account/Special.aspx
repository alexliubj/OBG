<%@ page title="Special" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_Special, App_Web_3mbqj51t" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="div1" runat="server" visible="true">
        <img alt="Special" src="../Pictures/special_offers.jpg" />
    </div>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" Orientation="Horizontal" OnMenuItemClick="NavigationMenu_MenuItemClick">
        <staticselectedstyle 
                           backcolor="White"
                           ForeColor="#3070d4"
                              borderstyle="Solid"
                              bordercolor="Black" 
                              borderwidth="1"/>
                    
        <Items>
            <asp:MenuItem Text="Wheels"></asp:MenuItem>
            <asp:MenuItem Text="Tires"></asp:MenuItem>
            <asp:MenuItem Text="Accessories"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <br/>
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
        <br/>
        <asp:GridView ID="GridView1" runat="server" GridLines="Both" AllowPaging="True" Align="center" EmptyDataText="There is no wheels special now." AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductId" ForeColor="#333333" 
Visible="true" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product ID" Visible="false"  InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' OnClientClick = "return LoadDiv(this.src);"></asp:ImageButton>
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
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:ImageField HeaderText="Image" DataImageUrlField="Image" ControlStyle-Width="35" ControlStyle-Height="35">
                </asp:ImageField>--%>
                <%-- <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Style" SortExpression="Style">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Style") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Size" SortExpression="Size">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="SizeLabel" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pcd" SortExpression="Pcd">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Finish" SortExpression="Finish">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Offset" SortExpression="Offset">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Seat" SortExpression="Seat">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bore" SortExpression="Bore">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Onhand" SortExpression="Onhand">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reg Price" SortExpression="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Price")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <%--<asp:TemplateField HeaderText="Description" SortExpression="Des" Visible="false">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
                <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Bind("special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Special Price" SortExpression="Pricing">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Font-Bold="true"  Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="4"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center"  SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server"  OnClientClick="return confirm('Add the wheel to the shoppingcart?')" CommandName="MyButtonClick" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
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
         <br/>
    <br/>
        </div>
   

    <div id="divTire" runat="server" visible="false">
        <asp:Label ID="Label1" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage2" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage2_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>
        <br/>
        <asp:GridView ID="GridView2" runat="server" GridLines="Both" AllowPaging="True" Align="center" EmptyDataText="There is no wheels special now." AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TireId" ForeColor="#333333" 
 Visible="true" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView1_RowCommand1" OnSorting="GridView2_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TireId" Visible="false" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />
            
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' OnClientClick = "return LoadDiv(this.src);"></asp:ImageButton>
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
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Size" SortExpression="Size">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Season" SortExpression="Season">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Season") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="seasonLabel" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               <asp:TemplateField HeaderText="Reg Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Description" SortExpression="Des">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial1" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial1" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Bind("Special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Special Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="specialprice" runat="server" ForeColor="Red" Font-Bold="true"  Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center"  SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server"  OnClientClick="return confirm('Add the tire to the shoppingcart?')" CommandName="MyButtonClickt" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
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
        <br/><br/>
        </div>
    

     <div id="divAcc" runat="server" visible="false">
        <asp:Label ID="Label16" runat="server" Text="Per Page:"></asp:Label>
    <asp:DropDownList ID="dropDownRecordsPerPage3" runat="server"
        AutoPostBack="true" OnSelectedIndexChanged="dropDownRecordsPerPage3_SelectedIndexChanged" AppendDataBoundItems="true"
        Style="text-align: right;">
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" Selected="True" />
        <asp:ListItem Value="25" Text="25" />
        <asp:ListItem Value="50" Text="50" />
        <asp:ListItem Value="100" Text="100" />
    </asp:DropDownList>
         <br/>
        <asp:GridView ID="GridView3" runat="server" GridLines="Both" AllowPaging="True" Align="center" EmptyDataText="There is no wheels special now." AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" ForeColor="#333333" 
 Visible="true" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand" OnSorting="GridView3_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="AccId" HeaderText="Acc ID" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="AccId" />
      
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:ImageButton class="Imagehub" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' OnClientClick = "return LoadDiv(this.src);"></asp:ImageButton>
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
                    </ItemTemplate>
                </asp:TemplateField>
                          <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Brand" SortExpression="Brand">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Des">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Reg Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="accLabel5" runat="server" Text='<%# Bind("finalprice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Special" Visible="false" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSpecial" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LBSpecial" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Bind("Special") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Special Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="accl5" runat="server" ForeColor="Red" Font-Bold="true"  Text='<%# Bind("specialPrice","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="Center" SortExpression="QTY">
                <ItemTemplate>
                    <asp:TextBox ID="QTYTextBox" runat="server" Width="20" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="ADD" ItemStyle-HorizontalAlign="Center"  SortExpression="ADD">
                <ItemTemplate>
                    <asp:ImageButton ID="AddBt" runat="server"  OnClientClick="return confirm('Add the accessory to the shoppingcart?')" CommandName="MyButtonClicka" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="../Pictures/images.jpg"></asp:ImageButton>
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
          <br/><br/>
         </div>
   
</asp:Content>

