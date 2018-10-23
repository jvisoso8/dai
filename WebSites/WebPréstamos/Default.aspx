<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aplicación Web con acceso a BD</title>
    <style type="text/css">
        #form1 {
            height: 636px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #FFCC66">
    <div style="background-color: #FF9933; height: 609px;">
    
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" style="z-index: 1; left: 248px; top: 96px; position: absolute; height: 147px; width: 342px">
        </asp:Login>
    
    </div>
    </form>
</body>
</html>
