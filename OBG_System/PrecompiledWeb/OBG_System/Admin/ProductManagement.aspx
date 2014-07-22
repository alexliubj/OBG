<%@ page title="Product Management" language="C#" masterpagefile="~/Admin/AdminSite.master" autoeventwireup="true" inherits="Admin_Default, App_Web_owrxjuqs" errorpage="~/mycustompage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" OnMenuItemClick="NavigationMenu_MenuItemClick">
        <Items>
            <asp:MenuItem Text="Wheels"></asp:MenuItem>
            <asp:MenuItem Text="Tires"></asp:MenuItem>
            <asp:MenuItem Text="Accessories"></asp:MenuItem>
        </Items>
    </asp:Menu>
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
        <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductId" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" Visible="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Image") %>' Width="50" Height="50" />
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
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Price")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Price")) %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Description" SortExpression="Des" Visible="false">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Special" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# string.Format("{0:0.###%}", Eval("Special")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="myButton" />
                <%--  <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this wheel?');" CssClass="myButton" />
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
        <br />
        <asp:Button ID="btnAddWheel" runat="server" OnClick="Button1_Click" Text="Add new Wheel" CssClass="myButton" />

        <div id="wheelInformation" runat="server" visible="false">
            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="RegisterUserValidationGroup" />
            <fieldset class="wheelInfo">
                <legend>Wheel Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="ImageLabel" runat="server" AssociatedControlID="FileUploadControl">Image:</asp:Label>
                        </td>
                        <script type="text/javascript">

                            function FileUploadControl_onchange(oFileUploadControl) {
                                document.getElementById('btnPreviewImage').click();
                            }

                        </script>
                        <td>
                            <asp:Image ID="Image1" runat="server" Width="50" Height="50" />
                            <asp:FileUpload ID="FileUploadControl" runat="server" onchange="document.getElementById('btnPreviewImage').click();" />
                            <asp:Button ID="btnPreviewImage" runat="server" Text="Preview" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PartNoLabel" runat="server" AssociatedControlID="PartNo">Part NO.:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="PartNo" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PartNoRequired" runat="server" ControlToValidate="PartNo"
                                CssClass="failureNotification" ErrorMessage="Part No. is required."
                                ToolTip="Part No. is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="StyleLabel" runat="server" AssociatedControlID="Style">Style:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Style" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Style"
                                CssClass="failureNotification" ErrorMessage="Style is required." ToolTip="Style is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="BrandLabel" runat="server" AssociatedControlID="Brand">Brand:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Brand" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Brand"
                                CssClass="failureNotification" ErrorMessage="Brand is required." ToolTip="Brand is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="SizeLabel" runat="server" AssociatedControlID="Size">Size:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Size" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Size"
                                CssClass="failureNotification" ErrorMessage="Size is required." ToolTip="Size is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="PcdLabel" runat="server" AssociatedControlID="Pcd">Pcd:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Pcd" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Pcd"
                                CssClass="failureNotification" ErrorMessage="Pcd is required." ToolTip="Pcd is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="FinishLabel" runat="server" AssociatedControlID="Finish">Finish:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Finish" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Finish"
                                CssClass="failureNotification" ErrorMessage="Finish is required." ToolTip="Finish is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="OffsetLabel" runat="server" AssociatedControlID="Offset">Offset:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Offset" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Offset"
                                CssClass="failureNotification" ErrorMessage="Offset is required." ToolTip="Offset is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="SeatLabel" runat="server" AssociatedControlID="Seat">Seat:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Seat" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Seat"
                                CssClass="failureNotification" ErrorMessage="Seat is required." ToolTip="Seat is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="BoreLabel" runat="server" AssociatedControlID="Bore">Bore:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Bore" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Bore"
                                CssClass="failureNotification" ErrorMessage="Bore is required." ToolTip="Bore is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="WeightLabel" runat="server" AssociatedControlID="Weight">Weight:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Weight" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="WeightRequired" runat="server" ControlToValidate="Weight"
                                CssClass="failureNotification" ErrorMessage="Weight is required." ToolTip="Weight is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="OnhandLabel" runat="server" AssociatedControlID="Onhand">Onhand:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Onhand" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="OnhandRequired" runat="server" ControlToValidate="Onhand"
                                CssClass="failureNotification" ErrorMessage="Onhand is required."
                                ToolTip="Onhand is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="DesLabel" runat="server" AssociatedControlID="Des">Description:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Des" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Des"
                                CssClass="failureNotification" ErrorMessage="Description is required."
                                ToolTip="Description is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="SpecialLabel" runat="server" AssociatedControlID="Special">Special:</asp:Label>
                        </td>
                        <td>If you want to make this product special, enter a number less then 1, for example: 0.9 means 90% discount
                            <asp:TextBox ID="Special" runat="server" CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PriceLabel" runat="server" AssociatedControlID="Price">Price:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Price" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price"
                                CssClass="failureNotification" ErrorMessage="Price is required."
                                ToolTip="Price is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="PriceExpression" runat="SERVER"
                                ControlToValidate="Price"
                                CssClass="failureNotification"
                                ErrorMessage="Please Enter Only Numbers."
                                ValidationExpression="[-+]?[0-9]*\.?[0-9]+"
                                ValidationGroup="RegisterUserValidationGroup">*
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="VehicleLabel" runat="server" AssociatedControlID="CheckBoxListVehicle">Vehicles:</asp:Label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxListVehicle" runat="server" DataSourceID="SqlDataSource1" DataTextField="VehicleName" DataValueField="VehicleId" RepeatDirection="Horizontal" RepeatColumns="5" OnSelectedIndexChanged="CheckBoxListVehicle_SelectedIndexChanged"></asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OBG_Local %>" SelectCommand="SELECT * FROM [Vehicles]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                            <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                        </td>
                        <td>
                            <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancel" Visible="true" CssClass="myButton" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
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
        <asp:GridView ID="GridView2" runat="server" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TireId" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
            OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing"
            OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" Visible="true" OnPageIndexChanging="GridView2_PageIndexChanging" OnSorting="GridView2_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TireId" HeaderText="Tire ID" InsertVisible="False" ReadOnly="True" SortExpression="TireId" />
                <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Image") %>' Width="50" Height="50" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Season" SortExpression="Season">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Season") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Description" SortExpression="Des" Visible="false">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Special" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# string.Format("{0:0.###%}", Eval("Special")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="myButton" />
                <%--  <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this tire?');" CssClass="myButton" />
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
        <br />
        <asp:Button ID="BtnAddNewTire" runat="server" OnClick="BtnAddNewTire_Click" Text="Add new Tire" CssClass="myButton" />
        <div id="DivTireInformation" runat="server" visible="false">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                ValidationGroup="RegisterUserValidationGroup" />
            <fieldset class="tireInfo">
                <legend>Tire Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="TireImageLabel" runat="server" AssociatedControlID="TireFileUploadControl">Image:</asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="TireImage" runat="server" Width="50" Height="50" />
                            <asp:FileUpload ID="TireFileUploadControl" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="TirePartNoLabel" runat="server" AssociatedControlID="TirePartNo">Part NO.:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TirePartNo" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TirePartNo"
                                CssClass="failureNotification" ErrorMessage="Part NO. is required." ToolTip="Part NO. is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="TireSizeLabel" runat="server" AssociatedControlID="TireSize">Size:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TireSize" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TireSize"
                                CssClass="failureNotification" ErrorMessage="Size is required." ToolTip="Size is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="TirePriceLabel" runat="server" AssociatedControlID="TirePrice">Price:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TirePrice" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TirePrice"
                                CssClass="failureNotification" ErrorMessage="Price is required." ToolTip="Price is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="SERVER"
                                ControlToValidate="TirePrice"
                                CssClass="failureNotification"
                                ErrorMessage="Please Enter Only Numbers."
                                ValidationExpression="[-+]?[0-9]*\.?[0-9]+"
                                ValidationGroup="RegisterUserValidationGroup">*
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="TireSeasonLabel" runat="server" AssociatedControlID="TireSeason">Season:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TireSeason" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TireSeason"
                                CssClass="failureNotification" ErrorMessage="Season is required." ToolTip="Season is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="TireBrandLabel" runat="server" AssociatedControlID="TireBrand">Brand:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TireBrand" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TireBrand"
                                CssClass="failureNotification" ErrorMessage="Brand is required." ToolTip="Brand is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="TireSpecialLabel" runat="server" AssociatedControlID="TireSpecial">Special:</asp:Label>
                        </td>
                        <td>If you want to make this product special, enter a number less then 1, for example: 0.9 means 90% discount
                            <asp:TextBox ID="TireSpecial" runat="server" CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="TireDesLabel" runat="server" AssociatedControlID="TireDes" >Description:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TireDes" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TireDes"
                                CssClass="failureNotification" ErrorMessage="Description is required." ToolTip="Description is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnAddTire" runat="server" Text="Add" OnClick="BtnAddTire_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                            <asp:Button ID="BtnSaveTire" runat="server" OnClick="BtnSaveTire_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                        </td>
                        <td>
                            <asp:Button ID="BtnCancelTire" runat="server" OnClick="BtnCancelTire_Click" Text="Cancel" Visible="true" CssClass="myButton" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
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
        <asp:GridView ID="GridView3" runat="server" GridLines="None" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" ForeColor="#333333" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
            OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
            OnRowUpdating="GridView3_RowUpdating" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDataBound="GridView3_RowDataBound" Visible="true" OnPageIndexChanging="GridView3_PageIndexChanging" OnSorting="GridView3_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="AccId" HeaderText="Acc ID" InsertVisible="False" ReadOnly="True" SortExpression="AccId" />
                <asp:TemplateField HeaderText="PartNo" SortExpression="PartNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PartNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Image") %>' Width="50" Height="50" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Des" Visible="false">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Pricing">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# string.Format("{0:0.##}", Eval("Pricing")) %>'></asp:Label>
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
                          <asp:TemplateField HeaderText="Special" SortExpression="Special">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Special") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# string.Format("{0:0.###%}", Eval("Special")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="myButton" />
                <%-- <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />--%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this accessory?');" CssClass="myButton" />
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
        <br />
        <asp:Button ID="BtnAddNewAcc" runat="server" OnClick="BtnAddNewAcc_Click" Text="Add new Accessory" CssClass="myButton" />
        <div id="DivAccInformation" runat="server" visible="false">
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="failureNotification"
                ValidationGroup="RegisterUserValidationGroup" />
            <fieldset class="accInfo">
                <legend>Accessory Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="AccImageLabel" runat="server" AssociatedControlID="AccFileUploadControl">Image:</asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="AccImage" runat="server" Width="50" Height="50" />
                            <asp:FileUpload ID="AccFileUploadControl" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="AccPartNoLabel" runat="server" AssociatedControlID="AccPartNo">Part NO.:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="AccPartNo" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="AccPartNo"
                                CssClass="failureNotification" ErrorMessage="Part NO. is required." ToolTip="Part NO. is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="AccNameLabel" runat="server" AssociatedControlID="AccName">Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="AccName" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="AccName"
                                CssClass="failureNotification" ErrorMessage="Name is required." ToolTip="Name is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="AccPriceLabel" runat="server" AssociatedControlID="AccPrice">Price:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="AccPrice" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="AccPrice"
                                CssClass="failureNotification" ErrorMessage="Price is required." ToolTip="Price is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2" runat="SERVER"
                                ControlToValidate="TirePrice"
                                CssClass="failureNotification"
                                ErrorMessage="Please Enter Only Numbers."
                                ValidationExpression="[-+]?[0-9]*\.?[0-9]+"
                                ValidationGroup="RegisterUserValidationGroup">*
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="AccBrandLabel" runat="server" AssociatedControlID="AccBrand">Brand:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="AccBrand" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="AccBrand"
                                CssClass="failureNotification" ErrorMessage="Brand is required." ToolTip="Brand is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            <asp:Label ID="AccSpecialLabel" runat="server" AssociatedControlID="AccSpecial">Special:</asp:Label>
                        </td>
                        <td>If you want to make this product special, enter a number less then 1, for example: 0.9 means 90% discount
                            <asp:TextBox ID="AccSpecial" runat="server" CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="AccDesLabel" runat="server" AssociatedControlID="AccDes">Description:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="AccDes" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="AccDes"
                                CssClass="failureNotification" ErrorMessage="Description is required." ToolTip="Description is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnAddAcc" runat="server" Text="Add" OnClick="BtnAddAcc_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                            <asp:Button ID="BtnSaveAcc" runat="server" OnClick="BtnSaveAcc_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" CssClass="myButton" />
                        </td>
                        <td>
                            <asp:Button ID="BtnCancelAcc" runat="server" OnClick="BtnCancelAcc_Click" Text="Cancel" Visible="true" CssClass="myButton" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>

</asp:Content>
