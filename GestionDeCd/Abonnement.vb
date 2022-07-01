Imports MySql.Data.MySqlClient

Public Class Abonnement
    Dim cls As ClsDonnee = New ClsDonnee()
    Dim MaConnexion As MySqlConnection = New MySqlConnection()
    Private Sub Abonnement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        affiche()
    End Sub
    Public Sub affiche()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from abonnement"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        AbonnementTab.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim abon As String
        abon = "Insert into abonnement values('" & Num.Text & "','" & DureeAbon.Value & "','" & DateAbon.Value & "','" & DroitAbon.Text & "','" & IdCli.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(abon, MaConnexion)
        MsgBox("Nouvel Abonnement Ajouter avec succes")
        Num.Clear()
        DroitAbon.Clear()
        IdCli.Clear()
        MaConnexion.Close()
        affiche()
        MaConnexion.Close()
        affiche()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub

    Private Sub AbonnementTab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AbonnementTab.CellContentClick

    End Sub
    Private Sub Clear()
        Num.Clear()
        DroitAbon.Text = ""
        IdCli.Text = ""

    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Num.Text = "" Or DroitAbon.Text = "" Or IdCli.Text = "" Then
            MsgBox("il manque des infos")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim cli As String
            cli = "Update abonnee set Num_Abonne='" & Num.Text & "',Droit_Abonne='" & DroitAbon.Text & "',Code_Client='" & IdCli.Text & "'"
            Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
            MsgBox("Abonné modifié avec succes")
            MaConnexion.Close()
            affiche()
            Clear()
        End If
    End Sub
    Dim key = 0
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If key = 0 Then
            MsgBox("Selectionner le l'abboné à supprimer")
        Else
            Try
                Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
                Dim cli As String
                cli = "Delete from abonnement where Num_Abonne = " & key & ""
                Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
                MsgBox("client supprimé avec succes")
                MaConnexion.Close()
                affiche()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub AbonnementTab_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles AbonnementTab.CellMouseClick
        Dim row As DataGridViewRow = AbonnementTab.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Num.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        DureeAbon.Value = row.Cells(1).Value.ToString()
        DateAbon.Value = row.Cells(2).Value.ToString()
        DroitAbon.Text = row.Cells(3).Value.ToString()
        IdCli.Text = row.Cells(4).Value.ToString()
    End Sub
End Class