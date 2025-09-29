Imports System.Data.SqlClient

Module ModuleDB
    ' Change the Data Source to match your SQL Server instance
    Public connectionString As String =
    "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SweetDelight;Integrated Security=True"


    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
End Module
