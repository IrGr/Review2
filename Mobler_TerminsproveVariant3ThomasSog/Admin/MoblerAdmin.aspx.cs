using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MoblerAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_ProdukterTabel.DataSource = DB.TagAlleProdukter();
        Repeater_ProdukterTabel.DataBind();
    }
    protected void LinkButton_AddProdukt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/NyProdukt.aspx");
    }
    protected void Repeater_ProdukterTabel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Slet")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var produkt = DB.TagEtProduktMedId(id);
            var pb = DB.TagAlleBilledeEfterProduktId(id);
            var billeder = (from b in DB.DBContext._Billedes
                           join k in DB.DBContext._Produkt_Billedes on b.billlede_id equals k.fk_billede_id 
                            where k.fk_produkt_id == id select b).ToList();


            foreach (_Billede item in billeder)
	        {
		         DB.DBContext._Billedes.DeleteOnSubmit(item);

                File.Delete(Server.MapPath("~/Images/"+ produkt._Serie.serie_navn + "/" + item.billede_sti_120_90));
                File.Delete(Server.MapPath("~/Images/"+ produkt._Serie.serie_navn + "/" + item.billede_sti_120_90));

	        }
            foreach (_Produkt_Billede item in pb)
	        {
		        DB.DBContext._Produkt_Billedes.DeleteOnSubmit(item);
	        }
            
		        DB.DBContext._Produkts.DeleteOnSubmit(produkt);

             try
            {
                DB.DBContext.SubmitChanges();
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {

                Response.Write("Der opstod en fejl:" + ex.Message);
            }
	        
        }
    }
}