'Biblioteki funkcji
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml


Public Class Rezerwacja
    'W tych listach będą przechowywane wszystkie Użyte Arkusze w projekcie
    Dim Lista_Uzytych_Arkuszy As New List(Of UzyteArkusze)
    '
    Dim Lista_Uzytych_Arkuszy_Do_Dopisania As New List(Of UzyteArkusze)
    'Użyte Odpady
    Dim Lista_Uzytych_Odpadow As New List(Of UzyteOdpady)
    'i Nowo Utworzone Odpady
    Dim Lista_Nowych_Odpadow As New List(Of OdpadyDoUzycia)

    ' Dokument oraz znacznik XML
    Dim xmldoc As New XmlDataDocument()
    Dim xmlnode As XmlNodeList

    ' Dostęp do pliku projektu
    Dim PlikProjektu As New FileStream(SciezkaProjektu, FileMode.Open, FileAccess.Read)


    Public Sub Inicjalizacja()
        'Załaduj Plik projektu
        Try
            xmldoc.Load(PlikProjektu)
            DoFlowLogaDoPliku("Załadowano plik projektu: " & SciezkaProjektu)
            ' MsgBox("wczytano plik RPD")
        Catch ex As Exception
            DoFlowLogaDoPliku("Nie Załadowano pliku projektu: " & SciezkaProjektu)
        End Try

        'Wczytaj dane o Arkuszach i Odpadach do Rezerwacji
        Pobierz_Uzyte_Arkusze()
        DoFlowLogaDoPliku("Pobrano Uzyte Arkusze")
        Pobierz_Uzyte_Odpady()
        DoFlowLogaDoPliku("Pobrano Uzyte Odpady")
        'Wczytaj dane o Nowych Odpadach do ponownego użycia
        Pobierz_Nowe_Odpady()
        DoFlowLogaDoPliku("Pobrano Nowe Odpady")

        Odczytaj_Folder_Odpadow_do_Uzycia()


    End Sub

    Public Sub Rezerwacja()
        'Zrobić warunek jeżeli jest już w bazie rezerwacja to zapytaj użytkownika czy dodać tylko te nowe
        'Pytanie co jeżeli zmieniła się ilość 
        If Sprawdz_Czy_Istnieje_Juz_Rezerwacja() = False Then
            'JESZCZE NIE ISTNIEJE REZERWACJA
            If Sprawdz_Czy_Sa_Arkusze_Do_Rezerwacji() = True Then

                Rezerwuj_Uzyte_Arkusze()
                LOG_Rezerwacji_Uzytych_Arkuszy()

            End If

            If Sprawdz_Czy_Sa_Uzyte_Odpady_Do_Rezerwacji() = True Then
                Rezerwuj_Uzyte_Odpady()
                LOG_Rezerwacji_Uzytych_Odpadow()
            End If

        Else
            'ISTNIEJE JUŻ REZERWACJA
            Pobierz_Uzyte_Arkusze()
            If Sprawdz_Czy_Sa_Zuzyte_Arkusze() = True Then
                'Jeżeli tak to wyświetl komunikat do użytkownika z pytaniem
                ' Dim wynik As Integer = Windows.Forms.MessageBox.Show("Wykryto Arkusze w Rezerwacji, które są już zużyte. 
                ' Czy chcesz kontynuować?", "Arkusze_Zużyte", MessageBoxButtons.YesNo)
                MsgBox("Wykryto Arkusze w Rezerwacji, które są już zużyte. Sprawdź zużyte arkusze.")
                Exit Sub
                'Jeżeli odpowiedź tak to rezerwuj arkusze
                '  If wynik = DialogResult.Yes Then

                'Else
                'Exit Sub
            End If

            'Zadaj pytanie użytkownikowi. Niektóre z arkuszy są zarezerwowane, a niektóre nie. 
            ' Czy chcesz ponowić całą rezerwację (anulowanie poprzedniej
            ' i stworzenie nowej) [Tak]. Czy chcesz zerezerwować tylko te pozostałe? [Nie]
            'Jeżeli TAK to 

            Dim iloscArkuszyDoDopisania As Integer = 0

            For Each arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy

                If arkusz.Sprawdz_Czy_Jest_Rezerwacja() = False Then
                    ' Lista_Uzytych_Arkuszy_Do_Dopisania.Add(arkusz)
                    iloscArkuszyDoDopisania += 1
                End If
            Next


            If iloscArkuszyDoDopisania > 0 Then

                Dim wynik As Integer = Windows.Forms.MessageBox.Show("Niektóre z arkuszy są zarezerwowane, a niektóre nie. 
            Czy chcesz ponowić całą rezerwację (anulowanie poprzedniej i stworzenie nowej) [Tak].
            Czy chcesz zerezerwować tylko te pozostałe? [Nie].", "Arkusze_Do_Rezerwacji", MessageBoxButtons.YesNo)

                If wynik = DialogResult.Yes Then

                    Anuluj_Rezerwacje()
                    'Wczytaj dane o Arkuszach i Odpadach do Rezerwacji
                    Pobierz_Uzyte_Arkusze()

                    'Ponowne wczytanie danych
                    DoFlowLogaDoPliku("Pobrano Uzyte Arkusze")
                    Pobierz_Uzyte_Odpady()
                    DoFlowLogaDoPliku("Pobrano Uzyte Odpady")
                    Pobierz_Nowe_Odpady()
                    DoFlowLogaDoPliku("Pobrano Nowe Odpady")

                    Rezerwacja()

                ElseIf wynik = DialogResult.No Then

                    'Jeżeli NIE to
                    'Pobierz Arkusze
                    Pobierz_Uzyte_Arkusze()
                    Lista_Uzytych_Arkuszy_Do_Dopisania.Clear()

                    For Each arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy

                        If arkusz.Sprawdz_Czy_Jest_Rezerwacja() = False Then
                            Lista_Uzytych_Arkuszy_Do_Dopisania.Add(arkusz)
                        End If
                    Next

                    Rezerwuj_Uzyte_Arkusze_Do_Dopisania()
                    LOG_Rezerwacji_Uzytych_Arkuszy_Do_Dopisania()
                    'Sprawdź, które nie mają wpisu w LOG2 w Akcji Rezerwacja z numerem magazynowym
                    'Do tego stworzyłem nową listę arkuszy Lista_Uzytych_Arkuszy_Do_Dopisania

                End If

                'I zarezerwuj tylko te
            Else

                Anuluj_Rezerwacje()
                'Wczytaj dane o Arkuszach i Odpadach do Rezerwacji
                Pobierz_Uzyte_Arkusze()

                'Ponowne wczytanie danych
                DoFlowLogaDoPliku("Pobrano Uzyte Arkusze")
                Pobierz_Uzyte_Odpady()
                DoFlowLogaDoPliku("Pobrano Uzyte Odpady")
                Pobierz_Nowe_Odpady()
                DoFlowLogaDoPliku("Pobrano Nowe Odpady")

                Rezerwacja()
            End If
        End If

    End Sub

    Public Function Sprawdz_Czy_Sa_Zuzyte_Arkusze() As Boolean

        'Dim TymczasowePrzyjecie As New PrzyjęcieMagazynowe
        Dim flaga As Boolean = False
        For Each arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
            Dim IloscZuzytych As Integer = 0
            IloscZuzytych = SprawdzIloscZuzytych(arkusz.StockId)
            If IloscZuzytych > 0 Then
                MsgBox("Arkusz o numerze: " & arkusz.StockId & " ma zużyte arkusze z tej rezerwacji.")
                flaga = True
            End If
        Next
        Return flaga
    End Function

    Public Sub Dodaj_Nowe_Odpady_Do_Bazy()


        If Sprawdz_Czy_Sa_Nowe_Odpady() = True Then

            'Pytanie czy chcesz zapisać odpady dwa warianty odpowiedzi
            Dim wynik As Integer = Windows.Forms.MessageBox.Show("Wykryto Nowo Utworzone Odpady 
            Czy  chcesz je wpisać do bazy?", "Nowe_Odpady", MessageBoxButtons.YesNo)

            'Jeżeli tak do zapisz odpad do bazy i jako przyjęcie magazynowe do loga
            If wynik = DialogResult.Yes Then
                'Jeżeli wykryje już odpad w bazie to poda komunikat
                Zapisz_Odpad_Do_Bazy_I_Do_Loga()
                '  LOG_Zapisu_Nowych_Odpadow_Do_Bazy()

                'Jeżeli nie to anuluj
                If wynik = DialogResult.No Then
                    DoFlowLogaDoPliku("Anulowano Wpisanie Nowych Odpadów")
                    MsgBox("Anulowano Wpisanie Nowych Odpadów")
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub Odczytaj_Folder_Odpadow_do_Uzycia()
        Dim IloscOdpadow = 0
        Try
            'odczytaj znacznik Folderu Odpadu
            xmlnode = xmldoc.GetElementsByTagName("RemnantUseFolder")

            SciezkaOdpadowDoUzyciaWProjekcie = xmlnode(0).ChildNodes.Item(0).InnerText.Trim()
            ' PlikProjektu.Close()
            DoFlowLogaDoPliku("Odczytano folder odpadu do użycia (RemnantUseFolder) z pliku projektu: " & SciezkaOdpadowDoUzyciaWProjekcie)
        Catch ex As Exception
            DoFlowLogaDoPliku("Nie można odczytać folderu odpadu do użycia (RemnantUseFolder) z projektu")
            MsgBox("Nie można odczytać folderu odpadu do użycia (RemnantUseFolder) z projektu")
        End Try
    End Sub

    Private Sub Pobierz_Uzyte_Arkusze()

        Lista_Uzytych_Arkuszy.Clear()                                      'Wyzerowanie listy

        xmlnode = xmldoc.GetElementsByTagName("Sheet")                     'odczytaj znacznik Arkusza

        Dim str As String = ""                                             'Zmienna pomocnicza
        Dim NumMag As String                                               'Numer Magazynowy
        Dim IloDoRez As Integer                                            'Ilość do Rezerwacji
        Dim Mat As String                                                  'Materiał
        Dim Gru As Double                                                  'Grubość

        'Pętla odczytania danych z pliku XML do klasy UżyteArkusze
        For i As Integer = 1 To xmlnode.Count - 1

            'Przypisanie danych
            xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
            NumMag = xmlnode(i).ChildNodes.Item(8).InnerText.Trim()
            IloDoRez = CInt(xmlnode(i).ChildNodes.Item(11).InnerText.Trim())
            Mat = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()

            'zamiana kropek na przecinki w grubości inaczej błędy
            str = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
            str = Replace(str, ".", ",")
            Gru = str

            'Sprawdzenie czy Arkusz do rezerwacji ma Numer Magazynowy!
            If xmlnode(i).ChildNodes.Item(8).InnerText.Trim() = "" Then
                MsgBox("Arkusz nie ma Numeru Magazynowego: " & Mat & " #" & Gru & " Ilość:" & IloDoRez &
                       ". Sprawdź Arkusz i spróbuj ponownie.")
                DoFlowLogaDoPliku("Arkusz nie ma Numeru Magazynowego: " & Mat & " " & Gru & " " & IloDoRez)
            End If

            'Dodaj do listy Zarezerwowane Arkusze
            Try
                Lista_Uzytych_Arkuszy.Add(New UzyteArkusze() With {
                .StockId = NumMag,
                .Used = IloDoRez,
                .Material = Mat,
                .Grubosc = Gru,
                .X = xmlnode(i).ChildNodes.Item(5).InnerText.Trim(),
                .Y = xmlnode(i).ChildNodes.Item(6).InnerText.Trim()
                           })

                'Zapis do loga
                DoFlowLogaDoPliku("Arkusz do rezerwacji o numerze: " &
               xmlnode(i).ChildNodes.Item(8).InnerText.Trim() &
               " ilość " & CInt(xmlnode(i).ChildNodes.Item(11).InnerText.Trim()))
            Catch ex As Exception
                DoFlowLogaDoPliku("Arkusz " & xmlnode(i).ChildNodes.Item(8).InnerText.Trim() &
                " liczba użytych 0: ") '& ex.Message
            End Try
        Next

        'odczytaj znacznik Arkusza
        'Sprawdzenie wszystkich ID arkusza
        'Sama lista ID5
        xmlnode = xmldoc.GetElementsByTagName("Sheet")
        For Each arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
            For i As Integer = 1 To xmlnode.Count - 1
                xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                Try
                    If arkusz.StockId = xmlnode(i).ChildNodes.Item(8).InnerText.Trim() Then
                        DoFlowLogaDoPliku("Arkusz: " & arkusz.StockId & " Is used in Nest: ")
                        For e As Integer = 0 To xmlnode(i).ChildNodes.Count - 1
                            arkusz.ID5.Add(xmlnode(i).ChildNodes.Item(12).ChildNodes.Item(e).ChildNodes.Item(0).InnerText.Trim())
                            arkusz.ileID = xmlnode(i).ChildNodes.Count - 1
                            DoFlowLogaDoPliku(xmlnode(i).ChildNodes.Item(12).ChildNodes.Item(e).ChildNodes.Item(0).ChildNodes.Item(0).InnerText.Trim())
                        Next
                    Else
                        'arkusz.ID5.Add(0)
                    End If

                Catch ex As Exception
                    DoFlowLogaDoPliku("Błąd przy pobieraniu ID: " & ex.Message)
                End Try
            Next
        Next


    End Sub

    'Do poprawy
    Private Sub Pobierz_Uzyte_Odpady()
        'Wyzerowanie listy
        Lista_Uzytych_Odpadow.Clear()

        'Szukaj znacznika REmanant Sheet, tak są nazwane odpady w pliku projektu
        xmlnode = xmldoc.GetElementsByTagName("RemnantSheet")

        'Odczytaj ile użyto odpadów
        Dim IleOdpadow As Integer = 0
        For i As Integer = 0 To xmlnode.Count - 1
            IleOdpadow = IleOdpadow + 1
            Lista_Uzytych_Odpadow.Add(New UzyteOdpady() With {
                    .NazwaOdpadu = xmlnode(i).ChildNodes.Item(0).InnerText.Trim(),
               .Used = xmlnode(i).ChildNodes.Item(2).InnerText.Trim(),
               .SciezkaDoPliku = OdpadyDoUzyciaWBazie & xmlnode(i).ChildNodes.Item(0).InnerText.Trim() & ".drg"
               })
            DoFlowLogaDoPliku("Użyty odpad o nazwie: " & xmlnode(i).ChildNodes.Item(0).InnerText.Trim())
        Next

        'Nie wszystkie informacje można odczytać z pliku projektu
        For Each odpad As UzyteOdpady In Lista_Uzytych_Odpadow
            'Trzeba jeszcze przeczytać plik .DRG odpadu
            odpad.Odczytaj_Info_Odpadow_Z_Jego_Pliku()
            'Oraz odczytać Numer Magazynowy z bazy danych SQL
            odpad.Zwroc_Numer_Magazynowy()
        Next

        'odczytaj znacznik Arkusza
        xmlnode = xmldoc.GetElementsByTagName("RemnantSheet")
        'Sprawdzenie wszystkich ID arkusza
        'Sama lista ID5
        For Each odpad As UzyteOdpady In Lista_Uzytych_Odpadow
            For i As Integer = 1 To xmlnode.Count - 1
                xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                Try
                    If odpad.NazwaOdpadu = xmlnode(i).ChildNodes.Item(0).InnerText.Trim() Then
                        DoFlowLogaDoPliku("Odpad: " & odpad.NazwaOdpadu & " Is used in Nest: ")
                        For e As Integer = 0 To xmlnode(i).ChildNodes.Count - 1
                            odpad.ID5.Add(xmlnode(i).ChildNodes.Item(3).ChildNodes.Item(e).ChildNodes.Item(0).InnerText.Trim())
                            odpad.ileID = xmlnode(i).ChildNodes.Count - 1
                            DoFlowLogaDoPliku(xmlnode(i).ChildNodes.Item(3).ChildNodes.Item(e).ChildNodes.Item(0).InnerText.Trim())
                        Next
                    Else

                    End If

                Catch ex As Exception
                    DoFlowLogaDoPliku("Błąd przy pobieraniu ID: " & ex.Message)
                End Try
            Next
        Next

        'Odpady w tym momencie są przechowywane w pamięci komputera, jeszcze nie są wpisane do bazy
    End Sub

    Private Sub Pobierz_Nowe_Odpady()

        ' Odczytaj folder zapisu odpadów z projektu
        xmlnode = xmldoc.GetElementsByTagName("RemnantSaveFolder")
        xmlnode(0).ChildNodes.Item(0).InnerText.Trim()
        RemnantSaveFolder = xmlnode(0).ChildNodes.Item(0).InnerText.Trim()

        ' MsgBox("Folder odpadów To: " & RemnantSaveFolder)

        'Wyzerowanie listy
        Lista_Nowych_Odpadow.Clear()

        Dim iloscOdpadow As Integer = 0

        'Odczytaj nazwy odpadów i ściezki do plików
        xmlnode = xmldoc.GetElementsByTagName("Remnant")
        For i As Integer = 0 To xmlnode.Count - 1
            Lista_Nowych_Odpadow.Add(New OdpadyDoUzycia() With {
               .CzyOdpad = True,
               .NazwaOdpadu = xmlnode(i).ChildNodes.Item(0).InnerText.Trim(),
               .SciezkaDoPliku = RemnantSaveFolder & "\" & xmlnode(i).ChildNodes.Item(0).InnerText.Trim(),
               .SourceNest = xmlnode(i).ChildNodes.Item(2).ChildNodes(0).InnerText.Trim()
               })
            iloscOdpadow = iloscOdpadow + 1
            DoFlowLogaDoPliku("Nowy odpad o nazwie: " & xmlnode(i).ChildNodes.Item(0).InnerText.Trim())
        Next

        DoFlowLogaDoPliku("Ilość Nowych Odpadów to: " & iloscOdpadow)

        For Each Nowy_Odpad As OdpadyDoUzycia In Lista_Nowych_Odpadow
            DoFlowLogaDoPliku("Wchodzę do pętli Nowy_odpad")
            ' MsgBox("Wchodzę do pętli Nowy_odpad")
            ' File.Copy(Nowy_Odpad.SciezkaDoPliku, OdpadyDoUzyciaWBazie & Nowy_Odpad.NazwaOdpadu, True)
            For Each Uzyty_Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
                DoFlowLogaDoPliku("Wchodzę do pętli Uzyty_arkusz")
                '
                '  Nowy_Odpad.SciezkaDoPliku = OdpadyDoUzyciaWBazie & Nowy_Odpad.NazwaOdpadu
                Try
                    '  For d As Integer = 0 To Uzyty_Arkusz.ileID
                    ' If Nowy_Odpad.SourceNest = Uzyty_Arkusz.ID5(d) Then

                    '  End If
                    'Next

                    For Each ID As Integer In Uzyty_Arkusz.ID5
                        If ID = Nowy_Odpad.SourceNest Then
                            Try
                                Nowy_Odpad.Ident_Odpadu_Z_Arkusza_Pochodnego(Uzyty_Arkusz.StockId)

                            Catch ex As Exception
                                DoFlowLogaDoPliku("Ident_Odpadu_Z_Arkusza_Pochodnego: " & ex.Message)
                            End Try

                            Try
                                Nowy_Odpad.Odczytaj_Info_Odpadow_Z_Jego_Pliku()

                            Catch ex As Exception
                                DoFlowLogaDoPliku("Odczyt info odpadu z jego pliku " & ex.Message)
                            End Try

                            DoFlowLogaDoPliku("Znaleziono skąd pochodzi odpad")
                            '  Nowy_Odpad.Zapisz_Odpad_Do_Bazy()
                        Else

                        End If
                    Next

                    '    If Uzyty_Arkusz.ID5.Exists(Nowy_Odpad.SourceNest) Then

                    '   End If

                    ' If Nowy_Odpad.SourceNest = Uzyty_Arkusz.ID Then

                    ' Else
                    'DoLoga("Warunek Nie spełniony")
                    '  End If
                Catch ex As Exception
                    DoFlowLogaDoPliku("Błąd powstał w bloku try:  " & ex.Message)
                End Try

            Next

            For Each Uzyty_Odpad As UzyteOdpady In Lista_Uzytych_Odpadow
                DoFlowLogaDoPliku("Wchodzę do pętli For Each Uzyty_Odpad As UzyteOdpady In Lista_Uzytych_Odpadow w Pobierz Nowe Odpady")

                Try
                    For Each ID As Integer In Uzyty_Odpad.ID5
                        If ID = Nowy_Odpad.SourceNest Then
                            Try
                                Nowy_Odpad.Ident_Odpadu_Z_Arkusza_Pochodnego(Uzyty_Odpad.StockId) 'do poprawy odpad uwzględnić 1-5

                            Catch ex As Exception
                                DoFlowLogaDoPliku("Ident_Odpadu_Z_Arkusza_Pochodnego: " & ex.Message)
                            End Try

                            Try
                                Nowy_Odpad.Odczytaj_Info_Odpadow_Z_Jego_Pliku()

                            Catch ex As Exception
                                DoFlowLogaDoPliku("Odczyt info odpadu z jego pliku " & ex.Message)
                            End Try

                            DoFlowLogaDoPliku("Znaleziono skąd pochodzi odpad")
                            '  Nowy_Odpad.Zapisz_Odpad_Do_Bazy()
                        Else

                        End If
                    Next

                Catch ex As Exception
                    DoFlowLogaDoPliku("Błąd powstał w bloku try:  " & ex.Message)
                End Try

            Next

        Next

        'Jeden Arkusz może byc wykorzystany w kilku nestingach zapisuje się to jako used in nests
        'i podaje numery ID nestingów. 
        '<Sheet>
        '<ID>10</ID>
        '<NumAvailable>5</NumAvailable>
        '<Material>Mild Steel</Material>
        ' <Thickness>1</Thickness>
        '<ThickUnits>mm</ThickUnits>
        '<SheetX>3000</SheetX>
        '<SheetY>1500</SheetY>
        '<SheetUnits>mm</SheetUnits>
        '<StockID>103296</StockID>
        '<Exclude>n</Exclude>
        '<Priority>5</Priority>
        '<Used>5</Used>
        '<UsedInNests>
        '  <UsedInNest>
        '   <ID>10</ID>
        ' <Used>3</Used>
        ' </UsedInNest>
        '  <UsedInNest>
        '   <ID>11</ID>
        '   <Used>2</Used>
        '  </UsedInNest>
        ' </UsedInNests>

        'Odpad zapisuje się jako nazwa i z którego nestingu pochodzi. 
        '<Remnants>
        ' <Remnant>
        '  <FileName>Odpad1 P10 ndf.drg</FileName>
        ' <ID>1000001</ID>
        '<SourceNest>
        '   <ID>10</ID>
        ' </SourceNest>
        ' </Remnant>

        'Aby poznać pochodną odpadu trzeba porównać te wartości ID nestingu odpadu i arkusza
        'co robi powyższa pętla

        'W tym momencie mam liste nowych odpadów w pamięci komputera
    End Sub

    Private Sub Zapisz_Odpad_Do_Bazy_I_Do_Loga()

        Dim iloscOdpadow As Integer = 0
        ' iloscOdpadow = 'selectcount(Lista_Nowych_Odpadow)
        '  iloscOdpadow = Lista_Nowych_Odpadow.Count
        For Each Nowy_Odpad As OdpadyDoUzycia In Lista_Nowych_Odpadow
            'Kopiuj plik odpadu .drg do wspólnego katalogu
            Try
                File.Copy(Nowy_Odpad.SciezkaDoPliku, OdpadyDoUzyciaWBazie & Nowy_Odpad.NazwaOdpadu, True)

            Catch ex As Exception
                DoFlowLogaDoPliku("Błąd podczas kopiowania pliku odpadu")
                MsgBox("Błąd podczas kopiowania pliku odpadu")
            End Try

            'Nadpisz mu ścieżke
            'Do sprawdzenia ' Póki co działa
            Nowy_Odpad.SciezkaDoPliku = OdpadyDoUzyciaWBazie & Nowy_Odpad.NazwaOdpadu
            For Each Uzyty_Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy

                For Each ID As Integer In Uzyty_Arkusz.ID5
                    If ID = Nowy_Odpad.SourceNest Then
                        'Jeżeli ten odpad jest już w bazie to
                        If Nowy_Odpad.Sprawdz_Czy_Juz_Wpisano_Odpad() = True Then
                            DoFlowLogaDoPliku("Już wpisano ten odpad do bazy ")
                            '  MsgBox("Nie dodamy tego odpadu do bazy.")
                        Else ' do sprawdzenia ' Póki co działa
                            'Jeżeli nie to zapisz
                            iloscOdpadow = iloscOdpadow + 1
                            Nowy_Odpad.Zapisz_Odpad_Do_Bazy()
                            Nowy_Odpad.Wpisz_Przyjecie_Nowego_Odpadu_Do_Loga()
                            Nowy_Odpad.PodmienNumerMagazynowy()

                        End If
                    Else

                    End If
                Next

            Next
            '=========================================================================================
            For Each Uzyty_Odpad As UzyteOdpady In Lista_Uzytych_Odpadow

                For Each ID As Integer In Uzyty_Odpad.ID5
                    If ID = Nowy_Odpad.SourceNest Then
                        'Jeżeli ten odpad jest już w bazie to
                        If Nowy_Odpad.Sprawdz_Czy_Juz_Wpisano_Odpad() = True Then
                            DoFlowLogaDoPliku("Już wpisano ten odpad do bazy ")
                            '  MsgBox("Nie dodamy tego odpadu do bazy.")
                        Else ' do sprawdzenia ' Póki co działa
                            'Jeżeli nie to zapisz
                            iloscOdpadow = iloscOdpadow + 1
                            Nowy_Odpad.Zapisz_Odpad_Do_Bazy()
                            Nowy_Odpad.Wpisz_Przyjecie_Nowego_Odpadu_Do_Loga()
                            Nowy_Odpad.PodmienNumerMagazynowy()

                        End If
                    Else

                    End If
                Next

            Next

            '=========================================================================================
        Next
        If iloscOdpadow > 0 Then
            DoFlowLogaDoPliku("Dodano odpady do bazy")
            MsgBox("Dodano odpady do bazy")
        End If
    End Sub

    Public Sub Rezerwuj_Uzyte_Arkusze()

        Dim Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID As Integer = 0
        Dim ostatnieId As Integer = 0

        For Each Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy

            If ostatnieId <> Arkusz.StockId Then
                ostatnieId = Arkusz.StockId
            ElseIf ostatnieId = Arkusz.StockId Then
                Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID = Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID +
                    Arkusz.Used
            End If

        Next
        '  If iloscwszystkicharkuszyztymsamymID > ar Then

        For Each Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
            'Zaktualizuj ilość dostępnych arkuszy o anulowaną rezerwację, analogicznie liczby arkuszy zarezerwowanych

            Dim IloscDostepna As Integer = Arkusz.Zwroc_Ilosc_Dostepna()

            If IloscDostepna >= Arkusz.Used And Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID <= Arkusz.Used Then
                Arkusz.Rezerwuj_Ilosci_W_Bazie()

            ElseIf Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID > Arkusz.Used Then
                MsgBox("Chcesz zarezerwować więcej arkuszy niż jest dostępnych, sprawdź stan arkuszy")
                Exit Sub
            Else
                MsgBox("Ilość Dostępna Arkuszy o Numerze Magazynowym: " & Arkusz.StockId & " jest mniejsza niż
                ilość Arkuszy, które chcesz zarezerwować. Sprawdź czy ktoś już tych arkuszy nie zarezerwował.")
                ' index = False
                Exit Sub
            End If
        Next

        MsgBox("Zarezerwowano Arkusze")
    End Sub

    Public Sub Rezerwuj_Uzyte_Arkusze_Do_Dopisania()

        Dim Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID As Integer = 0
        Dim ostatnieId As Integer = 0

        For Each Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy_Do_Dopisania

            If ostatnieId <> Arkusz.StockId Then
                ostatnieId = Arkusz.StockId
            ElseIf ostatnieId = Arkusz.StockId Then
                Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID = Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID +
                    Arkusz.Used
            End If

        Next
        '  If iloscwszystkicharkuszyztymsamymID > ar Then

        For Each Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy_Do_Dopisania
            'Zaktualizuj ilość dostępnych arkuszy o anulowaną rezerwację, analogicznie liczby arkuszy zarezerwowanych

            Dim IloscDostepna As Integer = Arkusz.Zwroc_Ilosc_Dostepna()

            If IloscDostepna >= Arkusz.Used And Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID <= Arkusz.Used Then
                Arkusz.Rezerwuj_Ilosci_W_Bazie()

            ElseIf Ilosc_Wszystkich_Arkuszy_z_tym_Samym_ID > Arkusz.Used Then
                MsgBox("Chcesz zarezerwować więcej arkuszy niż jest dostępnych, sprawdź stan arkuszy")
                Exit Sub
            Else
                MsgBox("Ilość Dostępna Arkuszy o Numerze Magazynowym: " & Arkusz.StockId & " jest mniejsza niż
                ilość Arkuszy, które chcesz zarezerwować. Sprawdź czy ktoś już tych arkuszy nie zarezerwował.")
                ' index = False
                Exit Sub
            End If
        Next

        MsgBox("Zarezerwowano Arkusze")
    End Sub

    Public Sub Rezerwuj_Uzyte_Odpady()
        Dim x As Integer = 0
        For Each odpad As UzyteOdpady In Lista_Uzytych_Odpadow
            odpad.Rezerwuj_Ilosci_Odpadow_W_Bazie()
            x = x + 1
        Next
        MsgBox("Zarezerwowano odpady" & x)
    End Sub

    Public Sub LOG_Zapisu_Nowych_Odpadow_Do_Bazy()
        For Each Nowy_Odpad As OdpadyDoUzycia In Lista_Nowych_Odpadow
            Nowy_Odpad.Wpisz_Przyjecie_Nowego_Odpadu_Do_Loga()
        Next
    End Sub

    Public Sub LOG_Rezerwacji_Uzytych_Arkuszy()
        For Each Uzyty_Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
            If Uzyty_Arkusz.Used > 0 Then
                Uzyty_Arkusz.Zapisz_Rezerwacje_Do_Loga()
            End If
        Next

    End Sub

    Public Sub LOG_Rezerwacji_Uzytych_Arkuszy_Do_Dopisania()
        For Each Uzyty_Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy_Do_Dopisania
            If Uzyty_Arkusz.Used > 0 Then
                Uzyty_Arkusz.Zapisz_Rezerwacje_Do_Loga()
            End If
        Next

    End Sub

    Public Sub LOG_Rezerwacji_Uzytych_Odpadow()
        For Each Uzyty_Odpad As UzyteOdpady In Lista_Uzytych_Odpadow
            Uzyty_Odpad.Zapisz_Rezerwacje_Do_Loga()
        Next
        MsgBox("Udało się wpisać rezerwacje użytego odpadu do LOGa w bazie")
    End Sub


    Public Function Sprawdz_Czy_Sa_Arkusze_Do_Rezerwacji() As Boolean
        'Jeżeli w projekcie nie wykorzystano żadnego arkusza to nic nie rezerwuj
        Dim ilosc As Integer = 0
        'Lista_Uzytych_Arkuszy.Count
        For Each Uzyty_Arkusz As UzyteArkusze In Lista_Uzytych_Arkuszy
            ilosc = ilosc + Uzyty_Arkusz.Used
        Next

        If ilosc = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Anuluj_Rezerwacje()
        '
        Dim AnulujRez As New AnulowanieRezerwacjivb
        Try
            AnulujRez.Show()

        Catch ex As Exception
            MsgBox("Zyrtax Error")
        End Try

        'Przy pierwszy uruchomieniu okna wyświetl wszystkie rezerwacje
        Dim zapytanie As String
        zapytanie = "Select * from LOG2 where Akcja = 'Rezerwacja' AND NazwaProjektu = '" & SciezkaProjektu & "'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, AnulujRez.DataGridView1)

        'Usuń wszystkie widoczne w datagridview rezerwacje
        'Zapisz Projekt
        ' myMac.prj_save()

        'Anuluj Wszystkie WYSWIETLONE w datagridview Rezerwacje
        'Dim zapytanie As String
        Dim PierwszaCyfra As String
        Dim tabela As String = "Arkusze"

        'Anulowanie Rezerwacji
        Try
            For i As Integer = 0 To AnulujRez.DataGridView1.Rows.Count - 2
                'Sprawdź pierwszą cyfrę numeru magazynowego, jeżeli jedynka to aktualizuj tabele Arkusze
                PierwszaCyfra = CStr(AnulujRez.DataGridView1.Rows(i).Cells(3).Value)
                PierwszaCyfra = PierwszaCyfra.Substring(0, 1)
                If PierwszaCyfra = "1" Then
                    tabela = "Arkusze"
                    'Jeżeli 5 to aktualizuj tabele Odpady
                ElseIf PierwszaCyfra = "5" Then
                    tabela = "Odpady"
                Else ' Jeżeli jakakolwiek inna to wyświetl ostrzeżenie
                    MsgBox("Napotkano nietypowy Numer Magazynowy pierwsza cyfra nie jest zgodna z Arkuszem (1) ani Odpadem (5)")
                    Exit Sub
                End If

                'Zaktualizuj ilości Arkuszy lub Użytych Odpadów
                zapytanie = "Update " & tabela & " SET IloscDostepne = IloscDostepne + " &
                                         CStr(AnulujRez.DataGridView1.Rows(i).Cells(5).Value) & ", IloscRezerwacja = IloscRezerwacja -  " &
                                         CStr(AnulujRez.DataGridView1.Rows(i).Cells(5).Value) &
                                         " WHERE[Numer Magazynowy] = " & AnulujRez.DataGridView1.Rows(i).Cells(3).Value
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                'Później usuń Rezerwacje z Loga

                zapytanie = "Delete from LOG2 where [IDArkusza]  = " & AnulujRez.DataGridView1.Rows(i).Cells(3).Value &
                    " AND NazwaProjektu= '" & AnulujRez.DataGridView1.Rows(i).Cells(2).Value & "' AND Akcja = 'Rezerwacja'"
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                'Zapisz informacje o Anulowaniu Rezerwacji do Loga
                Anulowanie_Rezerwacji_Do_Loga(AnulujRez.DataGridView1, i)
            Next

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas zmiany ilości dostępnych i zarezerwowanych arkuszy podczas Anulowania Rezerwacji")
        End Try

        'Anulowanie Przyjęcia Magazynowego Nowych odpadów
        zapytanie = "Select * from LOG2 where Akcja = 'PrzyjecieMagazynowe' AND NazwaProjektu = '" & SciezkaProjektu & "'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, AnulujRez.DataGridView1)
        DoFlowLogaDoPliku(zapytanie)

        For i As Integer = 0 To AnulujRez.DataGridView1.Rows.Count - 2
            If AnulujRez.DataGridView1.Rows(i).Cells(3).Value > 500000 Then
                AnulujRez.DataGridView1.Rows(i).Selected = True
                AnulujRez.BtnAnulujPrzyjęcieMagazynowe.PerformClick()
            End If
            For Each odpad In Lista_Nowych_Odpadow
                If odpad.NumerMagazynow = AnulujRez.DataGridView1.Rows(i).Cells(3).Value Then
                    File.Delete(odpad.SciezkaDoPliku)
                    If File.Exists(odpad.SciezkaDoPliku) Then
                        DoFlowLogaDoPliku("Nie usunięto pliku odpadu: " & odpad.SciezkaDoPliku)
                    Else
                        DoFlowLogaDoPliku("Usunięto plik odpadu: " & odpad.SciezkaDoPliku)
                    End If
                End If
            Next
            'odśwież
            zapytanie = "Select * from LOG2 where Akcja = 'PrzyjecieMagazynowe' AND NazwaProjektu = '" & SciezkaProjektu & "'"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, AnulujRez.DataGridView1)
            'File.Delete(AnulujRez.DataGridView1.Rows(i).Cells(21).Value)
        Next

        'MsgBox("Anulowano Przyjęcie Magazynowe")
        'Odśwież dane w datagridview dla Rezerwacji

        zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, AnulujRez.DataGridView1)
        MsgBox("Anulowano Rezerwacje")

        flaga = False
        AnulujRez.Close()

    End Sub

    Public Function Sprawdz_Czy_Istnieje_Juz_Rezerwacja() As Boolean
        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe

        'Zapytanie zliczające ile jest wpisów o tej nazwie projektu
        Dim ZapytanieCount As String = "select count (NazwaProjektu) from log2 where Akcja = 'Rezerwacja' and NazwaProjektu = '" &
            SciezkaProjektu & "'"

        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieCount, tymczasowePM.DataGridView1)

        Dim ilosc As Integer = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value
        ' MsgBox(ilosc)
        'Zamknięcie formularza
        tymczasowePM.Dispose()
        If ilosc > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Sprawdz_Czy_Sa_Uzyte_Odpady_Do_Rezerwacji() As Boolean
        If Lista_Uzytych_Odpadow.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Sprawdz_Czy_Sa_Nowe_Odpady() As Boolean
        If Lista_Nowych_Odpadow.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub Anulowanie_Rezerwacji_Do_Loga(ByRef DataGrid As DataGridView, ByVal i As Integer)

        'Definicja funkcji, która wpisuje AnulowanieRezerwacji do LOGA

        'Zamiana  (w grubości) przecinków na kropki bo inaczej będzie błąd w zapytaniu SQL
        Dim gr As String = "'" & CStr(DataGrid.Rows(i).Cells(10).Value) & "'"
        gr = Replace(gr, ",", ".")

        Dim ZapytanieSQL As String

        ZapytanieSQL = "Insert into LOG2 " &
         "(Akcja, 
         IDArkusza, 
         NazwaProjektu, 
         IloscDostepnych, 
         IloscZarezerwowanych, 
         Uzytkownik,
         Data,
         Material,
         Grubosc,
         X,
         Y) 
         values" &
        "('Anulowanie Rezerwacji'," &
        DataGrid.Rows(i).Cells(3).Value & ",'" &
        SciezkaProjektu & "'," &
        DataGrid.Rows(i).Cells(5).Value & "," &
        -DataGrid.Rows(i).Cells(5).Value & "," &
         "'" & nazwaUzytkownika & "'" &
         ", GETDATE()" & "," &
         "'" & CStr(DataGrid.Rows(i).Cells(9).Value) & "'," &
         gr & "," &
         CDbl(DataGrid.Rows(i).Cells(11).Value) & "," &
         CDbl(DataGrid.Rows(i).Cells(12).Value) & ")"

        Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)
    End Sub

    Public Sub Finisz()
        'Zamknięcie pliku projektu
        PlikProjektu.Close()
        DoFlowLogaDoPliku("Zamknięto plik RPD")
        Me.Finalize()
    End Sub
End Class
