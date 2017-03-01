using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    /// <summary>
    /// Entidad que representa a los artículos del Blog
    /// </summary>
    public class Articulo
    {
        public long ID { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        //autor... comentarios...
    }
}