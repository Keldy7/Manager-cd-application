Public Class Login
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        id.Clear()
        Psw.Clear()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If id.Text = "" Or Psw.Text = "" Then
            MsgBox("veillez remplir les champs")
        ElseIf id.Text = "Argentin" And Psw.Text = "1303" Then
            Me.Close()
            MainForm.Show()
        Else
            MsgBox("mot de pass ou Pseudo incorrect")
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class