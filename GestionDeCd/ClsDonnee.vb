Imports MySql.Data.MySqlClient

Public Class ClsDonnee
    Public chaineDeConnection As String = "server=localhost; user id=root; password= ;database=gestion_cd;"
    'SslMode=None;server=localhost;database=gestion-cd;pwd= 
    'Fonction permettant d'ouvrir un objet connexion (MysqlConnection) et de l'afficher
    'à une variable de type connection(MaConnexion)
    Public Function OuvrirConnexion() As MysqlConnection
        'Creation d'une variable d'instance de la connexion
        Dim MaConnexion As MysqlConnection = New MysqlConnection()
        'Définition de la chaine de connexion
        MaConnexion.ConnectionString = chaineDeConnection
        'ouverture de la connexion
        Try
            MaConnexion.Open()
            'retourne la connexion au programme appelant
        Catch Erreur As Exception
            MessageBox.Show(Erreur.Message)
        End Try
        Return MaConnexion
    End Function
    'cette fonction recoit un requete (LaRequete) et une connexion ouverte(Conn)
    ' et retourne le resultat de la requete dans un jeu d'enregistrement (Enreg) de type dataReader
    '(Lecture sequentielle de haut en bas uniquement)
    Public Function ExecuteRequete(ByVal LaRequete As String, ByVal conn As MySqlConnection) As MySqlDataReader
        'Creation d'une variable objet de type commande connecter à la connection con 
        Dim Commande As MySqlCommand = conn.CreateCommand()
        'on affecte de la requete de type texte à la variable commande
        Commande.CommandText = LaRequete
        'definition d'un jeu d'enregistrement Enreg de type DataReader
        Dim Enreg As MySqlDataReader = Nothing
        Try
            Enreg = Commande.ExecuteReader()
        Catch Erreur As Exception
            MessageBox.Show(Erreur.Message)
        End Try
        Return Enreg
    End Function
End Class
