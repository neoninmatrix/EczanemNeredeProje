using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class UyeOlmaGiris : System.Web.UI.Page
    {

        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_basarili.Visible = false;
            pnl_basarisiz.Visible = false;



        }

        protected void lnk_button_basarili_Click(object sender, EventArgs e)
        {
            pnl_basarili.Visible = false;
        }

        protected void lnk_button_basarisiz_Click(object sender, EventArgs e)
        {
            pnl_basarili.Visible = false;
        }

        protected void lnk_button_uye_ol_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_box_sifre.Text) && !string.IsNullOrEmpty(txt_box_eczane_sifre.Text))
            {
                if (txt_box_sifre.Text == txt_box_sifre_tekrar.Text && txt_box_eczane_sifre.Text == txt_box_eczane_tekrar_sifre.Text)
                {
                    Uye u = new Uye();
                    u.Isim = txt_box_isim.Text;
                    u.Soyisim = txt_box_soyisim.Text;
                    u.UyeAdi = txt_box_uye_isim.Text;
                    u.Sifre = txt_box_sifre.Text;
                    u.EczaneTakmaAdi = txt_eczane_takma_isim.Text;
                    u.EczaneSifre = txt_box_eczane_sifre.Text;
                    u.Mail = txt_box_mail.Text;
                    u.OlusturulmaTarihi = DateTime.Now;
                    u.Aktif = true;
                    u.Silinmis = true;
                    if (dm.UyeOl(u))
                    {
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_basarili.Text = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Girdiğiniz şifreler eşleşmiyor.";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Girdiğiniz kısımlar boş bırakılamaz";
                txt_box_eczane_sifre.BorderColor = Color.Red;
                txt_box_eczane_tekrar_sifre.BorderColor = Color.Red;
                txt_box_sifre.BorderColor = Color.Red;
                txt_box_sifre_tekrar.BorderColor = Color.Red;
            }
        }
    }
}