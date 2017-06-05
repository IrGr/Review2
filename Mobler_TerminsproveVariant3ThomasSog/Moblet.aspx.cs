using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Moblet : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Hvis QuerySrting er forskellige fra null
        //definerer vi en ny variable, som er lig med 0
        //bagefter tjekker om  QuerySrting er det en tal
        //hvis Ja, så gemmer vi den i variablen, som vi lige har oprettet
        // hvis den ikke er en tal, så sætter vi variablens værdi til 0
        if (Request.QueryString["id"] != null)
        {
            int current_id = 0;
            if (!int.TryParse(Request.QueryString["id"], out current_id))
            {
                current_id = 0;
            }

            
        //Udtrækker et produkt, der har id, som er lig med den id, som vi har i url
            var etmobel = db._Produkts.Where(n => n.id.Equals(current_id)).FirstOrDefault();

            List<_Billede> billeder = new List<_Billede>();

            billeder = db._Billedes.Where(b => (db._Produkt_Billedes.Where(
                        pb => pb.fk_produkt_id == etmobel.id && pb.fk_billede_id == b.billlede_id
                        ).FirstOrDefault() != null)).ToList();

            FuldProdukt fuldprodukt = new FuldProdukt(etmobel,billeder);
            List<FuldProdukt> fuldproduktlist = new List<FuldProdukt>();
            fuldproduktlist.Add(fuldprodukt);

            Repeater_EtMobel.DataSource = fuldproduktlist;
            Repeater_EtMobel.DataBind();
            Repeater_SideNavn.DataSource = fuldproduktlist;
            Repeater_SideNavn.DataBind();



            if (etmobel.id > 0)
            {
                LiteralPageTitle.Text = etmobel.navn + " : CMK Møbler";
            }



            /*breadcrumb*/
            HyperLink_BreadCrumb_Serie.NavigateUrl = "~/Series.aspx?sid=" + fuldprodukt._Serie.serie_id;
            HyperLink_BreadCrumb_Serie.Text = fuldprodukt._Serie.serie_navn;
            Literal_BreadCrumb_MobelTitle.Text = fuldprodukt.navn;

            this.Title = "CMK Møbler:" + fuldprodukt.navn;

        }
    }
}