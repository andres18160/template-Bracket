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
    public partial class login : System.Web.UI.Page
    {

        private D_usuario Dusuario;
        private EnUsuario Eusuario=new EnUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["inicio"] = null;
            Session["clave"] = null;
            Eusuario = null;
        }


        //[WebMethod]
        //public static string ValidarUsuario(string usuario,string clave)
        //{
        //    return "ok";
        //}

        protected void bntLogin_Click(object sender, EventArgs e)
        {
            Dusuario = new D_usuario();
            Eusuario = new EnUsuario();

            Eusuario.Usuario = txtUsuario.Text;
            Eusuario.Password = txtclave.Text;

            if (Dusuario.validarUsuario(Eusuario))
            {
                Session["usuario"] = txtUsuario.Text;
                Session["clave"] = txtclave.Text;
                Response.Redirect("index.aspx");
            }
            else
                lblMensaje.Text = "Usuario o contraseña invalidos!";



        }
    }
}