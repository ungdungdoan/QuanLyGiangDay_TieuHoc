Imports System.Data

Partial Class NhapChiTietDiem
    Inherits System.Web.UI.Page

    Dim hs As New HocSinh
    Dim lop As New LopHoc


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Not Session("DataTable") Is Nothing Then
                Me.grvDiem.DataSource = Session("DataTable")
                Me.grvDiem.DataBind()
                hs.MaHocSinh = Session("MaHocSinh")
                Me.lblTenHocSinh.Text = hs.TimHoTenTheoMa()
                lop.MaLop = Request.QueryString("malop")
                Me.lblTenLop.Text = lop.TimTenLopTheoMa()
            End If
        End If
    End Sub
   
    Protected Sub btnLuu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLuu.Click

        Dim kq As New KetQua
        Dim diem15 As String
        Dim diem1tiet As String
        Dim diemhocky As String
        Dim tbmon As String

        kq.MaHocVien = Session("MaHocSinh")
        kq.MaLopHoc = Request.QueryString("malop")
        kq.HocKy = Request.QueryString("hocky")

        For Each row As GridViewRow In Me.grvDiem.Rows
            kq.MaMonHoc = DirectCast(row.FindControl("lblMaMon"), Label).Text

            diem15 = DirectCast(row.FindControl("txtDiem15"), TextBox).Text
            kq.DiemMuoiLam = Double.Parse(IIf(diem15 = "", 0, diem15))

            diem1tiet = DirectCast(row.FindControl("txtDiem1Tiet"), TextBox).Text
            kq.DiemMotTiet = Double.Parse(IIf(diem1tiet = "", 0, diem1tiet))

            diemhocky = DirectCast(row.FindControl("txtDiemHocKy"), TextBox).Text
            kq.DiemThiHocKy = Double.Parse(IIf(diemhocky = "", 0, diemhocky))

            tbmon = DirectCast(row.FindControl("txtTrungBinhMon"), TextBox).Text
            kq.TrungBinhMon = Double.Parse(IIf(tbmon = "", 0, tbmon))

            If Boolean.Parse(DirectCast(row.FindControl("chkCapNhat"), CheckBox).Checked) Then
                kq.CapNhat()
            Else
                kq.Them()
            End If
        Next

    End Sub

End Class

