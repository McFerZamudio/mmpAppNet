Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Crea_SP
        Inherits DbMigration

        Public Overrides Sub Up()
            CreateStoredProcedure("dbo.Movie_Insert", Function(p) New With {Key .Name = p.String(maxLength:=50), Key .ReleaseDate = p.DateTime(), Key .Category = p.String()
    }, body:="INSERT [dbo].[Movies]([Name], [ReleaseDate], [Category2])  
                              VALUES (@Name, @ReleaseDate, @Category)  

                              DECLARE @ID int  
                              SELECT @ID = [ID]  
                              FROM [dbo].[Movies]  
                              WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()  

                              SELECT t0.[ID]  
                              FROM [dbo].[Movies] AS t0  
                              WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID")
        End Sub

        Public Overrides Sub Down()
            DropStoredProcedure("dbo.Movie_Insert")
        End Sub



    End Class
End Namespace
