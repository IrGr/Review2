using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Kontakt : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        overskrift_aabningstider.InnerText = ConstantClass.overskrift_aabningstider;

        // henter åbningstider ud fra DB
        
        Repeater_Aabningstider.DataSource = DB.TagAabningstider();
        Repeater_Aabningstider.DataBind();




    }
    /// <summary>
    /// Når brugeren klikker på Send knap i kontaktformular - skal der sendes en besked til admin email
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Send_Click(object sender, EventArgs e)
    {
        //string fra = "afsender@xxx.xx";
        //string til = "modtager@xxx.xx";
        //string subjekt = "Hej!";
        //string besked_indhold = TextBox_Kommentar.Text.ToString();

        //MailMessage mailobj = new MailMessage(fra,til,subjekt,besked_indhold);
        //mailobj.IsBodyHtml=true;

        ////SmtpClient benytte de oplysninger, som står i Web.config filens mailSettings
        //// i virkliheden skal der bruges de mail-settings, som matche
        //SmtpClient SMTPServer= new SmtpClient();
        //SMTPServer.Send(mailobj);
        Panel_KontaktFormular.Visible = false;
        Panel_TakBesked.Visible = true;
    }
}