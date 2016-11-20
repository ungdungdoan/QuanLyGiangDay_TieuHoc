Imports System.Data
Imports System.Xml

Partial Class SiteMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            TaoMenu()
            If Not Request.Cookies("TenUser") Is Nothing Then
                If Request.Cookies("TenUser").Value <> "" Then
                    Me.txtTenNguoiDung.Text = Request.Cookies("TenUser").Value

                    If Not Request.Cookies("MatKhauUser") Is Nothing Then
                        If Request.Cookies("MatKhauUser").Value <> "" Then
                            Session("Password") = Request.Cookies("MatKhauUser").Value
                            Me.lblLogin.Text = "Sign out"
                            Me.chkNhoMatKhau.Checked = True
                            Me.DangNhap(Request.Cookies("TenUser").Value, Request.Cookies("MatKhauUser").Value)
                        End If
                    End If
                End If
            End If

        End If

    End Sub

    Public Sub TaoMenu()

        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("~/App_Data/Menu.xml"))
        Dim goc As XmlElement = doc.DocumentElement

        For i As Int16 = 0 To goc.ChildNodes.Count - 1
            Dim url As String = goc.ChildNodes(i).Attributes("NavigateUrl").Value
            Dim text As String = goc.ChildNodes(i).Attributes("Text").Value
            Dim mi As New MenuItem(text, "", "", url)
            mnuSite.Items.Add(mi)
            For j As Int16 = 0 To goc.ChildNodes(i).ChildNodes.Count - 1
                Dim suburl As String = goc.ChildNodes(i).ChildNodes(j).Attributes("NavigateUrl").Value
                Dim subtext As String = goc.ChildNodes(i).ChildNodes(j).Attributes("Text").Value
                Dim smi As New MenuItem(subtext, "", "", suburl)
                mi.ChildItems.Add(smi)
            Next
        Next

    End Sub

    Private Sub ThongBao(ByVal msg As String)
        Response.Write("<script language=javascript>alert('" & msg & "')</script>")
    End Sub

    Private Function IsValidUser(ByVal name As String, ByVal pwd As String) As Boolean

        Dim dt As New DataTable
        Dim tv As New ThanhVien
        Dim kq As New Boolean

        dt = tv.DanhSachThanhVien()
        Dim drs As DataRow() = dt.Select("tennguoidung='" & name & "' AND matkhau='" & pwd & "'")

        If drs.Length > 0 Then
            Dim q As New Quyen
            Session("User") = name
            Session("Role") = q.TimQuyen(New Guid(drs(0)("quyen").ToString)).TenQuyen
            kq = True
        Else
            Session("User") = "guest"
            Session("Role") = "guest"
            kq = False
        End If

        Return kq

    End Function

    Protected Sub btnDangNhap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDangNhap.Click

        DangNhap(Me.txtTenNguoiDung.Text, Me.txtMatKhau.Text)

    End Sub

    Protected Sub lblLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogin.Click

        If Me.lblLogin.Text = "Sign in" Then
            DangNhap(Me.txtTenNguoiDung.Text, Me.txtMatKhau.Text)
        Else
            DangXuat()
        End If

    End Sub

    Private Sub DangNhap(ByVal _name As String, ByVal pwd As String)

        Try

            Me.XoaNoiDungCookie()

            If Me.chkNhoMatKhau.Checked Then
                Response.Cookies("TenUser").Value = _name
                Response.Cookies("TenUSer").Expires = DateTime.Now.AddDays(7)
                Response.Cookies("MatKhauUser").Value = pwd
                Response.Cookies("MatKhauUSer").Expires = DateTime.Now.AddDays(1)
            End If

            If Me.IsValidUser(_name, pwd) = False Then
                Me.ThongBao("Tên người dùng hoặc mật khẩu không đúng!!!")
            Else
                Me.lblLogin.Text = "Sign out"
                FormsAuthentication.SetAuthCookie(CStr(Session("Role")), True)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DangXuat()

        lblLogin.Text = "Sign in"
        Me.XoaNoiDungCookie()
        Me.txtTenNguoiDung.Text = "Tài khoản"
        FormsAuthentication.SetAuthCookie("guest", True)
        FormsAuthentication.SignOut()
        Response.Redirect("~/Public/TrangChu.aspx")

    End Sub

    Private Sub XoaNoiDungCookie()

        If Not Response.Cookies("TenUser") Is Nothing Then
            Response.Cookies("TenUser").Value = ""
            Response.Cookies("TenUSer").Expires = DateTime.Now
        End If

        If Not Response.Cookies("MatKhauUser") Is Nothing Then
            Response.Cookies("MatKhauUser").Value = ""
            Response.Cookies("MatKhauUSer").Expires = DateTime.Now
        End If

    End Sub

End Class

