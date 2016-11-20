Imports Microsoft.VisualBasic
Imports System.Data

Public Class MonHocLop

    Private mamon As String
    Private malophoc As String

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

    Public Property MaLop() As String
        Get
            Return malophoc
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing And value.Length > 50 Then
                malophoc = value.Substring(0, 50)
            Else
                malophoc = value
            End If
        End Set
    End Property

    Public Function DanhSachMonHocLop() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM monhoc_lop")

    End Function

    Public Function DaTonTai() As Boolean

        Dim dt As DataTable = SqlServerAdapter.ReadData("SELECT * FROM monhoc_lop WHERE mamon='" & MaMonHoc & "' AND malop='" & MaLop & "'")
        Return IIf(dt.Rows.Count > 0, True, False)

    End Function

    Public Sub Them()

        Dim dt As DataTable = DanhSachMonHocLop()
        Dim dr As DataRow = dt.NewRow
        dr("mamon") = MaMonHoc
        dr("malop") = MaLop
        dt.Rows.Add(dr)
        SqlServerAdapter.WriteData(dt, "monhoc_lop")

    End Sub

End Class
