Imports System.Data
Imports System.Xml

Partial Class GiaoVien_NhapDiem
    Inherits System.Web.UI.Page

    Private Shared hs As New HocSinh
    Private Shared lop As New LopHoc
    Private Shared dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            XuLyChung.FillSchoolYear(Me.ddlsNamHoc)
            XuLyChung.FillGrade(Me.ddlsKhoiLop)

        End If

    End Sub

    Protected Sub ddlsNamHoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsNamHoc.SelectedIndexChanged

        Me.HienThiLop()
        Me.HienThiDanhSachHocSinh()

    End Sub

    Protected Sub ddlsKhoiLop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsKhoiLop.SelectedIndexChanged

        Me.HienThiLop()
        Me.HienThiDanhSachHocSinh()

    End Sub

    Protected Sub ddlsLop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsLop.SelectedIndexChanged

        Me.HienThiDanhSachHocSinh()

    End Sub

    Public Sub NhapDiem(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim lnkbt As LinkButton = sender
        Dim hk As Integer = IIf(lnkbt.ID = "lnkbtNhapDiemHKI", 1, 2)
        Dim query As String = "SELECT mh.mamon, mh.tenmon FROM lop l, monhoc_lop mhl, monhoc mh WHERE l.malop='" & Me.ddlsLop.SelectedValue & "' AND mhl.malop=l.malop AND mh.mamon=mhl.mamon"
        Me.ThemDayDuMonHocChoLop()
        Dim dt As DataTable = SqlServerAdapter.ReadData(query)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add(New DataColumn("diem15", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("diem1tiet", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("diemhocky", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("tbmon", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("capnhat", Type.GetType("System.Boolean")))
            Me.DienDiemDaCoVaoBang(dt, hk, lnkbt.CommandName, Me.ddlsLop.SelectedValue)
            Session("DataTable") = dt
            Session("MaHocSinh") = lnkbt.CommandName
            Response.Redirect("~/GiaoVien/NhapChiTietDiem.aspx?hocky=" & hk & "&malop=" & Me.ddlsLop.SelectedValue)
        Else
            Session("DataTable") = Nothing
            Session("MaHocSinh") = Nothing
        End If

    End Sub

    Private Sub HienThiLop()

        dt = lop.TimLopTheoKhoiVaNam(Me.ddlsKhoiLop.SelectedValue, Me.ddlsNamHoc.SelectedValue)

        If dt.Rows.Count > 0 Then
            XuLyChung.Binding(Me.ddlsLop, dt, "tenlop", "malop")
        Else
            Me.ddlsLop.Items.Clear()
        End If

    End Sub

    Private Sub HienThiDanhSachHocSinh()

        Me.grvHocSinh.DataSource = hs.DanhSachHocSinh(Me.ddlsLop.SelectedValue)
        Me.grvHocSinh.DataBind()

    End Sub

    Private Sub ThemDayDuMonHocChoLop()

        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("~/App_Data/MonHoc.xml"))
        Dim root As XmlElement = doc.DocumentElement
        Dim mhl As New MonHocLop
        Dim mh As New MonHoc
        mhl.MaLop = Me.ddlsLop.SelectedValue

        For i As Int16 = 0 To root.ChildNodes.Count - 1
            Dim khoi As String = root.ChildNodes(i).Attributes("Text").Value
            If khoi = Me.ddlsKhoiLop.SelectedValue Then
                For j As Int16 = 0 To root.ChildNodes(i).ChildNodes.Count - 1
                    Dim mamon As String = root.ChildNodes(i).ChildNodes(j).Attributes("Value").Value
                    Dim tenmon As String = root.ChildNodes(i).ChildNodes(j).Attributes("Text").Value
                    mhl.MaMonHoc = mamon
                    mh.MaMonHoc = mamon
                    mh.TenMonHoc = tenmon
                    If Not mh.DaTonTai() Then
                        mh.Them()
                    End If
                    If Not mhl.DaTonTai() Then
                        mhl.Them()
                    Else
                        Continue For
                    End If
                Next
            Else
                Continue For
            End If
        Next

    End Sub

    Private Sub DienDiemDaCoVaoBang(ByVal dt As DataTable, ByVal hocky As Integer, ByVal mahs As String, ByVal malop As String)

        Dim kq As New KetQua
        kq.MaHocVien = mahs
        kq.MaLopHoc = malop
        kq.HocKy = hocky
        Dim dt2 As DataTable = kq.LayBangDiemTungHocSinh()
        If dt2.Rows.Count > 0 Then
            For Each dr As DataRow In dt2.Rows
                Dim dr2 As DataRow = dt.Select("mamon='" & dr("mamon") & "'")(0)
                dr2("diem15") = dr("diem15")
                dr2("diem1tiet") = dr("diem1tiet")
                dr2("diemhocky") = dr("diemhocky")
                dr2("tbmon") = dr("tbmon")
                dr2("capnhat") = True
            Next
        Else
            Exit Sub
        End If

    End Sub

End Class