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
    Public Class empresa_incidenciatipoController
        Inherits System.Web.Mvc.Controller

        Private db As New mmpContext

        ' GET: empresa_incidenciatipo
        Function Index() As ActionResult
            Dim empresa_incidenciatipo = db.empresa_incidenciatipo.Include(Function(e) e.empresa)
            Return View(empresa_incidenciatipo.ToList())
        End Function

        ' GET: empresa_incidenciatipo/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciatipo As empresa_incidenciatipo = db.empresa_incidenciatipo.Find(id)
            If IsNothing(empresa_incidenciatipo) Then
                Return HttpNotFound()
            End If
            Return View(empresa_incidenciatipo)
        End Function

        ' GET: empresa_incidenciatipo/Create
        Function Create() As ActionResult
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom")
            Return View()
        End Function

        ' POST: empresa_incidenciatipo/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="incidenciatipo_id,empresa_id,incidenciatipo_nombre_nom")> ByVal empresa_incidenciatipo As empresa_incidenciatipo) As ActionResult
            If ModelState.IsValid Then
                db.empresa_incidenciatipo.Add(empresa_incidenciatipo)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciatipo.empresa_id)
            Return View(empresa_incidenciatipo)
        End Function

        ' GET: empresa_incidenciatipo/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciatipo As empresa_incidenciatipo = db.empresa_incidenciatipo.Find(id)
            If IsNothing(empresa_incidenciatipo) Then
                Return HttpNotFound()
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciatipo.empresa_id)
            Return View(empresa_incidenciatipo)
        End Function

        ' POST: empresa_incidenciatipo/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="incidenciatipo_id,empresa_id,incidenciatipo_nombre_nom")> ByVal empresa_incidenciatipo As empresa_incidenciatipo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empresa_incidenciatipo).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.empresa_id = New SelectList(db.empresa_maestro, "empresa_id", "empresa_nombre_nom", empresa_incidenciatipo.empresa_id)
            Return View(empresa_incidenciatipo)
        End Function

        ' GET: empresa_incidenciatipo/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresa_incidenciatipo As empresa_incidenciatipo = db.empresa_incidenciatipo.Find(id)
            If IsNothing(empresa_incidenciatipo) Then
                Return HttpNotFound()
            End If
            Return View(empresa_incidenciatipo)
        End Function

        ' POST: empresa_incidenciatipo/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim empresa_incidenciatipo As empresa_incidenciatipo = db.empresa_incidenciatipo.Find(id)
            db.empresa_incidenciatipo.Remove(empresa_incidenciatipo)
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
