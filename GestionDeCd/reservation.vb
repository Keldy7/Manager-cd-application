Imports MySql.Data.MySqlClient

Public Class reservation
    Dim cls As ClsDonnee = New ClsDonnee()
    Private Sub reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fiche()
    End Sub
    Private Sub fiche()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from reservation"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub

    Dim key = 0
    Private Sub Clear()
        Code_reserv.Clear()
        Code_client.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim cli As String
        cli = "Insert into reservation values ('" & Code_reserv.Text & "','" & Date_reserv.Value & "','" & Code_client.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
        MsgBox("La reservation a bien été ajoutée")
        Code_reserv.Clear()
        Code_client.Clear()
        MaConnexion.Close()
        fiche()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Code_reserv.Text = "" Or Code_client.Text = "" Then
            MsgBox("il manque des infos")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim cli As String
            cli = "Update reservation set Code_reserv='" & Code_reserv.Text & "',Code_client ='" & Code_client.Text & "'"
            Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
            MsgBox("La reservation a bien été modifiée ")
            MaConnexion.Close()
            fiche()
            Clear()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If key = 0 Then
            MsgBox("Selectionner le la reservation à supprimer")
        Else
            Try
                Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
                Dim cli As String
                cli = "Delete from abonnement where Num_Abonne = " & key & ""
                Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
                MsgBox("la reservation a bien été suprimée")
                MaConnexion.Close()
                fiche()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        ' key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Code_reserv.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        Date_reserv.Value = row.Cells(1).Value.ToString()
        Code_client.Text = row.Cells(2).Value.ToString()

    End Sub
End Class