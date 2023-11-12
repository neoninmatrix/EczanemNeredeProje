using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class IlacBilgisiDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
               
                int id = Convert.ToInt32(Request.QueryString["ilacbilgiID"]);
                Ilaclar ilac = dm.IlacBilgiDetay(id);
                lbl_ilac_isim.Text = ilac.Isim;
                lbl_ilac_kategori.Text = ilac.Kategori;
                lbl_ilac_marka.Text = ilac.Marka;
                lbl_ilac_aciklama.Text = ilac.Aciklama;

                //int eczaneID = ilac.EczaneID;
                //Eczaneler eczaneler = new Eczaneler();

                Eczaneler eczanebilgi = dm.EczaneIDCekmeDeneme(id);
                lbl_eczane_isim.Text = eczanebilgi.Isim;
                lbl_eczane_konum.Text = eczanebilgi.Konum;

            }
            else
            {
                Response.Redirect("ilacarama.aspx");
            }
        }

        protected void link_btn_eczane_konum_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.google.com/maps/place/" + lbl_eczane_konum.Text);
        }
    }
}