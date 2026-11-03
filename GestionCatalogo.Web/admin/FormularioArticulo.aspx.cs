using System;
using System.Threading;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web.admin
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool Modificacion { get { return Request.QueryString["id"] != null; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                phForm.Visible = false;
                divAcceso.Visible = true;
                return;
            }

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    if (Modificacion)
                    {
                        tituloPantalla.InnerText = "Modificar artículo";
                        int id;
                        int.TryParse(Request.QueryString["id"], out id);

                        ArticuloNegocio negocio = new ArticuloNegocio();
                        var resultado = negocio.obtenerPorId(id);
                        if (resultado.Count > 0)
                        {
                            Articulo art = resultado[0];
                            txtCodigo.Text = art.Codigo;
                            txtNombre.Text = art.Nombre;
                            txtDescripcion.Text = art.Descripcion;
                            txtImagenUrl.Text = art.ImagenUrl;
                            txtPrecio.Text = art.Precio.ToString("0.##", CultureInfo.CurrentCulture);
                            ddlMarca.SelectedValue = art.Marca.Id.ToString();
                            ddlCategoria.SelectedValue = art.Categoria.Id.ToString();
                            imgPrevisualizacion.Src = !string.IsNullOrEmpty(art.ImagenUrl)
                                ? art.ImagenUrl
                                : "https://placehold.co/220x130?text=Sin+imagen";
                        }
                    }
                    else
                    {
                        imgPrevisualizacion.Src = "https://placehold.co/220x130?text=Sin+imagen";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void validarMarca(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlMarca.SelectedIndex >= 0);
        }

        protected void validarCategoria(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlCategoria.SelectedIndex >= 0);
        }

        protected void validarPrecio(object source, ServerValidateEventArgs args)
        {
            decimal precio;
            string texto = txtPrecio.Text.Replace(',', '.');
            args.IsValid = decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out precio) && precio >= 0;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo art = new Articulo();
                art.Codigo = txtCodigo.Text.Trim();
                art.Nombre = txtNombre.Text.Trim();
                art.Descripcion = txtDescripcion.Text.Trim();
                art.ImagenUrl = txtImagenUrl.Text.Trim();
                art.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                art.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                decimal precio;
                decimal.TryParse(txtPrecio.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);
                art.Precio = precio;

                if (Modificacion)
                {
                    int id;
                    int.TryParse(Request.QueryString["id"], out id);
                    art.Id = id;
                    negocio.modificar(art);
                }
                else
                {
                    negocio.agregar(art);
                }

                Response.Redirect("PanelArticulos.aspx", false);
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelArticulos.aspx", false);
        }
    }
}
