<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="XemChiTietDiem.aspx.vb" Inherits="HocSinh_XemChiTietDiem" title="Xem chi tiet diem" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register Src="../UserControls/ChiTietDiem.ascx" TagName="ChiTietDiem" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <ajax:AjaxPanel ID="panel1" runat="server">
        <uc1:ChiTietDiem ID="ChiTietDiem1" runat="server" />
    </ajax:AjaxPanel>
</asp:Content>

