'Klasa używana w Rezerwacji Arkuszy w RadraftInteropPlugIn.vb

Public Class UzyteArkusze
    Public StockId As Integer                                          'Numer Magazynowy
    Public Used As Integer                                             'Ilość Użytych (do rezerwacji) Arkuszy
    Public Material As String
    Public Grubosc As Double
    Public X As Double
    Public Y As Double
    Public ID5 As New List(Of Integer)                                  'Numery ID w projekcie
    Public ileID As Integer

    Public Sub Zapisz_Rezerwacje_Do_Loga()
        'Zamiana  (w grubości) przecinków na kropki bo inaczej będzie błąd w zapytaniu SQL
        Dim gr As String = "'" & CStr(Grubosc) & "'"
        gr = Replace(gr, ",", ".")

        Dim ZapytanieSql As String
        ZapytanieSql = "Insert into LOG2 " &
               "(Akcja, 
                IDArkusza,
                NazwaProjektu,
                IloscDostepnych,
                IloscZarezerwowanych,
                Uzytkownik,
                Material,
                Grubosc,
                X,
                Y)" &
                "values" &
                "('Rezerwacja'," &
                StockId & "," &
                "'" & SciezkaProjektu & "'," &
                0 & "," &
                Used & "," &
                "'" & nazwaUzytkownika & "'," &
                "'" & Material & "'," &
                gr & "," &
                X & "," &
                Y & ")"

        ' MsgBox(ZapytanieSql)
        DoFlowLogaDoPliku(ZapytanieSql)

        Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSql)
    End Sub

    Public Sub Rezerwuj_Ilosci_W_Bazie()
        Dim zapytanieUpdate As String
        zapytanieUpdate = "Update Arkusze SET IloscDostepne = IloscDostepne -" & Used &
                              ", IloscRezerwacja = IloscRezerwacja + " & Used &
                              " WHERE[Numer Magazynowy] = " & StockId
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanieUpdate)

        DoFlowLogaDoPliku(zapytanieUpdate)
    End Sub

    Public Function Zwroc_Ilosc_Dostepna() As Integer
        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego 
        'datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe
        Dim ZapytanieIloscDostepna As String = "select IloscDostepne from Arkusze where [Numer Magazynowy] = " & StockId
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieIloscDostepna, tymczasowePM.DataGridView1)
        Dim IloscDostepna As Integer = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value
        tymczasowePM.Dispose()
        Return IloscDostepna
    End Function

    Public Function Sprawdz_Czy_Jest_Rezerwacja() As Boolean
        'Definiuje nowy formularz Przyjęcia Magazynowego tylko po to aby mieć chwilowy dostęp do jego 
        'datagridview
        Dim tymczasowePM As New PrzyjęcieMagazynowe
        Dim ZapytanieIloscDostepna As String = "select count (Akcja) from Log2 where IDArkusza = " & StockId &
            " and Akcja = 'Rezerwacja' And NazwaProjektu = '" & SciezkaProjektu & "'"
        'MsgBox(ZapytanieIloscDostepna)
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ZapytanieIloscDostepna, tymczasowePM.DataGridView1)
        Dim IloscDostepna As Integer = tymczasowePM.DataGridView1.Rows(0).Cells(0).Value
        tymczasowePM.Dispose()
        If IloscDostepna > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    'Konstruktor odczytuje dane z datagridview (potrzebna pętla po rzędach row)

End Class
