using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {
        public List<Vouchers> Listar()
        {
            List<Vouchers> lista = new List<Vouchers>();
            AccesoDatos datos = new AccesoDatos();



            return lista;
        }
        public Vouchers BuscarPorCodigo(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            Vouchers voucher = new Vouchers();

            try
            {
                datos.setearConsulta("SELECT codigoVoucher, idCliente, fechaCanje, idArticulo FROM Vouchers WHERE codigoVoucher = @codigoVoucher");
                datos.setearParametro("@codigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher.cliente = new Cliente();
                    voucher.articulo = new Articulo();

                    voucher.codigoVoucher = (string)datos.Lector["codigoVoucher"];
                    voucher.cliente.ID = (int)datos.Lector["idCliente"];
                    voucher.fechaCanje = (DateTime)datos.Lector["fechaCanje"];
                    voucher.articulo.Id = (int)datos.Lector["idArticulo"];

                    //voucher = new Vouchers
                    //{
                    //    codigoVoucher = datos.Lector["codigoVoucher"].ToString(),
                    //    cliente = datos.Lector["idCliente"] != DBNull.Value ? new Cliente { Dni = datos.Lector["idCliente"].ToString() } : null,
                    //    fechaCanje = datos.Lector["fechaCanje"] != DBNull.Value ? Convert.ToDateTime(datos.Lector["fechaCanje"]) : DateTime.MinValue,
                    //    articulo = datos.Lector["idArticulo"] != DBNull.Value ? new Articulo { Id = Convert.ToInt32(datos.Lector["idArticulo"]) } : null
                    //};

                    


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return voucher;
        }
        public void CanjearVoucher(string codigoVoucher, Cliente cliente, Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET idCliente = @idCliente, fechaCanje = @fechaCanje, idArticulo = @idArticulo WHERE codigoVoucher = @codigoVoucher");
                datos.setearParametro("@idCliente", cliente.Dni);
                datos.setearParametro("@fechaCanje", DateTime.Now);
                datos.setearParametro("@idArticulo", articulo.Id);
                datos.setearParametro("@codigoVoucher", codigoVoucher);
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
        public void agregar(Vouchers nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                //datos.setearParametro("@Codigo", nuevo.Codigo);
                //datos.setearParametro("@Nombre", nuevo.Nombre);
                //datos.setearParametro("@Descripcion", nuevo.Descripcion);
                //datos.setearParametro("@IdMarca", nuevo.Marca.Codigo);
                //datos.setearParametro("@IdCategoria", nuevo.Categoria.Codigo);
                //datos.setearParametro("@Precio", nuevo.Precio);

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
