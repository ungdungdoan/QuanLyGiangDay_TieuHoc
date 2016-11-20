<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="XemDiemTheoTen.aspx.vb" Inherits="XemDiemTheoTen" title="Xem diem theo ten" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:AjaxPanel ID="panel1" runat="server">
        <div>
            <br />            
            <table id="TABLE1" style="width: 585px; height: 186px">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblTittle" runat="server" BackColor="#C0FFC0" Font-Size="X-Large" Height="26px" Text="Xem điểm theo tên" Width="359px"></asp:Label>
                    </td>            
                </tr>
            
                <tr>
                    <td align="center" colspan="4"></td>
                </tr>
                
                <tr>
                    <td style="width: 193px" align="left">
                        <asp:Label ID="lblHo" runat="server" Text="Họ:" Width="29px"></asp:Label>
                    </td>
                    
                    <td style="width: 718px" align="left">
                        <asp:TextBox ID="txtHo" runat="server" Width="175px"></asp:TextBox>
                    </td>
                    
                    <td style="width: 132px" align="left">
                        <asp:Label ID="lblTen" runat="server" Height="19px" Text="Tên:" Width="41px"></asp:Label>
                    </td>
                    
                    <td style="width: 195px" align="left">
                        <asp:TextBox ID="txtTen" runat="server" Width="148px"></asp:TextBox>
                    </td>
                    
                </tr>
                
                <tr>
                    <td style="width: 193px" align="left">
                        <asp:Label ID="lblNgaySinh" runat="server" Height="19px" Text="Ngày sinh:" Width="68px"></asp:Label>
                    </td>
                    
                    <td style="width: 718px" align="left">
                        <asp:TextBox ID="txtNgaySinh" runat="server" Width="111px"></asp:TextBox>&nbsp;
                    </td>                
                    <td style="width: 132px">&nbsp;</td>
                    <td style="width: 195px">&nbsp;</td>
                </tr>
                
                <tr>
                    <td style="width: 193px" align="left">
                       <asp:Label ID="Label3" runat="server" Text="Năm học:"></asp:Label>
                    </td>
                    
                    <td style="width: 718px" align="left">
                       <asp:DropDownList ID="ddlsNamHoc" runat="server" Width="120px" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    
                    <td style="width: 132px" align="left">
                       <asp:Label ID="Label2" runat="server" Height="19px" Text="Khối lớp:" Width="68px"></asp:Label>
                    </td>
                    
                    <td style="width: 195px" align="left">
                        <asp:DropDownList ID="ddlsKhoiLop" runat="server" Width="108px" AutoPostBack="true" ></asp:DropDownList>
                    </td>
                    
                </tr>
                
                <tr>
                    <td style="width: 193px; height: 28px"></td>
                    <td align="center" colspan="3" style="height: 28px">&nbsp;
                        <asp:Button ID="btnTimHocSinh" runat="server" Text="Tìm học sinh" Width="103px" />
                    </td>
                </tr>
                
             </table> <br />
        </div>
        
        <center>
            <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" Width="501px" Height="101px">
                <Columns>               
                    <asp:BoundField DataField="hohs" HeaderText="Họ" />
                    <asp:BoundField DataField="tenhs" HeaderText="Tên" />
                    <asp:BoundField DataField="tenlop" HeaderText="Lớp" />
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Xem điểm" OnClick='XemDiem' CommandName='<%# Eval("mahs") %>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </center>
    </ajax:AjaxPanel>
</asp:Content>
