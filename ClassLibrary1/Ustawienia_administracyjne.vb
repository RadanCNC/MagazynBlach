Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System

Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Windows.Forms

Public Class Ustawienia_administracyjne

    Public Sub WczytajUstawienia(ByVal serwer As String, ByVal FolderOdpadow As String, ByVal baza As String,
               ByVal login As String, ByVal haslo As String)

        TxtSerwer.Text = serwer
        TxtOdpadyDoUzycia.Text = FolderOdpadow
        TxtBaza.Text = baza
        TxtLogin.Text = login
        TxtHaslo.Text = CryptoZ.Decrypt(haslo, "my key")
    End Sub




    Private Sub BtnZmienBaze_Click(sender As Object, e As EventArgs) Handles BtnZmienBaze.Click

        Try

            Dim polaczenie As String
            If CBWindowsAuthentications.Checked = False Then
                polaczenie = "Server=" & TxtSerwer.Text & "; Database=" & TxtBaza.Text &
                                         "; User=" & TxtLogin.Text & ";Pwd=" & TxtHaslo.Text
            Else
                polaczenie = "Server=" & TxtSerwer.Text & "; Database=" & ";Integrated Security=SSPI"
            End If
            sql.SQLConect = New SqlConnection(polaczenie)
            If sql.HasConnection() = True Then
                MsgBox("Pomyslnie nawiązano połączenie z :" & polaczenie)
            Else
                MsgBox("Błąd przy połączeniu z bazą")
            End If

        Catch ex As Exception
            MsgBox("Błąd podczas połączenia")
        End Try


    End Sub

    Public Sub BtnZapiszUStawienia_click(sender As Object, e As EventArgs) Handles BtnZapiszUStawienia.Click


        Dim writer As New XmlTextWriter("C:\Ustawienia.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("Ustawienia")
        Dim integrated As String
        integrated = CStr(CBWindowsAuthentications.Checked)
        createNode(TxtSerwer.Text, TxtBaza.Text, TxtLogin.Text, CryptoZ.Encrypt(TxtHaslo.Text, "my key"), integrated, writer, TxtOdpadyDoUzycia.Text, TxtSciezkaDoLoga.Text & "\FlowLog.log")

        'createNode(TxtSerwer.Text, TxtBaza.Text, TxtLogin.Text, CryptoZ.Encrypt(TxtHaslo.Text, "my key"), True, writer)

        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()

        MsgBox("Zapisano ustawienia do pliku: " & "C:\Ustawienia.xml")
        ' Integrated Security=SSPI"

    End Sub

    Private Sub createNode(ByVal XMLSerwer As String, ByVal XMLBaza As String, ByVal XMLLogin As String,
                         ByVal XMLHaslo As String, ByVal WindowsAuthenticationBool As String, ByVal writer As XmlTextWriter, ByVal folderodpadow As String, ByVal SciezkaDoLoga As String)
        writer.WriteStartElement("Serwer")
        writer.WriteString(XMLSerwer)
        writer.WriteEndElement()
        writer.WriteStartElement("BazaDanych")
        writer.WriteString(XMLBaza)
        writer.WriteEndElement()
        writer.WriteStartElement("Login")
        writer.WriteString(XMLLogin)
        writer.WriteEndElement()
        writer.WriteStartElement("Haslo")
        writer.WriteString(XMLHaslo)
        writer.WriteEndElement()
        writer.WriteStartElement("IntegratedSecurity")
        writer.WriteString(WindowsAuthenticationBool)
        writer.WriteEndElement()
        writer.WriteStartElement("FolderOdpadow")
        writer.WriteString(folderodpadow)
        writer.WriteEndElement()
        writer.WriteStartElement("SciezkaDoLoga")
        writer.WriteString(SciezkaDoLoga)
        writer.WriteEndElement()
        ' 
    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub

    Private Sub CheckBoxWindowsAuthentications_CheckedChanged(sender As Object, e As EventArgs) Handles CBWindowsAuthentications.CheckedChanged
        If CBWindowsAuthentications.Checked = True Then
            TxtLogin.Enabled = False
            TxtHaslo.Enabled = False

        Else
            TxtLogin.Enabled = True
            TxtHaslo.Enabled = True
        End If
    End Sub

    Private Sub BtnOtworzPlik_Click(sender As Object, e As EventArgs) Handles BtnOtworzPlik.Click
        Dim myStream As Stream = Nothing
        Dim folderbrowser As New FolderBrowserDialog()

        If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            TxtSciezkaDoLoga.Text = folderbrowser.SelectedPath

        End If

    End Sub

    Private Sub BtnNowyLog_Click(sender As Object, e As EventArgs) Handles BtnNowyLog.Click
        Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz stworzyć nowy plik log?",
                                                             "Nowe_Odpady", MessageBoxButtons.YesNo)

        'Jeżeli tak do zapisz odpad do bazy i jako przyjęcie magazynowe do loga
        If wynik = DialogResult.Yes Then

            File.Create(TxtSciezkaDoLoga.Text & "\FlowLog.log").Dispose()

            'Jeżeli nie to nie rób nic
            If wynik = DialogResult.No Then

                Exit Sub
            End If
        End If

    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Process.Start(SciezkaDoPlikuLog)
    End Sub

    Public Sub wczytajUstawianieZPliku()
        ' 
        Dim xmlFolderOdpadow As String = ""
        Dim XMLSerwer As String = "", XMLBaza As String = "", XMLLogin As String = ""
        Dim XMLHaslo As String = "", XMLSciezkaLoga As String = ""
        Dim XMLIntegratedSecurity As String = ""                                     'Windows Authentication
        Dim xmlDoc As New XmlDocument()
        Dim sciezka As String = "C:\" & "Ustawienia.xml"

        'Sprawdź czy plik istnieje
        If My.Computer.FileSystem.FileExists(sciezka) Then

            xmlDoc.Load(sciezka)                                                      'Załaduj plik

            'Odczytaj informacje z pliku z Tabeli Ustawienia
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Ustawienia")

            'Odczytaj dane z każdego znacznika <Serwer>, <BazaDanych> itp..
            For Each node As XmlNode In nodes
                XMLSerwer = node.SelectSingleNode("Serwer").InnerText
                XMLBaza = node.SelectSingleNode("BazaDanych").InnerText
                XMLLogin = node.SelectSingleNode("Login").InnerText
                XMLHaslo = node.SelectSingleNode("Haslo").InnerText
                XMLIntegratedSecurity = node.SelectSingleNode("IntegratedSecurity").InnerText
                xmlFolderOdpadow = node.SelectSingleNode("FolderOdpadow").InnerText
                XMLSciezkaLoga = node.SelectSingleNode("SciezkaDoLoga").InnerText
                ' MsgBox(XMLSerwer & " " & XMLBaza & " " & XMLLogin & " " & XMLHaslo)
            Next

            SciezkaDoPlikuLog = XMLSciezkaLoga

            Dim polaczenie As String
            Try
                If CBool(XMLIntegratedSecurity) = False Then

                    'Nawiąż połączenie z bazą danych z wczytanych ustawień
                    polaczenie = "Server=" & XMLSerwer & "; Database=" & XMLBaza &
                                 "; User=" & XMLLogin & ";Pwd=" & CryptoZ.Decrypt(XMLHaslo, "my key")
                Else
                    polaczenie = "Server=" & XMLSerwer & "; Database=" & XMLBaza &
                                 "; Integrated Security=SSPI"

                End If

                sql.SQLConect = New SqlConnection(polaczenie)
                If sql.HasConnection() = True Then
                    ' MsgBox("Pomyslnie nawiązano połączenie z :" & polaczenie)
                Else
                    MsgBox("Błąd przy połączeniu z bazą")
                    ' Ustawienia_Administracyjne.Show()
                End If

            Catch ex As Exception
                MsgBox("Błąd podczas połączenia")

            End Try


            'Pokaż ustawienia z pliku
            '    Ustawienia_administracyjne.

            TxtOdpadyDoUzycia.Text = xmlFolderOdpadow
            TxtSerwer.Text = XMLSerwer
            TxtBaza.Text = XMLBaza
            TxtLogin.Text = XMLLogin
            TxtHaslo.Text = CryptoZ.Decrypt(XMLHaslo, "my key")
            CBWindowsAuthentications.Checked = CBool(XMLIntegratedSecurity)
            TxtSciezkaDoLoga.Text = XMLSciezkaLoga.Remove(XMLSciezkaLoga.Count - 11, 11)

            '  Ustawienia_Administracyjne_1.

            'Jeżeli plik Ustawienia.xml nie istnieje to
        Else
            MsgBox("Nie znaleziono pliku Ustawien, Wpisz dane do połączenia z bazą")

            Dim Ustawienia_Administracyjne As New Ustawienia_administracyjne
            Ustawienia_Administracyjne.Show()                                   'Pokaż Ustawienia Admin.
        End If

    End Sub

    Private Sub BtnWyczyscBaze_Click(sender As Object, e As EventArgs) Handles BtnWyczyscBaze.Click
        Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz wyczyścić bazę?",
                                                             "Wyczyść Baze", MessageBoxButtons.YesNo)

        'Jeżeli tak do zapisz odpad do bazy i jako przyjęcie magazynowe do loga
        If wynik = DialogResult.Yes Then
            Dim zapytanie As String = "delete from Arkusze"
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

            zapytanie = "delete from Odpady"
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

            zapytanie = "delete from Log2"
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

            MsgBox("Wyczyszczono")
        Else
            MsgBox("Anulowano")
        End If

    End Sub

    Private Sub Ustawienia_administracyjne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub
End Class