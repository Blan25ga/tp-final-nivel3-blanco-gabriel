using System;
using System.Web;
using System.Web.UI;

namespace GestionCatalogo.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Session["error"].ToString();
                Session.Remove("error");
            }
            else
            {
                lblError.Text = "Ocurrió un error inesperado. Por favor, inténtelo más tarde.";
            }
        }
    }
}
