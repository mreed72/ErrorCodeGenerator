' **** SIMONCODER SOFTWARE ******** © 2018-2025 Scott Reed **** mreed1972@gmail.com

Public Class Form1
    Private CoDec As String
    Private clog As String = "C:\Mighty Apps\ECGlog.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Session Log
        Try
            Dim f As Boolean
            f = My.Computer.FileSystem.FileExists(clog)
            If f = False Then
                My.Computer.FileSystem.WriteAllText(clog, "", False)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Function setday() As String
        Dim dayGroup As Integer = (Date.Now.Day - 1) \ 5 + 1
        If dayGroup > 6 Then dayGroup = 9
        Return dayGroup & "X"
    End Function

    Public Function Grs(ByRef length As Integer) As String
        Try
            Dim sb As New System.Text.StringBuilder()
            Dim ac As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim rnd As New Random()
            For i As Integer = 1 To length
                sb.Append(ac(rnd.Next(0, ac.Length)))
            Next
            Return sb.ToString()
        Catch ex As Exception
        End Try
    End Function

    Function ELOG(msg As String)
        Try
            Dim vt As String = vbCrLf & Date.Now & " ===== " & msg
            My.Computer.FileSystem.WriteAllText(clog, vt & vbCrLf & My.Computer.FileSystem.ReadAllText(clog), False)
        Catch ex As Exception
            ' Handle exception if needed
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CoDec = txCodeDec.Text & "(" & Chr(34) & setday() & Grs(5) & Chr(34) & ", " & "ex.message)"

        lbx.Items.Add(CoDec)
        b3.Text = lbx.Items.Count.ToString & " items."

        If Clipboard.ContainsText() Then
            Clipboard.Clear()
        End If
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