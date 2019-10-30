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

Namespace Views
    Public Class empresa_incidenciadetalleController
        Inherits System.Web.Mvc.Controller

        Private db As New mmpContext

        ' GET: empresa_incidenciadetalle
        Function Index(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Filtrado = From s In db.empresa_incidenciadetalle Select s
            Filtrado = Filtrado.Where(Function(s) s.incidenciatipo_id = id).OrderBy(Function(s) s.incidenciadetalle_nombre_txt)

            If IsNothing(Filtrado) Then
                Return HttpNotFound()
            End If
            Return View(Filtrado.ToList())
        End Function

        ' GET: empresa_incidenciadetalle/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciadetalle As empresa_incidenciadetalle = db.empresa_incidenciadetalle.Find(id)
            If IsNothing(empresa_incidenciadetalle) Then
                Return HttpNotFound()
            End If
            Return View(empresa_incidenciadetalle)
        End Function

        ' GET: empresa_incidenciadetalle/Create
        Function Create() As ActionResult
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom")
            ViewBag.incidenciatipo_id = New SelectList(db.empresa_incidenciatipo, "incidenciatipo_id", "incidenciatipo_nombre_nom")
            Return View()
        End Function

        ' POST: empresa_incidenciadetalle/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="incidenciadetalle_id,empresa_id,incidenciatipo_id,incidenciadetalle_nombre_txt")> ByVal empresa_incidenciadetalle As empresa_incidenciadetalle) As ActionResult
            If ModelState.IsValid Then
                empresa_incidenciadetalle.empresa_id = gbl_empresaID
                db.empresa_incidenciadetalle.Add(empresa_incidenciadetalle)
                db.SaveChanges()
                Return RedirectToAction("Index/" & empresa_incidenciadetalle.incidenciatipo_id)
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciadetalle.empresa_id)
            ViewBag.incidenciatipo_id = New SelectList(db.empresa_incidenciatipo, "incidenciatipo_id", "incidenciatipo_nombre_nom", empresa_incidenciadetalle.incidenciatipo_id)
            Return View(empresa_incidenciadetalle)
        End Function

        ' GET: empresa_incidenciadetalle/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciadetalle As empresa_incidenciadetalle = db.empresa_incidenciadetalle.Find(id)
            If IsNothing(empresa_incidenciadetalle) Then
                Return HttpNotFound()
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciadetalle.empresa_id)
            ViewBag.incidenciatipo_id = New SelectList(db.empresa_incidenciatipo, "incidenciatipo_id", "incidenciatipo_nombre_nom", empresa_incidenciadetalle.incidenciatipo_id)
            Return View(empresa_incidenciadetalle)
        End Function

        ' POST: empresa_incidenciadetalle/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="incidenciadetalle_id,empresa_id,incidenciatipo_id,incidenciadetalle_nombre_txt")> ByVal empresa_incidenciadetalle As empresa_incidenciadetalle) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empresa_incidenciadetalle).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciadetalle.empresa_id)
            ViewBag.incidenciatipo_id = New SelectList(db.empresa_incidenciatipo, "incidenciatipo_id", "incidenciatipo_nombre_nom", empresa_incidenciadetalle.incidenciatipo_id)
            Return View(empresa_incidenciadetalle)
        End Function

        ' GET: empresa_incidenciadetalle/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciadetalle As empresa_incidenciadetalle = db.empresa_incidenciadetalle.Find(id)
            If IsNothing(empresa_incidenciadetalle) Then
                Return HttpNotFound()
            End If
            Return View(empresa_incidenciadetalle)
        End Function

        ' POST: empresa_incidenciadetalle/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim empresa_incidenciadetalle As empresa_incidenciadetalle = db.empresa_incidenciadetalle.Find(id)
            db.empresa_incidenciadetalle.Remove(empresa_incidenciadetalle)
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
