using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetAabningstid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Hvis det ikke er PostBack 
            // definerer vi en ny variable
            // og tjekker om der er noget i vores QueryString

            // Hvis QS er forskillige fra null og der er et heltal, så gemmer vi den i varianlen
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {

                //tager abningstid , hvor id er lige mem værdien fra QS
                var tid = DB.DBContext._Aabningstids.Where(a => a.id.Equals(id)).FirstOrDefault();

                //Hvis forespørgsel returnerer noget
                //opfylder vi vores TextBoxer
                //eller viser en fejl hvis resultat af forespørgsel er lig med null
                if (tid != null)
                {
                    TextBox_Dag.Text = tid.dag;
                    TextBox_Aaben.Text = tid.aaben;
                    TextBox_Luk.Text = tid.luk;
                   
                }
                else
                {
                    Response.Write("Der opstå en fejl. Prøv igen senere");
                }
            }
            else
            {
                Response.Write("Der opstå en fejl. Prøv igen senere");
            }

        }
    }
    protected void Button_Aabningstid_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox_Dag.Text) &&
            !string.IsNullOrEmpty(TextBox_Aaben.Text) &&
            !string.IsNullOrEmpty(TextBox_Luk.Text))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //Vores query indeholder værdier fra vores valgte kolonne
            var query = DB.DBContext._Aabningstids.Where(a => a.id == id).FirstOrDefault();

            //Gem de nye værdier
            query.dag = TextBox_Dag.Text;
            query.aaben = TextBox_Aaben.Text;
            query.luk = TextBox_Luk.Text;
            


            // Prøver at gemme de nye værdier, og inlæsser siden igen 

            try
            {
                DB.DBContext.SubmitChanges();
                Response.Redirect("~/Admin/Kontaktoplysninger.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Der opstod en fejl:" + ex.Message);
            }
        }
    
    }
}