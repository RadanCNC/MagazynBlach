<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnulowanieRezerwacjivb
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnulowanieRezerwacjivb))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnAnulujPrzyjęcieMagazynowe = New System.Windows.Forms.Button()
        Me.BtnAnulujRezerwacje = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.BtnAnulujWszystkie = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(35, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1438, 549)
        Me.DataGridView1.TabIndex = 0
        '
        'BtnAnulujPrzyjęcieMagazynowe
        '
        Me.BtnAnulujPrzyjęcieMagazynowe.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnAnulujPrzyjęcieMagazynowe.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnAnulujPrzyjęcieMagazynowe.Location = New System.Drawing.Point(169, 630)
        Me.BtnAnulujPrzyjęcieMagazynowe.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAnulujPrzyjęcieMagazynowe.Name = "BtnAnulujPrzyjęcieMagazynowe"
        Me.BtnAnulujPrzyjęcieMagazynowe.Size = New System.Drawing.Size(112, 41)
        Me.BtnAnulujPrzyjęcieMagazynowe.TabIndex = 1
        Me.BtnAnulujPrzyjęcieMagazynowe.Text = "Anuluj Przyjęcie Magazynowe"
        Me.BtnAnulujPrzyjęcieMagazynowe.UseVisualStyleBackColor = False
        '
        'BtnAnulujRezerwacje
        '
        Me.BtnAnulujRezerwacje.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnAnulujRezerwacje.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnAnulujRezerwacje.Location = New System.Drawing.Point(38, 630)
        Me.BtnAnulujRezerwacje.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAnulujRezerwacje.Name = "BtnAnulujRezerwacje"
        Me.BtnAnulujRezerwacje.Size = New System.Drawing.Size(112, 41)
        Me.BtnAnulujRezerwacje.TabIndex = 2
        Me.BtnAnulujRezerwacje.Text = "Anuluj Rezerwację"
        Me.BtnAnulujRezerwacje.UseVisualStyleBackColor = False
        Me.BtnAnulujRezerwacje.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Rezerwacje", "Przyjęcia Magazynowe", "Anulowane Rezerwacje"})
        Me.ComboBox1.Location = New System.Drawing.Point(45, 10)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Text = "Rezerwacje"
        '
        'BtnAnulujWszystkie
        '
        Me.BtnAnulujWszystkie.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnAnulujWszystkie.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._7
        Me.BtnAnulujWszystkie.Location = New System.Drawing.Point(511, 630)
        Me.BtnAnulujWszystkie.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAnulujWszystkie.Name = "BtnAnulujWszystkie"
        Me.BtnAnulujWszystkie.Size = New System.Drawing.Size(112, 41)
        Me.BtnAnulujWszystkie.TabIndex = 5
        Me.BtnAnulujWszystkie.Text = "Anuluj wszystkie Rezerwacje"
        Me.BtnAnulujWszystkie.UseVisualStyleBackColor = False
        '
        'AnulowanieRezerwacjivb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BackgroundImage = Global.MagazynBlach.My.Resources.Resources._14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1490, 699)
        Me.Controls.Add(Me.BtnAnulujWszystkie)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtnAnulujRezerwacje)
        Me.Controls.Add(Me.BtnAnulujPrzyjęcieMagazynowe)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "AnulowanieRezerwacjivb"
        Me.Text = "AnulowanieRezerwacjivb"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents BtnAnulujPrzyjęcieMagazynowe As Windows.Forms.Button
    Friend WithEvents BtnAnulujRezerwacje As Windows.Forms.Button
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents BtnAnulujWszystkie As Windows.Forms.Button
End Class
