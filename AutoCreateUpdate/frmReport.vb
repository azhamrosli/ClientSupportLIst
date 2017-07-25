Public Class frmReport

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            cboReportType.SelectedIndex = cboReportType.Items.Count - 1
            Application.DoEvents()
            LoadData()
        Catch ex As Exception

        End Try
        'Me.ReportViewer1.RefreshReport()
        Me.rptView.RefreshReport()
    End Sub
    Private Sub LoadData()
        Try
            Me.Cursor = Cursors.AppStarting
            Application.DoEvents()
            Dim dt As DataTable = Nothing
            Select Case cboReportType.SelectedIndex
                Case 0
                    'Today report
                    dtFroms.Value = Now
                    dtTos.Value = Now

                    dt = mdlProcess_Office.LoadSupport_Search("", "", dtFroms.Value, dtTos.Value, -1, "", "")

                    If dt IsNot Nothing Then
                        ReportByDate(dt)
                    End If

                Case 1
                    'monthly
                    'Today report
                    Dim datLastDay As Date = GetLastDayOfMonth(Now.Month, Now.Year)
                    dtFroms.Value = CDate(Format(Now, "01-MMM-yyyy 00:00:00"))
                    dtTos.Value = CDate(Format(datLastDay, "dd-MMM-yyyy 23:59:59"))

                    dt = mdlProcess_Office.LoadSupport_Search("", "", dtFroms.Value, dtTos.Value, -1, "", "")

                    If dt IsNot Nothing Then
                        ReportByDate(dt)
                    End If

                Case 2

                    'yearly
                    'Today report
                    Dim Firstyear As New DateTime(DateTime.Now.Year, 1, 1)
                    Dim Lastyear As New DateTime(DateTime.Now.Year, 12, 31)
                    dtFroms.Value = Firstyear
                    dtTos.Value = Lastyear

                    dt = mdlProcess_Office.LoadSupport_Search("", "", dtFroms.Value, dtTos.Value, -1, "", "")

                    If dt IsNot Nothing Then
                        ReportByDate(dt)
                    End If

                Case 3
                    'custom date

                    dt = mdlProcess_Office.LoadSupport_Search("", "", dtFroms.Value, dtTos.Value, -1, "", "")

                    If dt IsNot Nothing Then
                        ReportByDate(dt)
                    End If

                Case 4

                    dt = mdlProcess_Office.LoadTopSupportReport()

                    If dt IsNot Nothing Then
                        ReportByTopSupport(dt)
                    End If

            End Select

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ReportByDate(ByVal dt As DataTable)
        Try
            Dim tmpstr As String = Nothing
            Dim bindingsource As BindingSource
            Dim DateFrom As DateTime
            Dim DateTo As DateTime
            If dt IsNot Nothing Then

                Dim dr As DataRow
                DsReport1.Tables("dtSupport").Rows.Clear()

                Application.DoEvents()

                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = DsReport1.Tables("dtSupport").NewRow()
                    dr("ID") = IIf(IsDBNull(dt.Rows(i)("ID")), 0, dt.Rows(i)("ID"))
                    dr("CompanyID") = IIf(IsDBNull(dt.Rows(i)("RefID")), "", dt.Rows(i)("RefID"))
                    dr("CompanyName") = IIf(IsDBNull(dt.Rows(i)("CompanyName")), "", dt.Rows(i)("CompanyName"))
                    dr("Phone1") = IIf(IsDBNull(dt.Rows(i)("Phone1")), "", dt.Rows(i)("Phone1"))

                    tmpstr = Nothing
                    If IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 1 Then
                        tmpstr += "Enterprise,"
                    ElseIf IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 2 Then
                        tmpstr += "Enterprise C+,"
                    ElseIf IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 3 Then
                        tmpstr += "Enterprise B+,"
                    End If

                    If IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 1 Then
                        tmpstr += "Small Business,"
                    ElseIf IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 2 Then
                        tmpstr += "Small Business C+,"
                    ElseIf IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 3 Then
                        tmpstr += "Small Business B+,"
                    End If

                    If IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 1 Then
                        tmpstr += "Lite,"
                    ElseIf IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 2 Then
                        tmpstr += "Lite C+,"
                    ElseIf IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 3 Then
                        tmpstr += "Lite B+,"
                    End If

                    If IsDBNull(dt.Rows(i)("License_Education")) = False AndAlso dt.Rows(i)("License_Education") = 1 Then
                        tmpstr += "Education,"
                    End If
                    If IsDBNull(dt.Rows(i)("License_Trial")) = False AndAlso dt.Rows(i)("License_Trial") = 1 Then
                        tmpstr += "Trial,"
                    End If
                    If IsDBNull(dt.Rows(i)("License_SQL_En")) = False AndAlso dt.Rows(i)("License_SQL_En") = 1 Then
                        tmpstr += "SQL,"
                    End If
                    dr("LicenseType") = tmpstr


                    dr("ServerName") = IIf(IsDBNull(dt.Rows(i)("ServerName")), "", dt.Rows(i)("ServerName"))
                    dr("DateTime") = IIf(IsDBNull(dt.Rows(i)("DateTime")), Now, dt.Rows(i)("DateTime"))
                    dr("TeamviewerID") = IIf(IsDBNull(dt.Rows(i)("TeamviewerID")), "", dt.Rows(i)("TeamviewerID"))
                    dr("PersonName") = IIf(IsDBNull(dt.Rows(i)("PersonName")), "", dt.Rows(i)("PersonName"))
                    dr("Problem") = IIf(IsDBNull(dt.Rows(i)("Problem")), "", dt.Rows(i)("Problem"))
                    dr("Note") = IIf(IsDBNull(dt.Rows(i)("Note")), "", dt.Rows(i)("Note"))
                    dr("DateCreated") = IIf(IsDBNull(dt.Rows(i)("DateCreated")), Now, dt.Rows(i)("DateCreated"))
                    dr("ModifiedBy") = IIf(IsDBNull(dt.Rows(i)("ModifiedBy")), "", dt.Rows(i)("ModifiedBy"))
                    dr("DateTimeFrom") = dtFroms.Value
                    dr("DateTimeTo") = dtTos.Value
                    dr("TotalSupport") = dt.Rows.Count.ToString
                    dr("TotalSupportYear") = mdlProcess_Office.LoadSupportTotalSupport(4, DateFrom, DateTo).ToString
                    dr("Status") = mdlProcess_Office.GetStatusSupport(IIf(IsDBNull(dt.Rows(i)("Status")), 0, dt.Rows(i)("Status")))
                    DsReport1.Tables("dtSupport").Rows.Add(dr)
                Next

                bindingsource = New BindingSource
                bindingsource.DataSource = DsReport1
                bindingsource.DataMember = "dtSupport"

                Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
                ReportDataSource1.Name = "dsReport"
                ReportDataSource1.Value = bindingsource

                Me.rptView.LocalReport.ReportPath = Application.StartupPath & "\rptSupportList.rdlc"
                Me.rptView.LocalReport.DataSources.Add(ReportDataSource1)
                Me.rptView.LocalReport.EnableExternalImages = True
                Me.rptView.ServerReport.Refresh()
                Me.rptView.RefreshReport()




            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ReportByTopSupport(ByVal dt As DataTable)
        Try
            Dim tmpstr As String = Nothing
            Dim bindingsource As BindingSource

            If dt IsNot Nothing Then

                Dim dr As DataRow
                dsTopSupport.Tables("dtTopSupport").Rows.Clear()

                Application.DoEvents()

                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dsTopSupport.Tables("dtTopSupport").NewRow()
                    dr("ID") = i
                    dr("CompanyID") = IIf(IsDBNull(dt.Rows(i)("CompanyID")), "", dt.Rows(i)("CompanyID"))
                    dr("CompanyName") = IIf(IsDBNull(dt.Rows(i)("CompanyName")), "", dt.Rows(i)("CompanyName"))
                    dr("Count") = IIf(IsDBNull(dt.Rows(i)("countx")), 0, dt.Rows(i)("countx"))

                    dsTopSupport.Tables("dtTopSupport").Rows.Add(dr)
                Next

                ' bindingsource = New BindingSource
                dtTopSupportBindingSource.DataSource = dsTopSupport
                dtTopSupportBindingSource.DataMember = "dtTopSupport"

                Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
                ReportDataSource1.Name = "dsTopSupport"
                ReportDataSource1.Value = dtTopSupportBindingSource

                Me.rptView.LocalReport.ReportPath = Application.StartupPath & "\rptTopSupport.rdlc"
                Me.rptView.LocalReport.DataSources.Add(ReportDataSource1)
                Me.rptView.ServerReport.Refresh()
                Me.rptView.RefreshReport()



            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        LoadData()
    End Sub
End Class