Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of mmpContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            AutomaticMigrationDataLossAllowed = True
        End Sub

        Protected Overrides Sub Seed(context As mmpContext)

            Dim _empresa As New mmpLibrerias.maestro_empresa
            _empresa.empresa_uid_nom = "0000"
            _empresa.empresa_nombre_nom = "Empresa de Prueba"
            _empresa.empresa_pwd_nom = "123456"
            _empresa.empresa_fechacreacion_nom = Now
            _empresa.empresa_usuariocreador_nom = "Sistema"
            context.empresa_maestro.AddOrUpdate(Function(p) p.empresa_uid_nom, _empresa)
            context.SaveChanges()

            Dim _Pais As New mmpLibrerias.empresa_pais
            _Pais.empresa_id = 1
            _Pais.pais_iva_dec = 17
            _Pais.pais_nombre_nom = "España"
            context.empresa_pais.AddOrUpdate(Function(p) p.pais_nombre_nom, _Pais)
            context.SaveChanges()

        End Sub




    End Class

End Namespace
