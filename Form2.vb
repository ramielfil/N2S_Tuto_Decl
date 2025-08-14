Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Public Class Form2

    ' 📦 Dataset pour stocker les données récupérées
    Public V_DataSet As DataSet

    ' 🔹 Commande SQL pour exécuter des requêtes
    Public V_SqlCommand As SqlCommand

    ' 🔄 Adaptateur SQL pour remplir le Dataset
    Public V_SqlDataAdapter As SqlDataAdapter

    ' 📜 DataReader pour lecture directe des données
    Public V_SqlDataReader As SqlDataReader

    ' 📝 Rapport DevExpress
    'Public V_Report As New XtraReport1

    ' 📌 Événement au chargement du formulaire
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rendre le champ N2S_DOS_ID non modifiable
        N2S_DOS_ID.Properties.ReadOnly = True
        ' Charger les références dans la combo
        F_LoadReferences()

        ' Charger les données dans le tableau principal
        F_LoadDosList()
    End Sub

    ' 📌 Fonction : Charger les données du tableau N2S_DOS dans le GridControl
    Public Sub F_LoadDosList()
        ' Vérifier la connexion à la base
        F_CheckConnection()

        ' Initialiser le Dataset
        V_DataSet = New DataSet

        ' Requête SQL pour récupérer les données du tableau N2S_DOS avec alias AS
        Dim V_SqlQuery As String =
            "SELECT N2S_DOS AS DOS, " &
            "N2S_MF_DOS AS MF_DOS, " &
            "N2S_DOS_ID AS DOS_ID, " &
            "N2S_TEL AS TEL, " &
            "N2S_ADR AS ADR, " &
            "N2S_VILLE AS VILLE " &
            "FROM N2S_DOS " &
            "ORDER BY N2S_DOS"

        Try
            ' Créer la commande SQL
            V_SqlCommand = New SqlCommand(V_SqlQuery, V_SqlConnection)

            ' Préparer l'adaptateur et remplir le Dataset
            V_SqlDataAdapter = New SqlDataAdapter(V_SqlCommand)
            V_SqlDataAdapter.Fill(V_DataSet, "N2S_DOS")

            ' Lier le Dataset au GridControl
            GridControl1.DataSource = V_DataSet.Tables("N2S_DOS")

            ' Afficher le footer pour les totaux/sommes si besoin
            GridView1.OptionsView.ShowFooter = True

            ' Rafraîchir le GridControl
            GridControl1.Refresh()

        Catch ex As Exception
            ' Afficher l'erreur en cas de problème
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ClearFields()
        N2S_DOS_ID.Text = ""
        N2S_DOS.Text = ""
        N2S_MF.Text = ""
        N2S_TEL.Text = ""
        N2S_ADR.Text = ""
        N2S_VILLE.Text = ""
    End Sub

    ' 📌 Fonction : Charger les références pour la combo AR_REF depuis N2S_DOS
    Public Sub F_LoadReferences()
        ' Vérifier la connexion à la base
        F_CheckConnection()

        ' Initialiser le Dataset
        V_DataSet = New DataSet

        ' Requête SQL pour remplir la combo avec alias AS
        Dim V_SqlQuery As String =
            "SELECT N2S_DOS AS DOS, " &
            "N2S_MF_DOS AS MF_DOS " &
            "FROM N2S_DOS " &
            "ORDER BY N2S_DOS"

        Try
            ' Créer la commande SQL
            V_SqlCommand = New SqlCommand(V_SqlQuery, V_SqlConnection)

            ' Préparer l'adaptateur et remplir le Dataset
            V_SqlDataAdapter = New SqlDataAdapter(V_SqlCommand)
            V_SqlDataAdapter.Fill(V_DataSet, "N2S_DOS")

            ' Rien à lier, TextEdit prend ce que l'utilisateur tape
            Dim DOSText As String = N2S_DOS.Text



        Catch ex As Exception
            ' Afficher l'erreur si un problème survient
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_01_Click(sender As Object, e As EventArgs) Handles BTN_01.Click
        Try
            F_CheckConnection()

            ' Vérifier que le numéro de téléphone n'existe pas déjà
            Dim checkSql As String = "SELECT COUNT(*) FROM N2S_DOS WHERE N2S_TEL = @TEL"
            Dim cmdCheck As New SqlCommand(checkSql, V_SqlConnection)
            cmdCheck.Parameters.AddWithValue("@TEL", N2S_TEL.Text)
            Dim count As Integer = CInt(cmdCheck.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Le numéro de téléphone existe déjà !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Récupérer le prochain ID
            Dim nextID As String = F_GetNextID()

            ' Requête d'insertion
            Dim insertSql As String = "INSERT INTO N2S_DOS (N2S_DOS_ID, N2S_DOS, N2S_MF_DOS, N2S_TEL, N2S_ADR, N2S_VILLE) " &
                                  "VALUES (@ID, @DOS, @MF_DOS, @TEL, @ADR, @VILLE)"
            Dim cmdInsert As New SqlCommand(insertSql, V_SqlConnection)
            cmdInsert.Parameters.AddWithValue("@ID", nextID)
            cmdInsert.Parameters.AddWithValue("@DOS", N2S_DOS.Text)
            cmdInsert.Parameters.AddWithValue("@MF_DOS", N2S_MF.Text)
            cmdInsert.Parameters.AddWithValue("@TEL", N2S_TEL.Text)
            cmdInsert.Parameters.AddWithValue("@ADR", N2S_ADR.Text)
            cmdInsert.Parameters.AddWithValue("@VILLE", N2S_VILLE.Text)
            cmdInsert.ExecuteNonQuery()

            ' Rafraîchir le tableau
            F_LoadDosList()

            ' Vider les champs
            ClearFields()

            MessageBox.Show("Insertion effectuée avec succès !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion : " & ex.Message)
        End Try
    End Sub


    Private Sub BTN_04_Click(sender As Object, e As EventArgs) Handles BTN_04.Click
        Try
            ' Vérifier la connexion
            F_CheckConnection()

            ' Recharger les données du GridControl
            F_LoadDosList()

            MessageBox.Show("Tableau rafraîchi avec succès !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Erreur lors du rafraîchissement : " & ex.Message)
        End Try
    End Sub

    Private Sub BTN_02_Click(sender As Object, e As EventArgs) Handles BTN_02.Click
        Try
            F_CheckConnection()

            If String.IsNullOrWhiteSpace(N2S_DOS_ID.Text) Then
                MessageBox.Show("Sélectionnez une ligne avant de modifier !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim updateSql As String = "UPDATE N2S_DOS SET " &
                                  "N2S_DOS = @DOS, " &
                                  "N2S_MF_DOS = @MF_DOS, " &
                                  "N2S_TEL = @TEL, " &
                                  "N2S_ADR = @ADR, " &
                                  "N2S_VILLE = @VILLE " &
                                  "WHERE N2S_DOS_ID = @ID"

            Dim cmdUpdate As New SqlCommand(updateSql, V_SqlConnection)
            cmdUpdate.Parameters.AddWithValue("@ID", N2S_DOS_ID.Text)
            cmdUpdate.Parameters.AddWithValue("@DOS", N2S_DOS.Text)
            cmdUpdate.Parameters.AddWithValue("@MF_DOS", N2S_MF.Text)
            cmdUpdate.Parameters.AddWithValue("@TEL", N2S_TEL.Text)
            cmdUpdate.Parameters.AddWithValue("@ADR", N2S_ADR.Text)
            cmdUpdate.Parameters.AddWithValue("@VILLE", N2S_VILLE.Text)
            cmdUpdate.ExecuteNonQuery()

            ' Rafraîchir
            F_LoadDosList()

            ' Vider les champs
            ClearFields()

            MessageBox.Show("Modification effectuée avec succès !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la modification : " & ex.Message)
        End Try
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            ' Récupérer le GridView associé au GridControl
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridControl1.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Vérifier qu'on a bien une ligne sélectionnée
            Dim rowHandle As Integer = view.FocusedRowHandle
            If rowHandle >= 0 Then
                ' Remplir les TextEdit avec les valeurs de la ligne sélectionnée
                N2S_DOS_ID.Text = view.GetRowCellValue(rowHandle, "DOS_ID").ToString()

                N2S_DOS.Text = view.GetRowCellValue(rowHandle, "DOS").ToString()
                N2S_MF.Text = view.GetRowCellValue(rowHandle, "MF_DOS").ToString()
                N2S_TEL.Text = view.GetRowCellValue(rowHandle, "TEL").ToString()
                N2S_ADR.Text = view.GetRowCellValue(rowHandle, "ADR").ToString()
                N2S_VILLE.Text = view.GetRowCellValue(rowHandle, "VILLE").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la sélection : " & ex.Message)
        End Try
    End Sub

    Private Sub BTN_03_Click(sender As Object, e As EventArgs) Handles BTN_03.Click
        Try
            F_CheckConnection()

            ' Récupérer le GridView actif
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridControl1.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim rowHandle As Integer = view.FocusedRowHandle

            If rowHandle < 0 Then
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Récupérer l'ID de la ligne sélectionnée
            Dim selectedID As Integer = CInt(view.GetRowCellValue(rowHandle, "DOS_ID"))

            ' Confirmer suppression
            If MessageBox.Show("Voulez-vous vraiment supprimer ce dossier ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub

            ' Suppression
            Dim deleteSql As String = "DELETE FROM N2S_DOS WHERE N2S_DOS_ID = @ID"
            Dim cmdDelete As New SqlCommand(deleteSql, V_SqlConnection)
            cmdDelete.Parameters.AddWithValue("@ID", selectedID)
            cmdDelete.ExecuteNonQuery()
            'MessageBox.Show("ID à supprimer : " & selectedID)
            ' Rafraîchir
            F_LoadDosList()

            ' Vider les champs
            ClearFields()

            MessageBox.Show("Dossier supprimé avec succès !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression : " & ex.Message)
        End Try
    End Sub


End Class
