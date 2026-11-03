using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class MiPerfil : System.Web.UI.Page
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
                {
                    User user = (User)Session["user"];
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    txtImagenPerfil.Text = user.UrlImagenPerfil;
                    imgPerfil.Src = !string.IsNullOrEmpty(user.UrlImagenPerfil)
                        ? user.UrlImagenPerfil
                        : "https://placehold.co/110x110?text=%3A%29";
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

        protected void validarPass(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtPass.Text.Length == 0 || txtPass.Text.Length >= 4);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                User user = (User)Session["user"];
                UserNegocio negocio = new UserNegocio();

                user.Nombre = txtNombre.Text.Trim();
                user.Apellido = txtApellido.Text.Trim();
                user.UrlImagenPerfil = txtImagenPerfil.Text.Trim();
                if (txtPass.Text.Length > 0)
                    user.Pass = txtPass.Text.Trim();

                negocio.actualizar(user);
                Session["user"] = user;

                divMensaje.InnerText = "Tus datos fueron guardados correctamente.";
                divMensaje.Visible = true;
                imgPerfil.Src = !string.IsNullOrEmpty(user.UrlImagenPerfil)
                    ? user.UrlImagenPerfil
                    : "https://placehold.co/110x110?text=%3A%29";
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
