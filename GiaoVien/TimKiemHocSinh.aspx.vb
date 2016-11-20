
Partial Class GiaoVien_TimKiemHocSinh
    Inherits System.Web.UI.Page

    Dim query As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            XuLyChung.FillSchoolYear(Me.ddlsNamHoc)
            XuLyChung.FillGrade(Me.ddlsKhoiLop)

        End If

    End Sub

    Private Sub TaoCauTruyVan()

        query = "SELECT hs.mahs, hohs, tenhs, tenlop FROM hocsinh hs, lop l, hocsinh_lop hsl WHERE hs.mahs=hsl.mahs AND hsl.malop=l.malop AND SUBSTRING(hs.mahs,5,2)='" & CStr(Me.ddlsKhoiLop.SelectedValue) & "' AND SUBSTRING(hs.mahs,7,2)='" & Me.ddlsNamHoc.SelectedValue.Substring(2, 2) & "'"

        If Me.txtHo.Text <> "" Then
            query = query & " AND hohs='" & Me.txtHo.Text.Trim & "'"
        End If

        If Me.txtTen.Text <> "" Then
            query = query & " AND tenhs='" & Me.txtTen.Text.Trim & "'"
        End If

    End Sub

    Public Sub XemChiTietHocSinh(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lnkbt As LinkButton = sender
        Response.Redirect("~/GiaoVien/XemChiTietHocSinh.aspx?mahocsinh=" & CStr(lnkbt.CommandName))
    End Sub

    Protected Sub btnTimHocSinh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimHocSinh.Click

        Me.HienThiThongTin()

    End Sub

    Private Sub ThongBao(ByVal msg As String)
        Response.Write("<script language=javascript>alert('" & msg & "')</script>")
    End Sub

    Private Sub HienThiThongTin()

        Me.TaoCauTruyVan()
        Me.grvHocSinh.DataSource = SqlServerAdapter.ReadData(query)
        Me.grvHocSinh.DataBind()

    End Sub

End Class
