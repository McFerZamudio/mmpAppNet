Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Crea_SP
        Inherits DbMigration

        Public Overrides Sub Up()
            CreateStoredProcedure("dbo.empresa_cliente_UpdateByCodigo", Function(p) New With {Key .cliente_id = p.Long, .empresa_id = p.Long, .cliente_codigo_c25 = p.String(maxLength:=25), .cliente_nombre_nom = p.String(maxLength:=25), .pais_id = p.Long, .cliente_direccionfacturacion_txt = p.String(), .cliente_direccionenvio_txt = p.String(), .cliente_Telefono_tel = p.String(maxLength:=200), .cliente_email_ema = p.String(maxLength:=200)},
                                    body:="UPDATE [dbo].[tbl_empresa_cliente]
                                    SET [empresa_id] = @empresa_id, [cliente_codigo_c25] = @cliente_codigo_c25, [cliente_nombre_nom] = @cliente_nombre_nom, [pais_id] = @pais_id, [cliente_direccionfacturacion_txt] = @cliente_direccionfacturacion_txt, [cliente_direccionenvio_txt] = @cliente_direccionenvio_txt, [cliente_Telefono_tel] = @cliente_Telefono_tel, [cliente_email_ema] = @cliente_email_ema
                                    WHERE ([cliente_codigo_c25] = @cliente_codigo_c25)")

        End Sub

        Public Overrides Sub Down()
            DropStoredProcedure("dbo.empresa_cliente_UpdateByCodigo")
        End Sub

    End Class
End Namespace
