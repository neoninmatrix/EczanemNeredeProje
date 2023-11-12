using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_uye_giris_basarisiz.Visible = false;
        }
         
        protected void lnk_button_uye_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_box_uye_isim.Text) && !string.IsNullOrEmpty(txt_box_eczane_takma_isim.Text) && !string.IsNullOrEmpty(txt_box_sifre.Text) && !string.IsNullOrEmpty(txt_box_eczane_sifre.Text))
            {
                if (txt_box_uye_isim.Text.Length >= 4)
                {
                    Uye u = dm.UyeGiris(txt_box_uye_isim.Text, txt_box_sifre.Text, txt_box_eczane_takma_isim.Text, txt_box_eczane_sifre.Text);
                    if (u != null)
                    {
                        if (u.Aktif)
                        {
                            Session["uye"] = u;
                            Response.Redirect("AnaSayfa.aspx");
                        }
                        else
                        {
                            pnl_uye_giris_basarisiz.Visible = true;
                            lbl_uye_giris_basarisiz.Text = "Hesabınız askıya alınmıştır";
                        }
                    }
                    else
                    {
                        pnl_uye_giris_basarisiz.Visible = true;
                        lbl_uye_giris_basarisiz.Text = "Üye bulunamadı. Lütfen bilgilerinizi tekrar kontrol ediniz";
                    }
                }
                else
                {
                    pnl_uye_giris_basarisiz.Visible = true;
                    lbl_uye_giris_basarisiz.Text = "Üye isminiz en az 4 karakter olmak zorundadır";
                }
            }
            else
            {
                pnl_uye_giris_basarisiz.Visible = true;
                lbl_uye_giris_basarisiz.Text = "Üye ismi, şifre, eczane ismi ve şifre kısımları boş bırakılamaz";
            }
        }

        protected void pnl_uye_giris_basarisiz_kapatma_Click(object sender, EventArgs e)
        {
            pnl_uye_giris_basarisiz.Visible = false;
        }
    }
}