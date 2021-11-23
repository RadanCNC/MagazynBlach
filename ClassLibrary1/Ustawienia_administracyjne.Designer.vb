<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ustawienia_administracyjne
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ustawienia_administracyjne))
        Me.BtnZmienBaze = New System.Windows.Forms.Button()
        Me.TxtSerwer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtHaslo = New System.Windows.Forms.TextBox()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.TxtBaza = New System.Windows.Forms.TextBox()
        Me.BtnZapiszUStawienia = New System.Windows.Forms.Button()
        Me.CBWindowsAuthentications = New System.Windows.Forms.CheckBox()
        Me.TxtOdpadyDoUzycia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtSciezkaDoLoga = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnOtworzPlik = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnNowyLog = New System.Windows.Forms.Button()
        Me.BtnWyczyscBaze = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnZmienBaze
        '
        Me.BtnZmienBaze.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnZmienBaze.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnZmienBaze.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnZmienBaze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnZmienBaze.Location = New System.Drawing.Point(40, 215)
        Me.BtnZmienBaze.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnZmienBaze.Name = "BtnZmienBaze"
        Me.BtnZmienBaze.Size = New System.Drawing.Size(368, 43)
        Me.BtnZmienBaze.TabIndex = 43
        Me.BtnZmienBaze.Text = "Zmien Baze"
        Me.BtnZmienBaze.UseVisualStyleBackColor = False
        '
        'TxtSerwer
        '
        Me.TxtSerwer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtSerwer.FormattingEnabled = True
        Me.TxtSerwer.Location = New System.Drawing.Point(124, 32)
        Me.TxtSerwer.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSerwer.Name = "TxtSerwer"
        Me.TxtSerwer.Size = New System.Drawing.Size(285, 21)
        Me.TxtSerwer.TabIndex = 42
        Me.TxtSerwer.Text = "WROCLAW_SZ_4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 150)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Hasło"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Login:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Baza Danych:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Serwer:"
        '
        'TxtHaslo
        '
        Me.TxtHaslo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtHaslo.Location = New System.Drawing.Point(124, 145)
        Me.TxtHaslo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtHaslo.Name = "TxtHaslo"
        Me.TxtHaslo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtHaslo.Size = New System.Drawing.Size(285, 19)
        Me.TxtHaslo.TabIndex = 37
        Me.TxtHaslo.Text = "kamil123"
        '
        'TxtLogin
        '
        Me.TxtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtLogin.Location = New System.Drawing.Point(124, 109)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(285, 19)
        Me.TxtLogin.TabIndex = 36
        Me.TxtLogin.Text = "kamil"
        '
        'TxtBaza
        '
        Me.TxtBaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtBaza.Location = New System.Drawing.Point(124, 69)
        Me.TxtBaza.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBaza.Name = "TxtBaza"
        Me.TxtBaza.Size = New System.Drawing.Size(285, 19)
        Me.TxtBaza.TabIndex = 35
        Me.TxtBaza.Text = "ArkuszeDB"
        '
        'BtnZapiszUStawienia
        '
        Me.BtnZapiszUStawienia.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnZapiszUStawienia.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnZapiszUStawienia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnZapiszUStawienia.Location = New System.Drawing.Point(40, 263)
        Me.BtnZapiszUStawienia.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnZapiszUStawienia.Name = "BtnZapiszUStawienia"
        Me.BtnZapiszUStawienia.Size = New System.Drawing.Size(368, 42)
        Me.BtnZapiszUStawienia.TabIndex = 44
        Me.BtnZapiszUStawienia.Text = "Zapisz ustawienia do pliku"
        Me.BtnZapiszUStawienia.UseVisualStyleBackColor = False
        '
        'CBWindowsAuthentications
        '
        Me.CBWindowsAuthentications.AutoSize = True
        Me.CBWindowsAuthentications.BackColor = System.Drawing.Color.Transparent
        Me.CBWindowsAuthentications.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CBWindowsAuthentications.Location = New System.Drawing.Point(274, 181)
        Me.CBWindowsAuthentications.Margin = New System.Windows.Forms.Padding(2)
        Me.CBWindowsAuthentications.Name = "CBWindowsAuthentications"
        Me.CBWindowsAuthentications.Size = New System.Drawing.Size(141, 17)
        Me.CBWindowsAuthentications.TabIndex = 50
        Me.CBWindowsAuthentications.Text = "Windows Authentication"
        Me.CBWindowsAuthentications.UseVisualStyleBackColor = False
        '
        'TxtOdpadyDoUzycia
        '
        Me.TxtOdpadyDoUzycia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtOdpadyDoUzycia.Location = New System.Drawing.Point(204, 313)
        Me.TxtOdpadyDoUzycia.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtOdpadyDoUzycia.Name = "TxtOdpadyDoUzycia"
        Me.TxtOdpadyDoUzycia.Size = New System.Drawing.Size(206, 19)
        Me.TxtOdpadyDoUzycia.TabIndex = 51
        Me.TxtOdpadyDoUzycia.Text = "C:\OdpadyDoUzycia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 313)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Folder odpadów do użycia:"
        '
        'TxtSciezkaDoLoga
        '
        Me.TxtSciezkaDoLoga.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TxtSciezkaDoLoga.Location = New System.Drawing.Point(204, 351)
        Me.TxtSciezkaDoLoga.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSciezkaDoLoga.Name = "TxtSciezkaDoLoga"
        Me.TxtSciezkaDoLoga.Size = New System.Drawing.Size(206, 19)
        Me.TxtSciezkaDoLoga.TabIndex = 53
        Me.TxtSciezkaDoLoga.Text = "C:\"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 354)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Katalog pliku Log:"
        '
        'BtnLog
        '
        Me.BtnLog.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnLog.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnLog.Location = New System.Drawing.Point(306, 382)
        Me.BtnLog.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(103, 32)
        Me.BtnLog.TabIndex = 55
        Me.BtnLog.Text = "Otwórz Log"
        Me.BtnLog.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BtnOtworzPlik
        '
        Me.BtnOtworzPlik.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnOtworzPlik.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnOtworzPlik.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnOtworzPlik.Location = New System.Drawing.Point(413, 349)
        Me.BtnOtworzPlik.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOtworzPlik.Name = "BtnOtworzPlik"
        Me.BtnOtworzPlik.Size = New System.Drawing.Size(24, 19)
        Me.BtnOtworzPlik.TabIndex = 56
        Me.BtnOtworzPlik.Text = "..."
        Me.BtnOtworzPlik.UseVisualStyleBackColor = False
        '
        'BtnNowyLog
        '
        Me.BtnNowyLog.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnNowyLog.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnNowyLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnNowyLog.Location = New System.Drawing.Point(168, 382)
        Me.BtnNowyLog.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnNowyLog.Name = "BtnNowyLog"
        Me.BtnNowyLog.Size = New System.Drawing.Size(134, 32)
        Me.BtnNowyLog.TabIndex = 57
        Me.BtnNowyLog.Text = "Stwórz nowy plik log"
        Me.BtnNowyLog.UseVisualStyleBackColor = False
        '
        'BtnWyczyscBaze
        '
        Me.BtnWyczyscBaze.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnWyczyscBaze.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnWyczyscBaze.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BtnWyczyscBaze.Location = New System.Drawing.Point(306, 432)
        Me.BtnWyczyscBaze.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWyczyscBaze.Name = "BtnWyczyscBaze"
        Me.BtnWyczyscBaze.Size = New System.Drawing.Size(103, 29)
        Me.BtnWyczyscBaze.TabIndex = 58
        Me.BtnWyczyscBaze.Text = "Wyczyść Baze"
        Me.BtnWyczyscBaze.UseVisualStyleBackColor = False
        '
        'Ustawienia_administracyjne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LimeGreen
        Me.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(448, 490)
        Me.Controls.Add(Me.BtnWyczyscBaze)
        Me.Controls.Add(Me.BtnNowyLog)
        Me.Controls.Add(Me.BtnOtworzPlik)
        Me.Controls.Add(Me.BtnLog)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSciezkaDoLoga)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtOdpadyDoUzycia)
        Me.Controls.Add(Me.CBWindowsAuthentications)
        Me.Controls.Add(Me.BtnZapiszUStawienia)
        Me.Controls.Add(Me.BtnZmienBaze)
        Me.Controls.Add(Me.TxtSerwer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtHaslo)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtBaza)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Ustawienia_administracyjne"
        Me.Text = "Ustawienia Administracyjne"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnZmienBaze As Windows.Forms.Button
    Friend WithEvents TxtSerwer As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TxtHaslo As Windows.Forms.TextBox
    Friend WithEvents TxtLogin As Windows.Forms.TextBox
    Friend WithEvents TxtBaza As Windows.Forms.TextBox
    Friend WithEvents BtnZapiszUStawienia As Windows.Forms.Button
    Friend WithEvents CBWindowsAuthentications As Windows.Forms.CheckBox
    Friend WithEvents TxtOdpadyDoUzycia As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents TxtSciezkaDoLoga As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents BtnLog As Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents BtnOtworzPlik As Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnNowyLog As Windows.Forms.Button
    Friend WithEvents BtnWyczyscBaze As Windows.Forms.Button
End Class
