using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web.admin
{
    public partial class PanelArticulos : System.Web.UI.Page
    {
        private const int pageSize = 9;
        private int currentPage = 1;
        private string sortColumn = "Nombre";
        private string sortDirection = "ASC";

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
                List<Articulo> lista = negocio.listarOrdenado(sortColumn, sortDirection);

                int totalItems = lista.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize, totalItems);
                var pagina = lista.GetRange(startIndex, endIndex - startIndex);

                repArticulos.DataSource = pagina;
                repArticulos.DataBind();

                lblPaginacion.Text = "Página " + currentPage + " de " + totalPages + " (" + totalItems + " artículos)";
                btnPaginaAnterior.Enabled = (currentPage > 1);
                btnPaginaSiguiente.Enabled = (currentPage < totalPages);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            currentPage--;
            cargarListado();
        }

        protected void btnPaginaPrimera_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            cargarListado();
        }

        protected void btnPaginaUltima_Click(object sender, EventArgs e)
        {
            currentPage = int.MaxValue;
            cargarListado();
        }

        protected void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            currentPage++;
            cargarListado();
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

        protected void hdnSort_Command(object sender, CommandEventArgs e)
        {
            sortColumn = e.CommandArgument.ToString();
            sortDirection = sortColumn == "Nombre" ? "DESC" : "ASC";
            cargarListado();
        }
    }
}
