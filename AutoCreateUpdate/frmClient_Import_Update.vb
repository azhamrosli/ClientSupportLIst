Public Class frmClient_Import_Update

    Dim ErrorLog As clsError = Nothing
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            Dim ofdResult As Windows.Forms.DialogResult = OpenFileDialog1.ShowDialog
            txtFileName.Clear()
            If ofdResult = Windows.Forms.DialogResult.OK AndAlso System.IO.File.Exists(OpenFileDialog1.FileName) Then
                Dim currentRow As String()
                txtFileName.Text = OpenFileDialog1.FileName

                Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(OpenFileDialog1.FileName)
                    MyReader.TextFieldType = FileIO.FieldType.Delimited
                    MyReader.SetDelimiters(",")
                    currentRow = MyReader.ReadFields()

                    Dim dtRow As DataRow
                    Dim tmpID As String = Nothing
                    Dim indextmp As Integer = 0
                    DataSet1.Tables("dtClient").Rows.Clear()

                    While Not MyReader.EndOfData
                        indextmp += 1

                        If indextmp <> 1 Then

                            currentRow = Nothing
                            currentRow = MyReader.ReadFields()

                            If currentRow IsNot Nothing AndAlso currentRow.Length > 0 Then

                                dtRow = DataSet1.Tables("dtClient").NewRow

                                dtRow("ID") = ""
                                dtRow("CompanyName") = currentRow(1)
                                dtRow("Address1") = currentRow(4)
                                dtRow("Address2") = currentRow(5)
                                dtRow("Address3") = currentRow(6)
                                dtRow("State") = currentRow(10)
                                dtRow("City") = currentRow(9)
                                dtRow("Postcode") = currentRow(8)
                                dtRow("Country") = currentRow(11)
                                dtRow("Phone1") = currentRow(12)
                                dtRow("Phone2") = ""
                                dtRow("FaxNo") = ""
                                dtRow("License_Enterprise") = ""
                                dtRow("License_SmallBusiness") = ""
                                dtRow("License_Lite") = ""
                                dtRow("License_Trial") = ""
                                dtRow("RefID") = currentRow(2)

                                DataSet1.Tables("dtClient").Rows.Add(dtRow)
                                Application.DoEvents()

                            End If
                        End If

                    End While

                    dgview.DataSource = DataSet1.Tables("dtClient")
                End Using

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellEndEdit
        Try
            If e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Then
                If IsDBNull(dgview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True OrElse dgview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" OrElse IsNumeric(dgview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False Then
                    dgview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            For i As Integer = 0 To dgview.Rows.Count - 1
                If dgview.Rows(i).Selected = True Then
                    dgview.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If mdlProcess_Office.UpdateImportClient2(dgview, ErrorLog) Then
                MsgBox("Successfully import data", MsgBoxStyle.Information)
                Me.Close()
            Else
                MsgBox("Unsuccessfully import database" & vbCrLf & ErrorLog.ErrorMessage, MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmClient_Import_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class