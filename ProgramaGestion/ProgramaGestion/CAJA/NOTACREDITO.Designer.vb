<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DEVOLUCION
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DEVOLUCION))
        Dim DataViewProperty7 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Dim DataViewProperty8 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Dim DataViewProperty9 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Dim DataViewProperty10 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Dim DataViewProperty11 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Dim DataViewProperty12 As DevExpress.Xpo.DataViewProperty = New DevExpress.Xpo.DataViewProperty()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.XpDataView1 = New DevExpress.Xpo.XPDataView(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colidDetalle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colidVenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArticulo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrecioUni = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrecioTot = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpDataView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.IsSplitterFixed = True
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TextEdit2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TextEdit1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl1.Size = New System.Drawing.Size(805, 711)
        Me.SplitContainerControl1.SplitterPosition = 88
        Me.SplitContainerControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(512, 25)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(121, 46)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "ANULAR"
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(85, 54)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Size = New System.Drawing.Size(358, 20)
        Me.TextEdit2.TabIndex = 3
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(240, 22)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(64, 20)
        Me.TextEdit1.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(24, 55)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(55, 16)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "MOTIVO:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(24, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(210, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "INGRESE NÚMERO DE OPERACIÓN:"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.XpDataView1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(805, 617)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'XpDataView1
        '
        DataViewProperty7.Name = "idDetalle"
        DataViewProperty7.ValueType = GetType(Integer)
        DataViewProperty8.Name = "idVenta"
        DataViewProperty8.ValueType = GetType(Integer)
        DataViewProperty9.Name = "Articulo"
        DataViewProperty9.ValueType = GetType(String)
        DataViewProperty10.Name = "Cantidad"
        DataViewProperty10.ValueType = GetType(Integer)
        DataViewProperty11.Name = "PrecioUni"
        DataViewProperty11.ValueType = GetType(Decimal)
        DataViewProperty12.Name = "PrecioTot"
        DataViewProperty12.ValueType = GetType(Decimal)
        Me.XpDataView1.Properties.AddRange(New DevExpress.Xpo.DataViewProperty() {DataViewProperty7, DataViewProperty8, DataViewProperty9, DataViewProperty10, DataViewProperty11, DataViewProperty12})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colidDetalle, Me.colidVenta, Me.colArticulo, Me.colCantidad, Me.colPrecioUni, Me.colPrecioTot})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colidDetalle
        '
        Me.colidDetalle.FieldName = "idDetalle"
        Me.colidDetalle.Name = "colidDetalle"
        '
        'colidVenta
        '
        Me.colidVenta.FieldName = "idVenta"
        Me.colidVenta.Name = "colidVenta"
        '
        'colArticulo
        '
        Me.colArticulo.Caption = "ARTICULO"
        Me.colArticulo.FieldName = "Articulo"
        Me.colArticulo.Name = "colArticulo"
        Me.colArticulo.Visible = True
        Me.colArticulo.VisibleIndex = 0
        '
        'colCantidad
        '
        Me.colCantidad.Caption = "CANTIDAD"
        Me.colCantidad.FieldName = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "TOTAL ARTICULOS = {0}")})
        Me.colCantidad.Visible = True
        Me.colCantidad.VisibleIndex = 1
        '
        'colPrecioUni
        '
        Me.colPrecioUni.Caption = "PRECIO"
        Me.colPrecioUni.FieldName = "PrecioUni"
        Me.colPrecioUni.Name = "colPrecioUni"
        Me.colPrecioUni.Visible = True
        Me.colPrecioUni.VisibleIndex = 2
        '
        'colPrecioTot
        '
        Me.colPrecioTot.Caption = "PRECIO TOTAL"
        Me.colPrecioTot.FieldName = "PrecioTot"
        Me.colPrecioTot.Name = "colPrecioTot"
        Me.colPrecioTot.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrecioTot", "TOTAL = {0}")})
        Me.colPrecioTot.Visible = True
        Me.colPrecioTot.VisibleIndex = 3
        '
        'DEVOLUCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(805, 711)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DEVOLUCION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Credito"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpDataView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XpDataView1 As DevExpress.Xpo.XPDataView
    Friend WithEvents colidDetalle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colidVenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArticulo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrecioUni As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrecioTot As DevExpress.XtraGrid.Columns.GridColumn
End Class
