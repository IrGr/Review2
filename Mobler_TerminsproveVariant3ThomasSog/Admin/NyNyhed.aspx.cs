using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NyNyhed : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_GemNyNyhed_Click(object sender, EventArgs e)
    {
        string overskrift = TextBox_Overskrift.Text;
        string tekst = TextBox_Tekst.Text;
        string forfatter = TextBox_Forfatter.Text;

        if (!string.IsNullOrEmpty(overskrift)
            && !string.IsNullOrEmpty(tekst)
            && !string.IsNullOrEmpty(forfatter))
        {
            int forfatter_id = 0;

            var query = db._Forfatters.Where(f => f.forfatter_name.Equals(forfatter)).FirstOrDefault();
            if (query == null)
            {
                _Forfatter nyforfatter = new _Forfatter
                {
                    forfatter_name = forfatter
                };
                db._Forfatters.InsertOnSubmit(nyforfatter);
                db.SubmitChanges();
                forfatter_id = nyforfatter.forfatter_id;
            }
            else
            {
                forfatter_id = query.forfatter_id;
            }

            _Nyhed nynyhed = new _Nyhed
            {
                overskrift = overskrift,
                tekst = tekst,
                dato = DateTime.Now,
                fk_forfatter_id = forfatter_id

            };

            db._Nyheds.InsertOnSubmit(nynyhed);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Response.Redirect("~/Admin/NyhederAdmin.aspx");
        }
        
    }
}