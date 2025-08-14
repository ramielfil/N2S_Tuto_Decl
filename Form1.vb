Imports System.ComponentModel
Imports System.Text


Partial Public Class Form1
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Form2.Show()
    End Sub
End Class
