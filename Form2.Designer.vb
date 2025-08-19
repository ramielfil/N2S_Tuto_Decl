<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.TileBar1 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.TileBar2 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BTN_01 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_02 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_03 = New DevExpress.XtraEditors.SimpleButton()
        Me.N2S_DOS = New DevExpress.XtraEditors.TextEdit()
        Me.N2S_TEL = New DevExpress.XtraEditors.TextEdit()
        Me.N2S_VILLE = New DevExpress.XtraEditors.TextEdit()
        Me.N2S_ADR = New DevExpress.XtraEditors.TextEdit()
        Me.N2S_MF = New DevExpress.XtraEditors.TextEdit()
        Me.BTN_04 = New DevExpress.XtraEditors.SimpleButton()
        Me.N2S_DOS_ID = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_DOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_TEL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_VILLE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_ADR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_MF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N2S_DOS_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileBar1
        '
        Me.TileBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar1.Location = New System.Drawing.Point(0, 0)
        Me.TileBar1.Name = "TileBar1"
        Me.TileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar1.Size = New System.Drawing.Size(800, 150)
        Me.TileBar1.TabIndex = 0
        Me.TileBar1.Text = "TileBar1"
        '
        'TileBar2
        '
        Me.TileBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileBar2.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar2.Location = New System.Drawing.Point(0, 150)
        Me.TileBar2.Name = "TileBar2"
        Me.TileBar2.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar2.Size = New System.Drawing.Size(800, 300)
        Me.TileBar2.TabIndex = 1
        Me.TileBar2.Text = "TileBar2"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 150)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(800, 300)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 20)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Dos"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(206, 26)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 20)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "MF"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(12, 66)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(30, 20)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "TEL"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(206, 69)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(62, 20)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Adresse"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(12, 110)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(32, 20)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Ville"
        '
        'BTN_01
        '
        Me.BTN_01.ImageOptions.Image = CType(resources.GetObject("BTN_01.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_01.Location = New System.Drawing.Point(618, 11)
        Me.BTN_01.Name = "BTN_01"
        Me.BTN_01.Size = New System.Drawing.Size(102, 32)
        Me.BTN_01.TabIndex = 13
        Me.BTN_01.Text = "Ajouter"
        '
        'BTN_02
        '
        Me.BTN_02.ImageOptions.Image = CType(resources.GetObject("BTN_02.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_02.Location = New System.Drawing.Point(618, 49)
        Me.BTN_02.Name = "BTN_02"
        Me.BTN_02.Size = New System.Drawing.Size(102, 32)
        Me.BTN_02.TabIndex = 14
        Me.BTN_02.Text = "Modifier"
        '
        'BTN_03
        '
        Me.BTN_03.ImageOptions.Image = CType(resources.GetObject("BTN_03.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_03.Location = New System.Drawing.Point(618, 87)
        Me.BTN_03.Name = "BTN_03"
        Me.BTN_03.Size = New System.Drawing.Size(102, 32)
        Me.BTN_03.TabIndex = 15
        Me.BTN_03.Text = "Supprimer"
        '
        'N2S_DOS
        '
        Me.N2S_DOS.Location = New System.Drawing.Point(60, 23)
        Me.N2S_DOS.Name = "N2S_DOS"
        Me.N2S_DOS.Size = New System.Drawing.Size(125, 22)
        Me.N2S_DOS.TabIndex = 16
        '
        'N2S_TEL
        '
        Me.N2S_TEL.Location = New System.Drawing.Point(60, 67)
        Me.N2S_TEL.Name = "N2S_TEL"
        Me.N2S_TEL.Size = New System.Drawing.Size(125, 22)
        Me.N2S_TEL.TabIndex = 17
        '
        'N2S_VILLE
        '
        Me.N2S_VILLE.Location = New System.Drawing.Point(60, 110)
        Me.N2S_VILLE.Name = "N2S_VILLE"
        Me.N2S_VILLE.Size = New System.Drawing.Size(125, 22)
        Me.N2S_VILLE.TabIndex = 18
        '
        'N2S_ADR
        '
        Me.N2S_ADR.Location = New System.Drawing.Point(274, 67)
        Me.N2S_ADR.Name = "N2S_ADR"
        Me.N2S_ADR.Size = New System.Drawing.Size(125, 22)
        Me.N2S_ADR.TabIndex = 20
        '
        'N2S_MF
        '
        Me.N2S_MF.Location = New System.Drawing.Point(274, 23)
        Me.N2S_MF.Name = "N2S_MF"
        Me.N2S_MF.Size = New System.Drawing.Size(125, 22)
        Me.N2S_MF.TabIndex = 19
        '
        'BTN_04
        '
        Me.BTN_04.ImageOptions.Image = CType(resources.GetObject("BTN_04.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_04.Location = New System.Drawing.Point(745, 12)
        Me.BTN_04.Name = "BTN_04"
        Me.BTN_04.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.BTN_04.Size = New System.Drawing.Size(43, 29)
        Me.BTN_04.TabIndex = 21
        '
        'N2S_DOS_ID
        '
        Me.N2S_DOS_ID.Location = New System.Drawing.Point(274, 104)
        Me.N2S_DOS_ID.Name = "N2S_DOS_ID"
        Me.N2S_DOS_ID.Size = New System.Drawing.Size(125, 22)
        Me.N2S_DOS_ID.TabIndex = 22
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.N2S_DOS_ID)
        Me.Controls.Add(Me.BTN_04)
        Me.Controls.Add(Me.N2S_ADR)
        Me.Controls.Add(Me.N2S_MF)
        Me.Controls.Add(Me.N2S_VILLE)
        Me.Controls.Add(Me.N2S_TEL)
        Me.Controls.Add(Me.N2S_DOS)
        Me.Controls.Add(Me.BTN_03)
        Me.Controls.Add(Me.BTN_02)
        Me.Controls.Add(Me.BTN_01)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.TileBar2)
        Me.Controls.Add(Me.TileBar1)
        Me.Name = "Form2"
        Me.Text = "Paramétrage dossier "
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_DOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_TEL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_VILLE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_ADR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_MF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N2S_DOS_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TileBar1 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents TileBar2 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BTN_01 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_02 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_03 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents N2S_DOS As DevExpress.XtraEditors.TextEdit
    Friend WithEvents N2S_TEL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents N2S_VILLE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents N2S_ADR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents N2S_MF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BTN_04 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents N2S_DOS_ID As DevExpress.XtraEditors.TextEdit
End Class
