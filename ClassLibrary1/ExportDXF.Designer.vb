<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportDXF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnZbierzInfo = New System.Windows.Forms.Button()
        Me.TxTKatalog = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBNazwa = New System.Windows.Forms.CheckBox()
        Me.CBMaterial = New System.Windows.Forms.CheckBox()
        Me.CbGrubosc = New System.Windows.Forms.CheckBox()
        Me.CBIlosc = New System.Windows.Forms.CheckBox()
        Me.BtnZrobRozwiniecia = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.BtnZmienNazwy = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnWybierz = New System.Windows.Forms.Button()
        Me.TxtPodglad = New System.Windows.Forms.TextBox()
        Me.LblPodglad = New System.Windows.Forms.Label()
        Me.TxtNazwa = New System.Windows.Forms.TextBox()
        Me.BtnPodglad = New System.Windows.Forms.Button()
        Me.TxtMaterial = New System.Windows.Forms.TextBox()
        Me.TxtGrubosc = New System.Windows.Forms.TextBox()
        Me.TxtIlosc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtWlasnyText = New System.Windows.Forms.TextBox()
        Me.CBWlasnyTekst = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.CBAdmin = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnZbierzInfo
        '
        Me.BtnZbierzInfo.Location = New System.Drawing.Point(12, 390)
        Me.BtnZbierzInfo.Name = "BtnZbierzInfo"
        Me.BtnZbierzInfo.Size = New System.Drawing.Size(174, 143)
        Me.BtnZbierzInfo.TabIndex = 1
        Me.BtnZbierzInfo.Text = "Zbierz Informacje"
        Me.BtnZbierzInfo.UseVisualStyleBackColor = True
        Me.BtnZbierzInfo.Visible = False
        '
        'TxTKatalog
        '
        Me.TxTKatalog.Location = New System.Drawing.Point(31, 54)
        Me.TxTKatalog.Name = "TxTKatalog"
        Me.TxTKatalog.Size = New System.Drawing.Size(325, 22)
        Me.TxTKatalog.TabIndex = 2
        Me.TxTKatalog.Text = "D:\"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Katalog Docelowy"
        '
        'CBNazwa
        '
        Me.CBNazwa.AutoSize = True
        Me.CBNazwa.Checked = True
        Me.CBNazwa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBNazwa.Location = New System.Drawing.Point(33, 171)
        Me.CBNazwa.Name = "CBNazwa"
        Me.CBNazwa.Size = New System.Drawing.Size(72, 21)
        Me.CBNazwa.TabIndex = 4
        Me.CBNazwa.Text = "Nazwa"
        Me.CBNazwa.UseVisualStyleBackColor = True
        '
        'CBMaterial
        '
        Me.CBMaterial.AutoSize = True
        Me.CBMaterial.Checked = True
        Me.CBMaterial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBMaterial.Location = New System.Drawing.Point(33, 213)
        Me.CBMaterial.Name = "CBMaterial"
        Me.CBMaterial.Size = New System.Drawing.Size(80, 21)
        Me.CBMaterial.TabIndex = 5
        Me.CBMaterial.Text = "Materiał"
        Me.CBMaterial.UseVisualStyleBackColor = True
        '
        'CbGrubosc
        '
        Me.CbGrubosc.AutoSize = True
        Me.CbGrubosc.Checked = True
        Me.CbGrubosc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbGrubosc.Location = New System.Drawing.Point(33, 252)
        Me.CbGrubosc.Name = "CbGrubosc"
        Me.CbGrubosc.Size = New System.Drawing.Size(84, 21)
        Me.CbGrubosc.TabIndex = 6
        Me.CbGrubosc.Text = "Grubość"
        Me.CbGrubosc.UseVisualStyleBackColor = True
        '
        'CBIlosc
        '
        Me.CBIlosc.AutoSize = True
        Me.CBIlosc.Checked = True
        Me.CBIlosc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBIlosc.Location = New System.Drawing.Point(33, 290)
        Me.CBIlosc.Name = "CBIlosc"
        Me.CBIlosc.Size = New System.Drawing.Size(58, 21)
        Me.CBIlosc.TabIndex = 7
        Me.CBIlosc.Text = "Ilość"
        Me.CBIlosc.UseVisualStyleBackColor = True
        '
        'BtnZrobRozwiniecia
        '
        Me.BtnZrobRozwiniecia.Location = New System.Drawing.Point(9, 595)
        Me.BtnZrobRozwiniecia.Name = "BtnZrobRozwiniecia"
        Me.BtnZrobRozwiniecia.Size = New System.Drawing.Size(174, 37)
        Me.BtnZrobRozwiniecia.TabIndex = 8
        Me.BtnZrobRozwiniecia.Text = "Zrób Rozwinięcia"
        Me.BtnZrobRozwiniecia.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(9, 648)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(413, 198)
        Me.RichTextBox1.TabIndex = 9
        Me.RichTextBox1.Text = ""
        '
        'BtnZmienNazwy
        '
        Me.BtnZmienNazwy.Location = New System.Drawing.Point(300, 390)
        Me.BtnZmienNazwy.Name = "BtnZmienNazwy"
        Me.BtnZmienNazwy.Size = New System.Drawing.Size(174, 143)
        Me.BtnZmienNazwy.TabIndex = 10
        Me.BtnZmienNazwy.Text = "Zmien nazwy Plików w katalogu"
        Me.BtnZmienNazwy.UseVisualStyleBackColor = True
        '
        'BtnWybierz
        '
        Me.BtnWybierz.Location = New System.Drawing.Point(399, 53)
        Me.BtnWybierz.Name = "BtnWybierz"
        Me.BtnWybierz.Size = New System.Drawing.Size(75, 23)
        Me.BtnWybierz.TabIndex = 11
        Me.BtnWybierz.Text = "Wybierz"
        Me.BtnWybierz.UseVisualStyleBackColor = True
        '
        'TxtPodglad
        '
        Me.TxtPodglad.Location = New System.Drawing.Point(124, 893)
        Me.TxtPodglad.Name = "TxtPodglad"
        Me.TxtPodglad.Size = New System.Drawing.Size(256, 22)
        Me.TxtPodglad.TabIndex = 13
        '
        'LblPodglad
        '
        Me.LblPodglad.AutoSize = True
        Me.LblPodglad.Location = New System.Drawing.Point(12, 860)
        Me.LblPodglad.Name = "LblPodglad"
        Me.LblPodglad.Size = New System.Drawing.Size(426, 17)
        Me.LblPodglad.TabIndex = 14
        Me.LblPodglad.Text = "Podgląd nazwy części: Part1 o grubości 1 mm Aluminium i ilości 23"
        '
        'TxtNazwa
        '
        Me.TxtNazwa.Location = New System.Drawing.Point(160, 171)
        Me.TxtNazwa.Name = "TxtNazwa"
        Me.TxtNazwa.Size = New System.Drawing.Size(100, 22)
        Me.TxtNazwa.TabIndex = 15
        '
        'BtnPodglad
        '
        Me.BtnPodglad.Location = New System.Drawing.Point(12, 892)
        Me.BtnPodglad.Name = "BtnPodglad"
        Me.BtnPodglad.Size = New System.Drawing.Size(75, 23)
        Me.BtnPodglad.TabIndex = 20
        Me.BtnPodglad.Text = "Podgląd"
        Me.BtnPodglad.UseVisualStyleBackColor = True
        '
        'TxtMaterial
        '
        Me.TxtMaterial.Location = New System.Drawing.Point(160, 213)
        Me.TxtMaterial.Name = "TxtMaterial"
        Me.TxtMaterial.Size = New System.Drawing.Size(100, 22)
        Me.TxtMaterial.TabIndex = 24
        Me.TxtMaterial.Text = "_"
        '
        'TxtGrubosc
        '
        Me.TxtGrubosc.Location = New System.Drawing.Point(160, 252)
        Me.TxtGrubosc.Name = "TxtGrubosc"
        Me.TxtGrubosc.Size = New System.Drawing.Size(100, 22)
        Me.TxtGrubosc.TabIndex = 25
        Me.TxtGrubosc.Text = "_"
        '
        'TxtIlosc
        '
        Me.TxtIlosc.Location = New System.Drawing.Point(160, 290)
        Me.TxtIlosc.Name = "TxtIlosc"
        Me.TxtIlosc.Size = New System.Drawing.Size(100, 22)
        Me.TxtIlosc.TabIndex = 26
        Me.TxtIlosc.Text = "mm_"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Prefix"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Nazwa", "Materiał", "Grubość", "Ilość", "Własny Tekst", " "})
        Me.ComboBox1.Location = New System.Drawing.Point(353, 176)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 28
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Nazwa", "Materiał", "Grubość", "Ilość", "Własny Tekst", " "})
        Me.ComboBox2.Location = New System.Drawing.Point(353, 218)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox2.TabIndex = 29
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Nazwa", "Materiał", "Grubość", "Ilość", "Własny Tekst", " "})
        Me.ComboBox3.Location = New System.Drawing.Point(353, 257)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox3.TabIndex = 30
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Nazwa", "Materiał", "Grubość", "Ilość", "Własny Tekst", " "})
        Me.ComboBox4.Location = New System.Drawing.Point(353, 297)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox4.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(331, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(331, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 17)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(331, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "4"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(331, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 17)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(353, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 17)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Kolejność"
        '
        'TxtWlasnyText
        '
        Me.TxtWlasnyText.Location = New System.Drawing.Point(160, 330)
        Me.TxtWlasnyText.Name = "TxtWlasnyText"
        Me.TxtWlasnyText.Size = New System.Drawing.Size(100, 22)
        Me.TxtWlasnyText.TabIndex = 38
        Me.TxtWlasnyText.Text = "qt"
        '
        'CBWlasnyTekst
        '
        Me.CBWlasnyTekst.AutoSize = True
        Me.CBWlasnyTekst.Checked = True
        Me.CBWlasnyTekst.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBWlasnyTekst.Location = New System.Drawing.Point(33, 330)
        Me.CBWlasnyTekst.Name = "CBWlasnyTekst"
        Me.CBWlasnyTekst.Size = New System.Drawing.Size(115, 21)
        Me.CBWlasnyTekst.TabIndex = 37
        Me.CBWlasnyTekst.Text = "Własny Tekst"
        Me.CBWlasnyTekst.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 332)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 17)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "5"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"Nazwa", "Materiał", "Grubość", "Ilość", "Własny Tekst", " "})
        Me.ComboBox5.Location = New System.Drawing.Point(353, 330)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox5.TabIndex = 39
        '
        'CBAdmin
        '
        Me.CBAdmin.AutoSize = True
        Me.CBAdmin.Location = New System.Drawing.Point(15, 559)
        Me.CBAdmin.Name = "CBAdmin"
        Me.CBAdmin.Size = New System.Drawing.Size(69, 21)
        Me.CBAdmin.TabIndex = 41
        Me.CBAdmin.Text = "Admin"
        Me.CBAdmin.UseVisualStyleBackColor = True
        '
        'ExportDXF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 943)
        Me.Controls.Add(Me.CBAdmin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.TxtWlasnyText)
        Me.Controls.Add(Me.CBWlasnyTekst)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtIlosc)
        Me.Controls.Add(Me.TxtGrubosc)
        Me.Controls.Add(Me.TxtMaterial)
        Me.Controls.Add(Me.BtnPodglad)
        Me.Controls.Add(Me.TxtNazwa)
        Me.Controls.Add(Me.LblPodglad)
        Me.Controls.Add(Me.TxtPodglad)
        Me.Controls.Add(Me.BtnWybierz)
        Me.Controls.Add(Me.BtnZmienNazwy)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnZrobRozwiniecia)
        Me.Controls.Add(Me.CBIlosc)
        Me.Controls.Add(Me.CbGrubosc)
        Me.Controls.Add(Me.CBMaterial)
        Me.Controls.Add(Me.CBNazwa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxTKatalog)
        Me.Controls.Add(Me.BtnZbierzInfo)
        Me.Name = "ExportDXF"
        Me.Text = "ExportDXF"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnZbierzInfo As Windows.Forms.Button
    Friend WithEvents TxTKatalog As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents CBNazwa As Windows.Forms.CheckBox
    Friend WithEvents CBMaterial As Windows.Forms.CheckBox
    Friend WithEvents CbGrubosc As Windows.Forms.CheckBox
    Friend WithEvents CBIlosc As Windows.Forms.CheckBox
    Friend WithEvents BtnZrobRozwiniecia As Windows.Forms.Button
    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents BtnZmienNazwy As Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnWybierz As Windows.Forms.Button
    Friend WithEvents TxtPodglad As Windows.Forms.TextBox
    Friend WithEvents LblPodglad As Windows.Forms.Label
    Friend WithEvents TxtNazwa As Windows.Forms.TextBox
    Friend WithEvents BtnPodglad As Windows.Forms.Button
    Friend WithEvents TxtMaterial As Windows.Forms.TextBox
    Friend WithEvents TxtGrubosc As Windows.Forms.TextBox
    Friend WithEvents TxtIlosc As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents TxtWlasnyText As Windows.Forms.TextBox
    Friend WithEvents CBWlasnyTekst As Windows.Forms.CheckBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents ComboBox5 As Windows.Forms.ComboBox
    Friend WithEvents CBAdmin As Windows.Forms.CheckBox
End Class
