

'Biblioteki funkcji
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class RadraftInteropPlugIn
    ' This is a special sub that the Radan application interfaces with. 
    Public Sub OnConnectToApplication(app As Radraft.Interop.Application)
        ' Set global variable to the Radan Application that is running 
        myApp = app
    End Sub
    Dim listaArkuszy As New List(Of UzyteArkusze)
    Dim listaOdpadowDoUzycia As New List(Of OdpadyDoUzycia)
    Dim listaUzytychOdpadow As New List(Of UzyteOdpady)

    Dim index As Boolean = True
    Dim pierwszeUruchomienia As Boolean = True



    ' This is another special sub that interfaces with the Radan GUI.  ' The menu system that is required in Radan is created here.. 
    Public Sub OnUpdateGUI()

        If pierwszeUruchomienia = True Then
            Dim ustawienia As New Ustawienia
            ustawienia.wczytajUstawianieZPliku()
        End If

        pierwszeUruchomienia = False

        ' set the global mac object to our application mac object 
        myMac = myApp.Mac
        ' using myApp, add the top menu with AddMenu 
        If myMac.prj_is_open() And myApp.GUIState = Radraft.Interop.RadGUIState.radNest And myApp.GUISubState = Radraft.Interop.RadGUISubState.radModifyNest Then
            ' now add another top menu item and a sub menu item 
            myApp.PluginManager.AddMenu("", "Magazyn blach")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Import blach", "ImportujBlachy")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Przyjęcie magazynowe", "Uruchom_Przyjecie_magazynowe")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Przyjęcie wielu pozycji", "Uruchom_Przyjecie_Wielu_Pozycji")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Rezerwacja arkuszy", "Uruchom_Rezerwacja_arkuszy")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Anulowanie rezerwacji", "Uruchom_Anulowanie_rezerwacji")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Ustawienia Administracyjne", "Uruchom_Ustawienia_administracyjne")
            myApp.PluginManager.AddMenuItem("Magazyn blach", "Informacje", "Uruchom_Informacje")
            ' myApp.PluginManager.AddMenuItem("Magazyn blach", "FlowLog - działania i błędy", "Uruchom_FlowLog")
            ' myApp.PluginManager.AddMenuItem("Magazyn blach", "Aktualizacja nestingu", "Uruchom_Aktualizacja_nestingu")

            SciezkaProjektu = myMac.prj_get_file_path()
            nazwaUzytkownika = myMac.UID
            pierwszeUruchomienia = False
            Dim z As String = ""
        End If

        '   If myApp.GUIState = Radraft.Interop.RadGUIState.radPart Then
        '  myApp.PluginManager.AddMenu("", "Zamien na DXF")
        '   myApp.PluginManager.AddMenuItem("Zamien na DXF", "Zamien na DXF", "ZamiennaDXF")
        '   End If

        'Wykomentowano dla Edax
        'If myApp.GUIState = Radraft.Interop.RadGUIState.rad3D Or myApp.GUIState = Radraft.Interop.RadGUIState.radPart Then
        'myApp.PluginManager.AddMenu("", "Eksportuj do DXFa")
        ' myApp.PluginManager.AddMenuItem("Eksportuj do DXFa", "Eksportuj do DXFa", "ExportDXF")
        ' End If
        'Koniec Edax

        'Obsługa komunikatu przypominającego o zarezerwowaniu Arkuszy
        '  If myMac.prj_is_open() = False And flaga = False And pierwszeUruchomienia = False Then
        ' MsgBox("Zapomniałeś o rezerwacji arkuszy. Czy chcesz zarezerwować arkusze? (W przygotowaniu)")
        '  flaga = False
        '    End If

    End Sub

    Public Sub ImportujBlachy()
        'Wyswietl nowe okno ImportBlach

        Dim frm As New ImportBlach
        Try
            frm.Show()
        Catch ex As Exception
            MsgBox("Błąd podczas otwarcia okna ImportujBlachy")
        End Try
    End Sub

    Public Sub ZamiennaDXF()
        'Wyswietl nowe okno ImportBlach
        Dim frm As New ZamienNaDXF
        Try
            frm.Show()
        Catch ex As Exception
            MsgBox("Błąd podczas otwarcia okna ImportujBlachy")
        End Try

    End Sub

    Public Sub ExportDXF()
        'Wyswietl nowe okno ImportBlach
        Dim frm As New ExportDXF
        Try
            frm.Show()
        Catch ex As Exception
            MsgBox("Błąd podczas otwarcia okna ImportujBlachy")
        End Try
    End Sub

    Private Sub Uruchom_Przyjecie_Wielu_Pozycji()

        'Wyswietl nowe okno Przyjecie_wielu_pozycji
        SciezkaProjektu = myMac.prj_get_file_path()

        Dim Przyjwielupoz As New Przyjecie_Wielu_Pozycji
        Try
            Przyjwielupoz.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Uruchom_Anulowanie_rezerwacji()
        'Wyswietl nowe okno ImportBlach

        Dim frm As New AnulowanieRezerwacjivb
        Try
            frm.Show()
        Catch ex As Exception
            MsgBox("Błąd podczas otwarcia okna do anulowania rezerwacji")
        End Try
    End Sub

    Private Sub Uruchom_Przyjecie_magazynowe()

        'Wyświetl okno Przyjęcie magazynowe.
        SciezkaProjektu = myMac.prj_get_file_path()

        Dim PrzyjMagazynowe As New PrzyjęcieMagazynowe
        Try
            PrzyjMagazynowe.Show()

        Catch ex As Exception
            MsgBox("Zyrtax Error")
        End Try

    End Sub

    Public Sub Uruchom_Rezerwacja_arkuszy()
        'Log do zapisywania działań z rezerwacji

        '  Dim okno As New FlowLog
        ' OknoRezerwacji = okno

        '  Try
        ' OknoRezerwacji.Show()
        ' Catch ex As Exception
        ' MsgBox("Błąd podczas otwarcia okna do rezerwacji")
        ' End Try

        'Wyzerowanie loga
        '  OknoRezerwacji.RichTextBox1.Text = ""
        'myMac.

        'Zapisz aktywny rysunek nestingu inaczej może przeoczyć ostanie zmiany w nenstingu
        Try
            myApp.ActiveDocument.Save()
        Catch ex As Exception

        End Try


        Try
            myMac.prj_save()                                  'Zapisz Projekt
            DoFlowLogaDoPliku("Zapisano projekt")
        Catch ex As Exception
            MsgBox("Przechwycono wyjątek: Błąd podczas zapisu pliku projektu")
            DoFlowLogaDoPliku("Nie zapisano projektu: " & ex.Message)
        End Try

        Dim Rezerwacja As New Rezerwacja                      'Nowa klasa rezerwacja

        'W inicjalizacje pobierane są dane z pliku projektu oraz plików .drg i bazy danych SQL
        Rezerwacja.Inicjalizacja()

        'Zmiania ilości dostępnych i zarezerwowanych w bazie danych 
        Rezerwacja.Rezerwacja()

        Rezerwacja.Dodaj_Nowe_Odpady_Do_Bazy()                'Przyjęcie magazynowe nowo utworzonych odpadów
        Rezerwacja.Finisz()                                   'Zwolnienie zasobów

    End Sub

    Private Sub Uruchom_Aktualizacja_nestingu()
        'Póki co nie używany
        MsgBox("Aktualizacja nesting")
    End Sub

    Private Sub Uruchom_Ustawienia_administracyjne()
        'Uruchom nową instancję formularza ustawienia_administracyjne
        Dim Ust_admin As New Ustawienia_administracyjne

        Try
            ' Ust_admin = Ustawienia_Administracyjne_1
            Ust_admin.wczytajUstawianieZPliku()
            Ust_admin.Show()
        Catch ex As Exception
            MsgBox("Nie można wyświetlić okna z Ustawieniami Administracyjnymi")
        End Try
        ' MsgBox("Ustawienia Administracyjne")
    End Sub

    Private Sub Uruchom_Informacje()

        Dim Info As New Informacje
        Try
            Info.Show()

        Catch ex As Exception
            MsgBox("Nie można otworzyć okna z Informacjami")
        End Try

    End Sub

    Private Sub Uruchom_FlowLog()

        Dim Flow As New FlowLog
        OknoFlowLoga = Flow
        Try
            Flow.Show()

        Catch ex As Exception
            MsgBox("Nie można otworzyć okna z FlowLog")
        End Try

        'Wyzerowanie loga
        OknoFlowLoga.RichTextBox1.Text = ""

        DoFlowLogaDoPliku("Data: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        DoFlowLogaDoPliku("Użytkownik: " & nazwaUzytkownika)

    End Sub

    Public Sub ZapiszProjekt()
        If myMac.prj_save() = False Then
            MsgBox("zapisz projekt i uruchom makro ponownie")
            Exit Sub
        End If
    End Sub


End Class





