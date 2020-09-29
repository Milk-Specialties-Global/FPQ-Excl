Public Class Form1
    Dim sql As String = " ID, Strc, Pnum, Lot, SampNo, Test from LimViolExcl " & _
                        " where (strc = @plant or @plant = '') " & _
                        "    and (pnum = @item or @item = '') " & _
                        "    and (lot = @lot or @lot = '') " & _
                        "    and (sampno = @sampno or @sampno = '') " & _
                        "    and (test = @test or @test = '') "
    Dim tbl As DataTable

    Dim lwconn As SqlClient.SqlConnection
    Dim lwcmd As SqlClient.SqlCommand
    Dim lwda As SqlClient.SqlDataAdapter
    Dim lwbld As SqlClient.SqlCommandBuilder

    '
    ' Internals
    '

    Private Sub errmsg(priMsg As String, ex As Exception)
        Dim st As New StackTrace(True)
        st = New StackTrace(ex, True)
        Dim ii As Integer = st.GetFrames.Count - 1

        MsgBox(priMsg & vbCr & vbCr & _
               "IS Information..." & vbCr & _
               vbTab & "Method :: " & st.GetFrame(ii).GetMethod.Name & vbCr & _
               vbTab & "Line # :: " & st.GetFrame(ii).GetFileLineNumber.ToString & vbCr & _
               vbTab & "File   :: " & st.GetFrame(ii).GetFileName, MsgBoxStyle.Critical, Me.Text)
    End Sub

    Public Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is 
          Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

    Private Function IsInADGroup(userName As String, groupName As String) As Boolean
        Dim wi As Security.Principal.WindowsIdentity = New Security.Principal.WindowsIdentity(userName)
        Dim rslt As Boolean = False
        For Each group As Security.Principal.IdentityReference In wi.Groups
            Dim thisGroup As String = group.Translate(GetType(Security.Principal.NTAccount)).ToString()
            Debug.Print(thisGroup)
            If thisGroup = groupName Then
                rslt = True
                Exit For
            End If
        Next
        Return rslt
    End Function
    Private Function CheckDirty() As Boolean
        Dim resp As Boolean = False
        If Not IsNothing(tbl) Then
            If Not IsNothing(tbl.GetChanges) Then
                resp = MsgBox("There unsaved changes that will be discarded if you reload." & vbLf & vbLf & "Are you sure?", MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes
            End If
        End If
        Return resp
    End Function
    Private Sub LoadGrid()

        If CheckDirty() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim largeds As Boolean

        tbl = New DataTable
        Try
            lwconn = New SqlClient.SqlConnection(My.Settings.ConnStr)

            ' First check for large data set
            Using cmd As New SqlClient.SqlCommand("select count(1) as cnt from (select" & sql & ") a", lwconn)
                cmd.Parameters.Add("@plant", SqlDbType.Char, 2).Value = vStrc.Text
                cmd.Parameters.Add("@item", SqlDbType.Char, 15).Value = vPnum.Text
                cmd.Parameters.Add("@lot", SqlDbType.Char, 15).Value = vLot.Text
                cmd.Parameters.Add("@sampno", SqlDbType.VarChar, 7).Value = vSampno.Text
                cmd.Parameters.Add("@test", SqlDbType.Char, 30).Value = vTest.Text
                If lwconn.State = ConnectionState.Broken Then lwconn.Close()
                If lwconn.State = ConnectionState.Closed Then lwconn.Open()
                largeds = (cmd.ExecuteScalar() > 5000)
            End Using

            lbLargeDS.Visible = largeds

            lwcmd = New SqlClient.SqlCommand(IIf(largeds, "select top 5000 ", "select ") & sql, lwconn)
            lwcmd.Parameters.Add("@plant", SqlDbType.Char, 2).Value = vStrc.Text
            lwcmd.Parameters.Add("@item", SqlDbType.Char, 15).Value = vPnum.Text
            lwcmd.Parameters.Add("@lot", SqlDbType.Char, 15).Value = vLot.Text
            lwcmd.Parameters.Add("@sampno", SqlDbType.VarChar, 7).Value = vSampno.Text
            lwcmd.Parameters.Add("@test", SqlDbType.Char, 30).Value = vTest.Text
            lwda = New SqlClient.SqlDataAdapter(lwcmd)
            lwbld = New SqlClient.SqlCommandBuilder(lwda)
            lwda.Fill(tbl)
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MsgBox(ex.Message & vbLf & vbLf & "Subroutine :: " & System.Reflection.MethodBase.GetCurrentMethod.Name, MsgBoxStyle.Exclamation, Me.Text)
        End Try

        grid.DataSource = tbl
        grid.AutoResizeColumns()
        grid.Columns("ID").ReadOnly = True

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        Try
            lwda.Update(tbl)
        Catch ex As Exception
            MsgBox(ex.Message & vbLf & vbLf & "Subroutine :: " & System.Reflection.MethodBase.GetCurrentMethod.Name, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    '
    ' User Interface
    '
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Security to run this
        Try
            If Not IsInADGroup(GetUserName(), "MILKSPECIALTIES\Domain Admins") Then _
            If Not IsInADGroup(GetUserName(), "MILKSPECIALTIES\LW_ADMIN") Then _
                Throw New System.Exception("This app is for domain or labworks admins only. User: " & GetUserName())
        Catch ex As Exception
            errmsg(ex.Message, ex)
            Me.Close()
        End Try

        LoadGrid()
    End Sub
    Private Sub bReload_Click(sender As Object, e As EventArgs) Handles bReload.Click
        LoadGrid()
    End Sub
    Private Sub vComboEnter(sender As Object, e As EventArgs) Handles vStrc.Enter, vPnum.Enter, vSampno.Enter, vLot.Enter, vTest.Enter
        ' Generic entry loading routine, requires:
        ' Sending control is a combobox
        ' Name of the sending control be <single letter>FieldName (vStrc, vPnum, etc.)

        Dim fldname As String = sender.name.ToString.Substring(1, Len(sender.name) - 1)
        Dim ssql As String = "select distinct top 1000 " & fldname & " from limviolexcl where " & fldname & " is not null "
        If fldname <> "Strc" And vStrc.Text <> "" Then ssql = ssql & " and strc = @plant"
        If fldname <> "Pnum" And vPnum.Text <> "" Then ssql = ssql & " and pnum = @item"
        If fldname <> "Lot" And vLot.Text <> "" Then ssql = ssql & " and lot = @lot"
        If fldname <> "Sampno" And vSampno.Text <> "" Then ssql = ssql & " and sampno = @sampno"

        ssql = ssql & " order by " & fldname

        If fldname = "Strc" Or fldname = "Lot" Or fldname = "Sampno" Then ssql = ssql & " desc"


        sender.Items.Clear()
        sender.items.add("")
        Using cmd As New SqlClient.SqlCommand(ssql, lwconn)
            cmd.Parameters.Add("@plant", SqlDbType.Char, 2).Value = vStrc.Text
            cmd.Parameters.Add("@item", SqlDbType.Char, 15).Value = vPnum.Text
            cmd.Parameters.Add("@lot", SqlDbType.Char, 15).Value = vLot.Text
            cmd.Parameters.Add("@sampno", SqlDbType.VarChar, 7).Value = vSampno.Text
            cmd.Parameters.Add("@test", SqlDbType.Char, 30).Value = vTest.Text
            If lwconn.State = ConnectionState.Broken Then lwconn.Close()
            If lwconn.State = ConnectionState.Closed Then lwconn.Open()
            Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    Dim st As String = IIf(IsDBNull(dr(0)), "", dr(0))
                    If Not sender.Items.Contains(st) Then sender.Items.Add(st)
                Loop
            End Using
        End Using
        If sender.Items.Count = 2 Then sender.selectedindex = 1
    End Sub
    Private Sub grid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grid.CellFormatting
        ' force all columns to upper case
        If Not IsNothing(e.Value) Then
            e.Value = e.Value.ToString.ToUpper
            e.FormattingApplied = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        vStrc.Text = ""
        vStrc.Items.Clear()
        vPnum.Text = ""
        vPnum.Items.Clear()
        vLot.Text = ""
        vLot.Items.Clear()
        vSampno.Text = ""
        vSampno.Items.Clear()
        vTest.Text = ""
        vTest.Items.Clear()
    End Sub
    Private Sub AppClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = CheckDirty()
    End Sub

    Private Sub OpenAddByLotWindow(sender As Object, e As EventArgs) Handles Button2.Click
        AddByLot.ShowDialog()
    End Sub
End Class
