' **** SIMONCODER SOFTWARE ******** © 2018 Scott Reed **** mreed1972@gmail.com

Public Class Form1
    Private xcode As String
    Private CoDec As String
    Private clog As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Session Log
        Try
            clog = My.Application.Info.DirectoryPath & "\slog.txt"
            Dim f As Boolean
            f = My.Computer.FileSystem.FileExists(clog)
            If f = False Then
                My.Computer.FileSystem.WriteAllText(clog, "", False)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Function setday()
        Select Case Date.Now.Day
            Case 1 To 10
                Return "1X"
            Case 11 To 20
                Return "2X"
            Case 21 To 25
                Return "3X"
            Case 26 To 30
                Return "4X"
            Case Else
                Return "9X"
        End Select
    End Function

    Public Function Grs(ByRef length As Integer) As String
        Try
            Randomize()
            Dim ac As String
            ac = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim i As Integer
            For i = 1 To length
                Grs = Grs & Mid(ac, Int(Rnd() * Len(ac) + 1), 1)
            Next
        Catch ex As Exception
        End Try
    End Function

    Function ELOG(msg As String)
        Dim myfile As String = clog
        Dim itxt As New TextBox
        If IO.File.Exists(myfile) Then
            itxt.Text = IO.File.ReadAllText(myfile)
        End If
        Dim vt As String = vbCrLf & Date.Now & " ===== " & msg & itxt.Text
        My.Computer.FileSystem.WriteAllText(myfile, vt, False)
        itxt.Clear()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CoDec = txCodeDec.Text & "(" & Chr(34) & setday() & Grs(5) & Chr(34) & ", " & "ex.message)"

        lbx.Items.Add(CoDec)
        Clipboard.SetText(CoDec)
        ELOG(CoDec)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(clog)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frmAbout.Show()

    End Sub

End Class