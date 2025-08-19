Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports DevExpress.XtraPrinting.Native.WebClientUIControl
Imports Newtonsoft.Json
Imports OfficeOpenXml
Public Class FormImportExcel

    ' 🔹 Variables
    Private filePath As String ' chemin complet du fichier Excel

    ' ===================== Bouton Choisir Fichier =====================
    Private Sub BTN_ChoisirFichier_Click(sender As Object, e As EventArgs) Handles BTN_ChoisirFichier.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Fichiers Excel|*.xlsx;*.xls"
            If ofd.ShowDialog() = DialogResult.OK Then
                filePath = ofd.FileName

                ' 🔹 Affichage chemin complet et nom du fichier
                TxtFilePath.Text = filePath
                TxtFileName.Text = Path.GetFileName(filePath)

                ' 🔹 Vider et remplir ComboBox avec les feuilles
                ComboBoxFeuilles.Items.Clear()
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Using package As New ExcelPackage(New FileInfo(filePath))
                    For Each ws As ExcelWorksheet In package.Workbook.Worksheets
                        ComboBoxFeuilles.Items.Add(ws.Name)
                    Next
                End Using

                If ComboBoxFeuilles.Items.Count > 0 Then
                    ComboBoxFeuilles.SelectedIndex = 0
                End If

                MessageBox.Show("Fichier chargé avec succès !")
            End If
        End Using
    End Sub

    ' ===================== Bouton Importer Excel dans Grid =====================
    Private Sub BTN_ImportExcel_Click(sender As Object, e As EventArgs) Handles BTN_ImportExcel.Click
        If String.IsNullOrEmpty(filePath) Then
            MessageBox.Show("Veuillez choisir un fichier Excel d'abord.")
            Exit Sub
        End If
        If ComboBoxFeuilles.SelectedItem Is Nothing Then
            MessageBox.Show("Veuillez sélectionner une feuille à importer.")
            Exit Sub
        End If

        Dim dt As DataTable = LireFeuilleExcel(ComboBoxFeuilles.SelectedItem.ToString())
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    ' ===================== Fonction utilitaire : Lire une feuille Excel =====================
    Private Function LireFeuilleExcel(sheetName As String) As DataTable
        Dim dt As New DataTable()
        Using package As New ExcelPackage(New FileInfo(filePath))
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets(sheetName)
            ' Colonnes à partir de la première ligne
            For col As Integer = 1 To ws.Dimension.End.Column
                dt.Columns.Add(ws.Cells(1, col).Text)
            Next
            ' Remplir les lignes
            For row As Integer = 2 To ws.Dimension.End.Row
                Dim newRow As DataRow = dt.NewRow()
                For col As Integer = 1 To ws.Dimension.End.Column
                    newRow(col - 1) = ws.Cells(row, col).Text
                Next
                dt.Rows.Add(newRow)
            Next
        End Using
        Return dt
    End Function

    ' ===================== Fonctions utilitaires pour Grid =====================
    Private Function GetGridValue(rowIndex As Integer, columnName As String) As String
        Return If(GridView1.GetRowCellValue(rowIndex, columnName)?.ToString().Trim(), "")
    End Function

    Private Function ConvertToInteger(value As String) As Integer
        Dim result As Integer
        If Not Integer.TryParse(value, result) Then result = 0
        Return result
    End Function

    Private Function ConvertToDateOrDbNull(value As String) As Object
        Dim tempDate As Date
        Return If(Date.TryParse(value, tempDate), CType(tempDate, Object), DBNull.Value)
    End Function

    Private Function IdExiste(id As Integer) As Boolean
        Using cmd As New SqlCommand("SELECT COUNT(*) FROM N2S_CLIENTS WHERE Id = @Id", V_SqlConnection)
            cmd.Parameters.AddWithValue("@Id", id)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Sub InsererClient(id As Integer, prenom As String, nom As String, sexe As String,
                              pays As String, age As Integer, dateDoc As Object)
        Using cmd As New SqlCommand(
            "INSERT INTO N2S_CLIENTS (Id, Prenom, Nom, Sexe, Pays, Age, DateDoc) " &
            "VALUES (@Id, @Prenom, @Nom, @Sexe, @Pays, @Age, @DateDoc)", V_SqlConnection)

            cmd.Parameters.AddWithValue("@Id", id)
            cmd.Parameters.AddWithValue("@Prenom", prenom)
            cmd.Parameters.AddWithValue("@Nom", nom)
            cmd.Parameters.AddWithValue("@Sexe", sexe)
            cmd.Parameters.AddWithValue("@Pays", pays)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@DateDoc", dateDoc)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' ===================== Bouton Enregistrer dans la Base =====================
    Private Sub BTN_EnregistrerBDD_Click(sender As Object, e As EventArgs) Handles BTN_EnregistrerBDD.Click
        If GridView1.RowCount = 0 Then
            MessageBox.Show("Aucune ligne à insérer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        F_CheckConnection()  ' Vérifier la connexion

        Dim lignesInserees As Integer = 0
        Dim lignesIgnorees As Integer = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                ' Récupérer toutes les valeurs de la ligne
                Dim nom As String = GetGridValue(i, "Nom")
                Dim prenom As String = GetGridValue(i, "Prenom")
                Dim sexe As String = GetGridValue(i, "Sexe")
                Dim pays As String = GetGridValue(i, "Pays")
                Dim age As Integer = ConvertToInteger(GetGridValue(i, "Age"))
                Dim dateDoc As Object = ConvertToDateOrDbNull(GetGridValue(i, "DateDoc"))
                Dim id As Integer = ConvertToInteger(GetGridValue(i, "Id"))

                ' Ignorer ligne vide
                If String.IsNullOrEmpty(nom) AndAlso String.IsNullOrEmpty(prenom) AndAlso
                   String.IsNullOrEmpty(sexe) AndAlso String.IsNullOrEmpty(pays) AndAlso
                   age = 0 AndAlso dateDoc Is DBNull.Value AndAlso id = 0 Then Continue For

                ' Vérifier si ID existe
                If IdExiste(id) Then
                    lignesIgnorees += 1
                    Continue For
                End If

                ' Insérer le client
                InsererClient(id, prenom, nom, sexe, pays, age, dateDoc)
                lignesInserees += 1
            Next

            ' Afficher le résultat final
            MessageBox.Show($"{lignesInserees} ligne(s) insérée(s)." & Environment.NewLine &
                            $"{lignesIgnorees} ligne(s) ignorée(s) car ID déjà existant.",
                            "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Async Sub BTN_EnvoyerAPI_Click(sender As Object, e As EventArgs) Handles BTN_EnvoyerAPI.Click
        ' 🔹 Vérifier qu'il y a des données dans le Grid
        If GridView1.RowCount = 0 Then
            MessageBox.Show("Aucune ligne à envoyer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' 🔹 Créer la liste d'objets à envoyer
        Dim dataToSend As New List(Of Object)

        For i As Integer = 0 To GridView1.RowCount - 1
            Dim nom As String = GetGridValue(i, "Nom")
            Dim prenom As String = GetGridValue(i, "Prenom")

            Dim age As Integer = ConvertToInteger(GetGridValue(i, "Age"))

            ' Ignorer ligne vide
            If String.IsNullOrEmpty(nom) AndAlso String.IsNullOrEmpty(prenom) AndAlso age = 0 Then Continue For

            ' Ajouter chaque ligne comme objet JSON
            dataToSend.Add(New With {
               Key .title = nom,
               Key .body = prenom.ToString(),
               Key .userId = age
           })


        Next

        If dataToSend.Count = 0 Then
            MessageBox.Show("Aucune donnée valide à envoyer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' 🔹 Convertir en JSON
        Dim jsonData As String = JsonConvert.SerializeObject(dataToSend)

        ' 🔹 URL du web service test
        Dim apiUrl As String = "https://jsonplaceholder.typicode.com/posts"

        Using client As New HttpClient()
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            Try
                ' 🔹 Envoyer les données en POST
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' 🔹 Vérifier le résultat
                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Données envoyées avec succès !" & Environment.NewLine & responseString,
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erreur API :" & Environment.NewLine &
                                    "Code HTTP : " & CInt(response.StatusCode) & Environment.NewLine &
                                    "Réponse : " & responseString,
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Erreur lors de l'envoi à l'API : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
