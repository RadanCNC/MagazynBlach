<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZamienNaDXF
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
        Me.TxtNazwaPliku = New System.Windows.Forms.TextBox()
        Me.Btn = New System.Windows.Forms.Button()
        Me.TxtRezult = New System.Windows.Forms.TextBox()
        Me.TxtDirectory = New System.Windows.Forms.TextBox()
        Me.BtnWszystkie = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtNazwaPliku
        '
        Me.TxtNazwaPliku.Location = New System.Drawing.Point(50, 30)
        Me.TxtNazwaPliku.Name = "TxtNazwaPliku"
        Me.TxtNazwaPliku.Size = New System.Drawing.Size(211, 22)
        Me.TxtNazwaPliku.TabIndex = 0
        Me.TxtNazwaPliku.Text = "D:\1.sym"
        '
        'Btn
        '
        Me.Btn.Location = New System.Drawing.Point(50, 130)
        Me.Btn.Name = "Btn"
        Me.Btn.Size = New System.Drawing.Size(211, 58)
        Me.Btn.TabIndex = 1
        Me.Btn.Text = "Button1"
        Me.Btn.UseVisualStyleBackColor = True
        '
        'TxtRezult
        '
        Me.TxtRezult.Location = New System.Drawing.Point(50, 72)
        Me.TxtRezult.Name = "TxtRezult"
        Me.TxtRezult.Size = New System.Drawing.Size(211, 22)
        Me.TxtRezult.TabIndex = 2
        '
        'TxtDirectory
        '
        Me.TxtDirectory.Location = New System.Drawing.Point(50, 220)
        Me.TxtDirectory.Name = "TxtDirectory"
        Me.TxtDirectory.Size = New System.Drawing.Size(211, 22)
        Me.TxtDirectory.TabIndex = 3
        Me.TxtDirectory.Text = "D:\Dab\"
        '
        'BtnWszystkie
        '
        Me.BtnWszystkie.Location = New System.Drawing.Point(50, 279)
        Me.BtnWszystkie.Name = "BtnWszystkie"
        Me.BtnWszystkie.Size = New System.Drawing.Size(211, 58)
        Me.BtnWszystkie.TabIndex = 4
        Me.BtnWszystkie.Text = "BtnWszystkie"
        Me.BtnWszystkie.UseVisualStyleBackColor = True
        '
        'ZamienNaDXF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 371)
        Me.Controls.Add(Me.BtnWszystkie)
        Me.Controls.Add(Me.TxtDirectory)
        Me.Controls.Add(Me.TxtRezult)
        Me.Controls.Add(Me.Btn)
        Me.Controls.Add(Me.TxtNazwaPliku)
        Me.Name = "ZamienNaDXF"
        Me.Text = "ZamienNaDXF"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNazwaPliku As Windows.Forms.TextBox
    Friend WithEvents Btn As Windows.Forms.Button
    Friend WithEvents TxtRezult As Windows.Forms.TextBox
    Friend WithEvents TxtDirectory As Windows.Forms.TextBox
    Friend WithEvents BtnWszystkie As Windows.Forms.Button
End Class
