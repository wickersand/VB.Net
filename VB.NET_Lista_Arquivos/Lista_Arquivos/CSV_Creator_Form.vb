Imports System.IO.File
Imports System.IO.Directory
Imports System.Security
Imports System.IO
Imports System.Text
Imports System.Array


Public Class CSV_Creator_Form

    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Dim strVersion As String = Application.ProductVersion

    Private strConfigFile As String = ""
    Private m_strFileLocation As String = "F:\Temp\Test.CSV"

    Private Const strPROGRAM As String = "PROGRAM"
    Private Const strVerProg As String = "Version"
    Private Const strProgVerNumber As String = "1.0.0.0"


    'Get Config INI File Data (Usando arquivo INI como referência)
    Public Function LoadINIFile() As Integer
        Dim strAux As String = ""
        Dim nStatus As Integer = -1
        Dim arguments As String() = Environment.GetCommandLineArgs()
        Dim strINIFileName As String = "CONFIG_DATA.INI"

        If arguments.Length > 1 Then

            If My.Computer.FileSystem.FileExists(arguments(1)) Then

                strConfigFile = arguments(1)
                nStatus = 0

            Else

                MsgBox("Arquivo: " & arguments(1) & "Invalido! Verifique a linha de comando!")
                nStatus = -1

            End If

        ElseIf My.Computer.FileSystem.FileExists(strINIFileName) Then

            strConfigFile = strINIFileName
            nStatus = 0

        Else

            MsgBox("Arquivo de configuração não encontrado!")
            nStatus = -1

        End If

        If 0 = nStatus Then

            If strVersion = ReadINIFile(strConfigFile, strPROGRAM, strVerProg, strProgVerNumber) Then
                nStatus = 0

            Else

                MsgBox("Arquivo de configuração incompatível com a versão atual do programa: " & strVersion)
                nStatus = -1

            End If

        End If

        'If 0 = nStatus Then

        'Verifica se irá coletar cada informação.
        'num_DPHFixed = CInt(ReadINIFile(strConfigFile, "RECIPE", "DPHFIXED", "1"))
        'num_24HDayCap = CInt(ReadINIFile(strConfigFile, "RECIPE", "24HDAYCAP", "1"))
        'num_WeekCap = CInt(ReadINIFile(strConfigFile, "RECIPE", "WEEKCAP", "1"))

        Return nStatus

        'End If


    End Function

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click

        If MessageBox.Show("Deseja Sair?", "Encerrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Refresh()
            Application.Exit()

        Else
            Me.ListBox1.Items.Clear() 'Limpando o campo do ListBox
            TextBox1.Text = "" ' Limpando o campo do TextBox1
            ListBox1.Text = "" ' Limpando os dados do ListBox1

        End If
    End Sub

    Private Sub btnSelecionarArquivos_Click(sender As Object, e As EventArgs) Handles btnSelecionarArquivos.Click

        'Usado para detectar arquivos!!!!
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Selecionar Arquivo"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.DefaultExt = "log" 'Predefinição de Arquivo durante a inicialização
        'OpenFileDialog1.Filter = "log files (*.log) | *.txt | All Files (*.*) | *.*" 'Exibe somente os arquivos *.log
        OpenFileDialog1.Filter = "log files (*.log) | *.*" 'Exibe somente os arquivos *.log
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True 'Abre localizador
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.ShowReadOnly = True

        TextBox1.Text = OpenFileDialog1.FileName 'Mostra nome do arquivo ou pasta no campo Local...não está funfando... =/

        Dim DR As DialogResult = Me.OpenFileDialog1.ShowDialog()

        If DR = System.Windows.Forms.DialogResult.OK Then

            Try
                For Each Arquivo As String In OpenFileDialog1.FileNames 'Le os arquivos selecionados

                    ListBox1.Items.Add(Arquivo)

                Next

                btnCriarCSV.Enabled = True

            Catch ex As Exception

                MessageBox.Show((("Erro: Não foi possível abrir o arquivo!" & vbLf & vbLf & "Mensagem: ") + ex.Message & vbLf & vbLf & "Detalhes (Testes): " & vbLf & vbLf) + ex.StackTrace)

            End Try

        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        'Cria variável ItemSelected do arquivo selecionado dentro do ListBox
        Dim ItemSelected As String = ListBox1.SelectedItem.ToString()

        'Modifica o endereço do TextBox1 utilizando a String do nome do arquivo!
        TextBox1.Text = ItemSelected

        'Remove informação do campo Label2
        Label2.Visible = False

    End Sub

    Private Sub btnCriarCSV_Click(sender As Object, e As EventArgs) Handles btnCriarCSV.Click

        Dim strContentData As String = ""
        Dim strDados As String = ""
        Dim nStatus As Integer = -99979

        nStatus = TrataArquivo(strDados)

        Dim strLine() As String = Split(strDados, vbCrLf, True)

        'Header do arquivo CSV
        Dim strResultFinalData As String = "DATE" & ";" & "PROJECT NAME" & ";" & "PASSED" & ";" & "REJECT" & ";" & "YIELD" & ";" & "DPH FIXED" & ";" & "CAPACITY 24H DAY" & ";" & "CAPACITY WEEKLY" & ";" & "MACHINE UTILIZATION" & vbCrLf

        'Array com tamanho igual ao strLine
        Dim strCalcResult(strLine.Length() - 1) As String

        'Numero Fixo de base de calculo
        Dim num_DPHFixed As Integer = 720

        'Iniciando as Variáveis
        Dim num_Cap24HDay As Integer = num_DPHFixed * 24
        Dim num_CapWeekly As Integer = num_Cap24HDay * 7
        Dim num_MachineUtil As Integer = 0
        Dim strAux As String = ""
        Dim strListaProdutos() As String = Split(OpenFile(".\config\produtos.txt"), vbCrLf)



        'Variáveis dos resultados
        Dim aux_Cap24HResult As Integer = 0 'Multiplicar DHPFixo por 24
        Dim aux_CapWeeklyResult As Integer = 0 'Multiplicar 24H por 7
        Dim aux_MachineUtilResult As Integer = 0 ' Dividir qty Passed pelo Cap 24H Day

        For nCount As Integer = 1 To strLine.Length() - 1

            Dim strInfo() As String = Split(strLine(nCount), ";")

            strAux = strInfo(1)

            If "" <> strLine(nCount) Then
                Dim strvalues() As String = Split(strLine(nCount), ";", True)

                If 0 <> strvalues(2) Then

                    'Calculando MachineUtil
                    'strCalcResult(nCount) = (CLng(strvalues(2)) / num_Cap24HDay) * 100 & "%" 'Alterando de número decimal para porcentagem.

                    For Each Product In strListaProdutos

                        If strInfo(1).Contains(Product) = True Then

                            strAux = Product

                            Exit For

                        End If

                    Next
                    '                                          "DATE" & ";" & "PROJECT NAME" & ";" & "PASSED" & ";" & "REJECT" & ";" & "YIELD" & ";" & "DPH FIXED" & ";" & "CAPACITY 24H DAY" & ";" & "CAPACITY WEEKLY" & ";" & "MACHINE UTILIZATION"
                    strResultFinalData = strResultFinalData & strInfo(0) & ";" & strAux & ";" & strInfo(2) & ";" & strInfo(3) & ";" & strInfo(4).Replace(".", ",") & ";" & num_DPHFixed & ";" & num_Cap24HDay & ";" & num_CapWeekly & ";" & strCalcResult(nCount) & vbCrLf

                End If

            End If

        Next

        SaveFile(GetFileLocation(), strResultFinalData) 'Salva arquivo tratado...
        btnCriarCSV.Enabled = False 'Desabilita o botão.

        'Me.Close() 'Fecha o Form

    End Sub
    Private Function TrataArquivo(ByRef strResultFinalData As String) As Integer

        Dim strContentData As String = ""

        Dim nStatus As Integer = -99989 'Tratamento de falha.

        Try
            For Each File In Me.ListBox1.Items
                strContentData = ""

                nStatus = -99988

                If FileExist(File) Then

                    strContentData = OpenFile(File)

                    'Adiciona de forma sequencial os dados em colunas no Excel.
                    strResultFinalData = strResultFinalData & vbCrLf & GetData(GetInfoFromFileLog(strContentData, "Date Logged:")) & ";" & GetInfoFromFileLog(strContentData, "Task Name:") & ";" & GetInfoFromFileLog(strContentData, "Devices Passed:") & ";" & GetInfoFromFileLog(strContentData, "Devices Failed:") & ";" & GetInfoFromFileLog(strContentData, "Overall Device Yield:")
                    nStatus = 0

                End If
            Next

        Catch ex As Exception

        End Try

        Return nStatus

    End Function

    Private Function GetInfoFromFileLog(ByVal strFileData As String, ByVal strKey As String) As String

        Dim strAux As String = ""
        Dim strLine() As String = Split(strFileData.ToUpper, vbCrLf)
        For Each e In strLine
            If e.Contains(strKey.ToUpper) Then
                strAux = e.Replace(strKey.ToUpper, "").TrimStart.TrimEnd
                Exit For
            End If
        Next

        Return strAux

    End Function

    Private Function GetData(ByVal strGetData As String) As String

        Dim strAux As String = ""

        If strGetData.Length > 0 Then

            strAux = strGetData.Substring(0, strGetData.IndexOf(" ")).Replace("-", "/")

        End If

        Return strAux

    End Function

    Public Function OpenFile(ByVal strFileName) As String
        Dim FILE_NAME As String = strFileName
        Dim strErrMsg As String = ""

        Try

            Dim strFileContent As String = ""


            If "" <> FILE_NAME Then

                Dim objReader As New System.IO.StreamReader(FILE_NAME)

                strFileContent = objReader.ReadToEnd

                objReader.Close()

            End If


            Return strFileContent
        Catch
            strErrMsg = "Erro ao Abrir o arquivo: " & strFileName
            Return ""

        End Try
    End Function

    Public Function SaveFile(ByVal strPath As String, ByVal strText As String) As Integer
        Dim strAux As String = strPath

        Try
            If Not My.Computer.FileSystem.DirectoryExists(strAux.Substring(0, strAux.LastIndexOf("\") + 1)) Then
                My.Computer.FileSystem.CreateDirectory(strAux.Substring(0, strAux.LastIndexOf("\") + 1))
            End If
            If True = My.Computer.FileSystem.FileExists(strAux) Then
                My.Computer.FileSystem.DeleteFile(strAux)
            End If
            My.Computer.FileSystem.WriteAllText(strAux, strText, False, Encoding.Default)

            Me.ListBox1.Items.Clear() 'Limpando o campo do ListBox
            TextBox1.Text = "" ' Limpando o campo do TextBox1
            ListBox1.Text = "" ' Limpando os dados do ListBox1

            MsgBox("Arquivo criado com sucesso!" & vbCrLf & "Local do arquivo: " & strAux)
            Return 0

        Catch
            MsgBox("Não foi possivel criar o arquivo:  " & strAux & vbCrLf & "Verifique se o arquivo está aberto." & vbCrLf & "Feche-o para criar um novo arquivo.")
            Return -1
        End Try

    End Function

    Public Function MoveFile(ByVal strOrig As String, ByVal strDest As String) As Integer

        Try
            If True = My.Computer.FileSystem.FileExists(strOrig) Then
                If True = My.Computer.FileSystem.FileExists(strDest) Then
                    My.Computer.FileSystem.DeleteFile(strDest)
                End If
                My.Computer.FileSystem.MoveFile(strOrig, strDest, True)
                Return 0
            Else
                MsgBox("Arquivo Temporario não encontrado!")
                Return -9985
            End If
        Catch
            MsgBox("Erro ao criar log de testes no servidor!")
            Return -9986
        End Try

    End Function

    Public Function CopyFile(ByVal strOrig As String, ByVal strDest As String) As Integer

        Try
            If True = My.Computer.FileSystem.FileExists(strOrig) Then
                If True = My.Computer.FileSystem.FileExists(strDest) Then
                    My.Computer.FileSystem.DeleteFile(strDest)
                End If
                My.Computer.FileSystem.CopyFile(strOrig, strDest, True)
                Return 0
            Else
                MsgBox("Arquivo Temporario não encontrado!")
                Return -9987
            End If
        Catch
            MsgBox("Erro ao criar backup de log em: ")
            Return -9988
        End Try

    End Function

    Public Function SaveFile(ByVal strPath As String, ByVal strText As String, ByVal strSep As String) As Integer
        Dim strAux() As String = Split(strPath, strSep)
        Dim strTextToLog As String = ""
        Dim nCount As Integer = 0


        Try
            While nCount < strAux.Length
                If Not My.Computer.FileSystem.DirectoryExists(strAux(nCount).Substring(0, strAux(nCount).LastIndexOf("\") + 1)) Then
                    My.Computer.FileSystem.CreateDirectory(strAux(nCount).Substring(0, strAux(nCount).LastIndexOf("\") + 1))
                End If
                If True = My.Computer.FileSystem.FileExists(strAux(nCount)) Then
                    My.Computer.FileSystem.DeleteFile(strAux(nCount))
                End If
                My.Computer.FileSystem.WriteAllText(strAux(nCount), strText, False, Encoding.Default)
                nCount = nCount + 1
            End While

            Return 0
        Catch
            MsgBox("Não foi possivel criar o arquivo:  " & strAux(nCount))
            Return -1
        End Try

    End Function

    Private Function CheckPath(ByVal strPath As String) As String

        If Not (("/" = strPath.Substring(strPath.Length - 1)) Or ("\" = strPath.Substring(strPath.Length - 1))) Then
            Return strPath & "\"
        Else
            Return strPath
        End If
    End Function

    'Check if File Exist
    Public Function FileExist(ByVal strFile As String) As Boolean
        If My.Computer.FileSystem.FileExists(strFile) Then
            Return True
        Else
            Return False
        End If
    End Function

    'Usa a função GetProvateProfileString para obter os valores
    Private Function ReadINIFile(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)

        Return string_builder.ToString()

    End Function

    Private Function WriteINIFile(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As Integer

        Dim nStatus As Integer = -99999 'Tratamento de falha.
        Try

            nStatus = WritePrivateProfileString(section_name, key_name, default_value, file_name)

        Catch ex As Exception

        End Try

        Return nStatus

    End Function

    Private Sub btnMostraGraphic_Click(sender As Object, e As EventArgs) Handles btnMostraGraphic.Click

        Dim Graphic_Form As New Graphic_Table_Form()

        Graphic_Form.Show()

    End Sub

    'Metodo GET
    Public Function GetFileLocation() As String

        Return m_strFileLocation

    End Function

    'Metodo SET
    Private Sub SetFileLocation(ByVal strData As String)

        m_strFileLocation = strData.ToUpper

    End Sub


End Class
