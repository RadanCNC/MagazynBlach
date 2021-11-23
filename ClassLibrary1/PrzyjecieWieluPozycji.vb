Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class Przyjecie_Wielu_Pozycji

    'Dim con As New SqlConnection("Server=WROCLAW_SZ_4; Database=ArkuszeDB; User=kamil;Pwd=kamil123")
    Dim con = Globals.sql.SQLConect
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable

    ' linia kodu odpowiadajaca za okno makra zawsze na wierzchu
    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True

        'ukrywa arkuszedatagridview2
        ArkuszeDataGridView2.Visible = False

    End Sub

    Private Sub btnWczytajDoBazy_Click(sender As Object, e As EventArgs) Handles btnWczytajDoBazy.Click
        Dim pyt_przy_kliknieciu_btnWczytajDoBazy As MsgBoxResult = MessageBox.Show("Czy na pewno zapisać arkusze do bazy?", "Czy na pewno zapisać arkusze do bazy?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If pyt_przy_kliknieciu_btnWczytajDoBazy = Windows.Forms.DialogResult.Yes Then


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




            Dim ZapytanieSqldoDgv As String
            Dim NumerMagazynowy As Integer
            'Try
            'If sql.HasException(True) Then Exit Sub



            For i As Integer = 0 To DataGridViewArkusze.RowCount - 2

                If DataGridViewArkusze.Rows(i).Cells(0).Value = "" Then

                    MsgBox("Kolumna Materiał musi być uzupełniona")

                    Exit Sub
                End If

                If IsNumeric(DataGridViewArkusze.Rows(i).Cells(2).Value) = False Then
                    MsgBox("Kolumna Ilość Dostępne musi być poprawnie uzupełniona")
                    Exit Sub
                End If

                If DataGridViewArkusze.Rows(i).Cells(1).Value = "" Then

                    MsgBox("Kolumna Grubość musi być uzupełniona")

                    Exit Sub
                End If
                If DataGridViewArkusze.Rows(i).Cells(2).Value = "" Then

                    MsgBox("Kolumna Ilość Dostępne musi być uzupełniona")

                    Exit Sub
                End If
                If DataGridViewArkusze.Rows(i).Cells(5).Value = "" Then

                    MsgBox("Kolumna X musi być uzupełniona")

                    Exit Sub
                End If
                If DataGridViewArkusze.Rows(i).Cells(6).Value = "" Then

                    MsgBox("Kolumna Y musi być uzupełniona")

                    Exit Sub
                End If
                ' If DataGridViewArkusze.Rows(i).Cells(13).Value = "" Then

                ' MsgBox("Kolumna WZ musi być uzupełniona")

                ' Exit Sub
                'End If

                '  Dim value As String
                '  Dim number As Double


                ' value = DataGridViewArkusze.Rows(x).Cells(6).Value
                ' If Double.TryParse(value, number) Then
                ' DataGridViewArkusze.Rows(x).Cells(6).Value = value
                'MsgBox(" Jest Ok")
                '  Else
                'MsgBox("Nie Jest Ok")
                ' End If


            Next

            'Pętla wczytująca dane z datagridview do bazy danych
            Dim Ile_rzedow As Integer = 0

            'Barcode
            Dim BarcodeData As String
            Dim Barcdode_sciezka_do_pliku As String

            'Deklaracja zmiennych z DatagridView
            Dim Material As String = ""
            Dim Grubosc As String = ""
            Dim IloscDostepne As String = ""
            Dim X As String = ""
            Dim Y As String = ""
            Dim Size_Units As String = ""
            Dim Sheet_Thickness_Units As String = ""
            Dim PoleUzytkownika2 As String = ""
            Dim Klient As String = ""
            Dim Wytop As String = ""
            Dim Atest As String = ""
            Dim Wz As String = ""
            Dim Powierzony As String = ""
            Dim Lokalizacja As String = ""

            Dim UtworzonoBarcode As Boolean

            'Początek pętli
            For cn As Integer = 0 To DataGridViewArkusze.RowCount - 2

                'Wyzerowanie zawartości barcode'a i jego ścieżki do pliku
                BarcodeData = ""
                Barcdode_sciezka_do_pliku = ""
                UtworzonoBarcode = False

                'Przypisanie danych z data gridview
                Material = DataGridViewArkusze.Rows(cn).Cells(0).Value
                Grubosc = DataGridViewArkusze.Rows(cn).Cells(1).Value
                IloscDostepne = DataGridViewArkusze.Rows(cn).Cells(2).Value
                X = DataGridViewArkusze.Rows(cn).Cells(5).Value
                Y = DataGridViewArkusze.Rows(cn).Cells(6).Value
                Size_Units = DataGridViewArkusze.Rows(cn).Cells(7).Value
                Sheet_Thickness_Units = DataGridViewArkusze.Rows(cn).Cells(8).Value
                PoleUzytkownika2 = DataGridViewArkusze.Rows(cn).Cells(9).Value
                Klient = DataGridViewArkusze.Rows(cn).Cells(10).Value
                Wytop = DataGridViewArkusze.Rows(cn).Cells(11).Value
                Atest = DataGridViewArkusze.Rows(cn).Cells(12).Value
                Wz = DataGridViewArkusze.Rows(cn).Cells(13).Value
                Powierzony = DataGridViewArkusze.Rows(cn).Cells(14).Value
                Lokalizacja = DataGridViewArkusze.Rows(cn).Cells(15).Value

                Dim zapytanie2 As String
                zapytanie2 = "INSERT INTO Arkusze (Material, Grubosc, IloscDostepne, X, Y, Size_Units, Sheet_Thickness_Units, Pole_uzytkownika2, Klient, Wytop, Atest, WZ, Powierzony, Lokalizacja) VALUES ('" &
                Material & "', " &
                Grubosc & ", " &
                IloscDostepne & ", " &
                X & ", " &
                Y & ", '" &
                Size_Units & "', '" &
                Sheet_Thickness_Units & "', '" &
                PoleUzytkownika2 & "', '" &
                Klient & "', '" &
                Wytop & "', '" &
                Atest & "', '" &
                Wz & "', '" &
                Powierzony & "', '" &
                Lokalizacja & "')"
                ' DataGridViewArkusze.Rows(cn).Cells(3).Value & ", " &
                'DataGridViewArkusze.Rows(cn).Cells(4).Value & ", " &


                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie2)

                'Sprawdz Numer Magazynowy

                ZapytanieSqldoDgv = "select max ([Numer Magazynowy]) from Arkusze "
                ' sql.ExecQuery(zapytaniesqldodgv)

                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieSqldoDgv, ArkuszeDataGridView2)

                NumerMagazynowy = ArkuszeDataGridView2.Rows(0).Cells(0).Value
                '  MsgBox(NumerMagazynowy)


                'Zapis do LOGa
                Dim nazwaUzytkownika As String = myMac.UID
                Dim zapytanie3 As String

                '  SQL.AddParam("@Code", "dddddd")
                zapytanie3 = "INSERT INTO LOG2 (Akcja, IDArkusza, NazwaProjektu, IloscDostepnych, Uzytkownik, Material, Grubosc, X, Y) VALUES ('PrzyjecieMagazynowe', " &
                NumerMagazynowy & ", '" &
                SciezkaProjektu & " ', " &
                IloscDostepne & ", ' " &
                nazwaUzytkownika & " ', ' " &
                Material & " ', " &
                Grubosc & ", " &
                X & ", " &
                Y & ")"

                ' sql.ExecQuery(zapytanie2)

                If Wyslij_Zapytanie_SQL_Do_Bazy_F(zapytanie3) = True Then
                    Ile_rzedow = Ile_rzedow + 1
                End If

                'Barcode
                If CBZrobBarcody.Checked = True Then

                    If Directory.Exists(TxtSciezkaBarcode.Text) = False Then
                        MsgBox("Ścieżka do katalogu:  " & TxtSciezkaBarcode.Text & " nie istnieje. Sprawdź ścieżkę i spróbuj ponownie")
                        Exit Sub
                    End If

                    If CBNumerMagazynowy.Checked = True Then
                        BarcodeData = BarcodeData & CStr(NumerMagazynowy) '& "-"
                        Barcdode_sciezka_do_pliku = Barcdode_sciezka_do_pliku & CStr(NumerMagazynowy) & "-"
                    End If
                    If CbMaterial.Checked = True Then
                        BarcodeData = BarcodeData & Material
                        Barcdode_sciezka_do_pliku = Barcdode_sciezka_do_pliku & Material
                    End If
                    If CBGrubosc.Checked = True Then
                        BarcodeData = BarcodeData & Grubosc '& "#"
                        Barcdode_sciezka_do_pliku = Barcdode_sciezka_do_pliku & "#" & Grubosc & "#"
                    End If
                    If CBWymiar.Checked = True Then
                        BarcodeData = BarcodeData & X & "x" & Y
                        Barcdode_sciezka_do_pliku = Barcdode_sciezka_do_pliku & X & "x" & Y
                    End If

                    Barcode1.Data = BarcodeData
                    Barcdode_sciezka_do_pliku = TxtSciezkaBarcode.Text & "\" & Barcdode_sciezka_do_pliku & ".png"

                    Try
                        Barcode1.SaveAsImage(Barcdode_sciezka_do_pliku)
                        UtworzonoBarcode = True
                    Catch ex As Exception
                        MsgBox("Błąd podczas zapisywania, sprawdź czy ścieżka istnieje: " & ex.Message)
                        UtworzonoBarcode = False
                    End Try

                End If
                'Koniec warunku czy ustawienia barcodu są włączone

                'Barcode koniec

                'Koniec pętli
            Next

            If Ile_rzedow > 0 And UtworzonoBarcode = True Then
                MsgBox("Dodano pomyślnie nowe arkusze i utworzono barcode'y")
            ElseIf Ile_rzedow > 0 And UtworzonoBarcode = False Then
                MsgBox("Dodano pomyślnie nowe arkusze i nie utworzono barcode'ów")
            Else
                MsgBox("Wpisz poprawnie dane")
            End If
            Ile_rzedow = 0

            Me.Dispose()
            '   Me.Close()
        Else

        End If


    End Sub

    Private Sub ArkuszeDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewArkusze.EditingControlShowing


        'autouzupełnianie nazwy materiału po wpisaniu pierwszej litery. Nazwa materiału pobierana jest z bazy danych
        Dim txt As New TextBox

        'nawiązanie połączenia z baza danych
        con.Open()
        dt = New DataTable
        'set your commands for holding the data.
        With cmd
            .Connection = con
            .CommandText = "SELECT DISTINCT material FROM arkusze"
        End With

        'uzupełnienie tabeli w bazie
        da.SelectCommand = cmd
        da.Fill(dt)

        Dim r As DataRow 'represents a row of data in the datatable
        For Each r In dt.Rows 'get a collection of rows that belongs to this table

            'the control shown to the user for editing the selected cell value
            If TypeOf e.Control Is TextBox Then
                txt = e.Control
                'adding the specific row of the table in the AutoCompleteCustomSource of the textbox
                txt.AutoCompleteCustomSource.Add(r.Item("Material").ToString)
                txt.AutoCompleteMode = AutoCompleteMode.Suggest
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
        Next

        'Zamknięcie połączenia z bazą danych
        con.Close()

    End Sub

    Private Sub Przyjecie_Wielu_Pozycji_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

        'declaring a new textbox column in the datagridview
        Dim txt As New DataGridViewTextBoxColumn
        'adding a textbox column in the datagridview
        DataGridViewArkusze.Columns.Add(txt)

    End Sub

    Private Sub dataGridView1_DefaultValuesNeeded(ByVal sender As Object,
    ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
    Handles DataGridViewArkusze.DefaultValuesNeeded

        With e.Row
            .Cells("Size_Units").Value = "mm"
            .Cells("Sheet_Thickness_Units").Value = "mm"
            .Cells("WymiarX").Value = "3000"
            .Cells("WymiarY").Value = "1500"
            .Cells("IloscDostepne").Value = "1"
            .Cells("Grubosc").Value = "1"
            .Cells("Material").Value = "FE37 235"
            .Cells("WZ").Value = ""
        End With

    End Sub

    Private Sub CBZrobBarcody_CheckedChanged(sender As Object, e As EventArgs) Handles CBZrobBarcody.CheckedChanged
        'Włącz lub wyłącz ustawienia do tworzenia barcodów
        CBGrubosc.Enabled = CBZrobBarcody.CheckState
        CbMaterial.Enabled = CBZrobBarcody.CheckState
        CBWymiar.Enabled = CBZrobBarcody.CheckState
        CBNumerMagazynowy.Enabled = CBZrobBarcody.CheckState
        LblKatalogDoZapisuBarcodow.Enabled = CBZrobBarcody.CheckState
        LblUstawieniaKoduKreskowego.Enabled = CBZrobBarcody.CheckState
        TxtSciezkaBarcode.Enabled = CBZrobBarcody.CheckState
    End Sub

    Private Sub BtnOtworzPlik_Click(sender As Object, e As EventArgs) Handles BtnOtworzPlik.Click
        Dim myStream As Stream = Nothing
        Dim folderbrowser As New FolderBrowserDialog()

        If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            TxtSciezkaBarcode.Text = folderbrowser.SelectedPath

        End If
    End Sub
End Class