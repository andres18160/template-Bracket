using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCamiloAndresAgudelo.Datos;
using WebAppCamiloAndresAgudelo.Entidades;

namespace WebAppCamiloAndresAgudelo.Pages
{
    public partial class clientes : System.Web.UI.Page
    {
        private static List<EnCliente> listClientes;
        private static D_cliente Dcliente;
        private static EnCliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }

            }
        }


        [WebMethod]
        public static List<EnCliente> CargarClientes()
        {
              Dcliente = new D_cliente();
              listClientes = Dcliente.ConsultarClientes();

            return listClientes;
        }

        [WebMethod]
        public static string EliminarCliente(int Id)
        {
            Dcliente = new D_cliente();
            if (Dcliente.EliminarCliente(Id))
                return "OK";
            else
                return "NO";
        }

        [WebMethod]
        public static string ActualizarCliente(int Id, string Nombre, string Apellido, string Direccion, string Telefono, string Cedula)
        {
            cliente = new EnCliente();
            cliente.Id = Id;
            cliente.Nombre = Nombre;
            cliente.Apellidos = Apellido;
            cliente.Direccion = Direccion;
            cliente.Telefono = Telefono;
            cliente.cedula = Cedula;


            Dcliente = new D_cliente();
            if (Dcliente.ActualizarCliente(cliente))
                return "OK";
            else
                return "NO";
        }

        [WebMethod]
        public static string CrearCliente(string Nombre, string Apellido, string Direccion, string Telefono, string Cedula)
        {
            cliente = new EnCliente();
            cliente.Nombre = Nombre;
            cliente.Apellidos = Apellido;
            cliente.Direccion = Direccion;
            cliente.Telefono = Telefono;
            cliente.cedula = Cedula;


            Dcliente = new D_cliente();
            if (Dcliente.ValidarClienteExiste(cliente))
                return "EXISTE";
            if (Dcliente.CrearCliente(cliente))
                return "OK";
            else
                return "NO";
        }

    }
}