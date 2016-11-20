Imports Microsoft.VisualBasic
Imports System.Data

Public Class ThanhVien

    Private matv As Guid 'mã thành viên
    Private hotv As String ' họ thành viên
    Private tentv As String ' tên thành viên
    Private ns As DateTime ' ngày sinh
    Private dc As String ' địa chỉ
    Private dt As String ' điện thoại
    Private em As String ' email
    Private username As String ' tên người dùng
    Private password As String ' mật khẩu
    Private q As String ' quyền

    Public Property MaThanhVien() As Guid
        Get
            Return matv
        End Get

        Set(ByVal value As Guid)
            matv = value
        End Set
    End Property

    Public Property Ho() As String
        Get
            Return hotv
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                hotv = value.Substring(0, 50)
            Else
                hotv = ""
            End If
        End Set
    End Property

    Public Property Ten() As String
        Get
            Return tentv
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                tentv = value.Substring(0, 50)
            Else
                tentv = ""
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

    Public Property DiaChi() As String
        Get
            Return dc
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 250 Then
                dc = value.Substring(0, 250)
            Else
                dc = ""
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
                dt = ""
            End If
        End Set
    End Property

    Public Property Email() As String
        Get
            Return em
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 250 Then
                em = value.Substring(0, 250)
            Else
                em = ""
            End If
        End Set
    End Property

    Public Property TenNguoiDung() As String
        Get
            Return username
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                username = value.Substring(0, 50)
            Else
                username = ""
            End If
        End Set
    End Property

    Public Property MatKhau() As String
        Get
            Return password
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                password = value.Substring(0, 50)
            Else
                password = ""
            End If
        End Set
    End Property

    Public Property Quyen() As String
        Get
            Return q
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing Then
                q = value
            Else
                q = ""
            End If
        End Set
    End Property

    Public Function DanhSachThanhVien() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM thanhvien")

    End Function

    Public Function TimThanhVien(ByVal _ten As String, ByVal _matkhau As String) As ThanhVien

        Dim tv As New ThanhVien
        Dim dt As DataTable = Me.DanhSachThanhVien()
        Dim drs As DataRow() = dt.Select("tennguoidung='" & _ten.Trim & "' AND matkhau='" & _matkhau & "'")

        If drs.Length > 0 Then
            tv.MaThanhVien = New Guid(drs(0)("matv").ToString)
            tv.Ho = drs(0)("hotv")
            tv.Ten = drs(0)("hotv")
            tv.ns = drs(0)("ngaysinh")
            tv.DiaChi = drs(0)("diachi")
            tv.DienThoai = drs(0)("dienthoai")
            tv.Email = drs(0)("email")
            tv.TenNguoiDung = drs(0)("tennguoidung")
            tv.MatKhau = drs(0)("MatKhau")
            Dim q As New Quyen
            tv.Quyen = q.TimQuyen(drs(0)("quyen").ToString).TenQuyen
        Else
            tv = Nothing
        End If

        Return tv

    End Function

    Public Sub Them()

        Dim dt As DataTable = Me.DanhSachThanhVien
        Dim dr As DataRow = dt.NewRow
        dr("hotv") = Me.Ho
        dr("tentv") = Me.Ten
        dr("ngaysinh") = Me.NgaySinh
        dr("diachi") = Me.DiaChi
        dr("dienthooai") = Me.DienThoai
        dr("email") = Me.Email
        dr("tennguoidung") = Me.TenNguoiDung
        dr("matkhau") = Me.MatKhau
        Dim q As New Quyen
        dr("quyen") = q.TimQuyen("guest").MaQuyen
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "thanhvien")

    End Sub

    Public Sub CapNhat()

        Dim dt As DataTable = Me.DanhSachThanhVien
        Dim drs As DataRow() = dt.Select("matv='" & Me.MaThanhVien.ToString & "'")

        If drs.Length > 0 Then
            drs(0)("hotv") = Me.Ho
            drs(0)("tentv") = Me.Ten
            drs(0)("ngaysinh") = Me.NgaySinh
            drs(0)("diachi") = Me.DiaChi
            drs(0)("dienthoai") = Me.DienThoai
            drs(0)("email") = Me.Email
            drs(0)("tennguoidung") = Me.TenNguoiDung
            drs(0)("matkhau") = Me.MatKhau
            SqlServerAdapter.WriteData(dt, "thanhvien")
        End If

    End Sub

    Public Function DaTonTaiTenNguoiDung(ByVal _name As String) As Boolean

        Return IIf(SqlServerAdapter.ReadData("SELECT * FROM thanhvien WHERE tennguoidung='" & _name.Trim & "'").Rows.Count > 0, True, False)

    End Function

End Class
