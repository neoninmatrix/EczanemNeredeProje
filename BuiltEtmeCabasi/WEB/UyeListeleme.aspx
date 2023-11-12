<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="UyeListeleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.UyeListeleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="UyeListelePanel">
        <div class="UyeListelemeBaslikSatir">
            <h3 class="UyeListelemeBaslik">Üye Listesi</h3>
        </div>
        <div class="UyeListelemeIcerik">
            <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr class="tr">
                            <th>Isim Soyisim</th>
                            <th>Kullanıcı Adı</th>
                            <th>Üyelik Tarih</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="tr2">
                        <td>
                            <%# Eval("Isim") %> <%# Eval("Soyisim") %>
                        </td>
                        <td>
                            <%# Eval("UyeAdi") %>
                        </td>
                        <td>
                            <%# Eval("OlusturulmaTarihi") %>
                        </td>
                        <td>
                            <%# Eval("Aktif") %>
                        </td>
                        <td class="sonSatir">
                            <a href="UyeDuzenleme.aspx?UyeID=<%# Eval("ID") %>" class="UyelikDurumuDegistirmeButton">Durum Değiştir</a>
                            <asp:LinkButton CssClass="UyeSilButton" ID="lnk_button_uye_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' >Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
