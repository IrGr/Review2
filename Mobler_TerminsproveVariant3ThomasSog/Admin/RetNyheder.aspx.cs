using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RetNyheder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {


                var nyheden = DB.TagEnNyhedMedId(id);    //  var nyheden = db._Nyheds.Where(n => n.nyhed_id.Equals(id)).FirstOrDefault();

                if (nyheden != null)
                {
                    TextBox_Overskrift.Text = nyheden.overskrift;
                    TextBox_Tekst.Text = nyheden.tekst;
                    TextBox_Forfatter.Text = nyheden._Forfatter.forfatter_name;

                }
                else
                {
                    Label_Fejl.Visible = true;
                    Label_Fejl.Text = "Der opstå en fejl. Prøv igen senere";
                    //Response.Write("Der opstå en fejl. Prøv igen senere");
                }
            }
            else
            {
                Label_Fejl.Visible = true;
                Label_Fejl.Text = "Der opstå en fejl. Prøv igen senere";
                //Response.Write("Der opstå en fejl. Prøv igen senere");
            }

        }
    }

    protected void Button_GemNyhed_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox_Overskrift.Text) &&
           !string.IsNullOrEmpty(TextBox_Tekst.Text) &&
           !string.IsNullOrEmpty(TextBox_Forfatter.Text))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //Vores query indeholder værdier fra vores valgte kolonne
            var query = DB.DBContext._Nyheds.Where(n => n.nyhed_id == id).FirstOrDefault();

            //Gem de nye værdier
            query.overskrift = TextBox_Overskrift.Text;
            query.tekst = TextBox_Tekst.Text;
            query.dato = DateTime.Now;
            query._Forfatter.forfatter_name = TextBox_Forfatter.Text;


            // Prøver at gemme de nye værdier, og inlæsser siden igen 

            try
            {
                DB.DBContext.SubmitChanges();
                Response.Redirect("~/Admin/NyhederAdmin.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Der opstod en fejl:" + ex.Message);
            }
        }
    }

}