Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions

' Kiểm tra định dạng của Mã học sinh và Mã lớp học có đúng không
Public Class KiemTraDinhDang

    Private Shared reg As Regex
    Private Shared MAHOCSINH_PATTERN As String = "^[H][S][L][H]\d{8}$"
    Private Shared MALOPHOC_PATTERN As String = "^[L][H]\d{6}$"

    Public Shared Function LaMaHocSinhHopLe(ByVal id As String) As Boolean

        reg = New Regex(MAHOCSINH_PATTERN)
        Return reg.IsMatch(id)

    End Function

    Public Shared Function LaMaLopHopLe(ByVal id As String) As Boolean

        reg = New Regex(MALOPHOC_PATTERN)
        Return reg.IsMatch(id)

    End Function

End Class
