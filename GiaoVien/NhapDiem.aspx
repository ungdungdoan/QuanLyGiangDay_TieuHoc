<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="NhapDiem.aspx.vb" Inherits="GiaoVien_NhapDiem" title="Nhap diem cho hoc sinh" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
    <ajax:AjaxPanel ID="panel1" runat="server">
        <table id="TABLE1" style="width: 620px; height: 143px">
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblTittle" runat="server" BackColor="#C0FFC0" Font-Size="X-Large" Height="26px" Text="Nhập điểm" Width="359px"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="4"></td>
            </tr>
            
            <tr>
                <td align="left" style="width: 67px">
                    <asp:Label ID="Label1" runat="server" Text="Năm học:" Width="65px"></asp:Label>
                </td>
                
                <td align="left" style="width: 222px">
                    <asp:DropDownList ID="ddlsNamHoc" runat="server" AutoPostBack="True" Width="140px"></asp:DropDownList>
                </td>
                
                <td align="left" style="width: 68px">
                    <asp:Label ID="Label2" runat="server" Height="19px" Text="Khối lớp:" Width="74px"></asp:Label>
                </td>
                
                <td align="left" style="width: 223px">
                    <asp:DropDownList ID="ddlsKhoiLop" runat="server" AutoPostBack="True" Width="91px"></asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td align="left" style="width: 67px; height: 25px">
                    <asp:Label ID="Label3" runat="server" Text="Lớp:"></asp:Label>
                </td>
                
                <td align="left" style="width: 222px; height: 25px">
                    <asp:DropDownList ID="ddlsLop" runat="server" AutoPostBack="True" Width="193px"></asp:DropDownList>
                </td>
                
                <td align="left" style="width: 68px; height: 25px">&nbsp;</td>
                <td align="left" style="width: 223px; height: 25px">&nbsp;</td>
            </tr>
            <tr>
            </tr>
        </table>
        
        <br />
        
        <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" BackColor="LightYellow" BorderColor="#C0C0FF" BorderStyle="Outset" Font-Size="Small" Height="163px" Width="828px">
            <Columns>
                <asp:BoundField DataField="MaHS" HeaderText="Mã học sinh" Visible="False" />
                <asp:BoundField DataField="HoHS" HeaderText="Họ" />
                <asp:BoundField DataField="TenHS" HeaderText="Tên" />
                
                <asp:TemplateField HeaderText="Ngày sinh">
                    <ItemTemplate>
                        <asp:Label ID="lblNgaySinh" runat="server" Text='<%# Eval("ngaysinh") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Phái">
                    <ItemTemplate>
                        <asp:Label ID="lblPhai" runat="server" Text='<%# IIf(Eval("phai"),"Nam","Nữ")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton id="lnkbtNhapDiemHKI" runat="server" Text="Học kỳ I" OnClick='NhapDiem' CommandName='<%# Eval("mahs") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton id="lnkbtNhapDiemHKII" runat="server" Text="Học kỳ II" OnClick='NhapDiem' CommandName='<%# Eval("mahs") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>  
                          
            </Columns>
            
            <EditRowStyle BackColor="DodgerBlue" BorderColor="#8080FF" />
            <HeaderStyle BackColor="Gold" ForeColor="Black" />
            
        </asp:GridView>
    
    </ajax:AjaxPanel>
    
</asp:Content>

