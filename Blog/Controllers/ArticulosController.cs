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
        public ActionResult GuardarArticulo(string titulo, string imagen, string texto)
        {
            Articulo nuevoArticulo = new Articulo();
            //nuevoArticulo.ID = id;
            //nuevoArticulo.Fecha = DateTime.Now;
            nuevoArticulo.Titulo = titulo;
            nuevoArticulo.Imagen = imagen;
            nuevoArticulo.Texto = texto;
            nuevoArticulo.Autor = (Usuario)Session["UsuarioLogueado"];

            ArticulosManager manager = new ArticulosManager();
            manager.Insertar(nuevoArticulo);

            return RedirectToAction("Index", "Home");

            ////List<Articulo> listaArticulos = (List<Articulo>)Session["Articulos"];
            ////if(listaArticulos == null) 
            ////{
            ////    //es el primer artículo
            ////    listaArticulos = new List<Articulo>();
            ////}
            ////listaArticulos.Add(nuevoArticulo);
            ////Session["Articulos"] = listaArticulos;
        }
    }
}