<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.vStrc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.vPnum = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.vLot = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.vSampno = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.vTest = New System.Windows.Forms.ComboBox()
        Me.bReload = New System.Windows.Forms.Button()
        Me.bSave = New System.Windows.Forms.Button()
        Me.lbLargeDS = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToOrderColumns = True
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(186, 12)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(615, 422)
        Me.grid.TabIndex = 0
        '
        'vStrc
        '
        Me.vStrc.Location = New System.Drawing.Point(59, 13)
        Me.vStrc.Name = "vStrc"
        Me.vStrc.Size = New System.Drawing.Size(49, 21)
        Me.vStrc.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Plant"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item"
        '
        'vPnum
        '
        Me.vPnum.Location = New System.Drawing.Point(59, 41)
        Me.vPnum.Name = "vPnum"
        Me.vPnum.Size = New System.Drawing.Size(121, 21)
        Me.vPnum.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Lot"
        '
        'vLot
        '
        Me.vLot.Location = New System.Drawing.Point(59, 68)
        Me.vLot.Name = "vLot"
        Me.vLot.Size = New System.Drawing.Size(121, 21)
        Me.vLot.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sample"
        '
        'vSampno
        '
        Me.vSampno.FormattingEnabled = True
        Me.vSampno.Location = New System.Drawing.Point(59, 95)
        Me.vSampno.Name = "vSampno"
        Me.vSampno.Size = New System.Drawing.Size(121, 21)
        Me.vSampno.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Analyte"
        '
        'vTest
        '
        Me.vTest.FormattingEnabled = True
        Me.vTest.Location = New System.Drawing.Point(59, 122)
        Me.vTest.Name = "vTest"
        Me.vTest.Size = New System.Drawing.Size(121, 21)
        Me.vTest.TabIndex = 9
        '
        'bReload
        '
        Me.bReload.Location = New System.Drawing.Point(33, 211)
        Me.bReload.Name = "bReload"
        Me.bReload.Size = New System.Drawing.Size(116, 23)
        Me.bReload.TabIndex = 11
        Me.bReload.Text = "Reload Exclusions"
        Me.bReload.UseVisualStyleBackColor = True
        '
        'bSave
        '
        Me.bSave.Location = New System.Drawing.Point(33, 249)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(116, 23)
        Me.bSave.TabIndex = 12
        Me.bSave.Text = "Save Changes"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'lbLargeDS
        '
        Me.lbLargeDS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbLargeDS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLargeDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLargeDS.Location = New System.Drawing.Point(33, 287)
        Me.lbLargeDS.Name = "lbLargeDS"
        Me.lbLargeDS.Size = New System.Drawing.Size(116, 36)
        Me.lbLargeDS.TabIndex = 13
        Me.lbLargeDS.Text = "Results Limited to 10,000 rows."
        Me.lbLargeDS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 411)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Clear Selection"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(33, 158)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 38)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Add Exclusions by Lot"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 446)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbLargeDS)
        Me.Controls.Add(Me.bSave)
        Me.Controls.Add(Me.bReload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.vTest)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.vSampno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.vLot)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.vPnum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.vStrc)
        Me.Controls.Add(Me.grid)
        Me.Name = "Form1"
        Me.Text = "FPQ Exclusions"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents vStrc As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents vPnum As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents vLot As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents vSampno As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents vTest As System.Windows.Forms.ComboBox
    Friend WithEvents bReload As System.Windows.Forms.Button
    Friend WithEvents bSave As System.Windows.Forms.Button
    Friend WithEvents lbLargeDS As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
