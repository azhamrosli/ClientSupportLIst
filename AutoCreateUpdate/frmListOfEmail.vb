Public Class frmListOfEmail

    Private Sub frmListOfEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboType.SelectedIndex = 0
        LoadData()
    End Sub
    Private Sub LoadData(Optional Typex As Integer = 0)
        Try


            Dim dt As DataTable = Nothing

            If Typex = 0 Then
                dt = mdlProcess_Office.LoadEmailUserClient_Data()
            Else
                Dim typeData As Integer = -1

                Select Case cboType.SelectedIndex
                    Case 0
                        'All
                        typeData = -1
                    Case 1
                        'Enterprise
                        typeData = 0
                    Case 2
                        'Enterprise C+
                        typeData = 1
                    Case 3
                        'Enterprise B+
                        typeData = 2
                    Case 4
                        'Small
                        typeData = 3
                    Case 5
                        'Small C+
                        typeData = 4
                    Case 6
                        'Small B+
                        typeData = 5
                    Case 7
                        'Lite
                        typeData = 6
                    Case 8
                        'Lite
                        typeData = 8
                    Case 9
                        'sql
                        typeData = 10
                End Select
                dt = mdlProcess_Office.LoadEmailUserClient_Search(txtemail.Text, typeData)
            End If

            DataSet1.Tables("dbEmail").Clear()
            If dt IsNot Nothing Then      
                DbEmailBindingSource.DataSource = dt
                Application.DoEvents()

                For i As Integer = 0 To DataGridView1.RowCount - 1
                    Select Case DataGridView1.Rows(i).Cells(4).Value
                        Case 0
                            'Enterprise
                            DataGridView1.Rows(i).Cells(5).Value = "Enterprise"
                        Case 1
                            'Enterprise C+
                            DataGridView1.Rows(i).Cells(5).Value = "Enterprise C+"
                        Case 2
                            'Enterprise B+
                            DataGridView1.Rows(i).Cells(5).Value = "Enterprise B+"
                        Case 3
                            'Small
                            DataGridView1.Rows(i).Cells(5).Value = "Small Business"
                        Case 4
                            'Small C+
                            DataGridView1.Rows(i).Cells(5).Value = "Small Business C+"
                        Case 5
                            'Small B+
                            DataGridView1.Rows(i).Cells(5).Value = "Small Business B+"
                        Case 6
                            'Lite
                            DataGridView1.Rows(i).Cells(5).Value = "Lite Business"
                        Case 7
                            'Lite
                            DataGridView1.Rows(i).Cells(5).Value = "Education"
                        Case 10
                            'sql
                            DataGridView1.Rows(i).Cells(5).Value = "SQL"
                    End Select
                Next
            End If

        Catch ex As Exception

        Finally
            txtemail.Focus()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            LoadData(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtemail.Clear()
            cboType.SelectedIndex = 0
            LoadData(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyEmailToolStripMenuItem.Click
        Try
            If DataGridView1.RowCount > 0 Then
                Dim tmpstring As String = Nothing
                For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                    tmpstring = DataGridView1.SelectedRows(i).Cells(3).Value
                    My.Computer.Clipboard.SetText(tmpstring)
                Next
                MsgBox("Data copy this  clipboard : " & tmpstring)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyCompanyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyCompanyNameToolStripMenuItem.Click
        Try
            If DataGridView1.RowCount > 0 Then
                Dim tmpstring As String = Nothing
                For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                    tmpstring = DataGridView1.SelectedRows(i).Cells(2).Value
                    My.Computer.Clipboard.SetText(tmpstring)
                Next
                MsgBox("Data copy this  clipboard : " & tmpstring)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class