Module modMain
    Public gbl_empresaID As Long = 1
    Public gbl_usuario As String = "fzamudio"
    Public cnxMaster As String = My.Settings.cnxMaster
    'Public cnxMaster As String = My.Settings.cnxEmergencia

    Public Function fnc_BuscaPais(_NombrePais As String, ByRef _cnx As SqlClient.SqlConnection) As String

        Dim cmd As New SqlClient.SqlCommand("pa_pais_empresa_FindIDByNombre", _cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@pais_nombre_nom", _NombrePais)

        Using lee As SqlClient.SqlDataReader = cmd.ExecuteReader
            If lee.Read Then
                Return lee("pais_id")
            Else
                Return 1
            End If
        End Using

        Return Nothing
    End Function

End Module
