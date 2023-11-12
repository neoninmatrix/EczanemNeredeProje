<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="BuiltEtmeCabasi.AnaSayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="rp_makaleler_kisa" runat="server">
        <ItemTemplate>
            <div class="MakalelerKisaPanel">
                <div class="BaslikKisaSatir">
                    <h3><%# Eval("Baslik") %></h3>
                </div>
                <div class="MakaleKisaOzetSatir">
                    <label><%# Eval("Ozet") %></label>
                </div>
                <div class="MakaleResimKisaSatir">
                    <img src='MakaleResimler/<%# Eval("KapakResmi") %>' />
                </div>
                <div class="MakaleOzellikKisaSatir">
                    Yazar: <%# Eval("Yazar") %> | Kategori: <%# Eval("Kategori") %> | Görüntülenme Sayı: <%# Eval("GoruntulemeSayi") %>
                </div>

                <div class="MakaleDevaminiOkuSatir">
                    <a class="MakaleDevamiButton" href="MakaleDetay.aspx?makaleid=<%# Eval("ID")  %>">
                        Makalenin Devamı 
                    </a>
                </div> 
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
