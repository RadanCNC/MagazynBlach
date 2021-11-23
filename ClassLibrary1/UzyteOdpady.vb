Imports System.IO

Public Class UzyteOdpady
    Inherits UzyteArkusze

    Public NazwaOdpadu As String
    Public SciezkaDoPliku As String
    Public IloscDostepne As Integer
    Public Pochodna As Integer

    Public Sub Rezerwuj_Ilosci_Odpadow_W_Bazie()
        Dim zapytanieUpdate As String
        zapytanieUpdate = "Update Odpady SET IloscDostepne = IloscDostepne -" & Used &
                              ", IloscRezerwacja = IloscRezerwacja + " & Used &
                              " WHERE[Nazwaodpadu] = '" & NazwaOdpadu & ".drg'"
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanieUpdate)
        DoFlowLogaDoPliku(zapytanieUpdate)
    End Sub

    Public Sub Odczytaj_Info_Odpadow_Z_Jego_Pliku()

        Dim ilosclocal As Integer = 0
        Dim xlocal As Double = 0
        Dim ylocal As Double = 0
        Dim materiallocal As String = ""
        Dim grubosclocal As Double = 0
        Dim pochodnalocal As Integer = 0

        Using reader As New StreamReader(SciezkaDoPliku)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()

                'Odczytaj Atrybut o numerze 137
                If line.Contains("Attr num=" & Chr(34) & "137") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    ilosclocal = CInt(line)
                End If

                If line.Contains("Attr num=" & Chr(34) & "124") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    xlocal = CDbl(line)
                End If

                If line.Contains("Attr num=" & Chr(34) & "125") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    ylocal = CDbl(line)
                End If

                If line.Contains("Attr num=" & Chr(34) & "119") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    materiallocal = CStr(line)
                End If

                If line.Contains("Attr num=" & Chr(34) & "120") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    grubosclocal = CDbl(line)
                End If

                If line.Contains("Attr num=" & Chr(34) & "159") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    pochodnalocal = CDbl(line)
                End If

            End While
        End Using

        IloscDostepne = ilosclocal
        X = xlocal
        Y = ylocal
        Material = materiallocal
        Grubosc = grubosclocal
        Pochodna = pochodnalocal
        DoFlowLogaDoPliku("Odczytano informacje na temat odpadu z jego pliku : " &
             IloscDostepne & " " & X & " " & Y & " " & Material & " " & Grubosc &
            " " & Pochodna & " Ścieżka do pliku: " & SciezkaDoPliku)
    End Sub

    Public Sub Zwroc_Numer_Magazynowy()

        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego 
        'datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe
        Dim ZapytanieNumerMagazynowy As String = "select [Numer Magazynowy] from Odpady " &
        "where [NazwaOdpadu] = '" & NazwaOdpadu & ".drg'"

        'Do sprawdzenia
        '   MsgBox(ZapytanieNumerMagazynowy)
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieNumerMagazynowy, tymczasowePM.DataGridView1)
        DoFlowLogaDoPliku(ZapytanieNumerMagazynowy)
        Try

            Dim numerMagazynowy As Integer = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value
        tymczasowePM.Dispose()
        StockId = numerMagazynowy
            ' MsgBox(StockId)

        Catch ex As Exception
            DoFlowLogaDoPliku("Błąd przy odczytaniu numeru magazynowego")
        End Try
    End Sub
End Class
