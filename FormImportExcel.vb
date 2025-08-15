Imports OfficeOpenXml
Imports System.IO
Imports System.Data.SqlClient

Public Class FormImportExcel

    Private filePath As String ' chemin du fichier Excel

    ' Bouton pour choisir le fichier Excel
    Private Sub BTN_ChoisirFichier_Click(sender As Object, e As EventArgs) Handles BTN_ChoisirFichier.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Fichiers Excel|*.xlsx;*.xls"
            If ofd.ShowDialog() = DialogResult.OK Then
                filePath = ofd.FileName

                ' Vider la ComboBox avant de remplir
                ComboBoxFeuilles.Items.Clear()

                ' Définir le contexte de licence EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial

                ' Charger les feuilles du fichier Excel
                Using package As New ExcelPackage(New FileInfo(filePath))
                    For Each ws As ExcelWorksheet In package.Workbook.Worksheets
                        ComboBoxFeuilles.Items.Add(ws.Name)
                    Next
                End Using

                ' Sélectionner la première feuille par défaut
                If ComboBoxFeuilles.Items.Count > 0 Then
                    ComboBoxFeuilles.SelectedIndex = 0
                End If

                MessageBox.Show("Fichier chargé avec succès !")
            End If
        End Using
    End Sub

    ' Bouton pour importer les données dans le GridControl
    Private Sub BTN_ImportExcel_Click(sender As Object, e As EventArgs) Handles BTN_ImportExcel.Click
        ' Vérifier qu'un fichier est choisi
        If String.IsNullOrEmpty(filePath) Then
            MessageBox.Show("Veuillez choisir un fichier Excel d'abord.")
            Exit Sub
        End If

        ' Vérifier qu'une feuille est sélectionnée
        If ComboBoxFeuilles.SelectedItem Is Nothing Then
            MessageBox.Show("Veuillez sélectionner une feuille à importer.")
            Exit Sub
        End If

        Dim sheetName As String = ComboBoxFeuilles.SelectedItem.ToString()
        Dim dt As New DataTable()

        Using package As New ExcelPackage(New FileInfo(filePath))
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets(sheetName)

            ' Créer les colonnes du DataTable à partir de la première ligne Excel
            For col As Integer = 1 To ws.Dimension.End.Column
                dt.Columns.Add(ws.Cells(1, col).Text)
            Next

            ' Parcourir les lignes et remplir le DataTable
            For row As Integer = 2 To ws.Dimension.End.Row
                Dim newRow As DataRow = dt.NewRow()
                For col As Integer = 1 To ws.Dimension.End.Column
                    newRow(col - 1) = ws.Cells(row, col).Text
                Next
                dt.Rows.Add(newRow)
            Next
        End Using

        ' Lier le DataTable au GridControl
        GridControl1.DataSource = dt
        GridView1.BestFitColumns() ' ajuste la largeur des colonnes

        'MessageBox.Show("Importation terminée !")
    End Sub

    Private Sub BTN_EnregistrerBDD_Click(sender As Object, e As EventArgs) Handles BTN_EnregistrerBDD.Click
        ' Vérifier si le GridControl contient des lignes
        If GridView1.RowCount = 0 Then
            MessageBox.Show("Aucune ligne à insérer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Vérifier la connexion existante
        F_CheckConnection()

        Dim lignesInserees As Integer = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                ' Lire les valeurs depuis GridView1
                Dim nom As String = If(GridView1.GetRowCellValue(i, "Nom")?.ToString(), "").Trim()
                Dim prenom As String = If(GridView1.GetRowCellValue(i, "Prenom")?.ToString(), "").Trim()
                Dim sexe As String = If(GridView1.GetRowCellValue(i, "Sexe")?.ToString(), "").Trim()
                Dim pays As String = If(GridView1.GetRowCellValue(i, "Pays")?.ToString(), "").Trim()
                Dim ageStr As String = If(GridView1.GetRowCellValue(i, "Age")?.ToString(), "").Trim()
                Dim dateStr As String = If(GridView1.GetRowCellValue(i, "DateDoc")?.ToString(), "").Trim()
                Dim idStr As String = If(GridView1.GetRowCellValue(i, "Id")?.ToString(), "").Trim()

                ' Ignorer la ligne si toutes les colonnes sont vides
                If String.IsNullOrEmpty(nom) AndAlso String.IsNullOrEmpty(prenom) AndAlso
                   String.IsNullOrEmpty(sexe) AndAlso String.IsNullOrEmpty(pays) AndAlso
                   String.IsNullOrEmpty(ageStr) AndAlso String.IsNullOrEmpty(dateStr) AndAlso
                   String.IsNullOrEmpty(idStr) Then
                    Continue For
                End If

                ' Conversion sécurisée
                Dim age As Integer
                If Not Integer.TryParse(ageStr, age) Then age = 0

                ' Conversion sécurisée pour la date
                Dim dateDoc As Object
                Dim tempDate As Date
                If Date.TryParse(dateStr, tempDate) Then
                    dateDoc = tempDate
                Else
                    dateDoc = DBNull.Value  ' Met NULL dans la base si la date est invalide
                End If


                Dim id As Integer
                If Not Integer.TryParse(idStr, id) Then id = 0

                ' Commande SQL avec la connexion existante
                Dim query As String = "INSERT INTO N2S_CLIENTS (Id, Prenom, Nom, Sexe, Pays, Age, DateDoc) " &
                                      "VALUES (@Id, @Prenom, @Nom, @Sexe, @Pays, @Age, @DateDoc)"

                Using cmd As New SqlCommand(query, V_SqlConnection)
                    cmd.Parameters.AddWithValue("@Id", id)
                    cmd.Parameters.AddWithValue("@Prenom", prenom)
                    cmd.Parameters.AddWithValue("@Nom", nom)
                    cmd.Parameters.AddWithValue("@Sexe", sexe)
                    cmd.Parameters.AddWithValue("@Pays", pays)
                    cmd.Parameters.AddWithValue("@Age", age)
                    cmd.Parameters.AddWithValue("@DateDoc", dateDoc)

                    lignesInserees += cmd.ExecuteNonQuery()
                End Using
            Next

            MessageBox.Show($"{lignesInserees} ligne(s) insérée(s) avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

