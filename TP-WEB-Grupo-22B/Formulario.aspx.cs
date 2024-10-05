using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;  // Carpeta que envia correos (actividad opcional)
using dominio;
using negocio;

namespace TP_WEB_Grupo_22B
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void agregarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Dni = txtDni.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.CP = int.Parse(txtCP.Text);

            if (cliente.CP < 0)
            {
                return;
            }

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.agregar(cliente);

        }

        private bool campoVacio(string campo)
        {
            if(campo == "")
            {
                return true;
            }

            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(Request.QueryString["id"]);
            string mensajeError = "";

            //validar que todos los campos estén completos
            if(campoVacio(txtDni.Text) || campoVacio(txtNombre.Text) || campoVacio(txtApellido.Text) || campoVacio(txtEmail.Text) || campoVacio(txtDireccion.Text) || campoVacio(txtCiudad.Text) || campoVacio(txtCP.Text) )
            {
                mensajeError += "Debe cargar todos los campos para participar. ";
            }

            if(!(CheckTermCond.Checked)) 
                {
                mensajeError += "Debe aceptar los terminos y condiciones.";
                }

            if(mensajeError != "")
            {
                Response.Write("<script>alert('" + mensajeError + "');</script>");
                return;
            }

            string dni = txtDni.Text;
            ClienteNegocio auxNegocio = new ClienteNegocio();
            Cliente aux = auxNegocio.BuscarPorDni(dni);

            int IdCliente;
           

            if (aux != null && aux.Dni != "0")
            {
                IdCliente = auxNegocio.buscarId(dni);
                Response.Write("<script>alert('no se cargo , el id es: " + IdCliente + "');</script>");
            }
            else
            {
                agregarCliente();
                IdCliente = auxNegocio.buscarId(dni);  //ID DEL CLIENTE CARGADO
                Response.Write("<script>alert('se cargo y el id es:" + IdCliente + "');</script>");

            }

            //IdCliente, Codigo de vaucher, fecha de hoy, ID de articulo

            string codigoVoucher = Session["codigoVoucher"].ToString();
            //int idArticulo = int.Parse(Request.QueryString["id"]);

            VoucherNegocio vnegocio = new VoucherNegocio();
            vnegocio.canjearVoucher(codigoVoucher, IdCliente, idArticulo);

            // -------actividad opcional, enviar correo ------//
            
            //await EnviarCorreoSendGrid.EnviarCorreo(txtEmail.Text, txtNombre.Text, codigoVoucher);

            // -------actividad opcional, enviar correo ------//
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente = clienteNegocio.BuscarPorDni(dni);
                if (cliente.Dni != "0")
                {
                    txtDni.Text = cliente.Dni;
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtCiudad.Text = cliente.Ciudad;
                    txtDireccion.Text = cliente.Direccion;
                    txtCP.Text = cliente.CP.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}