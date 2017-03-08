using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticulosController : Controller
    {
        [HttpPost]
        public ActionResult GuardarArticulo(int id, string titulo, string imagen, string texto)
        {
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.ID = id;
            nuevoArticulo.Titulo = titulo;
            nuevoArticulo.Imagen = imagen;
            nuevoArticulo.Texto = texto;

            //Session["Articulo"] = nuevoArticulo;

            List<Articulo> listaArticulos = (List<Articulo>)Session["Articulos"];
            if(listaArticulos == null) 
            {
                //es el primer artículo
                listaArticulos = new List<Articulo>();
            }
            listaArticulos.Add(nuevoArticulo);
            Session["Articulos"] = listaArticulos;

            return RedirectToAction("Index", "Home");
        }
    }
}