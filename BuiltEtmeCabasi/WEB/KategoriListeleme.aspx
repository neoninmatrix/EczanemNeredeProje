<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="KategoriListeleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.KategoriListeleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ListelemeKutu">
        <div class="ListelemeBaslik">
            <h3 class="LBaslik">Kategori Listesi</h3>
        </div>
        <div class="ListelemeIcerik">
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Açıklama</th>
                            <th>Seçenekler</th>
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
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                        <a href="KategoriDuzenleme.aspx?kid=<%# Eval("ID") %>" class="tablobutton duzenle">Düzenle</a>
                            <asp:LinkButton CssClass="tablobutton sil" ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Isim") %>
                        </td>
                        <td>
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                            <a href="KategoriDuzenleme.aspx?kid=<%# Eval("ID") %>" class="tablobutton duzenle">Düzenle</a>
                            <asp:LinkButton CssClass="tablobutton sil" ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
