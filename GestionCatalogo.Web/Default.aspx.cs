using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Articulo> artLos = new List<Articulo>();
        private const int pageSize = 9;
        private int currentPage = 1;

        public List<Articulo> Articulos
        {
            get
            {
                if (Session["articulosCatalogo"] == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session["articulosCatalogo"] = negocio.listar();
                }
                return (List<Articulo>)Session["articulosCatalogo"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("Todas", "0"));

                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Todas", "0"));

                    cargarGrilla();
                }
                catch (Exception ex)
                {
                    mostrarError("Ocurrió un error al cargar el catálogo.", ex);
                }
            }
        }

        private void cargarGrilla()
        {
            try
            {
                List<Articulo> lista = Articulos;
                artLos = lista;

                string filtroNombre = txtNombre.Text.Trim();
                int idMarca = int.Parse(ddlMarca.SelectedValue);
                int idCategoria = int.Parse(ddlCategoria.SelectedValue);
                decimal precioMax;
                bool tienePrecio = decimal.TryParse(txtPrecioMax.Text, out precioMax);

                var filtrada = lista;
                if (!string.IsNullOrEmpty(filtroNombre))
                {
                    filtrada = filtrada.FindAll(x => x.Nombre.IndexOf(filtroNombre, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                if (!tienePrecio) precioMax = decimal.MaxValue;
                if (idMarca > 0)
                    filtrada = filtrada.FindAll(x => x.Marca.Id == idMarca).ToList();
                if (idCategoria > 0)
                    filtrada = filtrada.FindAll(x => x.Categoria.Id == idCategoria).ToList();
                filtrada = filtrada.FindAll(x => x.Precio >= 0 && x.Precio <= precioMax).ToList();

                // --- Paginación ---
                int totalItems = filtrada.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize, totalItems);
                var pagina = filtrada.GetRange(startIndex, endIndex - startIndex);

                repArticulos.DataSource = pagina;
                repArticulos.DataBind();

                sinResultados.Visible = (totalItems == 0);

                lblPaginacion.Text = "Página " + currentPage + " de " + totalPages + " (" + totalItems + " artículos)";
                btnPaginaAnterior.Enabled = (currentPage > 1);
                btnPaginaSiguiente.Enabled = (currentPage < totalPages);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            cargarGrilla();
        }

        protected void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            currentPage--;
            cargarGrilla();
        }

        protected void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            currentPage++;
            cargarGrilla();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            cargarGrilla();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            cargarGrilla();
        }

        protected void txtPrecioMax_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            cargarGrilla();
        }

        private void mostrarError(string mensaje, Exception ex)
        {
            alertaError.Controls.Add(new Literal());
            alertaError.InnerHtml = "<strong>" + HttpUtility.HtmlEncode(mensaje) + "</strong><br/>" + HttpUtility.HtmlEncode(ex.Message);
            alertaError.Visible = true;
        }
    }
}
