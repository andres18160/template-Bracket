using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Entidades
{
    public class EnFacturaSimple
    {
        public int NumeroFactura { get; set; }
        public string NombreCliente { get; set; }
        public string Fecha { get; set; }
        public bool Autoretenedor { get; set; }
        public string Estado { get; set; }
        public float ValorTotal { get; set; }
    }
}