<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Przyjecie_Wielu_Pozycji
    Inherits System.Windows.Forms.Form

    'Formularz zastępuje metodę dispose, aby wyczyścić listę składników.
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

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: Następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Można to modyfikować, używając Projektanta formularzy systemu Windows.  
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Przyjecie_Wielu_Pozycji))
        Me.btnWczytajDoBazy = New System.Windows.Forms.Button()
        Me.DataGridViewArkusze = New System.Windows.Forms.DataGridView()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grubosc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IloscDostepne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IloscRezerwacja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IloscZuzyte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WymiarX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WymiarY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size_Units = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Sheet_Thickness_Units = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Klient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wytop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Atest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WZ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Powierzony = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Lokalizacja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArkuszeDataGridView2 = New System.Windows.Forms.DataGridView()
        Me.LblUstawieniaKoduKreskowego = New System.Windows.Forms.Label()
        Me.CBWymiar = New System.Windows.Forms.CheckBox()
        Me.CBGrubosc = New System.Windows.Forms.CheckBox()
        Me.CbMaterial = New System.Windows.Forms.CheckBox()
        Me.CBNumerMagazynowy = New System.Windows.Forms.CheckBox()
        Me.LblKatalogDoZapisuBarcodow = New System.Windows.Forms.Label()
        Me.TxtSciezkaBarcode = New System.Windows.Forms.TextBox()
        Me.CBZrobBarcody = New System.Windows.Forms.CheckBox()
        Me.Barcode1 = New BarcodeLib.Barcode.WinForms.QRCodeWinForm()
        Me.BtnOtworzPlik = New System.Windows.Forms.Button()
        CType(Me.DataGridViewArkusze, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArkuszeDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnWczytajDoBazy
        '
        Me.btnWczytajDoBazy.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnWczytajDoBazy.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.btnWczytajDoBazy.Location = New System.Drawing.Point(742, 548)
        Me.btnWczytajDoBazy.Name = "btnWczytajDoBazy"
        Me.btnWczytajDoBazy.Size = New System.Drawing.Size(255, 60)
        Me.btnWczytajDoBazy.TabIndex = 10
        Me.btnWczytajDoBazy.Text = "Wczytaj do bazy"
        Me.btnWczytajDoBazy.UseVisualStyleBackColor = False
        '
        'DataGridViewArkusze
        '
        Me.DataGridViewArkusze.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridViewArkusze.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridViewArkusze.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewArkusze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewArkusze.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material, Me.Grubosc, Me.IloscDostepne, Me.IloscRezerwacja, Me.IloscZuzyte, Me.WymiarX, Me.WymiarY, Me.Size_Units, Me.Sheet_Thickness_Units, Me.Status, Me.Klient, Me.Wytop, Me.Atest, Me.WZ, Me.Powierzony, Me.Lokalizacja})
        Me.DataGridViewArkusze.Cursor = System.Windows.Forms.Cursors.IBeam
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewArkusze.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewArkusze.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridViewArkusze.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewArkusze.Name = "DataGridViewArkusze"
        Me.DataGridViewArkusze.Size = New System.Drawing.Size(1156, 528)
        Me.DataGridViewArkusze.TabIndex = 9
        '
        'Material
        '
        Me.Material.DataPropertyName = "Material"
        Me.Material.HeaderText = "Material"
        Me.Material.Name = "Material"
        Me.Material.Width = 69
        '
        'Grubosc
        '
        Me.Grubosc.HeaderText = "Grubosc"
        Me.Grubosc.Name = "Grubosc"
        Me.Grubosc.Width = 72
        '
        'IloscDostepne
        '
        Me.IloscDostepne.HeaderText = "IloscDostepne"
        Me.IloscDostepne.Name = "IloscDostepne"
        '
        'IloscRezerwacja
        '
        Me.IloscRezerwacja.HeaderText = "IloscRezerwacja"
        Me.IloscRezerwacja.Name = "IloscRezerwacja"
        Me.IloscRezerwacja.ReadOnly = True
        Me.IloscRezerwacja.Visible = False
        '
        'IloscZuzyte
        '
        Me.IloscZuzyte.HeaderText = "IloscZuzyte"
        Me.IloscZuzyte.Name = "IloscZuzyte"
        Me.IloscZuzyte.ReadOnly = True
        Me.IloscZuzyte.Visible = False
        '
        'WymiarX
        '
        Me.WymiarX.HeaderText = "X"
        Me.WymiarX.Name = "WymiarX"
        Me.WymiarX.Width = 39
        '
        'WymiarY
        '
        Me.WymiarY.HeaderText = "Y"
        Me.WymiarY.Name = "WymiarY"
        Me.WymiarY.Width = 39
        '
        'Size_Units
        '
        Me.Size_Units.HeaderText = "Size_Units"
        Me.Size_Units.Items.AddRange(New Object() {"mm", "cal"})
        Me.Size_Units.Name = "Size_Units"
        Me.Size_Units.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Size_Units.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Size_Units.Width = 82
        '
        'Sheet_Thickness_Units
        '
        Me.Sheet_Thickness_Units.HeaderText = "Sheet_Thickness_Units"
        Me.Sheet_Thickness_Units.Items.AddRange(New Object() {"mm", "cal"})
        Me.Sheet_Thickness_Units.Name = "Sheet_Thickness_Units"
        Me.Sheet_Thickness_Units.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Sheet_Thickness_Units.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Sheet_Thickness_Units.Width = 145
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 62
        '
        'Klient
        '
        Me.Klient.HeaderText = "Klient"
        Me.Klient.Name = "Klient"
        Me.Klient.Width = 58
        '
        'Wytop
        '
        Me.Wytop.HeaderText = "Wytop"
        Me.Wytop.Name = "Wytop"
        Me.Wytop.Width = 63
        '
        'Atest
        '
        Me.Atest.HeaderText = "Atest"
        Me.Atest.Name = "Atest"
        Me.Atest.Width = 56
        '
        'WZ
        '
        Me.WZ.HeaderText = "WZ"
        Me.WZ.Name = "WZ"
        Me.WZ.Width = 50
        '
        'Powierzony
        '
        Me.Powierzony.FalseValue = "0"
        Me.Powierzony.HeaderText = "Powierzony"
        Me.Powierzony.Name = "Powierzony"
        Me.Powierzony.TrueValue = "1"
        Me.Powierzony.Width = 67
        '
        'Lokalizacja
        '
        Me.Lokalizacja.HeaderText = "Lokalizacja"
        Me.Lokalizacja.Name = "Lokalizacja"
        Me.Lokalizacja.Width = 85
        '
        'ArkuszeDataGridView2
        '
        Me.ArkuszeDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ArkuszeDataGridView2.Location = New System.Drawing.Point(0, 548)
        Me.ArkuszeDataGridView2.Name = "ArkuszeDataGridView2"
        Me.ArkuszeDataGridView2.Size = New System.Drawing.Size(83, 69)
        Me.ArkuszeDataGridView2.TabIndex = 11
        '
        'LblUstawieniaKoduKreskowego
        '
        Me.LblUstawieniaKoduKreskowego.AutoSize = True
        Me.LblUstawieniaKoduKreskowego.BackColor = System.Drawing.Color.Transparent
        Me.LblUstawieniaKoduKreskowego.Enabled = False
        Me.LblUstawieniaKoduKreskowego.Location = New System.Drawing.Point(320, 542)
        Me.LblUstawieniaKoduKreskowego.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUstawieniaKoduKreskowego.Name = "LblUstawieniaKoduKreskowego"
        Me.LblUstawieniaKoduKreskowego.Size = New System.Drawing.Size(147, 13)
        Me.LblUstawieniaKoduKreskowego.TabIndex = 60
        Me.LblUstawieniaKoduKreskowego.Text = "Ustawienia kodu kreskowego"
        Me.LblUstawieniaKoduKreskowego.Visible = False
        '
        'CBWymiar
        '
        Me.CBWymiar.AutoSize = True
        Me.CBWymiar.BackColor = System.Drawing.Color.Transparent
        Me.CBWymiar.Enabled = False
        Me.CBWymiar.Location = New System.Drawing.Point(548, 581)
        Me.CBWymiar.Margin = New System.Windows.Forms.Padding(2)
        Me.CBWymiar.Name = "CBWymiar"
        Me.CBWymiar.Size = New System.Drawing.Size(61, 17)
        Me.CBWymiar.TabIndex = 59
        Me.CBWymiar.Text = "Wymiar"
        Me.CBWymiar.UseVisualStyleBackColor = False
        Me.CBWymiar.Visible = False
        '
        'CBGrubosc
        '
        Me.CBGrubosc.AutoSize = True
        Me.CBGrubosc.BackColor = System.Drawing.Color.Transparent
        Me.CBGrubosc.Enabled = False
        Me.CBGrubosc.Location = New System.Drawing.Point(481, 581)
        Me.CBGrubosc.Margin = New System.Windows.Forms.Padding(2)
        Me.CBGrubosc.Name = "CBGrubosc"
        Me.CBGrubosc.Size = New System.Drawing.Size(66, 17)
        Me.CBGrubosc.TabIndex = 58
        Me.CBGrubosc.Text = "Grubość"
        Me.CBGrubosc.UseVisualStyleBackColor = False
        Me.CBGrubosc.Visible = False
        '
        'CbMaterial
        '
        Me.CbMaterial.AutoSize = True
        Me.CbMaterial.BackColor = System.Drawing.Color.Transparent
        Me.CbMaterial.Enabled = False
        Me.CbMaterial.Location = New System.Drawing.Point(416, 581)
        Me.CbMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.CbMaterial.Name = "CbMaterial"
        Me.CbMaterial.Size = New System.Drawing.Size(65, 17)
        Me.CbMaterial.TabIndex = 57
        Me.CbMaterial.Text = "Materiał"
        Me.CbMaterial.UseVisualStyleBackColor = False
        Me.CbMaterial.Visible = False
        '
        'CBNumerMagazynowy
        '
        Me.CBNumerMagazynowy.AutoSize = True
        Me.CBNumerMagazynowy.BackColor = System.Drawing.Color.Transparent
        Me.CBNumerMagazynowy.Enabled = False
        Me.CBNumerMagazynowy.Location = New System.Drawing.Point(320, 581)
        Me.CBNumerMagazynowy.Margin = New System.Windows.Forms.Padding(2)
        Me.CBNumerMagazynowy.Name = "CBNumerMagazynowy"
        Me.CBNumerMagazynowy.Size = New System.Drawing.Size(102, 17)
        Me.CBNumerMagazynowy.TabIndex = 56
        Me.CBNumerMagazynowy.Text = "Nr Magazynowy"
        Me.CBNumerMagazynowy.UseVisualStyleBackColor = False
        Me.CBNumerMagazynowy.Visible = False
        '
        'LblKatalogDoZapisuBarcodow
        '
        Me.LblKatalogDoZapisuBarcodow.AutoSize = True
        Me.LblKatalogDoZapisuBarcodow.BackColor = System.Drawing.Color.Transparent
        Me.LblKatalogDoZapisuBarcodow.Enabled = False
        Me.LblKatalogDoZapisuBarcodow.Location = New System.Drawing.Point(320, 626)
        Me.LblKatalogDoZapisuBarcodow.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblKatalogDoZapisuBarcodow.Name = "LblKatalogDoZapisuBarcodow"
        Me.LblKatalogDoZapisuBarcodow.Size = New System.Drawing.Size(142, 13)
        Me.LblKatalogDoZapisuBarcodow.TabIndex = 55
        Me.LblKatalogDoZapisuBarcodow.Text = "Katalog do zapisu Barcodów"
        Me.LblKatalogDoZapisuBarcodow.Visible = False
        '
        'TxtSciezkaBarcode
        '
        Me.TxtSciezkaBarcode.Enabled = False
        Me.TxtSciezkaBarcode.Location = New System.Drawing.Point(481, 624)
        Me.TxtSciezkaBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSciezkaBarcode.Name = "TxtSciezkaBarcode"
        Me.TxtSciezkaBarcode.Size = New System.Drawing.Size(213, 20)
        Me.TxtSciezkaBarcode.TabIndex = 54
        Me.TxtSciezkaBarcode.Text = "C:\Barcode"
        Me.TxtSciezkaBarcode.Visible = False
        '
        'CBZrobBarcody
        '
        Me.CBZrobBarcody.AutoSize = True
        Me.CBZrobBarcody.BackColor = System.Drawing.Color.Transparent
        Me.CBZrobBarcody.Enabled = False
        Me.CBZrobBarcody.Location = New System.Drawing.Point(481, 542)
        Me.CBZrobBarcody.Margin = New System.Windows.Forms.Padding(2)
        Me.CBZrobBarcody.Name = "CBZrobBarcody"
        Me.CBZrobBarcody.Size = New System.Drawing.Size(112, 17)
        Me.CBZrobBarcody.TabIndex = 61
        Me.CBZrobBarcody.Text = "Wł/Wył. Barcode"
        Me.CBZrobBarcody.UseVisualStyleBackColor = False
        Me.CBZrobBarcody.Visible = False
        '
        'Barcode1
        '
        Me.Barcode1.BackgroundColor = System.Drawing.Color.White
        Me.Barcode1.BottomMargin = 0!
        Me.Barcode1.Data = "QR Code"
        Me.Barcode1.ECI = -1
        Me.Barcode1.ECL = BarcodeLib.Barcode.QRCodeErrorCorrectionLevel.L
        Me.Barcode1.Enabled = False
        Me.Barcode1.EnableStructuredAppend = False
        Me.Barcode1.Encoding = BarcodeLib.Barcode.QRCodeEncoding.[Auto]
        Me.Barcode1.FNC1Mode = BarcodeLib.Barcode.QRCodeFNC1Mode.NotSupported
        Me.Barcode1.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
        Me.Barcode1.ImageHeight = 0!
        Me.Barcode1.ImageWidth = 0!
        Me.Barcode1.LeftMargin = 0!
        Me.Barcode1.Location = New System.Drawing.Point(616, 542)
        Me.Barcode1.Margin = New System.Windows.Forms.Padding(2)
        Me.Barcode1.ModuleColor = System.Drawing.Color.Black
        Me.Barcode1.ModuleSize = 2.0!
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.ProcessTilde = True
        Me.Barcode1.ResizeImage = False
        Me.Barcode1.Resolution = 72
        Me.Barcode1.RightMargin = 0!
        Me.Barcode1.Rotate = BarcodeLib.Barcode.RotateOrientation.BottomFacingDown
        Me.Barcode1.Size = New System.Drawing.Size(42, 42)
        Me.Barcode1.StructuredAppendCount = 0
        Me.Barcode1.StructuredAppendIndex = 0
        Me.Barcode1.TabIndex = 62
        Me.Barcode1.TopMargin = 0!
        Me.Barcode1.UOM = BarcodeLib.Barcode.UnitOfMeasure.PIXEL
        Me.Barcode1.Version = BarcodeLib.Barcode.QRCodeVersion.V1
        Me.Barcode1.Visible = False
        '
        'BtnOtworzPlik
        '
        Me.BtnOtworzPlik.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnOtworzPlik.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnOtworzPlik.Enabled = False
        Me.BtnOtworzPlik.Location = New System.Drawing.Point(698, 623)
        Me.BtnOtworzPlik.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOtworzPlik.Name = "BtnOtworzPlik"
        Me.BtnOtworzPlik.Size = New System.Drawing.Size(24, 19)
        Me.BtnOtworzPlik.TabIndex = 74
        Me.BtnOtworzPlik.Text = "..."
        Me.BtnOtworzPlik.UseVisualStyleBackColor = False
        Me.BtnOtworzPlik.Visible = False
        '
        'Przyjecie_Wielu_Pozycji
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LimeGreen
        Me.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1156, 657)
        Me.Controls.Add(Me.BtnOtworzPlik)
        Me.Controls.Add(Me.Barcode1)
        Me.Controls.Add(Me.CBZrobBarcody)
        Me.Controls.Add(Me.LblUstawieniaKoduKreskowego)
        Me.Controls.Add(Me.CBWymiar)
        Me.Controls.Add(Me.CBGrubosc)
        Me.Controls.Add(Me.CbMaterial)
        Me.Controls.Add(Me.CBNumerMagazynowy)
        Me.Controls.Add(Me.LblKatalogDoZapisuBarcodow)
        Me.Controls.Add(Me.TxtSciezkaBarcode)
        Me.Controls.Add(Me.ArkuszeDataGridView2)
        Me.Controls.Add(Me.btnWczytajDoBazy)
        Me.Controls.Add(Me.DataGridViewArkusze)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Przyjecie_Wielu_Pozycji"
        Me.Text = "Przyjęcie Wielu Pozycji"
        CType(Me.DataGridViewArkusze, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArkuszeDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewArkusze As System.Windows.Forms.DataGridView
    Friend WithEvents btnWczytajDoBazy As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArkuszeDataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Material As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grubosc As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IloscDostepne As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IloscRezerwacja As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IloscZuzyte As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WymiarX As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WymiarY As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size_Units As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Sheet_Thickness_Units As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Status As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Klient As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wytop As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Atest As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WZ As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Powierzony As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Lokalizacja As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblUstawieniaKoduKreskowego As Windows.Forms.Label
    Friend WithEvents CBWymiar As Windows.Forms.CheckBox
    Friend WithEvents CBGrubosc As Windows.Forms.CheckBox
    Friend WithEvents CbMaterial As Windows.Forms.CheckBox
    Friend WithEvents CBNumerMagazynowy As Windows.Forms.CheckBox
    Friend WithEvents LblKatalogDoZapisuBarcodow As Windows.Forms.Label
    Friend WithEvents TxtSciezkaBarcode As Windows.Forms.TextBox
    Friend WithEvents CBZrobBarcody As Windows.Forms.CheckBox
    Friend WithEvents Barcode1 As BarcodeLib.Barcode.WinForms.QRCodeWinForm
    Friend WithEvents BtnOtworzPlik As Windows.Forms.Button
End Class
