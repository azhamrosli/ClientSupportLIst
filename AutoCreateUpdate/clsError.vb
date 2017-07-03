Imports System.Math
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class clsError
    Public ErrorName As String = Nothing
    Public ErrorCode As String = Nothing
    Public ErrorMessage As String = Nothing
    Public ErrorDateTime As DateTime = Now

    Sub New()

    End Sub

    Sub New(ByVal ErrorName_ As String, ByVal ErrorCode_ As String, ByVal ErrorMessage_ As String, ByVal ErrorDateTime_ As DateTime)
        ErrorName = ErrorName_
        ErrorCode = ErrorCode_
        ErrorMessage = ErrorMessage_
        ErrorDateTime = ErrorDateTime_
    End Sub
End Class
Public Class clsOK
    Public OKName As String
    Public OKMessage As String
    Public OKRepone As String
    Public OKDateTime As DateTime
    Sub New()

    End Sub

    Sub New(ByVal OKName_ As String, ByVal OKMessage_ As String, ByVal OKRepone_ As String)
        OKName = OKName_
        OKMessage = OKMessage_
        OKRepone = OKRepone_
        OKDateTime = Now
    End Sub
End Class

