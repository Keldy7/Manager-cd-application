Imports MySql.Data.MySqlClient

Public Class Detail
    Dim cls As ClsDonnee = New ClsDonnee()
    Dim MaConnexion As MySqlConnection = New MySqlConnection()

    Private Sub fiche()
        If IdCli.Text = "" Then
            MsgBox("veillez entrer un identifiant")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim abon = "select * from abonnement where Num_Abonne=" & IdCli.Text & ""
            Dim Enreg As MySqlCommand = New MySqlCommand(abon, MaConnexion)
            Dim dt As DataTable = New DataTable
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter(Enreg)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                TextBox1.Text = dr(4).ToString()
                dater.Text = dr(2).ToString()
                duree.Text = dr(1).ToString()
                droit.Text = dr(3).ToString()
                TextBox1.Visible = True
                dater.Visible = True
                duree.Visible = True
                droit.Visible = True
            Next
        End If
        If IdCli.Text = "" Then
            MsgBox("veillez entrer un identifiant")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim abon = "select * from client where Code_client=" & TextBox1.Text & ""
            Dim Enreg As MySqlCommand = New MySqlCommand(abon, MaConnexion)
            Dim dt As DataTable = New DataTable
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter(Enreg)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                NomClient.Text = dr(1).ToString()
                AdresseClient.Text = dr(2).ToString()
                TelClient.Text = dr(3).ToString()
                NomClient.Visible = True
                AdresseClient.Visible = True
                TelClient.Visible = True
            Next
        End If
        MaConnexion.Close()
    End Sub
    Private Sub Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        fiche()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub
End Class