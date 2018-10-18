<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminAvalesPrest.aspx.cs" Inherits="AdminAvalesPrest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin. de avales con préstamos</title>
    <style type="text/css">
        #form1 {
            height: 758px;
        }
    </style>
</head>
<body style="height: 788px">
    <form id="form1" runat="server" style="background-color: #FFCC66">
    <div style="height: 713px; background-color: #FFCC99;">
    
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 369px; top: 71px; position: absolute" Text="Administración de avales y los préstamos que avalan."></asp:Label>
        <asp:Button ID="BtnAlta" runat="server" OnClick="BtnAlta_Click" style="z-index: 1; left: 145px; top: 136px; position: absolute; width: 160px" Text="Alta" />
        <asp:Label ID="LblMensaje" runat="server" style="z-index: 1; left: 60px; top: 511px; position: absolute" Text="Operación: en espera"></asp:Label>
        <asp:DropDownList ID="DdlAvales" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DdlAvales_SelectedIndexChanged" style="z-index: 1; left: 252px; top: 223px; position: absolute; height: 21px; width: 127px" Visible="False">
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 56px; top: 193px; position: absolute; right: 1123px" Text="Préstamos:" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 256px; top: 195px; position: absolute" Text="Avales:" Visible="False"></asp:Label>
        <asp:TextBox ID="TxtMonto" runat="server" Enabled="False" style="z-index: 1; left: 159px; top: 309px; position: absolute; width: 125px" Visible="False">50000</asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 161px; top: 284px; position: absolute" Text="Monto:" Visible="False"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" style="z-index: 1; left: 61px; top: 576px; position: absolute">Página inicial</asp:HyperLink>
        <asp:Button ID="BtnEjecuta" runat="server" Enabled="False" OnClick="BtnEjecuta_Click" style="z-index: 1; left: 447px; top: 507px; position: absolute; width: 157px" Text="Ejecutar" Visible="False" />
        <asp:Button ID="BtnBaja" runat="server" style="z-index: 1; left: 402px; top: 136px; position: absolute; width: 88px; right: 418px" Text="Baja" />
        <asp:Button ID="BtnCambia" runat="server" style="z-index: 1; left: 589px; top: 134px; position: absolute; width: 144px" Text="Cambia monto" />
        <asp:DropDownList ID="DdlPréstamos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPréstamos_SelectedIndexChanged" style="z-index: 1; left: 52px; top: 223px; position: absolute; height: 19px; width: 124px; right: 732px" Visible="False">
        </asp:DropDownList>
    
        <asp:GridView ID="GrdAvalan" runat="server" Caption="Préstamos y sus avales" Enabled="False" style="z-index: 1; left: 457px; top: 223px; position: absolute; height: 152px; width: 232px">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
