
Imports System.Windows.Forms

Public Class AnulowanieRezerwacjivb
    Dim nazwaUzytkownika As String = myMac.UID

    Private Sub BtnAnulujPrzyjęcieMagazynowe_Click(sender As Object, e As EventArgs) Handles BtnAnulujPrzyjęcieMagazynowe.Click

        Dim PierwszaCyfra As String
        Dim tabela As String = "Arkusze"
        Dim zapytanie As String
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then
                    'Sprawdź pierwszą cyfrę numeru magazynowego, jeżeli jedynka to aktualizuj tabele Arkusze
                    'jeżeli 5 to tabele odpady
                    PierwszaCyfra = CStr(DataGridView1.Rows(i).Cells(3).Value)
                    PierwszaCyfra = PierwszaCyfra.Substring(0, 1)

                    If PierwszaCyfra = "1" Then
                        tabela = "Arkusze"
                    ElseIf PierwszaCyfra = "5" Then
                        tabela = "Odpady"
                    Else ' Jeżeli jakakolwiek inna to wyświetl ostrzeżenie
                        MsgBox("Napotkano nietypowy Numer Magazynowy pierwsza cyfra nie jest zgodna z 
                                Arkuszem (1) ani Odpadem (5)")
                        Exit Sub
                    End If

                    'Zapytanie, które aktualizuje ilość arkuszy w tabeli Arkusze
                    zapytanie = "Update " & tabela & " SET IloscDostepne = IloscDostepne - " &
                    CStr(DataGridView1.Rows(i).Cells(4).Value) &
                     " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value

                    If Wyslij_Zapytanie_SQL_Do_Bazy_Zwroc_info(zapytanie) = True Then

                        DoFlowLogaDoPliku("Anulowanie Przyjęcia Magazynowego:" & zapytanie)

                        'Usuń informacje z Loga
                        zapytanie = "Delete from LOG2 where [IDArkusza]  = " &
                                     DataGridView1.Rows(i).Cells(3).Value
                        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
                        DoFlowLogaDoPliku("Usunięcie informacji z loga:" & zapytanie)

                    Else
                        DoFlowLogaDoPliku("Arkusze z tego przyjęcia magazynowego są już zarezerwowane. 
                                Anuluj najpierw rezerwacje")
                        MsgBox("Arkusze z tego przyjęcia magazynowego są już zarezerwowane. 
                                Anuluj najpierw rezerwacje")
                    End If

                End If
            Next
        Catch ex As Exception
            MsgBox("Wystąpił błąd przy aktualizowaniu dostępnych ilości Arkusza")
        End Try

        'Zapytanie odświeżające widok datagridview
        zapytanie = "Select * from Log2 where Akcja = 'PrzyjecieMagazynowe'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        DoFlowLogaDoPliku("Odświeżenie widoku datagrdiview:" & zapytanie)

        ' MsgBox("Anulowano Wybrane Przyjęcia Magazynowe")

    End Sub

    Private Sub AnulowanieRezerwacji_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)


        'Maksymalizacja okna
        ' Me.WindowState = FormWindowState.Maximized

        'Przy pierwszy uruchomieniu okna wyświetl wszystkie rezerwacje
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid("Select * from LOG2 where Akcja = 'Rezerwacja'", DataGridView1)
    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Okno zawsze na wierzchu
        Me.TopMost = True
    End Sub

    Private Sub Anulowanie_Rezerwacji_Do_Loga(ByRef DataGrid As DataGridView, ByVal i As Integer)

        'Definicja funkcji, która wpisuje AnulowanieRezerwacji do LOGA

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
        DataGridView1.Rows(i).Cells(5).Value & "," &
        -DataGridView1.Rows(i).Cells(5).Value & "," &
         "'" & nazwaUzytkownika & "'" &
         ", GETDATE()" & "," &
         "'" & CStr(DataGridView1.Rows(i).Cells(9).Value) & "'," &
         CDbl(DataGridView1.Rows(i).Cells(10).Value) & "," &
         CDbl(DataGridView1.Rows(i).Cells(11).Value) & "," &
         CDbl(DataGridView1.Rows(i).Cells(12).Value) & ")"

        Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)
        DoFlowLogaDoPliku("Anulowanie Rezerwacji:" & ZapytanieSQL)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Obsługa zmiany ComboBoxa z trzema akcjami:
        '0 Rezerwacje 
        '1 Przyjęcia magazynowe
        '2 Anulowane Rezerwacje
        '3 Anulowane Przyjęcia Magazynowe ' W przygotowaniu
        '4 Wszystko ' W przygotowaniu

        If ComboBox1.SelectedIndex = 0 Then
            BtnAnulujRezerwacje.Visible = True
            BtnAnulujWszystkie.Visible = True
            BtnAnulujPrzyjęcieMagazynowe.Visible = False
            Dim zapytanie As String
            zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        Else
            BtnAnulujRezerwacje.Visible = False
        End If

        If ComboBox1.SelectedIndex = 1 Then
            BtnAnulujPrzyjęcieMagazynowe.Visible = True
            BtnAnulujWszystkie.Visible = False
            Dim zapytanie As String
            zapytanie = "Select * from Log2 where Akcja = 'PrzyjecieMagazynowe'"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        Else
            BtnAnulujPrzyjęcieMagazynowe.Visible = False
        End If

        If ComboBox1.SelectedIndex = 2 Then
            BtnAnulujPrzyjęcieMagazynowe.Visible = False
            BtnAnulujWszystkie.Visible = False
            Dim zapytanie As String
            zapytanie = "Select * from Log2 where Akcja = 'Anulowanie Rezerwacji'"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        Else
            'BtnAnulujPrzyjęcieMagazynowe.Visible = False
        End If

    End Sub

    'Anuluj wszystkie Rezerwacje widoczne w datagridview
    Private Sub BtnAnulujWszystkie_Click(sender As Object, e As EventArgs) Handles BtnAnulujWszystkie.Click
        'Zapisz Projekt
        ' myMac.prj_save()

        'Anuluj Wszystkie WYSWIETLONE w datagridview Rezerwacje
        Dim zapytanie As String
        Dim PierwszaCyfra As String
        Dim tabela As String = "Arkusze"

        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                'Sprawdź pierwszą cyfrę numeru magazynowego, jeżeli jedynka to aktualizuj tabele Arkusze
                PierwszaCyfra = CStr(DataGridView1.Rows(i).Cells(3).Value)
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

                'Zaktualizuj ilości Arkuszy
                zapytanie = "Update " & tabela & " SET IloscDostepne = IloscDostepne + " &
                                         CStr(DataGridView1.Rows(i).Cells(5).Value) & ", IloscRezerwacja = IloscRezerwacja -  " &
                                         CStr(DataGridView1.Rows(i).Cells(5).Value) &
                                         " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                'Później usuń Rezerwacje z Loga

                zapytanie = "Delete from LOG2 where [IDArkusza]  = " & DataGridView1.Rows(i).Cells(3).Value & " AND NazwaProjektu= '" & DataGridView1.Rows(i).Cells(2).Value & "'"
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                'Zapisz informacje o Anulowaniu Rezerwacji do Loga
                Anulowanie_Rezerwacji_Do_Loga(DataGridView1, i)
            Next

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas zmiany ilości dostępnych i zarezerwowanych arkuszy podczas Anulowania Rezerwacji")
        End Try

        'Odśwież dane w datagridview dla Rezerwacji

        zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
        MsgBox("Anulowano Rezerwacje")

        flaga = False

    End Sub

    'Anuluj tylko wybrane przez użytkownika Rezerwacje
    Private Sub BtnAnulujRezerwacje_Click(sender As Object, e As EventArgs) Handles BtnAnulujRezerwacje.Click

        Dim PierwszaCyfra As String

        'Zapisz Projekt
        myMac.prj_save()

        'Zapytanie w pętli aktualizujące ilości arkusza podczas anulowania rezerwacji
        Dim zapytanie As String
        Dim tabela As String = "Arkusze"

        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            If DataGridView1.Rows(i).Selected Then
                'Sprawdź pierwszą cyfrę numeru magazynowego, jeżeli jedynka to aktualizuj tabele Arkusze
                PierwszaCyfra = CStr(DataGridView1.Rows(i).Cells(3).Value)
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

                'Zaktualizuj ilości Arkuszy
                zapytanie = "Update " & tabela & " SET IloscDostepne = IloscDostepne + " &
                                     CStr(DataGridView1.Rows(i).Cells(5).Value) & ", IloscRezerwacja = IloscRezerwacja -  " &
                                     CStr(DataGridView1.Rows(i).Cells(5).Value) &
                                     " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                'Usuń Rezerwacje z Loga
                zapytanie = "Delete from LOG2 where [IDArkusza]  = " & DataGridView1.Rows(i).Cells(3).Value &
                    " AND NazwaProjektu= '" & DataGridView1.Rows(i).Cells(2).Value & "'"
                Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

                Try
                    'Zapisz informacje o Anulowaniu Rezerwacji do Loga
                    Anulowanie_Rezerwacji_Do_Loga(DataGridView1, i)
                Catch ex As Exception
                    MsgBox("Błąd przy zapisywaniu Anulowania Rezerwacji do Loga")
                End Try

            End If
        Next

        ' Odśwież dane w datagridview dla Rezerwacji
        zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)

        MsgBox("Anulowano Wybrane Rezerwacje")

    End Sub
End Class
