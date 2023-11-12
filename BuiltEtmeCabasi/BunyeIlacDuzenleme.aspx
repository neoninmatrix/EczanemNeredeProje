<%@ Page Title="" Language="C#" MasterPageFile="~/GirislerMaster.Master" AutoEventWireup="true" CodeBehind="BunyeIlacDuzenleme.aspx.cs" Inherits="BuiltEtmeCabasi.BunyeIlacDuzenleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel CssClass="PanelBasariliBilgi" ID="pnl_guncelleme_basarili_bilgi" runat="server">
        <asp:Label CssClass="LabelBasariliBilgi" ID="lbl_guncelleme_basarili_bilgi" runat="server">İşlem başarılı bir şekilde gerçekleşmiştir.</asp:Label>
    </asp:Panel>

    <asp:Panel CssClass="PanelBasarisizBilgi" ID="pnl_guncelleme_basarisiz_bilgi" runat="server">
        <asp:Label CssClass="LabelBasarisizBilgi" ID="lbl_guncelleme_basarisiz_bilgi" runat="server">İşlem gerçekleşmemiştir.</asp:Label>
    </asp:Panel>


    <div class="IlacBilgisiDuzenlemePanel">
        <div class="IlacBilgisiDuzenlemeHeader">
            <h3>İlac Bilgisi Düzenleme</h3>
        </div>
        <div class="IlacBilgisiDuzenlemeIcerik">
            <div class="IlacBilgiDuzenlemeSatir">
                <label>İlaç isim</label>
                <br />
                <asp:TextBox CssClass="IlacBilgiDuzenlemeKutu" ID="txt_box_ilac_isim_duzenleme" runat="server"></asp:TextBox>
            </div>
            <div class="IlacBilgiDuzenlemeSatir">
                <label>İlaç marka</label>
                <br />
                <asp:TextBox CssClass="IlacBilgiDuzenlemeKutu" ID="txt_box_ilac_marka_duzenleme" runat="server"></asp:TextBox>
            </div>
            <div class="IlacBilgiDuzenlemeSatir">
                <label>İlaç Kategori</label>
                <br />
                <asp:TextBox CssClass="IlacBilgiDuzenlemeKutu" ID="txt_box_ilac_kategori_duzenleme" runat="server"></asp:TextBox>
            </div>
            <div class="IlacBilgiDuzenlemeSatir">
                <label>İlaç Aciklama</label>
                <br />
                <asp:TextBox CssClass="IlacBilgiDuzenlemeKutu" ID="txt_box_ilac_acikalam_duzenleme" runat="server"></asp:TextBox>
            </div>
            <div class="IlacBilgiDuzenlemeButtonSatir">
                <asp:LinkButton CssClass="IlacDuzenlemeButtonDuzenleme" ID="link_btn_ilac_duzeneleme" OnClick="link_btn_ilac_duzeneleme_Click1" runat="server">Düzenlemeleri Kaydet</asp:LinkButton>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>

</asp:Content>
