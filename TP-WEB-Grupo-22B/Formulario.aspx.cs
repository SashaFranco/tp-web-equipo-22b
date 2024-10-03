using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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



        protected void Button1_Click(object sender, EventArgs e)
        {
           
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
            int idArticulo = int.Parse(Request.QueryString["id"]);

            VoucherNegocio vnegocio = new VoucherNegocio();
            vnegocio.canjearVoucher(codigoVoucher, IdCliente, idArticulo);

            Response.Redirect("partExitosa.aspx");
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