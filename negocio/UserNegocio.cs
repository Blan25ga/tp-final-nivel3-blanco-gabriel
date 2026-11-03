using System;
using System.Collections.Generic;
using System.Data;
using dominio;

namespace negocio
{
    public class UserNegocio
    {
        public bool Login(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, email, pass, nombre, apellido, urlImagenPerfil, admin " +
                                     "FROM USERS WHERE email = @email AND pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Pass = (string)datos.Lector["pass"];
                    user.Nombre = datos.Lector["nombre"] != DBNull.Value ? (string)datos.Lector["nombre"] : "";
                    user.Apellido = datos.Lector["apellido"] != DBNull.Value ? (string)datos.Lector["apellido"] : "";
                    user.UrlImagenPerfil = datos.Lector["urlImagenPerfil"] != DBNull.Value ? (string)datos.Lector["urlImagenPerfil"] : "";
                    user.Admin = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;
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

        public bool emailRegistrado(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USERS WHERE email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;
                return false;
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

        public int agregar(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "INSERT INTO USERS (email, pass, nombre, apellido, urlImagenPerfil, admin) " +
                    "VALUES (@email, @pass, @nombre, @apellido, @urlImagenPerfil, @admin); " +
                    "SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", "");
                datos.setearParametro("@apellido", "");
                datos.setearParametro("@urlImagenPerfil", "");
                datos.setearParametro("@admin", false);

                return (int)datos.ejecutarAccionScalar();
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

        public int buscarId(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id FROM USERS WHERE email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return (int)datos.Lector["Id"];
                return 0;
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

        public void actualizar(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "UPDATE USERS SET pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil " +
                    "WHERE Id = @Id");
                datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@urlImagenPerfil", user.UrlImagenPerfil);
                datos.setearParametro("@Id", user.Id);
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
    }
}
