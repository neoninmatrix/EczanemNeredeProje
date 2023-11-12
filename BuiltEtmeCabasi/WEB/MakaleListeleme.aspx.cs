using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuiltEtmeCabasi.WEB
{
    public partial class MakaleListeleme : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makale_listeleme.DataSource = dm.MakaleListeleme();
            lv_makale_listeleme.DataBind();
        }

        protected void lv_makale_listeleme_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Sil")
            {
                dm.MakaleSil(id);
            }
            lv_makale_listeleme.DataSource = dm.MakaleListeleme();
            lv_makale_listeleme.DataBind();
        }

    }
}