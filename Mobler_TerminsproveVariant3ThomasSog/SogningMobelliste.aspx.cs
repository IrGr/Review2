using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SogningMobelliste : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_SideNavn.Text = "Møbelliste";
        //ig
        //if (Request.QueryString.Count == 1)
        //{
        //    Repeater_Mobelliste.DataSource = DB.TagAlleProdukter();
        //    Repeater_Mobelliste.DataBind();
        //}
        //else//ig
        //{

            List<_Produkt> result = new List<_Produkt>();
            result = DB.TagAlleProdukter();


            if (Request.QueryString.Count > 1)
            {
                List<int> serierne = new List<int>();
                if (!string.IsNullOrEmpty(Request.QueryString["serier"]))
                {
                    string serier = Request.QueryString["serier"];
                    foreach (string serie in serier.Split(','))
                    {
                        serierne.Add(Convert.ToInt32(serie));

                    }

                }

                 int minaar=0;
                 int maxaar=0;
                 int minpris=0;
                 int maxpris=0;

                if (!string.IsNullOrEmpty(Request.QueryString["minaar"]))
                {
                 
                    //string minaar = Request.QueryString["minaar"];
                    int.TryParse(Request.QueryString["minaar"],out minaar);
                    //minaar = int.MinValue.ToString();
                    
                }
               //string maxaar = Request.QueryString["maxaar"];

                if (!string.IsNullOrEmpty(Request.QueryString["maxaar"]))
                {
                    //maxaar = int.MaxValue.ToString();
                    int.TryParse(Request.QueryString["maxaar"], out maxaar);
                }

                //string minpris = Request.QueryString["minpris"];
                if (!string.IsNullOrEmpty(Request.QueryString["minpris"]))
                {
                    //minpris = int.MinValue.ToString();
                    int.TryParse(Request.QueryString["minpris"], out minpris);
                }

                //string maxpris = Request.QueryString["maxpris"];
                if (!string.IsNullOrEmpty(Request.QueryString["maxpris"]))
                {
                    //maxpris = int.MaxValue.ToString();
                    int.TryParse(Request.QueryString["maxpris"], out maxpris);
                }

               // string designer = Request.QueryString["designer"] ?? "";// tjekker om værdien er forskellig med null; hvis QS == null, så returnerer den ""
                string designer = Request.QueryString["designer"];
                /*
                //it's work
                result.AddRange(db._Produkts.Where(p =>
                    (p.pris >= Convert.ToInt32(minpris) && p.pris <= Convert.ToInt32(maxpris))//pris
                    && (p.design_aar >= Convert.ToInt32(minaar) && p.design_aar <= Convert.ToInt32(maxaar))//år
                    && (p.designer == designer || string.IsNullOrEmpty(designer))//designer
                    && (serierne.Count == 0 || serierne.Contains(p.fk_serie_id))
                    ).ToList());
                Repeater_Mobelliste.DataSource = result;
                Repeater_Mobelliste.DataBind();
                //it's work finish
                */


                SearchHandler search = new SearchHandler(result);
                result = search.GetSearchResult(minaar,maxaar,minpris,maxpris,serierne,designer);

            }
            Repeater_Mobelliste.DataSource = result;
            Repeater_Mobelliste.DataBind();

        //}ig
    }
}