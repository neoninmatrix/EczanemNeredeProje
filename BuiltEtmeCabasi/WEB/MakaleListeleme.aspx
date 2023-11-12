<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Kullanicimaster.Master" AutoEventWireup="true" CodeBehind="MakaleListeleme.aspx.cs" Inherits="BuiltEtmeCabasi.WEB.MakaleListeleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="MakaleListelemePanel">
       <div class="MakaleListelemeBaslikKutu">
           <h3 class="MakaleListelemeBaslik">Makale Listeleme</h3>
       </div>
       <div class="MakaleListelemeIcerik">
           <asp:ListView ID="lv_makale_listeleme" runat="server" OnItemCommand="lv_makale_listeleme_ItemCommand">
               <LayoutTemplate>
                   <table cellpading="0" cellspacing="0">
                       <tr>
                           <th>ID</th>
                           <th>Isim</th>
                           <th>Kategori</th>
                           <th>Yazar</th>
                           <th>Ekleme Tarihi</th>
                           <th>Görüntülenme Sayı</th>
                           <th>Yayımlanmış</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr class="ItemTemplateAltı">
                       <td>
                           <%# Eval("ID") %>
                       </td>
                       <td>
                           <%# Eval("Baslik") %>
                       </td>
                       <td>
                           <%# Eval("Kategori") %>
                       </td>
                       <td>
                           <%# Eval("Yazar") %>
                       </td>
                       <td>
                           <%# Eval("EklemeTarihi") %> <!-- HATA BURADA OLABİLİR -->
                       </td>
                       <td>
                           <%# Eval("GoruntulemeSayi") %>
                       </td>
                       <td>
                           <%# Eval("Aktif") %>
                       </td>
                       <td>
                          <a href="MakaleDuzenleme.aspx?mid=<%#Eval("ID") %>" class="MakaleButtonDuzenle">Düzenle</a>
                           <asp:LinkButton CssClass="MakaleListelemeSil" ID="lnk_button_makale_sil" CommandName = "Sil" CommandArgument='<%#Eval("ID") %>' runat="server">Sil</asp:LinkButton>
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>

</asp:Content>
