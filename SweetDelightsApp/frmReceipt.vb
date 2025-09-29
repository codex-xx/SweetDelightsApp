Public Class frmReceipt

    ' === DESIGN NOTES ===
    ' RichTextBox: Name = txtReceipt
    ' Button: Name = btnClose | Text = "Close"
    ' Form Settings:
    '   FormBorderStyle = FixedDialog
    '   MaximizeBox = False
    '   MinimizeBox = False
    '   StartPosition = CenterParent

    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional formatting when form loads
        txtReceipt.ReadOnly = True
        txtReceipt.Font = New Font("Consolas", 10) ' Monospaced for alignment
    End Sub

    Public Sub LoadReceipt(receiptText As String)
        txtReceipt.Text = receiptText
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtReceipt_TextChanged(sender As Object, e As EventArgs) Handles txtReceipt.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click

    End Sub
End Class
