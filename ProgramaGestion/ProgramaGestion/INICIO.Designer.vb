<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INICIO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INICIO))
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement5 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement6 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement7 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement8 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement9 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem1 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem3 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem5 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TileGroup3 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem7 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem6 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem8 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem9 = New DevExpress.XtraEditors.TileItem()
        Me.SuspendLayout()
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'TileControl1
        '
        Me.TileControl1.AllowItemHover = True
        Me.TileControl1.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TileControl1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black
        Me.TileControl1.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileControl1.AppearanceItem.Normal.Options.UseForeColor = True
        Me.TileControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileControl1.Groups.Add(Me.TileGroup2)
        Me.TileControl1.Groups.Add(Me.TileGroup3)
        Me.TileControl1.Location = New System.Drawing.Point(0, 0)
        Me.TileControl1.MaxId = 12
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.ShowText = True
        Me.TileControl1.Size = New System.Drawing.Size(748, 402)
        Me.TileControl1.TabIndex = 0
        Me.TileControl1.Text = "TileControl1"
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileItem1)
        Me.TileGroup2.Items.Add(Me.TileItem2)
        Me.TileGroup2.Items.Add(Me.TileItem3)
        Me.TileGroup2.Items.Add(Me.TileItem5)
        Me.TileGroup2.Items.Add(Me.TileItem4)
        Me.TileGroup2.Name = "TileGroup2"
        '
        'TileItem1
        '
        TileItemElement1.ImageOptions.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        TileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement1.Text = "STOCK"
        Me.TileItem1.Elements.Add(TileItemElement1)
        Me.TileItem1.Id = 0
        Me.TileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem1.Name = "TileItem1"
        '
        'TileItem2
        '
        TileItemElement2.ImageOptions.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
        TileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement2.Text = "CLIENTES"
        Me.TileItem2.Elements.Add(TileItemElement2)
        Me.TileItem2.Id = 1
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem2.Name = "TileItem2"
        '
        'TileItem3
        '
        TileItemElement3.ImageOptions.Image = CType(resources.GetObject("resource.Image2"), System.Drawing.Image)
        TileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement3.Text = "VENTAS"
        Me.TileItem3.Elements.Add(TileItemElement3)
        Me.TileItem3.Id = 4
        Me.TileItem3.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem3.Name = "TileItem3"
        '
        'TileItem5
        '
        TileItemElement4.ImageOptions.Image = CType(resources.GetObject("resource.Image3"), System.Drawing.Image)
        TileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement4.Text = "CAJA"
        Me.TileItem5.Elements.Add(TileItemElement4)
        Me.TileItem5.Id = 6
        Me.TileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem5.Name = "TileItem5"
        '
        'TileItem4
        '
        TileItemElement5.ImageOptions.Image = CType(resources.GetObject("resource.Image4"), System.Drawing.Image)
        TileItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement5.Text = "LISTA DE PRECIOS"
        Me.TileItem4.Elements.Add(TileItemElement5)
        Me.TileItem4.Id = 9
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem4.Name = "TileItem4"
        '
        'TileGroup3
        '
        Me.TileGroup3.Items.Add(Me.TileItem7)
        Me.TileGroup3.Items.Add(Me.TileItem6)
        Me.TileGroup3.Items.Add(Me.TileItem8)
        Me.TileGroup3.Items.Add(Me.TileItem9)
        Me.TileGroup3.Name = "TileGroup3"
        '
        'TileItem7
        '
        TileItemElement6.ImageOptions.Image = CType(resources.GetObject("resource.Image5"), System.Drawing.Image)
        TileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement6.Text = "DATOS EMPRESA"
        Me.TileItem7.Elements.Add(TileItemElement6)
        Me.TileItem7.Id = 8
        Me.TileItem7.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem7.Name = "TileItem7"
        '
        'TileItem6
        '
        TileItemElement7.ImageOptions.Image = CType(resources.GetObject("resource.Image6"), System.Drawing.Image)
        TileItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement7.Text = "USUARIOS"
        Me.TileItem6.Elements.Add(TileItemElement7)
        Me.TileItem6.Id = 7
        Me.TileItem6.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem6.Name = "TileItem6"
        '
        'TileItem8
        '
        TileItemElement8.ImageOptions.Image = CType(resources.GetObject("resource.Image7"), System.Drawing.Image)
        TileItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement8.Text = "ACTIVAR"
        Me.TileItem8.Elements.Add(TileItemElement8)
        Me.TileItem8.Id = 10
        Me.TileItem8.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem8.Name = "TileItem8"
        '
        'TileItem9
        '
        TileItemElement9.ImageOptions.Image = CType(resources.GetObject("resource.Image8"), System.Drawing.Image)
        TileItemElement9.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement9.Text = "CAMBIAR USUARIO"
        Me.TileItem9.Elements.Add(TileItemElement9)
        Me.TileItem9.Id = 11
        Me.TileItem9.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem9.Name = "TileItem9"
        Me.TileItem9.Visible = False
        '
        'INICIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(748, 402)
        Me.Controls.Add(Me.TileControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "INICIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INICIO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem1 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem2 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem3 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem5 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem6 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem7 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileGroup3 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem8 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem9 As DevExpress.XtraEditors.TileItem
End Class
