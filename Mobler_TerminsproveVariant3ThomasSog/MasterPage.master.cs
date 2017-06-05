using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink_Logo.Text = ConstantClass.logo;
        HyperLink_NavArkiv.Text = ConstantClass.nav_arkiv;
        HyperLink_NavMobler.Text = ConstantClass.nav_mobler;
        HyperLink_NavKontakt.Text = ConstantClass.nav_kontakt;

        Label_FooterInfo.Text = ConstantClass.footer_info;

        Label_Title.Text = ConstantClass.logo;



        var serier = DB.DBContext._Series.ToList();
        //Repeater_Serie.DataSource = serier;
        //Repeater_Serie.DataBind();

//variant2
        Repeater_DDL_Serier.DataSource = serier;
        Repeater_DDL_Serier.DataBind();

    }
    /// <summary>
    /// Det aktuelle menupunkt markeres en hover farve 
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected string IsCurrent(string page)
    {
        return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
    }
}
