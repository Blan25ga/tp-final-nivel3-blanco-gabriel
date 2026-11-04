using System;
using System.Collections.Generic;
using System.Data;
using dominio;

namespace negocio
{
    public class FavoritoNegocio
    {
        public bool esFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error al verificar favorito: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int agregar(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccionScalar();
                return 1;
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

        public void eliminar(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArticulo", idArticulo);
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

        public List<Articulo> listarFavoritos(int idUser)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                datos.setearConsulta("SELECT IdArticulo FROM FAVORITOS WHERE IdUser = @IdUser");
                datos.setearParametro("@IdUser", idUser);
                datos.ejecutarLectura();
                List<int> ids = new List<int>();
                while (datos.Lector.Read())
                {
                    ids.Add((int)datos.Lector["IdArticulo"]);
                }
                datos.cerrarConexion();

                foreach (int id in ids)
                {
                    List<Articulo> articulo = articuloNegocio.obtenerPorId(id);
                    if (articulo.Count > 0)
                        lista.Add(articulo[0]);
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
    }
}
