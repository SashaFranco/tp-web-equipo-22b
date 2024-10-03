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
            //string codigoVoucher = Request.Form["exampleFormControlInput1"]; 
            string codigoVoucher = exampleFormControlInput1.Text;

            if (string.IsNullOrEmpty(codigoVoucher))
            {
                // Mensaje de error si el código está vacío
                Response.Write("<script>alert('Por favor, ingrese un código de voucher válido.');</script>");
                return;
            }
            
            VoucherNegocio voucherNegocio = new VoucherNegocio();

            // Validar el voucher
            if (voucherNegocio.ValidarVoucherNoUtilizado(codigoVoucher))
            {
                // Redirigir a la página de elegir premio si el voucher no ha sido utilizado
                Session["codigoVoucher"] = codigoVoucher;
                Response.Redirect("ElegirPremio.aspx");
            }
            else
            {
                // Mostrar mensaje de error si el voucher ya fue utilizado
                Response.Write("<script>alert('El código de voucher ya ha sido utilizado.');</script>");
            }
        }     
    }
}