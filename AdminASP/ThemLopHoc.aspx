<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ThemLopHoc.aspx.vb" Inherits="ThemLopHoc" title="Them lop hoc moi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <div>        
        <br />        
        <asp:Label ID="lblTittle" runat="server" BackColor="#80FF80" Font-Size="X-Large" Height="26px" Text="Thêm lớp học mới" Width="359px"></asp:Label><br /><br />                
        
        <table style="width: 506px; height: 118px">
            <tr>
                <td style="width: 133px">
                    <asp:Label ID="Label1" runat="server" Text="Tên lớp:"></asp:Label>
                </td>
                            
                <td align="left">
                    <asp:TextBox ID="txtTenLop" runat="server" Width="194px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TenLopRequiredValidator" runat="server" ControlToValidate="txtTenLop"
                        ErrorMessage="Chưa nhập tên lớp!"></asp:RequiredFieldValidator></td>
            </tr>
                        
            <tr>
                <td style="width: 133px">
                    <asp:Label ID="Label3" runat="server" Text="Năm học"></asp:Label>
                </td>
                            
                <td align="left">
                    <asp:DropDownList ID="ddlsNamHoc" runat="server" Width="149px"></asp:DropDownList>
                </td>
            </tr>
                        
            <tr>
                <td style="width: 133px; height: 20px">
                    <asp:Label ID="lblKhoi" runat="server" Text="Khối lớp:"></asp:Label>
                </td>
                            
                <td style="height: 20px" align="left">
                    <asp:DropDownList ID="ddlsKhoi" runat="server" Width="148px"></asp:DropDownList>
                </td>
                
            </tr>
                        
            <tr>
                <td style="width: 133px; height: 20px"></td>
                            
                <td style="height: 20px" align="left">
                    <asp:Button ID="btnThem" runat="server" Text="Thêm" Width="80px" />
                </td>
            </tr>
                        
        </table>
    
    </div>
</asp:Content>