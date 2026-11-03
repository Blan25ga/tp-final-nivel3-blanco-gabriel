using System;
using System.Collections.Generic;
using System.Data;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, " +
                    "M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(mapear(datos.Lector));
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, " +
                                  "M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria " +
                                  "FROM ARTICULOS A " +
                                  "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                                  "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id AND ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > @Filtro";
                            break;
                        case "Menor a":
                            consulta += "Precio < @Filtro";
                            break;
                        default:
                            consulta += "Precio = @Filtro";
                            break;
                    }
                    decimal precioFiltro;
                    decimal.TryParse(filtro, out precioFiltro);
                    datos.setearParametro("@Filtro", precioFiltro);
                }
                else if (campo == "Nombre")
                {
                    consulta += "Nombre LIKE @Filtro";
                    datos.setearParametro("@Filtro", construirLike(criterio, filtro));
                }
                else if (campo == "Marca")
                {
                    consulta += "M.Descripcion LIKE @Filtro";
                    datos.setearParametro("@Filtro", construirLike(criterio, filtro));
                }
                else
                {
                    consulta += "C.Descripcion LIKE @Filtro";
                    datos.setearParametro("@Filtro", construirLike(criterio, filtro));
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(mapear(datos.Lector));
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                    "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                cargarParametros(nuevo, datos);
                datos.setearParametro("@Id", nuevo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, " +
                    "IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio " +
                    "WHERE Id = @Id");
                cargarParametros(art, datos);
                datos.setearParametro("@Id", art.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> obtenerPorId(int id)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, " +
                    "M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id " +
                    "WHERE A.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(mapear(datos.Lector));
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private Articulo mapear(SqlDataReader lector)
        {
            Articulo aux = new Articulo();
            aux.Id = (int)lector["Id"];
            aux.Codigo = lector["Codigo"] != DBNull.Value ? (string)lector["Codigo"] : "";
            aux.Nombre = lector["Nombre"] != DBNull.Value ? (string)lector["Nombre"] : "";
            aux.Descripcion = lector["Descripcion"] != DBNull.Value ? (string)lector["Descripcion"] : "";
            aux.ImagenUrl = lector["ImagenUrl"] != DBNull.Value ? (string)lector["ImagenUrl"] : "";
            aux.Precio = lector["Precio"] != DBNull.Value ? (decimal)lector["Precio"] : 0;
            aux.Marca = new Marca();
            aux.Marca.Id = lector["IdMarca"] != DBNull.Value ? (int)lector["IdMarca"] : 0;
            aux.Marca.Descripcion = lector["Marca"] != DBNull.Value ? (string)lector["Marca"] : "";
            aux.Categoria = new Categoria();
            aux.Categoria.Id = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : 0;
            aux.Categoria.Descripcion = lector["Categoria"] != DBNull.Value ? (string)lector["Categoria"] : "";
            return aux;
        }

        private void cargarParametros(Articulo art, AccesoDatos datos)
        {
            datos.setearParametro("@Codigo", art.Codigo);
            datos.setearParametro("@Nombre", art.Nombre);
            datos.setearParametro("@Descripcion", art.Descripcion);
            datos.setearParametro("@IdMarca", art.Marca.Id);
            datos.setearParametro("@IdCategoria", art.Categoria.Id);
            datos.setearParametro("@ImagenUrl", art.ImagenUrl);
            datos.setearParametro("@Precio", art.Precio);
        }

        private string construirLike(string criterio, string filtro)
        {
            switch (criterio)
            {
                case "Comienza con":
                    return filtro + "%";
                case "Termina con":
                    return "%" + filtro;
                default:
                    return "%" + filtro + "%";
            }
        }
    }
}
