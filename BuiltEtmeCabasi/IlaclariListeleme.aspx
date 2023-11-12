<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.Master" AutoEventWireup="true" CodeBehind="IlaclariListeleme.aspx.cs" Inherits="BuiltEtmeCabasi.IlaclariListeleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="rp_ilac_listeleme" runat="server">
        <ItemTemplate> 
            <div class="IlacBilgiPanel">
                <div class="sag">
                    <asp:Image CssClass="IlacResim" ID="img_ilac_resim" runat="server"/>
                </div>
                <div class="sol">
                    <asp:Label CssClass="IlacIsim" ID="lbl_ilac_isim" runat="server"></asp:Label>
                    <br />
                    <asp:Label CssClass="IlacKategori" ID="lbl_ilac_kategori" runat="server"></asp:Label>
                    <br />
                    <asp:Label CssClass="IlacFiyat" ID="lbl_ilac_fiyat" runat="server"></asp:Label>
                    <br />
                    <a href="IlacBilgisiDetay.aspx?ilacID<%# Eval("ID") %>">ilaç bilgisi için tıklayınız</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
