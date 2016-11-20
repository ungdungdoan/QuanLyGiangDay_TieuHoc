<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="XemChiTietHocSinh.aspx.vb" Inherits="GiaoVien_XemChiTietHocSinh" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" Height="136px"
        Width="578px">
        <Columns>
            <asp:BoundField  HeaderText="Họ học sinh"  DataField="hohs"/>
            <asp:BoundField  HeaderText="Tên học sinh" DataField="tenhs"/>
            <asp:BoundField  HeaderText="Ngày sinh"    DataField="ngaysinh"/>
                        
            <asp:TemplateField HeaderText="Phái">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# IIf(Eval("phai"),"Nam","Nữ")%>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField  HeaderText="Địa chỉ" DataField="diachi"/>
            <asp:BoundField  HeaderText="Điện thoại" DataField="dienthoai"/>
        </Columns>
    </asp:GridView>
</asp:Content>

