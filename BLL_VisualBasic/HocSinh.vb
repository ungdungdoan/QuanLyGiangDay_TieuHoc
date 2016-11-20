Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class HocSinh

    Private mahs As String ' mã học sinh
    Private hohs As String ' họ học sinh
    Private tenhs As String ' tên học sinh
    Private ns As DateTime ' ngày sinh
    Private p As Boolean ' phái  (0: nữ , 1: nam)
    Private dc As String ' địa chỉ
    Private dt As String ' điện thoại

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

    Public Property HoHocSinh() As String
        Get
            Return hohs
        End Get

        Set(ByVal value As String)
            value = value.Trim
            If Not value Is Nothing And value.Length > 50 Then
                hohs = value.Substring(0, 50)
            Else
                hohs = value
            End If
        End Set
    End Property

    Public Property TenHocSinh() As String
        Get
            Return tenhs
        End Get

        Set(ByVal value As String)
            value = value.Trim
            If Not value Is Nothing And value.Length > 50 Then
                tenhs = value.Substring(0, 50)
            Else
                tenhs = value
            End If
        End Set
    End Property

    Public Property NgaySinh() As DateTime
        Get
            Return ns
        End Get

        Set(ByVal value As DateTime)
            ns = value
        End Set
    End Property

    Public Property Phai() As Boolean
        Get
            Return p
        End Get

        Set(ByVal value As Boolean)
            p = value
        End Set
    End Property

    Public Property DiaChi() As String
        Get
            Return dc
        End Get

        Set(ByVal value As String)
            value = value.Trim
            If Not value Is Nothing And value.Length > 50 Then
                dc = value.Substring(0, 50)
            Else
                dc = value
            End If
        End Set
    End Property

    Public Property DienThoai() As String
        Get
            Return dt
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 20 Then
                dt = value.Substring(0, 20)
            Else
                dt = value
            End If
        End Set
    End Property

    Public Overloads Function DanhSachHocSinh() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh")

    End Function

    Public Overloads Function DaTonTaiHocSinh() As Boolean

        Return IIf(Me.TimTheoMaHocSinh.Rows.Count > 0, True, False)

    End Function

    Public Overloads Function DanhSachHocSinh(ByVal malop As String) As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh WHERE SUBSTRING(mahs,3,8)='" & malop & "'")

    End Function

    Public Function TimTheoHoTen() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh WHERE hohs='" & Me.HoHocSinh.Trim & "' AND ten='" & Me.TenHocSinh.Trim & "'")

    End Function

    Public Function TimTheoTen() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh WHERE ten='" & Me.TenHocSinh.Trim & "'")

    End Function

    Public Function TimTheoMaHocSinh() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM hocsinh WHERE mahs='" & Me.MaHocSinh & "'")

    End Function

    Public Function TimHoTenTheoMa() As String

        Return CStr(SqlQuery.ExecuteScalar("SELECT hohs + ' ' + tenhs FROM hocsinh WHERE mahs='" & Me.MaHocSinh & "'"))

    End Function
    Public Overloads Sub Them(ByVal khoilop As Integer, ByVal namhoc As Integer)

        Dim malop As String = LopHoc.TimMaLop(namhoc, khoilop)
        Dim lop As New LopHoc
        Dim hsl As New HocSinhLop

        If malop Is Nothing Then
            malop = LopHoc.TaoMaLopMoi(khoilop, namhoc)
            lop.MaLop = malop
            lop.Khoi = CStr(khoilop)
            lop.TenLop = ""
            lop.NamHoc = namhoc
            lop.Them()
        End If

        Me.MaHocSinh = Me.TaoMaHocSinh(malop)
        Me.Them()
        hsl.MaHocSinh = Me.MaHocSinh
        hsl.MaLop = malop
        hsl.Them()

    End Sub

    Public Overloads Sub Them()

        Dim dt As DataTable = Me.DanhSachHocSinh()
        Dim dr As DataRow = dt.NewRow
        dr("mahs") = Me.MaHocSinh
        dr("hohs") = Me.hohs
        dr("tenhs") = Me.TenHocSinh
        dr("ngaysinh") = Me.NgaySinh
        dr("phai") = Me.Phai
        dr("diachi") = Me.DiaChi
        dr("dienthoai") = Me.DienThoai
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "hocsinh")

    End Sub

    Public Sub CapNhat()

        Dim dt As New DataTable
        dt = SqlServerAdapter.ReadData("SELECT * FROM hocsinh")
        Dim drs As DataRow() = dt.Select("mahs='" & Me.MaHocSinh & "'")

        If drs.Length <> 0 Then
            drs(0)("hohs") = Me.HoHocSinh
            drs(0)("tenhs") = Me.TenHocSinh
            drs(0)("ngaysinh") = Me.NgaySinh
            drs(0)("phai") = Me.Phai
            drs(0)("diachi") = Me.DiaChi
            drs(0)("dienthoai") = Me.DienThoai
            SqlServerAdapter.WriteData(dt, "hocsinh")
        End If

    End Sub

    Public Sub Xoa()

        Dim query As String = "DELETE FROM hocsinh WHERE mahs=@mahs"
        Dim params As String() = {"@mahs"}
        Dim values As String() = {Me.MaHocSinh}

        Dim hsl As New HocSinhLop
        Dim kq As New KetQua

        hsl.Xoa(Me.MaHocSinh)
        kq.Xoa(Me.MaHocSinh)

        Try
            SqlQuery.ExecuteNonQuery(query, CommandType.Text, params, values)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function TaoMaHocSinh(ByVal malop As String) As String

        Dim result As String = ""
        Dim query As String = "SELECT MAX(RIGHT(mahs,2))+1 FROM hocsinh WHERE SUBSTRING(mahs,3,8)='" & malop & "'"
        Dim sttmax As String = ""

        Try
            If LopHoc.LopDaTonTai(malop) Then
                If LopHoc.SiSo(malop) > 0 Then
                    sttmax = CStr(SqlQuery.ExecuteScalar(query))
                    If (sttmax.Length = 1) Then
                        sttmax = "0" & sttmax
                    End If
                Else
                    sttmax = "01"
                End If
            Else
                Exit Try
            End If
        Catch ex As Exception
            Throw ex
        End Try

        result = "HS" & malop & sttmax

        Return result

    End Function

    Public Sub ChuyenLop(ByVal malop_new As String)

        Dim mahs_new As String = Me.TaoMaHocSinh(malop_new)

        ' Tắt constraint
        Dim query As String = "ALTER TABLE ketqua NOCHECK CONSTRAINT FK_ketqua_hocsinh " & _
                              "ALTER TABLE hocsinh_lop NOCHECK CONSTRAINT FK_hocsinh_lop_hocsinh " & _
                              "UPDATE hocsinh SET mahs='" & mahs_new & "' WHERE mahs='" & Me.MaHocSinh & "' " & _
                              "UPDATE hocsinh_lop SET mahs='" & mahs_new & "', malop='" & malop_new & "' WHERE mahs='" & Me.MaHocSinh & "' AND malop='" & Me.MaHocSinh.Substring(2, 8) & "' " & _
                              "UPDATE ketqua SET mahv='" & mahs_new & "', malop='" & malop_new & "' WHERE mahv='" & Me.MaHocSinh & "' AND malop='" & Me.MaHocSinh.Substring(2, 8) & "' " & _
                              "ALTER TABLE ketqua CHECK CONSTRAINT FK_ketqua_hocsinh " & _
                              "ALTER TABLE hocsinh_lop CHECK CONSTRAINT FK_hocsinh_lop_hocsinh "

        Try
            SqlQuery.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class
