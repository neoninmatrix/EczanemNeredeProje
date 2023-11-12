using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class MakaleEkleme : System.Web.UI.Page
    {

        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_makale_ekleme_basarili.Visible = false;
            pnl_makale_ekleme_basarisiz.Visible = false;
            if (!IsPostBack)
            {
                ddl_makale_kategori_seciniz.DataSource = dm.KategoriListeleme();
                ddl_makale_kategori_seciniz.DataBind();
            }
        }


        protected void lnkbutton_makale_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbox_makale_baslik.Text))
            {
                Makale makale = new Makale();
                makale.Baslik = txtbox_makale_baslik.Text;
                makale.Kategori_ID = Convert.ToInt32(ddl_makale_kategori_seciniz.SelectedItem.Value);
                makale.Ozet = txtbox_makale_ozet.Text;
                makale.Icerik = txtbox_makale_makale_ekleme_icerik.Text;
                makale.Aktif = cbox_makale_yayinla.Checked;
                makale.EklemeTarihi = DateTime.Now;
                makale.GoruntulemeSayi = 0;
                makale.BegeniSayi = 0;
                Kullanici k = (Kullanici)Session["yon"];
                makale.Yazar_ID = k.ID;
                makale.Silinmis = false;
                bool UygunUzanti = true;
                if (fu_resim.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                    {
                        string dosyaAdi = Guid.NewGuid().ToString();
                        string uzanti = fi.Extension; // .jpg, .png
                        fu_resim.SaveAs(Server.MapPath("../MakaleResimler/" + dosyaAdi + uzanti));
                        makale.KapakResmi = dosyaAdi + uzanti;
                    }
                    else
                    {
                        UygunUzanti = false;
                    }
                }
                else
                {
                    makale.KapakResmi = "ResimYok(none).png"; 
                }

                if (UygunUzanti)
                {
                    if (dm.MakaleEkle(makale))
                    {
                        pnl_makale_ekleme_basarili.Visible = true;
                        pnl_makale_ekleme_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_makale_ekleme_basarisiz.Visible = true;
                        pnl_makale_ekleme_basarili.Visible = false;
                        lbl_makale_ekleme_basarisiz.Text = "Bir hata oluştu";
                    }
                }
                else
                {
                    pnl_makale_ekleme_basarisiz.Visible = true;
                    pnl_makale_ekleme_basarili.Visible = false;
                    lbl_makale_ekleme_basarisiz.Text = "Resim uzantısı .jpg, .png veya .gif formatında olamaz";
                }
            }
            else
            {
                pnl_makale_ekleme_basarili.Visible = false;
                pnl_makale_ekleme_basarisiz.Visible = true;
                lbl_makale_ekleme_basarisiz.Text = "Makale başlığı boş bırakılamaz";
            }
        }

        protected void lnkbutton_makale_ekleme_basarili_kapatma1_Click(object sender, EventArgs e)
        {
            pnl_makale_ekleme_basarili.Visible = false;
           
        }

        protected void lnkbutton_makale_ekleme_basarisiz_kapatma2_Click(object sender, EventArgs e)
        {
            pnl_makale_ekleme_basarisiz.Visible = false;
        }
    }
}