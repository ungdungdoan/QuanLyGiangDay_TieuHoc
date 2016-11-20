
Partial Class TrangChu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Role") Is Nothing Then
                Session("Role") = "guest"
            End If
        End If
    End Sub
End Class
