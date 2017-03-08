using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Usuario
    {
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Imagen { get; set; }
    }
}