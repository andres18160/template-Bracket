using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Entidades
{
    public class EnFactura
    {
        //NumeroFactura, Fecha, Autoretenedor, IdEstado, IdCliente, ValorTotal
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Autoretenedor { get; set; }
        public int IdEstado { get; set; }
        public int IdCliente { get; set; }
        public int ValorTotal { get; set; }
    }
}