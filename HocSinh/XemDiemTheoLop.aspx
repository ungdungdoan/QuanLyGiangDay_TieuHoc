<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="XemDiemTheoLop.aspx.vb" Inherits="XemDiemTheoLop" title="Xem diem theo lop" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <ajax:AjaxPanel ID="AjaxPanel1" runat="server">
        <div>        
            <table id="TABLE1" style="width: 573px; height: 143px">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblTittle" runat="server" BackColor="#C0FFC0" Font-Size="X-Large" Height="26px" Text="Xem điểm theo lớp" Width="359px"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td align="center" colspan="4"></td>
                </tr>
                        
                <tr>
                    <td style="width: 193px" align="left">
                        <asp:Label ID="Label1" runat="server" Text="Năm học:" Width="65px"></asp:Label>
                    </td>
                            
                    <td style="width: 414px" align="left">
                        <asp:DropDownList ID="ddlsNamHoc" runat="server" Width="140px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                            
                    <td style="width: 132px" align="left">
                        <asp:Label ID="Label2" runat="server" Height="19px" Text="Khối lớp:" Width="74px"></asp:Label>
                    </td>
                            
                    <td style="width: 223px" align="left">
                        <asp:DropDownList ID="ddlsKhoiLop" runat="server" Width="91px" AutoPostBack="True"></asp:DropDownList>
                    </td>                
                </tr>
                        
                <tr>
                    <td style="width: 193px" align="left">
                        <asp:Label ID="Label3" runat="server" Text="Lớp:"></asp:Label>
                    </td>
                            
                    <td style="width: 414px" align="left">                        
                        <asp:DropDownList ID="ddlsLop" runat="server" Width="194px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                            
                    <td style="width: 132px" align="left">
                        <asp:Label ID="Label4" runat="server" Text="Môn học:"></asp:Label>
                    </td>
                            
                    <td style="width: 223px" align="left">
                        <asp:DropDownList ID="ddlsMonHoc" runat="server" Width="161px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td align="left" style="width: 193px"></td>
                    <td align="left" style="width: 414px"></td>
                    <td align="left" style="width: 132px">
                        <asp:Button ID="btnXemDiem" runat="server" Text="Xem điểm" Width="75px" />
                    </td>
                    <td align="left" style="width: 223px"></td>
                </tr>
                        
            </table>
                
        </div><br />
         
        <center>       
            <asp:GridView ID="grvBangDiem" runat="server" Height="163px" Width="582px" AutoGenerateColumns="False" BackColor="#FFFFC0" BorderColor="Black" BorderWidth="2px"> 
                <Columns>
                    <asp:BoundField DataField="hohs" HeaderText="Họ" />
                    <asp:BoundField DataField="tenhs" HeaderText="Tên" />
                    <asp:BoundField DataField="diem15" HeaderText="15'" />
                    <asp:BoundField DataField="diem1tiet" HeaderText="45'" />
                    <asp:BoundField DataField="diemhocky" HeaderText="Thi học kỳ" />
                    <asp:BoundField DataField="tbmon" HeaderText="Trung bình môn" />
                    <asp:BoundField DataField="hocky" HeaderText="Học kỳ" />
                </Columns>
                <RowStyle BackColor="#FFFFC0" />
            </asp:GridView>
        </center>
    </ajax:AjaxPanel> 
</asp:Content>