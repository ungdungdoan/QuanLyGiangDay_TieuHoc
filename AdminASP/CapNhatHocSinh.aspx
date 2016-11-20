<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CapNhatHocSinh.aspx.vb" Inherits="CapNhatHocSinh" title="Cap nhat thong tin hoc sinh" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <ajax:AjaxPanel ID="panel1" runat="server">        
            <table style="width: 702px; height: 401px" id="TABLE1">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblTittle" runat="server" BackColor="Honeydew" Font-Size="X-Large" Height="26px" Text="Cập nhật thông tin học sinh" Width="333px"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td align="left" colspan="1"></td>
                    <td align="left" colspan="2"></td>
                    <td align="left" colspan="1"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px"></td>
                    
                    <td style="width: 96px" align="left">
                        <asp:Label ID="lblHoHocSinh" runat="server" Text="Họ học sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px" align="left">
                        <asp:TextBox ID="txtHoHocSinh" runat="server"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="HoHocSinhRequiredValidator" runat="server" ControlToValidate="txtHoHocSinh" ErrorMessage="Chưa nhập họ học sinh!"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px"></td>
                    
                    <td style="width: 96px" align="left">
                        <asp:Label ID="lblTenHocSinh" runat="server" Text="Tên học sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px" align="left">
                        <asp:TextBox ID="txtTenHocSinh" runat="server"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="TenHocSinhRequiredValidator" runat="server" ErrorMessage="Chưa nhập tên!" ControlToValidate="txtTenHocSinh"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px"></td>
                    
                    <td style="width: 96px" align="left">
                        <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px" align="left">
                        <asp:DropDownList ID="ddlsNgay" runat="server"> </asp:DropDownList>&nbsp;
                        <asp:DropDownList ID="ddlsThang" runat="server"></asp:DropDownList>&nbsp;
                        <asp:DropDownList ID="ddlsNam" runat="server"></asp:DropDownList>&nbsp;
                        <asp:Label ID="lblKiemTraNgay" runat="server" ForeColor="Red" Text="Ngày không hợp lệ" Visible="False"></asp:Label>
                    </td>
                    
                    <td align="left" style="width: 257px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px; height: 20px"></td>
                    
                    <td style="width: 96px; height: 20px" align="left">
                        <asp:Label ID="lblPhai" runat="server" Text="Giới tính:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px; height: 20px" align="left">
                        <asp:RadioButtonList ID="rblPhai" runat="server" Width="150px" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 20px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px; height: 18px"></td>
                    
                    <td style="width: 96px; height: 18px" align="left">
                        <asp:Label ID="lblDiaChi" runat="server" Text="Địa chỉ:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px; height: 18px" align="left">
                        <asp:TextBox ID="txtDiaChi" runat="server" Height="59px" TextMode="MultiLine" Width="235px"></asp:TextBox>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px; height: 18px"></td>
                    
                    <td style="width: 96px; height: 18px" align="left">
                        <asp:Label ID="lblDienThoai" runat="server" Text="Số điện thoại:"></asp:Label>
                    </td>
                    
                    <td style="width: 604px; height: 18px" align="left">
                        <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px; height: 18px"></td>
                    
                    <td style="width: 96px; height: 18px" align="left"></td>
                    
                    <td style="width: 604px; height: 18px" align="left">
                        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" Width="59px" />&nbsp;
                    </td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 96px; height: 18px"></td>
                    
                    <td align="left" style="width: 96px; height: 18px">
                        <asp:HyperLink ID="lnkDanhSachHocSinh" runat="server" NavigateUrl="~/Admin/DanhSachHocSinh.aspx" Width="87px">Quay lại</asp:HyperLink>
                    </td>
                    
                    <td align="left" style="width: 604px; height: 18px"></td>
                    
                    <td align="left" style="width: 257px; height: 18px"></td>
                </tr>
                
            </table>
        </ajax:AjaxPanel>
   </div>
</asp:Content>