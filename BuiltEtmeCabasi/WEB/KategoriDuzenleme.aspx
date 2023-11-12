<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.KategoriDuzenleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="Duzenlemepanel">

        <div class="BaslikKategoriDuzenleme">
            <h3 class="BaslikDuzenleme">Kategori Düzenleme</h3>
        </div>

        <div class="altKutu">
        
            <asp:Panel CssClass="DuzenlemeBasariliPanel" ID="pnl_duzenleme_basarili" runat="server">
                <asp:Label CssClass="DuzenlemeBasariliLabel" ID="lnl_duzenleme_basarili" runat="server">
                     Kategori başarıyla düzenlenmiştir.
                </asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_duzenleme_basarili_kapatma" runat="server" OnClick="lnkbutton_duzenleme_basarili_kapatma_Click">
                    <span class="material-symbols-outlined" style="color:green;">close</span>
                </asp:LinkButton>
            </asp:Panel>
          
            
            <asp:Panel CssClass="DuzenlemeBasarisizPanel" ID="pnl_duzenleme_basarisiz" runat="server">
                <asp:Label CssClass="DuzenlemeBasarisizLabel" ID="lbl_duzenleme_basarisiz" runat="server">
                    Kategori düzenlenirken bir hata oluştu.
                </asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_duzenleme_basarisiz_kapatma" runat="server" OnClick="lnkbutton_duzenleme_basarisiz_kapatma_Click">
                    <span class="material-symbols-outlined" style="color:red;">close</span>
                </asp:LinkButton>
            </asp:Panel>
            
            
            <div class="AdSatir">
                <label class="Ad">Kategori Adı</label>
                <br />
                <asp:TextBox CssClass="KategoriAdiMetinKutu" ID="txt_kategoriDuzenlemeAdiMetinKutu" runat="server"></asp:TextBox>
            </div>
            
            <div class="yataycizgi2"></div>
            
            <div class="AciklamaSatir">
                <label class="Aciklama">Kategori Açıklama</label>
                <br />
                <asp:TextBox CssClass="KategoriAciklamaMetinKutu" ID="txt_kategoriDuzenlemeAciklamaMetinKutu" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            
            <div class="DuzenlemeButtonSatir">
                <asp:LinkButton CssClass="DuzenlemeButton" ID="lnkbutton_duzenleme_button" runat="server" OnClick="lnkbutton_duzenleme_button_Click">Düzenle</asp:LinkButton>
            </div>
        
        </div>
    </div>

</asp:Content>
