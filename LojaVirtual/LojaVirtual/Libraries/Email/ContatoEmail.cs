
using System.Net.Mail;
using System.Net;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {

        public static void EnviarContatoPorEmail(Contato contato)
        {

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("carlosoliveira121@gmail.com", "");

            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +

            "<b>Nome: </b> {0} <br />" +

            "<b>E-mail: </b> {1} <br />" +

            "<b>Texto: </b> {2} <br />" +

            "<br /> E-mail enviado automaticamente do site LojaVirtual.",

            contato.Nome,

            contato.Email,

            contato.Texto

            );

            /*

            * MailMessage -> Construir a mensagem

            */

            MailMessage mensagem = new MailMessage();

            mensagem.From = new MailAddress("carlosoliveira121@gmail.com");

            mensagem.To.Add("carlosoliveira121@gmail.com");

            mensagem.Subject = "Contato - LojaVirtual - E-mail: " + contato.Email;

            mensagem.Body = corpoMsg;

            mensagem.IsBodyHtml = true;

            //Enviar Mensagem via SMTP

            smtp.Send(mensagem);

        }

    }

}

