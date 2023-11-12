<%@ Page Title="" Language="C#" MasterPageFile="~/GirislerMaster.Master" AutoEventWireup="true" CodeBehind="UyeBilgileri.aspx.cs" Inherits="BuiltEtmeCabasi.UyeBilgileri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--  <div class="KapsayiciPanel">

        <div class="UyeBilgileriPanel">

            <div class="UyeBilgileriHeader">
                <h3 class="UyeBilgileriBaslik">Üye Bilgileriniz</h3>
            </div>
             
            <div class="UyeBilgileriIcerik">

                <div class="UyeIsimSatir">
                    <label>İsim</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_uye_isim" runat="server"></asp:TextBox>
                </div>

                <div class="UyeSoyisimSatir">
                    <label>Soyisim</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_soyisim" runat="server"></asp:TextBox>
                </div>

                <div style="clear: both;"></div>

                <div class="UyeMailSatir">
                    <label>Mail</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_mail" runat="server"></asp:TextBox>
                </div>

                <div class="UyeAdiSatir">
                    <label>Üye Adı</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_uye_adi" runat="server"></asp:TextBox>
                </div>

                <div style="clear: both;"></div>

                <div class="UyeSifreSatir">
                    <label>Şifre</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_sifre" runat="server"></asp:TextBox>
                </div>

                <div class="UyeSifreTekrarSatir">
                    <label>Şifre Tekrar</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgiKutu" ID="txt_box_uye_sifre_tekrar" runat="server"></asp:TextBox>
                </div>

                <div style="clear: both;"></div>


            </div>
        </div>

        <div class="EczaneBilgileriPanel">
            <div class="EczaneBilgileriBaslikSatir">
                <h3 class="EczaneBilgileriBaslik">Eczane Bilgileri</h3>
            </div>

            <div class="EczaneBilgileri">

                <div class="EczaneAdiSatir">
                    <label>Eczanenizin adı</label>
                    <br />
                    <asp:TextBox CssClass="EczaneBilgiKutu" ID="txt_box_eczane_adi" runat="server"></asp:TextBox>
                </div>

                <div class="EczaneTakmaAdiSatir">
                    <label>Eczanenizin Takma Adı</label>
                    <br />
                    <asp:TextBox CssClass="EczaneBilgiKutu" ID="txt_box_eczane_takma_ad" runat="server"></asp:TextBox>
                </div>

                <div style="clear: both;"></div>

                <div class="EczaneSifre">
                    <label>Eczane Şifreniz</label>
                    <br />
                    <asp:TextBox CssClass="EczaneBilgiKutu" ID="txt_box_eczane_sifre" runat="server"></asp:TextBox>
                </div>

                <div class="EczaneTekrarSifre">
                    <label>Eczane Şifre Tekrar</label>
                    <br />
                    <asp:TextBox CssClass="EczaneBilgiKutu" ID="txt_box_eczane_sifre_tekrar" runat="server"></asp:TextBox>
                </div>

                <div style="clear: both;"></div>

                <div class="EczaneResimSatir">
                    <label>Eczanenizin resmi ya da resimleri</label>
                    <br />
                    <asp:FileUpload CssClass="EczaneResimYukle" ID="fl_eczane_resim" runat="server"></asp:FileUpload>
                </div>

                <div class="EczaneKonumSatir">
                    <label>Eczanenizin Konumu</label>
                    <br />
                    <asp:TextBox CssClass="EczaneBilgiKutu" ID="txt_box_eczane_konum" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>

            </div>
        </div>

        <div class="IlacBilgileriPanel">
            <div class="IlacBilgileriBaslikSatir">
                <h3 class="IlacBilgileriBaslik">İlaç Bilgileri</h3>
            </div>
            <div class="IlacBilgileri">
                <div class="IlacKategoriSatir">
                    <label>İlaç Kategorisi</label>
                    <br />
                    <asp:TextBox CssClass="IlacBilgileriKutu" ID="txt_box_ilac_bilgileri" runat="server"></asp:TextBox>
                </div>
                <div class="IlacIsimSatir">
                    <label>İlaç İsmi</label>
                    <br />
                    <asp:TextBox CssClass="IlacBilgileriKutu" ID="txt_box_ilac_isim" runat="server"></asp:TextBox>
                </div>
                <div class="IlacMarkaSatir">
                    <label>İlaç Markası</label>
                    <br />
                    <asp:TextBox CssClass="IlacBilgileriKutu" ID="txt_box_ilac_markasi" runat="server"></asp:TextBox>
                </div>
                <div class="IlacAciklamaSatir">
                    <label class="ss">İlaç Açıklama</label>
                    <br />
                    <asp:TextBox CssClass="IlacBilgileriAciklama" ID="txt_box_ilac_aciklama" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="ButtonSatir">
            <asp:LinkButton CssClass="BilgileriDegistirmeButton" ID="lnk_button_bilgileri_degistirme" runat="server">Güncelle</asp:LinkButton>
        </div>
        <div style="clear: both;"></div>

    </div>--%>

    <asp:Panel CssClass="PNLhata" ID="hata_pnl" runat="server">
        <asp:Label CssClass="LBLhata" ID="hata_lbl" runat="server">..</asp:Label>
    </asp:Panel>

    <asp:Panel CssClass="PNLhatasiz" ID="hatasiz_pnl" runat="server">
        <asp:Label CssClass="LBLhatasiz" ID="hatasiz_lbl" runat="server">..</asp:Label>
    </asp:Panel>

    <div class="BilgiPanelleriPanel">

        <div class="UyeBilgiPanel">
            <div class="UyeBilgiHeader">
                <h3>Üye Bilgileri</h3>
            </div>
            <div class="UyeBilgileriIcerik">

                <asp:Panel CssClass="PanelHata" ID="pnl_hata" runat="server">
                    <asp:Label CssClass="LabelHata" ID="lbl_hata" runat="server">asd</asp:Label>
                </asp:Panel>
                <asp:Panel CssClass="PanelBasarili" ID="pnl_basarili" runat="server">
                    <asp:Label CssClass="LabelBasarili" ID="lbl_basarili" runat="server">asd</asp:Label>
                </asp:Panel>

                <div class="BilgiSatir">
                    <label>İsminiz</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_uye_isim" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Soyisminiz</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_uye_soyisim" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Üye Adınız</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_uye_adi" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Şifreniz</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_sifre" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Mail</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_mail" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="EczaneBilgileriPanel">
            <div class="UyeBilgiHeader">
                <h3>Eczane Bilgileri</h3>
            </div>
            <div class="UyeBilgileriIcerik">

                <div class="BilgiSatir">
                    <label>Eczane ismi</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_eczane_isim" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Eczane Konum</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_eczane_konum" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div class="BilgiSatir">
                    <label>Eczane Resmi</label>
                    <br />
                    <asp:FileUpload CssClass="EczaneResim" ID="fu_eczane_resim" runat="server" />
                </div>
                <%-- <div class="BilgiSatir">
                    <label>Eczane İlaç Sayısı</label>
                    <br />
                    <asp:TextBox CssClass="UyeBilgileriKutu" ID="txt_box_eczane_ilac_sayisi" runat="server"></asp:TextBox>
                </div>--%>
                <%-- <div class="ButtonlarinSatir">
                    <asp:LinkButton CssClass="EkleButton" ID="link_btn_ekle" OnClick="link_btn_ekle_Click" runat="server">Ekle</asp:LinkButton>
                    <asp:LinkButton CssClass="KaydetButton" ID="link_btn_kaydet" OnClick="link_btn_kaydet_Click" runat="server">Kaydet</asp:LinkButton>
                </div>
                <div style="clear: both;"></div>--%>
            </div>
        </div>

        <div class="IlacBilgileriPanel">
            <div class="IlacBilgiBaslik">
                <h3>İlaç Bilgileri</h3>
            </div>
            <div class="IlacBilgiIcerikPanel">

                <%--<div class="BilgiSatir">
                    <label>İlaç Resim</label>
                    <br />
                    <asp:FileUpload CssClass="IlacResim" ID="fu_ilac_resim" runat="server" />
                </div>--%>

                <div class="BilgiSatir">
                    <label>İlaç İsim</label>
                    <br />
                    <asp:TextBox CssClass="IlacIsim" ID="txt_box_ilac_isim" runat="server" />
                </div>

                <div class="BilgiSatir">
                    <label>İlaç Marka</label>
                    <br />
                    <asp:TextBox CssClass="IlacMarka" ID="txt_ilac_marka" runat="server" />
                </div>

                <div class="BilgiSatir">
                    <label>İlaç Kategori</label>
                    <br />
                    <asp:TextBox CssClass="IlacMarka" ID="txt_box_ilac_kategori" runat="server" />
                </div>

                <div class="BilgiSatir">
                    <label>İlaç Aciklama</label>
                    <br />
                    <asp:TextBox CssClass="IlacMarka" ID="txt_box_ila_aciklama" runat="server" />
                </div>

                <div class="BtnIlacEkle">
                    <asp:LinkButton CssClass="IlacEkle" ID="link_btn_ilac_ekle" OnClick="link_btn_ilac_ekle_Click" runat="server">Ekle</asp:LinkButton>
                </div>
            </div>
        </div>

    </div>

    <div class="IlaclariListeleme">
        <div class="IlacListelemeHeader">
            <h3>Bünyedeki İlaçlar</h3>
        </div>
        <div class="IlacListelemeIcerik">
            <asp:ListView ID="lv_ilac_listeleme" OnItemCommand="lv_ilac_listeleme_ItemCommand" runat="server">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Marka</th>
                            <th>Kategori</th>
                            <th>Aciklama</th>
                            <th>Ayarlar</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>

                        <td>
                            <%# Eval("Isim") %>
                        </td>

                        <td>
                            <%# Eval("Marka") %>
                        </td>

                        <td>
                            <%# Eval("Kategori") %>

                        </td>

                        <td>
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                            <a href="BunyeIlacDuzenleme.aspx?IlacID=<%# Eval("ID") %>" class="BunyeIlacDuzenleme">Düzenle</a>
                            <asp:LinkButton CssClass="BunyeIlacSil" ID="link_btn_bunye_ilac_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>

                        <td>
                            <%# Eval("Isim") %>
                        </td>

                        <td>
                            <%# Eval("Marka") %>
                        </td>

                        <td>
                            <%# Eval("Kategori") %>

                        </td>

                        <td>
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                            <a href="BunyeIlacDuzenleme.aspx?IlacID=<%# Eval("ID") %>" class="BunyeIlacDuzenleme">Düzenle</a>
                            <asp:LinkButton CssClass="BunyeIlacSil" ID="link_btn_bunye_ilac_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
