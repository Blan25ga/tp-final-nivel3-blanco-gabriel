using System;
using System.Web.UI;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public dominio.User Usuario
        {
            get
            {
                if (Session["user"] != null)
                    return (dominio.User)Session["user"];
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar timeout de sesión
            if (Session["user"] == null)
            {
                Session.Add("error", "Tu sesión expiró. Por favor, inicia sesión nuevamente.");
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            btnSalir.Visible = true;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}
