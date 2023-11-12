using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class BunyeIlacDuzenleme : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            pnl_guncelleme_basarili_bilgi.Visible = false;
            pnl_guncelleme_basarisiz_bilgi.Visible = false;

            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["IlacID"]);
                    Ilaclar i = dm.IlacBilgileriniGetir(id);
                    txt_box_ilac_isim_duzenleme.Text = i.Isim;
                    txt_box_ilac_marka_duzenleme.Text = i.Marka;
                    txt_box_ilac_kategori_duzenleme.Text = i.Kategori;
                    txt_box_ilac_acikalam_duzenleme.Text = i.Aciklama;
                }
            }
            else
            {
                Response.Redirect("UyeBilgileri.aspx");
            }
        }

        protected void link_btn_ilac_duzeneleme_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["IlacID"]);
            Ilaclar i = new Ilaclar();
            i.ID = id;
            i.Isim = txt_box_ilac_isim_duzenleme.Text;
            i.Marka = txt_box_ilac_marka_duzenleme.Text;
            i.Kategori = txt_box_ilac_kategori_duzenleme.Text;
            i.Aciklama = txt_box_ilac_acikalam_duzenleme.Text;
            if (dm.IlacBilgileriniGuncelle(i))
            {
                pnl_guncelleme_basarili_bilgi.Visible = true;
            }
            else
            {
                pnl_guncelleme_basarili_bilgi.Visible = false;
                pnl_guncelleme_basarisiz_bilgi.Visible = false;
            }
        }
    }
}