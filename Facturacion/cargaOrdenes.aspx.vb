Imports mmpLibrerias
Imports System.IO

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
        If IsNothing(dtsOrden) = False Then

            GridView1.DataSource = dtsOrden
            GridView1.DataBind()
            If GridView1.Rows.Count > 0 Then
                total = GridView1.Rows.Count
                lbl_resultados.Text = "Cantidad de ordenes PRE-VISUALIZADAS ==> " & GridView1.Rows.Count
                sub_habilitaBotones()
                lbl_Archivo.Text = filename
            End If
        End If
        GridView1.DataBind()
    End Function
    Private Function fnc_ExportaCVStoDTS() As Boolean
        Dim cargaCSV As New mmpLibrerias.Facturacion

        filename = lbl_Archivo.Text
        Using _cnx As New SqlClient.SqlConnection(cnxMaster)
            _cnx.Open()
            dtsOrden = cargaCSV.fnc_CargaCSVtoDTS(filename, True)
            For i = 0 To dtsOrden.Tables(0).Rows.Count - 1
                fnc_AgregaClientetoDB(i, _cnx)
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
            'Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), 2, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
            '  Dim _ResultadoGeneral() As String = Split(_TablaOBJ.fnc_Inserta(_cnxMasterDB), "|")
            Dim _ResultadoGeneral() As String = Split(_TablaOBJ.fnc_Migracion(_cnxMasterDB), "|")



            Try
                If _ResultadoGeneral(0) = "1" Then
                    buenos = buenos + 1
                    fnc_ValidaGrid(_pos, _tabla, _ResultadoGeneral(1), "OK")
                    Exit Function
                End If

                dtsOrden.Tables(0).Rows(_pos)("EstadoGeneral") = "Error"
            Catch ex As Exception
                dtsOrden.Tables(0).Rows(_pos)("Estado") = "Error"
                dtsOrden.Tables(0).Rows(_pos)("Observaciones") = _ResultadoGeneral(1)
            End Try


        End With

        '    btn_clientes.Text = "Clientes Cargados(" & buenos & ") - Error(" & total - buenos & ")"



    End Function



    Private Function fnc_AgregaClientetoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), 2, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
            fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _cliente, "Cliente")
        End With
    End Function

    Private Function fnc_AgregaProductostoDB(_pos As Long, _cnxMasterDB As SqlClient.SqlConnection)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), 2, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
            'fnc_AgregaGeneraltoDB(_pos, _cnxMasterDB, _cliente, "Cliente")
        End With
    End Function


#End Region

#Region "Metodos Capa Presentacion"
    Private Sub sub_habilitaBotones()
        btn_clientes.Enabled = True
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