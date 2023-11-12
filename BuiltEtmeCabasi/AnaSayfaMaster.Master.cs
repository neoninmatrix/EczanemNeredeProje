using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class AnaSayfaMaster : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["uye"] == null)
            {
                pnl_uye_yok.Visible = true;
                pnl_uye_var.Visible = false;
            }
            else
            {
                Uye u = Session["uye"] as Uye;
                lnk_button_uye_isim.Text = u.UyeAdi;
                pnl_uye_var.Visible = true;
                pnl_uye_yok.Visible = false;
            }
        }

        protected void lnk_button_hesap_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("AnaSayfa.aspx");
        }

        protected void lnk_button_uye_isim_Click(object sender, EventArgs e)
        {
            Response.Redirect("UyeBilgileri.aspx");
        }

        protected void lnk_button_arama_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("ilacarama.aspx?ilacadi=" + txt_box_ilac_arama.Text);
        }
    }
}