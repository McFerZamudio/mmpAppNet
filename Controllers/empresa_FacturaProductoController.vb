Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports mmpAppNet
Imports mmpLibrerias

Namespace Controllers
    Public Class empresa_FacturaProductoController
        Inherits System.Web.Mvc.Controller

        Private db As New mmpContext

        '' GET: empresa_FacturaProducto
        'Function Index(ByVal id As Long?) As ActionResult
        '    Dim empresa_FacturaProducto = db.empresa_FacturaProducto.Include(Function(e) e.Factura)
        '    Return View(empresa_FacturaProducto.ToList())
        'End Function

        Function Index(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(id)

            Dim Filtrado = From s In db.empresa_FacturaProducto Select s

            Filtrado = Filtrado.Where(Function(s) s.ventadocumento_id = id)
            Dim f As New DataSet

            Dim cant As Long = Filtrado.Count



            If IsNothing(Filtrado) Then
                Return HttpNotFound()
            End If
            Return View(Filtrado.ToList())

        End Function

        ' GET: empresa_FacturaProducto/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(id)
            If IsNothing(empresa_FacturaProducto) Then
                Return HttpNotFound()
            End If
            Return View(empresa_FacturaProducto)
        End Function

        ' GET: empresa_FacturaProducto/Create
        Function Create() As ActionResult
            ViewBag.ventadocumento_id = New SelectList(db.empresa_factura, "ventadocumento_id", "ventadocumento_venta_codigo_c25")
            Return View()
        End Function

        ' POST: empresa_FacturaProducto/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ventaproduco_id,ventadocumento_id,producto_codigo_txt,Producto_imagen_txt,producto_nombre_txt,producto_unidades_dec,producto_sku_txt,producto_enlace_txt,producto_preciocompra_dec,producto_beneficio_dec,producto_incidencia_txt")> ByVal empresa_FacturaProducto As empresa_FacturaProducto) As ActionResult
            If ModelState.IsValid Then
                db.empresa_FacturaProducto.Add(empresa_FacturaProducto)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ventadocumento_id = New SelectList(db.empresa_factura, "ventadocumento_id", "ventadocumento_venta_codigo_c25", empresa_FacturaProducto.ventadocumento_id)
            Return View(empresa_FacturaProducto)
        End Function

        ' GET: empresa_FacturaProducto/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(id)
            If IsNothing(empresa_FacturaProducto) Then
                Return HttpNotFound()
            End If
            ViewBag.ventadocumento_id = New SelectList(db.empresa_factura, "ventadocumento_id", "ventadocumento_venta_codigo_c25", empresa_FacturaProducto.ventadocumento_id)
            Return View(empresa_FacturaProducto)
        End Function

        ' POST: empresa_FacturaProducto/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ventaproduco_id,ventadocumento_id,producto_codigo_txt,Producto_imagen_txt,producto_nombre_txt,producto_unidades_dec,producto_sku_txt,producto_enlace_txt,producto_preciocompra_dec,producto_beneficio_dec,producto_incidencia_txt")> ByVal empresa_FacturaProducto As empresa_FacturaProducto) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empresa_FacturaProducto).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("../empresa_FacturaProducto/Index/" & empresa_FacturaProducto.ventadocumento_id)
            End If
            ViewBag.ventadocumento_id = New SelectList(db.empresa_factura, "ventadocumento_id", "ventadocumento_venta_codigo_c25", empresa_FacturaProducto.ventadocumento_id)
            Return View(empresa_FacturaProducto)
        End Function

        ' GET: empresa_FacturaProducto/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(id)
            If IsNothing(empresa_FacturaProducto) Then
                Return HttpNotFound()
            End If
            Return View(empresa_FacturaProducto)
        End Function

        ' POST: empresa_FacturaProducto/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim empresa_FacturaProducto As empresa_FacturaProducto = db.empresa_FacturaProducto.Find(id)
            db.empresa_FacturaProducto.Remove(empresa_FacturaProducto)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
