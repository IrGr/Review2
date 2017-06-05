using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Helper.ErLoggetInd())
        {
            HyperLink_Logo.Text = ConstantClass.logo;
            HyperLink_NavArkiv.Text = ConstantClass.adm_nav_nyhed;
            HyperLink_NavMobler.Text = ConstantClass.nav_mobler;
            HyperLink_NavKontakt.Text = ConstantClass.nav_kontakt;

            Hyperlink_LogUd.Text = ConstantClass.logud;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected string IsCurrent(string page)
    {
        return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
    }
    protected void Hyperlink_LogUd_Click(object sender, EventArgs e)
    {
        Helper.LogUd();
    }
}
