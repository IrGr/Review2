using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetProdukt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                var produkt = DB.TagEtProduktMedId(id);
                if (produkt != null)
                {
                    //opfylder TextBoxer
                    TextBox_Navn.Text = produkt.navn;
                    TextBox_Varenummer.Text = produkt.varenr.ToString();
                    TextBox_Pris.Text = produkt.pris.ToString();
                    TextBox_Designer.Text = produkt.designer;
                    TextBox_Designaar.Text = produkt.design_aar.ToString();
                    TextBox_Beskrivelse.Text = produkt.beskrivelse;

                    //udtrækker alle serier og udskriver dem i DDL
                    var serier = DB.TagAlleSerier();
                    DB.DropDownList(serier, "serie_navn", "serie_id", DropDownList_Serie);
                    DropDownList_Serie.SelectedValue = Convert.ToString(produkt.fk_serie_id);

                    //Opfylder DDL, hvor vi kan vælge et primært billede
                    //tager alle billeder, der svarer til det produkt
                    var billeder = DB.DBContext._Billedes.Where(b => (DB.DBContext._Produkt_Billedes.Where(
                        pb => pb.fk_produkt_id == produkt.id && pb.fk_billede_id == b.billlede_id
                        ).FirstOrDefault() != null)).ToList();
                    //test
                    if (billeder.Count!=0)
                    {
                        DB.DropDownList(billeder, "billede_navn", "billlede_id", DropDownList_PrimBillede);
                        DropDownList_PrimBillede.SelectedValue = Convert.ToString(produkt.fk_primert_billede_id);

                        //hvis der er valgt et billede i DDL_PrimBilleder,
                        // så viser vi det 
                        if (Convert.ToInt32(DropDownList_PrimBillede.SelectedValue) > 0)
                        {
                            Image_PrimertBillede.ImageUrl = "../Images/" + produkt._Serie.serie_navn + "/" + produkt._Billede.billede_sti_120_90;
                        }
                    }
                    else
                    {
                        DropDownList_PrimBillede.Visible = false;
                        Label_PrimBillede.Visible = false;
                        Image_PrimertBillede.Visible = false;
                    }

                }

                //opfylder billeder checkboxlist
                /*TEST checkboxWithImg*/
                var produktBilleder = (from b in DB.DBContext._Billedes
                                       join pb in DB.DBContext._Produkt_Billedes on b.billlede_id equals pb.fk_billede_id
                                       join p in DB.DBContext._Produkts on pb.fk_produkt_id equals p.id
                                       where pb.fk_produkt_id == id && b.billlede_id != p._Billede.billlede_id
                                       select b).ToList();


                DB.CheckBoxList(produktBilleder, "billede_sti_120_90", "billlede_id", CheckBoxList_ProduktBilleder);
                if (produktBilleder.Count == 0)
                {
                    Button_SletBilleder.Visible = false;
                }
                /*TEST checkboxWithImg*/
            }
        }
    }

    /// <summary>
    /// Gemmmer Produkt efter redigering
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_GemProdukt_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["id"]);
        string navn = TextBox_Navn.Text;
        string varenr = TextBox_Varenummer.Text;
        string pris = TextBox_Pris.Text;
        string designer = TextBox_Designer.Text;
        string designaar = TextBox_Designaar.Text;
        string beskrivelse = TextBox_Beskrivelse.Text;
        var produktet = DB.TagEtProduktMedId(id);

        if (string.IsNullOrEmpty(navn) ||
            string.IsNullOrEmpty(varenr) ||
            string.IsNullOrEmpty(pris) ||
            string.IsNullOrEmpty(designer) ||
            string.IsNullOrEmpty(designaar) ||
            string.IsNullOrEmpty(beskrivelse) ||
            produktet == null)
        {
            return;
        }

        _Billede nytbillede = null;
        if (FileUpload_Billede.HasFile == true)
        {
            string filenavn_lille;
            string filenavn_stor;

            string stor = "stor";
            string lille = "lille";

            string FolderDestination = "undefined";
            // Alle billeder ligger i forskelige mapper
            // en serie har sin egen mappe
            switch (DropDownList_Serie.SelectedItem.Text)
            {
                case "Sofa": FolderDestination = "sofa";
                    break;
                case "Sofabord": FolderDestination = "sofabord";
                    break;
                case "Spisebord": FolderDestination = "spisebord";
                    break;
                case "Spisestol": FolderDestination = "spisestol";
                    break;
            }

            //1.Der skal være mulighed for at uploade 2 billeder med samme navn

            //Erklærer en variabel, som vi skal tilføjer til billedenavn, for at hvert billede får unikt navn 
            string datetimestamp = DateTime.Now.ToFileTime().ToString();

            // 2.endvidere skal et billede gemmes i 2 forskellige størrelser
            //vi markerer små og store billeder, så det er mere overskuelig, hvor og hvilket billede er
            filenavn_lille = lille + datetimestamp + FileUpload_Billede.FileName;
            filenavn_stor = stor + datetimestamp + FileUpload_Billede.FileName;

            //3.Tjekker om der er billedet med dette navn i vores mappe
            //hvis nej - skalerer vi billeder og gemmer det i mappen og i DB
            if (!File.Exists(Server.MapPath("~/Images/" + FolderDestination + "/" + filenavn_lille)))
            {
                System.Drawing.Image srcImage = System.Drawing.Image.FromStream(FileUpload_Billede.PostedFile.InputStream);


                //lille billede
                Bitmap lillebillede = Helper.ResizeImage(srcImage, 90, 120);
                lillebillede.Save(Server.MapPath("~/Images/" + FolderDestination + "/" + filenavn_lille));

                // stort billede
                Bitmap stortbillede = Helper.ResizeImage(srcImage, 225, 300);
                stortbillede.Save(Server.MapPath("~/Images/" + FolderDestination + "/" + filenavn_stor));



                nytbillede = new _Billede
                {
                    billede_navn = FileUpload_Billede.FileName,
                    billede_sti_120_90 = filenavn_lille,
                    billede_sti_300_225 = filenavn_stor
                };

                DB.DBContext._Billedes.InsertOnSubmit(nytbillede);
                try
                {
                    DB.DBContext.SubmitChanges();
                }
                catch (Exception ex)
                {

                    Response.Write("Der opstod en fejl:" + ex.Message);
                }


                //4. Gemmer id af nyt billede i mellemtabel
                _Produkt_Billede pb = new _Produkt_Billede
                {
                    _Produkt = produktet,
                    _Billede = nytbillede
                };

                DB.DBContext._Produkt_Billedes.InsertOnSubmit(pb);
                try
                {
                    DB.DBContext.SubmitChanges();


                }
                catch (Exception ex)
                {

                    Response.Write("Der opstod en fejl:" + ex.Message);
                }
            }
        }

        string serie = produktet._Serie.serie_navn;//test  gemmer produkt serie i en variabel før den bliver ændret, det skal vi bruger lidt senere


        //4.Gemmer produkt
        produktet.navn = navn;
        produktet.varenr = Convert.ToInt32(varenr);
        produktet.pris = Convert.ToInt32(pris);
        produktet.design_aar = Convert.ToInt32(designaar);
        produktet.designer = designer;
        produktet.beskrivelse = beskrivelse;
        produktet._Serie = DB.DBContext._Series.Where(s => s.serie_id.Equals(Convert.ToInt32(DropDownList_Serie.SelectedValue))).FirstOrDefault();

        if (nytbillede == null)
        {
            nytbillede = DB.DBContext._Billedes.Where(b => b.billlede_id.Equals(Convert.ToInt32(DropDownList_PrimBillede.SelectedValue))).FirstOrDefault();
        }

        produktet._Billede = nytbillede;

        try
        {
            DB.DBContext.SubmitChanges();
            //Response.Redirect("~/Admin/MoblerAdmin.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("Der opstod en fejl:" + ex.Message);
        }

        //Når vi ændre serien, flytter billeder fra den gamle series mappe til den nye 
        if (!serie.Equals(produktet._Serie))
        {
            List<_Billede> billeder = new List<_Billede>();

            billeder = DB.DBContext._Billedes.Where(b => (DB.DBContext._Produkt_Billedes.Where(
                        pb => pb.fk_produkt_id == produktet.id && pb.fk_billede_id == b.billlede_id
                        ).FirstOrDefault() != null)).ToList();
            if (billeder.Count > 0)
            {

                foreach (_Billede item in billeder)
                {
                    if (File.Exists(Server.MapPath("../Images/" + serie + "/" + item.billede_sti_120_90)))
                    {
                        string sourceFile = Server.MapPath("../Images/" + serie + "/" + item.billede_sti_120_90);
                        string destinationFile = Server.MapPath("../Images/" + produktet._Serie.serie_navn + "/" + item.billede_sti_120_90);
                        System.IO.File.Move(sourceFile, destinationFile);
                    }
                    if (File.Exists(Server.MapPath("../Images/" + serie + "/" + item.billede_sti_300_225)))
                    {
                        string sourceFile = Server.MapPath("../Images/" + serie + "/" + item.billede_sti_300_225);
                        string destinationFile = Server.MapPath("../Images/" + produktet._Serie.serie_navn + "/" + item.billede_sti_300_225);
                        System.IO.File.Move(sourceFile, destinationFile);
                    }
                }

            }

        }
        Response.Redirect("~/Admin/MoblerAdmin.aspx");
    }

    /// <summary>
    /// Primært billede præsentation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList_PrimBillede_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*virker*/
        var produkt = DB.DBContext._Produkts.Where(p => p.id.Equals(Convert.ToInt32(Request.QueryString["id"]))).FirstOrDefault();
        var billede = DB.DBContext._Billedes.Where(b => b.billlede_id.Equals(Convert.ToInt32(DropDownList_PrimBillede.SelectedValue))).FirstOrDefault();
        //Image_PrimertBillede.ImageUrl = "../Images/" + DropDownList_Serie.SelectedItem + "/" + billede.billede_sti_120_90;
        /*virker slut*/

        Image_PrimertBillede.ImageUrl = "../Images/" + produkt._Serie.serie_navn + "/" + billede.billede_sti_120_90;


        /*Test Checkbox Update*/
        int id = Convert.ToInt32(Request.QueryString["id"]);
        var produktBilleder = (from b in DB.DBContext._Billedes
                               join pb in DB.DBContext._Produkt_Billedes on b.billlede_id equals pb.fk_billede_id
                               join p in DB.DBContext._Produkts on pb.fk_produkt_id equals p.id
                               where pb.fk_produkt_id == id && b.billlede_id != billede.billlede_id
                               select b).ToList();


        DB.CheckBoxList(produktBilleder, "billede_sti_120_90", "billlede_id", CheckBoxList_ProduktBilleder);


    }

    /// <summary>
    /// CheckBoxList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBoxList_ProduktBilleder_DataBound(object sender, EventArgs e)
    {
        //var produktet = DB.DBContext._Produkts.Where(p=>p.id.Equals(Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
        var produkt = DB.TagEtProduktMedId(Convert.ToInt32(Request.QueryString["id"]));
        foreach (ListItem item in CheckBoxList_ProduktBilleder.Items)
        {
            //CheckBoxList_ProduktBilleder.Items.Add(new ListItem(
            //    string.Format("<img src='../Images/{0}/{1}' alt='' />", produkt._Serie.serie_navn , item.Text),
            //   item.Value));



            item.Text = string.Format("<img src= \"{0}\" title='" + item.Value + "'/>",
            string.Format("../Images/{0}/{1}", produkt._Serie.serie_navn, item.Text), null);
        }
    }

    /// <summary>
    /// Slet Billeder Knap
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_SletBilleder_Click(object sender, EventArgs e)
    {
        int id = 0;
        //int id = Convert.ToInt32(Request.QueryString["id"]);
        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            //tager det produkt, der redigeres
            var produktet = DB.DBContext._Produkts.Where(p => p.id.Equals(id)).FirstOrDefault();
            //tager alle de billeder, der hører til produktet
            // og gemmer dem i en liste

            List<_Billede> billeder = DB.DBContext._Billedes.Where(b => (DB.DBContext._Produkt_Billedes.Where(
                              pb => pb.fk_produkt_id == produktet.id && pb.fk_billede_id == b.billlede_id
                              ).FirstOrDefault() != null)).ToList();


            //for hver item i chackboxlist
            //hvis den er selected
            //sletter vi det billeder fra mappen
            //sletter fk fra _Produkt_Billede og fra _Billede tabel
            foreach (ListItem item in CheckBoxList_ProduktBilleder.Items)
            {
                if (item.Selected)
                {

                    //vi skal slette både stort og lille billede

                    int billedeId = Convert.ToInt32(item.Value);
                    var billederNavn = DB.DBContext._Billedes.Where(b => b.billlede_id.Equals(billedeId)).FirstOrDefault();
                    try
                    {
                        if (billederNavn != null)
                        {
                            File.Delete(Server.MapPath("../Images/" + produktet._Serie.serie_navn + "/" + billederNavn.billede_sti_120_90));
                            File.Delete(Server.MapPath("../Images/" + produktet._Serie.serie_navn + "/" + billederNavn.billede_sti_300_225));
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Der opstod en fejl:" + ex.Message);
                    }


                    var prod_bil = DB.DBContext._Produkt_Billedes.Where(pb => pb.fk_billede_id.Equals(billedeId)).FirstOrDefault();
                    DB.DBContext._Produkt_Billedes.DeleteOnSubmit(prod_bil);

                    var billedet = DB.DBContext._Billedes.Where(b => b.billlede_id.Equals(billedeId)).FirstOrDefault();
                    DB.DBContext._Billedes.DeleteOnSubmit(billedet);


                    try
                    {
                        DB.DBContext.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Der opstod en fejl:" + ex.Message);
                    }
                }
            }//foreach
            Response.Redirect(Request.RawUrl);

        }
    }
}