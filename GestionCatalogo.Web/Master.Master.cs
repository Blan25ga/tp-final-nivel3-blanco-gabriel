using System;
using System.Web.UI;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public int ArticulosCount { get; set; } = 0;

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
            // Contar artículos para el menú de administración
            if (Usuario != null && Usuario.Admin)
            {
                try
                {
                    ArticulosCount = new ArticuloNegocio().contar();
                }
                catch
                {
                    ArticulosCount = 0;
                }
            }

            // Verificar timeout de sesión (excepto en Login, Registro y Error, para no entrar en bucle)
            if (Session["user"] == null)
            {
                string pagina = Request.AppRelativeCurrentExecutionFilePath ?? "";
                bool esPublica = pagina.Equals("~/Login.aspx", StringComparison.OrdinalIgnoreCase)
                              || pagina.Equals("~/Registro.aspx", StringComparison.OrdinalIgnoreCase)
                              || pagina.Equals("~/Error.aspx", StringComparison.OrdinalIgnoreCase);
                if (!esPublica)
                {
                    Session.Add("error", "Tu sesión expiró. Por favor, inicia sesión nuevamente.");
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
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
