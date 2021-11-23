
'Biblioteka z funkcjami SQL
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Imports System.Drawing
'Imports RasterEdge.Imaging.Basic
'Imports RasterEdge.XDoc.PDF
'Imports BarcodeLib

Public Class ImportBlach

    Dim ListaArkuszyImport As New List(Of DostepneArkusze)()

    Public Sub BtnWczytajDane_Click(sender As Object, e As EventArgs) Handles BtnWczytajDane.Click

        'Zapytanie SQL, które może tylko admin wpisać
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(RichTextBox1.Text, DataGridView1)

    End Sub
    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Okno zawsze na wierzchu
        Me.TopMost = True
    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

        'Funkcja która pokazuje lub blokuje kilka formantów w zależności czy check box admin jest kliknięte
        Ukryj_Pokaz_Przyciski()

        'Po załadowaniu okna wyświetl dane z zapytania z RichtextBoxa
        BtnWczytajOdpad.Visible = True
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(RichTextBox1.Text, DataGridView1)

        Me.BackColor = Color.LimeGreen

    End Sub

    Public Sub BtnWczytajDoRadana_Click(sender As Object, e As EventArgs) Handles BtnWczytajDoRadana.Click

        Dim ileRekordow As Integer = 0
        'Jeżeli nie jesteś adminem to od razu wczytaj do radana

        If CBAdmin.Checked = False Then
            'Zapytanie SQL, które może tylko admin wpisać
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(RichTextBox1.Text, DataGridView1)
        End If

        'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz

        Try
            For row As Integer = 0 To DataGridView1.RowCount - 2
                ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
            Next
        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wczytywania danych z datagridview do listyArkuszyImport")
        End Try

        'Ilość arkuszy równa się ilości rzędów z datagridview 
        Dim ileArkuszy As Int16 = DataGridView1.RowCount - 2

        'Zmienne do progress baru

        'Najpierw go zeruje
        ProgressBar1.Value = 0
        'Określam jego maksimum
        ProgressBar1.Maximum = ileArkuszy + 1
        'Info dla użytkownika
        LabelProgressBar.Text = "Proszę czekać"
        Dim procent As Double = 0

        'Wczytaj arkusze do Radana
        Try
            For Each ArkuszImport As DostepneArkusze In ListaArkuszyImport
                ileRekordow = ileRekordow + 1
                'Importuj Arkusze do Projektu Nestingu Radana
                ArkuszImport.WczytajArkuszDoRadana()

                ' MsgBox(ArkuszImport.ID & " " & ArkuszImport.material & " " & ArkuszImport.grubosc & " " & ArkuszImport.ilosc & " " & ArkuszImport.x & " " & ArkuszImport.y & " " & ArkuszImport.Priorytet & " " & ArkuszImport.Sheet_Thickness_Unit & " " & ArkuszImport.Size_Units)

                ProgressBar1.Value = ProgressBar1.Value + 1
                procent = (ProgressBar1.Value * 100) / ProgressBar1.Maximum

                LabelProgressBar.Text = "Ukończono w " & procent.ToString("F0") & "%"
                Me.Update()
            Next

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wczytywania danych do Radana")
        End Try

        'Wyzerowanie listyArkuszy
        ListaArkuszyImport.Clear()

        If ileRekordow = 0 Then
            MsgBox("Brak Arkuszy do wczytania")
        End If

    End Sub

    Private Sub CBAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles CBAdmin.CheckedChanged
        Ukryj_Pokaz_Przyciski()
    End Sub

    Private Sub Ukryj_Pokaz_Przyciski()
        'Funkcja która pokazuje lub blokuje kilka formantów w zależności czy check box admin jest kliknięte
        RichTextBox1.Visible = CBAdmin.Checked
        BtnWczytajDane.Enabled = CBAdmin.Checked
    End Sub

    Private Sub BtnWczytajWybrane_Click(sender As Object, e As EventArgs) Handles BtnWczytajWybrane.Click

        'Wczytaj tylko wybrane Arkusze

        Dim ileArkuszy As Integer = 0

        Try
            'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz
            For row As Integer = 0 To DataGridView1.RowCount - 2
                If DataGridView1.Rows(row).Selected = True Then
                    ileArkuszy = ileArkuszy + 1
                    ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
                End If

            Next
        Catch ex As Exception
            MsgBox("Najpierw wczytaj materiały z bazy danych")
        End Try

        'Zmienne do progress baru
        'Najpierw go zeruje
        ProgressBar1.Value = 0
        'Określam jego maksimum
        ProgressBar1.Maximum = ileArkuszy
        'Info dla użytkownika
        LabelProgressBar.Text = "Proszę czekać"
        Dim procent As Double

        'Pętla, w której przypisujemy wartości z tablicy do Radana
        Try
            For Each ArkuszImport As DostepneArkusze In ListaArkuszyImport

                '  Importuj Do Projektu Nestingu Radana
                ArkuszImport.WczytajArkuszDoRadana()

                'Obsługa Progress bara
                ProgressBar1.Value = ProgressBar1.Value + 1
                procent = (ProgressBar1.Value * 100) / ProgressBar1.Maximum
                LabelProgressBar.Text = "Ukończono w " & procent.ToString("F0") & "%"

                Me.Update()

            Next

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wczytywania danych do Radana")
        End Try

        'Warunek do sprawdzenia czy coś zaznaczono
        If ileArkuszy < 1 Then
            MsgBox("Nic nie zaznaczono. Zaznacz poprawnie cały rząd.")
        End If

        ListaArkuszyImport.Clear()
    End Sub


    Private Sub Podwojne_Klikniecie_W_Komorke_Datagridview(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Obsługa podwójnego kliknięcia na komórce
        ' MsgBox("To działa")
        For index As Integer = 0 To DataGridView1.Rows.Count - 1

            If e.RowIndex = index And e.ColumnIndex < 22 And ComboBox1.SelectedIndex = 0 Then
                Try
                    'Pokaz Arkusz w nowym oknie Przyjęcia Magazynowego
                    ' MsgBox("To działa")
                    WyswietlDaneArkuszaWOknie(DataGridView1, index)
                Catch ex As Exception
                    MsgBox("Wystąpił błąd i nie można wyświetlić okna")
                    MsgBox(ex.Message)
                End Try
            End If

            If e.RowIndex = index And e.ColumnIndex < 22 And ComboBox1.SelectedIndex = 1 Then
                Try
                    'Otwórz plik i zrób miniaturkę
                    ' MsgBox(DataGridView1.Rows(index).Cells(22).Value)
                    myApp.OpenDrawing(CStr(DataGridView1.Rows(index).Cells(22).Value), True, "")
                    myMac.fla_thumbnail("C:\temp\miniaturka.png", 320, 230)
                    myApp.NewDrawing(True)
                    'Pokaz Arkusz w nowym oknie Przyjęcia Magazynowego
                    WyswietlDaneArkuszaWOknie(DataGridView1, index, "C:\temp\miniaturka.png")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            ' If e.RowIndex = index And e.ColumnIndex = 22 And ComboBox1.SelectedIndex = 1 Then
            'Otwórz plik po kliknięciu w ostanią kolumnę 
            'System.Diagnostics.Process.Start(CStr(DataGridView1.Rows(index).Cells(22).Value))
            '    End If
        Next

    End Sub

    Public Overloads Sub WyswietlDaneArkuszaWOknie(ByRef datagridview1 As DataGridView, ByVal Index As Integer, ByVal miniaturka As String)

        'Pokaz dane w formularzu przyjęcia magazynowego
        Dim PokazArkusz As New PrzyjęcieMagazynowe
        PokazArkusz.Show()

        PokazArkusz.BtnGenerujKod.Visible = True
        PokazArkusz.Barcode1.Visible = True

        'Przypisz Wartości z datagridview
        PokazArkusz.TXTNumerMagazynowy.Text = datagridview1.Rows(Index).Cells(0).Value
        PokazArkusz.TxtMaterial.Text = datagridview1.Rows(Index).Cells(1).Value
        PokazArkusz.TxtGrubosc.Text = datagridview1.Rows(Index).Cells(2).Value
        PokazArkusz.TxtIloscDostepna.Text = datagridview1.Rows(Index).Cells(3).Value
        PokazArkusz.TxtIloscRezerwacja.Text = datagridview1.Rows(Index).Cells(4).Value
        PokazArkusz.TxtIloscZuzyta.Text = datagridview1.Rows(Index).Cells(5).Value
        PokazArkusz.TxtX.Text = datagridview1.Rows(Index).Cells(6).Value
        PokazArkusz.TxtY.Text = datagridview1.Rows(Index).Cells(7).Value
        PokazArkusz.TxtPriorytet.Text = datagridview1.Rows(Index).Cells(8).Value
        PokazArkusz.TxtJednostki.Text = datagridview1.Rows(Index).Cells(9).Value
        '10
        PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value
        'PokazArkusz.TxtPole_uzytkownika2.Text = datagridview1.Rows(Index).Cells(12).Value
        PokazArkusz.TxtKlient.Text = datagridview1.Rows(Index).Cells(13).Value
        PokazArkusz.TxtWytop.Text = datagridview1.Rows(Index).Cells(14).Value
        PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(15).Value
        PokazArkusz.TxtDataPrzyjecia.Text = datagridview1.Rows(Index).Cells(16).Value
        PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        PokazArkusz.TxtLokalizacja.Text = datagridview1.Rows(Index).Cells(19).Value

        'Włącz Textboxy
        PokazArkusz.TxtDataPrzyjecia.Enabled = True
        PokazArkusz.TXTNumerMagazynowy.Enabled = True

        'Wyłącz Przyciski
        PokazArkusz.BtnWpiszDoBazy.Visible = False
        PokazArkusz.CBAdmin.Visible = False

        PokazArkusz.PictureBox1.ImageLocation = miniaturka

        PokazArkusz.Text = "Odpad w Magazynie"

    End Sub

    Public Overloads Sub WyswietlDaneArkuszaWOknie(ByRef datagridview1 As DataGridView, ByVal Index As Integer)
        ' MsgBox("1")
        'Pokaz dane w formularzu przyjęcia magazynowego
        Dim PokazArkusz As New PrzyjęcieMagazynowe
        '  MsgBox("2")
        PokazArkusz.Show()

        PokazArkusz.BtnGenerujKod.Visible = True
        PokazArkusz.Barcode1.Visible = True

        'Przypisz Wartości z datagridview
        PokazArkusz.TXTNumerMagazynowy.Text = datagridview1.Rows(Index).Cells(0).Value
        PokazArkusz.TxtMaterial.Text = datagridview1.Rows(Index).Cells(1).Value
        PokazArkusz.TxtGrubosc.Text = datagridview1.Rows(Index).Cells(2).Value
        PokazArkusz.TxtIloscDostepna.Text = datagridview1.Rows(Index).Cells(3).Value
        PokazArkusz.TxtIloscRezerwacja.Text = datagridview1.Rows(Index).Cells(4).Value
        PokazArkusz.TxtIloscZuzyta.Text = datagridview1.Rows(Index).Cells(5).Value
        PokazArkusz.TxtX.Text = datagridview1.Rows(Index).Cells(6).Value
        PokazArkusz.TxtY.Text = datagridview1.Rows(Index).Cells(7).Value
        PokazArkusz.TxtPriorytet.Text = datagridview1.Rows(Index).Cells(8).Value
        PokazArkusz.TxtJednostki.Text = datagridview1.Rows(Index).Cells(9).Value
        '10
        PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value
        PokazArkusz.TxtPole_uzytkownika2.Text = datagridview1.Rows(Index).Cells(12).Value
        PokazArkusz.TxtKlient.Text = datagridview1.Rows(Index).Cells(13).Value
        PokazArkusz.TxtWytop.Text = datagridview1.Rows(Index).Cells(14).Value
        PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(15).Value
        PokazArkusz.TxtDataPrzyjecia.Text = datagridview1.Rows(Index).Cells(16).Value
        PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        PokazArkusz.TxtLokalizacja.Text = datagridview1.Rows(Index).Cells(19).Value

        'Włącz Textboxy
        PokazArkusz.TxtDataPrzyjecia.Enabled = True
        PokazArkusz.TXTNumerMagazynowy.Enabled = True

        'Wyłącz Przyciski
        PokazArkusz.BtnWpiszDoBazy.Visible = False
        PokazArkusz.CBAdmin.Visible = False
        PokazArkusz.BtnWpiszDoBazyZosobna.Visible = False

        PokazArkusz.Text = "Arkusz w Magazynie"
        'MsgBox("3")
    End Sub

    Private Sub BtnWyszukaj_Click(sender As Object, e As EventArgs) Handles BtnWyszukaj.Click

        'Wyszukiwarka
        Dim ZapytanieSQL As String
        Dim Szukana As String = TxtWyszukaj.Text

        Dim tabela As String = "Arkusze"

        If ComboBox1.Text = "Arkusze" Then
            tabela = "Arkusze"
        ElseIf ComboBox1.Text = "Odpady" Then
            tabela = "Odpady"
        Else
            MsgBox("Nieprawidłowe wartości w liście rozwijalnej")
        End If

        'Jeżeli wartość szukana jest liczbą to
        If IsNumeric(Szukana) Then
            ZapytanieSQL = "Select * from " & tabela & " where Priorytet = " & Szukana &
            " or Grubosc = " & Szukana &
            " or X = " & Szukana &
            " or Y = " & Szukana &
            " or [Numer Magazynowy] = " & Szukana &
         " or IloscDostepne = " & Szukana &
         " or IloscZuzyte = " & Szukana &
        " or IloscRezerwacja = " & Szukana

            'Jeżeli nie jest liczbą to
        Else
            'MsgBox("Szukana nie jest liczbą")
            ZapytanieSQL = "Select * from " & tabela & " where Material = '" & Szukana & "'" &
            " or Klient = '" & Szukana & "'" &
            " or Atest = '" & Szukana & "'" &
            " or Wytop = '" & Szukana & "'" &
            " or WZ = '" & Szukana & "'" &
            " or Size_Units = '" & Szukana & "'" &
            " or Pole_uzytkownika = '" & Szukana & "'" &
            " or Lokalizacja = '" & Szukana & "'"
        End If

        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieSQL, DataGridView1)

    End Sub

    Private Sub BtnPokazWszystko_Click(sender As Object, e As EventArgs) Handles BtnPokazWszystko.Click
        'Pokaz wszystkie Arkusze
        Dim ZapytanieSQL As String
        If ComboBox1.Text = "Arkusze" Then
            ZapytanieSQL = "Select * From Arkusze"
        Else
            ZapytanieSQL = "Select * From Odpady"
        End If

        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieSQL, DataGridView1)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Wyświetl tylko Dostępne Arkusze
        If ComboBox1.SelectedIndex = 0 Then
            Dim zapytanie As String
            zapytanie = "Select * From Arkusze where iloscDostepne > 0"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            BtnWczytajOdpad.Enabled = False
            BtnWczytajDoRadana.Enabled = True
            BtnWczytajWybrane.Enabled = True
            CBOdpadyZatwierdzone.Visible = False
            ' BtnWczytajWszystkieOdpady.Enabled = False
        Else
        End If
        'Wyświetl tylko Dostępne Odpady
        If ComboBox1.SelectedIndex = 1 Then
            Dim zapytanie As String
            zapytanie = "Select * From Odpady where iloscDostepne > 0"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            BtnWczytajOdpad.Enabled = True
            BtnWczytajDoRadana.Enabled = False
            BtnWczytajWybrane.Enabled = False
            CBOdpadyZatwierdzone.Visible = True


            ' BtnWczytajWszystkieOdpady.Enabled = True
        Else
        End If

    End Sub

    Private Sub BtnWczytajOdpad_Click(sender As Object, e As EventArgs) Handles BtnWczytajOdpad.Click
        Dim IloscOdpadow = 0

        'MsgBox(SciezkaOdpadowDoUzyciaWProjekcie)
        Dim Sciezka_Pliku_Odpadu As String = ""
        Dim NazwaOdpadu As String = ""
        Dim destination As String = ""
        Try

            For row As Integer = 0 To DataGridView1.RowCount - 2
                IloscOdpadow = IloscOdpadow + 1
                If DataGridView1.Rows(row).Selected = True Then
                    ' ileArkuszy = ileArkuszy + 1
                    Sciezka_Pliku_Odpadu = DataGridView1.Rows(row).Cells(22).Value
                    NazwaOdpadu = DataGridView1.Rows(row).Cells(21).Value
                    'MsgBox("czy chcesz zaimportować odpad: " & Sciezka_Pliku_Odpadu)
                    destination = SciezkaOdpadowDoUzyciaWProjekcie & "\" & NazwaOdpadu
                    '  MsgBox(destination)
                    File.Copy(Sciezka_Pliku_Odpadu, destination)

                    myMac.prj_save()
                    If File.Exists(destination) Then

                        DoFlowLogaDoPliku("Przekopiowano plik odpadu do: " & destination)
                    Else
                        DoFlowLogaDoPliku("Nie przekopiowano pliku odpadu do: " & destination)
                    End If

                    'ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
                End If

            Next
            If IloscOdpadow > 0 Then
                MsgBox("Wczytano pomyślnie odpady")
            Else
                MsgBox("Brak odpadów do wczytania")
            End If


        Catch ex As IOException
            DoFlowLogaDoPliku("Bład na linii I/O: " & ex.GetType().Name)
        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas kopiowania pliku odpadu. Sprawdź czy już wczytałeś ten odpad: " & NazwaOdpadu)

        End Try
    End Sub

    Private Sub BtnWczytajWszystkieOdpady_Click(sender As Object, e As EventArgs) Handles BtnWczytajWszystkieOdpady.Click

        Dim IloscOdpadow = 0

        'MsgBox(SciezkaOdpadowDoUzyciaWProjekcie)
        Dim Sciezka_Pliku_Odpadu As String = ""
        Dim NazwaOdpadu As String = ""
        Dim destination As String = ""
        Try
            For row As Integer = 0 To DataGridView1.RowCount - 2
                IloscOdpadow = IloscOdpadow + 1
                ' ileArkuszy = ileArkuszy + 1
                Sciezka_Pliku_Odpadu = DataGridView1.Rows(row).Cells(22).Value
                NazwaOdpadu = DataGridView1.Rows(row).Cells(21).Value
                'MsgBox("czy chcesz zaimportować odpad: " & Sciezka_Pliku_Odpadu)
                destination = SciezkaOdpadowDoUzyciaWProjekcie & NazwaOdpadu
                '  MsgBox(destination)
                File.Copy(Sciezka_Pliku_Odpadu, destination)
                myMac.prj_save()
                'ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
                If File.Exists(destination) Then
                    DoFlowLogaDoPliku("Przekopiowano plik odpadu do: " & destination)
                Else
                    DoFlowLogaDoPliku("Nie przekopiowano pliku odpadu do: " & destination)
                End If
            Next

            If IloscOdpadow > 0 Then
                MsgBox("Wczytano pomyślnie odpady")
            Else
                MsgBox("Brak odpadów do wczytania")
            End If
        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas kopiowania pliku odpadu. Sprawdź czy już wczytałeś ten odpad: " & NazwaOdpadu)
        End Try
    End Sub

    Private Sub BtnGenerujKody_Click(sender As Object, e As EventArgs) Handles BtnGenerujKody.Click
        'Sprawdź poprawność ustawień Kodów kreskowych
        If CBZrobBarcody.Checked = True Then

            If Directory.Exists(TxtSciezkaBarcode.Text) = False Then
                MsgBox("Wskazany folder do zapisu Barcode nie istnieje. Sprawdź ścieżke do zapisu i spróbuj ponownie.")

                Exit Sub
            End If

            Dim IloscChecboxowZaznaczonych As Integer = 0

            If CBNumerMagazynowy.Checked = True Then
                IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
            End If
            If CbMaterial.Checked = True Then
                IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
            End If
            If CBGrubosc.Checked = True Then
                IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
            End If
            If CBWymiar.Checked = True Then
                IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
            End If

            'Jeżeli nie zaznaczono żadnego checkboxa to podaj komunikat i wyjdź
            If IloscChecboxowZaznaczonych = 0 Then
                MsgBox("Zaznacz przynajmniej jedną opcję do zapisu kodu kreskowego i spróbuj ponownie")
                Exit Sub
            End If

        End If


        'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz
        For row As Integer = 0 To DataGridView1.RowCount - 2

            If DataGridView1.Rows(row).Selected = True Then
                ' ileArkuszy = ileArkuszy + 1
                ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
            End If

        Next

        'Barcode
        Dim BarcodeData As String
        Dim sciezka As String

        Dim IloscRzedow As Integer = 0
        For Each ArkuszImport As DostepneArkusze In ListaArkuszyImport
            IloscRzedow = IloscRzedow + 1
            'Barcode
            BarcodeData = ""
            sciezka = ""
            If CBZrobBarcody.Checked = True Then

                If CBNumerMagazynowy.Checked = True Then
                    BarcodeData = BarcodeData & CStr(ArkuszImport.NumerMagazynowy) '& "-"
                    sciezka = sciezka & CStr(ArkuszImport.NumerMagazynowy) & "-"
                End If
                If CbMaterial.Checked = True Then
                    BarcodeData = BarcodeData & ArkuszImport.Material
                    sciezka = sciezka & ArkuszImport.Material
                End If
                If CBGrubosc.Checked = True Then
                    BarcodeData = BarcodeData & CStr(ArkuszImport.Grubosc) '& "#"
                    sciezka = sciezka & "#" & CStr(ArkuszImport.Grubosc) & "#"
                End If
                If CBWymiar.Checked = True Then
                    BarcodeData = BarcodeData & CStr(ArkuszImport.X) & "x" & CStr(ArkuszImport.Y)
                    sciezka = sciezka & CStr(ArkuszImport.X) & "x" & CStr(ArkuszImport.Y)
                End If

                Barcode1.Data = BarcodeData
                sciezka = TxtSciezkaBarcode.Text & "\" & sciezka & ".png"

                Try
                    Barcode1.SaveAsImage(sciezka)
                    '  IloscWygenerowanychKodowKreskowych = IloscWygenerowanychKodowKreskowych + 1
                Catch ex As Exception
                    MsgBox("Wystąpił błąd podczas zapisu kodu kreskowego." & ex.Message)
                End Try

            End If

            'Barcode koniec
        Next
        If IloscRzedow > 0 Then
            MsgBox("Wygenerowano kody kreskowe ")
        Else
            MsgBox("Brak zaznaczonych elementów na liście Arkuszy/Odpadów")
        End If
    End Sub

    Private Sub BtnOtworzPlik_Click(sender As Object, e As EventArgs) Handles BtnOtworzPlik.Click
        Dim myStream As Stream = Nothing
        Dim folderbrowser As New FolderBrowserDialog()

        If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            TxtSciezkaBarcode.Text = folderbrowser.SelectedPath

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBKolorTla.SelectedIndexChanged
        'Zmiana koloru tła w zależności od wybranej pozycji w comboboxie

        Dim kolor As Integer = CBKolorTla.SelectedIndex
        Select Case kolor
            Case 0
                Me.BackColor = Color.LimeGreen
            Case 1
                Me.BackColor = Color.Gray
            Case Else
                Me.BackColor = Color.Gray
        End Select
    End Sub

    Private Sub CBZrobBarcody_CheckedChanged(sender As Object, e As EventArgs) Handles CBZrobBarcody.CheckedChanged

        CBNumerMagazynowy.Enabled = CBZrobBarcody.Checked
        CbMaterial.Enabled = CBZrobBarcody.Checked
        CBGrubosc.Enabled = CBZrobBarcody.Checked
        CBWymiar.Enabled = CBZrobBarcody.Checked
        TxtSciezkaBarcode.Enabled = CBZrobBarcody.Checked
        BtnOtworzPlik.Enabled = CBZrobBarcody.Checked
        LblUstawieniaKoduKreskowego.Enabled = CBZrobBarcody.Checked

    End Sub

    Private Sub CBOdpadyZatwierdzone_CheckedChanged(sender As Object, e As EventArgs) Handles CBOdpadyZatwierdzone.CheckedChanged
        If CBOdpadyZatwierdzone.Checked = True Then
            Dim zapytanie As String
            zapytanie = "Select * From Odpady where iloscDostepne > 0 and Lokalizacja <> ''"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        End If

        If CBOdpadyZatwierdzone.Checked = False Then
            Dim zapytanie As String
            zapytanie = "Select * From Odpady where iloscDostepne > 0"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        End If

    End Sub

End Class
