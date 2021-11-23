<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlowLog
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.BtnZamknij = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(45, 37)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(624, 456)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'BtnZamknij
        '
        Me.BtnZamknij.Location = New System.Drawing.Point(195, 499)
        Me.BtnZamknij.Name = "BtnZamknij"
        Me.BtnZamknij.Size = New System.Drawing.Size(214, 82)
        Me.BtnZamknij.TabIndex = 1
        Me.BtnZamknij.Text = "Zamknij"
        Me.BtnZamknij.UseVisualStyleBackColor = True
        '
        'FlowLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 589)
        Me.Controls.Add(Me.BtnZamknij)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "FlowLog"
        Me.Text = "Zapis działań i błędów"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents BtnZamknij As Windows.Forms.Button
End Class
