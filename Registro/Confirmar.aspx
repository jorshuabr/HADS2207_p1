<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmar.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="texto" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Pulsa "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Inicio.aspx">aquí</asp:HyperLink>
&nbsp;<asp:Label ID="Label2" runat="server" Text=" para volver a la página de inicio."></asp:Label>
        </div>
    </form>
</body>
</html>
