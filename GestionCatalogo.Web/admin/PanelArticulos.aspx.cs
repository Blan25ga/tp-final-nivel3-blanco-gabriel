using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web.admin
{
    public partial class PanelArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                phPanel.Visible = false;
                divAcceso.Visible = true;
                return;
            }

            if (!IsPostBack)
            {
                cargarListado();
            }
        }

        private void cargarListado()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                repArticulos.DataSource = negocio.listar();
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(e.CommandArgument.ToString(), out id);
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(id);
                cargarListado();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx", false);
            }
        }
    }
}
