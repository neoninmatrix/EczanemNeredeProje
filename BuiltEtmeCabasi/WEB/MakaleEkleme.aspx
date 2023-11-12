<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.MakaleEkleme"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="MakaleEklemePanel">
        <div class="MakaleEklemePanelBaslik">
            <h3>Makale Ekle</h3>
        </div>
        <div class="MakaleEklemeIcerik">

            <asp:Panel CssClass="BasariliMakaleEklemePanel" ID="pnl_makale_ekleme_basarili" runat="server">
                <asp:Label CssClass="BasariliMakaleEklemeLabel" ID="lnl_makale_ekleme_basarili" runat="server">
          Kategori Başarıyla Eklenmiştir.
                </asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_makale_ekleme_basarili_kapatma1" runat="server" OnClick="lnkbutton_makale_ekleme_basarili_kapatma1_Click">
         <span class="material-symbols-outlined" style="color:green;">close</span>
                </asp:LinkButton>
            </asp:Panel>

            <asp:Panel CssClass="BasarisizMakaleEklemePanel" ID="pnl_makale_ekleme_basarisiz" runat="server">
                <asp:Label CssClass="BasarisizMakaleEklemeLabel" ID="lbl_makale_ekleme_basarisiz" runat="server">Kategori eklenirken bir hata oluştu</asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_makale_ekleme_basarisiz_kapatma2" runat="server" OnClick="lnkbutton_makale_ekleme_basarisiz_kapatma2_Click">
         <span class="material-symbols-outlined" style="color:red;">close</span>
                </asp:LinkButton>
            </asp:Panel>

            <div class="MakaleEklemeIcerikSol">
                <div class="MakaleKategoriSatir">
                    <label>Kategori Seçiniz</label>
                    <br />
                    <asp:DropDownList CssClass="ddlMakaleKategori" ID="ddl_makale_kategori_seciniz" runat="server" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="MakaleBaslikSatir">
                    <label>Makale Baslik</label>
                    <br />
                    <asp:TextBox CssClass="txtboxMakaleBaslik" ID="txtbox_makale_baslik" runat="server"></asp:TextBox>
                </div>
                <div class="MakaleKapakResimSatir">
                    <label>Kapak Resim</label><br />
                    <asp:FileUpload CssClass="fuMakaleKapakResim" ID="fu_resim" runat="server" />
                </div>
                <div class="MakaleOzetSatir">
                    <label>Makale Ozet</label>
                    <br />
                    <asp:TextBox CssClass="txtboxMakaleOzet" ID="txtbox_makale_ozet" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="MakaleMetinYayinlaSatir">
                    <label style="margin-left: 5px; font-size: 12pt; font-weight: 700; user-select:none;">
                        Makale Yayınla
                    <asp:CheckBox CssClass="cboxMakaleYayinla" ID="cbox_makale_yayinla" runat="server" />
                    </label>
                </div>
                <div class="MakaleEkleButtonSatir">
                    <asp:LinkButton CssClass="lnkbuttonMakaleEkle" ID="lnkbutton_makale_ekle" runat="server" OnClick="lnkbutton_makale_ekle_Click">Makale Ekle</asp:LinkButton>
                </div>
            </div>
            <div class="MakaleIcerikSag">
                <div class="MakaleEklemeMakaleSatir">
                    <label style="font-size: 15pt;">Makale</label>
                    <br />
                    <asp:TextBox CssClass="txtCKEditor" ID="txtbox_makale_makale_ekleme_icerik" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div style="clear: both;"></div>

        </div>
    </div>



</asp:Content>
