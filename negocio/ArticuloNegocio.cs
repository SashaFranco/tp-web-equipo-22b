using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

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
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS ImagenUrl, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
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
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Codigo);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Codigo);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
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
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setearParametro("@Id", art.Id);
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Codigo);
                datos.setearParametro("@idCategoria", art.Categoria.Codigo);
                datos.setearParametro("@precio", art.Precio);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            /*
            try
            {
                datos.setearConsulta("update IMAGENES set ImagenUrl = @imagen where IdArticulo = " + art.Imagen);
                datos.setearParametro("@imagen", art.Imagen);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            */

        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametro("Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarImagen(Articulo aux)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("insert into IMAGENES(IdArticulo, ImagenUrl) values(@idArt, @urlImg)");
                datos.setearParametro("idArt", aux.Id);
                datos.setearParametro("urlImg", aux.Imagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Articulo leerDatos(Articulo aux)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("SELECT Id, Codigo, Nombre, Descripcion, Precio from ARTICULOS");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                if ((string)datos.Lector["Codigo"] == aux.Codigo)

                {
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                }


            }

            return aux;
        }

        public List<string> cargarVecImagenes(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<string> lista = new List<string>();


            try
            {
                datos.setearConsulta("select Id, idArticulo, ImagenUrl from IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!((datos.Lector["ImagenUrl"] is DBNull)) && (Id == (int)datos.Lector["IdArticulo"]))
                        lista.Add((string)datos.Lector["ImagenUrl"]);


                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }






        }

        public List<Articulo> filtrar (string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS ImagenUrl, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca and ";
                switch (campo)
                {
                    case "Precio":
                        if(criterio == "Menor a")
                        {
                            consulta += "A.Precio < " + filtro;
                        }
                        else if (criterio == "Mayor a")
                        {
                            consulta += "A.Precio > " + filtro;
                        }
                        else
                        {
                            consulta += "A.Precio = " + filtro;
                        }

                        break;
                    case "Nombre":
                        if(criterio == "Comienza con")
                        {
                            consulta += "A.Nombre like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Nombre like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Nombre like '%" + filtro + "%'";
                        }
                        break;
                    case "Descripcion":
                        if (criterio == "Comienza con")
                        {
                            consulta += "A.Descripcion like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Descripcion like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                        }
                        break;
                    case "Codigo":
                        if (criterio == "Comienza con")
                        {
                            consulta += "A.Codigo like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Codigo like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Codigo like '%" + filtro + "%'";
                        }
                        break;
                    case "Marca":
                        if (criterio == "Comienza con")
                        {
                            consulta += "M.Descripcion like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "M.Descripcion like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                        }
                        break;
                    case "Categoria":
                        if (criterio == "Comienza con")
                        {
                            consulta += "C.Descripcion like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "C.Descripcion like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

               
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
