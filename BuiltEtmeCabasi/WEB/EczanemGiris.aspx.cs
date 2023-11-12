using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class html : System.Web.UI.Page
    {
        DataModel db = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            hata_pnl.Visible = false;
        }

        protected void giris_btn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(isim_txtbox.Text) && string.IsNullOrEmpty(sifre_txtbox.Text)))
            {
                if (isim_txtbox.Text.Length >= 3)
                {
                    Kullanici k = db.KullaniciKontrol(isim_txtbox.Text, sifre_txtbox.Text);
                    if (k != null)
                    {
                        if (k.Aktif)
                        {
                            Session["yon"] = k;//BOXING
                            Response.Redirect("Anasayfa.aspx");
                        }
                        else
                        {
                            hata_pnl.Visible = true;
                            hata_lbl.Text = "Hesabınız yönetici tarafından askıya alınmıştır";
                        }
                    }
                    else
                    {
                        hata_pnl.Visible = true;
                        hata_lbl.Text = "Kullanıcı Bulunamadı. Kullanıcı Adı ve şifreyi kontrol ediniz";
                    }
                }
                else
                {
                    hata_pnl.Visible = true;
                    hata_lbl.Text = "Kullanıcı Adı 3 karakterden az olamaz";
                }
            }
            else
            {
                hata_pnl.Visible = true;
                hata_lbl.Text = "Kullanıcı Adı Şifre Boş olamaz";
            }
        }
    }
}