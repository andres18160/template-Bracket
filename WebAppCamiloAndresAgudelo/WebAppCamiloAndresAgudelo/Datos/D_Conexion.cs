using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppCamiloAndresAgudelo.Datos
{
    public class D_Conexion
    {
        public SqlConnection conectar()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conexion"]);
                conn.Open();
                return conn;
            }
            catch (SqlException errorsql)
            {
                throw new Exception("error DB= "+ errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }
    }
}