<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cargaOrdenes.aspx.vb" Inherits="mmpAppNet.cargaOrdenes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        body  
        {  
            font-family: Arial;  
            font-size: 10pt;  
        }  
        table  
        {  
            border: 1px solid #ccc;  
            border-collapse: collapse;  
            background-color: #fff;  
        }  
        table th  
        {  
            background-color: #ff7f00;  
            color: #fff;  
            font-weight: bold;  
        }  
        table th, table td  
        {  
            padding: 5px;  
            border: 1px solid #ccc;  
        }  
        table, table table td  
        {  
            border: 0px solid #ccc;  
        }  
        .button {  
    background-color: #0094ff; /* Blue */  
    border: none;  
    color: white;  
    padding: 15px 32px;  
    text-align: center;  
    text-decoration: none;  
    display: inline-block;  
    font-size: 16px;  
}  
        .auto-style1 {
            height: -42px;
        }
    </style>  
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>  
<body>  
    <form id="form1" runat="server">  
        <asp:FileUpload ID="FileUpload1" multiple="false" runat="server" Width="100%" />
        &nbsp;<asp:Button ID="btn_Previsualizar" runat="server" Text="Previsualizacion de datos" Width="169px" />
    &nbsp;<asp:Button ID="btn_CargarDatos" runat="server" Text="Cargar Datos" Width="169px" />
    &nbsp;<asp:Label ID="lbl_resultados" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbl_Archivo" runat="server"></asp:Label>
    <asp:GridView ID="GridView1" runat="server">  
    </asp:GridView>  
        <asp:TextBox ID="TextBox1" runat="server" Height="166px" Visible="False" Width="797px"></asp:TextBox>
    </form>  
</body>  
</html>  