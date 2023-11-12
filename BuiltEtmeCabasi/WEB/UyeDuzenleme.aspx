<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="UyeDuzenleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.UyeDuzenleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel CssClass="UyeDegistirmeBilgilendirme" ID="pnl_uye_bilgilendirme" runat="server">
        <asp:Label CssClass="UyeBilgilendirmeYazi" ID="lbl_uye_bilgilendirme_yazi" runat="server">Üyenin Aktiflik Durumu 
            <asp:Label CssClass="AktiflikDurumu" ID="lbl_aktiflik" runat="server"></asp:Label></asp:Label>
    </asp:Panel>

    <div class="UyeDuzenlemePanel">
        <div class="UyeDuzenlemeHeader">
            <h3>Üyenin Bilgileri</h3>
        </div>
        <div class="UyeIcerik">
            <div class="UyeSatir">
                <label class="SS">Üye ID</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uye_id" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üye İsim</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uye_isim" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üye Soyisim</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uye_soyisim" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üyenin Takma Adı</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uye_takma_isim" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üye Eczane Takma Adı</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_eczane_takma_adi" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üye Mail</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uye_mail" runat="server"></asp:Label>
            </div>
            <div class="UyeSatir">
                <label class="SS">Üyenin Aktiflik Durumu</label>
                <asp:Label CssClass="UyeBilgileri" ID="lbl_uyelik_aktiflik_durumu" runat="server"></asp:Label>
            </div>
            <div class="AktiflikDegistirSatir">
                <asp:LinkButton CssClass="AktiflikDegistir" ID="link_btn_aktiflik_degistir" OnClick="link_btn_aktiflik_degistir_Click" runat="server">Hesabı BAN'la</asp:LinkButton>
                <%--<div style="clear:both;"></div>--%>
            </div>
        </div>
    </div>

</asp:Content>
