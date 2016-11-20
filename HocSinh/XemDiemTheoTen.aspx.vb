
Partial Class XemDiemTheoTen
    Inherits System.Web.UI.Page

    Public Shared kq As New KetQua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        XuLyChung.FillSchoolYear(Me.ddlsNamHoc)
        XuLyChung.FillGrade(Me.ddlsKhoiLop)

    End Sub

    Public Sub XemDiem(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim lnkbt As LinkButton = sender
        Session("MaHocSinh") = CStr(lnkbt.CommandName)
        Response.Redirect("XemChiTietDiem.aspx")

    End Sub

    Protected Sub btnTimHocSinh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimHocSinh.Click

        Me.HienThiDanhSachHocSinh()

    End Sub

    Public Sub HienThiDanhSachHocSinh()

        Me.grvHocSinh.DataSource = kq.LayBangDiemTheoHoTen(Me.txtHo.Text.Trim, Me.txtTen.Text.Trim)
        Me.grvHocSinh.DataBind()

    End Sub

End Class
