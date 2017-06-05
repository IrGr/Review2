using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NyProdukt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var query = DB.TagAlleSerier();
            DB.DropDownList(query, "serie_navn", "serie_id", DropDownList_Serie);
            DropDownList_Serie.Items.Insert(0, new ListItem("Alle", String.Empty));
        }
    }
    protected void Button_NytProdukt_Click(object sender, EventArgs e)
    {
        string navn = TextBox_Navn.Text;
        string varenr = TextBox_Varenummer.Text;
        string pris = TextBox_Pris.Text;
        string designer = TextBox_Designer.Text;
        string designaar = TextBox_Designaar.Text;
        string beskrivelse = TextBox_Beskrivelse.Text;
        string l = DropDownList_Serie.SelectedItem.Text;

        if (!string.IsNullOrEmpty(navn) &&
            !string.IsNullOrEmpty(varenr) &&
            !string.IsNullOrEmpty(pris) &&
            !string.IsNullOrEmpty(designer) &&
            !string.IsNullOrEmpty(designaar) &&
            !string.IsNullOrEmpty(beskrivelse) &&
            DropDownList_Serie.SelectedIndex > 0)
        {

            /* IG
            string error = string.Empty;
            error = DB.SaveProdukt(navn
                , varenr
                , pris
                , designer
                , designaar
                , beskrivelse
                , l
                , Convert.ToInt32(DropDownList_Serie.SelectedValue)
                , FileUpload_Billede.FileName
                , FileUpload_Billede.PostedFile.InputStream
                , Server.MapPath("~/Images/"));

            if (string.IsNullOrEmpty(error))
            {
                Response.Redirect("~/Admin/MoblerAdmin.aspx");
            }
            else
            {
                Response.Write(error);
            }
            */

            _Billede nytbillede = null;
            if (FileUpload_Billede.HasFile == true)
            {
                string filenavn_lille;
                string filenavn_stor;

                string stor = "stor";
                string lille = "lille";

                string FolderDestination = "undefined";
                // Alle billeder ligger i forskelige mapper
                // en kategori har sin egen mappe
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


                string datetimestamp = DateTime.Now.ToFileTime().ToString();
                filenavn_lille = lille + datetimestamp + FileUpload_Billede.FileName;
                filenavn_stor = stor + datetimestamp + FileUpload_Billede.FileName;

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

                    //}test
                    //}test
                    //opretter et produkt
                    _Produkt nytprodukt = new _Produkt
                    {
                        navn = navn,
                        varenr = Convert.ToInt32(varenr),
                        pris = Convert.ToInt32(pris),
                        designer = designer,
                        design_aar = Convert.ToInt32(designaar),
                        beskrivelse = beskrivelse,
                        fk_serie_id = Convert.ToInt32(DropDownList_Serie.SelectedValue),
                        //fk_primert_billede_id=nytbillede.billlede_id
                        _Billede = nytbillede//.billlede_id == null ? 0 : nytbillede.billlede_id

                    };
                    DB.DBContext._Produkts.InsertOnSubmit(nytprodukt);
                    try
                    {
                        DB.DBContext.SubmitChanges();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("Der opstod en fejl:" + ex.Message);
                    }

                    //gemmer billede og produkt id i mellemtabel
                    if (nytbillede != null)
                    {
                        _Produkt_Billede produkt_billede = new _Produkt_Billede
                        {
                            _Produkt = nytprodukt,
                            _Billede = nytbillede

                        };
                        DB.DBContext._Produkt_Billedes.InsertOnSubmit(produkt_billede);
                        try
                        {
                            DB.DBContext.SubmitChanges();
                            Response.Redirect("~/Admin/MoblerAdmin.aspx");
                        }
                        catch (Exception ex)
                        {

                            Response.Write("Der opstod en fejl:" + ex.Message);
                        }
                    }
                }

            }
            //else
            //{
            //    Label_FejlUpload.Visible = true;
            //}
        }
             
        //else
        //{
        //    Label_FejlUpload.Visible = true;
        //    Label_FejlUpload.Text = "Giv alle oplysninger til produktet";
        //}

    }
}