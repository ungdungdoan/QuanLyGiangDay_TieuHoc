<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DangKy.aspx.vb" Inherits="Public_DangKy" title="Dang ky thanh vien moi" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:AjaxPanel ID="panel1" runat="server">
        <br />
        <table id="TABLE1" style="width: 797px; height: 497px;">
            <tr>
                <td style="width: 268px"></td>
                <td style="width: 11px">
                </td>
                <td style="width: 940px" align="left">
                    <asp:Label ID="lblKiemTraTen" runat="server" ForeColor="Red" Visible="False" Width="345px">Tên người dùng này đã có, vui lòng chọn tên khác!</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 268px">
                </td>
                <td style="width: 11px">
                </td>
                <td align="left" style="width: 940px">
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 13px" align="right">Họ:</td>
                <td align="right" style="width: 11px; height: 13px">
                </td>
                
                <td style="width: 940px; height: 13px" align="left">
                    <asp:TextBox ID="txtHo" runat="server" Width="173px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="HoValidator" runat="server" ControlToValidate="txtHo" ErrorMessage="Chưa nhập họ!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 26px;" align="right">Tên:</td>
                <td align="right" style="width: 11px; height: 26px">
                </td>
                
                <td style="width: 940px; height: 26px;" align="left">
                    <asp:TextBox ID="txtTen" runat="server" Width="174px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TenValidator" runat="server" ControlToValidate="txtTen" ErrorMessage="Chưa nhập tên!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 268px; height: 26px">Ngày sinh:</td>
                <td align="right" style="width: 11px; height: 26px">
                </td>
                
                <td align="left" style="width: 940px; height: 26px">
                    <asp:DropDownList ID="ddlsNgay" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="ddlsThang" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="ddlsNam" runat="server" Width="86px"></asp:DropDownList>
                    <asp:Label ID="lblKiemTraNgaySinh" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px" align="right">Địa chỉ:</td>
                <td align="right" style="width: 11px">
                </td>
                
                <td style="width: 940px" align="left">
                    <asp:TextBox ID="txtDiaChi" runat="server" Height="48px" TextMode="MultiLine">aaa</asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px" align="right">Điện thoại:</td>
                <td align="right" style="width: 11px">
                </td>
                
                <td style="width: 940px" align="left">
                    <asp:TextBox ID="txtDienThoai" runat="server" Width="171px">1234567</asp:TextBox>
                    <asp:RegularExpressionValidator ID="DienThoaiValidator" runat="server" ErrorMessage="Điện thoại không hợp lệ" ControlToValidate="txtDienThoai" ValidationExpression="^\d{7,20}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px" align="right">Email:</td>
                <td align="right" style="width: 11px">
                </td>
                
                <td style="width: 940px" align="left">
                    <br />
                    <asp:TextBox ID="txtEmail" runat="server" Width="171px">mtuananh@gmail.com</asp:TextBox>
                    <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email không hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ControlToValidate="txtEmail" ErrorMessage="Chưa nhập Email!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 26px;" align="right">Tên người dùng:</td>
                <td align="right" style="width: 11px; height: 26px">
                </td>
                
                <td style="width: 940px; height: 26px;" align="left">
                    <asp:TextBox ID="txtTenNguoiDung" runat="server" Width="171px">guest</asp:TextBox>
                    <asp:RequiredFieldValidator ID="TenNguoiDungValidator" runat="server" ControlToValidate="txtTenNguoiDung" ErrorMessage="Chưa nhập tên người dùng" Width="178px"></asp:RequiredFieldValidator>&nbsp;
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 24px" align="right">Mật khẩu:</td>
                <td align="right" style="width: 11px; height: 24px">
                </td>
                
                <td style="width: 940px; height: 24px" align="left">
                    <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" Width="172px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="MatKhauValidator" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="Chưa nhập mật khẩu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px" align="right">Nhắc lại mật khẩu:</td>
                <td align="right" style="width: 11px">
                </td>
                
                <td style="width: 940px" align="left">
                    <asp:TextBox ID="txtNhacMatKhau" runat="server" TextMode="Password" Width="172px"></asp:TextBox>
                    <asp:CompareValidator ID="MatKhauCompareValidator" runat="server" ControlToCompare="txtMatKhau" ControlToValidate="txtNhacMatKhau" ErrorMessage="Mật khẩu không khớp!"></asp:CompareValidator>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 20px;" align="right">
                    Là học sinh trường này ?</td>
                <td align="right" style="width: 11px; height: 20px">
                </td>
                
                <td style="width: 940px; height: 20px;" align="left">
                    <asp:RadioButtonList ID="rblLaHocSinh" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="169px"></asp:RadioButtonList>
                </td>
            </tr>
            
            <tr>
                <td style="width: 268px; height: 22px;" align="right">
                    <asp:Label ID="lblMaHocSinh" runat="server" Text="Nhập mã học sinh:" Visible="False"></asp:Label>
                </td>
                <td align="right" style="width: 11px; height: 22px">
                </td>
                
                <td style="width: 940px; height: 22px;" align="left">
                    <asp:TextBox ID="txtMaHocSinh" runat="server" Visible="False" Width="172px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lblKiemTraMaHocSinh" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td align="right" style="width: 268px; height: 13px"></td>
                <td align="right" style="width: 11px; height: 13px">
                </td>
                
                <td align="left" style="width: 940px; height: 13px">
                    <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" />
                    </td>
            </tr>
        </table>
        
    </ajax:AjaxPanel>
     
</asp:Content>

