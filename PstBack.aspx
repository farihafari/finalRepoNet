<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PstBack.aspx.cs" Inherits="WebApp1.PstBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Postback</h1>
            <asp:Label ID="lblMessage" runat="server" Text="Welcome to ASP.NET 
Web Forms"></asp:Label> 
        <br /><br /> 
         
        <asp:Button ID="btnClick" runat="server" Text="Click Me" 
OnClick="btnClick_Click" /> 
        <br /><br /> 
         
        <asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" 
OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged"> 
            <asp:ListItem Text="Select an option" Value="" /> 
            <asp:ListItem Text="Option 1" Value="1" /> 
            <asp:ListItem Text="Option 2" Value="2" /> 
            <asp:ListItem Text="Option 3" Value="3" /> 
        </asp:DropDownList> 
         
        <br /><br /> 
        <asp:Label ID="lblSelected" runat="server" Text=""></asp:Label> 
        </div>
    </form>
</body>
</html>
