Imports mmpLibrerias
Imports System.IO

Public Class cargaOrdenes


    Inherits System.Web.UI.Page
    Dim dtsOrden As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Previsualizar.Click
        Dim cargaCSV As New mmpLibrerias.Facturacion

        Dim filename As String = Server.MapPath("~/App_Data/CSV/") + Path.GetFileName(FileUpload1.PostedFile.FileName).ToString
        FileUpload1.SaveAs(filename)

        dtsOrden = cargaCSV.fnc_CargaCSV(filename)
        If IsNothing(dtsOrden) = False Then
            GridView1.DataSource = dtsOrden
            GridView1.DataBind()
            If GridView1.Rows.Count > 0 Then
                lbl_resultados.Text = "Cantidad de ordenes PRE-CARGADAS ==> " & GridView1.Rows.Count
                sub_habilitaBotones()
                fnc_CargaCliente()
            End If
        End If


        IO.File.Delete(filename)
    End Sub
    Private Sub sub_habilitaBotones()
        btn_clientes.Enabled = True
    End Sub

    Private Function fnc_CargaCliente()

        With dtsOrden.Tables(0).Rows(0)
            Try
                Dim _cliente As New empresa_cliente(gbl_empresaID, .Item("codigo_c25"), .Item("cliente_nombre_nom"), 1, .Item("cliente_direccionfacturacion_txt"), .Item("cliente_id"), .Item("cliente_id"), .Item("cliente_id"))
            Catch ex As Exception

            End Try



        End With



    End Function



End Class