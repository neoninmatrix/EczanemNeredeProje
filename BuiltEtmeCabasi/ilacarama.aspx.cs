using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class ilacarama : System.Web.UI.Page
    {

        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

            #region Repeater kullanıldığında kullanılacak olan 

            //rp_ilac_arama_sonuc.DataSource = dm.IlacListeleme(ilac);
            //rp_ilac_arama_sonuc.DataBind();

            #endregion


            #region Burada Sadece Bir Tane Ilac Listeleniyor. AMA LİSTELENİYOR

            //string ilaclar = Convert.ToString(Request.QueryString["ilacadi"]);
            //Ilaclar ilac = dm.IlaclarıGetir(ilaclar);

            //lbl_ilac_isim.Text = ilac.Isim;
            //lbl_ilac_marka.Text = ilac.Marka;
            //lbl_ilac_kategori.Text = ilac.Kategori;

            #endregion


            #region Doğru Sonuç Buuuu

            string ilaclar = Convert.ToString(Request.QueryString["ilacadi"]);
            Ilaclar ilac = dm.IlaclarıGetir(ilaclar);
            rp_ilac_arama_sonuc.DataSource = dm.IlacListeleme(ilaclar);
            rp_ilac_arama_sonuc.DataBind();

            #endregion

        }
    }
}