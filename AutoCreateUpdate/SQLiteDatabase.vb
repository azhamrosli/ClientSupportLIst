Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.Windows.Forms

Class SQLiteDatabase
    Private dbConnection As [String]

    ''' <summary>
    '''     Default Constructor for SQLiteDatabase Class.
    ''' </summary>
    Public Sub New()
        dbConnection = "Data Source=recipes.s3db"
    End Sub

    ''' <summary>
    '''     Single Param Constructor for specifying the DB file.
    ''' </summary>
    ''' <param name="inputFile">The File containing the DB</param>
    Public Sub New(inputFile As [String])
        dbConnection = [String].Format("{0}", inputFile)
    End Sub

    ''' <summary>
    '''     Single Param Constructor for specifying advanced connection options.
    ''' </summary>
    ''' <param name="connectionOpts">A dictionary containing all desired options and their values</param>
    Public Sub New(connectionOpts As Dictionary(Of [String], [String]))
        Dim str As [String] = ""
        For Each row As KeyValuePair(Of [String], [String]) In connectionOpts
            str += [String].Format("{0}={1}; ", row.Key, row.Value)
        Next
        str = str.Trim().Substring(0, str.Length - 1)
        dbConnection = str
    End Sub
    Public Function OpenSQLConnection() As SQLiteConnection
        Try
            Dim cnn As New SQLiteConnection(dbConnection)
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
                cnn.Close()
            End If

            Return cnn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    '''     Allows the programmer to run a query against the Database.
    ''' </summary>
    ''' <param name="sql">The SQL to run</param>
    ''' <returns>A DataTable containing the result set.</returns>
    Public Function GetDataTable(sql As SQLiteCommand, ByRef ErrorMsg As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim cnn As New SQLiteConnection(dbConnection)
            cnn.Open()
            sql.Connection = cnn
            Dim reader As SQLiteDataReader = sql.ExecuteReader()
            dt.Load(reader)
            reader.Close()
            cnn.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
            ErrorMsg = ex.Message
        End Try

    End Function

    ''' <summary>
    '''     Allows the programmer to interact with the database for purposes other than a query.
    ''' </summary>
    ''' <param name="sql">The SQL to be run.</param>
    ''' <returns>An Integer containing the number of rows updated.</returns>
    '''Public Function ExecuteNonQuery(sql As String) As Integer
    '''    Dim cnn As New SQLiteConnection(dbConnection)
    '''    cnn.Open()
    '''    Dim mycommand As New SQLiteCommand(cnn)
    '''    mycommand.CommandText = sql
    '''    Dim rowsUpdated As Integer = mycommand.ExecuteNonQuery()
    '''    cnn.Close()
    '''    Return rowsUpdated
    '''End Function
    Public Function ExecuteNonQuery(sql As SQLiteCommand, ByRef ReturnValue As Integer, ByRef ErrorMsg As String) As Boolean
        Try
            Dim cnn As New SQLiteConnection(dbConnection)
            cnn.Open()
            sql.Connection = cnn
            ReturnValue = sql.ExecuteNonQuery()

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

            Return True
        Catch ex As Exception
            ErrorMsg = ex.Message
            Return False
        End Try

    End Function
    Public Function ExecuteNonQueryTransactionCMD(ByVal Listofcmd As List(Of SQLiteCommand), ByRef ErrorMsg As String) As Boolean
        Dim txn As SQLite.SQLiteTransaction
        Dim cnn As New SQLiteConnection(dbConnection)
        Dim IndexExec As Integer = 0
        cnn.Open()
        txn = cnn.BeginTransaction
        Try

            If Listofcmd Is Nothing AndAlso Listofcmd.Count = 0 Then
                Return False
            End If

            For i As Integer = 0 To Listofcmd.Count - 1
                IndexExec = i
                Listofcmd(i).Connection = cnn
                Listofcmd(i).Transaction = txn
                Listofcmd(i).ExecuteNonQuery()
            Next

            txn.Commit()
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
            Return True
        Catch ex As Exception
            ErrorMsg = "Index No : " & IndexExec & " " & ex.Message
            If cnn.State = ConnectionState.Open Then
                cnn.Clone()
            End If
            txn.Rollback()
            Return False
        End Try
    End Function
    Public Function ExecuteNonQueryTransaction(sql As List(Of String), ByRef ErrorMsg As String) As Boolean
        Dim txn As SQLite.SQLiteTransaction
        Dim cnn As New SQLiteConnection(dbConnection)
        cnn.Open()
        txn = cnn.BeginTransaction
        Try
            Dim cmd As SQLiteCommand
            For i = 0 To sql.Count - 1
                cmd = New SQLiteCommand
                cmd.Connection = cnn
                cmd.CommandText = sql(i)
                cmd.CommandTimeout = 60
                cmd.Transaction = txn
                cmd.ExecuteNonQuery()
            Next

            txn.Commit()
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
            Return True
        Catch ex As Exception
            ErrorMsg = ex.Message
            If cnn.State = ConnectionState.Open Then
                cnn.Clone()
            End If
            txn.Rollback()
            Return False
        End Try

    End Function
    ''' <summary>
    '''     Allows the programmer to retrieve single items from the DB.
    ''' </summary>
    ''' <param name="sql">The query to run.</param>
    ''' <returns>A string.</returns>
    Public Function ExecuteScalar(sql As String) As String
        Dim cnn As New SQLiteConnection(dbConnection)
        cnn.Open()
        Dim mycommand As New SQLiteCommand(cnn)
        mycommand.CommandText = sql
        Dim value As Object = mycommand.ExecuteScalar()
        cnn.Close()
        If value IsNot Nothing Then
            Return value.ToString()
        End If
        Return ""
    End Function


End Class
