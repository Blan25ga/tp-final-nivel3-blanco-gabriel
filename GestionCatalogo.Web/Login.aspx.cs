using System;
using System.Web;
using System.Web.UI;
using dominio;
using negocio;

namespace GestionCatalogo.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                dominio.User user = new dominio.User();
                UserNegocio negocio = new UserNegocio();
                user.Email = txtEmail.Text.Trim();
                user.Pass = txtPass.Text.Trim();

                if (negocio.Login(user))
                {
                    Session["user"] = user;
                    if (user.Admin)
                        Response.Redirect("admin/PanelArticulos.aspx", false);
                    else
                        Response.Redirect("Default.aspx", false);
                }
                else
                {
                    divMensaje.InnerText = "Email o contraseña incorrectos.";
                    divMensaje.Visible = true;
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
    }
}
