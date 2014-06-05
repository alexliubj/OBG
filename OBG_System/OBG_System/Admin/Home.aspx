<%@ Page Title="Home Page Management" Language="C#" MasterPageFile="~/Admin/AdminSite.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    Instruction: Only two images could be saved at a moment, inserting a new image will replace the older one.
     <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="RegisterUserValidationGroup" />
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" OnMenuItemClick="NavigationMenu_MenuItemClick">
        <Items>
            <asp:MenuItem Text="View Current Image"></asp:MenuItem>
            <asp:MenuItem Text="Insert New Image"></asp:MenuItem>
            <asp:MenuItem Text="Initial Image"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:Table ID="insertNewImage" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ImageLabel" runat="server" AssociatedControlID="FileUploadControl">Image:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="FileUploadControl" runat="server" onchange="FileUploadControl_onchange(this);" />
                 <asp:RequiredFieldValidator ID="FileUploadControlRequired" runat="server" ControlToValidate="FileUploadControl"
                                        CssClass="failureNotification" ErrorMessage="Image is required." ToolTip="Image is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="DesLabel" runat="server" AssociatedControlID="Des">Description:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Des" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell>
                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="BtnCancle" runat="server" OnClick="BtnCancle_Click" Text="Cancle" Visible="true" />
            </asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
    <asp:Table ID="viewCurrentImage" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblImage1" runat="server" AssociatedControlID="Image1">Image 1:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Image ID="Image1" runat="server" Width="200" Height="150" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDes1" runat="server" AssociatedControlID="Des1">Description 1:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Des1" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblImage2" runat="server" AssociatedControlID="Image2">Image 2:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Image ID="Image2" runat="server" Width="200" Height="150" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDes2" runat="server" AssociatedControlID="Des2">Description 2:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Des2" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

     <asp:Table ID="initialImage" runat="server" Visible="false">
         <asp:TableRow>
             <asp:TableCell>
                             Instruction: Only need to inital image, when there is no news yet.
                 </asp:TableCell>
         </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInitialImage1" runat="server" AssociatedControlID="FileUpload1">Image1:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFileUpload1" runat="server" ControlToValidate="FileUpload1"
                                        CssClass="failureNotification" ErrorMessage="Image1 is required." ToolTip="Image1 is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="DesInitialLabel1" runat="server" AssociatedControlID="initialDes1">Description1:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="initialDes1" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
           <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInitialImage2" runat="server" AssociatedControlID="FileUpload2">Image2:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFileUpload2" runat="server" ControlToValidate="FileUpload2"
                                        CssClass="failureNotification" ErrorMessage="Image2 is required." ToolTip="Image2 is required."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="DesInitialLabel2" runat="server" AssociatedControlID="initialDes2">Description2:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="initialDes2" runat="server" CssClass="textEntry" ReadOnly="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell>
                <asp:Button ID="BtnInitialSave" runat="server" OnClick="BtnInitialSave_Click" Text="Save" Visible="true" ValidationGroup="RegisterUserValidationGroup"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="BtnInitialCancle" runat="server" OnClick="BtnInitialCancle_Click" Text="Cancle" Visible="true" />
            </asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
</asp:Content>

