using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
    private static DataClassesDataContext db = new DataClassesDataContext();

    public static DataClassesDataContext DBContext { get { return db; } }

    public DB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<_Nyhed> TagFemSenesteNyheder()
    {
        return db._Nyheds.OrderByDescending(n => n.dato).Take(5).ToList();
    }
    public static List<_Nyhed> TagAlleNyheder()
    {
        return db._Nyheds.OrderByDescending(n => n.dato).ToList();
    }
    public static List<_Produkt> TagAlleProdukter()
    {
        return db._Produkts.OrderBy(n => n.id).ToList();
    }
    public static List<_Serie> TagAlleSerier()
    {
        return db._Series.OrderBy(n => n.serie_id).ToList();
    }
    public static List<_Nyhed> TagTreSenesteNyheder()
    {
        return db._Nyheds.OrderByDescending(n => n.dato).Take(3).ToList();
    }
    public static _Nyhed TagEnNyhedMedId(int id)
    {
        return db._Nyheds.Where(n=>n.nyhed_id.Equals(id)).FirstOrDefault();
    }
    public static _Produkt TagEtProduktMedId(int id)
    {
        return db._Produkts.Where(n => n.id.Equals(id)).FirstOrDefault();
    }
    public static List<_Produkt_Billede> TagAlleBilledeEfterProduktId(int id)
    {
        return db._Produkt_Billedes.Where(pb=>pb.fk_produkt_id.Equals(id)).ToList();
    }
    public static List<_Kontaktoplysninger> TagKontaktoplysninger()
    {
        return db._Kontaktoplysningers.ToList();
    }

    public static List<_Aabningstid> TagAabningstider()
    {
        return db._Aabningstids.ToList();
    }
    public static _Bruger TagBrugeren(string brugernavn, string password)
    {
        return db._Brugers.Where(b => b.brugernavn.Equals(brugernavn) && b.password.Equals(password)).Single();
    }

    /* IG
    /// <summary>
    /// Creates new product in database
    /// </summary>
    /// <param name="navn">Produkt navn</param>
    /// <param name="varenr"></param>
    /// <param name="pris"></param>
    /// <param name="designer"></param>
    /// <param name="designaar"></param>
    /// <param name="beskrivelse"></param>
    /// <param name="l"></param>
    /// <returns>Returns empty string if product was created, otherwise return a message of error</returns>
    
    public static String SaveProdukt(string navn
        , string varenr
        , string pris
        , string designer
        , string designaar
        , string beskrivelse
        , string serie
        , int serieID
        , string billedeFileNavn
        , Stream billedeStream
        , string serverMapPathImages)
    {

        _Billede nytbillede = null;
        if (!String.IsNullOrEmpty(billedeFileNavn))
        {
            string filenavn_lille;
            string filenavn_stor;

            string stor = "stor";
            string lille = "lille";

            string FolderDestination = "undefined";
            // Alle billeder ligger i forskelige mapper
            // en kategori har sin egen mappe
            switch (serie)
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
            filenavn_lille = lille + datetimestamp + billedeFileNavn;
            filenavn_stor = stor + datetimestamp + billedeFileNavn;

            if (!File.Exists(serverMapPathImages + FolderDestination + "/" + filenavn_lille))
            {
                System.Drawing.Image srcImage = System.Drawing.Image.FromStream(billedeStream);
                //lille billede


                Bitmap lillebillede = Helper.ResizeImage(srcImage, 90, 120);
                lillebillede.Save(serverMapPathImages + FolderDestination + "/" + filenavn_lille);

                // stort billede
                Bitmap stortbillede = Helper.ResizeImage(srcImage, 225, 300);
                stortbillede.Save(serverMapPathImages + FolderDestination + "/" + filenavn_stor);


                nytbillede = new _Billede
                {
                    billede_navn = billedeFileNavn,
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

                    return "Der opstod en fejl:" + ex.Message;
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
                    fk_serie_id = serieID,
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

                    return "Der opstod en fejl:" + ex.Message;
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
                    }
                    catch (Exception ex)
                    {
                        return "Der opstod en fejl:" + ex.Message;
                    }
                }
            }
        }

        return String.Empty;
    }
    */


    /// <summary>
    ///  Vælger et random produkt på listen
    /// items er det samme som list og vi henter og laver det til et unikt id (Guid)
    /// Guid er en unique værdi,der sikrer, at når man sorterer vil sorteringeren hele tiden blive forskellig
    /// </summary>
    /// <returns></returns>
    public static List<_Produkt> TagEtRandomProdukt()
    {
        var items = db._Produkts.ToList();
        return items.OrderBy(z => Guid.NewGuid()).Take(1).ToList();
    }

    #region Opfylder CheckBox
    // <summary>
    // Generic method
    // Generic methods have type parameters. 
    // They provide a way to parameterize the types used in a method. 
    // This means you can provide only one implementation and call it with different types.
    // </summary>
    // <typeparam name="T"></typeparam>
    // <param name="query"></param>
    // <param name="DataTextField"></param>
    // <param name="DataValueField"></param>
    public static void CheckBoxList<T>(List<T> query, string DataTextField, string DataValueField, CheckBoxList chb)
    {
        //Henter data fra DB
        chb.DataSource = query;

        // Sætte værdier på Dropdown liste
        //DataText_Field - data, der skal vises i liste   

        chb.DataTextField = DataTextField;
        chb.DataValueField = DataValueField;
        chb.DataBind();
    }
    #endregion


    #region Opfylder DropDownList
    /// <summary>
    /// Generic method
    /// Generic methods have type parameters. 
    /// They provide a way to parameterize the types used in a method. 
    /// This means you can provide only one implementation and call it with different types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="DataTextField"></param>
    /// <param name="DataValueField"></param>
    public static void DropDownList<T>(List<T> query, string DataTextField, string DataValueField, DropDownList ddl)
    {
        // Henter data fra DB
        ddl.DataSource = query;

        // Sætte værdier på Dropdown liste
        //DataText_Field - data, der skal vises i liste   

        ddl.DataTextField = DataTextField;
        ddl.DataValueField = DataValueField;
        ddl.DataBind();
    }
    #endregion
}