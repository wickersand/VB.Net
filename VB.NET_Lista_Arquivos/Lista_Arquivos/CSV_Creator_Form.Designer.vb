<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSV_Creator_Form
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelecionarArquivos = New System.Windows.Forms.Button()
        Me.btnCriarCSV = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnMostraGraphic = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Local:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(100, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(396, 20)
        Me.TextBox1.TabIndex = 1
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(475, 325)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(102, 23)
        Me.btnSair.TabIndex = 6
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(504, 225)
        Me.ListBox1.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(61, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 271)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Arquivos Listados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(477, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'btnSelecionarArquivos
        '
        Me.btnSelecionarArquivos.Location = New System.Drawing.Point(502, 12)
        Me.btnSelecionarArquivos.Name = "btnSelecionarArquivos"
        Me.btnSelecionarArquivos.Size = New System.Drawing.Size(75, 27)
        Me.btnSelecionarArquivos.TabIndex = 9
        Me.btnSelecionarArquivos.Text = "Procurar"
        Me.btnSelecionarArquivos.UseVisualStyleBackColor = True
        '
        'btnCriarCSV
        '
        Me.btnCriarCSV.Enabled = False
        Me.btnCriarCSV.Location = New System.Drawing.Point(61, 325)
        Me.btnCriarCSV.Name = "btnCriarCSV"
        Me.btnCriarCSV.Size = New System.Drawing.Size(110, 23)
        Me.btnCriarCSV.TabIndex = 11
        Me.btnCriarCSV.Text = "Criar Arquivo CSV"
        Me.btnCriarCSV.UseVisualStyleBackColor = True
        '
        'btnMostraGraphic
        '
        Me.btnMostraGraphic.Location = New System.Drawing.Point(177, 325)
        Me.btnMostraGraphic.Name = "btnMostraGraphic"
        Me.btnMostraGraphic.Size = New System.Drawing.Size(110, 23)
        Me.btnMostraGraphic.TabIndex = 12
        Me.btnMostraGraphic.Text = "Criar Gráfico"
        Me.btnMostraGraphic.UseVisualStyleBackColor = True
        '
        'CSV_Creator_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 360)
        Me.Controls.Add(Me.btnMostraGraphic)
        Me.Controls.Add(Me.btnCriarCSV)
        Me.Controls.Add(Me.btnSelecionarArquivos)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CSV_Creator_Form"
        Me.Text = "CSV File Creator - PS388 Graphics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelecionarArquivos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCriarCSV As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnMostraGraphic As System.Windows.Forms.Button

End Class
