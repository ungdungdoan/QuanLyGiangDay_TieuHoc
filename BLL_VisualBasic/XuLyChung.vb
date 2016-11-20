Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web.UI.Page

Public Class XuLyChung

    ' Điền các giá trị ngày, tháng, năm vào các DropDownList
    Public Shared Sub FillDate(ByVal ngay As DropDownList, ByVal thang As DropDownList, ByVal nam As DropDownList)

        ' Ngày
        For i As Int16 = 1 To 31
            ngay.Items.Add(New ListItem(i, i)) 'ListItem(text,value)
        Next

        'Tháng
        For i As Int16 = 1 To 12
            thang.Items.Add(New ListItem(i, i)) 'ListItem(text,value)
        Next

        'Năm
        For i As Int16 = 1980 To DateTime.Now.Year
            nam.Items.Add(New ListItem(i, i))
        Next

        'Giá trị mặc định
        ngay.SelectedValue = DateTime.Now.Day
        thang.SelectedValue = DateTime.Now.Month
        nam.SelectedValue = DateTime.Now.Year

    End Sub

    ' Đièn năm học , ví dụ như: 1997-1998, 1998-1999
    Public Shared Sub FillSchoolYear(ByVal nam As DropDownList)

        'Điền năm học
        For i As Int16 = 1989 To DateTime.Now.Year
            nam.Items.Add(New ListItem(CStr(i) + "-" + CStr(i + 1), i + 1))
        Next

        nam.SelectedValue = DateTime.Now.Year
    End Sub

    Public Shared Sub FillGrade(ByVal khoilop As DropDownList)

        ' Điền khối lớp
        For i As Integer = 10 To 12
            khoilop.Items.Add(New ListItem("Khối " + CStr(i), i))
        Next

    End Sub

    Public Overloads Shared Sub Binding(ByVal control As DropDownList, ByVal tableName As String, ByVal text As String, ByVal value As String)

        Binding(control, SqlServerAdapter.ReadData("SELECT * FROM " & tableName), text, value)

    End Sub

    Public Overloads Shared Sub Binding(ByVal control As DropDownList, ByVal table As DataTable, ByVal text As String, ByVal value As String)

        control.DataSource = table
        control.DataTextField = text
        control.DataValueField = value
        control.DataBind()
        control.SelectedIndex = 0

    End Sub

    Public Overloads Shared Sub Binding(ByVal control As RadioButtonList, ByVal text As String(), ByVal value As Object())

        For i As Int16 = 0 To text.Length - 1
            Dim li As New ListItem(text(i), value(i))
            control.Items.Add(li)
        Next

        control.Items(0).Selected = True

    End Sub

End Class
