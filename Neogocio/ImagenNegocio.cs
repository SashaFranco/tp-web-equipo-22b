using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace TP_WinForms_Grupo_1B.Modelos
{
    public class ImagenNegocio
    {
        public void CargarImagen(string url)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            Articulo aux = new Articulo();
            AccesoDatos datos = new AccesoDatos();
            aux = articulo.BuscarUltimoArticulo();
            try
            {
                string consulta = "insert into IMAGENES(IdArticulo,ImagenUrl)values(@id,@url)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@url", url);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se pude cargar imagen");
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
