using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
//using System.Web.Services.Description;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
 
        public void eliminar(int Dni)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("delete from clientes where Documento=@Dni");
                datos.setearParametro("@Dni", Dni);
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

        public void agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into clientes values (@Dni, @Nombre, @Apellido,@Email, @Direccion, @Ciudad,@CP)");
                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email",cliente.Email);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);
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

        public Cliente BuscarPorDni(string Dni)
        {
            
            AccesoDatos datos=new AccesoDatos();
            Cliente cliente = new Cliente();

            try
            {
                datos.setearConsulta("select Id,Documento, Nombre,Apellido,Email,Direccion, Ciudad,CP from clientes where Documento = @Dni");
                datos.setearParametro("@Dni", Dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.Dni = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CP = (int)datos.Lector["CP"];
                    
                    return cliente;
                }
                else
                {
                cliente.Dni = "0";

                }
                return cliente;
                


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }


        }




    }
}