<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.master"
    AutoEventWireup="true" CodeFile="ProductManagement.aspx.cs" Inherits="Admin_Default" %>

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
    <asp:Button ID="btnAddWheel" runat="server" OnClick="Button1_Click" Text="Add new Wheel" align="right" />
    <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductId" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
            <asp:TemplateField HeaderText="Image" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pcd") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Pcd") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Finish" SortExpression="Finish">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Finish") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Finish") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Offset" SortExpression="Offset">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Offset") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Offset") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Seat" SortExpression="Seat">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Seat") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Seat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bore" SortExpression="Bore">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Bore") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Bore") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Onhand" SortExpression="Onhand">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Onhand") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Onhand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
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


    <div id="wheelInformation" runat="server" visible="false">
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="RegisterUserValidationGroup" />
        <fieldset class="wheelInfo">
            <legend>Wheel Information</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="ImageLabel" runat="server" AssociatedControlID="Image">Image:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Image" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ImageRequired" runat="server" ControlToValidate="Image"
                            CssClass="failureNotification" ErrorMessage="Image is required." ToolTip="Image is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        <%--  <asp:RegularExpressionValidator
                            ID="EmailExpression" runat="SERVER"
                            ControlToValidate="Email"
                            CssClass="failureNotification"
                            ErrorMessage="Enter a valid Email."
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="RegisterUserValidationGroup">*
                        </asp:RegularExpressionValidator>--%>
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
                        <%--     <asp:RegularExpressionValidator
                            ID="PhoneExpression" runat="SERVER"
                            ControlToValidate="Phone"
                            CssClass="failureNotification"
                            ErrorMessage="Enter a valid Phone Number."
                            ValidationExpression="^([0-9\(\)\/\+ \-]*)$"
                            ValidationGroup="RegisterUserValidationGroup">*
                        </asp:RegularExpressionValidator>--%>
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
                        <%-- <asp:RegularExpressionValidator
                            ID="ShippingPostCodeExpression" runat="SERVER"
                            ControlToValidate="ShippingPostCode"
                            CssClass="failureNotification"
                            ErrorMessage="Enter a valid Post Code."
                            ValidationExpression="\d{5}((-)?\d{4})?|([A-Za-z]\d[A-Za-z]( )?\d[A-Za-z]\d)"
                            ValidationGroup="RegisterUserValidationGroup">*
                        </asp:RegularExpressionValidator>--%>
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
                        <%--  <asp:RegularExpressionValidator
                            ID="BillingPostCodeExpression" runat="SERVER"
                            ControlToValidate="BillingPostCode"
                            CssClass="failureNotification"
                            ErrorMessage="Enter a valid Post Code."
                            ValidationExpression="\d{5}((-)?\d{4})?|([A-Za-z]\d[A-Za-z]( )?\d[A-Za-z]\d)"
                            ValidationGroup="RegisterUserValidationGroup">*
                        </asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="WeightLabel" runat="server" AssociatedControlID="Weight" Visible="false">Weight:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Weight" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="WeightRequired" runat="server" ControlToValidate="Weight"
                            CssClass="failureNotification" ErrorMessage="Weight is required." ToolTip="Weight is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="OnhandLabel" runat="server" AssociatedControlID="Onhand" Visible="false">Onhand:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Onhand" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="OnhandRequired" runat="server" ControlToValidate="Onhand"
                            CssClass="failureNotification" ErrorMessage="Onhand is required."
                            ToolTip="Onhand is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" AssociatedControlID="Price" Visible="false">Price:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Price" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price"
                            CssClass="failureNotification" ErrorMessage="Price is required."
                            ToolTip="Price is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" AssociatedControlID="CategoryId" Visible="false">Category ID:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CategoryId" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CategoryIdRequired" runat="server" ControlToValidate="CategoryId"
                            CssClass="failureNotification" ErrorMessage="CategoryId is required."
                            ToolTip="CategoryId is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" Visible="true" ValidationGroup="RegisterUserValidationGroup" />
                        <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup" />
                    </td>
                    <td>
                        <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancle" Visible="true" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>

    <asp:GridView ID="GridView2" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TireId" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
        OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing"
        OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" Visible="False">
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
            <asp:TemplateField HeaderText="Width" SortExpression="Width">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("rimWith") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("rimWith") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Height" SortExpression="Height">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("rimHeight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("rimHeight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pricing") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Season" SortExpression="Season">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Season") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Season") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
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


    <asp:GridView ID="GridView3" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AccId" ForeColor="#333333" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
        OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
        OnRowUpdating="GridView3_RowUpdating" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDataBound="GridView3_RowDataBound" Visible="False">
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
            <asp:TemplateField HeaderText="Img" SortExpression="Img">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Des" SortExpression="Des">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Des") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pricing" SortExpression="Pricing">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Pricing") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Pricing") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CategoryId" SortExpression="CategoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
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
