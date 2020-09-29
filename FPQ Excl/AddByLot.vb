Public Class AddByLot
    Dim sql As String = " Select " & _
                        "     (Case when ep.id is not null then 'pin'                   " & _
                        "           when ept.id is not null then 'pin/test'             " & _
                        "           when epl.id is not null then 'lot'                  " & _
                        "           when eps.id is not null then 'samp' end) as Excl    " & _
                        "     , u.mfg_site as Plant, u.pin_number as Pin, r.SampNo, u.Pallet_number as Pallet, r.acode as Analyte " & _
                        "     , r.Result, r.ViolType, r.ViolValue, r.Analyst" & _
                        " from result r " & _
                        " join suserflds u on u.sampno=r.sampno " & _
                        " left outer join limViolexcl ep on ep.strc=left(u.mfg_site,2) and ep.pnum=u.pin_number and ep.test is null and ep.lot is null and ep.sampno is null " & _
                        " left outer join limViolexcl ept on  ep.id is null and                                                                                              " & _
                        "     ept.strc=left(u.mfg_site,2) and ept.pnum=u.pin_number and ept.test=r.acode and ept.lot is null and ept.sampno is null                         " & _
                        " left outer join LimViolexcl epl on  ep.id is null and ept.id is null and                                                                           " & _
                        "     epl.strc=left(u.mfg_site,2) and epl.lot=u.lot_number and (epl.test=r.acode or epl.test is null) and epl.sampno is null                        " & _
                        " left outer join LimViolExcl eps on ep.id is null and ept.id is null and epl.id is null and                                                         " & _
                        "     eps.strc=left(u.mfg_site,2) and eps.sampno=u.sampno and (eps.test=r.acode or eps.test is null)                                                " & _
                        " where u.lot_number = @lot " & _
                        "    and (r.acode = @test or @test = '') " & _
                        "    and (r.violtype <> '' or @violonly = 0) " & _
                        "    and r.resultpart='mean_avg' " & _
                        "    and r.result <> '' "
    Dim tbl As DataTable

    Dim lwconn As SqlClient.SqlConnection
    Dim lwcmd As SqlClient.SqlCommand
    Dim lwda As SqlClient.SqlDataAdapter

    '
    ' Internals
    '

    Private Sub LoadGrid()
        tbl = New DataTable
        Try
            lwconn = New SqlClient.SqlConnection(My.Settings.ConnStr)

            lwcmd = New SqlClient.SqlCommand(sql, lwconn)
            lwcmd.Parameters.Add("@lot", SqlDbType.Char, 15).Value = LotNumber.Text
            lwcmd.Parameters.Add("@test", SqlDbType.Char, 30).Value = Analyte.Text
            lwcmd.Parameters.Add("@violonly", SqlDbType.Bit).Value = IIf(ViolOnly.Checked, 1, 0)
            lwda = New SqlClient.SqlDataAdapter(lwcmd)
            lwda.Fill(tbl)
        Catch ex As Exception
            MsgBox(ex.Message & vbLf & vbLf & "Subroutine :: " & System.Reflection.MethodBase.GetCurrentMethod.Name, MsgBoxStyle.Exclamation, Me.Text)
        End Try

        grid.DataSource = tbl
        grid.AutoResizeColumns()


    End Sub
    Private Sub ToggleSampExcl(trow As Integer, plant As String, sampno As String, test As String)

        Dim found As Boolean

        Try
            ' Does this exclusion exist?
            Using cmd As New SqlClient.SqlCommand("select coalesce(id,0) as id from limviolexcl where sampno = @sampno and test = @test", lwconn)
                cmd.Parameters.Add("@sampno", SqlDbType.VarChar, 30).Value = sampno
                cmd.Parameters.Add("@test", SqlDbType.VarChar, 30).Value = test
                If lwconn.State = ConnectionState.Broken Then lwconn.Close()
                If lwconn.State = ConnectionState.Closed Then lwconn.Open()
                Dim eid As Int64 = cmd.ExecuteScalar
                found = (eid > 0)
            End Using
            If found Then
                ' Delete it
                Using cmd As New SqlClient.SqlCommand("delete limviolexcl where sampno = @sampno and test = @test", lwconn)
                    cmd.Parameters.Add("@sampno", SqlDbType.VarChar, 30).Value = sampno
                    cmd.Parameters.Add("@test", SqlDbType.VarChar, 30).Value = test
                    If lwconn.State = ConnectionState.Broken Then lwconn.Close()
                    If lwconn.State = ConnectionState.Closed Then lwconn.Open()
                    cmd.ExecuteNonQuery()
                    grid.Rows(trow).Cells("Excl").Value = ""
                End Using
            Else
                ' Add it
                Using cmd As New SqlClient.SqlCommand("insert into limviolexcl (strc, sampno, test) values (@plant, @sampno, @test)", lwconn)
                    cmd.Parameters.Add("@plant", SqlDbType.VarChar, 30).Value = plant
                    cmd.Parameters.Add("@sampno", SqlDbType.VarChar, 30).Value = sampno
                    cmd.Parameters.Add("@test", SqlDbType.VarChar, 30).Value = test
                    If lwconn.State = ConnectionState.Broken Then lwconn.Close()
                    If lwconn.State = ConnectionState.Closed Then lwconn.Open()
                    cmd.ExecuteNonQuery()
                    grid.Rows(trow).Cells("Excl").Value = "Samp"
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbLf & vbLf & "Subroutine :: " & System.Reflection.MethodBase.GetCurrentMethod.Name, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub


    '
    ' User Interface
    '

    Private Sub Analyte_Enter(sender As Object, e As EventArgs) Handles Analyte.Enter
        Dim ssql As String = _
            "select distinct r.acode from result r " & _
            "join suserflds u on u.sampno=r.sampno " & _
            "where u.lot_number = @lot and (r.violtype <> '' or @violonly = 0)"

        sender.items.clear()
        Try
            Using cmd As New SqlClient.SqlCommand(ssql, lwconn)
                cmd.Parameters.Add("@lot", SqlDbType.VarChar, 30).Value = LotNumber.Text
                cmd.Parameters.Add("@violonly", SqlDbType.Bit).Value = IIf(ViolOnly.Checked, 1, 0)
                If lwconn.State = ConnectionState.Broken Then lwconn.Close()
                If lwconn.State = ConnectionState.Closed Then lwconn.Open()
                Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        Dim st As String = IIf(IsDBNull(dr(0)), "", dr(0))
                        If Not sender.items.contains(st) Then sender.items.add(st)
                    Loop
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbLf & vbLf & "Subroutine :: " & System.Reflection.MethodBase.GetCurrentMethod.Name, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub
    Private Sub Analyte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Analyte.SelectedIndexChanged
        LoadGrid()
    End Sub

    Private Sub AddByLot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lwconn = New SqlClient.SqlConnection(My.Settings.ConnStr)
    End Sub
    Private Sub grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim plant As String = grid.Rows(e.RowIndex).Cells("Plant").Value
            Dim sampno As String = grid.Rows(e.RowIndex).Cells("SampNo").Value
            Dim test As String = grid.Rows(e.RowIndex).Cells("Analyte").Value
            ToggleSampExcl(e.RowIndex, plant, sampno, test)
        End If
    End Sub
End Class