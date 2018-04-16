using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCamiloAndresAgudelo.Datos;
using WebAppCamiloAndresAgudelo.Entidades;

namespace WebAppCamiloAndresAgudelo.Pages
{
    public partial class index : System.Web.UI.Page
    {
       
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
    }
}