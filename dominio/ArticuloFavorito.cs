namespace dominio
{
    public class ArticuloFavorito
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Articulo Articulo { get; set; }

        public ArticuloFavorito()
        {
            User = new User();
            Articulo = new Articulo();
        }
    }
}
