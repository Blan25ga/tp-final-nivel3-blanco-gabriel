using System;
using System.Threading;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            try
            {
                if (!IsPostBack)
                    cargarFavoritos();
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarFavoritos()
        {
            try
            {
                User user = (User)Session["user"];
                FavoritoNegocio negocio = new FavoritoNegocio();
                System.Collections.Generic.List<Articulo> favoritos = negocio.listarFavoritos(user.Id);

                repFavoritos.DataSource = favoritos;
                repFavoritos.DataBind();
                sinFavoritos.Visible = (favoritos.Count == 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnQuitar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                User user = (User)Session["user"];
                int idArticulo;
                int.TryParse(e.CommandArgument.ToString(), out idArticulo);

                FavoritoNegocio negocio = new FavoritoNegocio();
                negocio.eliminar(user.Id, idArticulo);

                cargarFavoritos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
