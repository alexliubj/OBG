<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ip.aspx.cs" Inherits="ip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
        font: normal 11px auto "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;   
        background-color: #ffffff;
        color: #4f6b72;      
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelLoc" runat="server">
                    <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
                    <asp:Button ID="btnGetLoc"
                        runat="server" Text="Get IP Details" onclick="btnGetLoc_Click" />
                    <br />
                    <asp:Xml ID="Xml1" runat="server"></asp:Xml>
 
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:UpdateProgress ID="updProgress"
        AssociatedUpdatePanelID="UpdatePanel1"
        runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/progress.gif"/>        
            </ProgressTemplate>
        </asp:UpdateProgress>
 
    </div>
    </form>
</body>
</html>
