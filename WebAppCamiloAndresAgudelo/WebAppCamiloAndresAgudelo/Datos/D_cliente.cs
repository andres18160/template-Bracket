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
    public class D_cliente
    {
        /// <summary>
        /// Metodo encargado de validar si un cliente tiene facturas vinculadas, si tiene facturas retorna verdadero; de lo contrario retorna falso
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool ValidarCliente(EnCliente cliente)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ValidarCliente";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Id", cliente.Id);
                int exist = Convert.ToInt16(ocmd.ExecuteScalar().ToString());
                if (exist > 0)
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
        /// <summary>
        /// Metodo encargado de validar si un cliente Existe retorna true si el cliente existe de lo contrario retorna false
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool ValidarClienteExiste(EnCliente cliente)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ValidarClienteExiste";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Cedula", cliente.cedula);
                int exist = Convert.ToInt16(ocmd.ExecuteScalar().ToString());
                if (exist > 0)
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
        /// <summary>
        /// Metodo encargado de consultar la informacion de un cliente por medio del Id devuelve un objeto de tipo EnCLiente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public EnCliente ConsultarCliente(EnCliente cliente)
        {
            try
            {

                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ConsultarUsuario";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Id", cliente.Id);
                SqlDataAdapter oda = new SqlDataAdapter(ocmd);
                DataTable registro = new DataTable();
                oda.Fill(registro);

                if (registro.Rows.Count > 0)
                {
                    cliente.Nombre = registro.Rows[0]["Nombre"].ToString();
                    cliente.Apellidos = registro.Rows[0]["Apellidos"].ToString();
                    cliente.cedula = registro.Rows[0]["Cedula"].ToString();
                    cliente.Direccion = registro.Rows[0]["Direccion"].ToString();
                    cliente.Telefono = registro.Rows[0]["Telefono"].ToString();
                    return cliente;
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

        /// <summary>
        /// Meotdo encargado de obtener toda la lista de clientes registrados en el sistem
        /// </summary>
        /// <returns></returns>
        public List<EnCliente> ConsultarClientes()
        {
            try
            {
                List<EnCliente> listClientes = new List<EnCliente>();

                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ConsultarClientes";
                ocmd.Connection = oconexion.conectar();
                SqlDataAdapter oda = new SqlDataAdapter(ocmd);
                DataTable registro = new DataTable();
                oda.Fill(registro);

                foreach (DataRow item in registro.Rows)
                {
                    listClientes.Add(new EnCliente
                    {
                        Id = Convert.ToInt32(item["Id"].ToString()),
                        Nombre = item["Nombre"].ToString(),
                        Apellidos = item["Apellidos"].ToString(),
                        cedula = item["cedula"].ToString(),
                        Direccion = item["Direccion"].ToString(),
                        Telefono = item["Telefono"].ToString(),
                    });
                }
                return listClientes;


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

        public bool EliminarCliente(int Id)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "EliminarCliente";
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

        public bool ActualizarCliente(EnCliente cliente)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "ActualizarCliente";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Id", cliente.Id);
                ocmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                ocmd.Parameters.AddWithValue("@Apellido", cliente.Apellidos);
                ocmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                ocmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
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

        public bool CrearCliente(EnCliente cliente)
        {
            try
            {
                D_Conexion oconexion = new D_Conexion();
                SqlCommand ocmd = new SqlCommand();
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "CrearCliente";
                ocmd.Connection = oconexion.conectar();
                ocmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                ocmd.Parameters.AddWithValue("@Apellido", cliente.Apellidos);
                ocmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                ocmd.Parameters.AddWithValue("@Cedula", cliente.cedula);
                ocmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
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