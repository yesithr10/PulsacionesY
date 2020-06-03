using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Entity;

namespace Infraestructura
{
    public class Email
    {
        private MailMessage email;
        private SmtpClient smtp;

        public Email()
        {
            smtp = new SmtpClient();
        }
        private void ConfigurarSmt() {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("yesithm72@gmail.com", "2305f3e6");
        }
        private void ConfigurarEmail(Persona persona) {
            email = new MailMessage();

            email.To.Add(persona.Email);

            email.From = new MailAddress("yesithm72@gmail.com");

            email.Subject = "Orlando Rojano Registro de Usuario "

            + DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");

            email.Body = $"<b>Sr {persona.Nombre }</b> <br " +

            $" > se ha realizado su registro Sartisfactoriamente";

            email.IsBodyHtml = true;

            email.Priority = MailPriority.Normal;
        }
        public string EnviarEmail(Persona persona)
        {
            try

            {

                ConfigurarSmt();

                ConfigurarEmail(persona);

                smtp.Send(email);

                return ("Correo enviado Satifactoriamente");

            }

            catch (Exception e)

            {

                return ("error al enviar correo" + e.Message);

            }

            finally

            {

                email.Dispose();
            }

        }
    }
}
