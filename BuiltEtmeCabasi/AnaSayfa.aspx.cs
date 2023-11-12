using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_makaleler_kisa.DataSource = dm.MakaleListeleme();
            rp_makaleler_kisa.DataBind();
        }
    }
}