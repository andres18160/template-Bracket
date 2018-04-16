using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCamiloAndresAgudelo.Datos;
using WebAppCamiloAndresAgudelo.Entidades;

namespace WebAppCamiloAndresAgudelo.MasterPages
{
    public partial class Master : System.Web.UI.MasterPage
    {

        private EnUsuario usuario = new EnUsuario();
        private D_usuario Dusuario = new D_usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
            usuario.Usuario = Session["usuario"].ToString();
            usuario.Password = Session["clave"].ToString();
            usuario = Dusuario.ConsultarUsuario(usuario);
            if (usuario != null)
            {
                lblNombre.Text = usuario.Nombre;
                lblNombre2.Text = usuario.Nombre;
                lblusuario.Text = usuario.Usuario;
            }
        }

    }
}