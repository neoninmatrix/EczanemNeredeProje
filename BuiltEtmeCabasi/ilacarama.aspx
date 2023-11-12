<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.Master" AutoEventWireup="true" CodeBehind="ilacarama.aspx.cs" Inherits="BuiltEtmeCabasi.ilacarama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <asp:Repeater ID="rp_ilac_arama_sonuc" runat="server">
     <ItemTemplate>
         <div class="IlacPanel">
             <div class="IlacIsimSatir">
                 <h3><%# Eval("Isim") %></h3>
             </div>
             <div class="IlacMarkaSatir">
                 <label><%# Eval("Marka") %></label>
             </div>
             <div class="MakaleResimKisaSatir">
                 <label><%# Eval("Kategori") %></label>
             </div>
         </div>
     </ItemTemplate>
 </asp:Repeater>--%>

    <asp:Repeater ID="rp_ilac_arama_sonuc" runat="server">
        <ItemTemplate>
            <div class="IlacPanel1">
                <div class="IlacIsimSatir">
                    <h3><%# Eval("Isim") %></h3>
                </div>
                <div class="IlacMarkaSatir">
                   <label>Marka:</label> <label><%# Eval("Marka") %></label>
                </div>
                <div class="MakalKategoriKisaSatir">
                    <label>Kategori:</label> <label><%# Eval("Kategori") %></label>
                </div>
                <div class="IlacBilgiDevamı">
                    <a class="IlacBilgiDevamıButton" href="IlacBilgisiDetay.aspx?ilacbilgiID=<%# Eval("ID") %>">İlac bilgisi için Tıklayın<label class="sus">=></label></a>
                </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="IlacPanel2">
                <div class="IlacIsimSatir">
                    <h3><%# Eval("Isim") %></h3>
                </div>
                <div class="IlacMarkaSatir">
                   <label>Marka:</label> <label><%# Eval("Marka") %></label>
                </div>
                <div class="MakalKategoriKisaSatir">
                   <label>Kategori:</label> <label><%# Eval("Kategori") %></label>
                </div>
                <div class="IlacBilgiDevamı">
                    <a class="IlacBilgiDevamıButton" href="IlacBilgisiDetay.aspx?ilacbilgiID=<%# Eval("ID") %>">İlac bilgisi için Tıklayın<label class="sus">=></label></a>
                </div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>

</asp:Content>
