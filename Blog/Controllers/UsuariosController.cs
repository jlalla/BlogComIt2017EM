using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(string email, string password)
        {
            UsuariosManager manager = new UsuariosManager();
            Usuario usuario = manager.Validar(email, password);
            if(usuario != null)
            {
                //ESTÁ BIEN
                Session["UsuarioLogueado"] = usuario;
            }
            else
            {
                //EL USUARIO NO EXISTE O ESTA MAL LA CONTRASEÑA
                TempData["Error"] = "El usuario no existe o está mal la contraseña";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["UsuarioLogueado"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}