<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.KategoriEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel">

        <div class="BaslikKategoriEkleme1">
            <h3 class="BaslikEkleme">Kategori Ekleme</h3>
        </div>
        <div class="altKutu">
            <asp:Panel CssClass="BasariliPanel" ID="pnl_basarili" runat="server">
                <asp:Label CssClass="BasariliLabel" ID="lnl_basarili" runat="server">
                     Kategori Başarıyla Eklenmiştir.
                </asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_kapatma1" runat="server" OnClick="lnkbutton_kapatma1_Click">
                    <span class="material-symbols-outlined" style="color:green;">close</span>
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel CssClass="BasarisizPanel" ID="pnl_basarisiz" runat="server">
                <asp:Label CssClass="BasarisizLabel" ID="lbl_basarisiz" runat="server">Kategori eklenirken bir hata oluştu</asp:Label>
                <asp:LinkButton CssClass="KapatmaButton" ID="lnkbutton_kapatma2" runat="server" OnClick="lnkbutton_kapatma2_Click">
                    <span class="material-symbols-outlined" style="color:red;">close</span>
                </asp:LinkButton>
            </asp:Panel>
            <div class="AdSatir">
                <label class="Ad">Kategori Adı</label>
                <br />
                <asp:TextBox CssClass="KategoriAdiMetinKutu" ID="txt_kategoriAdiMetinKutu" runat="server"></asp:TextBox>
            </div>
            <div class="yataycizgi2"></div>
            <div class="AciklamaSatir">
                <label class="Aciklama">Kategori Açıklama</label>
                <br />
                <asp:TextBox CssClass="KategoriAciklamaMetinKutu" ID="txt_kategoriAciklamaMetinKutu" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="EklemeButtonSatir">
                <asp:LinkButton CssClass="EklemeButton" ID="lnkbutton_eklemeButton" runat="server" OnClick="lnkbutton_eklemeButton_Click">Kategori Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
