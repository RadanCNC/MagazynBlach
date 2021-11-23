Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports RasterEdge.Imaging.Basic
Imports RasterEdge.XDoc.PDF
'Imports BarcodeLib



Public Class PrzyjęcieMagazynowe

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Zawsze na wierzchu
        Me.TopMost = True
    End Sub

    Private Sub PrzyjęcieMagazynowe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub

    Private Sub TxtIloscDostepna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIloscDostepna.KeyPress

        'Zezwól na wpisywanie Tylko Cyfr

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtPowierzony_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPowierzony.KeyPress

        'Zezwól na wpisywanie Tylko Cyfr 0,1

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) <> 48 And Asc(e.KeyChar) <> 49 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtPriorytet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPriorytet.KeyPress
        'Tylko Cyfry

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtGrubosc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGrubosc.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtX.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtY.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub BtnWpiszDoBazy_Click(sender As Object, e As EventArgs) Handles BtnWpiszDoBazy.Click
        'Sprawdź poprawność ustawień Kodów kreskowych
        If CBZrobBarcody.Checked = True Then
            If SprawdzCzyIstniejeKatalog(TxtSciezkaBarcode.Text) = False Then
                Exit Sub
            End If
            If SprawdzUstawieniaKoduKreskowego() = False Then
                Exit Sub
            End If
        End If

        Dim BarcodeData As String = ""
        Dim sciezka As String = ""

        If TxtMaterial.Text = "" Then
            MsgBox("Wpisz Nazwę Materiału")
            Exit Sub
        ElseIf TxtGrubosc.Text = "" Then
            MsgBox("Wpisz Grubość Materiału")
            Exit Sub
        ElseIf TxtIloscDostepna.Text = "" Then
            MsgBox("Wpisz Ilość Dostępną")
            Exit Sub
        ElseIf CInt(TxtPriorytet.Text) < 1 Or CInt(TxtPriorytet.Text) > 9 Then
            MsgBox("Priorytet powinien się mieścić w zakresie od 1 do 9")
            Exit Sub
        End If

        'Wpisz do Bazy nowe Arkusze
        Dim zapytanie As String
        zapytanie = "Insert into Arkusze" &
         "( Material, Grubosc, IloscDostepne, IloscRezerwacja, IloscZuzyte, X, Y, Priorytet, Size_Units," &
         "Sheet_Thickness_Units, Pole_uzytkownika2, Klient, Wytop, Atest, WZ, Powierzony, Pole_Uzytkownika, Lokalizacja) values ('" &
         TxtMaterial.Text & "' ," &
         TxtGrubosc.Text & "," &
         TxtIloscDostepna.Text & "," &
         TxtIloscRezerwacja.Text & "," &
         TxtIloscZuzyta.Text & "," &
         TxtX.Text & "," &
         TxtY.Text & "," &
         TxtPriorytet.Text & ",'" &
         TxtJednostki.Text & "','" &
         TxtJednostki.Text & "','" &
         TxtPole_uzytkownika2.Text & "','" &
         TxtKlient.Text & "','" &
         TxtWytop.Text & "','" &
         TxtAtest.Text & "','" &
         TxtWz.Text & "'," &
         TxtPowierzony.Text & ",'" &
         TxtPoleUzytkownika.Text & "','" &
         TxtLokalizacja.Text &
         "')"

        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

        'Sprawdź Numer Magazynowy
        Dim NumerMagazynowy As Integer
        zapytanie = "select max ([Numer Magazynowy]) from Arkusze "

        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)

        NumerMagazynowy = DataGridView1.Rows(0).Cells(0).Value

        MsgBox("Dodano arkusze o numerze magazynowym: " & NumerMagazynowy)

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
        NumerMagazynowy & ",'" &
        SciezkaProjektu & "'," &
        TxtIloscDostepna.Text & "," &
        "'" & nazwaUzytkownika & "'," &
        "'" & TxtMaterial.Text & "'," &
        TxtGrubosc.Text & "," &
        TxtX.Text & "," &
        TxtY.Text &
        ")"

        Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)

        'Barcode
        If CBZrobBarcody.Checked = True Then

            If CBNumerMagazynowy.Checked = True Then
                BarcodeData = BarcodeData & CStr(NumerMagazynowy) '& "-"
                sciezka = sciezka & CStr(NumerMagazynowy) & "-"
            End If
            If CbMaterial.Checked = True Then
                BarcodeData = BarcodeData & TxtMaterial.Text
                sciezka = sciezka & TxtMaterial.Text
            End If
            If CBGrubosc.Checked = True Then
                BarcodeData = BarcodeData & TxtGrubosc.Text '& "#"
                sciezka = sciezka & "#" & TxtGrubosc.Text & "#"
            End If
            If CBWymiar.Checked = True Then
                BarcodeData = BarcodeData & TxtX.Text & "x" & TxtY.Text
                sciezka = sciezka & TxtX.Text & "x" & TxtY.Text
            End If
            Barcode1.Data = BarcodeData
            sciezka = TxtSciezkaBarcode.Text & "\" & sciezka & ".png"

            Try
                Barcode1.SaveAsImage(sciezka)
                MsgBox("Wygenerowano kod kreskowy: " & sciezka)
            Catch ex As Exception
                MsgBox("Wystąpił błąd podczas zapisu kodu kreskowego." & ex.Message)
            End Try

        End If

        'Barcode koniec

    End Sub


    Private Sub CBAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles CBAdmin.CheckedChanged
        'Zmień widoczność jeżeli jesteś adminem
        If CBAdmin.Checked = True Then
            RichTextBox1.Visible = True
            DataGridView1.Visible = True
        Else
            RichTextBox1.Visible = False
            DataGridView1.Visible = False
        End If
    End Sub

    Private Sub TxtWytop_TextChanged(sender As Object, e As EventArgs) Handles TxtWytop.TextChanged

    End Sub

    Private Sub BtnWpiszDoBazyZosobna_Click(sender As Object, e As EventArgs) Handles BtnWpiszDoBazyZosobna.Click
        'Sprawdź poprawność ustawień Kodów kreskowych
        If CBZrobBarcody.Checked = True Then
            If SprawdzCzyIstniejeKatalog(TxtSciezkaBarcode.Text) = False Then
                Exit Sub
            End If
            If SprawdzUstawieniaKoduKreskowego() = False Then
                Exit Sub
            End If
        End If

        Dim IloscWygenerowanychKodowKreskowych As Integer = 0

        If TxtMaterial.Text = "" Then
            MsgBox("Wpisz Nazwę Materiału")
            Exit Sub
        ElseIf TxtGrubosc.Text = "" Then
            MsgBox("Wpisz Grubość Materiału")
            Exit Sub
        ElseIf TxtIloscDostepna.Text = "" Then
            MsgBox("Wpisz Ilość Dostępną")
            Exit Sub
        ElseIf CInt(TxtPriorytet.Text) < 1 Or CInt(TxtPriorytet.Text) > 9 Then
            MsgBox("Priorytet powinien się mieścić w zakresie od 1 do 9")
            Exit Sub
        End If

        'Wpisz do Bazy nowe Arkusze
        Dim IloscArkuszy As Integer = 0
        IloscArkuszy = CInt(TxtIloscDostepna.Text)

        'Barcode
        Dim BarcodeData As String
        Dim sciezka As String

        For i As Integer = 1 To IloscArkuszy
            BarcodeData = ""
            sciezka = ""
            Dim zapytanie As String
            zapytanie = "Insert into Arkusze" &
             "( Material, Grubosc, IloscDostepne, IloscRezerwacja, IloscZuzyte, X, Y, Priorytet, Size_Units," &
             "Sheet_Thickness_Units, Pole_uzytkownika2, Klient, Wytop, Atest, WZ, Powierzony, Pole_Uzytkownika, Lokalizacja) values ('" &
             TxtMaterial.Text & "' ," &
             TxtGrubosc.Text & "," &
             1 & "," &
             TxtIloscRezerwacja.Text & "," &
             TxtIloscZuzyta.Text & "," &
             TxtX.Text & "," &
             TxtY.Text & "," &
             TxtPriorytet.Text & ",'" &
             TxtJednostki.Text & "','" &
             TxtJednostki.Text & "','" &
             TxtPole_uzytkownika2.Text & "','" &
             TxtKlient.Text & "','" &
             TxtWytop.Text & "','" &
             TxtAtest.Text & "','" &
             TxtWz.Text & "'," &
             TxtPowierzony.Text & ",'" &
             TxtPoleUzytkownika.Text & "','" &
             TxtLokalizacja.Text &
             "')"

            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

            Dim NumerMagazynowy As Integer
            zapytanie = "select max ([Numer Magazynowy]) from Arkusze "

            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)

            NumerMagazynowy = DataGridView1.Rows(0).Cells(0).Value
            'Barcode
            If CBZrobBarcody.Checked = True Then

                If CBNumerMagazynowy.Checked = True Then
                    BarcodeData = BarcodeData & CStr(NumerMagazynowy) '& "-"
                    sciezka = sciezka & CStr(NumerMagazynowy) & "-"
                End If
                If CbMaterial.Checked = True Then
                    BarcodeData = BarcodeData & TxtMaterial.Text
                    sciezka = sciezka & TxtMaterial.Text
                End If
                If CBGrubosc.Checked = True Then
                    BarcodeData = BarcodeData & TxtGrubosc.Text '& "#"
                    sciezka = sciezka & "#" & TxtGrubosc.Text & "#"
                End If
                If CBWymiar.Checked = True Then
                    BarcodeData = BarcodeData & TxtX.Text & "x" & TxtY.Text
                    sciezka = sciezka & TxtX.Text & "x" & TxtY.Text
                End If
                Barcode1.Data = BarcodeData
                sciezka = TxtSciezkaBarcode.Text & "\" & sciezka & ".png"

                Try
                    Barcode1.SaveAsImage(sciezka)
                    IloscWygenerowanychKodowKreskowych = IloscWygenerowanychKodowKreskowych + 1
                Catch ex As Exception
                    MsgBox("Wystąpił błąd podczas zapisu kodu kreskowego." & ex.Message)
                End Try

            End If

            'Barcode koniec

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
            NumerMagazynowy & ",'" &
            SciezkaProjektu & "'," &
            1 & "," &
            "'" & nazwaUzytkownika & "'," &
            "'" & TxtMaterial.Text & "'," &
            TxtGrubosc.Text & "," &
            TxtX.Text & "," &
            TxtY.Text &
            ")"

            Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)

        Next
        MsgBox("Wpisano arkusze do bazy danych. Wygenerowano " & IloscWygenerowanychKodowKreskowych & " kodów kreskowych")
        ' MsgBox("Wygenerowano " & IloscWygenerowanychKodowKreskowych & " kodów kreskowych")
        'Sprawdź Numer Magazynowy

        ' MsgBox("Dodano arkusze o numerze magazynowym: " & NumerMagazynowy)


    End Sub

    Public Function SprawdzCzyIstniejeKatalog(ByVal Katalog As String) As Boolean
        If Directory.Exists(Katalog) = False Then
            MsgBox("Wskazany folder do zapisu Kodów Kreskowych nie istnieje. Sprawdź ścieżke do zapisu i spróbuj ponownie.")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function SprawdzUstawieniaKoduKreskowego() As Boolean
        'Sprawdź poprawność ustawień Kodów kreskowych
        '    If CBZrobBarcody.Checked = True Then

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
            Return False
        Else
            Return True
        End If

        '  End If

    End Function



    Private Sub BtnGenerujKod_Click(sender As Object, e As EventArgs) Handles BtnGenerujKod.Click
        'Sprawdź poprawność ustawień Kodów kreskowych
        If CBZrobBarcody.Checked = True Then
            If SprawdzCzyIstniejeKatalog(TxtSciezkaBarcode.Text) = False Then
                Exit Sub
            End If
            If SprawdzUstawieniaKoduKreskowego() = False Then
                Exit Sub
            End If
        End If

        'Barcode
        If CBZrobBarcody.Checked = True Then
            'Wyzerowanie danych
            Dim BarcodeData As String = ""
            Dim sciezka As String = ""

            If CBNumerMagazynowy.Checked = True Then
                BarcodeData = BarcodeData & TXTNumerMagazynowy.Text '& "-"
                sciezka = sciezka & TXTNumerMagazynowy.Text & "-"
            End If
            If CbMaterial.Checked = True Then
                BarcodeData = BarcodeData & TxtMaterial.Text
                sciezka = sciezka & TxtMaterial.Text
            End If
            If CBGrubosc.Checked = True Then
                BarcodeData = BarcodeData & TxtGrubosc.Text '& "#"
                sciezka = sciezka & "#" & TxtGrubosc.Text & "#"
            End If
            If CBWymiar.Checked = True Then
                BarcodeData = BarcodeData & TxtX.Text & "x" & TxtY.Text
                sciezka = sciezka & TxtX.Text & "x" & TxtY.Text
            End If
            Barcode1.Data = BarcodeData
            sciezka = TxtSciezkaBarcode.Text & "\" & sciezka & ".png"

            Try
                Barcode1.SaveAsImage(sciezka)
                MsgBox("Wygenerowano kod kreskowy: " & sciezka)
            Catch ex As Exception
                MsgBox("Nie zapisano kodu kreskowego. Sprawdź ścieżke do zapisu. " & ex.Message)
            End Try
        Else
            MsgBox("Włącz ustawienia Barcode")

        End If
        'Koniec Barcode


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
        BtnGenerujKod.Enabled = CBZrobBarcody.CheckState

    End Sub

    Private Sub BtnOtworzPlik_Click(sender As Object, e As EventArgs) Handles BtnOtworzPlik.Click
        Dim myStream As Stream = Nothing
        Dim folderbrowser As New FolderBrowserDialog()

        If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            TxtSciezkaBarcode.Text = folderbrowser.SelectedPath

        End If
    End Sub
End Class