<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="NhapChiTietDiem.aspx.vb" Inherits="NhapChiTietDiem" title="Nhap diem cho tung mon" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">&nbsp;    
    <ajax:AjaxPanel ID="panel1" runat="server">
        <table style="width: 310px">
            <tr>
                <td style="height: 21px" align="left">
                    <asp:Label ID="lblTenHocSinh" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td align="left" style="height: 21px">
                    <asp:Label ID="lblTenLop" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td align="left"></td>
            </tr>
            
            <tr>
                <td>
                    <br />
                    <asp:GridView ID="grvDiem" runat="server" AutoGenerateColumns="False" Width="635px">        
                        <Columns>        
                            <asp:TemplateField Visible="False" >
                                <ItemTemplate>
                                    <asp:Label id="lblMaMon" runat="server" Text='<%# Eval("mamon") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Tên môn học">
                                <ItemTemplate>
                                    <asp:Label id="lblTenMon" runat="server" Text='<%# Eval("tenmon") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Điểm 15 phút">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" id="txtDiem15" Width="80" Text='<%# Eval("diem15") %>' ></asp:TextBox>    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Điểm 1 tiết">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" id="txtDiem1Tiet" Width="80" Text='<%# Eval("diem1tiet") %>' ></asp:TextBox>    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Điểm thi học kỳ">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" id="txtDiemHocKy" Width="80" Text='<%# Eval("diemhocky") %>' ></asp:TextBox>    
                                </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>            
                            
                             <asp:TemplateField HeaderText="Trung bình môn">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" id="txtTrungBinhMon" Width="80" Text='<%# Eval("tbmon") %>' ></asp:TextBox>    
                                </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField Visible="False" >
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkCapNhat" Checked='<%# IIf(Eval("capnhat") is System.DbNull.Value,False,True) %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>          
                            
                        </Columns>        
                    </asp:GridView>    
                </td>
            </tr>
            
            <tr>
                <td align="right">
                    <asp:Button ID="btnLuu" runat="server" Text="Lưu thông tin" />&nbsp;
                </td>
            </tr>        
        </table>
    </ajax:AjaxPanel>
</asp:Content>


