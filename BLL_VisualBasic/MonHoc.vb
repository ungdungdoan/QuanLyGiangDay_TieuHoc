Imports Microsoft.VisualBasic
Imports System.Data

Public Class MonHoc

    Private ma As String
    Private ten As String

    Public Property MaMonHoc() As String
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

    Public Property TenMonHoc() As String
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

    Public Function DanhSachMonHoc() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM monhoc")

    End Function

    Public Sub Them()
        Dim dt As DataTable = DanhSachMonHoc()
        Dim dr As DataRow = dt.NewRow
        dr("mamon") = MaMonHoc
        dr("tenmon") = TenMonHoc
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "monhoc")
    End Sub

    Public Function DaTonTai() As Boolean

        Dim dt As DataTable = SqlServerAdapter.ReadData("SELECT * FROM monhoc WHERE mamon='" & Me.MaMonHoc & "'")
        Return IIf(dt.Rows.Count > 0, True, False)

    End Function

End Class
