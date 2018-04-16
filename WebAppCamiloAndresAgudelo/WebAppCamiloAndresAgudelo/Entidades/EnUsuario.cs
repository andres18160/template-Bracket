using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Entidades
{
    public class EnUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
    }
}