' **** SIMONCODER SOFTWARE ******** © 2018 Scott Reed **** mreed1972@gmail.com



Public Class Form1

    Dim xcode As String
    Dim CoDec As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.cXY0160

    End Sub

    Function setday()
        Dim dy As Integer = Date.Now.Day
        Select Case dy
            Case 1 To 5
                Return "1X"
            Case 6 To 10
                Return "2X"
            Case 11 To 15
                Return "3X"
            Case 16 To 20
                Return "4X"
            Case > 20
                Return "5X"
        End Select
    End Function

    Public Function Grs(ByRef length As Integer) As String
        Randomize()
        Dim ac As String
        ac = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim i As Integer
        For i = 1 To length
            Grs = Grs & Mid(ac, Int(Rnd() * Len(ac) + 1), 1)
        Next
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CoDec = txCodeDec.Text & "(" & setday() & Grs(6) & ")"

        lbx.Items.Add(CoDec)
        Clipboard.SetText(CoDec)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class
