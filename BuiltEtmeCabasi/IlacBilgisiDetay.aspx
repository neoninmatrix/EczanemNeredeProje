<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.Master" AutoEventWireup="true" CodeBehind="IlacBilgisiDetay.aspx.cs" Inherits="BuiltEtmeCabasi.IlacBilgisiDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="IlacinDevamiPanel">
        <div class="EczaneBilgiKısmı">
            <div class="EczaneIsimSatir">
                <label>Eczanenin ismi=> </label>
                <asp:Label CssClass="EczaneIsim" ID="lbl_eczane_isim" runat="server"></asp:Label>
            </div>
            <div class="EczaneKonumSatir">
                <label>Eczanenin Konumu=> </label>
                <asp:LinkButton CssClass="KonumaGitBtn" ID="link_btn_eczane_konum" OnClick="link_btn_eczane_konum_Click" runat="server">
                    <asp:Label CssClass="EczaneKonum" ID="lbl_eczane_konum" runat="server">
                    </asp:Label>
                </asp:LinkButton>
            </div>
        </div>
        <div class="IlacBilgiIsim">
            <label>İlacın İsmi</label>
            <asp:Label CssClass="IlacIsim" ID="lbl_ilac_isim" runat="server"></asp:Label>
        </div>
        <div class="IlacBilgiMarka">
            <label>İlacın Markası</label>
            <asp:Label CssClass="IlacMarka" ID="lbl_ilac_marka" runat="server"></asp:Label>
        </div>
        <div class="IlacBilgiKategori">
            <label>İlacın Kategorisi</label>
            <asp:Label CssClass="IlacKategori" ID="lbl_ilac_kategori" runat="server"></asp:Label>
        </div>
        <div class="IlacBilgiAciklama">
            <label>İlac Açıklama</label>
            <asp:Label CssClass="IlacAciklama" ID="lbl_ilac_aciklama" runat="server"></asp:Label>
        </div>

    </div>

</asp:Content>
