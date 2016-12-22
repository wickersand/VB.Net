<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graphic_Table_Form
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChartProgGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChartWeeklyGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnFecharGraphic = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ChartProgGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ChartWeeklyGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChartProgGraph)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(578, 314)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Programming Overall"
        '
        'ChartProgGraph
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartProgGraph.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ChartProgGraph.Legends.Add(Legend1)
        Me.ChartProgGraph.Location = New System.Drawing.Point(7, 20)
        Me.ChartProgGraph.Name = "ChartProgGraph"
        Me.ChartProgGraph.Size = New System.Drawing.Size(565, 288)
        Me.ChartProgGraph.TabIndex = 0
        Me.ChartProgGraph.Text = "Prog_Overall_Graph"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChartWeeklyGraph)
        Me.GroupBox2.Location = New System.Drawing.Point(716, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(578, 314)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Weekly Capacity"
        '
        'ChartWeeklyGraph
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartWeeklyGraph.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.ChartWeeklyGraph.Legends.Add(Legend2)
        Me.ChartWeeklyGraph.Location = New System.Drawing.Point(7, 20)
        Me.ChartWeeklyGraph.Name = "ChartWeeklyGraph"
        Me.ChartWeeklyGraph.Size = New System.Drawing.Size(565, 288)
        Me.ChartWeeklyGraph.TabIndex = 0
        Me.ChartWeeklyGraph.Text = "Weekly_Cap_Graph"
        '
        'btnFecharGraphic
        '
        Me.btnFecharGraphic.Location = New System.Drawing.Point(1232, 566)
        Me.btnFecharGraphic.Name = "btnFecharGraphic"
        Me.btnFecharGraphic.Size = New System.Drawing.Size(75, 23)
        Me.btnFecharGraphic.TabIndex = 2
        Me.btnFecharGraphic.Text = "Fechar"
        Me.btnFecharGraphic.UseVisualStyleBackColor = True
        '
        'Graphic_Table_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1319, 601)
        Me.Controls.Add(Me.btnFecharGraphic)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Graphic_Table_Form"
        Me.Text = "Graphic_Table"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ChartProgGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ChartWeeklyGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChartProgGraph As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChartWeeklyGraph As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnFecharGraphic As System.Windows.Forms.Button
End Class
