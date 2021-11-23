

'DEFINICJA KLASY ARKUSZE Używana w ImportBlach

Imports System.IO
Imports System.Xml

Public Class DostepneArkusze
    Public NumerMagazynowy As String
    Public Material As String
    Public Grubosc As Double
    Public IloscDostepne As Integer
    Public X As Double
    Public Y As Double
    Public Priorytet As Integer
    Public Size_Units As String = "mm"
    Public Sheet_Thickness_Unit As String = "mm"

    Public Pole_uzytkownika As String
    Public IloscRezerwacja As Integer
    Public IloscZuzyte As Integer
    Public Status As String
    Public Klient As String
    Public Wytop As String
    Public Atest As String
    Public DataPrzyjęcia As String
    Public Wz As String
    Public Powierzony As String
    Public Lokalizacja As String

    'Ustawienie parametrów arkusza plus funkcja dodaj arkusz do projektu
    Public Sub WczytajArkuszDoRadana()
        myMac.SetString("PRJ_SHEET_STOCK_ID", NumerMagazynowy)
        myMac.SetString("PRJ_SHEET_MATERIAL", Material)
        myMac.SetNumber("PRJ_SHEET_THICKNESS", Grubosc)
        myMac.SetNumber("PRJ_SHEET_NUM_AVAILABLE", IloscDostepne)
        myMac.SetNumber("PRJ_SHEET_X_SIZE", X)
        myMac.SetNumber("PRJ_SHEET_Y_SIZE", Y)
        myMac.SetNumber("PRJ_SHEET_PRIORITY", Priorytet)
        myMac.SetString("PRJ_SHEET_SIZE_UNITS", Size_Units)
        myMac.SetString("PRJ_SHEET_THICK_UNITS", Sheet_Thickness_Unit)
        myMac.prj_add_sheet()
    End Sub

    'Konstruktor odczytuje dane z datagridview (potrzebna pętla po rzędach row)
    Sub New(ByRef DataGrid As Windows.Forms.DataGridView, ByVal row As Integer)
        NumerMagazynowy = DataGrid.Rows(row).Cells(0).Value
        Material = DataGrid.Rows(row).Cells(1).Value
        Grubosc = DataGrid.Rows(row).Cells(2).Value
        IloscDostepne = DataGrid.Rows(row).Cells(3).Value
        X = DataGrid.Rows(row).Cells(6).Value
        Y = DataGrid.Rows(row).Cells(7).Value
        Priorytet = DataGrid.Rows(row).Cells(8).Value
        Size_Units = DataGrid.Rows(row).Cells(9).Value
        Sheet_Thickness_Unit = DataGrid.Rows(row).Cells(10).Value
    End Sub

    'konstruktor z formularza przyjęcia magazynowego
    Sub New(ByRef PrzyjMagaz As PrzyjęcieMagazynowe)
        Material = PrzyjMagaz.TxtMaterial.Text
        Grubosc = CDbl(PrzyjMagaz.TxtGrubosc.Text)
        IloscDostepne = CInt(PrzyjMagaz.TxtIloscDostepna.Text)
        X = CInt(PrzyjMagaz.TxtX.Text)
        Y = CInt(PrzyjMagaz.TxtY.Text)
        Priorytet = CInt(PrzyjMagaz.TxtPriorytet.Text)
        Size_Units = PrzyjMagaz.TxtJednostki.Text
        Sheet_Thickness_Unit = PrzyjMagaz.TxtJednostki.Text

        Pole_uzytkownika = PrzyjMagaz.TxtPoleUzytkownika.Text
        IloscRezerwacja = CInt(PrzyjMagaz.TxtIloscRezerwacja.Text)
        IloscZuzyte = CInt(PrzyjMagaz.TxtIloscZuzyta.Text)
        Status = PrzyjMagaz.TxtPole_uzytkownika2.Text
        Klient = PrzyjMagaz.TxtKlient.Text
        Wytop = PrzyjMagaz.TxtWytop.Text
        Atest = PrzyjMagaz.TxtAtest.Text
        '  DataPrzyjęcia = PrzyjMagaz.Txt.Text
        Wz = PrzyjMagaz.TxtWz.Text
        Powierzony = PrzyjMagaz.TxtPowierzony.Text
        Lokalizacja = PrzyjMagaz.TxtLokalizacja.Text
    End Sub

    Public Sub Wpisz_Nowy_Arkusz_Do_Bazy()
        Dim zapytanie As String
        zapytanie = "Insert into Arkusze" &
         "( Material, Grubosc, IloscDostepne, IloscRezerwacja, IloscZuzyte, X, Y, Priorytet, Size_Units," &
         "Sheet_Thickness_Units, Status, Klient, Wytop, Atest, WZ, Powierzony, Pole_Uzytkownika, Lokalizacja) values ('" &
         Material & "' ," &
         Grubosc & "," &
         IloscDostepne & "," &
         IloscRezerwacja & "," &
         IloscZuzyte & "," &
         X & "," &
         Y & "," &
         Priorytet & ",'" &
         Size_Units & "','" &
         Sheet_Thickness_Unit & "','" &
         Status & "','" &
         Klient & "','" &
         Wytop & "','" &
         Atest & "','" &
         Wz & "'," &
         Powierzony & ",'" &
         Pole_uzytkownika & "','" &
         Lokalizacja &
         "')"
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
    End Sub

    Public Sub Wpisz_Przyjecie_Magazynowe_Do_Log()

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
        IloscDostepne & "," &
        "'" & nazwaUzytkownika & "'," &
        "'" & Material & "'," &
        Grubosc & "," &
        X & "," &
        Y &
        ")"
        ' MsgBox(ZapytanieSQL)
        Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)
    End Sub

    Sub New()

    End Sub



End Class
