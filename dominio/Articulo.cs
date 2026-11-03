namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

        public Articulo()
        {
            Marca = new Marca();
            Categoria = new Categoria();
            Codigo = string.Empty;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            ImagenUrl = string.Empty;
        }
    }
}
