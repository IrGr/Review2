using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Mobler : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //opfylder checkboxe
            var serier = db._Series.ToList();
            DB.CheckBoxList(serier, "serie_navn", "serie_id", CheckBoxList_Serie);

            //opfylder dropdownlist
            var designere = db._Produkts.Where(p => p.designer != "").Select(p => p.designer).Distinct().ToList();

            DropDownList_Designer.DataSource = designere;
            DropDownList_Designer.DataBind();
            DropDownList_Designer.Items.Insert(0, new ListItem("Alle", ""));


        }

        List<_Produkt> result = new List<_Produkt>();
        if (!IsPostBack && (Request.QueryString["minpris"] != null
            || Request.QueryString["maxpris"] != null
            || Request.QueryString["serie"] != null
            || Request.QueryString["minaar"] != null
            || Request.QueryString["maxaar"] != null
            ))
        {
            Panel_VarenrSog.Visible = false;
            PlaceHolder_AvansSog.Visible = false;

            List<int> serierne = new List<int>();
            if (!string.IsNullOrEmpty(Request.QueryString["serie"]))
            {
                string serier = Request.QueryString["serie"];
                foreach (string serie in serier.Split(','))
                {
                    serierne.Add(Convert.ToInt32(serie));

                }

            }

            string minaar = Request.QueryString["minaar"];
            if (string.IsNullOrEmpty(Request.QueryString["minaar"]))
            {
                minaar = int.MinValue.ToString();
            }
            string maxaar = Request.QueryString["maxaar"];

            if (string.IsNullOrEmpty(Request.QueryString["maxaar"]))
            {
                maxaar = int.MaxValue.ToString();
            }

            string minpris = Request.QueryString["minpris"];
            if (string.IsNullOrEmpty(Request.QueryString["minpris"]))
            {
                minpris = int.MinValue.ToString();
            }

            string maxpris = Request.QueryString["maxpris"];
            if (string.IsNullOrEmpty(Request.QueryString["maxpris"]))
            {
                maxpris = int.MaxValue.ToString();
            }

            string designer = Request.QueryString["designer"] ?? "";// tjekker om værdien er forskellig med null; hvis QS == null, så returnerer den ""


            result.AddRange(db._Produkts.Where(p =>
                (p.pris >= Convert.ToInt32(minpris) && p.pris <= Convert.ToInt32(maxpris))//pris
                && (p.design_aar >= Convert.ToInt32(minaar) && p.design_aar <= Convert.ToInt32(maxaar))//år
                && (p.designer == designer || string.IsNullOrEmpty(designer))//designer
                && (serierne.Count == 0 || serierne.Contains(p.fk_serie_id))
                ).ToList());


        }
        else
        {
            Panel_VarenrSog.Visible = true;
            PlaceHolder_AvansSog.Visible = true;
        }

        Panel_SogBesked.Visible = false;
        PlaceHolder_SogningResultat.Visible = true;
        Repeater_Mobelliste.DataSource = result;
        Repeater_Mobelliste.DataBind();
    }


    protected void Button_SogVarenr_Click(object sender, EventArgs e)
    {
        string varenr = TextBox_Varenr.Text;

        //tjekker om txb er tomt
        // hvis den ikke er tomt - tager vi den vare, som har samme varenummer og viser alt om den
        if (!string.IsNullOrEmpty(varenr))
        {
            var result = db._Produkts.Where(p => p.varenr.Equals(varenr)).FirstOrDefault();
            if (result != null)
            {
                Response.Redirect("Moblet.aspx?id=" + result.id);
            }
            else
            {
                Panel_SogBesked.Visible = true;
            }
        }

    }
    /*
        /// <summary>
        /// Den gamle event Søg knap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_SogKnap_Click(object sender, EventArgs e)
        {
            bool isAnySelected = CheckBoxList_Serie.SelectedIndex == -1; //If nothing is checked, the SelectedIndex is -1.
            string maxpris = TextBox_MaxPris.Text;
            string minpris = TextBox_MinPris.Text;
            string maxaar = TextBox_MaxDesignAar.Text;
            string minaar = TextBox_MinDesignAar.Text;

            if (string.IsNullOrEmpty(maxpris) &&
                string.IsNullOrEmpty(minpris) &&
                string.IsNullOrEmpty(maxaar) &&
                string.IsNullOrEmpty(minaar) &&
                DropDownList_Designer.SelectedValue == "0" &&
                isAnySelected)
            {
                Panel_SogBesked.Visible = false;
                Panel_VarenrSog.Visible = false;
                PlaceHolder_AvansSog.Visible = false;
                PlaceHolder_SogningResultat.Visible = true;
                Repeater_Mobelliste.DataSource = DB.TagAlleProdukter();
                Repeater_Mobelliste.DataBind();
                Label_SideNavn.Text = "Møbelliste";
            }
            else
            {



                List<_Produkt> result = null;

                #region CheckBoxList
                foreach (ListItem item in CheckBoxList_Serie.Items)
                {
                    if (item.Selected)
                    {
                        if (result == null)
                        {
                            result = db._Produkts.Where(p => p._Serie.serie_id.Equals(Convert.ToInt32(item.Value))).ToList();
                        }

                        else
                        {
                            result.AddRange(db._Produkts.Where(p => p._Serie.serie_id.Equals(Convert.ToInt32(item.Value))).ToList());
                        }
                    }
                }
                #endregion

                #region Designer
                if (DropDownList_Designer.SelectedValue != "0")
                {
                    if (result == null)
                    {
                        result = db._Produkts.Where(p => p.designer.Contains(DropDownList_Designer.SelectedValue)).ToList();
                    }
                    else
                    {
                        result = result.Where(p => p.designer.Contains(DropDownList_Designer.SelectedValue)).ToList();
                    }
                }
                #endregion

                #region MinDesignÅr
                if (!string.IsNullOrEmpty(TextBox_MinDesignAar.Text))
                {
                    if (Convert.ToInt32(TextBox_MinDesignAar.Text) > 0)
                    {
                        if (result == null)
                        {
                            result = db._Produkts.Where(p => p.design_aar >= Convert.ToInt32(TextBox_MinDesignAar.Text)).ToList();
                        }
                        else
                        {
                            result = result.Where(p => p.design_aar >= Convert.ToInt32(TextBox_MinDesignAar.Text)).ToList();
                        }
                    }
                }
                else
                {

                }
                #endregion

                #region MaxDesignÅr
                if (!string.IsNullOrEmpty(TextBox_MaxDesignAar.Text))
                {
                    if (Convert.ToInt32(TextBox_MaxDesignAar.Text) > 0)
                    {
                        if (result == null)
                        {
                            result = db._Produkts.Where(p => p.design_aar <= Convert.ToInt32(TextBox_MaxDesignAar.Text)).ToList();
                        }
                        else
                        {
                            result = result.Where(p => p.design_aar <= Convert.ToInt32(TextBox_MaxDesignAar.Text)).ToList();
                        }
                    }
                }
                #endregion

                #region MinPris
                if (!string.IsNullOrEmpty(TextBox_MinPris.Text))
                {
                    if (Convert.ToInt32(TextBox_MinPris.Text) > 0)
                    {
                        if (result == null)
                        {
                            result = db._Produkts.Where(p => p.pris >= Convert.ToInt32(TextBox_MinPris.Text)).ToList();

                        }
                        else
                        {
                            result = result.Where(p => p.pris >= Convert.ToInt32(TextBox_MinPris.Text)).ToList();
                        }
                    }
                }
                #endregion

                #region MaxPris
                if (!string.IsNullOrEmpty(TextBox_MaxPris.Text))
                {
                    if (Convert.ToInt32(TextBox_MaxPris.Text) > 0)
                    {
                        if (result == null)
                        {
                            result = db._Produkts.Where(p => p.pris <= Convert.ToInt32(TextBox_MaxPris.Text)).ToList();

                        }
                        else
                        {
                            result = result.Where(p => p.pris <= Convert.ToInt32(TextBox_MaxPris.Text)).ToList();
                        }
                    }
                }
                #endregion

                if (result.Count == 0)
                {
                    Panel_SogBesked.Visible = true;
                }
                else
                {

                    Panel_SogBesked.Visible = false;
                    Panel_VarenrSog.Visible = false;
                    PlaceHolder_AvansSog.Visible = false;
                    PlaceHolder_SogningResultat.Visible = true;
                    Repeater_Mobelliste.DataSource = result;
                    Repeater_Mobelliste.DataBind();
                    Label_SideNavn.Text = "Møbelliste";

                    // creates url parameter for a serier
                    string serier = string.Empty;
                    foreach (ListItem item in CheckBoxList_Serie.Items)
                    {
                        if (item.Selected)
                        {
                            serier += item.Value + ",";
                        }
                    }
                    if (serier.EndsWith(","))
                    {
                        serier = serier.Remove( serier.Length-1);
                    }

                    string urlPath = string.Format("Mobler.aspx?minpris={0}&maxpris={1}&serie={2}&minaar={3}&maxaar={4}&designer={5}"
                            , TextBox_MinPris.Text// {0}
                            , TextBox_MaxPris.Text // {1}
                            , serier// {2}
                            , TextBox_MinDesignAar.Text // {3}
                            ,TextBox_MaxDesignAar.Text//{4}
                            ,DropDownList_Designer.SelectedValue//{5}
                            );

                    Dictionary<string, string> requestParams = new Dictionary<string, string>();
                    requestParams["minpris"] = TextBox_MinPris.Text;
                    requestParams["maxpris"] = TextBox_MaxPris.Text;
                    requestParams["serie"] = serier;
                    requestParams["minaar"] = TextBox_MinDesignAar.Text;
                    requestParams["maxaar"] = TextBox_MaxDesignAar.Text;

                    string requestSearchString = GetSearchString(requestParams);
                    Response.Redirect(requestSearchString);

                    //Response.Redirect("Mobler.aspx?minpris=" + TextBox_MinPris.Text 
                    //    + "&maxpris=" + TextBox_MaxPris.Text 
                    //    + "&serie=" + serier 
                    //    + "&minaar=" + TextBox_MinDesignAar.Text 
                    //    + "&maxaar=" + TextBox_MaxDesignAar.Text 
                    //    + "&designer=" + DropDownList_Designer.SelectedValue);
                }
            }
        }

        /// <summary>
        /// metoden, der genererer url med det parametre, som vi giver som requestParams
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        private string GetSearchString(Dictionary<string, string> requestParams)
        {
            string requestSearchString = String.Empty;
            foreach (KeyValuePair<string, string> pair in requestParams)
            {
                requestSearchString += String.Format("&{0}={1}", pair.Key, pair.Value);
            }
            if (requestSearchString.Length > 0)
            {
                requestSearchString = requestSearchString.Remove(0, 1);
                requestSearchString = "Mobler.aspx?" + requestSearchString;
            }
            else
            {
                requestSearchString = "Mobler.aspx";
            }

            return requestSearchString;
        }

        */
    #region Prepare Search
    /// <summary>
    /// Thomas Variant af Søgning
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_searchKnap_Click(object sender, EventArgs e)
    {
        string maxpris = TextBox_MaxPris.Text;
        string minpris = TextBox_MinPris.Text;
        string maxaar = TextBox_MaxDesignAar.Text;
        string minaar = TextBox_MinDesignAar.Text;
        string designer = DropDownList_Designer.SelectedValue;

        //test start
        bool isAnySelected = CheckBoxList_Serie.SelectedIndex == -1; //If nothing is checked, the SelectedIndex is -1.


        if (string.IsNullOrEmpty(maxpris) &&
            string.IsNullOrEmpty(minpris) &&
            string.IsNullOrEmpty(maxaar) &&
            string.IsNullOrEmpty(minaar) &&
            DropDownList_Designer.SelectedValue == "" &&
            isAnySelected)
        {
            Response.Redirect("SogningMobelliste.aspx");
        }
        else//ig
        {
            ////ig
            List<_Produkt> result = new List<_Produkt>();
            
            List<int> serierne = new List<int>();
            foreach (ListItem item in CheckBoxList_Serie.Items)
            {
                if (item.Selected)
                {
                    serierne.Add(Convert.ToInt32(item.Value));
                }
            }

            int minaarval = 0;
            int maxaarval = int.MaxValue;
            int minprisval = 0;
            int maxprisval = int.MaxValue;

            if (!string.IsNullOrEmpty(minaar))
            {

                //string minaar = Request.QueryString["minaar"];
                int.TryParse(minaar, out minaarval);
                //minaar = int.MinValue.ToString();

            }
            //string maxaar = Request.QueryString["maxaar"];

            if (!string.IsNullOrEmpty(maxaar))
            {
                //maxaar = int.MaxValue.ToString();
                int.TryParse(maxaar, out maxaarval);
            }

            //string minpris = Request.QueryString["minpris"];
            if (!string.IsNullOrEmpty(minpris))
            {
                //minpris = int.MinValue.ToString();
                int.TryParse(minpris, out minprisval);
            }

            //string maxpris = Request.QueryString["maxpris"];
            if (!string.IsNullOrEmpty(maxpris))
            {
                //maxpris = int.MaxValue.ToString();
                int.TryParse(maxpris, out maxprisval);
            }

            SearchHandler search = new SearchHandler(DB.TagAlleProdukter());
            result = search.GetSearchResult(minaarval, maxaarval, minprisval, maxprisval, serierne, designer);
/*
            result.AddRange(db._Produkts.Where(p =>
                ((string.IsNullOrEmpty(minpris)||p.pris >= Convert.ToInt32(minpris)) && (string.IsNullOrEmpty(maxpris)||p.pris <= Convert.ToInt32(maxpris)))//pris
                && ((string.IsNullOrEmpty(minaar)||p.design_aar >= Convert.ToInt32(minaar)) && (string.IsNullOrEmpty(maxaar)||p.design_aar <= Convert.ToInt32(maxaar)))//år
                && (p.designer == designer || string.IsNullOrEmpty(designer))//designer
                && (serierne.Count == 0 || serierne.Contains(p.fk_serie_id))
                ).ToList());//(string.IsNullOrEmpty(designer)||
 */
            if (result.Count == 0)
            {
                Panel_SogBesked.Visible = true;
            }
            else
            {


                ///ig


                ////rabotaet
                // creates url parameter for a serier
                //string serier = string.Empty;
                //foreach (ListItem item in CheckBoxList_Serie.Items)
                //{
                //    if (item.Selected)
                //    {
                //        serier += item.Value + ",";
                //    }
                //}
                //if (serier.EndsWith(","))
                //{
                //    serier = serier.Remove(serier.Length - 1);
                //}

                string serier = string.Empty;
                if (serierne.Count > 0)
                {
                    serier = String.Join(",", serierne.ToArray());
                }
                

                var sb = new StringBuilder();

                sb.AppendFormat("/SogningMobelliste.aspx?q=1{0}", (!string.IsNullOrEmpty(minaar) ? "&minaar=" + minaar : ""));
                sb.AppendFormat("{0}", (!string.IsNullOrEmpty(maxaar)) ? "&maxaar=" + maxaar : "");
                sb.AppendFormat("{0}", (!string.IsNullOrEmpty(minpris)) ? "&minpris=" + minpris : "");
                sb.AppendFormat("{0}", (!string.IsNullOrEmpty(maxpris)) ? "&maxpris=" + maxpris : "");
                sb.AppendFormat("{0}", (!string.IsNullOrEmpty(serier)) ? "&serier=" + serier : "");
                sb.AppendFormat("{0}", (DropDownList_Designer.SelectedValue != "") ? "&designer=" + DropDownList_Designer.SelectedValue : "");
                Response.Redirect(sb.ToString());

            }//ig
        }//ig
    }
    #endregion
}