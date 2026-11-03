using dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            User aux = user != null ? (User)user : null;
            return aux != null && aux.Id != 0;
        }

        public static bool esAdmin(object user)
        {
            User aux = user != null ? (User)user : null;
            return aux != null && aux.Admin;
        }
    }
}
