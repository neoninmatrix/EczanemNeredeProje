using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class Kullanicimaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yon"] != null)
            {
                Kullanici k = (Kullanici)Session["yon"];
                lbl_kullanici.Text = "'" + k.KullaniciAdi + "'";
            }
            else
            {
                Response.Redirect("EczanemGiris.aspx");
            }
        }

        protected void lnkbutton_cikis_Click(object sender, EventArgs e)
        {
            Session["yon"] = null;
            Response.Redirect("EczanemGiris.aspx");
        }
    }
}