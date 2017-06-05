using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC_Møbler : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        overskrift_moblerbox.InnerText = ConstantClass.overskrift_mobler;


        //Vælger et tilfældigt(random) produkt på listen
        Repeater_RandomProdukt.DataSource = DB.TagEtRandomProdukt();
        Repeater_RandomProdukt.DataBind();
        
    }
}