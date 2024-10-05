using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid; // SE INSTALARON ESTOS PAQUETES PARA QUE PUEDA ENVIAR POR MAIL (ENTRAR AL MANAGE NUGET)
using SendGrid.Helpers.Mail;


namespace negocio
{
    public class EnviarCorreoSendGrid
    {
        private const string API_KEY = "clave api"; // esto sale de SendGrid

        public static async Task EnviarCorreo(string emailDestino, string nombreCliente, string codigoVoucher)
        {
            try
            {
                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress("unMail@gmail.com", "Grupo 22B");
                var subject = "Confirmación de Participación - Promoción";
                var to = new EmailAddress(emailDestino, nombreCliente);
                var plainTextContent = $"Hola {nombreCliente},\n\nGracias por participar en nuestra promoción. Aquí está tu código de voucher: {codigoVoucher}. ¡Suerte!\n\nSaludos,\nEl equipo.";
                var htmlContent = $"<strong>Hola {nombreCliente},</strong><br><br>Gracias por participar en nuestra promoción. Aquí está tu código de voucher: <strong>{codigoVoucher}</strong>. ¡Suerte!<br><br>Saludos,<br>El equipo.";
                var mensaje = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(mensaje);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("Correo enviado correctamente.");
                }
                else
                {
                    Console.WriteLine($"Error al enviar el correo: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
        }
    }
}
