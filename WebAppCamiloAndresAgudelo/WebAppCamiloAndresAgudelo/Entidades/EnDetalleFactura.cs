using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Entidades
{
    public class EnDetalleFactura
    {
        public int Id { get; set; }
        public Nullable<int> IdFactura { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> ValorUnitario { get; set; }
        public Nullable<double> ValorTotal { get; set; }
    }
}