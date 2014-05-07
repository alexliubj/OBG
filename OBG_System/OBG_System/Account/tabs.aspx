<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="tabs.aspx.cs" Inherits="Account_tabs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type="text/javascript">
        function ChangeForm(id) {

            var link1 = document.getElementById("a1");
            var link2 = document.getElementById("a2");
            var link3 = document.getElementById("a3");
            var div1 = document.getElementById("div1");
            var div2 = document.getElementById("div2");
            var div3 = document.getElementById("div3");
            if (id == 1) {
                link1.className = "tab_selected";
                link2.className = "tab";
                link3.className = "tab";

                div1.style.display = '';
                div2.style.display = 'none';
                div3.style.display = 'none';
            }
            else if (id == 2) {
                link1.className = "tab";
                link2.className = "tab_selected";
                link3.className = "tab";

                div1.style.display = 'none';
                div2.style.display = '';
                div3.style.display = 'none';
            }
            else if (id == 3) {
                link1.className = "tab";
                link2.className = "tab";
                link3.className = "tab_selected";

                div1.style.display = 'none';
                div2.style.display = 'none';
                div3.style.display = '';
            }
        }
    </script>
 
   
<%--<head >
    <title>Untitled Page</title>
    <style type="text/css">
    .tab {
    font-family: Verdana, Arial, Helvetica, sans-serif;
    font-size: 11px;
    color: #3574aa;
    font-weight: bold;
    text-align: center;
    height: 25px;
    width: 125px;
    line-height:25px;
    text-decoration:none;
    display:block;
    background-position: center bottom;
    vertical-align: bottom;
    background-color: #bbecfa;
    border: 1px solid #FFFFFF;
     }
.tab_selected {
    font-family: Verdana, Arial, Helvetica, sans-serif;
    font-size: 11px;
    color: #ffffff;
    font-weight: bold;
    text-align: center;
    height: 25px;
    width: 137px;
    line-height:25px;
    text-decoration:none;
    display:block;
    background-image: none;
    background-repeat: no-repeat;
    background-position: center;
    vertical-align: bottom;
    padding-top:0px;
    background-color: #0bb7df;
    border: 1px solid #FFFFFF;
     } 
    </style>
    
    
</head>--%>


    <div>
    <table width="375" border="0" cellspacing="0" cellpadding="0">
      <tr>
       

<td><a href="#2151624#" id="a1" class="tab_selected" onclick ="ChangeForm(1)">User</a></td>
        <td><a href="#2151624#" id="a2" class="tab" onclick ="ChangeForm(2)">Administrator</a></td>
        <td><a href="#2151624#" id="a3" class="tab" onclick ="ChangeForm(3)">Day Off</a></td> 
      </tr>
    </table> 
<div id="div1"  >
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>User Information</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</div>

<div id="div2"  style="display:none" >
    <asp:Login ID="Login1" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Admin Information</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</div>

<div id="div3" style="display:none" >
<p>content 3</p>
</div>

    </div>

</asp:Content>

