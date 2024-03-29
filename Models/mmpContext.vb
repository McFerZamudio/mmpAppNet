﻿Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration
Imports System.Data.Entity.ModelConfiguration.Conventions

Public Class mmpContext
    Inherits DbContext
    Private my_mppLibreria As mmpLibrerias.Modelos
#Region "Configuracion"
    Public Property empresa_maestro As DbSet(Of mmpLibrerias.maestro_empresa)
    Public Property empresa_pais As DbSet(Of mmpLibrerias.empresa_pais)
    Public Property empresa_canalpago As DbSet(Of mmpLibrerias.empresa_canalpago)
    Public Property empresa_canallogistico As DbSet(Of mmpLibrerias.empresa_canallogistico)
    Public Property empresa_canalventa As DbSet(Of mmpLibrerias.empresa_canalventa)
    Public Property empresa_clientes As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_cliente)
    Public Property empresa_producto As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_producto)
    Public Property empresa_factura As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_factura)
    Public Property empresa_FacturaProducto As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_FacturaProducto)
    Public Property empresa_incidenciatipo As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_incidenciatipo)
    Public Property empresa_incidenciadetalle As System.Data.Entity.DbSet(Of mmpLibrerias.empresa_incidenciadetalle)


    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()

        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.maestro_empresa)("maestro_empresa", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_pais)("empresa_pais", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_canalpago)("empresa_canalpago", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_canallogistico)("empresa_canallogistico", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_canalventa)("empresa_canalventa", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_cliente)("empresa_cliente", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_producto)("empresa_producto", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_factura)("empresa_factura", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_FacturaProducto)("empresa_FacturaProducto", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_incidenciatipo)("empresa_incidenciatipo", modelBuilder)
        my_mppLibreria.CreaTablaGeneral(Of mmpLibrerias.empresa_incidenciadetalle)("empresa_incidenciadetalle", modelBuilder)



    End Sub


#End Region


    Public Sub New()
        Try
            my_mppLibreria = New mmpLibrerias.Modelos(My.Settings.cnxMaster)
            MyBase.Database.Connection.ConnectionString = cnxMaster
        Catch ex As Exception

        End Try
    End Sub


End Class