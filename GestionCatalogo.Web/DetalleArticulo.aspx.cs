using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                    return;

                int id;
                int.TryParse(Request.QueryString["id"], out id);
                if (id <= 0)
                {
                    divNoEncontrado.Visible = true;
                    phDetalle.Visible = false;
                    return;
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> resultado = negocio.obtenerPorId(id);

                if (resultado.Count == 0)
                {
                    divNoEncontrado.Visible = true;
                    phDetalle.Visible = false;
                    return;
                }

                Articulo item = resultado[0];
                lblNombre.InnerText = item.Nombre;
                lblDescripcion.Text = !string.IsNullOrEmpty(item.Descripcion) ? item.Descripcion : "Sin descripción.";
                lblCodigo.Text = item.Codigo;
                lblMarca.Text = item.Marca.Descripcion;
                lblCategoria.Text = item.Categoria.Descripcion;
                lblPrecio.Text = "$ " + item.Precio.ToString("N0");
                imgPortada.Src = !string.IsNullOrEmpty(item.ImagenUrl)
                    ? item.ImagenUrl
                    : "https://placehold.co/420x280?text=Sin+imagen";

                if (Seguridad.sesionActiva(Session["user"]))
                {
                    User user = (User)Session["user"];
                    FavoritoNegocio favNegocio = new FavoritoNegocio();
                    bool esFavorito = favNegocio.esFavorito(user.Id, id);
                    btnFavorito.Text = esFavorito
                        ? "★ Quitar de favoritos"
                        : "☆ Agregar a favoritos";
                }
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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                User user = (User)Session["user"];
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                FavoritoNegocio favNegocio = new FavoritoNegocio();
                bool esFavorito = favNegocio.esFavorito(user.Id, id);

                if (esFavorito)
                    favNegocio.eliminar(user.Id, id);
                else
                    favNegocio.agregar(user.Id, id);

                Response.Redirect("DetalleArticulo.aspx?id=" + id, false);
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
    }
}
