using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Entidades
{
    public class EnCliente
    {
        //Id, Nombre, Apellidos, Direccion, Telefono, Cedula
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string cedula { get; set; }

    }
}