using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class UyeDuzenleme : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_uye_bilgilendirme.Visible = false;
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["UyeID"]);
                    Uye uye = dm.UgeBilgileriGetir(id);
                    lbl_uye_id.Text = uye.ID.ToString();
                    lbl_uye_isim.Text = uye.Isim;
                    lbl_uye_soyisim.Text = uye.Soyisim;
                    lbl_uye_takma_isim.Text = uye.UyeAdi;
                    lbl_eczane_takma_adi.Text = uye.EczaneTakmaAdi;
                    lbl_uye_mail.Text = uye.Mail;   
                    lbl_uyelik_aktiflik_durumu.Text = uye.Aktif.ToString();
                    if (uye.Aktif == false)
                    {
                        lbl_uyelik_aktiflik_durumu.Text = "Aktif DEĞİL";
                    }
                    else
                    {
                        lbl_uyelik_aktiflik_durumu.Text = "Aktif";
                    }
                    
                }
            }
        }

        protected void link_btn_aktiflik_degistir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["UyeID"]);
            Uye u = new Uye();
            u.ID = id;
            //u.ID = lbl_uye_id.Text.;
            u.Isim = lbl_uye_isim.Text;
            u.Soyisim = lbl_uye_soyisim.Text;
            u.UyeAdi = lbl_uye_takma_isim.Text;
            u.EczaneTakmaAdi = lbl_eczane_takma_adi.Text;
            u.Mail = lbl_uye_mail.Text;
            if (dm.UyeAktifligiGuncelle(u))
            {
                pnl_uye_bilgilendirme.Visible = true;
                lbl_aktiflik.Text = u.Aktif.ToString();
                if (u.Aktif == true)
                {
                    lbl_aktiflik.Text = "Aktif";
                }
                else
                {
                    lbl_aktiflik.Text = "Aktif Değil";
                }
            }
            else
            {
                pnl_uye_bilgilendirme.Visible = true;
                lbl_uye_bilgilendirme_yazi.Text = "Üyenin durumu değiştirilirken bir hata oluştu";
                }
            }
    }
}