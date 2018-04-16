using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebAppCamiloAndresAgudelo.Entidades;

namespace WebAppCamiloAndresAgudelo.Datos
{
    public class D_usuario
    {
        public bool validarUsuario(EnUsuario usuario)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ValidarUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                ocmd.Parameters.AddWithValue("@Password", usuario.Password);
                int exist = Convert.ToInt16(ocmd.ExecuteScalar().ToString());
                if (exist == 1)
                    return true;
                else
                    return false;
            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

        public EnUsuario ConsultarUsuario(EnUsuario usuario)
        {
            try
            {

                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ConsultarUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                ocmd.Parameters.AddWithValue("@Password", usuario.Password);
                SqlDataAdapter oda = new SqlDataAdapter(ocmd);
                DataTable registro = new DataTable();
                oda.Fill(registro);

                if (registro.Rows.Count > 0)
                {
                    usuario.Nombre = registro.Rows[0]["Nombre"].ToString();
                    return usuario;
                }
                else
                    return null;
            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

        public List<EnUsuario> ConsultarUsuarios()
        {
            try
            {
                List<EnUsuario> listUsuarios = new List<EnUsuario>();

                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ConsultarUsuarios";
                ocmd.Connection = oconexion.conectar();
                SqlDataAdapter oda = new SqlDataAdapter(ocmd);
                DataTable registro = new DataTable();
                oda.Fill(registro);

                foreach (DataRow item in registro.Rows)
                {
                    listUsuarios.Add(new EnUsuario
                    {
                        Id = Convert.ToInt32(item["Id"].ToString()),
                        Nombre = item["Nombre"].ToString(),
                        Password = item["Password"].ToString(),
                        Usuario = item["Usuario"].ToString()
                    });
                }
                return listUsuarios;


            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

        public bool EliminarUsuario(int Id)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "EliminarUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Id", Id);
                int result = ocmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

        public bool ActualizarUsuario(EnUsuario usuario)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ActualizarUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Id", usuario.Id);
                ocmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                ocmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                ocmd.Parameters.AddWithValue("@Password", usuario.Password);
                int result = ocmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

        public bool CrearUsuario(EnUsuario usuario)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "CrearUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                ocmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                ocmd.Parameters.AddWithValue("@Password", usuario.Password);
                int result = ocmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException errorsql)
            {
                Debug.WriteLine("Error SQL= " + errorsql.Message);
                throw new Exception("error DB= " + errorsql.Message);
            }
            catch (Exception errorlenguaje)
            {
                Debug.WriteLine("Error Lenguaje= " + errorlenguaje.Message);
                throw new Exception("Error De Lenguaje=" + errorlenguaje.Message);
            }
        }

    }
}