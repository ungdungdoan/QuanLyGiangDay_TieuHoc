
Partial Class GiaoVien_XemChiTietHocSinh
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Not Request.QueryString("mahocsinh") Is Nothing Then
                'Response.Write(Request.QueryString("mahocsinh"))
                Dim id As String = Request.QueryString("mahocsinh")
                Dim hs As New HocSinh
                hs.MaHocSinh = id
                Me.grvHocSinh.DataSource = hs.TimTheoMaHocSinh()
                Me.grvHocSinh.DataBind()
            End If
           
        End If

    End Sub

End Class
