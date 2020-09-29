<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddByLot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ViolOnly = New System.Windows.Forms.CheckBox()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Analyte = New System.Windows.Forms.ComboBox()
        Me.LotNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ViolOnly
        '
        Me.ViolOnly.AutoSize = True
        Me.ViolOnly.Location = New System.Drawing.Point(195, 9)
        Me.ViolOnly.Name = "ViolOnly"
        Me.ViolOnly.Size = New System.Drawing.Size(95, 17)
        Me.ViolOnly.TabIndex = 12
        Me.ViolOnly.Text = "Violations Only"
        Me.ViolOnly.UseVisualStyleBackColor = True
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(12, 35)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(734, 329)
        Me.grid.TabIndex = 14
        '
        'Analyte
        '
        Me.Analyte.FormattingEnabled = True
        Me.Analyte.Location = New System.Drawing.Point(379, 7)
        Me.Analyte.Name = "Analyte"
        Me.Analyte.Size = New System.Drawing.Size(177, 21)
        Me.Analyte.TabIndex = 13
        '
        'LotNumber
        '
        Me.LotNumber.Location = New System.Drawing.Point(59, 7)
        Me.LotNumber.Name = "LotNumber"
        Me.LotNumber.Size = New System.Drawing.Size(100, 20)
        Me.LotNumber.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Lot"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(311, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Analyte"
        '
        'AddByLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 378)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ViolOnly)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Analyte)
        Me.Controls.Add(Me.LotNumber)
        Me.Name = "AddByLot"
        Me.Text = "AddByLot"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ViolOnly As System.Windows.Forms.CheckBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents Analyte As System.Windows.Forms.ComboBox
    Friend WithEvents LotNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
