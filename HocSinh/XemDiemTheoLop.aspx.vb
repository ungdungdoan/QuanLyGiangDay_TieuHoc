Imports System.Data

Partial Class XemDiemTheoLop
    Inherits System.Web.UI.Page

    Private Shared lop As New LopHoc
    Private Shared kq As New KetQua
    Private Shared dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            XuLyChung.FillSchoolYear(Me.ddlsNamHoc)
            XuLyChung.FillGrade(Me.ddlsKhoiLop)
            Me.HienThiLop()
            XuLyChung.Binding(Me.ddlsMonHoc, SqlServerAdapter.ReadData("SELECT * FROM monhoc"), "tenmon", "mamon")

        End If

    End Sub


    Protected Sub ddlsKhoiLop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsKhoiLop.SelectedIndexChanged

        Me.HienThiLop()

    End Sub


    Protected Sub ddlsNamHoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsNamHoc.SelectedIndexChanged

        Me.HienThiLop()

    End Sub

    Private Sub HienThiLop()

        dt = lop.TimLopTheoKhoiVaNam(Me.ddlsKhoiLop.SelectedValue, Me.ddlsNamHoc.SelectedValue)

        If dt.Rows.Count > 0 Then
            XuLyChung.Binding(Me.ddlsLop, dt, "tenlop", "malop")
        Else
            Me.ddlsLop.Items.Clear()
        End If

    End Sub

    Private Sub HienThiMonHoc()

    End Sub

    Private Sub HienThiBangDiem()

        kq.MaLopHoc = Me.ddlsLop.SelectedValue
        kq.MaMonHoc = Me.ddlsMonHoc.SelectedValue
        dt = kq.LayBangDiemTheoLop()
        Me.grvBangDiem.DataSource = dt
        Me.grvBangDiem.DataBind()

    End Sub

    Protected Sub btnXemDiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXemDiem.Click

        Me.HienThiBangDiem()

    End Sub
   
    
End Class
