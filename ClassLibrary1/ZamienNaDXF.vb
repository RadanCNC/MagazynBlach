Imports System.IO
Imports System.Xml

Public Class ZamienNaDXF
    ' Dim xmldoc As New XmlDataDocument()
    'Dim xmlnode As XmlNodeList

    'Dim PlikProjektu As New FileStream(SciezkaProjektu, FileMode.Open, FileAccess.Read)

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Zawsze na wierzchu
        Me.TopMost = True
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn.Click
        Dim SciezkaDoPliku As String = TxtNazwaPliku.Text

        Dim Material As String = ""
        Dim Grubosc As String = ""

        Using reader As New StreamReader(SciezkaDoPliku)
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
                    Material = line
                End If

                'Y = CDbl(Odczytaj_wartosc_atrybutu(line, 125))
                'Odczytaj atrybut numer 125 to jest wymiar Y
                If line.Contains("Attr num=" & Chr(34) & "120") Then
                    line = line.Substring(0, line.Length)
                    Dim Pozycja As Integer
                    Pozycja = InStr(line, "value=")
                    line = line.Substring(Pozycja + 6, line.Length - Pozycja - 6 - 2)
                    Grubosc = CDbl(line)
                End If

            End While
        End Using

        Dim Pozycja2 As Integer
        Dim str As String
        Pozycja2 = InStr(TxtNazwaPliku.Text, ".sym")
        str = TxtNazwaPliku.Text.Substring(0, Pozycja2 - 1)
        TxtRezult.Text = str & "#" & Material & "#" & Grubosc & ".dxf"
        myApp.OpenSymbol(SciezkaDoPliku, True, "")
        'myMac.fla_browse_for_file_to_save(True, "", "DXF Files (*.dxf)|*.dxf|IGES Files (*.igs)|*.igs;*.iges|All Files (*.*)|*.*||", SciezkaDoPliku)
        ' myApp.Application.ActiveDocument
        myApp.Application.ActiveDocument.SaveCopyAs(TxtRezult.Text, "DXF")
        myApp.Application.ActiveDocument.Close(True)




    End Sub

    Private Sub Button1_Click_Wszystkie(sender As Object, e As EventArgs) Handles BtnWszystkie.Click
        Dim i As Integer = 0
        MsgBox("Program działa 1")

        'Target Directory
        Dim directory As String = TxtDirectory.Text
        MsgBox(directory)

        ProcessDirectory(directory)
        'Searches directory and it's subdirectories for all files, which "*" stands for
        'Say for example you only want to search for jpeg files... then change "*" to "*.jpg"  
        'For Each filename As String In IO.Directory.GetFiles(directory, ".sym", IO.SearchOption.AllDirectories)
        'MsgBox("Program działa 2")
        'The next line of code gets only file extensions from searched directories and subdirectories
        'Dim fName As String = IO.Path.GetExtension(filename)

        '  MsgBox(Directory & filename)

        ' myApp.OpenSymbol(SciezkaDoPliku, True, "")
        'myMac.fla_browse_for_file_to_save(True, "", "DXF Files (*.dxf)|*.dxf|IGES Files (*.igs)|*.igs;*.iges|All Files (*.*)|*.*||", SciezkaDoPliku)
        ' myApp.Application.ActiveDocument
        ''  myApp.Application.ActiveDocument.SaveCopyAs(SciezkaDoPliku, "DXF")
        '  myApp.Application.ActiveDocument.Close(True)

        ' System.IO.File.Delete(directory & fName)

        'fName.
        'Your code here above count function
        'The below counter only displays the final count after all files have been processed

        'i = i + 1
        'TxtNazwaPliku.Text = Convert.ToString(i)

        '  Next
        ' MsgBox("Program działa 3")
    End Sub

    Public Shared Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ' Process the list of files found in the directory.
        Dim fileName As String
        For Each fileName In fileEntries
            '  MsgBox(fileName)
            myApp.OpenSymbol(fileName, True, "")
            myApp.Application.ActiveDocument.SaveCopyAs(fileName & "1", "DXF")
            myApp.Application.ActiveDocument.Close(True)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        ' Recurse into subdirectories of this directory.
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub 'ProcessDirectory


End Class