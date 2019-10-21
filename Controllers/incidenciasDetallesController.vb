Imports System.Data.Entity
Imports System.Net
Imports System.Web.Mvc
Imports mmpAppNet
Imports mmpLibrerias

Namespace Controllers
    Public Class incidenciasDetallesController
        Inherits Controller

        Private db As New mmpContext
        ' GET: incidenciasDetalles
        Function Index() As ActionResult
            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(3407)

            If IsNothing(empresa_FacturaProducto) Then
                Return HttpNotFound()
            End If
            Return View(empresa_FacturaProducto)
        End Function
    End Class
End Namespace