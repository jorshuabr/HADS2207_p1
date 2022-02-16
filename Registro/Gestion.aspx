<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gestion.aspx.cs" Inherits="Registro.Gestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="¡Bienvenid@ a HADS22-07!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Sigue así, ¡seguro que sacarás matrícula!"></asp:Label>
            <br />
            <br />
            <asp:Button ID="logout" runat="server" OnClick="logout_Click" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
