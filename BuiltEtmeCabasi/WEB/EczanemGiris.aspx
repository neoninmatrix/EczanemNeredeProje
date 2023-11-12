<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EczanemGiris.aspx.cs" Inherits="BuiltEtmeCabasi.html" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/css.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Bricolage+Grotesque:opsz@12..96&display=swap" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+Syriac+Eastern&display=swap" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h3 class="baslik1">EczanemNerede</h3>
            <label class="slogan">Yüzlerce eczane ve ilaç hakkında bilgiler</label>
        </div>
        <div class="form">
            <h3 class="baslik2">Kullanıcı Girişi</h3>
            <div class="yataycizgi1"></div>
            <asp:Panel CssClass="hatapanel" runat="server" ID="hata_pnl">
                <asp:Label CssClass="hatalabel" runat="server" ID="hata_lbl"></asp:Label>
            </asp:Panel>
            <div class="sutun">
                <label class="isim">Kullanıcı ismi</label>
                <br />
                <asp:TextBox CssClass="isimtextbox" runat="server" ID="isim_txtbox"></asp:TextBox>
            </div>
            <div class="sutun">
                <label class="sifre">Kullanıcı şifre</label>
                <br />
                <asp:TextBox CssClass="sifretextbox" runat="server" ID="sifre_txtbox" TextMode="Password"></asp:TextBox>
            </div>
            <div class="buttonsutun">
               <asp:LinkButton CssClass="girisbuton" runat="server" ID="giris_btn" OnClick="giris_btn_Click">Giriş Yap</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
