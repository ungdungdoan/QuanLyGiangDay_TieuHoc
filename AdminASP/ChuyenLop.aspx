<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ChuyenLop.aspx.vb" Inherits="HocSinh_ChuyenLop" title="Chuyen lop cho hoc sinh" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <br />
    <ajax:AjaxPanel ID="panel1" runat="server">
    
        <table style="width: 317px; height: 86px;">
            <tr>
                <td style="width: 123px; height: 33px">
                    <asp:Label ID="lblChonLopMoi" runat="server" Text="Chọn lớp mới:" Width="94px"></asp:Label>
                </td>
                
                <td style="height: 33px">
                    <asp:DropDownList ID="ddlsLop" runat="server" Width="184px"></asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td style="width: 123px; height: 19px"></td>
                <td style="height: 19px">
                    <asp:Button ID="btnChuyenLop" runat="server" Text="Chuyển lớp" />&nbsp;
                </td>
            </tr>
            
            <tr>
                <td style="width: 123px"></td>
                
                <td />
            </tr>            
        </table>
        
    </ajax:AjaxPanel>  
    
</asp:Content>

