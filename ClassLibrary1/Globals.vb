Imports System.IO

Module Globals

    'Log do zapisu działań i błędów
    Public OknoFlowLoga As New FlowLog

    Public Sub DoFlowLogaDoPliku2(ByVal tekst As String)
        OknoFlowLoga.RichTextBox1.Text = OknoFlowLoga.RichTextBox1.Text & tekst & vbNewLine
    End Sub

    Public Sub DoFlowLogaDoPliku(ByVal tekst As String)
        Using sw As StreamWriter = File.AppendText(SciezkaDoPlikuLog)
            'Wpisz datę, nazwe użytkownika oraz wpis
            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & " " &
                         nazwaUzytkownika & " " & tekst)
        End Using
    End Sub


    Public sql As New SqlCon                                        'Połączenie z bazą danych

    Public myApp As Radraft.Interop.Application                     'Global object -Radraftapplication 

    Public myMac As Radraft.Interop.Mac                             'Global object -macro 


    Public Kolumny As New List(Of String)                 'Nazwy kolumn w datagridview1 w ImportBlach

    Public RemnantSaveFolder As String                              'Public OdpadyDoUzycia As String

    Public SciezkaProjektu As String                                'Sciezka do projektu

    Public SciezkaOdpadowDoUzyciaWProjekcie As String

    Public OdpadyDoUzyciaWBazie As String = "C:\OdpadyDoUzycia\"

    Public SciezkaDoPlikuLog As String

    Public nazwaUzytkownika As String                              'Nazwa użytkownika Radan

    'Flaga służy do sprawdzenia czy użytkownik wyszedł z projektu i zrobił rezerwację
    Public flaga As Boolean = False

    'Funkcja wyświetla wynik zapytania w podanym przez nas datagridview
    Public Sub Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ByVal Zapytanie As String, ByRef DataGRid As Windows.Forms.DataGridView)
        Try
            sql.ExecQuery(Zapytanie)

            'Jeżeli napotka problem to pojawi się komunikat z błędem, jeżeli nie to przypisz dane do datagridview
            If sql.HasException(True) Then Exit Sub
            DataGRid.DataSource = sql.DBDT

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

    End Sub

    'Realizacja samego zapytania z obsługą błędów
    Public Sub Wyslij_Zapytanie_SQL_Do_Bazy(ByVal Zapytanie As String)
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasException(True) Then
                DoFlowLogaDoPliku("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

    End Sub

    Public Function Wyslij_Zapytanie_SQL_Do_Bazy_Zwroc_info(ByVal Zapytanie As String) As Boolean
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasExceptionBezKomunikatu(True) Then
                DoFlowLogaDoPliku("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

        Return True
    End Function

    Public Function Wyslij_Zapytanie_SQL_Do_Bazy_F(ByVal Zapytanie As String) As Boolean
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasException(True) Then Return False

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
            Return False
        End Try
        Return True
    End Function

    Public Function SprawdzIloscZuzytych(ByVal NumerMagazynowy As Integer) As Integer
        'Stwórz tymczasowe przyjecie magazynowe
        Dim Tymcz_Przy_Mag As New PrzyjęcieMagazynowe

        'Zapytanie sprawdzające ilość zużytych arkuszy w Log2
        Dim zapytanie
        zapytanie = "Select IloscZuzytych From LOG2  Where Akcja = 'Rezerwacja' and NazwaProjektu = '" & SciezkaProjektu & "' and " &
                       "IDArkusza = " & NumerMagazynowy

        DoFlowLogaDoPliku(zapytanie)

        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, Tymcz_Przy_Mag.DataGridView1)

        Dim IloscZuz As Integer
        Try
            IloscZuz = CInt(Tymcz_Przy_Mag.DataGridView1.Rows(0).Cells(0).Value)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(Tymcz_Przy_Mag.DataGridView1.Rows(0).Cells(0).Value)
        End Try


        Return IloscZuz
        'Zamknij tymczasowe przyjecie magazynowe
        Tymcz_Przy_Mag.Dispose()

    End Function



    'NIEUŻYWANE FUNKCJE I FRAGMENTY KODÓW

    'Odczytaj nazwy kolumn z bazy danych i zapisz pod postacia listy String
    ' For index As Integer = 0 To DataGridView1.ColumnCount() - 1
    '        Kolumny.Add(DataGridView1.Columns(index).HeaderText)
    'Next

    ' Wyswietl Kolumny
    ' For Each Kol As String In Kolumny
    'MsgBox(Kol.ToString)
    ' Next


End Module