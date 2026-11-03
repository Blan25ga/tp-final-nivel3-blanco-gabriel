using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void validarPass(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtPass.Text.Length >= 4);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                string email = txtEmail.Text.Trim().ToLower();
                string pass = txtPass.Text.Trim();

                UserNegocio negocio = new UserNegocio();
                if (negocio.emailRegistrado(email))
                {
                    divMensaje.InnerText = "Ya existe una cuenta con ese email. Probá con otro o iniciá sesión.";
                    divMensaje.Visible = true;
                    return;
                }

                User nuevo = new User();
                nuevo.Email = email;
                nuevo.Pass = pass;
                negocio.agregar(nuevo);

                Session["nuevoUsuario"] = email;
                Response.Redirect("Login.aspx", false);
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
