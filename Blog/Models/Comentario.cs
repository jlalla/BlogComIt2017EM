using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comentario
    {
        public long ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public Usuario Autor { get; set; } 
        public Articulo Articulo { get; set; }       //generalmente no es necesario
    }
}