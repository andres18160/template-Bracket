using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCamiloAndresAgudelo.Entidades;

namespace WebAppCamiloAndresAgudelo.Pages
{
    public partial class facturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<EnFacturaSimple> GetAllFacturas()
        {

            var url = "http://localhost:64787/api/factura";
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(url);

            var releases = JsonConvert.DeserializeObject<List<EnFacturaSimple>>(response);

            return releases;

        }

        [WebMethod]
        public static List<EnCliente> GetAllClientes()
        {

            var url = "http://localhost:64787/api/cliente";
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(url);

            var releases = JsonConvert.DeserializeObject<List<EnCliente>>(response);

            return releases;

        }

        [WebMethod]
        public static List<EnEstado> GetAllEstados()
        {

            var url = "http://localhost:64787/api/estado";
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(url);

            var releases = JsonConvert.DeserializeObject<List<EnEstado>>(response);

            return releases;

        }
        [WebMethod]
        public static string CrearFactura(string Fecha, string Autoretenedor, string IdCliente, string IdEstado, string ValorTotal)
        {

            var url = "http://localhost:64787/api/factura";
            var client = new WebClient();
            EnFactura facturaEnvio = new EnFactura();
            facturaEnvio.NumeroFactura = 2;
            facturaEnvio.Fecha = Convert.ToDateTime(Fecha);
            facturaEnvio.Autoretenedor = Convert.ToBoolean(Autoretenedor);
            facturaEnvio.IdCliente = Convert.ToInt32(IdCliente);
            facturaEnvio.IdEstado = Convert.ToInt32(IdEstado);
            facturaEnvio.ValorTotal = Convert.ToInt32(ValorTotal);
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = client.UploadString(url, JsonConvert.SerializeObject(facturaEnvio));

            return response;

        }


        [WebMethod]
        public static string GrabarDetalle(string IdFactura,string Cantidad,string Descripcion,string ValorTotal,string ValorUnitario)
        {

            var url = "http://localhost:64787/api/detalle_factura";
            var client = new WebClient();
            EnDetalleFactura detalle = new EnDetalleFactura();
            detalle.IdFactura =Convert.ToInt32(IdFactura);
            detalle.Cantidad= Convert.ToInt32(Cantidad);
            detalle.Descripcion = Descripcion;
            detalle.ValorTotal = Convert.ToInt32(ValorTotal);
            detalle.ValorUnitario = Convert.ToInt32(ValorUnitario);


            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = client.UploadString(url, JsonConvert.SerializeObject(detalle));

            return response;

        }

        [WebMethod]
        public static EnFactura GetFactura(string Id)
        {
            var url = "http://localhost:64787/api/factura/"+ Id;
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(url);

            var releases = JsonConvert.DeserializeObject<EnFactura>(response);

            return releases;
        }

        [WebMethod]
        public static List<EnDetalleFactura> GetFacturaDetalle(string Id)
        {
            var url = "http://localhost:64787/api/detalle_factura/" + Id+ "/details";
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(url);

            var releases = JsonConvert.DeserializeObject<List<EnDetalleFactura>>(response);

            return releases;
        }

        [WebMethod]
        public static string ActualizarFactura(string NumeroFactura, string Fecha, string Autoretenedor, string IdCliente, string IdEstado, string ValorTotal)
        {
            var url = "http://localhost:64787/api/factura/"+ NumeroFactura;
            var client = new WebClient();
            EnFactura facturaEnvio = new EnFactura();
            facturaEnvio.NumeroFactura = Convert.ToInt32(NumeroFactura);
            facturaEnvio.Fecha = Convert.ToDateTime(Fecha);
            facturaEnvio.Autoretenedor = Convert.ToBoolean(Autoretenedor);
            facturaEnvio.IdCliente = Convert.ToInt32(IdCliente);
            facturaEnvio.IdEstado = Convert.ToInt32(IdEstado);
            facturaEnvio.ValorTotal = Convert.ToInt32(ValorTotal);
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = client.UploadString(url,"PUT", JsonConvert.SerializeObject(facturaEnvio));
            return response;
        }

        [WebMethod]
        public static string ActualizarDetalle(string IdFactura, string Cantidad, string Descripcion, string ValorTotal, string ValorUnitario)
        {

            EnDetalleFactura detalle = new EnDetalleFactura();
            detalle.IdFactura = Convert.ToInt32(IdFactura);
            detalle.Cantidad = Convert.ToInt32(Cantidad);
            detalle.Descripcion = Descripcion;
            detalle.ValorTotal = Convert.ToInt32(ValorTotal);
            detalle.ValorUnitario = Convert.ToInt32(ValorUnitario);

            var urlDelete = "http://localhost:64787/api/detalle_factura/"+IdFactura;

            var urlInsert = "http://localhost:64787/api/detalle_factura";
            var clientDelete = new WebClient();
            var client = new WebClient();
            clientDelete.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            clientDelete.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = clientDelete.UploadString(urlDelete, "DELETE", "");

            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            response = client.UploadString(urlInsert,JsonConvert.SerializeObject(detalle));

            return response;

        }

    }
}