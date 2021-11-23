Imports System.Windows.Forms

Public Class Informacje
    Private Sub Informacje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub
    ' linia kodu odpowiadajaca za okno makra zawsze na wierzchu
    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub
End Class