using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int ID = Convert.ToInt32(Request.QueryString["Makaleid"]);
                Makale mak = dm.MakaleGetir(ID);
                //ltrl_baslik.Text = mak.Baslik;
                //ltrl_goruntulenme_sayi.Text = mak.GoruntulemeSayi.ToString();
                //ltrl_yazar.Text = mak.Yazar;
                //ltrl_kategori.Text = mak.Kategori;
                //ltrl_makale_icerik.Text = mak.Icerik;
                //img_resim.ImageUrl = "../MakaleResimler/" + mak.KapakResmi;

                //if (Session["uye"] != null)
                //{

                //}

                lbl_makale_baslik.Text = mak.Baslik;
                lbl_goruntuleme_sayi.Text = mak.GoruntulemeSayi.ToString();
                lbl_kategori.Text = mak.Kategori;
                lbl_makale_icerik.Text = mak.Icerik;
                lbl_yazar.Text = mak.Yazar;
                img_resim.ImageUrl = "../MakaleResimler/" + mak.KapakResmi;
                

            }
            else
            {
                Response.Redirect("AnaSayfa.aspx");
            }

            //int ID = Convert.ToInt32(Request.QueryString["MakaleID="]);
            //Makale mak = dm.MakaleGetir(ID);
            //rp_makale.DataSource = dm.MakaleGetir();
            //rp_makale.DataBind();
        }
    }
}