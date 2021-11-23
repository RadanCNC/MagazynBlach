Imports System.IO

Public Class OdpadyDoUzycia
    'Dziedziczenie wszystkie atrybutów i metod z klasy DostepneArkusze
    Inherits DostepneArkusze

    'Deklaracja nowych atrybutów
    Public CzyOdpad As Boolean
    Public PochodnaNumerMagazynowy As Integer
    Public NazwaOdpadu As String
    Public SciezkaDoPliku As String
    Public SourceNest As Integer 'Numer w pliku projektu
    Public NumerMagazynow As String

    'Deklaracja nowych metod

    'Odczytaj informacje na temat odpadu z arkusza, z którego powstał.
    Public Sub Ident_Odpadu_Z_Arkusza_Pochodnego(ByVal NumerMagazynowy As Integer)
        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe
        '''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabela As String = "Arkusze"
        If NumerMagazynowy > 500000 - 1 Then
            tabela = "Odpady"
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ZapytanieSQL As String = "select * from " & tabela & " where [Numer Magazynowy] = " & NumerMagazynowy
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieSQL, tymczasowePM.DataGridView1)
        PochodnaNumerMagazynowy = NumerMagazynowy
        Material = tymczasowePM.DataGridView1.Rows(0).Cells(1).Value
        Grubosc = tymczasowePM.DataGridView1.Rows(0).Cells(2).Value
        ' Poniższych nie wczytuje bo odnoszą się tylko do arkusza pochodnego a nie do odpadu
        '  IloscDostepne = DataGrid.Rows(row).Cells(3).Value
        ' X = DataGrid.Rows(row).Cells(6).Value
        ' Y = DataGrid.Rows(row).Cells(7).Value
        Priorytet = tymczasowePM.DataGridView1.Rows(0).Cells(8).Value
        Size_Units = tymczasowePM.DataGridView1.Rows(0).Cells(9).Value
        Sheet_Thickness_Unit = tymczasowePM.DataGridView1.Rows(0).Cells(10).Value
        Pole_uzytkownika = tymczasowePM.DataGridView1.Rows(0).Cells(11).Value
        Klient = tymczasowePM.DataGridView1.Rows(0).Cells(13).Value
        Wytop = tymczasowePM.DataGridView1.Rows(0).Cells(14).Value
        Atest = tymczasowePM.DataGridView1.Rows(0).Cells(15).Value
        Wz = tymczasowePM.DataGridView1.Rows(0).Cells(17).Value
        Powierzony = tymczasowePM.DataGridView1.Rows(0).Cells(18).Value
        Lokalizacja = tymczasowePM.DataGridView1.Rows(0).Cells(19).Value
        'IloscDostepne = 1

        tymczasowePM.Dispose()

    End Sub

    Public Sub Zapisz_Odpad_Do_Bazy()

        Dim zapytanie As String
        zapytanie = "Insert into Odpady" &
         "(SciezkaDoPliku, Pochodna, NazwaOdpadu, Material, Grubosc, IloscDostepne, X, Y, Priorytet, Size_Units," &
         "Sheet_Thickness_Units, Klient, Wytop, Atest, WZ, Powierzony, Pole_Uzytkownika, Lokalizacja) values ('" &
        SciezkaDoPliku & "'," &
        PochodnaNumerMagazynowy & ",'" &
        NazwaOdpadu & "','" &
        Material & "' ," &
         Grubosc & "," &
         IloscDostepne & "," &
         X & "," &
         Y & "," &
         Priorytet & ",'" &
         Size_Units & "','" &
         Sheet_Thickness_Unit & "'," &
         "'" &
         Klient & "','" &
         Wytop & "','" &
         Atest & "','" &
         Wz & "'," &
         "'" & Powierzony & "','" &
        Pole_uzytkownika & "','" &
         Lokalizacja &
         "')"
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
        DoFlowLogaDoPliku(zapytanie)
    End Sub

    Public Sub Rezerwuj_Odpad()
        Dim zapytanieUpdate As String
        zapytanieUpdate = "Update Odpady SET IloscDostepne = IloscDostepne -" & IloscRezerwacja &
                              ", IloscRezerwacja = IloscRezerwacja + " & IloscRezerwacja &
                              " WHERE [NazwaOdpadu] = '" & NazwaOdpadu & ".drg'"
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanieUpdate)
    End Sub

    'Odczytaj pozostałe informacje na temat odpadu z jego pliku .drg
    Public Sub Odczytaj_Info_Odpadow_Z_Jego_Pliku()
        Dim Xlocal As Double = 0
        Dim Ylocal As Double = 0
        Dim IloscDostepnelocal As Integer = 0

        Try
            DoFlowLogaDoPliku("Odczytuje plik odpadu: " & SciezkaDoPliku)
            Using reader As New StreamReader(SciezkaDoPliku)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()

                    'Odczytaj atrybut numer 124 to jest wymiar X
                    ' X = CDbl(Odczytaj_wartosc_atrybutu(line, 124))
                    If line.Contains("Attr num=" & Chr(34) & "124") Then
                        'odczytaj całą linię z atrybutem 124
                        line = line.Substring(0, line.Length)
                        Dim Pozycja As Integer
                        ' znajdź pozycje w łańcuchu od którego zaczynają się wartości liczbowe
                        Pozycja = InStr(line, "value=")
                        ' Odczytaj tylko wartości liczbowe
                        line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                        Xlocal = CDbl(line)
                    End If

                    'Y = CDbl(Odczytaj_wartosc_atrybutu(line, 125))
                    'Odczytaj atrybut numer 125 to jest wymiar Y
                    If line.Contains("Attr num=" & Chr(34) & "125") Then
                        line = line.Substring(0, line.Length)
                        Dim Pozycja As Integer
                        Pozycja = InStr(line, "value=")
                        line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                        Ylocal = CDbl(line)
                    End If

                    'Odczytaj atrybut numer 137 to jest ilość
                    'IloscDostepne = CInt(Odczytaj_wartosc_atrybutu(line, 137))
                    If line.Contains("Attr num=" & Chr(34) & "137") Then
                        line = line.Substring(0, line.Length)
                        Dim Pozycja As Integer
                        Pozycja = InStr(line, "value=")
                        line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                        IloscDostepnelocal = CInt(line)
                    End If
                End While
            End Using
            X = Xlocal
            Y = Ylocal
            IloscDostepne = IloscDostepnelocal

        Catch ex As Exception
            DoFlowLogaDoPliku("Nie udało się odczytać pliku odpadu: " & SciezkaDoPliku)
        End Try

        ' MsgBox("wymiar X: " & X & "wymiar Y: " & Y & "Ilosc dostepne: " & IloscDostepne)
    End Sub

    Public Sub Wpisz_Przyjecie_Nowego_Odpadu_Do_Loga()

        Try

            'Sprawdź Numer Magazynowy
            Dim tymczasowePM As New PrzyjęcieMagazynowe
            ' Dim NumerMagazynowyLocal As Integer
            Dim zapytanie As String
            zapytanie = "select max ([Numer Magazynowy]) from Odpady "

            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, tymczasowePM.DataGridView1)

            NumerMagazynow = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value

            'Zapisz Przyjęcie Magazynowe do LOGa
            Dim nazwaUzytkownika As String = myMac.UID
            Dim ZapytanieSQL As String
            ZapytanieSQL = "Insert into LOG2 " &
        "(Akcja, 
        IDArkusza,
        NazwaProjektu,
        IloscDostepnych, 
        Uzytkownik,
        Material,
        Grubosc,
        X,
        Y) values" &
        "('PrzyjecieMagazynowe'," &
         NumerMagazynow & ",'" &
        SciezkaProjektu & "'," &
        IloscDostepne & "," &
        "'" & nazwaUzytkownika & "'," &
        "'" & Material & "'," &
        Grubosc & "," &
        X & "," &
        Y &
        ")"
            Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)

            DoFlowLogaDoPliku("Wpisano Przyjęcie Magazynowe Nowego Odpadu o numerze: " & NumerMagazynow & " do Loga")
        Catch ex As Exception
            DoFlowLogaDoPliku("Nie wpisano Przyjęcia Magazynowego Nowego Odpadu o numerze: " & NumerMagazynow & " do Loga")
        End Try
    End Sub

    Public Sub PodmienNumerMagazynowy()
        'Zamienia w pliku odpadu .drg atrybut o numerze 159 z pochodnego numeru magazynowego na
        'nowy

        Dim destination As String = OdpadyDoUzyciaWBazie & NazwaOdpadu
        Try
            Dim reader2 As New StreamReader(destination)
            Dim s = reader2.ReadToEnd().Replace(CStr(PochodnaNumerMagazynowy), NumerMagazynow)
            reader2.Close()

            DoFlowLogaDoPliku("Zmiana numeru: " & PochodnaNumerMagazynowy & " na " & NumerMagazynow)
            Dim writer As New StreamWriter(destination)

            writer.Write(s)
            writer.Close()
        Catch ex As Exception
            DoFlowLogaDoPliku("Nie udało się podmienić numeru magazynowego w pliku: " & destination)
            DoFlowLogaDoPliku("Błąd: " & ex.Message)
        End Try
    End Sub

    Public Function Sprawdz_Czy_Juz_Wpisano_Odpad() As Boolean
        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe

        'Zapytanie zliczające ile jest wpisów o tej nazwie projektu
        ' Dim ZapytanieCount As String = "select count (NazwaOdpadu) from Odpady where SciezkaDoPliku = '" & SciezkaDoPliku & "'"
        Dim ZapytanieCount As String = "select (IloscDostepne) from Odpady where SciezkaDoPliku = '" & SciezkaDoPliku & "'" & " and IloscDostepne > 0"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieCount, tymczasowePM.DataGridView1)
        DoFlowLogaDoPliku(ZapytanieCount)
        Dim ilosc As Integer = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value
        DoFlowLogaDoPliku("Wynik: " & ilosc)
        ' MsgBox(ilosc)
        'Zamknięcie formularza
        tymczasowePM.Dispose()
        If ilosc > 0 Then
            DoFlowLogaDoPliku("Ten odpad Już istnieje w bazie. Ilość dostępna odpadów: " & ilosc & "Nie dodamy tego odpadu do bazy: " & SciezkaDoPliku)
            MsgBox("Ten odpad Już istnieje w bazie. Ilość dostępna odpadów: " & ilosc & ". Nie dodamy tego odpadu do bazy: " & SciezkaDoPliku)
            Return True
        Else
            Return False
        End If

    End Function
End Class
