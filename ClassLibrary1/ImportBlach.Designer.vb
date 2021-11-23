<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportBlach
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportBlach))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.BtnWczytajDane = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BtnWczytajDoRadana = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelProgressBar = New System.Windows.Forms.Label()
        Me.CBAdmin = New System.Windows.Forms.CheckBox()
        Me.BtnWczytajWybrane = New System.Windows.Forms.Button()
        Me.TxtWyszukaj = New System.Windows.Forms.TextBox()
        Me.BtnWyszukaj = New System.Windows.Forms.Button()
        Me.BtnPokazWszystko = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.BtnWczytajOdpad = New System.Windows.Forms.Button()
        Me.BtnWczytajWszystkieOdpady = New System.Windows.Forms.Button()
        Me.BtnGenerujKody = New System.Windows.Forms.Button()
        Me.CBZrobBarcody = New System.Windows.Forms.CheckBox()
        Me.LblUstawieniaKoduKreskowego = New System.Windows.Forms.Label()
        Me.CBWymiar = New System.Windows.Forms.CheckBox()
        Me.CBGrubosc = New System.Windows.Forms.CheckBox()
        Me.CbMaterial = New System.Windows.Forms.CheckBox()
        Me.CBNumerMagazynowy = New System.Windows.Forms.CheckBox()
        Me.LblKatalogDoZapisuBarcodow = New System.Windows.Forms.Label()
        Me.TxtSciezkaBarcode = New System.Windows.Forms.TextBox()
        Me.Barcode1 = New BarcodeLib.Barcode.WinForms.QRCodeWinForm()
        Me.BtnOtworzPlik = New System.Windows.Forms.Button()
        Me.CBKolorTla = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBOdpadyZatwierdzone = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(660, 758)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(218, 80)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = "Select * From Arkusze where iloscDostepne > 0"
        '
        'BtnWczytajDane
        '
        Me.BtnWczytajDane.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnWczytajDane.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWczytajDane.Enabled = False
        Me.BtnWczytajDane.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWczytajDane.Location = New System.Drawing.Point(1400, 666)
        Me.BtnWczytajDane.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWczytajDane.Name = "BtnWczytajDane"
        Me.BtnWczytajDane.Size = New System.Drawing.Size(112, 63)
        Me.BtnWczytajDane.TabIndex = 20
        Me.BtnWczytajDane.Text = "Wczytaj Zapytanie SQL"
        Me.BtnWczytajDane.UseVisualStyleBackColor = False
        Me.BtnWczytajDane.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(16, 81)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1496, 566)
        Me.DataGridView1.TabIndex = 19
        '
        'BtnWczytajDoRadana
        '
        Me.BtnWczytajDoRadana.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnWczytajDoRadana.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWczytajDoRadana.Location = New System.Drawing.Point(905, 666)
        Me.BtnWczytajDoRadana.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWczytajDoRadana.Name = "BtnWczytajDoRadana"
        Me.BtnWczytajDoRadana.Size = New System.Drawing.Size(112, 63)
        Me.BtnWczytajDoRadana.TabIndex = 22
        Me.BtnWczytajDoRadana.Text = "Wczytaj Wszystkie Arkusze Do Radana"
        Me.BtnWczytajDoRadana.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(764, 38)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(295, 19)
        Me.ProgressBar1.TabIndex = 32
        '
        'LabelProgressBar
        '
        Me.LabelProgressBar.AutoSize = True
        Me.LabelProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.LabelProgressBar.Location = New System.Drawing.Point(762, 15)
        Me.LabelProgressBar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelProgressBar.Name = "LabelProgressBar"
        Me.LabelProgressBar.Size = New System.Drawing.Size(37, 13)
        Me.LabelProgressBar.TabIndex = 33
        Me.LabelProgressBar.Text = "Status"
        '
        'CBAdmin
        '
        Me.CBAdmin.AutoSize = True
        Me.CBAdmin.BackColor = System.Drawing.Color.Transparent
        Me.CBAdmin.Location = New System.Drawing.Point(889, 760)
        Me.CBAdmin.Margin = New System.Windows.Forms.Padding(2)
        Me.CBAdmin.Name = "CBAdmin"
        Me.CBAdmin.Size = New System.Drawing.Size(55, 17)
        Me.CBAdmin.TabIndex = 35
        Me.CBAdmin.Text = "Admin"
        Me.CBAdmin.UseVisualStyleBackColor = False
        Me.CBAdmin.Visible = False
        '
        'BtnWczytajWybrane
        '
        Me.BtnWczytajWybrane.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnWczytajWybrane.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWczytajWybrane.Location = New System.Drawing.Point(1029, 666)
        Me.BtnWczytajWybrane.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWczytajWybrane.Name = "BtnWczytajWybrane"
        Me.BtnWczytajWybrane.Size = New System.Drawing.Size(112, 63)
        Me.BtnWczytajWybrane.TabIndex = 36
        Me.BtnWczytajWybrane.Text = "Wczytaj tylko wybrane Arkusze"
        Me.BtnWczytajWybrane.UseVisualStyleBackColor = False
        '
        'TxtWyszukaj
        '
        Me.TxtWyszukaj.Location = New System.Drawing.Point(1114, 38)
        Me.TxtWyszukaj.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWyszukaj.Name = "TxtWyszukaj"
        Me.TxtWyszukaj.Size = New System.Drawing.Size(161, 20)
        Me.TxtWyszukaj.TabIndex = 37
        '
        'BtnWyszukaj
        '
        Me.BtnWyszukaj.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnWyszukaj.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWyszukaj.Location = New System.Drawing.Point(1293, 27)
        Me.BtnWyszukaj.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWyszukaj.Name = "BtnWyszukaj"
        Me.BtnWyszukaj.Size = New System.Drawing.Size(92, 41)
        Me.BtnWyszukaj.TabIndex = 38
        Me.BtnWyszukaj.Text = "Wyszukaj"
        Me.BtnWyszukaj.UseVisualStyleBackColor = False
        '
        'BtnPokazWszystko
        '
        Me.BtnPokazWszystko.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnPokazWszystko.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnPokazWszystko.Location = New System.Drawing.Point(1389, 27)
        Me.BtnPokazWszystko.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnPokazWszystko.Name = "BtnPokazWszystko"
        Me.BtnPokazWszystko.Size = New System.Drawing.Size(92, 41)
        Me.BtnPokazWszystko.TabIndex = 39
        Me.BtnPokazWszystko.Text = "Pokaż Wszystko"
        Me.BtnPokazWszystko.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Arkusze", "Odpady"})
        Me.ComboBox1.Location = New System.Drawing.Point(16, 37)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox1.TabIndex = 40
        Me.ComboBox1.Text = "Arkusze"
        '
        'BtnWczytajOdpad
        '
        Me.BtnWczytajOdpad.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnWczytajOdpad.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWczytajOdpad.Location = New System.Drawing.Point(1276, 666)
        Me.BtnWczytajOdpad.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWczytajOdpad.Name = "BtnWczytajOdpad"
        Me.BtnWczytajOdpad.Size = New System.Drawing.Size(112, 63)
        Me.BtnWczytajOdpad.TabIndex = 41
        Me.BtnWczytajOdpad.Text = "Wczytaj Odpad"
        Me.BtnWczytajOdpad.UseVisualStyleBackColor = False
        '
        'BtnWczytajWszystkieOdpady
        '
        Me.BtnWczytajWszystkieOdpady.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnWczytajWszystkieOdpady.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWczytajWszystkieOdpady.Location = New System.Drawing.Point(1153, 666)
        Me.BtnWczytajWszystkieOdpady.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWczytajWszystkieOdpady.Name = "BtnWczytajWszystkieOdpady"
        Me.BtnWczytajWszystkieOdpady.Size = New System.Drawing.Size(112, 63)
        Me.BtnWczytajWszystkieOdpady.TabIndex = 42
        Me.BtnWczytajWszystkieOdpady.Text = "Wczytaj Wszystkie Odpady"
        Me.BtnWczytajWszystkieOdpady.UseVisualStyleBackColor = False
        '
        'BtnGenerujKody
        '
        Me.BtnGenerujKody.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnGenerujKody.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnGenerujKody.Enabled = False
        Me.BtnGenerujKody.Location = New System.Drawing.Point(781, 666)
        Me.BtnGenerujKody.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGenerujKody.Name = "BtnGenerujKody"
        Me.BtnGenerujKody.Size = New System.Drawing.Size(112, 63)
        Me.BtnGenerujKody.TabIndex = 44
        Me.BtnGenerujKody.Text = "Generuj kody kreskowe dla wybranych arkuszy"
        Me.BtnGenerujKody.UseVisualStyleBackColor = False
        Me.BtnGenerujKody.Visible = False
        '
        'CBZrobBarcody
        '
        Me.CBZrobBarcody.AutoSize = True
        Me.CBZrobBarcody.BackColor = System.Drawing.Color.Transparent
        Me.CBZrobBarcody.Enabled = False
        Me.CBZrobBarcody.Location = New System.Drawing.Point(185, 666)
        Me.CBZrobBarcody.Margin = New System.Windows.Forms.Padding(2)
        Me.CBZrobBarcody.Name = "CBZrobBarcody"
        Me.CBZrobBarcody.Size = New System.Drawing.Size(112, 17)
        Me.CBZrobBarcody.TabIndex = 70
        Me.CBZrobBarcody.Text = "Wł/Wył. Barcode"
        Me.CBZrobBarcody.UseVisualStyleBackColor = False
        Me.CBZrobBarcody.Visible = False
        '
        'LblUstawieniaKoduKreskowego
        '
        Me.LblUstawieniaKoduKreskowego.AutoSize = True
        Me.LblUstawieniaKoduKreskowego.BackColor = System.Drawing.Color.Transparent
        Me.LblUstawieniaKoduKreskowego.Enabled = False
        Me.LblUstawieniaKoduKreskowego.Location = New System.Drawing.Point(25, 670)
        Me.LblUstawieniaKoduKreskowego.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUstawieniaKoduKreskowego.Name = "LblUstawieniaKoduKreskowego"
        Me.LblUstawieniaKoduKreskowego.Size = New System.Drawing.Size(147, 13)
        Me.LblUstawieniaKoduKreskowego.TabIndex = 69
        Me.LblUstawieniaKoduKreskowego.Text = "Ustawienia kodu kreskowego"
        Me.LblUstawieniaKoduKreskowego.Visible = False
        '
        'CBWymiar
        '
        Me.CBWymiar.AutoSize = True
        Me.CBWymiar.BackColor = System.Drawing.Color.Transparent
        Me.CBWymiar.Enabled = False
        Me.CBWymiar.Location = New System.Drawing.Point(253, 703)
        Me.CBWymiar.Margin = New System.Windows.Forms.Padding(2)
        Me.CBWymiar.Name = "CBWymiar"
        Me.CBWymiar.Size = New System.Drawing.Size(61, 17)
        Me.CBWymiar.TabIndex = 68
        Me.CBWymiar.Text = "Wymiar"
        Me.CBWymiar.UseVisualStyleBackColor = False
        Me.CBWymiar.Visible = False
        '
        'CBGrubosc
        '
        Me.CBGrubosc.AutoSize = True
        Me.CBGrubosc.BackColor = System.Drawing.Color.Transparent
        Me.CBGrubosc.Enabled = False
        Me.CBGrubosc.Location = New System.Drawing.Point(185, 703)
        Me.CBGrubosc.Margin = New System.Windows.Forms.Padding(2)
        Me.CBGrubosc.Name = "CBGrubosc"
        Me.CBGrubosc.Size = New System.Drawing.Size(66, 17)
        Me.CBGrubosc.TabIndex = 67
        Me.CBGrubosc.Text = "Grubość"
        Me.CBGrubosc.UseVisualStyleBackColor = False
        Me.CBGrubosc.Visible = False
        '
        'CbMaterial
        '
        Me.CbMaterial.AutoSize = True
        Me.CbMaterial.BackColor = System.Drawing.Color.Transparent
        Me.CbMaterial.Enabled = False
        Me.CbMaterial.Location = New System.Drawing.Point(121, 703)
        Me.CbMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.CbMaterial.Name = "CbMaterial"
        Me.CbMaterial.Size = New System.Drawing.Size(65, 17)
        Me.CbMaterial.TabIndex = 66
        Me.CbMaterial.Text = "Materiał"
        Me.CbMaterial.UseVisualStyleBackColor = False
        Me.CbMaterial.Visible = False
        '
        'CBNumerMagazynowy
        '
        Me.CBNumerMagazynowy.AutoSize = True
        Me.CBNumerMagazynowy.BackColor = System.Drawing.Color.Transparent
        Me.CBNumerMagazynowy.Enabled = False
        Me.CBNumerMagazynowy.Location = New System.Drawing.Point(25, 703)
        Me.CBNumerMagazynowy.Margin = New System.Windows.Forms.Padding(2)
        Me.CBNumerMagazynowy.Name = "CBNumerMagazynowy"
        Me.CBNumerMagazynowy.Size = New System.Drawing.Size(102, 17)
        Me.CBNumerMagazynowy.TabIndex = 65
        Me.CBNumerMagazynowy.Text = "Nr Magazynowy"
        Me.CBNumerMagazynowy.UseVisualStyleBackColor = False
        Me.CBNumerMagazynowy.Visible = False
        '
        'LblKatalogDoZapisuBarcodow
        '
        Me.LblKatalogDoZapisuBarcodow.AutoSize = True
        Me.LblKatalogDoZapisuBarcodow.BackColor = System.Drawing.Color.Transparent
        Me.LblKatalogDoZapisuBarcodow.Enabled = False
        Me.LblKatalogDoZapisuBarcodow.Location = New System.Drawing.Point(24, 748)
        Me.LblKatalogDoZapisuBarcodow.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblKatalogDoZapisuBarcodow.Name = "LblKatalogDoZapisuBarcodow"
        Me.LblKatalogDoZapisuBarcodow.Size = New System.Drawing.Size(142, 13)
        Me.LblKatalogDoZapisuBarcodow.TabIndex = 64
        Me.LblKatalogDoZapisuBarcodow.Text = "Katalog do zapisu Barcodów"
        Me.LblKatalogDoZapisuBarcodow.Visible = False
        '
        'TxtSciezkaBarcode
        '
        Me.TxtSciezkaBarcode.Enabled = False
        Me.TxtSciezkaBarcode.Location = New System.Drawing.Point(188, 745)
        Me.TxtSciezkaBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSciezkaBarcode.Name = "TxtSciezkaBarcode"
        Me.TxtSciezkaBarcode.Size = New System.Drawing.Size(213, 20)
        Me.TxtSciezkaBarcode.TabIndex = 63
        Me.TxtSciezkaBarcode.Text = "C:\Barcode"
        Me.TxtSciezkaBarcode.Visible = False
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
        Me.Barcode1.Location = New System.Drawing.Point(727, 667)
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
        Me.Barcode1.TabIndex = 71
        Me.Barcode1.TopMargin = 0!
        Me.Barcode1.UOM = BarcodeLib.Barcode.UnitOfMeasure.PIXEL
        Me.Barcode1.Version = BarcodeLib.Barcode.QRCodeVersion.V1
        Me.Barcode1.Visible = False
        '
        'BtnOtworzPlik
        '
        Me.BtnOtworzPlik.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnOtworzPlik.Enabled = False
        Me.BtnOtworzPlik.Location = New System.Drawing.Point(405, 745)
        Me.BtnOtworzPlik.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOtworzPlik.Name = "BtnOtworzPlik"
        Me.BtnOtworzPlik.Size = New System.Drawing.Size(24, 19)
        Me.BtnOtworzPlik.TabIndex = 72
        Me.BtnOtworzPlik.Text = "..."
        Me.BtnOtworzPlik.UseVisualStyleBackColor = True
        Me.BtnOtworzPlik.Visible = False
        '
        'CBKolorTla
        '
        Me.CBKolorTla.Enabled = False
        Me.CBKolorTla.FormattingEnabled = True
        Me.CBKolorTla.Items.AddRange(New Object() {"Zielony", "Szary"})
        Me.CBKolorTla.Location = New System.Drawing.Point(188, 780)
        Me.CBKolorTla.Margin = New System.Windows.Forms.Padding(2)
        Me.CBKolorTla.Name = "CBKolorTla"
        Me.CBKolorTla.Size = New System.Drawing.Size(92, 21)
        Me.CBKolorTla.TabIndex = 73
        Me.CBKolorTla.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(25, 780)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Kolor Tła"
        Me.Label1.Visible = False
        '
        'CBOdpadyZatwierdzone
        '
        Me.CBOdpadyZatwierdzone.AutoSize = True
        Me.CBOdpadyZatwierdzone.BackColor = System.Drawing.Color.Transparent
        Me.CBOdpadyZatwierdzone.Location = New System.Drawing.Point(221, 38)
        Me.CBOdpadyZatwierdzone.Margin = New System.Windows.Forms.Padding(2)
        Me.CBOdpadyZatwierdzone.Name = "CBOdpadyZatwierdzone"
        Me.CBOdpadyZatwierdzone.Size = New System.Drawing.Size(118, 17)
        Me.CBOdpadyZatwierdzone.TabIndex = 75
        Me.CBOdpadyZatwierdzone.Text = "Odpady już wycięte"
        Me.CBOdpadyZatwierdzone.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.MagazynBlach.My.Resources.Resources.radan
        Me.PictureBox1.Location = New System.Drawing.Point(966, 758)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(545, 109)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.WaitOnLoad = True
        '
        'ImportBlach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1528, 883)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CBOdpadyZatwierdzone)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBKolorTla)
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
        Me.Controls.Add(Me.BtnGenerujKody)
        Me.Controls.Add(Me.BtnWczytajWszystkieOdpady)
        Me.Controls.Add(Me.BtnWczytajOdpad)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtnPokazWszystko)
        Me.Controls.Add(Me.BtnWyszukaj)
        Me.Controls.Add(Me.TxtWyszukaj)
        Me.Controls.Add(Me.BtnWczytajWybrane)
        Me.Controls.Add(Me.CBAdmin)
        Me.Controls.Add(Me.LabelProgressBar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnWczytajDane)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnWczytajDoRadana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ImportBlach"
        Me.Text = "Import Blach"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents BtnWczytajDane As Windows.Forms.Button
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents BtnWczytajDoRadana As Windows.Forms.Button
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents LabelProgressBar As Windows.Forms.Label
    Friend WithEvents CBAdmin As Windows.Forms.CheckBox
    Friend WithEvents BtnWczytajWybrane As Windows.Forms.Button
    Friend WithEvents TxtWyszukaj As Windows.Forms.TextBox
    Friend WithEvents BtnWyszukaj As Windows.Forms.Button
    Friend WithEvents BtnPokazWszystko As Windows.Forms.Button
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents BtnWczytajOdpad As Windows.Forms.Button
    Friend WithEvents BtnWczytajWszystkieOdpady As Windows.Forms.Button
    Friend WithEvents BtnGenerujKody As Windows.Forms.Button
    Friend WithEvents CBZrobBarcody As Windows.Forms.CheckBox
    Friend WithEvents LblUstawieniaKoduKreskowego As Windows.Forms.Label
    Friend WithEvents CBWymiar As Windows.Forms.CheckBox
    Friend WithEvents CBGrubosc As Windows.Forms.CheckBox
    Friend WithEvents CbMaterial As Windows.Forms.CheckBox
    Friend WithEvents CBNumerMagazynowy As Windows.Forms.CheckBox
    Friend WithEvents LblKatalogDoZapisuBarcodow As Windows.Forms.Label
    Friend WithEvents TxtSciezkaBarcode As Windows.Forms.TextBox
    Friend WithEvents Barcode1 As BarcodeLib.Barcode.WinForms.QRCodeWinForm
    Friend WithEvents BtnOtworzPlik As Windows.Forms.Button
    Friend WithEvents CBKolorTla As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents CBOdpadyZatwierdzone As Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
