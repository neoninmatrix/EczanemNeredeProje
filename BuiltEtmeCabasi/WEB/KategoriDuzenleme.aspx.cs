using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class KategoriDuzenleme : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_duzenleme_basarili.Visible = false;
            pnl_duzenleme_basarisiz.Visible = false;

            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kid"]);
                    Kategori k = dm.KategoriGetir(id);
                    txt_kategoriDuzenlemeAdiMetinKutu.Text = k.Isim;
                    txt_kategoriDuzenlemeAciklamaMetinKutu.Text = k.Aciklama;
                }
            }
            else
            {
                /*Response.Redirect("KategoriDuzenleme.aspx");*/
            }

        }

        protected void lnkbutton_duzenleme_basarili_kapatma_Click(object sender, EventArgs e)
        {
            pnl_duzenleme_basarili.Visible = false;
        }

        protected void lnkbutton_duzenleme_basarisiz_kapatma_Click(object sender, EventArgs e)
        {
            pnl_duzenleme_basarisiz.Visible = false;
        }

        protected void lnkbutton_duzenleme_button_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kid"]);
            Kategori k = new Kategori();
            k.ID = id;
            k.Isim = txt_kategoriDuzenlemeAdiMetinKutu.Text;
            k.Aciklama = txt_kategoriDuzenlemeAciklamaMetinKutu.Text;
            if (dm.KategoriDuzenle(k))
            {
                pnl_duzenleme_basarili.Visible = true;
            }
            else
            {
                pnl_duzenleme_basarili.Visible = false;
                pnl_duzenleme_basarisiz.Visible = true;
                lbl_duzenleme_basarisiz.Text = "Güncelleme esnasında bir hata oluştu";
            }
        }
    }
}