<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCustomers = New System.Windows.Forms.Button()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomers
        '
        Me.btnCustomers.BackColor = System.Drawing.SystemColors.Info
        Me.btnCustomers.Location = New System.Drawing.Point(55, 166)
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Size = New System.Drawing.Size(190, 150)
        Me.btnCustomers.TabIndex = 0
        Me.btnCustomers.Text = "MANAGE CUSTOMERS"
        Me.btnCustomers.UseVisualStyleBackColor = False
        '
        'btnOrders
        '
        Me.btnOrders.BackColor = System.Drawing.SystemColors.Info
        Me.btnOrders.Location = New System.Drawing.Point(297, 166)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(190, 150)
        Me.btnOrders.TabIndex = 1
        Me.btnOrders.Text = "MANAGE ORDERS"
        Me.btnOrders.UseVisualStyleBackColor = False
        '
        'btnProducts
        '
        Me.btnProducts.BackColor = System.Drawing.SystemColors.Info
        Me.btnProducts.Location = New System.Drawing.Point(545, 166)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(190, 150)
        Me.btnProducts.TabIndex = 2
        Me.btnProducts.Text = "VIEW CAKES, ICING" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AND TOPPINGS"
        Me.btnProducts.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnProducts)
        Me.Controls.Add(Me.btnOrders)
        Me.Controls.Add(Me.btnCustomers)
        Me.Name = "frmMain"
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCustomers As Button
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnProducts As Button
End Class
