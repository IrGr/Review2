using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Kontaktoplysninger : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_Kontaktoplysninger.DataSource = DB.TagKontaktoplysninger();
        Repeater_Kontaktoplysninger.DataBind();

        Repeater_Aabningstid.DataSource = DB.TagAabningstider();
        Repeater_Aabningstid.DataBind();
    }
}