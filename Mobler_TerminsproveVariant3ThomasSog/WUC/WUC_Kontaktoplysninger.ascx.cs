using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_Kontaktoplysninger : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        overskrift_kontaktoplysningerbox.InnerText = ConstantClass.overskrift_kontaktoplysninger;


        // udtrække kontaktoplysninger ud fra DB
        var kontaktoplysninger = db._Kontaktoplysningers.ToList();
        Repeater_Kontaktoplysninger.DataSource = kontaktoplysninger;
        Repeater_Kontaktoplysninger.DataBind();
    }
}