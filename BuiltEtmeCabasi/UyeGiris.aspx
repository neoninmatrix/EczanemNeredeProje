<%@ Page Title="" Language="C#" MasterPageFile="~/GirislerMaster.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="BuiltEtmeCabasi.UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="UyeGirisPanel">
        <div class="UyeGirisBaslikKutu">
            <h3 class="UyeGirisBaslik">Üye Giriş</h3>
        </div>
        <asp:Panel CssClass="UyeGirisBasarisizPanel" ID="pnl_uye_giris_basarisiz" runat="server">
            <asp:Label CssClass="UyeGirisBasarisizLabel" ID="lbl_uye_giris_basarisiz" runat="server">
            </asp:Label>
            <asp:LinkButton CssClass="UyeGirisBasarisizKapatma" ID="pnl_uye_giris_basarisiz_kapatma" OnClick="pnl_uye_giris_basarisiz_kapatma_Click" runat="server">
                <span class="material-symbols-outlined" style="color:red;float: right; user-select:none;">close</span>
            </asp:LinkButton>
            <div style="clear: both;"></div>
        </asp:Panel>
        <div class="UyeGirisIcerik">
            <div class="UyeGirisSatir">
                <h3 class="UyeIsim">Üye isminizi giriniz</h3>
                <asp:TextBox CssClass="UyeGirisKutu" ID="txt_box_uye_isim" runat="server"></asp:TextBox>
            </div>
            <div class="UyeGirisSatir">
                <h3 class="Sifre">Şifrenizi giriniz</h3>
                <asp:TextBox CssClass="UyeGirisKutu" ID="txt_box_sifre" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="UyeGirisSatir">
                <h3 class="EczaneTakmaIsim">Eczanenizin takma isminizi giriniz</h3>
                <asp:TextBox CssClass="UyeGirisKutu" ID="txt_box_eczane_takma_isim" runat="server"></asp:TextBox>
            </div>
            <div class="UyeGirisSatir">
                <h3 class="EczaneSifre">Eczaneniz için belirlemiş olduğunuz şifreyi giriniz</h3>
                <asp:TextBox CssClass="UyeGirisKutu" ID="txt_box_eczane_sifre" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="UyeGirisButtonSatir">
                <asp:LinkButton CssClass="UyeGirisButton" ID="lnk_button_uye_giris" OnClick="lnk_button_uye_giris_Click" runat="server">Giriş yap</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
