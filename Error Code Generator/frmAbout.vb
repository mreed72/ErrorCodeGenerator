Public Class frmAbout

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Dim xc As String = "mailto:mreed1972@gmail.com"
            Diagnostics.Process.Start(xc)
        Catch ex As Exception

        End Try

    End Sub

End Class