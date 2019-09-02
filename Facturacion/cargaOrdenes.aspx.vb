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
        fnc_CargaCSV()

    End Sub
    Protected Sub btn_CargarDatos_Click(sender As Object, e As EventArgs) Handles btn_CargarDatos.Click
        Dim cargaCSV As New mmpLibrerias.Facturacion


        filename = lbl_Archivo.Text

        dtsOrden = cargaCSV.fnc_CargaCSV(filename)
        For i = 0 To dtsOrden.Tables(0).Rows.Count - 1
            fnc_CargaCliente(i)
        Next


        GridView1.DataSource = dtsOrden
        GridView1.DataBind()

        Try
            IO.File.Delete(filename)
        Catch ex As Exception

        End Try

    End Sub


#Region "Metodos"
    Private Sub sub_habilitaBotones()
        btn_clientes.Enabled = True
        btn_CargarDatos.Enabled = True
    End Sub
    Private Function fnc_CargaCSV() As Boolean
        Dim cargaCSV As New mmpLibrerias.Facturacion

        filename = Server.MapPath("~/App_Data/CSV/") + Path.GetFileName(FileUpload1.PostedFile.FileName).ToString

        dtsOrden = cargaCSV.fnc_CargaCSV(filename)
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
    Private Function fnc_CargaCliente(_pos As Long)
        With dtsOrden.Tables(0).Rows(_pos)
            Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), 1, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
            Dim _ResultadoGeneral() As String = Split(_cliente.fnc_InsertaClientes(), "|")
            Try
                If _ResultadoGeneral(0) = "1" Then
                    buenos = buenos + 1
                    dtsOrden.Tables(0).Rows(_pos)("Estado") = "OK"
                    dtsOrden.Tables(0).Rows(_pos)("Observaciones") = "Cliente Creado"
                    Exit Function
                End If

                If _ResultadoGeneral(0) = "2601" Then
                    _ResultadoGeneral = Split(_cliente.fnc_ActualizaClientes(), "|")
                    If _ResultadoGeneral(0) = "1" Then
                        buenos = buenos + 1
                        dtsOrden.Tables(0).Rows(_pos)("Estado") = "OK"
                        dtsOrden.Tables(0).Rows(_pos)("Observaciones") = "Cliente Actualizado"
                    End If
                End If
            Catch ex As Exception
                dtsOrden.Tables(0).Rows(_pos)("Estado") = "Error"
                dtsOrden.Tables(0).Rows(_pos)("Observaciones") = _ResultadoGeneral(1)
            End Try


        End With

        '    btn_clientes.Text = "Clientes Cargados(" & buenos & ") - Error(" & total - buenos & ")"



    End Function
#End Region



End Class