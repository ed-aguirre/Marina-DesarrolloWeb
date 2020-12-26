using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DALPersona
    {
        public static void Insertar(VOPersona persona)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = persona.Correo;
                cmd.Parameters.Add("@Cargo", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = persona.UrlFoto;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo insertar el dato en la base de datos " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public static void Actualizar(VOPersona persona)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ActualizarPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = persona.IdPersona;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = persona.Correo;
                cmd.Parameters.Add("@Cargo", SqlDbType.Int).Value = persona.Cargo;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = persona.UrlFoto;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = persona.Disponibilidad;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo actualizar el registro en la base de datos " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public static void EliminarPersona(int idPersona)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo actualizar el registro en la base de datos " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public static VOPersona ConsultarPersona(int idPersona)
        {
            VOPersona persona = null;
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            SqlDataReader datos;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ConsultarPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;
                datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    persona = new VOPersona(Convert.ToInt32(datos.GetValue(0).ToString()),
                        datos.GetValue(1).ToString(), datos.GetValue(2).ToString(),
                        datos.GetValue(3).ToString(), datos.GetValue(4).ToString(),
                        Convert.ToInt32(datos.GetValue(5).ToString()),
                        Convert.ToBoolean(datos.GetValue(6).ToString()), datos.GetValue(7).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo completar la busqueda");
            }
            finally
            {
                cnn.Close();
            }
            return persona;
        }
        public static List<VOPersona> ConsultarPersonasPorCargo(int cargo, bool? disponibilidad)
        {
            List<VOPersona> lista = new List<VOPersona>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand("SP_ConsultarPersonasPorCargo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cargo", SqlDbType.Int).Value = cargo;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Personas");
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    lista.Add(new VOPersona(fila));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Persona: " + ex.Message);
            }
        }
        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            List<VOPersona> lista = new List<VOPersona>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand("SP_ConsultarPersonas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Personas");
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    lista.Add(new VOPersona(fila));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Persona: " + ex.Message);
            }
        }
    }
}
