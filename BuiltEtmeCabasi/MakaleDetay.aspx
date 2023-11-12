<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="BuiltEtmeCabasi.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="MakaleIcerik">
      <div class="MakaleBaslikSatir">
          <h3><asp:Label CssClass="MakaleBaslik" ID="lbl_makale_baslik" runat="server"></asp:Label></h3>
      </div>
      <div class="MakaleResimSatir">
          <asp:Image CssClass="Resim" ID="img_resim" runat="server"/>
      </div>
      <div class="MakaleBilgiSatir">
          Yazar: <asp:Label ID="lbl_yazar" runat="server"></asp:Label> | Kategori : <asp:Label ID="lbl_kategori" runat="server"></asp:Label> | Görüntülenme sayi: <asp:Label ID="lbl_goruntuleme_sayi" runat="server"></asp:Label>
      </div>
      <div class="MakaleIcerikSatir">
          <asp:Label ID="lbl_makale_icerik" runat="server"></asp:Label>
      </div>
  </div>

  
</asp:Content>
