<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImportExcel
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImportExcel))
        Me.TileBar1 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.BTN_ChoisirFichier = New DevExpress.XtraEditors.SimpleButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TileBar2 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ComboBoxFeuilles = New System.Windows.Forms.ComboBox()
        Me.BTN_ImportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_EnregistrerBDD = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileBar1
        '
        Me.TileBar1.BackColor = System.Drawing.SystemColors.Control
        Me.TileBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar1.Location = New System.Drawing.Point(0, 0)
        Me.TileBar1.Name = "TileBar1"
        Me.TileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar1.Size = New System.Drawing.Size(800, 150)
        Me.TileBar1.TabIndex = 0
        Me.TileBar1.Text = "TileBar1"
        '
        'BTN_ChoisirFichier
        '
        Me.BTN_ChoisirFichier.ImageOptions.Image = CType(resources.GetObject("BTN_ChoisirFichier.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_ChoisirFichier.Location = New System.Drawing.Point(12, 12)
        Me.BTN_ChoisirFichier.Name = "BTN_ChoisirFichier"
        Me.BTN_ChoisirFichier.Size = New System.Drawing.Size(171, 44)
        Me.BTN_ChoisirFichier.TabIndex = 1
        Me.BTN_ChoisirFichier.Text = "Choisir fichier Excel"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TileBar2
        '
        Me.TileBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileBar2.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar2.Location = New System.Drawing.Point(0, 150)
        Me.TileBar2.Name = "TileBar2"
        Me.TileBar2.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar2.Size = New System.Drawing.Size(800, 300)
        Me.TileBar2.TabIndex = 2
        Me.TileBar2.Text = "TileBar2"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 150)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(800, 300)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'ComboBoxFeuilles
        '
        Me.ComboBoxFeuilles.FormattingEnabled = True
        Me.ComboBoxFeuilles.Location = New System.Drawing.Point(242, 24)
        Me.ComboBoxFeuilles.Name = "ComboBoxFeuilles"
        Me.ComboBoxFeuilles.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxFeuilles.TabIndex = 4
        '
        'BTN_ImportExcel
        '
        Me.BTN_ImportExcel.ImageOptions.Image = CType(resources.GetObject("BTN_ImportExcel.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_ImportExcel.Location = New System.Drawing.Point(400, 12)
        Me.BTN_ImportExcel.Name = "BTN_ImportExcel"
        Me.BTN_ImportExcel.Size = New System.Drawing.Size(171, 44)
        Me.BTN_ImportExcel.TabIndex = 5
        Me.BTN_ImportExcel.Text = "Importer dans Grid"
        '
        'BTN_EnregistrerBDD
        '
        Me.BTN_EnregistrerBDD.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_EnregistrerBDD.Location = New System.Drawing.Point(614, 12)
        Me.BTN_EnregistrerBDD.Name = "BTN_EnregistrerBDD"
        Me.BTN_EnregistrerBDD.Size = New System.Drawing.Size(154, 44)
        Me.BTN_EnregistrerBDD.TabIndex = 6
        Me.BTN_EnregistrerBDD.Text = "Enregistrer"
        '
        'FormImportExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTN_EnregistrerBDD)
        Me.Controls.Add(Me.BTN_ImportExcel)
        Me.Controls.Add(Me.ComboBoxFeuilles)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.TileBar2)
        Me.Controls.Add(Me.BTN_ChoisirFichier)
        Me.Controls.Add(Me.TileBar1)
        Me.Name = "FormImportExcel"
        Me.Text = "Form3"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TileBar1 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents BTN_ChoisirFichier As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TileBar2 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ComboBoxFeuilles As ComboBox
    Friend WithEvents BTN_ImportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_EnregistrerBDD As DevExpress.XtraEditors.SimpleButton
End Class
