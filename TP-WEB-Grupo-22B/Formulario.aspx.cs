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
        protected void Button1_Click(object sender, EventArgs e)
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