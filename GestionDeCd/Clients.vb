'Imports System.Data.M
Imports MySql.Data.MySqlClient
Public Class Clients
    Dim cls As ClsDonnee = New ClsDonnee()
    Dim MaConnexion As MySqlConnection = New MySqlConnection()
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles IdCli.TextChanged

    End Sub
    Private Sub populate()
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim sql = "select * from client"
        Dim ada As MySqlDataAdapter = New MySqlDataAdapter(sql, MaConnexion)
        Dim Builder As MySqlCommandBuilder = New MySqlCommandBuilder(ada)
        Dim ds As DataSet = New DataSet
        ada.Fill(ds)
        ClientTab.DataSource = ds.Tables(0)
        MaConnexion.Close()
    End Sub
    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
        Dim cli As String
        cli = "Insert into client values ('" & IdCli.Text & "','" & NomCli.Text & "','" & AdrCli.Text & "','" & NumCli.Text & "')"
        Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
        MsgBox("Client ajouter avec succes")
        IdCli.Clear()
        NomCli.Clear()
        AdrCli.Clear()
        NumCli.Clear()
        MaConnexion.Close()
        populate()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        MainForm.Show()
    End Sub
    Dim key = 0
    Private Sub Clear()
        IdCli.Clear()
        NomCli.Text = ""
        AdrCli.Text = ""
        NumCli.Text = ""

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If key = 0 Then
            MsgBox("Selectionner le clientà supprimer")
        Else
            Try
                Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
                Dim cli As String
                cli = "Delete from client where Code_client = " & key & ""
                Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
                MsgBox("client supprimé avec succes")
                MaConnexion.Close()
                populate()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub ClientTab_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ClientTab.CellMouseClick
        Dim row As DataGridViewRow = ClientTab.Rows(e.RowIndex)
        'key = Convert.ToInt32(row.Cells(0).Value.ToString())
        IdCli.Text = row.Cells(0).Value.ToString()              'pour faire apparaite les valeurs dans les champs à saisir
        NomCli.Text = row.Cells(1).Value.ToString()
        AdrCli.Text = row.Cells(2).Value.ToString()
        NumCli.Text = row.Cells(3).Value.ToString()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If IdCli.Text = "" Or NomCli.Text = "" Or AdrCli.Text = "" Or NumCli.Text = "" Then
            MsgBox("il manque des infos")
        Else
            Dim MaConnexion As MySqlConnection = cls.OuvrirConnexion()
            Dim cli As String
            cli = "Update client set Code_client='" & IdCli.Text & "',Nom_client='" & NomCli.Text & "',Adress_client='" & AdrCli.Text & "',Tel_client='" & NumCli.Text & "'"
            Dim Enreg As MySqlDataReader = cls.ExecuteRequete(cli, MaConnexion)
            MsgBox("client modifié avec succes")
            MaConnexion.Close()
            populate()
            Clear()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub

    Private Sub ClientTab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ClientTab.CellContentClick

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebmp As New Bitmap(Me.ClientTab.Width, Me.ClientTab.Height)
        ClientTab.DrawToBitmap(imagebmp, New Rectangle(0, 0, Me.ClientTab.Width, Me.ClientTab.Height))
        e.Graphics.DrawImage(imagebmp, 0, 0)
    End Sub
End Class