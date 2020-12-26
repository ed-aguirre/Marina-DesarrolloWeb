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
    public class DALAuto
    {
        public static bool Insertar(VOAuto auto)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarAuto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = auto.Matricula;
                cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = auto.Marca;
                cmd.Parameters.Add("@Anio", SqlDbType.VarChar).Value = auto.Anio;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = auto.UrlFoto;
                r = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new ArgumentException("no se pudo insertar el dato en la base de datos" + ex.Message);

            }
            finally
            {
                cnn.Close();
            }
            if (r == 1)
                return true;
            else
                return false;
        }
        public static bool Eliminar(int idAuto)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarAuto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IdAuto", SqlDbType.Int).Value = idAuto;
                r = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new ArgumentException("no se pudo eliminar el registro");
            }
            finally
            {
                cnn.Close();
            }
            if (r == 1)
                return true;
            else
                return false;
        }
        public static VOAuto ConsultarAuto(int idAuto)
        {
            VOAuto auto = null;
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            SqlDataReader datos;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ConsultarAuto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = idAuto;
                datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    auto = new VOAuto(
                        Convert.ToInt32(datos.GetValue(0).ToString()),
                        datos.GetValue(1).ToString(), 
                        datos.GetValue(2).ToString(),
                        datos.GetValue(3).ToString(),
                        Convert.ToBoolean(datos.GetValue(4).ToString()),
                        datos.GetValue(5).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo completar la busqueda " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return auto;
        }
        public static List<VOAuto> ConsultarAutos(bool? disponibilidad)
        {
            List<VOAuto> lista = new List<VOAuto>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarAutos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Autos");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOAuto(registro));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("error al consultar autos " + ex.Message);
            }
            return lista;
        }
        public static List<VOAuto> ConsultarBarcoPorPersona(int idPersona, bool? disponibilidad)
        {
            List<VOAuto> lista = new List<VOAuto>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarAutoPorPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Bit).Value = idPersona;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Autos");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOAuto(registro));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar barcos" + ex.Message);
            }
            return lista;
        }
        public static bool Actualizar(VOAuto auto)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ActualizarAuto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = auto.IdAuto;
                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = auto.Matricula;
                cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = auto.Marca;
                cmd.Parameters.Add("@Anio", SqlDbType.VarChar).Value = auto.Anio;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = auto.Disponibilidad;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = auto.UrlFoto;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo actualizar el dato en la base de datos " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            if (r == 1)
                return true;
            else
                return false;
        }
    }
}
