<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaPréstamos.aspx.cs" Inherits="ListaPréstamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista de préstamos de un cliente</title>
    <style type="text/css">
        #form1 {
            height: 651px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #FF9933">
    <div style="background-color: #FFCC66; height: 624px;">
    
        <asp:Table ID="TblUsuario" runat="server" BorderStyle="Double" GridLines="Both" style="z-index: 1; left: 264px; top: 102px; position: absolute; height: 54px; width: 372px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">RFC</asp:TableCell>
                <asp:TableCell runat="server">Nombre</asp:TableCell>
                <asp:TableCell runat="server">Domicilio</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" style="z-index: 1; left: 23px; top: 599px; position: absolute">Pägina principal</asp:HyperLink>
    
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 362px; top: 51px; position: absolute" Text="Préstamos de un cliente"></asp:Label>
    
    </div>
    </form>
</body>
</html>
