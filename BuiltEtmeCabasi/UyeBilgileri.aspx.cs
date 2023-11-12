using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class UyeBilgileri : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            hatasiz_pnl.Visible = false;
            hata_pnl.Visible = false;

            pnl_basarili.Visible = false;
            pnl_hata.Visible = false;
            Uye u = (Uye)Session["uye"];
            Uye uye = dm.UgeBilgileriGetir(u.ID);
            txt_box_uye_isim.Text = uye.Isim;
            txt_box_uye_soyisim.Text = uye.Soyisim;
            txt_box_mail.Text = uye.Mail;
            txt_box_uye_adi.Text = uye.UyeAdi;
            txt_box_sifre.Text = uye.Sifre;

            Eczaneler eczane = dm.EczaneBilgileriGetir(uye.ID);
            txt_box_eczane_isim.Text = eczane.Isim;
            txt_box_eczane_konum.Text = eczane.Konum;
            //txt_box_eczane_ilac_sayisi.Text = eczane.IlacSayisi.ToString();

            #region Daha düzenli olmasından böyle yaptım

            //lv_ilac_listeleme.DataSource = dm.BunyeIlacListele(uye.ID);// Bu yandaki bize uyenin ID'sini döndürüyor bunu eczaneID yapmamız lazım
            //lv_ilac_listeleme.DataBind();

            //Ilaclar uyeID = dm.IlacEczaneIDGetir(u.ID);
            //txt_box_ilac_isim.Text = uyeID.Isim;
            //Ilaclar listele = dm.BunyeIlacListele();

            //lv_ilac_listeleme.DataSource = dm.BunyeIlacListele();
            //lv_ilac_listeleme.DataBind();

            #endregion

            Eczaneler eczaneler = dm.EczaneColumnUyeIDCekmeDeneme(uye.ID);
            Ilaclar ilaclar = dm.IlaclarColumnEczaneIDCekmeDeneme(eczane.ID);


            lv_ilac_listeleme.DataSource = dm.BunyeIlacListele(ilaclar.EczaneID);
            lv_ilac_listeleme.DataBind();

        }

        protected void link_btn_kaydet_Click(object sender, EventArgs e)
        {
            #region Denenler


            //    //Uye u = (Uye)Session["uye"];
            //    //Eczaneler eczaneler = new Eczaneler();

            //    //bool eczane = dm.EczaneBilgileriniGuncelle(eczaneler);
            //    //eczaneler.Isim = txt_box_eczane_isim.Text;
            //    //eczaneler.Konum = txt_box_eczane_konum.Text;


            //    Uye u = (Uye)Session["uye"];
            //    //Eczaneler eczane = dm.EczaneBilgiGuncelle(u.ID);
            //    Eczaneler ecz = new Eczaneler();
            //    //txt_box_eczane_isim.Text = ecz.Isim;
            //    //txt_box_eczane_konum.Text = ecz.Konum;
            //    //txt_box_eczane_ilac_sayisi.Text = ecz.IlacSayisi.ToString();
            //    int UyeID = u.ID;
            //    string eczIsim = txt_box_eczane_isim.Text;
            //    string eczKonum = txt_box_eczane_konum.Text;
            //    Int64 eczIlacSayi = Convert.ToInt64(txt_box_eczane_ilac_sayisi.Text);
            //    string eczResim = fu_eczane_resim.FileName; 

            //    bool UygunUzanti = true;
            //    if (fu_eczane_resim.HasFile)
            //    {
            //        FileInfo fi = new FileInfo(fu_eczane_resim.FileName);
            //        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
            //        {
            //            string dosyaAdi = Guid.NewGuid().ToString();
            //            string uzanti = fi.Extension;
            //            fu_eczane_resim.SaveAs(Server.MapPath("/EczaneResimleri/" + dosyaAdi + uzanti));
            //            eczResim = dosyaAdi + uzanti;
            //        }
            //        else
            //        {
            //            UygunUzanti = false;
            //        }
            //    }

            //    Eczaneler eczane = dm.EczaneBilgiGuncelle(UyeID, eczIsim, eczKonum, eczResim , eczIlacSayi);

            #endregion

        }

        protected void link_btn_ekle_Click(object sender, EventArgs e)
        {

        }

        protected void link_btn_ilac_ekle_Click(object sender, EventArgs e)
        {
            Uye u = (Uye)Session["uye"];
            Eczaneler eczane = dm.EczaneBilgileriGetir(u.ID);
            if (!string.IsNullOrEmpty(txt_box_ilac_isim.Text) || !string.IsNullOrEmpty(txt_box_ilac_kategori.Text) || !string.IsNullOrEmpty(txt_box_ila_aciklama.Text) || !string.IsNullOrEmpty(txt_ilac_marka.Text))
            {
              
                Ilaclar ilac = new Ilaclar();
                ilac.Isim = txt_box_ilac_isim.Text;
                ilac.Marka = txt_ilac_marka.Text;
                ilac.Aciklama = txt_box_ila_aciklama.Text; 
                ilac.Kategori = txt_box_ilac_kategori.Text;
                ilac.Fiyat = 0;
                ilac.EczaneID = eczane.ID;

                if (dm.IlacEkle(ilac))
                {
                    hatasiz_pnl.Visible = true;
                    hatasiz_lbl.Text = "İlaç başarılı bir şekilde eklenmiştir";
                    hata_pnl.Visible = false;
                }
                else
                {
                    hatasiz_pnl.Visible = false;
                    hata_lbl.Text = "İlaç eklenirken bir hata oluştu";
                    hata_pnl.Visible = true;
                }
            }
            else
            {
                    hata_pnl.Visible = true;
                    hata_lbl.Text = "Bu kısım boş bırakılamaz.";
            }
        }

        protected void lv_ilac_listeleme_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Uye u = (Uye)Session["uye"];
            Uye uye = dm.UgeBilgileriGetir(u.ID);
            Eczaneler eczane = dm.EczaneBilgileriGetir(uye.ID);
            Eczaneler eczaneler = dm.EczaneColumnUyeIDCekmeDeneme(uye.ID);
            Ilaclar ilaclar = dm.IlaclarColumnEczaneIDCekmeDeneme(eczane.ID);

            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.IlacSil(id);
            }
            lv_ilac_listeleme.DataSource = dm.BunyeIlacListele(ilaclar.EczaneID);
            lv_ilac_listeleme.DataBind();
        }
    }
}