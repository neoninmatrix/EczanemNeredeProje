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
    public partial class MakaleDuzenleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_makale_duzenleme_basarili.Visible = false;
            pnl_makale_duzenleme_basarisiz.Visible = false;

            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_makale_kategori_seciniz.DataSource = dm.KategoriListeleme();
                    ddl_makale_kategori_seciniz.DataBind();

                    int id = Convert.ToInt32(Request.QueryString["mid"]);
                    Makale mak = dm.MakaleGetir(id);
                    ddl_makale_kategori_seciniz.SelectedValue = Convert.ToString(mak.Kategori_ID);
                    txtbox_makale_baslik.Text = mak.Baslik;
                    txtbox_makale_ozet.Text = mak.Ozet;
                    txtbox_makale_makale_ekleme_icerik.Text = mak.Icerik;
                    cbox_makale_yayinla.Checked = mak.Aktif;
                    img_resim.ImageUrl = "../MakaleResimler/" + mak.KapakResmi;
                }
            }
            else
            {
                Response.Redirect("MakaleListeleme.aspx");
            }
        }

        DataModel dm = new DataModel();
        protected void lnkbutton_makale_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Makale mak = dm.MakaleGetir(id);
            mak.Baslik = txtbox_makale_baslik.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_makale_kategori_seciniz.SelectedItem.Value);
            mak.Ozet = txtbox_makale_ozet.Text;
            mak.Icerik = txtbox_makale_makale_ekleme_icerik.Text;
            mak.Aktif = cbox_makale_yayinla.Checked;
            mak.GuncellemeTarih = DateTime.Now;
            bool UygunUzanti = true;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                {
                    string dosyaAdi = Guid.NewGuid().ToString();
                    string uzanti = fi.Extension; // .jpg, .png
                    fu_resim.SaveAs(Server.MapPath("../MakaleResimler/" + dosyaAdi + uzanti));
                    mak.KapakResmi = dosyaAdi + uzanti;
                }
                else
                {
                    UygunUzanti = false;
                }
            }

            if (UygunUzanti)
            {
                if (dm.MakaleGuncelle(mak))
                {
                    pnl_makale_duzenleme_basarili.Visible = true;
                    pnl_makale_duzenleme_basarisiz.Visible = false;
                }
                else
                {
                    pnl_makale_duzenleme_basarisiz.Visible = true;
                    pnl_makale_duzenleme_basarili.Visible = false;
                    lbl_makale_duzenleme_basarisiz.Text = "Makale güncellenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_makale_duzenleme_basarisiz.Visible = true;
                pnl_makale_duzenleme_basarili.Visible = false;
                lbl_makale_duzenleme_basarisiz.Text = "Resim uzantısı jpg, png, veya gif formatında olabilir";
            }
        }

        protected void lnkbutton_makale_duzenleme_basarili_kapatma_Click(object sender, EventArgs e)
        {
            pnl_makale_duzenleme_basarili.Visible = false;
        }

        protected void lnkbutton_makale_duzenleme_basarisiz_kapatma_Click(object sender, EventArgs e)
        {
            pnl_makale_duzenleme_basarisiz.Visible = false;
        }
    }
}