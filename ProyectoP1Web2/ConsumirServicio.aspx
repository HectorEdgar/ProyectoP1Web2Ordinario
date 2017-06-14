<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumirServicio.aspx.cs" Inherits="ProyectoP1Web2.ConsumirServicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Consumir servicio" />
    
    </div>
        <asp:ListBox ID="lb1" runat="server" Height="140px" Width="234px"></asp:ListBox>
    </form>
</body>
</html>
