<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ThemHocSinh.aspx.vb" Inherits="ThemHocSinh" title="Them hoc sinh moi" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <ajax:AjaxPanel ID="panel1" runat="server">
        
            <table style="width: 612px; height: 439px" id="TABLE1">
                <tr>
                    <td align="center" colspan="1" style="width: 161px"></td>
                    
                    <td align="center" colspan="3">
                        <asp:Label ID="lblTittle" runat="server" BackColor="Honeydew" Font-Size="X-Large" Height="26px" Text="Thêm học sinh mới" Width="289px"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td align="left" colspan="1" style="width: 161px"></td>
                    <td align="left" colspan="2"></td>
                    <td align="left" colspan="1"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td align="left" style="width: 417px">
                        <asp:Label ID="lblNamHoc" runat="server" Text="Năm học:"></asp:Label>
                    </td>
                    
                    <td align="left" style="width: 831px">
                        <asp:DropDownList ID="ddlsNamHoc" runat="server" Width="116px"></asp:DropDownList>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td align="left" style="width: 417px">
                        <asp:Label ID="lblKhoiLop" runat="server" Text="Khối lớp:"></asp:Label>
                    </td>
                    
                    <td align="left" style="width: 831px">
                        <asp:DropDownList ID="ddlsKhoiLop" runat="server" Width="116px"></asp:DropDownList>
                    </td>
                         
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td style="width: 417px" align="left">
                        <asp:Label ID="Label1" runat="server" Text="Mã học sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px" align="left">
                        <asp:TextBox ID="txtMaHocSinh" runat="server"></asp:TextBox>&nbsp;
                        <asp:Label ID="lblKiemTraMa" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td style="width: 417px" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Họ học sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px" align="left">
                        <asp:TextBox ID="txtHoHocSinh" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="HoHocSinhRequiredValidator" runat="server" ControlToValidate="txtHoHocSinh" ErrorMessage="Chưa nhập họ học sinh!"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td style="width: 417px" align="left">
                        <asp:Label ID="lblTenHocSinh" runat="server" Text="Tên học sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px" align="left">
                        <asp:TextBox ID="txtTenHocSinh" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TenHocSinhRequiredValidator" runat="server" ControlToValidate="txtTenHocSinh" ErrorMessage="Chưa nhập tên học sinh!"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px"></td>
                    
                    <td style="width: 417px" align="left">
                        <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh:"></asp:Label>
                    </td>
                    
                    <td align="left" colspan="2">
                        <asp:DropDownList ID="ddlsNgay" runat="server"> </asp:DropDownList>
                        <asp:DropDownList ID="ddlsThang" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlsNam" runat="server"></asp:DropDownList>&nbsp;
                        <asp:Label ID="lblKiemTraNgay" runat="server" ForeColor="Red" Text="Ngày không hợp lệ" Visible="False"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px; height: 20px"></td>
                    
                    <td style="width: 417px; height: 20px" align="left">
                        <asp:Label ID="lblPhai" runat="server" Text="Giới tính:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px; height: 20px" align="left">
                        <asp:RadioButtonList ID="rblPhai" runat="server" Width="152px" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 20px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px; height: 18px"></td>
                    
                    <td style="width: 417px; height: 18px" align="left">
                        <asp:Label ID="Label6" runat="server" Text="Địa chỉ:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px; height: 18px" align="left">
                        <asp:TextBox ID="txtDiaChi" runat="server" Height="59px" TextMode="MultiLine" Width="235px"></asp:TextBox>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px; height: 18px"></td>
                    
                    <td style="width: 417px; height: 18px" align="left">
                        <asp:Label ID="lblDienThoai" runat="server" Text="Số điện thoại:"></asp:Label>
                    </td>
                    
                    <td style="width: 831px; height: 18px" align="left">
                        <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="DienThoaiValidator" runat="server" ErrorMessage="Điện thoại không hợp lệ" ValidationExpression="^\d{7,20}$" ControlToValidate="txtDienThoai"></asp:RegularExpressionValidator>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px; height: 18px"></td>
                    
                    <td style="width: 417px; height: 18px" align="left"></td>
                    
                    <td style="width: 831px; height: 18px" align="left">
                        <asp:CheckBox ID="chkAutoID" runat="server" Text="Sử dụng mã tự động" AutoPostBack="True" />
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 161px; height: 18px"></td>
                    
                    <td style="width: 417px; height: 18px" align="left"></td>
                    
                    <td style="width: 831px; height: 18px" align="left">
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" Width="59px" />&nbsp;&nbsp;
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>                
            </table>
        </ajax:AjaxPanel>
    </div>    
</asp:Content>