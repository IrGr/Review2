using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        overskrift_nyhedsbrevbox.InnerText = ConstantClass.overskrift_nyhedsbrev;
    }
    protected void LinkButton_Tilmeld_Click(object sender, EventArgs e)
    {
        // vi tjekker om der er noget i vores TextBox
        // hvis TextBox ikke er tomt, så definerer vi en variable, hvor gemmer tekst, der står i feltet
        if (!string.IsNullOrEmpty(TextBox_Nyhedsbrevbox.Text))
        {
            string txbindhold = TextBox_Nyhedsbrevbox.Text;

            //tager alle de emails, der liger ind i DB
            var query = DB.DBContext._Nyhedsbrevs.Where(n => n.email.Equals(txbindhold)).FirstOrDefault();

            if (query != null)
            {
                ///udtrækker alle de emails, der er tilmeldt
                //var query_tilmeldt = query.tilmelding.Equals(1)).FirstOrDefault();

                // hvis query_tilmeldt er forskellig fra null,
                // skifter  vi tilmelding til 1, så brugeren bliver tilmeldt
                if (query.tilmelding==1)
                {
                    //ellers viser vi en besked, at brugeren allerede er tilmeldt 
                    Label_NyhBrevTilm.Visible = true;
                    Label_NyhBrevTilm.Text = "Du er allerede tilmeldt";
                    Label__NyhBrevFram.Visible = false;
                }
                else
                {
                    query.tilmelding = 1;
                    Label_NyhBrevTilm.Visible = true;
                    Label_NyhBrevTilm.Text = "Tak for din tilmelding";
                    Label__NyhBrevFram.Visible = false;
                    TextBox_Nyhedsbrevbox.Text = "";
                }

                try
                {
                    DB.DBContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Response.Write("Der opstod en fejl" + ex.Message);
                }

            }
            else
            {
                _Nyhedsbrev newtilmelding = new _Nyhedsbrev
                {
                    email = txbindhold,
                    tilmelding = 1
                };

                DB.DBContext._Nyhedsbrevs.InsertOnSubmit(newtilmelding);

                try
                {
                    DB.DBContext.SubmitChanges();
                    Label_NyhBrevTilm.Visible = true;
                    Label_NyhBrevTilm.Text = "Tak for din tilmelding";
                    Label__NyhBrevFram.Visible = false;

                }
                catch (Exception ex)
                {

                    Response.Write("Der opstod en fejl" + ex.Message); ;
                }
            }
        }
    }
    protected void LinkButton_Frameld_Click(object sender, EventArgs e)
    {
        // vi tjekker om der er noget i vores TextBox
        // hvis TextBox ikke er tom, så definerer vi en variable, hvor gemmer tekst, der står i feltet
        if (!string.IsNullOrEmpty(TextBox_Nyhedsbrevbox.Text))
        {
            string txbindhold = TextBox_Nyhedsbrevbox.Text;
            var query = DB.DBContext._Nyhedsbrevs.Where(n => n.email.Equals(txbindhold) && n.tilmelding.Equals(1)).FirstOrDefault();

            //Hvis query ikke er lig med null
            // så skifter vi tilmelding værdi
            //for at framelde brugeren
            if (query != null)
            {
                query.tilmelding = 0;
                try
                {
                    DB.DBContext.SubmitChanges();
                    Label_NyhBrevTilm.Visible = false;
                    Label__NyhBrevFram.Visible = true;
                    Label__NyhBrevFram.Text = "Du er frameldt";
                    TextBox_Nyhedsbrevbox.Text = "";

                }
                catch (Exception ex)
                {
                    Response.Write("Der opstod en fejl" + ex.Message);
                }
            }
            else
            {
                Label_NyhBrevTilm.Visible = false;
                Label__NyhBrevFram.Visible = true;
                Label__NyhBrevFram.Text = "Du er ikke tilmeldt endnu";
            }
        }
    }
}