namespace dominio
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImagenPerfil { get; set; }
        public bool Admin { get; set; }

        public User()
        {
            Email = string.Empty;
            Pass = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            UrlImagenPerfil = string.Empty;
        }
    }
}
