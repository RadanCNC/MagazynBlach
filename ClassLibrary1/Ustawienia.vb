Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml


Public Class Ustawienia
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

            'Jeżeli plik Ustawienia.xml nie istnieje to
        Else
            MsgBox("Nie znaleziono pliku Ustawien, Wpisz dane do połączenia z bazą")

            Dim Ustawienia_Administracyjne As New Ustawienia_administracyjne
            Ustawienia_Administracyjne.Show()                                   'Pokaż Ustawienia Admin.
        End If

    End Sub
End Class
