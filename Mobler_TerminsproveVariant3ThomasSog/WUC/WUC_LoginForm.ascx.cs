using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC_LoginForm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Login_Click(object sender, EventArgs e)
    {
        string salt = "mad";
        string email = TextBox_Brugernavn.Text;
        string password = Helper.GetMD5Hash(TextBox_Password.Text + salt);

        if (!string.IsNullOrEmpty(email) &&
            !string.IsNullOrEmpty(password))
        {
            try
            {
                var query = DB.TagBrugeren(email, password);

                Session["id"] = query.bruger_id;
                Session["brugernavn"] = query.brugernavn;
           

                Response.Redirect("~/Admin/Default_Admin.aspx");
            }
            catch (Exception)
            {

                Label_Error.Text = "<span style='color:Red;font-weight:bold;margin-right:5px'><p>Den log ind-information, du har angivet, er ikke korekt. Prøv igen!</p></span>";
                Label_Error.Visible = true;
            }
        }
    }
}