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
    public partial class usuarios_admin : System.Web.UI.Page
    {
        private static EnUsuario usuario;
        private static List<EnUsuario> listUsuarios;
        private static D_usuario Dusuario;
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
        public static List<EnUsuario> CargarUsuarios()
        {
            Dusuario = new D_usuario();
            listUsuarios = Dusuario.ConsultarUsuarios();

            return listUsuarios;
        }

        [WebMethod]
        public static string EliminarUsuario(int Id)
        {
            Dusuario = new D_usuario();
            if (Dusuario.EliminarUsuario(Id))
                return "OK";
            else
                return "NO";
        }

        [WebMethod]
        public static string ActualizarUsuario(int Id, string Nombre, string Usuario, string Password)
        {
            usuario = new EnUsuario();
            usuario.Nombre = Nombre;
            usuario.Usuario = Usuario;
            usuario.Password = Password;
            usuario.Id = Id;

            Dusuario = new D_usuario();
            if (Dusuario.ActualizarUsuario(usuario))
                return "OK";
            else
                return "NO";
        }
       

        [WebMethod]
        public static string CrearUsuario(string Nombre,string Usuario,string Password)
        {
            usuario = new EnUsuario();
            usuario.Nombre = Nombre;
            usuario.Usuario = Usuario;
            usuario.Password = Password;
            Dusuario = new D_usuario();
            
                if (Dusuario.validarUsuario(usuario))
                    return "Usuario ya existe";

                if (Dusuario.CrearUsuario(usuario))
                    return "OK";
                else return "NO";
           
           
        }
    }
}