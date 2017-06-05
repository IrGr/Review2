using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_ForsFilm.DataSource = DB.DBContext._Produkts.OrderByDescending(p=>p.id).Take(1);
        Repeater_ForsFilm.DataBind();

        Repeater_NyhedTab.DataSource = DB.TagFemSenesteNyheder();
        Repeater_NyhedTab.DataBind();
    }
}