
Partial Class Public_DangKy
    Inherits System.Web.UI.Page

    Dim q As New Quyen
    Dim tv As New ThanhVien
    Dim hs As New HocSinh

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            XuLyChung.Binding(Me.rblLaHocSinh, New String() {"Có", "Không"}, New Object() {1, 0})
            XuLyChung.FillDate(Me.ddlsNgay, Me.ddlsThang, Me.ddlsNam)
            Me.rblLaHocSinh.SelectedIndex = 1

        End If

    End Sub

    Protected Sub btnDangKy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDangKy.Click

        tv.Ho = Me.txtHo.Text
        tv.Ten = Me.txtTen.Text
        Dim ngaysinh As String = Me.ddlsNgay.SelectedValue & "/" & Me.ddlsThang.SelectedValue & "/" & Me.ddlsNam.SelectedValue
        If IsDate(ngaysinh) Then ' Kiểm tra ngày nhập vào
            tv.NgaySinh = DateTime.Parse(ngaysinh)
            Me.lblKiemTraNgaySinh.Visible = True

        Else
            Me.lblKiemTraNgaySinh.Visible = False

            Me.lblKiemTraNgaySinh.Text = "Ngày sinh không hợp lệ!"
            Exit Sub
        End If
        tv.DiaChi = IIf(Me.txtDiaChi.Text = "", "Không biết", Me.txtDiaChi.Text)
        tv.DienThoai = IIf(Me.txtDienThoai.Text = "", "Không biết", Me.txtDienThoai.Text)
        tv.Email = Me.txtEmail.Text

        If tv.DaTonTaiTenNguoiDung(Me.txtTenNguoiDung.Text) Then
            Me.lblKiemTraTen.Visible = True
        Else
            Me.lblKiemTraTen.Visible = False
            tv.TenNguoiDung = Me.txtTenNguoiDung.Text
        End If

        tv.MatKhau = Me.txtMatKhau.Text

        If (Me.txtMaHocSinh.Visible = True) Then
            hs.MaHocSinh = IIf(Me.txtMaHocSinh.Text = "", "abc", Me.txtMaHocSinh.Text)
            If Me.txtMaHocSinh.Text = "" Then
                Me.lblKiemTraMaHocSinh.Text = "Bạn chưa nhập mã học sinh!"
                Exit Sub
            ElseIf Not hs.DaTonTaiHocSinh() Then
                Me.lblKiemTraMaHocSinh.Text = "Không tìm thấy mã học sinh!!!"
                Exit Sub
            Else
                tv.Quyen = "student"
            End If
        Else
            tv.Quyen = "guest"
        End If

        tv.Them()

    End Sub

    Protected Sub rblLaHocSinh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblLaHocSinh.SelectedIndexChanged
        If Me.rblLaHocSinh.SelectedIndex = 0 Then
            Me.lblMaHocSinh.Visible = True
            Me.txtMaHocSinh.Visible = True
            Me.lblKiemTraMaHocSinh.Visible = True
        Else
            Me.lblMaHocSinh.Visible = False
            Me.txtMaHocSinh.Visible = False
            Me.lblKiemTraMaHocSinh.Visible = False
        End If
    End Sub
    
End Class
