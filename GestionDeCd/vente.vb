Imports MySql.Data.MySqlClient

Public Class vente
    Dim cls As ClsDonnee = New ClsDonnee()
    Private Sub vente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fiche()
    End Sub
    Private Sub fiche()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from vente"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub

    Dim key = 0
    Private Sub Clear()
        Num_vente.Clear()
        Code_client.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim cli As String
        cli = "Insert into vente values ('" & Num_vente.Text & "','" & DateVent_cd.Value & "','" & Code_client.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
        MsgBox("La vente a bien été effectué")
        Num_vente.Clear()
        Code_client.Clear()
        MaConnexion.Close()
        fiche()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Num_vente.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        DateVent_cd.Value = row.Cells(1).Value.ToString()
        Code_client.Text = row.Cells(2).Value.ToString()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub
End Class