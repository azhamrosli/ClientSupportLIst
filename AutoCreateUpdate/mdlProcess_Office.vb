Imports System.Data.SQLite
Imports System.Text
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Data.SqlClient
Imports Microsoft.AspNet.SignalR.Client

Module mdlProcess_Office
    Dim ADO As SQLDataObject
    Dim cmd As SqlCommand
    Dim SqlCon As SqlConnection
    Public LicenseType As Integer = 0
    Public V1 As Integer = 2
    Public V2 As Integer = 3
    Public V3 As Integer = 6
    Public V4 As Integer = 0
    'Public connection As HubConnection = New HubConnection("http://localhost:63739/signalr")
    Public connection As HubConnection = New HubConnection("http://www.arsoftwaremalaysia.com/signalr")
    Public myHub As IHubProxy = connection.CreateHubProxy("hitCounter")


    Async Sub startConnect()
        Try

            Await connection.Start()
            Await myHub.Invoke("OnConnectedChat", My.Computer.Name)
            '   Await myHub.Invoke("send", My.Computer.Name, "Hello")
        Catch ex As Exception
            MsgBox("Failed to start service signal R", MsgBoxStyle.Critical)
        End Try

    End Sub
    Async Sub chatConnect()
        Try
            If connection.State = ConnectionState.Connecting Or connection.State = ConnectionState.Disconnected Then
                Await connection.Start()
            End If

            Await myHub.Invoke("OnConnectedChat", My.Computer.Name)
        Catch ex As Exception
            MsgBox("Failed start chat service" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Async Sub disConnect()
        Try
            Await myHub.Invoke("OnDisconnected", True)
            connection.Stop()
        Catch ex As Exception
            MsgBox("Failed stop chat service" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Async Sub SendNotification(ByVal ComName As String)
        Try
            Await myHub.Invoke("sendnotification", My.Computer.Name, ComName)

        Catch ex As Exception

        End Try
    End Sub
    Async Sub SendMessage(ByVal ComName As String)
        Try
            Await myHub.Invoke("Send", My.Computer.Name, ComName)
        Catch ex As Exception

        End Try
    End Sub
#Region "STRUCT"
    Public Const RegisterUserURL As String = "http://localhost:52310/pages/registeruser_confirm.html"
    Public Const ForgotPassURL As String = "http://localhost:52310/pages/forgotpass.html"
    Public SystemInfo As SystemDetails
    Structure SystemDetails
        Dim V1 As Integer
        Dim V2 As Integer
        Dim V3 As Integer
        Dim LicenseKey As String
        Dim ValidateUntil As DateTime
        Dim isActive As Integer
        Dim LicenseType As Integer
        Dim LicenseName As String
    End Structure
#End Region
#Region "DATABASE"
    Public Function DBConnection(ByRef sqlCon As SqlConnection, ByRef ErrorMsg As clsError) As Boolean
        Try
            Dim strCon As String = DBSetting()

            If strCon Is Nothing OrElse strCon = "" Then
                With ErrorMsg
                    .ErrorName = "DBConnection"
                    .ErrorCode = "DB10001"
                    .ErrorDateTime = Now
                    .ErrorMessage = "Connection String Empty"
                End With
                Return False
            End If

            Dim Con As New SqlConnection(strCon)
            If Con.State = System.Data.ConnectionState.Closed Then
                Con.Open()
            End If

            sqlCon = Con
            Return True
        Catch ex As Exception
            With ErrorMsg
                .ErrorName = "DBConnection"
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function DBSetting() As String
        Try
            'If My.Settings.isFirstTime = True Then
            '    My.Settings.isFirstTime = False
            '    'My.Settings.dbPath = "Data Source=" & Application.StartupPath & "\Database\dbYGLEfilling.db"
            '    'My.Settings.Save()
            '    'My.Settings.Reload()
            '    'Return My.Settings.dbPath
            '    Dim Server As String = My.Settings.ServerName
            '    Dim Database As String = My.Settings.DatabaseName
            '    Dim UserID As String = My.Settings.UserID
            '    Dim Pass As String = DecriptPass(My.Settings.Password)

            '    Return "Server=" & Server & ";Database=" & Database & ";User Id=" & UserID & ";Password=" & Pass & ";"
            'Else
            '    Dim Server As String = My.Settings.ServerName
            '    Dim Database As String = My.Settings.DatabaseName
            '    Dim UserID As String = My.Settings.UserID
            '    Dim Pass As String = DecriptPass(My.Settings.Password)

            '    Return "Server=" & Server & ";Database=" & Database & ";User Id=" & UserID & ";Password=" & Pass & ";"
            'End If
            Return "Server=175.136.230.74,11443;Database=taxcom;User Id=taxcom;Password=P@$$w0rd;"
            ' Return System.Configuration.ConfigurationManager.ConnectionStrings("dbEmployeeManagementConnectionString").ConnectionString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region "ENCRYPT DECRYPT"
    Public Function EncryptPass(ByVal Password As String) As String
        Try
            Dim plainText As String = Password

            Dim passPhrase As String
            Dim saltValue As String
            Dim hashAlgorithm As String
            Dim passwordIterations As Integer
            Dim initVector As String
            Dim keySize As Integer

            '  plainText = "Hello, World!"     ' original plaintext

            passPhrase = "Pas5pr@se"        ' can be any string
            saltValue = "Azh@m1"         ' can be any string
            hashAlgorithm = "SHA1"          ' can be "MD5"
            passwordIterations = 2          ' can be any number
            initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                   ' can be 192 or 128

            Return RijndaelSimple.Encrypt _
             ( _
                 plainText, _
                 passPhrase, _
                 saltValue, _
                 hashAlgorithm, _
                 passwordIterations, _
                 initVector, _
                 keySize _
             )
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Public Function DecriptPass(ByVal Password As String) As String
        Try
            Dim cipherText As String = Password

            Dim passPhrase As String
            Dim saltValue As String
            Dim hashAlgorithm As String
            Dim passwordIterations As Integer
            Dim initVector As String
            Dim keySize As Integer

            '  plainText = "Hello, World!"     ' original plaintext

            passPhrase = "Pas5pr@se"        ' can be any string
            saltValue = "Azh@m1"         ' can be any string
            hashAlgorithm = "SHA1"          ' can be "MD5"
            passwordIterations = 2          ' can be any number
            initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                   ' can be 192 or 128

            Return RijndaelSimple.Decrypt _
            ( _
                cipherText, _
                passPhrase, _
                saltValue, _
                hashAlgorithm, _
                passwordIterations, _
                initVector, _
                keySize _
            )
        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
#End Region
#Region "LOAD"
#Region "PUBLIS USED"
    Public Function LoadSupport_ByID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT dbSupport.*,dbClient.*  FROM dbSupport INNER JOIN dbClient ON dbSupport.CompanyID=dbClient.ID WHERE dbSupport.ID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadComment_BySupportID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT *  FROM DBSUPPORT_COMMENT WHERE SupportID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadSupportLog_BySupportID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT *  FROM DBSUPPORT_LOG WHERE SupportID=" & ID & " ORDER BY DateTime DESC"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadComment_ByCountID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As Integer
        Try
            Dim StrSQL As String = "SELECT Count(*) as countx  FROM DBSUPPORT_COMMENT WHERE SupportID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso IsDBNull(dt.Rows(0)("countx")) = False Then
                Return dt.Rows(0)("countx")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadSupportAttachment_ByID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT *  FROM DBATTACHMENT WHERE SupportID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadSupportAttachment2_ByID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT ID FROM DBATTACHMENT WHERE SupportID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadSupportAttachmentCount_ByID(ByVal ID As Integer, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim StrSQL As String = "SELECT COUNT(ID) as countx  FROM DBATTACHMENT WHERE SupportID=" & ID


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return False
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso IsDBNull(dt.Rows(0)("countx")) = False AndAlso dt.Rows(0)("countx") > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return False
        End Try
    End Function
    Public Function LoadSupportTotalSupport(ByVal Type As Integer, Optional ByRef DateFrom As DateTime = Nothing, _
                                            Optional ByRef DateTo As DateTime = Nothing, Optional ByRef Errorlog As clsError = Nothing) As Integer
        Try
            Dim StrSQL As String = "SELECT COUNT(*) as countx FROM dbSupport WHERE DateTime >= @dtFrom AND DateTime <= @dtTo"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return 0
            End If

            cmd = New SqlCommand
            Select Case Type
                Case 0
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = CDate(Format(Now, "dd-MMM-yyyy 00:00:00"))
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = CDate(Format(Now, "dd-MMM-yyyy 23:59:59"))
                Case 1
                    DateFrom = CDate(Format(Now.AddDays(-7), "dd-MMM-yyyy 00:00:00"))
                    DateTo = CDate(Format(Now, "dd-MMM-yyyy 23:59:59"))
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = DateFrom
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = DateTo
                Case 2
                    Dim datLastDay As Date = GetLastDayOfMonth(Now.Month, Now.Year)
                    DateFrom = CDate(Format(Now, "01-MMM-yyyy 00:00:00"))
                    DateTo = CDate(Format(datLastDay, "dd-MMM-yyyy 23:59:59"))
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = DateFrom
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = DateTo
                Case 3
                    'Yesterday
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = CDate(Format(Now.AddDays(-1), "dd-MMM-yyyy 00:00:00"))
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = CDate(Format(Now.AddDays(-1), "dd-MMM-yyyy 23:59:59"))
                Case 4
                    'Yearly
                    Dim Firstyear As New DateTime(DateTime.Now.Year, 1, 1)
                    Dim Lastyear As New DateTime(DateTime.Now.Year, 12, 31)

                    DateFrom = Firstyear
                    DateTo = Lastyear
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = CDate(Format(DateFrom, "dd-MMM-yyyy 00:00:00"))
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = CDate(Format(DateTo, "dd-MMM-yyyy 23:59:59"))
                Case 5
                    'pending to testing
                    StrSQL += " AND Status=8"

                    Dim Firstyear As New DateTime(DateTime.Now.Year, 1, 1)
                    Dim Lastyear As New DateTime(DateTime.Now.Year, 12, 31)

                    DateFrom = Firstyear
                    DateTo = Lastyear
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = DateFrom
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = DateTo
                Case 6
                    'Bug only
                    StrSQL += " AND Status=5"

                    Dim Firstyear As New DateTime(DateTime.Now.Year, 1, 1)
                    Dim Lastyear As New DateTime(DateTime.Now.Year, 12, 31)

                    DateFrom = Firstyear
                    DateTo = Lastyear
                    cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = DateFrom
                    cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = DateTo

            End Select

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso IsDBNull(dt.Rows(0)("countx")) = False Then
                Return dt.Rows(0)("countx")
            Else
                Return 0
            End If
        Catch ex As Exception
            '  Errorlog = "ERROR : " & ex.Message

            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return 0
        End Try
    End Function
    Public Function LoadSupport(Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT dbSupport.*,dbClient.*  FROM dbSupport INNER JOIN dbClient ON dbSupport.CompanyID=dbClient.ID ORDER BY DateTime DESC"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadTopSupport(Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT TOP 3 DBCLIENT.CompanyName,dbSupport.CompanyID,Count(*) as countx FROM dbSupport INNER JOIN DBCLIENT ON DBCLIENT.ID=dbSupport.CompanyID WHERE CompanyID <> 'CLN-23052017114607CAA' GROUP BY dbSupport.CompanyID,DBCLIENT.CompanyName ORDER BY countx DESC"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadTopSupportReport(Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT DBCLIENT.CompanyName,dbSupport.CompanyID,Count(*) as countx FROM dbSupport INNER JOIN DBCLIENT ON DBCLIENT.ID=dbSupport.CompanyID WHERE CompanyID <> 'CLN-23052017114607CAA' GROUP BY dbSupport.CompanyID,DBCLIENT.CompanyName ORDER BY countx DESC"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadSupport_Search(ByVal RefID As String, ByVal Com As String, ByVal dtFrom As DateTime, ByVal dtTo As DateTime, _
                                ByVal Status As Integer, ByVal Person As String, Optional ByRef ErrorLog As clsError = Nothing) As DataTable
        Try
            ' Dim StrSQL As String = "SELECT dbSupport.*,dbClient.* FROM dbSupport INNER JOIN dbClient ON dbSupport.CompanyID=dbClient.ID"
            Dim StrSQL As String = "SELECT dbSupport.*,dbClient.* FROM dbSupport INNER JOIN dbClient ON dbSupport.CompanyID=dbClient.ID WHERE dbSupport.Status=1 UNION SELECT dbSupport.*,dbClient.* FROM dbSupport INNER JOIN dbClient ON dbSupport.CompanyID=dbClient.ID"
            Dim isWhere As Boolean = False


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, ErrorLog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            If isWhere = False Then
                isWhere = True
                StrSQL += " WHERE dbSupport.DateTime >=@dtFrom AND dbSupport.DateTime <=@dtTo"
                cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = CDate(Format(dtFrom, "dd-MMM-yyyy 00:00:00"))
                cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = CDate(Format(dtTo, "dd-MMM-yyyy 23:59:59"))
            Else
                StrSQL += " AND dbSupport.DateTime >=@dtFrom AND dbSupport.DateTime <=@dtTo"
                cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = CDate(Format(dtFrom, "dd-MMM-yyyy 00:00:00"))
                cmd.Parameters.Add("@dtTo", SqlDbType.DateTime).Value = CDate(Format(dtTo, "dd-MMM-yyyy 23:59:59"))
            End If


            If RefID IsNot Nothing AndAlso RefID <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE dbClient.RefID LIKE '%" & RefID & "%'"
                Else
                    StrSQL += " AND dbClient.RefID LIKE '%" & RefID & "%'"
                End If
            End If

            If Com IsNot Nothing AndAlso Com <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE dbClient.CompanyName LIKE '%" & Com & "%'"
                Else
                    StrSQL += " AND dbClient.CompanyName LIKE '%" & Com & "%'"
                End If
            End If

            If Person IsNot Nothing AndAlso Person <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE dbSupport.PersonName LIKE '%" & Person & "%'"
                Else
                    StrSQL += " AND dbSupport.PersonName LIKE '%" & Person & "%'"
                End If
            End If

            If Status <> -1 Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE dbSupport.Status=" & Status
                Else
                    StrSQL += " AND  dbSupport.Status=" & Status
                End If
            End If


            StrSQL += " ORDER BY DateTime DESC"
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, ErrorLog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If ErrorLog Is Nothing Then
                ErrorLog = New clsError
            End If

            With ErrorLog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With

            Return Nothing
        End Try
    End Function
    Public Function LoadClient(Optional isBan As Integer = 0, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT TOP 10 * FROM dbClient ORDER BY CompanyName"

            If isBan = 1 Then

                StrSQL += " isBan=1"

            End If

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadPreviousTeamviewerID(ByVal CompanyID As String, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT DISTINCT(TeamviewerID) as Datax FROM DBSupport WHERE CompanyID=@CompanyID"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = CompanyID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadPreviousPersonNameID(ByVal CompanyID As String, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT DISTINCT(PersonName) as Datax FROM DBSupport WHERE CompanyID=@CompanyID"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = CompanyID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadClient_ByID(ByVal ID As String, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT * FROM dbClient WHERE ID=@ID"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadClient_BySearch(ByVal CompanyName As String, ByVal ID As String, Optional isBan As Integer = 0, Optional TypeLicense As Integer = -1, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT * FROM dbClient"
            Dim isWhere As Boolean = False


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            If ID IsNot Nothing AndAlso ID <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE RefID LIKE '%" & ID & "%'"
                Else
                    StrSQL += " AND RefID LIKE '%" & ID & "%'"
                End If
            End If

            If CompanyName IsNot Nothing AndAlso CompanyName <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE CompanyName LIKE '%" & CompanyName & "%'"
                Else
                    StrSQL += " AND CompanyName LIKE '%" & CompanyName & "%'"
                End If
            End If

            If isBan = 1 Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE isBan=1"
                Else
                    StrSQL += " AND isBan=1"
                End If
            End If

            If TypeLicense <> -1 Then
                Dim tmpstr As String = ""
                Dim tmpVal As String = "0"

                Select Case TypeLicense
                    Case 0, 1, 2
                        tmpstr = "License_Enterprise"
                        Select Case TypeLicense
                            Case 0
                                tmpVal = "1"
                            Case 1
                                tmpVal = "2"
                            Case 2
                                tmpVal = "3"
                        End Select
                    Case 3, 4, 5
                        tmpstr = "License_SmallBusiness"
                        Select Case TypeLicense
                            Case 3
                                tmpVal = "1"
                            Case 4
                                tmpVal = "2"
                            Case 5
                                tmpVal = "3"
                        End Select
                    Case 6, 8
                        tmpstr = "License_Lite"
                        Select Case TypeLicense
                            Case 6
                                tmpVal = "1"
                            Case 8
                                tmpVal = "2"
                        End Select
                    Case 10
                        tmpstr = "License_SQL_En"
                        Select Case TypeLicense
                            Case 10
                                tmpVal = "1"
                        End Select
                End Select
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE " & tmpstr & "=" & tmpVal
                Else
                    StrSQL += " AND " & tmpstr & "=" & tmpVal
                End If
            End If


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadUserClient_ByCompanyID(ByVal CompanyID As String, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = "SELECT * FROM dbUserClient WHERE CompanyID=@CompanyID"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = CompanyID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadEmailUserClient(ByVal Type As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = Nothing

            Select Case Type
                Case 0
                    StrSQL = "SELECT dbClient.ID,dbClient.CompanyName,dbClient.License_Enterprise,dbUserClient.Email FROM dbClient INNER JOIN  dbUserClient ON dbClient.ID=dbUserClient.CompanyID WHERE dbClient.License_Enterprise <> 0 ORDER BY dbClient.License_Enterprise"
                Case 1
                    StrSQL = "SELECT dbClient.ID,dbClient.CompanyName,dbClient.License_SmallBusiness,dbUserClient.Email FROM dbClient INNER JOIN  dbUserClient ON dbClient.ID=dbUserClient.CompanyID WHERE dbClient.License_SmallBusiness <> 0 ORDER BY dbClient.License_SmallBusiness"
                Case 2
                    StrSQL = "SELECT dbClient.ID,dbClient.CompanyName,dbClient.License_lite,dbUserClient.Email FROM dbClient INNER JOIN  dbUserClient ON dbClient.ID=dbUserClient.CompanyID WHERE dbClient.License_lite <> 0 ORDER BY dbClient.License_lite"
                Case 3
                    StrSQL = "SELECT dbClient.ID,dbClient.CompanyName,dbClient.License_Education,dbUserClient.Email FROM dbClient INNER JOIN  dbUserClient ON dbClient.ID=dbUserClient.CompanyID WHERE dbClient.License_Education <> 0 ORDER BY dbClient.License_Education"
            End Select

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadEmailUserClient_2(ByVal Type As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = Nothing

            StrSQL = "SELECT * FROM dbEmail WHERE Type=@Type"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Type
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadEmailUserClient_Data(Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = Nothing

            StrSQL = "SELECT * FROM dbEmail ORDER BY Type,Email"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
    Public Function LoadEmailUserClient_Search(ByVal Email As String, ByVal Type As Integer, Optional ByRef Errorlog As clsError = Nothing) As DataTable
        Try
            Dim StrSQL As String = Nothing
            Dim isWhere As Boolean = False

            StrSQL = "SELECT * FROM dbEmail"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand




            If Email <> "" Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE email LIKE @email"
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 250).Value = "%" & Email & "%"
                Else
                    StrSQL += " AND email LIKE @email"
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 250).Value = "%" & Email & "%"
                End If
            End If

            If Type <> -1 Then
                If isWhere = False Then
                    isWhere = True
                    StrSQL += " WHERE type=@type"
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Type
                Else
                    StrSQL += " AND type=@type"
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Type
                End If
            End If

            StrSQL += " ORDER BY Type,Email"

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return Nothing
        End Try
    End Function
#End Region

#End Region
#Region "VALIDATE ID"
    Public Function ValidateTemplateID(ByVal ID As String, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try

            Dim StrSQL As String = "SELECT COUNT(*) countData FROM tblTemplate WHERE ID=@ID"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0)("countData") > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function ValidateStepJobID(ByVal ID As String, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try

            Dim StrSQL As String = "SELECT COUNT(*) countData FROM tblStepJob WHERE ID=@ID"

            ADO = New SQLDataObject()
            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID

            Dim dt As DataTable = ADO.GetSQLDataTable(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0)("countData") > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function

#End Region
#Region "UPDATE"
    'Public Function UpdatePromotion(ByVal PromotionID As String, ByVal ProductID As String, ByVal ProductName As String, ByVal DateFrom As DateTime, ByVal DateTo As DateTime, _
    '                              ByVal Name As String, ByVal Description As String, ByVal Type As Integer, DiscountType As Integer, ByVal DiscountValue As Decimal, _
    '                              ByVal DiscountBy As Integer, ByVal IsCondition As Integer, ByVal Condition1 As Integer, ByVal Condition2 As Integer, _
    '                              ByVal Condition3 As Integer, LvFreeGift As ListView, ByVal LvCategory As ListView, Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        Dim StrSQL As String = Nothing
    '        Dim ListofCmd As New List(Of SqlCommand)
    '        ADO = New SQLDataObject()

    '        StrSQL = "DELETE FROM tblPromotionFreeGift WHERE PromotionID=@PromotionID"
    '        cmd = New SqlCommand
    '        cmd.CommandText = StrSQL
    '        cmd.CommandTimeout = 0
    '        cmd.Parameters.Add("@PromotionID", SqlDbType.NVarChar, 30).Value = PromotionID

    '        ListofCmd.Add(cmd)

    '        cmd = Nothing
    '        StrSQL = Nothing

    '        StrSQL = "DELETE FROM tblPromotionCategory WHERE PromotionID=@PromotionID"
    '        cmd = New SqlCommand
    '        cmd.CommandText = StrSQL
    '        cmd.CommandTimeout = 0
    '        cmd.Parameters.Add("@PromotionID", SqlDbType.NVarChar, 30).Value = PromotionID

    '        ListofCmd.Add(cmd)

    '        cmd = Nothing
    '        StrSQL = Nothing

    '        StrSQL = "UPDATE tblPromotion SET ProductID=@ProductID,ProductName=@ProductName,DateFrom=@DateFrom,DateTo=@DateTo,Name=@Name,Description=@Description,Type=@Type,DiscountType=@DiscountType,DiscountValue=@DiscountValue,DiscountBy=@DiscountBy,isCondition=@isCondition,Condition1=@Condition1,Condition2=@Condition2,Condition3=@Condition3,Status=@Status WHERE ID=@ID"

    '        cmd = New SqlCommand
    '        cmd.CommandText = StrSQL
    '        cmd.CommandTimeout = 0
    '        cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = PromotionID
    '        cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar, 30).Value = ProductID
    '        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = ProductName
    '        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateFrom
    '        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTo
    '        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = Name
    '        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = Description
    '        cmd.Parameters.Add("@Type", SqlDbType.Int64).Value = Type
    '        cmd.Parameters.Add("@DiscountType", SqlDbType.Int64).Value = DiscountType
    '        cmd.Parameters.Add("@DiscountValue", SqlDbType.Decimal).Value = DiscountValue
    '        cmd.Parameters.Add("@DiscountBy", SqlDbType.Int64).Value = DiscountBy
    '        cmd.Parameters.Add("@isCondition", SqlDbType.Int64).Value = IsCondition
    '        cmd.Parameters.Add("@Condition1", SqlDbType.Int64).Value = Condition1
    '        cmd.Parameters.Add("@Condition2", SqlDbType.Int64).Value = Condition2
    '        cmd.Parameters.Add("@Condition3", SqlDbType.Decimal).Value = Condition3
    '        cmd.Parameters.Add("@Status", SqlDbType.Int64).Value = 1

    '        ListofCmd.Add(cmd)

    '        If LvFreeGift.Items.Count > 0 Then
    '            Dim tmpID As String = Nothing
    '            For i As Integer = 0 To LvFreeGift.Items.Count - 1

    '                cmd = Nothing
    '                StrSQL = Nothing

    '                tmpID = "PRF" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)

    '                While ValidatePromotion_FreeGift(tmpID)
    '                    tmpID = "PRF" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)
    '                End While

    '                StrSQL = "INSERT INTO tblPromotionFreeGift (ID,PromotionID,ProductID,Name) VALUES (@ID,@PromotionID,@ProductID,@Name)"

    '                cmd = New SqlCommand
    '                cmd.CommandText = StrSQL
    '                cmd.CommandTimeout = 0

    '                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = tmpID
    '                cmd.Parameters.Add("@PromotionID", SqlDbType.NVarChar, 30).Value = PromotionID
    '                cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar, 30).Value = LvFreeGift.Items(i).SubItems(1).Text
    '                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = LvFreeGift.Items(i).SubItems(2).Text

    '                ListofCmd.Add(cmd)
    '            Next
    '        End If

    '        If LvCategory.Items.Count > 0 Then
    '            Dim tmpID As String = Nothing
    '            For i As Integer = 0 To LvCategory.Items.Count - 1

    '                cmd = Nothing
    '                StrSQL = Nothing

    '                tmpID = "PRC" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)

    '                While ValidatePromotion_Category(tmpID)
    '                    tmpID = "PRC" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)
    '                End While

    '                StrSQL = "INSERT INTO tblPromotionCategory (ID,PromotionID,Name) VALUES (@ID,@PromotionID,@Name)"

    '                cmd = New SqlCommand
    '                cmd.CommandText = StrSQL
    '                cmd.CommandTimeout = 0

    '                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = tmpID
    '                cmd.Parameters.Add("@PromotionID", SqlDbType.NVarChar, 30).Value = PromotionID
    '                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = LvCategory.Items(i).SubItems(1).Text

    '                ListofCmd.Add(cmd)
    '            Next
    '        End If

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Errorlog = ex.Message
    '        Return False
    '    End Try
    'End Function
    Public Function UpdateClient(ByVal ID As String, ByVal RefID As String, ByVal CompanyName As String, ByVal Address1 As String, ByVal Address2 As String, _
                               ByVal Address3 As String, ByVal State As String, ByVal City As String, ByVal Postcode As String, _
                               ByVal Country As String, ByVal Phone1 As String, ByVal Phone2 As String, _
                               ByVal FaxNo As String, ByVal isLicenseEnterprise As Integer, _
                               ByVal isLicenseSmall As Integer, ByVal isLicenseLite As Integer, ByVal isLicenseEducation As Integer, _
                               ByVal isLicenseTrial As Integer, isLicenseSQL As Integer, ByVal isBan As Integer, ByVal ServerName As String, _
                               ByVal LvList As ListView, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim ListofCmd As New List(Of SqlCommand)
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            StrSQL = "DELETE FROM dbUserClient WHERE CompanyID=@CompanyID"
            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = ID

            ListofCmd.Add(cmd)

            StrSQL = Nothing
            cmd = Nothing

            StrSQL = "UPDATE dbClient SET RefID=@RefID,CompanyName=@CompanyName,Address1=@Address1,Address2=@Address2,Address3=@Address3,State=@State,City=@City,Postcode=@Postcode,Country=@Country,Phone1=@Phone1,Phone2=@Phone2,FaxNo=@FaxNo,License_Enterprise=@License_Enterprise,License_SmallBusiness=@License_SmallBusiness,License_Lite=@License_Lite,License_Education=@License_Education,License_Trial=@License_Trial,License_SQL_En=@License_SQL_En,isBan=@isBan,ServerName=@ServerName WHERE ID=@ID"




            cmd = New SqlCommand


            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID
            cmd.Parameters.Add("@RefID", SqlDbType.NVarChar, 30).Value = RefID
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 250).Value = CompanyName
            cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 100).Value = Address1
            cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 100).Value = Address2
            cmd.Parameters.Add("@Address3", SqlDbType.NVarChar, 100).Value = Address3
            cmd.Parameters.Add("@State", SqlDbType.NVarChar, 100).Value = State
            cmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = City
            cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar, 10).Value = Postcode
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 150).Value = Country
            cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar, 20).Value = Phone1
            cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar, 20).Value = Phone2
            cmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar, 20).Value = FaxNo
            cmd.Parameters.Add("@License_Enterprise", SqlDbType.Int).Value = isLicenseEnterprise
            cmd.Parameters.Add("@License_SmallBusiness", SqlDbType.Int).Value = isLicenseSmall
            cmd.Parameters.Add("@License_Lite", SqlDbType.Int).Value = isLicenseLite
            cmd.Parameters.Add("@License_Education", SqlDbType.Int).Value = isLicenseEducation
            cmd.Parameters.Add("@License_Trial", SqlDbType.Int).Value = isLicenseTrial
            cmd.Parameters.Add("@License_SQL_En", SqlDbType.Int).Value = isLicenseSQL
            cmd.Parameters.Add("@isBan", SqlDbType.Int).Value = isBan
            cmd.Parameters.Add("@ServerName", SqlDbType.NVarChar, 150).Value = ServerName

            ListofCmd.Add(cmd)


            For i As Integer = 0 To LvList.Items.Count - 1
                StrSQL = Nothing
                cmd = Nothing

                StrSQL = "INSERT INTO dbUserClient (ID,CompanyID,Name,Email,PhoneNo) VALUES (@ID,@CompanyID,@Name,@Email,@PhoneNo)"

                cmd = New SqlCommand
                cmd.CommandText = StrSQL
                cmd.CommandTimeout = 0

                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = LvList.Items(i).SubItems(0).Text
                cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = ID
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = LvList.Items(i).SubItems(1).Text
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250).Value = LvList.Items(i).SubItems(3).Text
                cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar, 20).Value = LvList.Items(i).SubItems(2).Text


                ListofCmd.Add(cmd)
            Next
            'Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd,Sql)
            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function UpdateTemplate(ByVal ID As String, ByVal Name As String, ByVal YA As Integer, ByVal FormType As Integer, _
                             ByVal isAuto As Integer, ByVal LvList As ListView, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim ListofCmd As New List(Of SqlCommand)
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0

            StrSQL = "DELETE FROM tblStepJob WHERE ParentID=@ParentID"

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@ParentID", SqlDbType.NVarChar, 30).Value = ID

            ListofCmd.Add(cmd)

            cmd = Nothing
            StrSQL = Nothing

            StrSQL = "UPDATE tblTemplate SET YA=@YA,TypeForm=@TypeForm,isAuto=@isAuto,Name=@Name WHERE ID=@ID"

            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID
            cmd.Parameters.Add("@YA", SqlDbType.Int).Value = YA
            cmd.Parameters.Add("@TypeForm", SqlDbType.Int).Value = FormType
            cmd.Parameters.Add("@isAuto", SqlDbType.Int).Value = isAuto
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = Name

            ListofCmd.Add(cmd)

            If LvList.Items.Count > 0 Then
                For i As Integer = 0 To LvList.Items.Count - 1
                    cmd = Nothing
                    StrSQL = Nothing

                    StrSQL = "INSERT INTO tblStepJob (ID,ParentID,Sequence,ObjectID,ObjectValue,ObjectType,ActionType,DocURL,isWait,NameObject,PageNo,EventObject) VALUES (@ID,@ParentID,@Sequence,@ObjectID,@ObjectValue,@ObjectType,@ActionType,@DocURL,@isWait,@NameObject,@PageNo,@EventObject)"

                    cmd = New SqlCommand
                    cmd.CommandText = StrSQL
                    cmd.CommandTimeout = 0

                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = LvList.Items(i).SubItems(1).Text
                    cmd.Parameters.Add("@ParentID", SqlDbType.NVarChar, 30).Value = ID
                    cmd.Parameters.Add("@Sequence", SqlDbType.Int).Value = i + 1
                    cmd.Parameters.Add("@ObjectID", SqlDbType.NVarChar, 100).Value = LvList.Items(i).SubItems(2).Text
                    cmd.Parameters.Add("@ObjectValue", SqlDbType.NVarChar, 250).Value = LvList.Items(i).SubItems(3).Text
                    cmd.Parameters.Add("@ObjectType", SqlDbType.Int).Value = CInt(LvList.Items(i).SubItems(4).Text)
                    cmd.Parameters.Add("@ActionType", SqlDbType.Int).Value = CInt(LvList.Items(i).SubItems(5).Text)
                    cmd.Parameters.Add("@DocURL", SqlDbType.NVarChar, 400).Value = LvList.Items(i).SubItems(7).Text
                    cmd.Parameters.Add("@isWait", SqlDbType.Int).Value = IIf(LvList.Items(i).SubItems(6).Text.ToUpper = "TRUE", 1, 0)
                    cmd.Parameters.Add("@NameObject", SqlDbType.NVarChar, 150).Value = LvList.Items(i).SubItems(8).Text
                    cmd.Parameters.Add("@PageNo", SqlDbType.Int).Value = CInt(LvList.Items(i).SubItems(9).Text)
                    cmd.Parameters.Add("@EventObject", SqlDbType.Int).Value = CInt(LvList.Items(i).SubItems(10).Text)
                    ListofCmd.Add(cmd)
                Next
            End If
            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
            'Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function UpdateSupport(ByVal ID As Integer, ByVal RefID As String, ByVal TeamviwerID As String, ByVal TeamviewerPass As String, ByVal PersorName As String, _
                               ByVal Problem As String, ByVal Note As String, ByVal Status As Integer, ByVal TypeForm As Integer, _
                               ByVal flpPanel As FlowLayoutPanel, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0
            Dim tmpDatax As Byte() = Nothing

            StrSQL = "UPDATE dbSupport SET CompanyID=@CompanyID,DateTime=@DateTime,TeamviewerID=@TeamviewerID,TeamviewerPass=@TeamviewerPass,PersonName=@PersorName,Problem=@Problem,Note=@Note,Status=@Status,ModifiedBy=@ModifiedBy,TypeForm=@TypeForm WHERE ID=@ID"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = RefID
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@TeamviewerID", SqlDbType.NVarChar, 15).Value = TeamviwerID
            cmd.Parameters.Add("@TeamviewerPass", SqlDbType.NVarChar, 15).Value = TeamviewerPass
            cmd.Parameters.Add("@PersorName", SqlDbType.NVarChar, 150).Value = PersorName
            cmd.Parameters.Add("@Problem", SqlDbType.NVarChar, 500).Value = Problem
            cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 500).Value = Note
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 250).Value = My.Computer.Name
            cmd.Parameters.Add("@TypeForm", SqlDbType.Int).Value = TypeForm

            ' Return ADO.ExecuteSQLCmd_NOIDReturn(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
            Dim tmpBol As Boolean = True
            tmpBol = ADO.ExecuteSQLCmd_NOIDReturn(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)


            Dim ListofCmd As New List(Of SqlCommand)

            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If
            cmd = Nothing
            StrSQL = "DELETE FROM DBATTACHMENT WHERE SupportID=@SupportID"
            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@SupportID", SqlDbType.Decimal).Value = ID
            ListofCmd.Add(cmd)
            If tmpBol = True AndAlso flpPanel IsNot Nothing AndAlso flpPanel.Controls.Count > 0 Then

                For i As Integer = 0 To flpPanel.Controls.Count - 1

                    cmd = Nothing
                    StrSQL = "INSERT INTO DBATTACHMENT(SupportID,Data,Type) VALUES (@SupportID,@Data,@Type)"
                    cmd = New SqlCommand
                    cmd.CommandText = StrSQL
                    cmd.CommandTimeout = 0

                    cmd.Parameters.Add("@SupportID", SqlDbType.Decimal).Value = ID
                    tmpDatax = GetByteFromPicturebox(CType(flpPanel.Controls(i), PictureBox))

                    If tmpDatax IsNot Nothing Then
                        cmd.Parameters.Add("@Data", SqlDbType.Image).Value = tmpDatax
                    Else
                        cmd.Parameters.Add("@Data", SqlDbType.Image).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add("@Type", SqlDbType.Decimal).Value = 0

                    ListofCmd.Add(cmd)

                Next

            End If
            tmpBol = ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name)
            If tmpBol Then
                SendNotification(RefID & " is updated")
                SaveLog(ID, "Support data is updated by " & My.Computer.Name)
            End If
            Return tmpBol
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function UpdateStatusSupport(ByVal ID As Integer, ByVal CompanyName As String, ByVal Status As Integer, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0

            StrSQL = "UPDATE dbSupport SET Status=@Status,ModifiedBy=@ModifiedBy WHERE ID=@ID"
            Dim tmpBol As Boolean = False

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 250).Value = My.Computer.Name

            tmpBol = ADO.ExecuteSQLCmd_NOIDReturn(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)

            If tmpBol Then
                SendNotification(CompanyName & " status is updated to " & GetStatusSupport(Status))
                SaveLog(ID, "Support status changed by " & My.Computer.Name & " To " & GetStatusSupport(Status))
            End If

            Return tmpBol
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
#End Region
#Region "SAVE"
    Public Function SaveImportClient(ByVal dgView As DataGridView, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim ListofCmd As New List(Of SqlCommand)
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0
            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            For i As Integer = 0 To dgView.Rows.Count - 1
                If IsDBNull(dgView.Rows(i).Cells(0).Value) = False AndAlso dgView.Rows(i).Cells(0).Value <> "" Then

                    StrSQL = "INSERT INTO dbClient (ID,RefID,CompanyName,Address1,Address2,Address2,State,City,Postcode,Country,Phone1,Phone2,FaxNo,License_Enterprise,License_SmallBusiness,License_Lite,License_Education,License_Trial,isBan) VALUES (@ID,@RefID,@CompanyName,@Address1,@Address2,@Address2,@State,@City,@Postcode,@Country,@Phone1,@Phone2,@FaxNo,@License_Enterprise,@License_SmallBusiness,@License_Lite,@License_Education,@License_Trial,@isBan)"


                    cmd = New SqlCommand
                    cmd.CommandText = StrSQL
                    cmd.CommandTimeout = 0

                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = dgView.Rows(i).Cells(0).Value
                    cmd.Parameters.Add("@RefID", SqlDbType.NVarChar, 30).Value = dgView.Rows(i).Cells(17).Value
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 250).Value = dgView.Rows(i).Cells(1).Value
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 100).Value = dgView.Rows(i).Cells(2).Value
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 100).Value = dgView.Rows(i).Cells(3).Value
                    cmd.Parameters.Add("@Address3", SqlDbType.NVarChar, 100).Value = dgView.Rows(i).Cells(4).Value
                    cmd.Parameters.Add("@State", SqlDbType.NVarChar, 100).Value = dgView.Rows(i).Cells(5).Value
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = dgView.Rows(i).Cells(6).Value
                    cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar, 10).Value = dgView.Rows(i).Cells(7).Value
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 150).Value = dgView.Rows(i).Cells(8).Value
                    cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar, 20).Value = dgView.Rows(i).Cells(9).Value
                    cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar, 20).Value = dgView.Rows(i).Cells(10).Value
                    cmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar, 20).Value = dgView.Rows(i).Cells(11).Value
                    If IsDBNull(dgView.Rows(i).Cells(12).Value) = False AndAlso dgView.Rows(i).Cells(12).Value <> "" Then
                        cmd.Parameters.Add("@License_Enterprise", SqlDbType.Int).Value = CInt(dgView.Rows(i).Cells(12).Value)
                    Else
                        cmd.Parameters.Add("@License_Enterprise", SqlDbType.Int).Value = 0
                    End If

                    If IsDBNull(dgView.Rows(i).Cells(13).Value) = False AndAlso dgView.Rows(i).Cells(13).Value <> "" Then
                        cmd.Parameters.Add("@License_SmallBusiness", SqlDbType.Int).Value = CInt(dgView.Rows(i).Cells(13).Value)
                    Else
                        cmd.Parameters.Add("@License_SmallBusiness", SqlDbType.Int).Value = 0
                    End If

                    If IsDBNull(dgView.Rows(i).Cells(14).Value) = False AndAlso dgView.Rows(i).Cells(14).Value <> "" Then
                        cmd.Parameters.Add("@License_Lite", SqlDbType.Int).Value = CInt(dgView.Rows(i).Cells(14).Value)
                    Else
                        cmd.Parameters.Add("@License_Lite", SqlDbType.Int).Value = 0
                    End If

                    If IsDBNull(dgView.Rows(i).Cells(15).Value) = False AndAlso dgView.Rows(i).Cells(15).Value <> "" Then
                        cmd.Parameters.Add("@License_Education", SqlDbType.Int).Value = CInt(dgView.Rows(i).Cells(15).Value)
                    Else
                        cmd.Parameters.Add("@License_Education", SqlDbType.Int).Value = 0
                    End If

                    If IsDBNull(dgView.Rows(i).Cells(16).Value) = False AndAlso dgView.Rows(i).Cells(16).Value <> "" Then
                        cmd.Parameters.Add("@License_Trial", SqlDbType.Int).Value = CInt(dgView.Rows(i).Cells(16).Value)
                    Else
                        cmd.Parameters.Add("@License_Trial", SqlDbType.Int).Value = 0
                    End If
                    cmd.Parameters.Add("@isBan", SqlDbType.Int).Value = 0

                    ListofCmd.Add(cmd)
                End If
            Next
            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function SaveClient(ByVal ID As String, ByRef RefID As String, ByVal CompanyName As String, ByVal Address1 As String, ByVal Address2 As String, _
                               ByVal Address3 As String, ByVal State As String, ByVal City As String, ByVal Postcode As String, _
                               ByVal Country As String, ByVal Phone1 As String, ByVal Phone2 As String, _
                               ByVal FaxNo As String, ByVal isLicenseEnterprise As Integer, _
                               ByVal isLicenseSmall As Integer, ByVal isLicenseLite As Integer, ByVal isLicenseEducation As Integer, _
                               ByVal isLicenseTrial As Integer, ByVal isLicenseSQL As Integer, ByVal isBan As Integer, _
                               ByVal ServerName As String, ByVal LvList As ListView, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim ListofCmd As New List(Of SqlCommand)
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand

            StrSQL = "INSERT INTO dbClient (ID,RefID,CompanyName,Address1,Address3,Address2,State,City,Postcode,Country,Phone1,Phone2,FaxNo,License_Enterprise,License_SmallBusiness,License_Lite,License_Education,License_Trial,isBan,License_SQL_En,ServerName) VALUES (@ID,@RefID,@CompanyName,@Address1,@Address2,@Address3,@State,@City,@Postcode,@Country,@Phone1,@Phone2,@FaxNo,@License_Enterprise,@License_SmallBusiness,@License_Lite,@License_Education,@License_Trial,@isBan,@License_SQL_En,@ServerName)"

            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ID
            cmd.Parameters.Add("@RefID", SqlDbType.NVarChar, 30).Value = RefID
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 250).Value = CompanyName
            cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 100).Value = Address1
            cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 100).Value = Address2
            cmd.Parameters.Add("@Address3", SqlDbType.NVarChar, 100).Value = Address3
            cmd.Parameters.Add("@State", SqlDbType.NVarChar, 100).Value = State
            cmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = City
            cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar, 10).Value = Postcode
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 150).Value = Country
            cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar, 20).Value = Phone1
            cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar, 20).Value = Phone2
            cmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar, 20).Value = FaxNo
            cmd.Parameters.Add("@License_Enterprise", SqlDbType.Int).Value = isLicenseEnterprise
            cmd.Parameters.Add("@License_SmallBusiness", SqlDbType.Int).Value = isLicenseSmall
            cmd.Parameters.Add("@License_Lite", SqlDbType.Int).Value = isLicenseLite
            cmd.Parameters.Add("@License_Education", SqlDbType.Int).Value = isLicenseEducation
            cmd.Parameters.Add("@License_Trial", SqlDbType.Int).Value = isLicenseTrial
            cmd.Parameters.Add("@isBan", SqlDbType.Int).Value = isBan
            cmd.Parameters.Add("@License_SQL_En", SqlDbType.Int).Value = isLicenseSQL
            cmd.Parameters.Add("@ServerName", SqlDbType.NVarChar, 150).Value = ServerName

            ListofCmd.Add(cmd)


            For i As Integer = 0 To LvList.Items.Count - 1
                StrSQL = Nothing
                cmd = Nothing

                StrSQL = "INSERT INTO dbUserClient (ID,CompanyID,Name,Email,PhoneNo) VALUES (@ID,@CompanyID,@Name,@Email,@PhoneNo)"

                cmd = New SqlCommand
                cmd.CommandText = StrSQL
                cmd.CommandTimeout = 0

                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = LvList.Items(i).SubItems(0).Text
                cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = ID
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = LvList.Items(i).SubItems(1).Text
                cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar, 20).Value = LvList.Items(i).SubItems(2).Text
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250).Value = LvList.Items(i).SubItems(3).Text

                ListofCmd.Add(cmd)
            Next

            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function SaveSupport(ByVal RefID As String, ByVal TeamviwerID As String, ByVal TeamviewerPass As String, ByVal PersorName As String, _
                                ByVal Problem As String, ByVal Note As String, ByVal Status As Integer, ByVal TypeForm As Integer, _
                                ByVal flpPanel As FlowLayoutPanel, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0
            Dim tmpBol As Boolean = True
            StrSQL = "INSERT INTO dbSupport (CompanyID,DateTime,TeamviewerID,TeamviewerPass,PersonName,Problem,Note,Status,DateCreated,ModifiedBy,TypeForm) VALUES (@CompanyID,@DateTime,@TeamviewerID,@TeamviewerPass,@PersorName,@Problem,@Note,@Status,@DateCreated,@ModifiedBy,@TypeForm)"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 30).Value = RefID
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@TeamviewerID", SqlDbType.NVarChar, 15).Value = TeamviwerID
            cmd.Parameters.Add("@TeamviewerPass", SqlDbType.NVarChar, 15).Value = TeamviewerPass
            cmd.Parameters.Add("@PersorName", SqlDbType.NVarChar, 150).Value = PersorName
            cmd.Parameters.Add("@Problem", SqlDbType.NVarChar, 500).Value = Problem
            cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 500).Value = Note
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 250).Value = My.Computer.Name
            cmd.Parameters.Add("@TypeForm", SqlDbType.Int).Value = TypeForm

            Dim ReturnID As Integer = 0
            tmpBol = ADO.ExecuteSQLCmd(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog, ReturnID)

            If tmpBol = True AndAlso flpPanel IsNot Nothing AndAlso flpPanel.Controls.Count > 0 Then
                Dim ListofCmd As New List(Of SqlCommand)

                If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                    Return Nothing
                End If
                cmd = Nothing
                StrSQL = "DELETE FROM DBATTACHMENT WHERE SupportID=@SupportID"
                cmd = New SqlCommand
                cmd.CommandText = StrSQL
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@SupportID", SqlDbType.Decimal).Value = ReturnID
                ListofCmd.Add(cmd)

                For i As Integer = 0 To flpPanel.Controls.Count - 1


                    cmd = Nothing
                    StrSQL = "INSERT INTO DBATTACHMENT(SupportID,Data,Type) VALUES (@SupportID,@Data,@Type)"
                    cmd = New SqlCommand
                    cmd.CommandText = StrSQL
                    cmd.CommandTimeout = 0



                    cmd.Parameters.Add("@SupportID", SqlDbType.Decimal).Value = ReturnID

                    cmd.Parameters.Add("@Data", SqlDbType.Image).Value = GetByteFromPicturebox(CType(flpPanel.Controls(i), PictureBox))
                    cmd.Parameters.Add("@Type", SqlDbType.Decimal).Value = 0

                    ListofCmd.Add(cmd)


                Next
                tmpBol = ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name)
            End If
            If tmpBol Then
                SendNotification(RefID & " is created")
                SaveLog(ReturnID, "Support data is created by " & My.Computer.Name)
            End If
            Return tmpBol
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function SaveLog(ByVal SupportID As Integer, ByVal Message As String, Optional ByRef ErrorLog As clsError = Nothing) As Boolean
        Try
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0
            Dim tmpBol As Boolean = True
            StrSQL = "INSERT INTO DBSUPPORT_LOG (SupportID,DateTime,Username,LogData) VALUES (@SupportID,@DateTime,@Username,@LogData)"
            Dim ReturnID As Integer = 0

            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, ErrorLog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@SupportID", SqlDbType.Int).Value = SupportID
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@LogData", SqlDbType.NVarChar, 500).Value = Message
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 250).Value = My.Computer.Name


            Return ADO.ExecuteSQLCmd(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, ErrorLog, ReturnID)
        Catch ex As Exception
            Return True
        End Try
    End Function
    Public Function SaveComment(ByVal SupportID As String, ByVal Message As String, ByRef ReturnID As Integer, Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            Dim StrSQL As String = Nothing
            Dim ReturnValue As Integer = 0
            Dim tmpBol As Boolean = True
            StrSQL = "INSERT INTO DBSUPPORT_COMMENT (SupportID,DateTime,Message,Username) VALUES (@SupportID,@DateTime,@Message,@Username)"


            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If

            cmd = New SqlCommand
            cmd.CommandText = StrSQL
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("@SupportID", SqlDbType.Int).Value = SupportID
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 3000).Value = Message
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 250).Value = My.Computer.Name


            Return ADO.ExecuteSQLCmd(cmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog, ReturnID)
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
#Region "REMOVE"
    Public Function RemoveClient(ByVal ListofID As List(Of String), Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try
            If ListofID.Count = 0 Then
                Return True
            End If

            Dim ListofCmd As New List(Of SqlCommand)

            Dim strSQL As String = Nothing
            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If
            Dim ReturnValue As Integer = 0

            For i As Integer = 0 To ListofID.Count - 1
                strSQL = "DELETE FROM dbClient WHERE ID=@ID"
                cmd = New SqlCommand
                cmd.CommandText = strSQL
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofID(i)

                ListofCmd.Add(cmd)

            Next

            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, )
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function RemoveCancelSupport(Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try

            Dim ListofCmd As New List(Of SqlCommand)

            Dim strSQL As String = Nothing
            ADO = New SQLDataObject()
            Dim SqlCon As SqlConnection = Nothing
            If DBConnection(SqlCon, Errorlog) = False OrElse SqlCon Is Nothing Then
                Return Nothing
            End If
            Dim ReturnValue As Integer = 0

            strSQL = "DELETE FROM DBSUPPORT WHERE DateTime<=@DateTime AND Status=2"
            cmd = New SqlCommand
            cmd.CommandText = strSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now.AddMonths(-3)
            ListofCmd.Add(cmd)

            strSQL = "DELETE FROM DBSUPPORT_LOG WHERE DateTime<=@DateTime AND Status=2"
            cmd = New SqlCommand
            cmd.CommandText = strSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Now.AddMonths(-3)

            strSQL = "UPDATE DBSUPPORT SET Status=1 WHERE ID in (SELECT ID FROM DBSUPPORT WHERE STATUS=0 AND DateTime < @DateTime)"
            cmd = New SqlCommand
            cmd.CommandText = strSQL
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Format(Now, "dd-MMM-yyyy 00:00:00")

            ListofCmd.Add(cmd)

            Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, )
        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    'Public Function RemoveBank(ByVal BankID As String, Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        strSQL = "DELETE FROM tblBank WHERE ID=@ID"

    '        cmd = New SqlCommand
    '        cmd.CommandText = strSQL
    '        cmd.CommandTimeout = 0

    '        cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = BankID

    '        Return ADO.ExecuteNonQuery(cmd, ReturnValue, ErrorLog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemoveMember(ByVal ListofMemberID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofMemberID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofMemberID.Count - 1
    '            strSQL = "DELETE FROM tblMember WHERE ID=@ID"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofMemberID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemoveUser(ByVal BankID As String, Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        strSQL = "DELETE FROM tblUser WHERE userID=@ID"

    '        cmd = New SqlCommand
    '        cmd.CommandText = strSQL
    '        cmd.CommandTimeout = 0

    '        cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = BankID

    '        Return ADO.ExecuteNonQuery(cmd, ReturnValue, ErrorLog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemoveCourier(ByVal CourierID As String, Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        strSQL = "DELETE FROM tblCourier WHERE ID=@ID"

    '        cmd = New SqlCommand
    '        cmd.CommandText = strSQL
    '        cmd.CommandTimeout = 0

    '        cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = CourierID

    '        Return ADO.ExecuteNonQuery(cmd, ReturnValue, ErrorLog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemoveOrder(ByVal ListofOrderID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofOrderID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofOrderID.Count - 1
    '            strSQL = "DELETE FROM tblProductItem WHERE OrderID=@OrderID AND Type=0"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar, 30).Value = ListofOrderID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing


    '            strSQL = "DELETE FROM tblOrder WHERE ID=@ID"

    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofOrderID(i)
    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemoveQuotation(ByVal ListofQuotationID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofQuotationID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofQuotationID.Count - 1
    '            strSQL = "DELETE FROM tblProductItem WHERE QOID=@QOID AND Type=1"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@QOID", SqlDbType.NVarChar, 30).Value = ListofQuotationID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing


    '            strSQL = "DELETE FROM tblQuotation WHERE ID=@ID"

    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofQuotationID(i)
    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemovePurchaseOrder(ByVal ListofPurchaseOrderID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofPurchaseOrderID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofPurchaseOrderID.Count - 1
    '            strSQL = "DELETE FROM tblProductItem WHERE POID=@POID AND Type=1"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@POID", SqlDbType.NVarChar, 30).Value = ListofPurchaseOrderID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing


    '            strSQL = "DELETE FROM tblPurchaseOrder WHERE ID=@ID"

    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofPurchaseOrderID(i)
    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Function RemovePromotion(ByVal ListofPromotionID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofPromotionID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofPromotionID.Count - 1
    '            strSQL = "DELETE FROM tblPromotionFreeGift WHERE PromotionID=@PromotionID"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@PromotionID", SqlDbType.NVarChar, 30).Value = ListofPromotionID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing

    '            strSQL = "DELETE FROM tblPromotionCategory WHERE PromotionID=@PromotionID2"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@PromotionID2", SqlDbType.NVarChar, 30).Value = ListofPromotionID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing

    '            strSQL = "DELETE FROM tblPromotion WHERE ID=@ID"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofPromotionID(i)

    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception

    '    End Try
    'End Function
    'Public Function RemoveInvoice(ByVal ListofInvoceID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofInvoceID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofInvoceID.Count - 1
    '            strSQL = "DELETE FROM tblProductItem WHERE INVID=@INVID AND Type=3"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@INVID", SqlDbType.NVarChar, 30).Value = ListofInvoceID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing


    '            strSQL = "DELETE FROM tblInvoice WHERE ID=@ID"

    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofInvoceID(i)
    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function RemoveDeliveryOrder(ByVal ListofDeliveryOrderID As List(Of String), Optional ByRef Errorlog as Errorlog= nothing) As Boolean
    '    Try
    '        If ListofDeliveryOrderID.Count = 0 Then
    '            Return True
    '        End If

    '        Dim ListofCmd As New List(Of SqlCommand)

    '        Dim strSQL As String = Nothing
    '        ADO = New SQLDataObject()
    '        Dim ReturnValue As Integer = 0

    '        For i As Integer = 0 To ListofDeliveryOrderID.Count - 1
    '            strSQL = "DELETE FROM tblProductItem WHERE INVID=@INVID AND Type=4"
    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@INVID", SqlDbType.NVarChar, 30).Value = ListofDeliveryOrderID(i)

    '            ListofCmd.Add(cmd)

    '            cmd = Nothing
    '            strSQL = Nothing


    '            strSQL = "DELETE FROM tblDeliveryOrder WHERE ID=@ID"

    '            cmd = New SqlCommand
    '            cmd.CommandText = strSQL
    '            cmd.CommandTimeout = 0
    '            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 30).Value = ListofDeliveryOrderID(i)
    '            ListofCmd.Add(cmd)
    '        Next

    '        Return ADO.ExecuteSQLTransactionBySQLCommand_NOReturnID(ListofCmd, SqlCon, System.Reflection.MethodBase.GetCurrentMethod().Name, Errorlog)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
#End Region
#Region "GENERAL"
    Public Function GetLastDayOfMonth(intMonth, intYear) As Date
        Try
            Return DateSerial(intYear, intMonth + 1, 0)
        Catch ex As Exception
            Return Now
        End Try
    End Function
    Public Function GetStatusSupport(ByVal Type As Integer) As String
        Try
            Select Case Type
                Case 0
                    Return "New"
                Case 1
                    Return "Hold"
                Case 2
                    Return "Cancel"
                Case 3
                    Return "Solved"
                Case 4
                    Return "Connection Problem"
                Case 5
                    Return "Bug Program On Hold"
                Case 6
                    Return "PC Problem"
                Case 7
                    Return "Urgent"
                Case 8
                    Return "Pending to Testing"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GetTypeFrom(ByVal Type As Integer) As String
        Try
            'Office = Sql
            'C += Sql
            'B += Sql
            'IEToolbar = Sql
            'Office = Access
            'C += Access
            'B += Access
            'IEToolbar = Access
            'General()
            Select Case Type
                Case 0
                    Return "Office SQL"
                Case 1
                    Return "C+ SQL"
                Case 2
                    Return "B+ SQL"
                Case 3
                    Return "IEToolbar SQL"
                Case 4
                    Return "Office Access"
                Case 5
                    Return "C+ Access"
                Case 6
                    Return "B+ Access"
                Case 7
                    Return "IEToolbar Access"
                Case 8
                    Return "General"
                Case 9
                    Return "SQL Lite"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function ConvertDateTimeToFacebookDateTime(ByVal DateData As DateTime, Optional ByVal FormatType As Integer = 0, Optional ByRef ErrorLog As String = "") As String
        Try
            Dim Hours As String = " hours ago"
            Dim Minutes As String = " minutes ago"
            Dim Seconds As String = "a few seconds ago"
            Select Case FormatType
                Case 0
                    Hours = " hours ago"
                    Minutes = " minutes ago"
                    Seconds = "a few seconds ago"
                Case 1
                    Hours = " hrs ago"
                    Minutes = " min ago"
                    Seconds = "a moments ago"
            End Select
            If DateDiff(DateInterval.Day, DateData, Now) > 0 Then
                Return Format(DateData, "dd-MMM-yyyy hh:mm tt")
            Else
                If DateDiff(DateInterval.Hour, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Hour, DateData, Now) & Hours & " " & Format(DateData, "hh:mm tt")
                ElseIf DateDiff(DateInterval.Minute, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Minute, DateData, Now) & Minutes
                Else
                    Return Seconds
                End If
            End If
        Catch ex As Exception
            Return Format(DateData, "dd-MMM-yyyy hh:mm tt")
        End Try
    End Function
    Public Function ConvertDateTimeToFacebookDateTime_Year(ByVal DateData As DateTime, Optional ByVal FormatType As Integer = 0, Optional ByRef ErrorLog As String = "") As String
        Try
            Dim Hours As String = " hours ago"
            Dim Minutes As String = " minutes ago"
            Dim Seconds As String = "a few seconds ago"
            Dim Years As String = "a years ago"
            Dim Months As String = "a months ago"
            Dim Days As String = "a days ago"
            Select Case FormatType
                Case 0
                    Hours = " hours ago"
                    Minutes = " minutes ago"
                    Seconds = "a few seconds ago"
                    Years = " years ago"
                    Months = " months ago"
                    Days = " days ago"
                Case 1
                    Hours = " hrs ago"
                    Minutes = " min ago"
                    Seconds = "a moments ago"
                    Years = " years ago"
                    Months = " months ago"
                    Days = " days ago"
            End Select
            If DateDiff(DateInterval.Day, DateData, Now) > 0 Then
                If DateDiff(DateInterval.Year, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Year, DateData, Now) & Years
                ElseIf DateDiff(DateInterval.Month, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Month, DateData, Now) & Months
                ElseIf DateDiff(DateInterval.Day, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Day, DateData, Now) & Days
                ElseIf DateDiff(DateInterval.Hour, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Hour, DateData, Now) & Hours
                ElseIf DateDiff(DateInterval.Minute, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Minute, DateData, Now) & Minutes
                Else
                    Return Seconds

                End If
            Else
                If DateDiff(DateInterval.Hour, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Hour, DateData, Now) & Hours
                ElseIf DateDiff(DateInterval.Minute, DateData, Now) > 0 Then
                    Return DateDiff(DateInterval.Minute, DateData, Now) & Minutes
                Else
                    Return Seconds
                End If
            End If

        Catch ex As Exception
            Return Format(DateData, "dd-MMM-yyyy")
        End Try
    End Function
    Public Function SentEmailUpdate(ByVal dtUserList As DataTable, ByVal Title As String, ByVal Link32Bit As String, _
                                    ByVal Link64Bit As String, ByVal ChangeLog As String, ByVal Type As Integer, ByVal TypePackage As Integer, _
                                    ByVal EmailTemplate As String, ByVal Versions As String, ByVal IEToolbarV As String, ByRef ListOfClient As List(Of String), Optional ByRef Errorlog As clsError = Nothing) As Boolean
        Try



            If dtUserList IsNot Nothing Then
                For i As Integer = 0 To dtUserList.Rows.Count - 1
                    If IsDBNull(dtUserList.Rows(i)("Email")) = False Then
                        Using mail As MailMessage = New MailMessage

                            'mail.Bcc.Add(dtUserList.Rows(i)("Email"))
                            mail.From = New MailAddress(My.Settings.mailsetting)
                            'mail.To.Add("kwokcs@yglworld.com")
                            'mail.To.Add("ikhram@yglworld.com")
                            'mail.To.Add("dannylee@yglmmr.com")
                            'mail.To.Add("azhamygl@gmail.com")
                            ListOfClient.Add(dtUserList.Rows(i)("Email"))
                            mail.To.Add(dtUserList.Rows(i)("Email"))

                            Dim Str As String = Nothing
                            Select Case Type
                                Case 0
                                    'Enterprise
                                    Str = "Enterprise"
                                Case 1
                                    'Small Business
                                    Str = "Small Business"
                                Case 2
                                    'Lite
                                    Str = "Taxoffice Lite"
                                Case 3
                                    'Lite
                                    Str = "Education"
                                Case 4
                                    'SQL
                                    Str = "SQL Edition Enterprise"
                            End Select

                            mail.Subject = "Release Tax Office " + Str + " " + Title
                            mail.IsBodyHtml = True

                            mail.Body = EmailTemplate_StringChange(Title, Link32Bit, Link64Bit, ChangeLog, Type, TypePackage, _
                                                                   EmailTemplate, Versions, IEToolbarV, Errorlog)


                            Using smtp As New SmtpClient("smtp.gmail.com")
                                smtp.EnableSsl = True
                                smtp.Credentials = New System.Net.NetworkCredential(My.Settings.mailsetting, DecriptPass(My.Settings.mailpassword))
                                smtp.Port = 587
                                smtp.Send(mail)
                            End Using

                        End Using
                    End If
                    System.Threading.Thread.Sleep(1500)
                Next
            End If


            'OK
            Using mail As MailMessage = New MailMessage

                'mail.Bcc.Add(dtUserList.Rows(i)("Email"))
                mail.From = New MailAddress(My.Settings.mailsetting)
                mail.To.Add("kwokcs@yglworld.com")
                mail.To.Add("ikhram@yglworld.com")
                mail.To.Add("dannylee@yglmmr.com")
                mail.To.Add("azhamygl@gmail.com")

                Dim Str As String = Nothing
                Select Case Type
                    Case 0
                        'Enterprise
                        Str = "Enterprise"
                    Case 1
                        'Small Business
                        Str = "Small Business"
                    Case 2
                        'Lite
                        Str = "Taxoffice Lite"
                    Case 3
                        'Lite
                        Str = "Education"
                    Case 4
                        'SQL
                        Str = "SQL Edition Enterprise"
                End Select

                mail.Subject = "Release Tax Office " + Str + " " + Title
                mail.IsBodyHtml = True

                mail.Body = EmailTemplate_StringChange(Title, Link32Bit, Link64Bit, ChangeLog, Type, TypePackage, _
                                                       EmailTemplate, Versions, IEToolbarV, Errorlog)


                Using smtp As New SmtpClient("smtp.gmail.com")
                    smtp.EnableSsl = True
                    smtp.Credentials = New System.Net.NetworkCredential(My.Settings.mailsetting, DecriptPass(My.Settings.mailpassword))
                    smtp.Port = 587
                    smtp.Send(mail)
                End Using

            End Using

            Return True

        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function SentEmailUpdate_TEST(ByVal dtUserList As DataTable, ByVal Title As String, ByVal Link32Bit As String, _
                                   ByVal Link64Bit As String, ByVal ChangeLog As String, ByVal Type As Integer, ByVal TypePackage As Integer, _
                                   ByVal EmailTemplate As String, ByVal Versions As String, ByVal IEToolbarV As String, Optional Errorlog As clsError = Nothing) As Boolean
        Try
            Using mail As MailMessage = New MailMessage
                mail.From = New MailAddress(My.Settings.mailsetting)
                mail.To.Add("azhamygl@gmail.com")

                If dtUserList IsNot Nothing Then
                    For i As Integer = 0 To dtUserList.Rows.Count - 1
                        If IsDBNull(dtUserList.Rows(i)("Email")) = False Then
                            mail.Bcc.Add(dtUserList.Rows(i)("Email"))
                        End If
                    Next
                End If

                Dim Str As String = Nothing
                Select Case Type
                    Case 0
                        'Enterprise
                        Str = "Enterprise"
                    Case 1
                        'Small Business
                        Str = "Small Business"
                    Case 2
                        'Lite
                        Str = "Taxoffice Lite"
                    Case 3
                        'Lite
                        Str = "Education"
                    Case 4
                        'SQL
                        Str = "SQL Edition Enterprise"
                End Select

                mail.Subject = "TESTING Release Tax Office " + Str + " " + Title
                mail.IsBodyHtml = True

                mail.Body = EmailTemplate_StringChange(Title, Link32Bit, Link64Bit, ChangeLog, Type, TypePackage, _
                                                       EmailTemplate, Versions, IEToolbarV, Errorlog)


                Using smtp As New SmtpClient("smtp.gmail.com")
                    smtp.EnableSsl = True
                    smtp.Credentials = New System.Net.NetworkCredential(My.Settings.mailsetting, DecriptPass(My.Settings.mailpassword))
                    smtp.Port = 587
                    smtp.Send(mail)
                End Using
            End Using
            'Dim MyMailMessage As New MailMessage
            'MyMailMessage.From = New MailAddress(My.Settings.mailsetting)
            'MyMailMessage.To.Add("arsoftwaremalaysia@gmail.com")
            'MyMailMessage.Subject = "Release " + Title + " " + Versions
            'MyMailMessage.IsBodyHtml = True
            'MyMailMessage.Body = EmailTemplate_StringChange(Title, Link32Bit, Link64Bit, ChangeLog, Type, TypePackage, _
            '                                           EmailTemplate, Versions, ErrorLog)

            'Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            'SMTPServer.Port = 587
            'SMTPServer.Credentials = New NetworkCredential(My.Settings.mailsetting, DecriptPass(My.Settings.mailpassword))
            'SMTPServer.EnableSsl = True
            ' SMTPServer.Send(MyMailMessage)
            Return True

        Catch ex As Exception
            If Errorlog Is Nothing Then
                Errorlog = New clsError
            End If

            With Errorlog
                .ErrorName = System.Reflection.MethodBase.GetCurrentMethod().Name
                .ErrorCode = ex.GetHashCode.ToString
                .ErrorDateTime = Now
                .ErrorMessage = ex.Message
            End With
            Return False
        End Try
    End Function
    Public Function RandomKey() As String
        Try
            Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim r As New Random
            Dim sb As New StringBuilder
            For i As Integer = 1 To 4
                Dim idx As Integer = r.Next(0, 4)
                sb.Append(s.Substring(idx, 1))
            Next
            sb.Append("-")
            For i As Integer = 1 To 4
                Dim idx As Integer = r.Next(0, 4)
                sb.Append(s.Substring(idx, 1))
            Next
            sb.Append("-")
            For i As Integer = 1 To 4
                Dim idx As Integer = r.Next(0, 4)
                sb.Append(s.Substring(idx, 1))
            Next
            sb.Append("-")
            For i As Integer = 1 To 3
                Dim idx As Integer = r.Next(0, 3)
                sb.Append(s.Substring(idx, 1))
            Next

            Return sb.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function RandomID(Optional ByVal Count As Integer = 4) As String
        Try
            Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim r As New Random
            Dim sb As New StringBuilder
            For i As Integer = 1 To Count
                Dim idx As Integer = r.Next(0, Count)
                sb.Append(s.Substring(idx, 1))
            Next

            Return sb.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function RandomNO_Only(Optional ByVal Count As Integer = 4) As String
        Try
            Dim s As String = "0123456789"
            Dim r As New Random
            Dim sb As New StringBuilder
            For i As Integer = 1 To Count
                Dim idx As Integer = r.Next(0, Count)
                sb.Append(s.Substring(idx, 1))
            Next

            Return sb.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub numbervalidation_Phone(ByVal e As KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 45) Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Public Sub numbervalidation_Decimal(ByVal e As KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Public Sub TextFocusValidate(txt As TextBox)

        If txt.Tag = txt.Text Then
            txt.Clear()
        End If

    End Sub
    Public Sub TextLostFocusValidate(txt As TextBox)

        If txt.TextLength = 0 Then
            txt.Text = txt.Tag
        End If

    End Sub
    Public Sub CBOFocusValidate(cbo As ComboBox)

        If cbo.Tag = cbo.Text Then
            cbo.Text = ""
        End If

    End Sub
    Public Sub CBOLostFocusValidate(cbo As ComboBox)

        If cbo.Text = "" Then
            cbo.Text = cbo.Tag
        End If

    End Sub
    Public Function GetByteFromPicturebox(ByVal picBox As PictureBox) As Byte()
        Dim picStream As New MemoryStream
tryagain:
        Try
            Dim safeimage As New Bitmap(picBox.Image)
            safeimage.Save(picStream, System.Drawing.Imaging.ImageFormat.Jpeg)

        Catch ex As Exception
            MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " " & ex.Message, MsgBoxStyle.Critical)
            GoTo tryagain
        End Try
        picStream.Close()


        Return picStream.ToArray
    End Function
    Public Function ProcessImagetoByte(ByVal Url As String) As Byte()

        Dim stream As New MemoryStream()
tryagain:
        Try
            If System.IO.File.Exists(Url) Then
                Dim image As New Bitmap(Url)
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            GoTo tryagain
        End Try

        Return stream.ToArray()


    End Function
    Public Sub GetImage(ByVal imgbyte As Byte(), Picbox As PictureBox)
        If imgbyte IsNot Nothing AndAlso imgbyte.Count > 0 Then
            Dim stream As New IO.MemoryStream()

            Dim image As Byte() = DirectCast(imgbyte, Byte())
            stream.Write(image, 0, image.Length)

            Dim bitmap As New Bitmap(stream)
            Picbox.Image = bitmap
        Else
            Exit Sub
        End If
    End Sub
    Public Function GetFormType() As List(Of String)

        Try
            Dim ListOfFormType As New List(Of String)

            ListOfFormType.Add("Form C")
            ListOfFormType.Add("Form B")
            ListOfFormType.Add("Form BE")
            ListOfFormType.Add("Form M")
            ListOfFormType.Add("Form P")
            ListOfFormType.Add("Form Other")
            ListOfFormType.Add("Form R")
            ListOfFormType.Add("Form CP204")
            ListOfFormType.Add("Form CP204A")
            Return ListOfFormType
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetFormType(ByVal Type As Integer) As String

        Try
            Select Case Type
                Case 0
                    Return "Form C"
                Case 1
                    Return "Form B"
                Case 2
                    Return "Form BE"
                Case 3
                    Return "Form M"
                Case 4
                    Return "Form P"
                Case 5
                    Return "Form Other"
                Case 6
                    Return "Form R"
                Case 7
                    Return "Form CP204"
                Case 8
                    Return "Form CP204A"
                Case Else
                    Return "-"
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetFormType_ByString(ByVal Type As String) As String

        Try
            Select Case Type
                Case "Form C"
                    Return 0
                Case "Form B"
                    Return 1
                Case "Form BE"
                    Return 2
                Case "Form M"
                    Return 3
                Case "Form P"
                    Return 4
                Case "Form Other"
                    Return 5
                Case "Form R"
                    Return 6
                Case "Form CP204"
                    Return 7
                Case "Form CP204A"
                    Return 8
                Case Else
                    Return 100
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetControl_Index(ByVal Type As String) As Integer
        Try
            Select Case Type.ToUpper
                Case "INPUT"
                    Return 0
                Case "BUTTON"
                    Return 1
                Case "SELECT"
                    Return 2
                Case "CHECKBOX"
                    Return 3
                Case "RADIO BUTTON"
                    Return 4
                Case "HYPER LINK"
                    Return 5
                Case Else
                    Return 100
            End Select
        Catch ex As Exception
            Return 100
        End Try
    End Function
    Public Function GetListControl() As List(Of String)
        Try
            Dim tmpListOfData As New List(Of String)

            tmpListOfData.Add("Input")
            tmpListOfData.Add("Button")
            tmpListOfData.Add("Select")
            tmpListOfData.Add("CheckBox")
            tmpListOfData.Add("Radio Button")
            tmpListOfData.Add("Hyper Link")

            Return tmpListOfData
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetListAction_Index(ByVal Type As String) As Integer
        Try
            Select Case Type.ToUpper
                Case "FILL UP"
                    Return 0
                Case "NAVAGATE"
                    Return 1
                Case "BUTTON PRESS"
                    Return 2
                Case Else
                    Return 100
            End Select
        Catch ex As Exception
            Return 100
        End Try
    End Function
    Public Function GetListAction() As List(Of String)
        Try
            Dim tmpListOfData As New List(Of String)

            tmpListOfData.Add("Fill Up")
            tmpListOfData.Add("Navagate")
            tmpListOfData.Add("Buton Press")

            Return tmpListOfData
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function UnicodeStringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function
    Private Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function
    Public Function EmailTemplate_StringChange(ByVal Title As String, ByVal Link32Bit As String, _
                                    ByVal Link64Bit As String, ByVal ChangeLog As String, ByVal Type As Integer, ByVal TypePackage As Integer, _
                                    ByVal EmailTemplate As String, ByVal Versions As String, ByVal IEToolbarV As String, Optional Errorlog As clsError = Nothing) As String
        Try

            If EmailTemplate Is Nothing OrElse EmailTemplate = "" Then
                Throw New System.Exception("An exception has occurred")
            End If

            Dim ListofPrimaryName As New List(Of String)
            ListofPrimaryName.Add("[VERSION]")
            ListofPrimaryName.Add("[TITLEVERSION]")
            ListofPrimaryName.Add("[PACKAGE]")
            ListofPrimaryName.Add("[DATETIME]")
            ListofPrimaryName.Add("[CHANGELOG]")
            ListofPrimaryName.Add("[URLFILE]")
            ListofPrimaryName.Add("[TYPE]")
            ListofPrimaryName.Add("[TYPEPACKAGE]")
            ListofPrimaryName.Add("[TYPESERVERFOLDER]")
            ListofPrimaryName.Add("[IETOOLBARVERSION]")
            ListofPrimaryName.Add("[TYPESERVERFOLDERIETOOLBAR]")

            Dim str As String = EmailTemplate
            For i As Integer = 0 To ListofPrimaryName.Count - 1
                Select Case ListofPrimaryName(i)
                    Case "[VERSION]"
                        str = str.Replace(ListofPrimaryName(i), Versions)
                    Case "[TITLEVERSION]"
                        str = str.Replace(ListofPrimaryName(i), Title)
                    Case "[PACKAGE]"
                        Select Case Type
                            Case 0
                                'Enterprise
                                str = str.Replace(ListofPrimaryName(i), "Enterprise")
                            Case 1
                                'Small Business
                                str = str.Replace(ListofPrimaryName(i), "Small Business")
                            Case 2
                                'Lite
                                str = str.Replace(ListofPrimaryName(i), "Taxoffice Lite")
                            Case 3
                                'edu
                                str = str.Replace(ListofPrimaryName(i), "Education")
                            Case 4
                                'sql enterprise
                                str = str.Replace(ListofPrimaryName(i), "SQL Edition Enterprise")
                        End Select
                    Case "[DATETIME]"
                        str = str.Replace(ListofPrimaryName(i), Format(Now, "dd-MMM-yyyy HH:mm:ss"))
                    Case "[CHANGELOG]"
                        str = str.Replace(ListofPrimaryName(i), ChangeLog)
                    Case "[URLFILE]"
                        ' str = EmailTemplate.Replace(ListofPrimaryName(i), ChangeLog)
                    Case "[TYPE]"
                        Select Case TypePackage
                            Case 0
                                'Full
                                str = str.Replace(ListofPrimaryName(i), "")
                            Case 1
                                'C
                                str = str.Replace(ListofPrimaryName(i), "C")
                            Case 2
                                'B
                                str = str.Replace(ListofPrimaryName(i), "B")
                        End Select
                    Case "[TYPEPACKAGE]"
                        Select Case TypePackage
                            Case 0
                                'Full
                                str = str.Replace(ListofPrimaryName(i), "Full Package")
                            Case 1
                                'C
                                str = str.Replace(ListofPrimaryName(i), "C+ Only")
                            Case 2
                                'B
                                str = str.Replace(ListofPrimaryName(i), "B+ Only")
                        End Select
                    Case "[TYPESERVERFOLDER]"
                        Select Case Type
                            Case 0
                                'Enterprise
                                str = str.Replace(ListofPrimaryName(i), "ES")
                            Case 1
                                'Small Business
                                str = str.Replace(ListofPrimaryName(i), "SBS")
                            Case 2
                                'Lite
                                str = str.Replace(ListofPrimaryName(i), "Lite")
                            Case 3
                                'edu
                                str = str.Replace(ListofPrimaryName(i), "Edu")
                            Case 4
                                'sql enterpise
                                str = str.Replace(ListofPrimaryName(i), "SQL")
                        End Select
                    Case "[IETOOLBARVERSION]"
                        str = str.Replace(ListofPrimaryName(i), IEToolbarV)
                    Case "[TYPESERVERFOLDERIETOOLBAR]"
                        Select Case Type
                            Case 0, 1, 2
                                'Enterprise
                                str = str.Replace(ListofPrimaryName(i), "")
                            Case 3
                                'edu
                                str = str.Replace(ListofPrimaryName(i), "Edu")
                            Case 4
                                'sql enterpise
                                str = str.Replace(ListofPrimaryName(i), "SQL")
                        End Select
                End Select
            Next

            Return str
        Catch ex As Exception

            Dim str As String = Nothing
            str = "<div style='color:#fafafa;width:100%'><img src='https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRVpylsaxX2yGiETsJMUsA0XIIwXO2g3H_ajaWYoedcB_ie0wbK'></div>"
            str += "<div><span>Dear Value Customer,</span><br />"
            str += "<div>Please click the following link to download " + Title + "</div><br /><br />"
            str += "<b>Windows XP / Window Server 2003 / Windows Vista / Windows 7 (32-bit)<b/><br />"
            str += "<a href='" + Link32Bit + "'>" + Title + " (32-Bit)</a><br />"
            str += "<b>Windows XP / Window Server 2003 / Windows Vista / Windows 7 (64-bit)<b/><br />"
            str += "<a href='" + Link64Bit + "'>" + Title + " (64-Bit)</a><br /><br />"

            str += "<b>How to Determine the system type (32-bit/64-bit)</b><br />"
            str += "Please refer the following website to determine the operating system bit count:<br />"
            str += "Microsoft Support: <a href='http://support.microsoft.com/kb/827218'>http://support.microsoft.com/kb/827218</a>"

            str += "<br /><br />"
            str += "<b>IMPORTANT REMINDER:</b><br />"
            str += "1. Please make sure you have installed Taxcom Office 2012 before update to " + Title + "<br />"
            str += "2. Please backup the databases (mdb files in Taxoffice Data) before performing the install/update/remove process.<br />"
            str += "3. Please make sure all computers installed with Taxcom Office are not in use/open during the update.<br /><br />"

            str += "<b>Installation guide for " + Title + ":</b><br />"
            str += "1. Double click the file as you download.<br />"
            str += "2. Press the 'Install/Extract' button to run the update.<br /><br /?"

            str += "ChangeLog : <br /><br />"
            str += ChangeLog

            str += "<br /><br />"
            str += "<b>YGL Multimedia Support Teams<b/>"
            str += "Mr. Kwok CS"
            str += "Phone : 012-4520188"
            str += "E-mail : kwokcs@yglworld.com"

            str += "<br /><br />"
            str += "<b>YGL Multimedia Support Teams<b/>"
            str += "Azham Bin Rosli"
            str += "Phone : 04-2290619 (ex116)"
            str += "E-mail : azhamygl@gmail.com"

            Return str
        End Try
    End Function
#End Region
End Module
