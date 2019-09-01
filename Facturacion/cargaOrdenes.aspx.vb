Imports mmpLibrerias
Imports System.IO

Public Class cargaOrdenes
    Inherits System.Web.UI.Page
    Dim dtsOrden As DataSet
    Dim buenos As Long
    Dim total As Long
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
                total = GridView1.Rows.Count
                lbl_resultados.Text = "Cantidad de ordenes PRE-VISUALIZADAS ==> " & GridView1.Rows.Count
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

        For i = 0 To total - 1

            With dtsOrden.Tables(0).Rows(i)
                Try
                    Dim _cliente As New empresa_cliente(cnxMaster, gbl_empresaID, .Item("UserID"), .Item("Comprador"), 1, "cliente_direccionfacturacion_txt", "Direccion envio", "Telefono", .Item("email"))
                    buenos = buenos + _cliente.fnc_InsertaClientes()
                Catch ex As Exception

                End Try


            End With
        Next i

        btn_clientes.Text = "Clientes Cargados(" & buenos & ") - Error(" & total - buenos & ")"



    End Function



End Class