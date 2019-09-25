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

Namespace Facturacion
    Public Class empresa_facturaController
        Inherits System.Web.Mvc.Controller

        Private db As New mmpContext

        ' GET: empresa_factura
        Function Index() As ActionResult
            Dim empresa_factura = db.empresa_factura.Include(Function(e) e.Empresas)
            Return View(empresa_factura.ToList())
        End Function

        ' GET: empresa_factura/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_factura As empresa_factura = db.empresa_factura.Find(id)
            If IsNothing(empresa_factura) Then
                Return HttpNotFound()
            End If
            Return View(empresa_factura)
        End Function

        ' GET: empresa_factura/Create
        Function Create() As ActionResult
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom")
            Return View()
        End Function

        ' POST: empresa_factura/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ventadocumento_id,empresa_id,ventadocumento_venta_codigo_c25,ventadocumento_venta_NroControl_lon,ventadocumento_venta_fecha_dat,ventadocumento_fecha_modificacion_dat,clientes_id,cliente_codigo_c25,cliente_nombre_nom,cliente_direccionfiscal_txt,cliente_direccionenvio_txt,cliente_telefono_tel,pais_id,canalventas_id,canalventa_nombre_nom,canalventa_comisionporc_dec,venta_comisioncanalventa_dec,canalpagos_id,canalpago_nombre_nom,canalpago_comisionpago_dec,ventadocumento_descotrosgastos_txt,ventadocumento_totalotrosgastos_dec,total_item_precioventatotal_dec,total_producto_comisionventa_dec,total_item_iva_dec,total_item_costototal_dec,total_paquete_costotransporte_dec,total_item_otroscostos_dec")> ByVal empresa_factura As empresa_factura) As ActionResult
            If ModelState.IsValid Then
                db.empresa_factura.Add(empresa_factura)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_factura.empresa_id)
            Return View(empresa_factura)
        End Function

        ' GET: empresa_factura/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_factura As empresa_factura = db.empresa_factura.Find(id)
            If IsNothing(empresa_factura) Then
                Return HttpNotFound()
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_factura.empresa_id)
            Return View(empresa_factura)
        End Function

        ' POST: empresa_factura/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ventadocumento_id,empresa_id,ventadocumento_venta_codigo_c25,ventadocumento_venta_NroControl_lon,ventadocumento_venta_fecha_dat,ventadocumento_fecha_modificacion_dat,clientes_id,cliente_codigo_c25,cliente_nombre_nom,cliente_direccionfiscal_txt,cliente_direccionenvio_txt,cliente_telefono_tel,pais_id,canalventas_id,canalventa_nombre_nom,canalventa_comisionporc_dec,venta_comisioncanalventa_dec,canalpagos_id,canalpago_nombre_nom,canalpago_comisionpago_dec,ventadocumento_descotrosgastos_txt,ventadocumento_totalotrosgastos_dec,total_item_precioventatotal_dec,total_producto_comisionventa_dec,total_item_iva_dec,total_item_costototal_dec,total_paquete_costotransporte_dec,total_item_otroscostos_dec")> ByVal empresa_factura As empresa_factura) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empresa_factura).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_factura.empresa_id)
            Return View(empresa_factura)
        End Function

        ' GET: empresa_factura/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_factura As empresa_factura = db.empresa_factura.Find(id)
            If IsNothing(empresa_factura) Then
                Return HttpNotFound()
            End If
            Return View(empresa_factura)
        End Function

        ' POST: empresa_factura/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim empresa_factura As empresa_factura = db.empresa_factura.Find(id)
            db.empresa_factura.Remove(empresa_factura)
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
