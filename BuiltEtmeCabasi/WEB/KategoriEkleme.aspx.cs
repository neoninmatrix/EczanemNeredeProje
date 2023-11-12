using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class KategoriEkleme : System.Web.UI.Page
    {

        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_basarili.Visible = false;
            pnl_basarisiz.Visible = false;
        }

        protected void lnkbutton_eklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_kategoriAdiMetinKutu.Text))
            {
                Kategori k = new Kategori();
                k.Isim = txt_kategoriAdiMetinKutu.Text;
                k.Aciklama = txt_kategoriAciklamaMetinKutu.Text;

                if (dm.KategoriEkle(k))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "İsim boş bırakılamaz";
            }
        }
        protected void lnkbutton_kapatma1_Click(object sender, EventArgs e)
        {
            pnl_basarili.Visible = false;
        }

        protected void lnkbutton_kapatma2_Click(object sender, EventArgs e)
        {
            pnl_basarisiz.Visible=false;
        }
    }
}