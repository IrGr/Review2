using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Serier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["sid"] != null)
        //{
        //    int sid = 0;
        //    if (!int.TryParse(Request.QueryString["sid"], out sid))
        //    {
        //        sid = 0;
        //    }
        //    var produkter_serie = DB.DBContext._Produkts.Where(p => p.fk_serie_id.Equals(sid)).ToList();
        //    Repeater_Mobelliste.DataSource = produkter_serie;
        //    Repeater_Mobelliste.DataBind();
        //}





        // variant DDL2
        if (Request.QueryString["serieId"] != null)
        {
            int serieId = 0;
            if (!int.TryParse(Request.QueryString["serieId"], out serieId))
            {
                serieId = 0;
            }
            var produkter_serie = DB.DBContext._Produkts.Where(p => p.fk_serie_id.Equals(serieId)).ToList();
            Repeater_Mobelliste.DataSource = produkter_serie;
            Repeater_Mobelliste.DataBind();
        }

        //Literal_BreadCrumb_Serier.Text = DB.DBContext._Series.First(s => s.serie_id.Equals(Request.QueryString["sid"])).serie_navn;
        Literal_BreadCrumb_Serier.Text = DB.DBContext._Series.First(s => s.serie_id.Equals(Request.QueryString["serieId"])).serie_navn;

    }
}