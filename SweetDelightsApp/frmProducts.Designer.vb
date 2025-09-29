<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducts
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
        Me.dgvCakes = New System.Windows.Forms.DataGridView()
        Me.dgvIcing = New System.Windows.Forms.DataGridView()
        Me.dgvTopping = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvIcings = New System.Windows.Forms.TextBox()
        Me.dgvToppings = New System.Windows.Forms.TextBox()
        CType(Me.dgvCakes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIcing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTopping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCakes
        '
        Me.dgvCakes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCakes.Location = New System.Drawing.Point(256, 32)
        Me.dgvCakes.Name = "dgvCakes"
        Me.dgvCakes.Size = New System.Drawing.Size(407, 128)
        Me.dgvCakes.TabIndex = 0
        '
        'dgvIcing
        '
        Me.dgvIcing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIcing.Location = New System.Drawing.Point(256, 166)
        Me.dgvIcing.Name = "dgvIcing"
        Me.dgvIcing.Size = New System.Drawing.Size(407, 126)
        Me.dgvIcing.TabIndex = 1
        '
        'dgvTopping
        '
        Me.dgvTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTopping.Location = New System.Drawing.Point(256, 298)
        Me.dgvTopping.Name = "dgvTopping"
        Me.dgvTopping.Size = New System.Drawing.Size(407, 129)
        Me.dgvTopping.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(58, 68)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 81)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CAKES"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvIcings
        '
        Me.dgvIcings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIcings.Location = New System.Drawing.Point(58, 189)
        Me.dgvIcings.Multiline = True
        Me.dgvIcings.Name = "dgvIcings"
        Me.dgvIcings.Size = New System.Drawing.Size(112, 77)
        Me.dgvIcings.TabIndex = 4
        Me.dgvIcings.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ICING"
        Me.dgvIcings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvToppings
        '
        Me.dgvToppings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvToppings.Location = New System.Drawing.Point(58, 320)
        Me.dgvToppings.Multiline = True
        Me.dgvToppings.Name = "dgvToppings"
        Me.dgvToppings.Size = New System.Drawing.Size(112, 82)
        Me.dgvToppings.TabIndex = 5
        Me.dgvToppings.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TOPPINGS"
        Me.dgvToppings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvToppings)
        Me.Controls.Add(Me.dgvIcings)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dgvTopping)
        Me.Controls.Add(Me.dgvIcing)
        Me.Controls.Add(Me.dgvCakes)
        Me.Name = "frmProducts"
        Me.Text = "Products"
        CType(Me.dgvCakes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIcing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTopping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCakes As DataGridView
    Friend WithEvents dgvIcing As DataGridView
    Friend WithEvents dgvTopping As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents dgvIcings As TextBox
    Friend WithEvents dgvToppings As TextBox
End Class
