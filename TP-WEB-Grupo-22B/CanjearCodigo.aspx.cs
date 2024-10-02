using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_WEB_Grupo_22B
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = Request.Form["exampleFormControlInput1"];

            if (string.IsNullOrEmpty(codigoVoucher))
            {
                // Mensaje de error si el código está vacío
                Response.Write("<script>alert('Por favor, ingrese un código de voucher válido.');</script>");
                return;
            }

            // Validar el voucher
            if (ValidarVoucherNoUtilizado(codigoVoucher))
            {
                // Redirigir a la página de elegir premio si el voucher no ha sido utilizado
                Response.Redirect("ElegirPremio.aspx");
            }
            else
            {
                // Mostrar mensaje de error si el voucher ya fue utilizado
                Response.Write("<script>alert('El código de voucher ya ha sido utilizado.');</script>");
            }
        }

        private bool ValidarVoucherNoUtilizado(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            bool esValido = false;

            try
            {
                // Consulta para verificar si el voucher ya está registrado en la tabla
                datos.setearConsulta("SELECT CodigoVoucher FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigoVoucher);

                datos.ejecutarLectura();

                // Si no hay registros, significa que el voucher no ha sido utilizado
                if (!datos.Lector.HasRows)
                {
                    esValido = true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error en la validación del voucher: " + ex.Message + "');</script>");
            }
            finally
            {
                datos.cerrarConexion();
            }

            return esValido;
        }
    }
}