Imports Microsoft.VisualBasic
Imports System.Data

Public Class Quyen

    Private mq As Guid
    Private tq As String

    Public Property MaQuyen() As Guid
        Get
            Return mq
        End Get

        Set(ByVal value As Guid)
            mq = value
        End Set
    End Property

    Public Property TenQuyen() As String
        Get
            Return tq
        End Get

        Set(ByVal value As String)
            If Not value Is Nothing Then
                tq = value
            Else
                tq = ""
            End If

        End Set
    End Property

    Public Function DanhSachQuyen() As DataTable

        Return SqlServerAdapter.ReadData("SELECT * FROM quyen")

    End Function

    Public Overloads Function TimQuyen(ByVal _maquyen As Guid) As Quyen

        Dim q As New Quyen
        Dim dt As DataTable = Me.DanhSachQuyen()
        Dim drs As DataRow() = dt.Select("maquyen='" & _maquyen.ToString & "'")
        If drs.Length > 0 Then
            q.MaQuyen = New Guid(drs(0)("maquyen").ToString)
            q.TenQuyen = CStr(drs(0)("tenquyen"))
        Else
            q = Nothing
        End If

        Return q

    End Function

    Public Overloads Function TimQuyen(ByVal _tenquyen As String) As Quyen

        Dim q As New Quyen
        Dim dt As DataTable = Me.DanhSachQuyen()
        Dim drs As DataRow() = dt.Select("tenquyen='" & _tenquyen.ToString & "'")
        If drs.Length > 0 Then
            q.MaQuyen = New Guid(drs(0)("maquyen").ToString)
            q.TenQuyen = drs(0)("tenquyen")
        Else
            q = Nothing
        End If

        Return q

    End Function

End Class
