Imports Microsoft.VisualBasic
Imports System.Data

Public Class HocSinhLop

    Private mahs As String ' mã học sinh
    Private ma As String ' mã lớp

    Public Property MaHocSinh() As String
        Get
            Return mahs
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                mahs = value.Substring(0, 50)
            Else
                mahs = value
            End If
        End Set
    End Property

    Public Property MaLop() As String
        Get
            Return ma
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                ma = value.Substring(0, 50)
            Else
                ma = value
            End If
        End Set
    End Property

    Public Function DanhSachHocSinhLop() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh_lop")

    End Function

    Public Sub Them()

        Dim dt As DataTable = Me.DanhSachHocSinhLop
        Dim dr As DataRow = dt.NewRow

        dr("mahs") = Me.MaHocSinh
        dr("malop") = Me.MaLop
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "hocsinh_lop")

    End Sub

    Public Overloads Sub Xoa()

        Dim query As String = "DELETE FROM hocsinh_lop WHERE mahs=@mahs AND malop=@malop"
        Dim params As String() = {"@mahs", "@malop"}
        Dim values As String() = {Me.MaHocSinh, Me.MaLop}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values)

    End Sub

    Public Overloads Sub Xoa(ByVal mhs As String)

        Dim query As String = "DELETE FROM hocsinh_lop WHERE mahs=@mahs"
        Dim params As String() = {"@mahs"}
        Dim values As String() = {mhs}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values)

    End Sub

    Public Sub CapNhat(ByVal mahs_old As String, ByVal malop_old As String)

        Dim dt As DataTable = Me.DanhSachHocSinhLop
        Dim drs As DataRow() = dt.Select("mahs='" & mahs_old.Trim & "' and malop='" & malop_old.Trim & "'")

        If drs.Length <> 0 Then
            drs(0)("mahs") = Me.MaHocSinh
            drs(0)("malop") = Me.MaLop
            SqlServerAdapter.WriteData(dt, "hocsinh_lop")
        End If

    End Sub

End Class
