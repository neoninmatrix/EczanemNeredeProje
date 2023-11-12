<%@ Page Title="" Language="C#" MasterPageFile="~/GirislerMaster.Master" AutoEventWireup="true" CodeBehind="UyeOlmaGiris.aspx.cs" Inherits="BuiltEtmeCabasi.UyeOlmaGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="UyeOlmaPanel">
        <div class="UyeOlmaBaslikKutu">
            <h3 class="UyeOlmaBaslik">Üye Olma</h3>
        </div>

        <asp:Panel CssClass="BasariliPanel" ID="pnl_basarili" runat="server">
            <asp:Label CssClass="BasariliLabel" ID="lbl_basarili" runat="server">
                Başarılı bir şekilde üyemiz olunmuştur.
            </asp:Label>
            <asp:LinkButton CssClass="BasariliButton" ID="lnk_button_basarili" OnClick="lnk_button_basarili_Click" runat="server">
                <span class="material-symbols-outlined" style="float:right; color: green;">close</span>
            </asp:LinkButton>
            <div style="clear: both;"></div>
        </asp:Panel>
        <asp:Panel CssClass="BasarisizPanel" ID="pnl_basarisiz" runat="server">
            <asp:Label CssClass="BasarisizLabel" ID="lbl_basarisiz" runat="server"></asp:Label>
            <asp:LinkButton CssClass="BasarisizButton" ID="lnk_button_basarisiz" OnClick="lnk_button_basarisiz_Click" runat="server"><span class="material-symbols-outlined" style="float:right;color: red; user-select: none;">close</span></asp:LinkButton>
        </asp:Panel>

        <div class="UyeOlmaIcerik">
            <div class="SolTaraf">
                <div class="Satir">
                    <h3>İsminizi giriniz</h3>
                    <asp:TextBox CssClass="Kutu isim" ID="txt_box_isim" runat="server"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Soyisminizi giriniz</h3>
                    <asp:TextBox CssClass="Kutu soyisim" ID="txt_box_soyisim" runat="server"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Üye isminizi giriniz</h3>
                    <asp:TextBox CssClass="Kutu uyeIsim" ID="txt_box_uye_isim" runat="server"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Şifrenizi giriniz</h3>
                    <asp:TextBox CssClass="Kutu sifre" ID="txt_box_sifre" runat="server"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Şifrenizi tekrar giriniz</h3>
                    <asp:TextBox CssClass="Kutu sifretekrar" ID="txt_box_sifre_tekrar" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="SagTaraf">
                <div class="Satir">
                    <h3>Eczanenizin takma isminiz giriniz</h3>
                    <asp:TextBox CssClass="Kutu eczanetakmaisim" ID="txt_eczane_takma_isim" runat="server"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Eczanenizin şifresini giriniz</h3>
                    <asp:TextBox CssClass="Kutu eczanesifre" ID="txt_box_eczane_sifre" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Eczanenizin şifresini tekrar giriniz</h3>
                    <asp:TextBox CssClass="Kutu eczanesifretekrar" ID="txt_box_eczane_tekrar_sifre" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="Satir">
                    <h3>Mail adresinizi giriniz</h3>
                    <asp:TextBox CssClass="Kutu mail" ID="txt_box_mail" runat="server"></asp:TextBox>
                </div>
                <div class="ButtonSatir">
                    <asp:LinkButton CssClass="UyeOlButton" ID="lnk_button_uye_ol" runat="server" OnClick="lnk_button_uye_ol_Click">Üye Ol</asp:LinkButton>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>

</asp:Content>
