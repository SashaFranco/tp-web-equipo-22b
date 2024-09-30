using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Codigo = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

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

        public void agregarMarca(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into MARCAS (Descripcion)values(@descripcion)");
                datos.setearParametro("@descripcion", nuevaMarca.Nombre);
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
    }

    
}
