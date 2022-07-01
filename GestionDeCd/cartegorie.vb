Imports MySql.Data.MySqlClient

Public Class cartegorie
    Dim cls As ClsDonnee = New ClsDonnee()
    Private Sub cartegorie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fiche()
    End Sub
    Private Sub fiche()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from categorie"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub

    Dim key = 0
    Private Sub Clear()
        Code_cat.Clear()
        Nom_cat.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim cli As String
        cli = "Insert into categorie values ('" & Code_cat.Text & "','" & Nom_cat.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
        MsgBox("Cartegorie ajouter avec succes")
        Code_cat.Clear()
        Nom_cat.Clear()
        MaConnexion.Close()
        fiche()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If key = 0 Then
            MsgBox("Selectionner le la cartegorie à supprimer")
        Else
            Try
                Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
                Dim cli As String
                cli = "Delete from categorie where Code_cat = " & key & ""
                Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
                MsgBox("categorie supprimé avec succes")
                MaConnexion.Close()
                fiche()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Code_cat.Text = "" Or Nom_cat.Text = "" Then
            MsgBox("il manque des infos")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim cli As String
            cli = "Update categorie set Code_cat='" & Code_cat.Text & "',Nom_cat ='" & Nom_cat.Text & "'"
            Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
            MsgBox("client modifié avec succes")
            MaConnexion.Close()
            fiche()
            Clear()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Code_cat.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        Nom_cat.Text = row.Cells(1).Value.ToString()
    End Sub
End Class