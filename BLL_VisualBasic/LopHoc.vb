Imports Microsoft.VisualBasic
Imports System.Data

Public Class LopHoc

    Private ma As String ' mã lớp
    Private ten As String ' tên lớp
    Private khoilop As String ' khối lớp
    Private nam As Integer ' năm học

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

    Public Property TenLop() As String
        Get
            Return ten
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                ten = value.Substring(0, 50)
            Else
                ten = value
            End If
        End Set
    End Property

    Public Property Khoi() As String
        Get
            Return khoilop
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                value = "Khối " & value
                khoilop = value.Substring(0, 50)
            Else
                khoilop = value
            End If
        End Set
    End Property

    Public Property NamHoc() As Integer
        Get
            Return nam
        End Get

        Set(ByVal value As Integer)
            If value > 1990 Then
                nam = value
            End If
        End Set
    End Property

    Public Sub Them()

        Dim dt As DataTable = Me.DanhSachLop
        Dim dr As DataRow = dt.NewRow

        dr("malop") = Me.MaLop
        dr("tenlop") = Me.TenLop
        dr("khoi") = Me.Khoi
        dr("namhoc") = Me.NamHoc
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "lop")

    End Sub

    Public Function DanhSachLop() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM lop")

    End Function

    Public Shared Function TimMaLop(ByVal nam As Integer, ByVal khoilop As Integer) As String

        Dim ml As String = CStr(khoilop) & CStr(nam).Substring(2, 2)
        Dim lop_da_co As Boolean = LopDaTonTai(nam, khoilop)
        Dim ret As String = Nothing

        Dim dt As DataTable = SqlServerAdapter.ReadData("SELECT * FROM lop WHERE SUBSTRING(malop,3,4)='" & ml & "'")

        ' Nếu đã tồn tại lớp có năm và khối lớp truyền vô
        If lop_da_co Then
            ' Duyệt từng lớp xem lớp nào chưa đủ 50 học sinh thì chọn lớp đó
            For Each dr As DataRow In dt.Rows
                If SiSo(dr("malop")) < 50 Then
                    ret = CStr(dr("malop"))
                    Exit For
                Else ' Nếu không thì duyệt tiếp
                    ret = Nothing
                    Continue For
                End If
            Next
        End If

        Return ret

    End Function

    Public Overloads Shared Function LopDaTonTai(ByVal nam As Integer, ByVal khoilop As Integer) As Boolean

        Dim ml As String = "LH" & CStr(khoilop) & CStr(nam).Substring(2)
        Dim query As String = "SELECT * FROM lop WHERE SUBSTRING(malop,1,6)='" & ml & "'"

        Return IIf(SqlServerAdapter.ReadData(query).Rows.Count > 0, True, False)

    End Function

    Public Overloads Shared Function LopDaTonTai(ByVal ml As String) As Boolean

        Dim query As String = "SELECT COUNT(*) FROM lop WHERE malop='" & ml & "'"
        Dim count As Integer = CInt(SqlQuery.ExecuteScalar(query, CommandType.Text))

        Return IIf(count > 0, True, False)

    End Function

    ' Tìm số lượng học sinh trong một lớp nào đó
    Public Shared Function SiSo(ByVal ml As String) As Integer

        Dim query As String = "SELECT COUNT(*) FROM hocsinh WHERE SUBSTRING(mahs,3,8)='" & ml & "'"

        Return CInt(SqlQuery.ExecuteScalar(query, CommandType.Text))

    End Function

    Public Shared Function TaoMaLopMoi(ByVal grade As Integer, ByVal year As Integer) As String

        Dim ml As String = CStr(grade) & CStr(year).Substring(2, 2)
        Dim sttmax As String = ""

        If LopDaTonTai(year, grade) Then
            Dim query As String = "SELECT MAX(RIGHT(malop,2))+1 FROM lop WHERE SUBSTRING(malop,3,4)='" & ml & "'"
            sttmax = CStr(SqlQuery.ExecuteScalar(query, CommandType.Text))
            If (sttmax.Length = 1) Then
                sttmax = "0" & sttmax
            End If
        Else
            sttmax = "01"
        End If

        ml = "LH" & ml & sttmax

        Return ml

    End Function

    Public Overloads Function TimLopTheoKhoiVaNam(ByVal _khoi As Integer, ByVal _namhoc As Integer) As DataTable

        Dim query As String = "SELECT * FROM lop WHERE SUBSTRING(malop,3,2)='" & CStr(_khoi) & "' AND SUBSTRING(malop,5,2)='" & CStr(_namhoc).Substring(2, 2) & "'"
        Return SqlServerAdapter.ReadData(query)

    End Function

    Public Overloads Function TimLopTheoKhoiVaNam(ByVal _khoi As Integer, ByVal _namhoc As Integer, ByVal malopold As String) As DataTable

        Dim query As String = "SELECT * FROM lop WHERE SUBSTRING(malop,3,2)='" & CStr(_khoi) & "' AND SUBSTRING(malop,5,2)='" & CStr(_namhoc).Substring(2, 2) & "' AND malop!='" & malopold & "'"
        Return SqlServerAdapter.ReadData(query)

    End Function

    Public Function TimTenLopTheoMa() As String

        Return CStr(SqlQuery.ExecuteScalar("SELECT tenlop FROM lop WHERE malop='" & Me.MaLop & "'"))

    End Function

End Class
