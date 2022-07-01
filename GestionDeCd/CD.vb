Imports MySql.Data.MySqlClient

Public Class CD
    Dim cls As ClsDonnee = New ClsDonnee()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub IdCli_TextChanged(sender As Object, e As EventArgs) Handles CodeType_cd.TextChanged

    End Sub
    Dim key = 0
    Private Sub Clear()
        CodeType_cd.Clear()
        prix_VentType.Text = ""
        Code_cat.Text = ""

    End Sub
    Private Sub fiche()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from type_cd"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        TypeCdTab.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub
    Private Sub CD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fiche()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim cli As String
        cli = "Insert into type_cd values ('" & CodeType_cd.Text & "','" & prix_VentType.Text & "','" & Code_cat.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
        MsgBox("Client ajouter avec succes")
        CodeType_cd.Clear()
        prix_VentType.Clear()
        Code_cat.Clear()
        MaConnexion.Close()
        fiche()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If CodeType_cd.Text = "" Or prix_VentType.Text = "" Or Code_cat.Text = "" Then
            MsgBox("il manque des infos")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim cli As String
            cli = "Update type_cd set CodeType_cd='" & CodeType_cd.Text & "',prix_VentType='" & prix_VentType.Text & "',Code_cat='" & Code_cat.Text & "'"
            Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
            MsgBox("Type du Cd modifié avec succes")
            MaConnexion.Close()
            fiche()
            Clear()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If key = 0 Then
            MsgBox("Selectionner le clientà supprimer")
        Else
            Try
                Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
                Dim cli As String
                cli = "Delete from type_cd where CodeType_cd = " & key & ""
                Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
                MsgBox("Type de cd supprimé avec succes")
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

    Private Sub TypeCdTab_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TypeCdTab.CellMouseClick
        Dim row As DataGridViewRow = TypeCdTab.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        CodeType_cd.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        prix_VentType.Text = row.Cells(1).Value.ToString()
        Code_cat.Text = row.Cells(2).Value.ToString()
    End Sub
End Class