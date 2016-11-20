<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="TimKiemHocSinh.aspx.vb" Inherits="GiaoVien_TimKiemHocSinh" title="Tim kiem thong tin hoc sinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="TABLE1" style="width: 585px; height: 186px">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lblTittle" runat="server" BackColor="#C0FFC0" Font-Size="X-Large" Height="26px" Text="Tìm kiếm thông tin học sinh" Width="359px"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="4"></td>
        </tr>
        
        <tr>
            <td align="left" style="width: 294px">
                <asp:Label ID="lblHo" runat="server" Text="Họ:" Width="29px"></asp:Label>
            </td>
            
            <td align="left" style="width: 570px">
                <asp:TextBox ID="txtHo" runat="server" Width="195px"></asp:TextBox>
            </td>
            
            <td align="left" style="width: 132px">
                <asp:Label ID="lblTen" runat="server" Height="19px" Text="Tên:" Width="41px"></asp:Label>
            </td>
            
            <td align="left" style="width: 195px">
                <asp:TextBox ID="txtTen" runat="server" Width="148px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="left" style="width: 294px">
                <asp:Label ID="Label3" runat="server" Text="Năm học:"></asp:Label>
            </td>
            
            <td align="left" style="width: 570px">
                <asp:DropDownList ID="ddlsNamHoc" runat="server" AutoPostBack="true" Width="128px"></asp:DropDownList>
            </td>
            
            <td align="left" style="width: 132px">
                <asp:Label ID="Label2" runat="server" Height="19px" Text="Khối lớp:" Width="68px"></asp:Label>
            </td>
            
            <td align="left" style="width: 195px">
                <asp:DropDownList ID="ddlsKhoiLop" runat="server" AutoPostBack="true" Width="108px"></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td style="width: 294px; height: 28px"></td>
            <td align="center" colspan="3" style="height: 28px">&nbsp;
                <asp:Button ID="btnTimHocSinh" runat="server" Text="Tìm" Width="76px" />
            </td>
        </tr>
    </table>
    
    <br />
    
    <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" Height="101px" Width="501px">
        <Columns>
            
            <asp:BoundField DataField="hohs" HeaderText="Họ" />
            <asp:BoundField DataField="tenhs" HeaderText="Tên" />
            <asp:BoundField DataField="tenlop" HeaderText="Lớp" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName='<%# Eval("mahs") %>' OnClick='XemChiTietHocSinh' Text="Xem chi tiết"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</asp:Content>

