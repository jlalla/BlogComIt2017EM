using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }    

        public ActionResult Contacto()
        {
            return View();                
        }

        [HttpPost]
        public ActionResult MailContacto(string nombre, string mail, string mensaje)
        {
            //Definimos la conexión al servidor SMTP que vamos a usar
            //para mandar el mail. Hay que buscarla en nuestro proveedor
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.Credentials = new NetworkCredential("testcomunidadit@gmail.com", "testcomit2017");
            clienteSmtp.EnableSsl = true;

            //Generamos el objeto MAIL a enviar
            MailMessage mailAEnviar = new MailMessage();
            mailAEnviar.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mailAEnviar.To.Add("testcomunidadit@gmail.com");
            mailAEnviar.Subject = "Te contactaron del blog!";
            mailAEnviar.Body = nombre + "(" + mail + ") te dejó un contacto en el blog. Su mensaje fue: " + mensaje;            

            //mandamos el mail
            clienteSmtp.Send(mailAEnviar);

            //vamos a mandarle un mail al usuario que nos dejó el contacto
            MailMessage mailAUsuario = new MailMessage();
            mailAUsuario.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mailAUsuario.To.Add(mail);
            mailAUsuario.Subject = "Gracias por contactarte con nosotros!";
            mailAUsuario.IsBodyHtml = true;
            mailAUsuario.Body = "Hola " + nombre + ", <br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + mail + "<br>Mensaje: " +mensaje+ "<br><br>Saludos!!!<br><b>Velez Blog</b><img src=\"http://www.losandes.com.ar/files/image/16/02/image56c3c893e34058.75676825.jpg\" />";

            clienteSmtp.Send(mailAUsuario);

            return View("Contacto");
        }
    }
}