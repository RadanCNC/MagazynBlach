Imports System.IO

Public Class ExportDXF
    Public Lista_Czesci As New List(Of Czesc)
    Public Lista_Etykiet As New List(Of Etykieta)

    Dim PrefiXNazwa As String = ""
    Dim PrefixMaterial As String = ""
    Dim PrefixGrubosc As String = ""
    Dim PrefixIlosc As String = ""
    Dim WlasnyText As String = ""

    Dim KolejnoscTxt = ""

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Zawsze na wierzchu
        Me.TopMost = True
    End Sub

    'Część 3D jako klasa 
    Public Class Czesc
        Public material As String
        Public grubosc As Double
        Public ID As String = ""
        Public ilosc As Integer = 0
        Public name As String
        Public nazwa As String = ""

        Public Sub PokazCzesc()
            nazwa = " Nazwa: " & name & " material: " & material & " Grubosc: " & grubosc & " Ilosc: " & ilosc & "ID: " & ID
        End Sub

    End Class


    Public Class Etykieta
        Public Nazwa As String
        Public Przedrostek As String
        Public Wpis As String
        Public Aktywny As Boolean
        Public NumerRzedu As Integer
        ' Public nazwa As String = ""
        Public Sub dodajDoDGV(ByRef datagrid As Windows.Forms.DataGridView)
            Dim row As String()
            row = New String() {Aktywny, Przedrostek, Nazwa}
            datagrid.Rows.Add(row)
        End Sub

        Public Sub New()

        End Sub

        Public Sub New(ByVal _nazwa As String, ByVal _przedrostek As String,
                    ByVal _wpis As String, ByVal _aktywny As Boolean)
            Nazwa = _nazwa
            Przedrostek = _przedrostek
            Wpis = _wpis
            Aktywny = _aktywny
        End Sub


    End Class

    Private Sub BtnZbierzInfo_Click(sender As Object, e As EventArgs) Handles BtnZbierzInfo.Click


    End Sub

    Private Sub BtnZrobRozwiniecia_Click(sender As Object, e As EventArgs) Handles BtnZrobRozwiniecia.Click
        For Each part As Czesc In Lista_Czesci

            'Ustaw aby rozwinięcie było w Edytorze Części
            myMac.MFL_U_PART_EDITOR_SPEC = True
            'Rozwiń część Automatycznie
            myMac.mfl_auto_unfold(part.ID)
            'Zapisz rysunek jako DXF 
            myApp.Application.ActiveDocument.SaveCopyAs(TxTKatalog.Text & "nazwa" & part.name & "material" & part.material & "grubosc" & part.grubosc & "ilosc" & part.ilosc & ".dxf", "DXF")

        Next

    End Sub

    Private Sub BtnZmienNazwy_Click(sender As Object, e As EventArgs) Handles BtnZmienNazwy.Click

        'Wyzerowanie listy
        Lista_Czesci.Clear()

        'Funkcja do rozpoczęcia skanowania plików 3D
        myMac.mfl_info_scan_start()

        'Podsumowanie wszystkich wczytanych części
        Dim wszystko As String = ""

        'Dane do części
        Dim material As String = ""
        Dim grubosc As Double = 0
        Dim ID As String = ""
        Dim ilosc As Integer = 0
        Dim name As String = ""


        ' W pętli skanujemy pokolei każdą część 3D
        ' Funkcja  myMac.mfl_info_scan_next() zwraca identyfikator następnego elementu-części
        ' Jeżeli będzie pusty lub nieprawidłowy to koniec pętli
        Try
            Do While String.IsNullOrEmpty(myMac.mfl_info_scan_next()) = False
                Try
                    ' myMac.MFL_U_PART_EDITOR_SPEC = True

                    'Odczytaj info o obiekcie
                    'ND_IDENT1 to ID części
                    myMac.mfl_object_info(myMac.ND_IDENT1, True)

                    'Dodajemy części do listy
                    'Ilość nie działa do tego jest inna pętla
                    Lista_Czesci.Add(New Czesc() With {
                    .material = myMac.MFL_U_MATERIAL_SPEC,
                    .grubosc = myMac.MFL_U_THICKNESS_SPEC,
                    .ilosc = 0,
                    .name = myMac.ND_NAME1,
                    .ID = myMac.ND_IDENT1
                    })
                    '.ilosc = myMac.MFL_U_NUM_DEVS_RES,
                Catch ex As Exception
                    MsgBox("Błąd przy dodaniu do listy ")
                End Try


                'Podsumowanie
                ' wszystko = wszystko & " Nazwa: " & name & " material: " & material & " Grubosc: " & grubosc & " Ilosc: " & ilosc & "ID: " & ID & vbNewLine
                Try
                    'Próbowałem od razu wszystkie części rozwijać ale robi tylko pierwszą
                    'Pozostałe nie wychodzą

                    ' myMac.mfl_auto_unfold(ID)
                Catch ex As Exception
                    MsgBox("Błąd przy tworzeniu rozwinięć: " & ex.Message)
                End Try

                Try
                    'Po rozwinięciu od razu zapisz do DXFa
                    '   myApp.Application.ActiveDocument.SaveCopyAs(TxTKatalog.Text & "nazwa" & name & "material" & material & "grubosc" & grubosc & "ilosc" & ilosc & ".dxf", "DXF")
                    '    myApp.Application.ActiveDocument.Close(True)
                Catch ex As Exception
                    MsgBox("Błąd przy zapisywaniu: " & ex.Message)
                End Try

            Loop

        Catch ex As Exception
            MsgBox("Błąd na końcu pętli" & ex.Message)
        End Try
        'Pokaż podsumowanie 

        'Pętla, w której zliczam ilość części o tej samej nazwie
        For Each part As Czesc In Lista_Czesci
            For Each part2 As Czesc In Lista_Czesci
                If part2.name = part.name Then
                    part2.ilosc = part2.ilosc + 1
                End If
            Next
        Next
        For Each part As Czesc In Lista_Czesci
            ' MsgBox(part.ilosc)
            'Podsumowanie
            wszystko = wszystko & part.name & " material: " & part.material & " Grubosc: " & part.grubosc & " Ilość: " & part.ilosc & " ID: " & part.ID & vbNewLine
        Next

        RichTextBox1.Text = wszystko

        '----------------------------------------------------------------------------------------

        If CBNazwa.Checked = True Then
            PrefiXNazwa = TxtNazwa.Text
        Else
            PrefiXNazwa = ""
        End If
        If CBMaterial.Checked = True Then
            PrefixMaterial = TxtMaterial.Text
        Else
            PrefixMaterial = ""
        End If
        If CbGrubosc.Checked = True Then
            PrefixGrubosc = TxtGrubosc.Text
        Else
            PrefixGrubosc = ""
        End If
        If CBIlosc.Checked = True Then
            PrefixIlosc = TxtIlosc.Text
        Else
            PrefixIlosc = ""
        End If



        'Dla każdej z części 

        Dim NowaNazwa As String
        Dim tekst As String
        For Each part As Czesc In Lista_Czesci


            Try
                NowaNazwa = ""
                tekst = TxTKatalog.Text & "\"
                'Otwórz plik .sym
                RichTextBox1.Text = RichTextBox1.Text & " Otwieram plik " & TxTKatalog.Text & "\" + part.name & ".sym"

                Dim material2 As String = ""
                Dim Grubosc2 As String = ""

                Using reader As New StreamReader(TxTKatalog.Text + part.name & ".sym")
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()

                        'Odczytaj atrybut numer 124 to jest wymiar X
                        ' X = CDbl(Odczytaj_wartosc_atrybutu(line, 124))
                        If line.Contains("Attr num=" & Chr(34) & "119") Then
                            'odczytaj całą linię z atrybutem 124
                            line = line.Substring(0, line.Length)
                            Dim Pozycja As Integer
                            ' znajdź pozycje w łańcuchu od którego zaczynają się wartości liczbowe
                            Pozycja = InStr(line, "value=")
                            ' Odczytaj tylko wartości liczbowe
                            line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                            material2 = line
                        End If

                        If line.Contains("Attr num=" & Chr(34) & "120") Then
                            'odczytaj całą linię z atrybutem 124
                            line = line.Substring(0, line.Length)
                            Dim Pozycja As Integer
                            ' znajdź pozycje w łańcuchu od którego zaczynają się wartości liczbowe
                            Pozycja = InStr(line, "value=")
                            ' Odczytaj tylko wartości liczbowe
                            line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                            Grubosc2 = line
                        End If

                    End While
                End Using

                part.material = material2
                part.grubosc = Grubosc2

                myApp.Application.Application.OpenSymbol(TxTKatalog.Text + part.name & ".sym", False, "")

                'Odczytaj atrybut Materiał
                ' Dim material2 As String = ""

                ' myApp.att_get_value(myApp.att_current_dwg(), 119, part.material)
                ' myApp.Application.ActiveDocument.att_get_dwg_attr(119, part.material)

                'I zapisz jako DXF ze zmienioną nazwą
                NowaNazwa = NowaNazwa & TxTKatalog.Text & "\"
                If CBNazwa.Checked = True Then
                    NowaNazwa = NowaNazwa & TxtNazwa.Text & part.name
                End If
                If CBMaterial.Checked = True Then
                    NowaNazwa = NowaNazwa & TxtMaterial.Text & part.material
                End If
                If CbGrubosc.Checked = True Then
                    NowaNazwa = NowaNazwa & TxtGrubosc.Text & CStr(part.grubosc)
                End If
                If CBIlosc.Checked = True Then
                    NowaNazwa = NowaNazwa & TxtIlosc.Text & CStr(part.ilosc)
                End If
                If CBWlasnyTekst.Checked = True Then
                    NowaNazwa = NowaNazwa & TxtWlasnyText.Text
                End If


                Select Case ComboBox1.SelectedIndex
                    Case 0
                        If CBNazwa.Checked = True Then
                            tekst = tekst & TxtNazwa.Text & part.name
                        End If

                    Case 1
                        If CBMaterial.Checked = True Then
                            tekst = tekst & TxtMaterial.Text & part.material
                        End If

                    Case 2
                        If CbGrubosc.Checked = True Then
                            tekst = tekst & TxtGrubosc.Text & CStr(part.grubosc)
                        End If

                    Case 3
                        If CBIlosc.Checked = True Then
                            tekst = tekst & TxtIlosc.Text & CStr(part.ilosc)
                        End If

                    Case 4
                        If CBWlasnyTekst.Checked = True Then
                            tekst = tekst & TxtWlasnyText.Text
                        End If
                    Case Else
                        tekst = tekst



                End Select

                Select Case ComboBox2.SelectedIndex
                    Case 0
                        If CBNazwa.Checked = True Then
                            tekst = tekst & TxtNazwa.Text & part.name
                        End If

                    Case 1
                        If CBMaterial.Checked = True Then
                            tekst = tekst & TxtMaterial.Text & part.material
                        End If

                    Case 2
                        If CbGrubosc.Checked = True Then
                            tekst = tekst & TxtGrubosc.Text & CStr(part.grubosc)
                        End If

                    Case 3
                        If CBIlosc.Checked = True Then
                            tekst = tekst & TxtIlosc.Text & CStr(part.ilosc)
                        End If

                    Case 4
                        If CBWlasnyTekst.Checked = True Then
                            tekst = tekst & TxtWlasnyText.Text
                        End If
                    Case Else
                        tekst = tekst
                End Select

                Select Case ComboBox3.SelectedIndex
                    Case 0
                        If CBNazwa.Checked = True Then
                            tekst = tekst & TxtNazwa.Text & part.name
                        End If

                    Case 1
                        If CBMaterial.Checked = True Then
                            tekst = tekst & TxtMaterial.Text & part.material
                        End If

                    Case 2
                        If CbGrubosc.Checked = True Then
                            tekst = tekst & TxtGrubosc.Text & CStr(part.grubosc)
                        End If

                    Case 3
                        If CBIlosc.Checked = True Then
                            tekst = tekst & TxtIlosc.Text & CStr(part.ilosc)
                        End If

                    Case 4
                        If CBWlasnyTekst.Checked = True Then
                            tekst = tekst & TxtWlasnyText.Text
                        End If
                    Case Else
                        tekst = tekst
                End Select

                Select Case ComboBox4.SelectedIndex
                    Case 0
                        If CBNazwa.Checked = True Then
                            tekst = tekst & TxtNazwa.Text & part.name
                        End If

                    Case 1
                        If CBMaterial.Checked = True Then
                            tekst = tekst & TxtMaterial.Text & part.material
                        End If

                    Case 2
                        If CbGrubosc.Checked = True Then
                            tekst = tekst & TxtGrubosc.Text & CStr(part.grubosc)
                        End If

                    Case 3
                        If CBIlosc.Checked = True Then
                            tekst = tekst & TxtIlosc.Text & CStr(part.ilosc)
                        End If

                    Case 4
                        If CBWlasnyTekst.Checked = True Then
                            tekst = tekst & TxtWlasnyText.Text
                        End If
                    Case Else
                        tekst = tekst
                End Select

                Select Case ComboBox5.SelectedIndex
                    Case 0
                        If CBNazwa.Checked = True Then
                            tekst = tekst & TxtNazwa.Text & part.name
                        End If

                    Case 1
                        If CBMaterial.Checked = True Then
                            tekst = tekst & TxtMaterial.Text & part.material
                        End If

                    Case 2
                        If CbGrubosc.Checked = True Then
                            tekst = tekst & TxtGrubosc.Text & CStr(part.grubosc)
                        End If

                    Case 3
                        If CBIlosc.Checked = True Then
                            tekst = tekst & TxtIlosc.Text & CStr(part.ilosc)
                        End If

                    Case 4
                        If CBWlasnyTekst.Checked = True Then
                            tekst = tekst & TxtWlasnyText.Text
                        End If
                    Case Else
                        tekst = tekst
                End Select

                tekst = tekst & ".dxf"
                ' MsgBox(tekst)
                NowaNazwa = NowaNazwa & ".dxf"
                ' NowaNazwa = tekst
                ' RichTextBox1.Text = RichTextBox1.Text & " Zapisuje plik " & tekst
                RichTextBox1.Text = tekst
                myApp.Application.ActiveDocument.SaveCopyAs(tekst, "DXF")
            Catch ex As Exception
                'Jak nie znajdzie pliku to wyświetl komunikat
                'MsgBox("Nie znaleziono pliku")
            End Try
        Next
    End Sub

    Private Sub BtnWybierz_Click(sender As Object, e As EventArgs) Handles BtnWybierz.Click
        'Wybierz katalog gdzie znajdują się rozwinięcia
        FolderBrowserDialog1.ShowNewFolderButton = True
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TxTKatalog.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ExportDXF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Ustaw wartości początkowe kolejności
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 1
        ComboBox3.SelectedIndex = 2
        ComboBox4.SelectedIndex = 3
        ComboBox5.SelectedIndex = 4

        BtnPodglad.Visible = CBAdmin.Checked
        RichTextBox1.Visible = CBAdmin.Checked
        LblPodglad.Visible = CBAdmin.Checked
        TxtPodglad.Visible = CBAdmin.Checked
        BtnZrobRozwiniecia.Visible = CBAdmin.Checked
        Me.Height = 520
    End Sub

    Private Sub BtnPodglad_Click(sender As Object, e As EventArgs) Handles BtnPodglad.Click
        'Podgląd nazwy pliku W TRAKCIE

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BtnWgore_Click(sender As Object, e As EventArgs)

        For Each Etykieta As Etykieta In Lista_Etykiet
            ' If Etykieta.NumerRzedu = DataGridView1.Rows(e.RowIndex).Cells(1).Value Then
            ' MsgBox(Etykieta.NumerRzedu)
            ' Etykieta.dodajDoDGV(DataGridView1)
            ' numer = numer + 1
        Next
    End Sub

    Private Sub CBNazwa_CheckedChanged(sender As Object, e As EventArgs) Handles CBNazwa.CheckedChanged
        If CBNazwa.Checked = False Then
            TxtNazwa.Enabled = False
        Else
            TxtNazwa.Enabled = True
        End If
        RichTextBox1.Text = "Zmieniono status chekbox"
        SprawdzCheckboxy()
    End Sub



    Private Sub CbGrubosc_CheckedChanged(sender As Object, e As EventArgs) Handles CbGrubosc.CheckedChanged
        If CbGrubosc.Checked = False Then
            TxtGrubosc.Enabled = False

        Else
            TxtGrubosc.Enabled = True
        End If
        SprawdzCheckboxy()
    End Sub
    Private Sub CBIlosc_CheckedChanged(sender As Object, e As EventArgs) Handles CBIlosc.CheckedChanged
        If CBIlosc.Checked = False Then
            TxtIlosc.Enabled = False
        Else
            TxtIlosc.Enabled = True
        End If
        SprawdzCheckboxy()
    End Sub
    Private Sub CBWlasnyTekst_CheckedChanged(sender As Object, e As EventArgs) Handles CBWlasnyTekst.CheckedChanged
        If CBWlasnyTekst.Checked = False Then
            TxtWlasnyText.Enabled = False
        Else
            TxtWlasnyText.Enabled = True
        End If
        SprawdzCheckboxy()

    End Sub

    Public Sub SprawdzCheckboxy()
        Dim IloscCheckBoxow As Integer = 0
        If CBNazwa.Checked = True Then
            IloscCheckBoxow = IloscCheckBoxow + 1
        End If
        If CBMaterial.Checked = True Then
            IloscCheckBoxow = IloscCheckBoxow + 1
        End If
        If CbGrubosc.Checked = True Then
            IloscCheckBoxow = IloscCheckBoxow + 1
        End If
        If CBIlosc.Checked = True Then
            IloscCheckBoxow = IloscCheckBoxow + 1
        End If
        If CBWlasnyTekst.Checked = True Then
            IloscCheckBoxow = IloscCheckBoxow + 1
        End If

        Select Case IloscCheckBoxow
            Case 0
                ComboBox1.SelectedItem = ""
                ComboBox1.Enabled = False

                ComboBox2.SelectedItem = ""
                ComboBox2.Enabled = False

                ComboBox3.SelectedItem = ""
                ComboBox3.Enabled = False

                ComboBox4.SelectedItem = ""
                ComboBox4.Enabled = False

                ComboBox5.SelectedItem = ""
                ComboBox5.Enabled = False

            Case 1
                ComboBox1.Enabled = True
                ComboBox2.SelectedItem = ""
                ComboBox2.Enabled = False

                ComboBox3.SelectedItem = ""
                ComboBox3.Enabled = False

                ComboBox4.SelectedItem = ""
                ComboBox4.Enabled = False

                ComboBox5.SelectedItem = ""
                ComboBox5.Enabled = False

            Case 2
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True

                ComboBox3.SelectedItem = ""
                ComboBox3.Enabled = False

                ComboBox4.SelectedItem = ""
                ComboBox4.Enabled = False

                ComboBox5.SelectedItem = ""
                ComboBox5.Enabled = False

            Case 3
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True

                ComboBox4.SelectedItem = ""
                ComboBox4.Enabled = False

                ComboBox5.SelectedItem = ""
                ComboBox5.Enabled = False

            Case 4
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                ComboBox4.Enabled = True

                ComboBox5.SelectedItem = ""
                ComboBox5.Enabled = False

            Case 5
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
            Case Else
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True

        End Select

    End Sub

    Public Function Sprawdz_Kolejnosc() As String
        Dim tekst As String = ""
        Select Case ComboBox1.SelectedIndex
            Case 0
                tekst = tekst & TxtNazwa.Text
            Case 1
                tekst = tekst & TxtMaterial.Text
            Case 2
                tekst = tekst & TxtGrubosc.Text
            Case 3
                tekst = tekst & TxtIlosc.Text
            Case 4
                tekst = tekst & TxtWlasnyText.Text

        End Select

        Select Case ComboBox2.SelectedIndex
            Case 0
                tekst = tekst & TxtNazwa.Text
            Case 1
                tekst = tekst & TxtMaterial.Text
            Case 2
                tekst = tekst & TxtGrubosc.Text
            Case 3
                tekst = tekst & TxtIlosc.Text
            Case 4
                tekst = tekst & TxtWlasnyText.Text
        End Select

        Select Case ComboBox3.SelectedIndex
            Case 0
                tekst = tekst & TxtNazwa.Text
            Case 1
                tekst = tekst & TxtMaterial.Text
            Case 2
                tekst = tekst & TxtGrubosc.Text
            Case 3
                tekst = tekst & TxtIlosc.Text
            Case 4
                tekst = tekst & TxtWlasnyText.Text
        End Select

        Select Case ComboBox4.SelectedIndex
            Case 0
                tekst = tekst & TxtNazwa.Text
            Case 1
                tekst = tekst & TxtMaterial.Text
            Case 2
                tekst = tekst & TxtGrubosc.Text
            Case 3
                tekst = tekst & TxtIlosc.Text
            Case 4
                tekst = tekst & TxtWlasnyText.Text
        End Select

        Select Case ComboBox5.SelectedIndex
            Case 0
                tekst = tekst & TxtNazwa.Text
            Case 1
                tekst = tekst & TxtMaterial.Text
            Case 2
                tekst = tekst & TxtGrubosc.Text
            Case 3
                tekst = tekst & TxtIlosc.Text
            Case 4
                tekst = tekst & TxtWlasnyText.Text
        End Select

        Return tekst
    End Function


    Private Sub CBMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles CBMaterial.CheckedChanged
        If CBMaterial.Checked = False Then
            TxtMaterial.Enabled = False
        Else
            TxtMaterial.Enabled = True
        End If
        SprawdzCheckboxy()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CBAdmin.CheckedChanged
        BtnPodglad.Visible = CBAdmin.Checked
        BtnZrobRozwiniecia.Visible = CBAdmin.Checked
        RichTextBox1.Visible = CBAdmin.Checked
        LblPodglad.Visible = CBAdmin.Checked
        TxtPodglad.Visible = CBAdmin.Checked
        If CBAdmin.Checked = True Then
            Me.Height = 990
        Else
            Me.Height = 520
        End If

    End Sub
End Class