Public Class Graphic_Table_Form

    'Testando sistema de plot de arquivo CSV para Chart em VB.Net
    Dim C_CSVCreate As New CSV_Creator_Form 'Forma de acesso do form Main

    Private Sub btnFecharGraphic_Click(sender As Object, e As EventArgs) Handles btnFecharGraphic.Click

        Me.Close()

    End Sub

    Private Sub ChartProgGraph_Click(sender As Object, e As EventArgs) Handles ChartProgGraph.Click

        ChartProgGraph.DataSource = CSVReader(C_CSVCreate.GetFileLocation())

        ChartProgGraph.Series.Add("PASSED")
        ChartProgGraph.Series("PASSED").XValueMember = "PASSED"

        ChartProgGraph.Series.Add("REJECT")
        ChartProgGraph.Series("REJECT").YValueMembers = "REJECT"

        ChartProgGraph.DataBind()

    End Sub


    Private Function CSVReader(ByVal strData As String) As DataTable

        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strData)

        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(";")

        Dim TextFileTable As DataTable = Nothing

        Dim Column As DataColumn
        Dim Row As DataRow
        Dim UpperBound As Int32
        Dim ColumnCount As Int32
        Dim CurrentRow As String()

        Dim strAux() As String


        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    ''# Check if DataTable has been created
                    If TextFileTable Is Nothing Then
                        TextFileTable = New DataTable("TextFileTable")
                        ''# Get number of columns
                        UpperBound = CurrentRow.GetUpperBound(0)
                        ''# Create new DataTable
                        For ColumnCount = 0 To UpperBound
                            Column = New DataColumn()
                            Column.DataType = System.Type.GetType("System.String")
                            'Column.ColumnName = "Column" & ColumnCount
                            'Column.Caption = "Column" & ColumnCount
                            If 2 = TextFileReader.LineNumber Then
                                Array.Resize(strAux, UpperBound + 1)
                                strAux(ColumnCount) = CurrentRow(ColumnCount)
                            End If
                            Column.ColumnName = CurrentRow(ColumnCount)
                            Column.Caption = CurrentRow(ColumnCount)
                            Column.ReadOnly = True
                            Column.Unique = False
                            TextFileTable.Columns.Add(Column)
                        Next
                    End If
                    Row = TextFileTable.NewRow
                    For ColumnCount = 0 To UpperBound
                        'Row("Column" & ColumnCount) = CurrentRow(ColumnCount).ToString
                        'Row(CurrentRow(ColumnCount)) = CurrentRow(ColumnCount).ToString
                        Row(strAux(ColumnCount)) = CurrentRow(ColumnCount).ToString
                    Next
                    TextFileTable.Rows.Add(Row)
                End If
            Catch ex As  _
            Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & _
                "is not valid and will be skipped.")
            End Try
        End While
        TextFileReader.Dispose()

        Return TextFileTable

    End Function


End Class