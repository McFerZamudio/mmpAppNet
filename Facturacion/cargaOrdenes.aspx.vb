Imports mmpLibrerias
Imports System.Globalization
Imports System.IO
Imports System.Threading

Public Class cargaOrdenes
    Inherits System.Web.UI.Page
    Dim dtsOrden As DataSet
    Dim buenos As Long
    Dim total As Long
    Dim filename As String


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Previsualizar.Click
        filename = Server.MapPath("~/App_Data/CSV/") + Path.GetFileName(FileUpload1.PostedFile.FileName).ToString
        FileUpload1.SaveAs(filename)
        fnc_CargaArchivoCSVtoGRID()
    End Sub
    Protected Sub btn_CargarDatos_Click(sender As Object, e As EventArgs) Handles btn_CargarDatos.Click
        fnc_ExportaCVStoDTS()
    End Sub
#Region "Metodos Capa Negocio"
    Private Function fnc_CargaArchivoCSVtoGRID() As Boolean
        Dim cargaCSV As New mmpLibrerias.Facturacion

        filename = Server.MapPath("~/App_Data/CSV/") + Path.GetFileName(FileUpload1.PostedFile.FileName).ToString

        dtsOrden = cargaCSV.fnc_CargaCSVtoDTS(filename, False)
        TextBox1.Text = "Cargo DTS"
        If IsNothing(dtsOrden) = False Then

            GridView1.DataSource = dtsOrden
            GridView1.DataBind()
            TextBox1.Text = "Hizo binding"
            If GridView1.Rows.Count > 0 Then
                TextBox1.Text = "Cant " & GridView1.Rows.Count
                total = GridView1.Rows.Count
                lbl_resultados.Text = "Cantidad de ordenes PRE-VISUALIZADAS ==> " & GridView1.Rows.Count
                sub_habilitaBotones()
                lbl_Archivo.Text = filename
                TextBox1.Text = "Agrego Nombre"
            End If
        Else
            TextBox1.Text = cargaCSV._Error
            TextBox1.Visible = True
        End If
        GridView1.DataBind()
    End Function
    Private Function fnc_ExportaCVStoDTS() As Boolean
        Dim cargaCSV As New mmpLibrerias.Facturacion

        filename = lbl_Archivo.Text
        Using _cnx As New SqlClient.SqlConnection(cnxMaster)
            _cnx.Open()
            dtsOrden = cargaCSV.fnc_CargaCSVtoDTS(filename, True)
            For i = 0 To 25 'dtsOrden.Tables(0).Rows.Count - 1
                fnc_AgregaClientetoDB(i, _cnx)
                fnc_AgregaProductostoDB(i, _cnx)

                Dim _NroFactura As Long
                _NroFactura = fnc_AgregaFacturatoDB(i, _cnx)
                fnc_AgregaFacturaProductotoDB(_NroFactura, i, _cnx)
            Next
            _cnx.Close()
            _cnx.Close()
        End Using

        GridView1.DataSource = dtsOrden
        GridView1.DataBind()
        Return True
    End Function
#End Region

#Region "Capa Datos"
    Private Function fnc_AgregaGeneraltoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection, _TablaOBJ As Object, _tabla As String)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _ResultadoGeneral() As String = Split(_TablaOBJ.fnc_Migracion(_cnxMasterDB), "|")

            Try
                If _ResultadoGeneral(0) = "1" Then
                    buenos = buenos + 1
                    fnc_ValidaGrid(_pos, _tabla, _ResultadoGeneral(1), "OK")
                    Exit Function
                End If

                dtsOrden.Tables(0).Rows(_pos)("Estado General") = "Error " & _ResultadoGeneral(1)
            Catch ex As Exception
                dtsOrden.Tables(0).Rows(_pos)("Estado General") = "Error " & ex.Message
                'dtsOrden.Tables(0).Rows(_pos)("Observaciones") = _ResultadoGeneral(1)
            End Try


        End With

        '    btn_clientes.Text = "Clientes Cargados(" & buenos & ") - Error(" & total - buenos & ")"



    End Function

    Private Function fnc_AgregaClientetoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _paisID As Long

            _paisID = fnc_BuscaPais(.Item("País"), _cnxMasterDB)
            Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), _paisID, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
            fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _cliente, "Cliente")
        End With
    End Function

    Private Function fnc_AgregaProductostoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _Producto As New empresa_producto(cnxMaster, gbl_empresaID, .Item("ID Item Ebay"), .Item("Producto"), "", "", .Item("Imagen"), .Item("sku"), 1, 0, .Item("Precio de Compra"), .Item("Total"), .Item("Beneficio"), 0, 0, .Item("enlace a producto"))
            fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _Producto, "Producto")
        End With
    End Function

    Private Function fnc_AgregaFacturatoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection) As Long
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _Factura As New empresa_factura
            Dim _paisID As Long

            _paisID = fnc_BuscaPais(.Item("País"), _cnxMasterDB)

            Dim en As New CultureInfo("es-ES")
            Thread.CurrentThread.CurrentCulture = en
            _Factura.CargaDatosGenerales(gbl_empresaID, 0, 0, .Item("fecha"), .Item("fecha"), 0, .Item("userid"), .Item("Comprador"), .Item("Dirección cliente"), .Item("Dirección cliente"), "", _paisID)

            _Factura.CargaDatosVentas(.Item("ID pedido Ebay"), 0, "Ebay", 0, 0, 0, "", 0, "", 0, 0, 0, 0, .Item("Total"), 0, 0)

            fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _Factura, "Factura")

            Return _Factura.ventadocumento_id

        End With
    End Function

    Private Function fnc_AgregaFacturaProductotoDB(_NroFactura As Long, _pos As Long, _cnxMasterDB As SqlClient.SqlConnection)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _FacturaProducto As New empresa_FacturaProducto
            Dim en As New CultureInfo("es-ES")
            Thread.CurrentThread.CurrentCulture = en
            _FacturaProducto.CargaProductoVenta(_NroFactura, .Item("ID Item Ebay"), .Item("imagen"), .Item("producto"), Replace(.Item("unidades"), ".", ","), .Item("sku"), .Item("enlace a producto"), Replace(.Item("Precio de Compra"), ".", ","), Replace(.Item("Total") / .Item("unidades"), ".", ","), Replace(.Item("beneficio"), ".", ","))

            fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _FacturaProducto, "ProductoVendido")

        End With


    End Function
#End Region

#Region "Metodos Capa Presentacion"
    Private Sub sub_habilitaBotones()
        btn_CargarDatos.Enabled = True
    End Sub
    Private Function fnc_ValidaGrid(_pos As Long, _Campo As String, _Accion As String, _Resultado As String) As Boolean
        Try
            dtsOrden.Tables(0).Rows(_pos)("Estado " & _Campo) = _Resultado
            dtsOrden.Tables(0).Rows(_pos)("Observaciones " & _Campo) = _Accion
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Class