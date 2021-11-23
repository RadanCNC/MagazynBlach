
Imports System.Data.Sql
Imports System.Data.SqlClient

'Klasa do połączenia z bazą danych SQL
' https://www.youtube.com/watch?v=D3C7wcAgSJQ

Public Class SqlCon

    Public conector As String
    Public polaczenieSQL = "Server=WROCLAW_SZ_4" & "; Database=ArkuszeDB" &
                                                 "; User=kamil" & ";Pwd=kamil123"

    Public SQLConect As New SqlConnection With {.ConnectionString = polaczenieSQL}
    Public SQLCmd As SqlCommand

    'Db Data
    Public DBDA As SqlDataAdapter
    Public DBDT As DataTable
    'Public SQLDS As DataSet

    ' Query Parameters
    Public Params As New List(Of SqlParameter)

    'Query Statistics
    Public RecordCount As Integer
    Public RecordCount2 As Integer
    Public Exception As String

    Public Sub New()

    End Sub
    ' Pozwól nna nadpisanie łańcucha połączenia
    Public Sub New(ConnectionString As String)
        SQLConect = New SqlConnection(ConnectionString)

    End Sub

    Public Sub ExecQuery(Query As String)
        ' REset Query Stats
        RecordCount = 0
        '  RecordCount2 = 0
        Exception = ""
        Try
            SQLConect.Open()
            'Create DB Command
            SQLCmd = New SqlCommand(Query, SQLConect)

            'Load Params into Db Command
            Params.ForEach(Sub(p) SQLCmd.Parameters.Add(p))
            'Clear param list
            Params.Clear()

            'Execute Command & fill dataset
            DBDT = New DataTable
            DBDA = New SqlDataAdapter(SQLCmd)
            ' SQLDS = New DataSet
            RecordCount = DBDA.Fill(DBDT)
            ' RecordCount2 = DBDA.Fill(SQLDS)
        Catch ex As Exception
            'Przechwytywanie błędów
            Exception = " ExcecQuery Error: " & vbNewLine & ex.Message

        Finally
            'Zamknij połączenie
            If SQLConect.State = ConnectionState.Open Then SQLConect.Close()

        End Try
    End Sub

    'Definicja funkcji do sprawdzania połączenia
    Public Function HasConnection() As Boolean
        Try
            SQLConect.Open()
            SQLConect.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Dodawanie nowych rekordów do bazy
    Public Sub AddParam(Name As String, value As Object)
        Dim NewParam As New SqlParameter(Name, value)
        Params.Add(NewParam)
    End Sub

    'Obsługa błędów
    Public Function HasException(Optional report As Boolean = True) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If report = True Then MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
        Return True
    End Function

    'Obsługa błędów bez komunikatu
    Public Function HasExceptionBezKomunikatu(Optional report As Boolean = True) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If report = True Then
            'MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
        End If
        Return True
    End Function

End Class

