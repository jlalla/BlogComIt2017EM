﻿using Blog.Models;
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
        public ActionResult GuardarArticulo(string titulo, string imagen, 
            string texto, HttpPostedFileBase imagenFile)
        {
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.Titulo = titulo;
            nuevoArticulo.Imagen = imagen;
            nuevoArticulo.Texto = texto;
            nuevoArticulo.Autor = (Usuario)Session["UsuarioLogueado"];

            ArticulosManager manager = new ArticulosManager();
            nuevoArticulo = manager.Insertar(nuevoArticulo);

            if(imagenFile != null)
            {
                imagenFile.SaveAs(Server.MapPath("~/Content/images/articulos/" + nuevoArticulo.ID + ".png"));
            }

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

        public ActionResult Ver(long ID)
        {
            ArticulosManager manager = new ArticulosManager();
            Articulo articulo = manager.Consultar(ID);
            ViewBag.Articulo = articulo;
            return View();
        }
    }
}