using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Nyhedsarkiv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // viser alle nyheder, der sorteres efter dato
        // den nyeste øvest
        Repeater_Nyheder.DataSource = DB.TagAlleNyheder();
        Repeater_Nyheder.DataBind();
    }
}