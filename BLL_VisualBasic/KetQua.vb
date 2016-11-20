Imports Microsoft.VisualBasic
Imports System.Data

Public Class KetQua

    Private mahv As String 'mã học viên
    Private mamon As String ' mã môn học
    Private d15 As Double ' điểm 15 phút
    Private d1t As Double ' điểm một tiết
    Private dhk As Double ' điểm học kỳ
    Private tbm As Double ' trung bình môn
    Private hk As Integer ' học kỳ
    Private malop As String ' mã lớp

    Public Property MaHocVien() As String
        Get
            Return mahv
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                mahv = value.Substring(0, 50)
            Else
                mahv = value
            End If
        End Set
    End Property

    Public Property MaMonHoc() As String
        Get
            Return mamon
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                mamon = value.Substring(0, 50)
            Else
                mamon = value
            End If
        End Set
    End Property

    Public Property DiemMuoiLam() As Double
        Get
            Return d15
        End Get

        Set(ByVal value As Double)
            If value >= 0 Then
                d15 = value
            Else
                d15 = 0
            End If
        End Set
    End Property

    Public Property DiemMotTiet() As Double
        Get
            Return d1t
        End Get

        Set(ByVal value As Double)
            If value >= 0 Then
                d1t = value
            Else
                d1t = 0
            End If
        End Set
    End Property

    Public Property DiemThiHocKy() As Double
        Get
            Return dhk
        End Get

        Set(ByVal value As Double)
            If value >= 0 Then
                dhk = value
            Else
                dhk = 0
            End If
        End Set
    End Property

    Public Property TrungBinhMon() As Double
        Get
            Return tbm
        End Get

        Set(ByVal value As Double)
            If value >= 0 Then
                tbm = value
            Else
                tbm = 0
            End If
        End Set
    End Property

    Public Property HocKy() As Integer
        Get
            Return hk
        End Get

        Set(ByVal value As Integer)
            hk = value
        End Set

    End Property

    Public Property MaLopHoc() As String
        Get
            Return malop
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                malop = value.Substring(0, 50)
            Else
                malop = value
            End If
        End Set
    End Property

    Public Function LayBangDiem() As DataTable

        Dim dt As DataTable
        Dim query As String = "SELECT * FROM ketqua"
        dt = SqlServerAdapter.ReadData(query)

        Return dt

    End Function

    Public Function LayBangDiemTheoHoTen(ByVal hohs As String, ByVal tenhs As String) As DataTable

        Dim query As String = "SELECT hs.mahs, hohs, tenhs, tenlop FROM hocsinh hs ,hocsinh_lop hsl, lop l WHERE hs.hohs='" & hohs.Trim & "' AND tenhs='" & tenhs.Trim & "' AND hs.mahs=hsl.mahs AND hsl.malop=l.malop"

        Return SqlServerAdapter.ReadData(query)

    End Function

    Public Function LayBangDiemTheoMaHS(ByVal ma As String) As DataTable

        Dim query As String = "SELECT k.mamon, tenmon, diem15, diem1tiet, diemhocky, tbmon, hocky, malop FROM ketqua k, monhoc m WHERE k.mamon = m.mamon AND mahv='" & ma.Trim & "'"

        Return SqlServerAdapter.ReadData(query)

    End Function

    Public Function LayBangDiemTheoLop() As DataTable

        Dim query As String = "SELECT hohs, tenhs, diem15, diem1tiet, diemhocky, tbmon, hocky FROM hocsinh INNER JOIN ketqua ON hocsinh.mahs=ketqua.mahv WHERE malop='" & Me.MaLopHoc & "' AND mamon='" & Me.MaMonHoc & "'"

        Return SqlServerAdapter.ReadData(query)

    End Function

    Public Sub Them()

        Dim query As String = "INSERT INTO ketqua(mahv,mamon,diem15,diem1tiet,diemhocky,tbmon,hocky,malop) VALUES(@mahv,@mamon,@diem15,@diem1tiet,@diemhocky,@tbmon,@hocky,@malop)"
        Dim parms As String() = {"@mahv", "@mamon", "@diem15", "@diem1tiet", "@diemhocky", "@tbmon", "@hocky", "@malop"}
        Dim values As String() = {Me.MaHocVien, Me.MaMonHoc, Me.DiemMuoiLam, Me.DiemMotTiet, Me.DiemThiHocKy, Me.TrungBinhMon, Me.HocKy, Me.MaLopHoc}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, parms, values)

    End Sub

    Public Overloads Sub Xoa()

        Dim query As String = "DELETE FROM ketqua WHERE mahv=@mahv AND mamon=@mamon AND hocky=@hocky AND malop=@malop"
        Dim params As String() = {"@mahv", "@mamon", "@hocky", "@malop"}
        Dim values As String() = {Me.MaHocVien, Me.MaMonHoc, Me.HocKy.ToString, Me.MaLopHoc}
        Dim sqltype As SqlDbType() = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values, sqltype)

    End Sub

    Public Overloads Sub Xoa(ByVal mhv As String)

        Dim query As String = "DELETE FROM ketqua WHERE mahv=@mahv"
        Dim params As String() = {"@mahv"}
        Dim values As String() = {mhv}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values)

    End Sub

    Public Overloads Sub Xoa(ByVal mhv As String, ByVal ml As String)

        Dim query As String = "DELETE FROM ketqua WHERE mahv=@mahv AND malop=@malop"
        Dim params As String() = {"@mahv", "@malop"}
        Dim values As String() = {mhv, ml}

        SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values)

    End Sub

    Public Overloads Sub CapNhat()

        Dim dt As New DataTable
        dt = SqlServerAdapter.ReadData("SELECT * FROM ketqua")
        Dim drs As DataRow() = dt.Select("mahv='" & Me.MaHocVien & "' and mamon='" & Me.MaMonHoc & "' and hocky=" & Me.HocKy & " and malop='" & Me.MaLopHoc & "'")
        If drs.Length <> 0 Then
            drs(0)("diem15") = Me.DiemMuoiLam
            drs(0)("diem1tiet") = Me.DiemMotTiet
            drs(0)("diemhocky") = Me.DiemThiHocKy
            drs(0)("tbmon") = Me.TrungBinhMon
            SqlServerAdapter.WriteData(dt, "ketqua")
        End If

    End Sub

    Public Function DaCoDiem() As Boolean

        Dim query As String = "SELECT COUNT(*) FROM ketqua WHERE mahv='" & MaHocVien & "' AND mamon='" & Me.MaMonHoc & "' AND hocky=" & Me.HocKy & "' AND malop='" & Me.MaLopHoc & "'"
        Dim count As Integer = DirectCast(SqlQuery.ExecuteScalar(query, CommandType.Text), Integer)

        Return IIf(count > 0, True, False)

    End Function

    Public Function LayBangDiemTungHocSinh() As DataTable

        Dim query As String = "SELECT mamon, diem15, diem1tiet, diemhocky, tbmon FROM ketqua WHERE mahv='" & Me.MaHocVien & "' AND malop='" & Me.MaLopHoc & "' AND hocky=" & Me.HocKy
        Return SqlServerAdapter.ReadData(query)

    End Function
End Class
