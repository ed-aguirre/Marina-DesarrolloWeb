using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class DALSalida
    {
        public static void InsertarSalida(VOSalida salida)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarSalida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime).Value = salida.FechaHoraSalida;
                cmd.Parameters.Add("@Destino", SqlDbType.VarChar).Value = salida.Destino;
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = salida.Estado;
                cmd.Parameters.Add("@IdBarco", SqlDbType.Int).Value = salida.IdBarco;
                cmd.Parameters.Add("@IdCapitan", SqlDbType.Int).Value = salida.IdCapitan;
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
        public static void FinalizarSalida(int idSalida, string estado)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_FinalizarSalida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSalida", SqlDbType.Int).Value = idSalida;
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al finalizar el registro de salida: " + ex.Message);
            }
        }
        public static List<VOSalida> ConsultarSalidaPorEstado(string estado)
        {
            List<VOSalida> lista = new List<VOSalida>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarSalidasPorEstado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = estado;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Salidas");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOSalida(registro));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }
        public static List<VOSalidaExtendida> ConsultarSalidaPorEstadoExtendida(string estado)
        {
            List<VOSalidaExtendida> lista = new List<VOSalidaExtendida>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarSalidasPorEstadoExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = estado;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Salidas");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOSalidaExtendida(registro));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }
        public static VOSalidaExtendida ConsultarSalidaPorIdExtendida(int idSalida)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarSalidasPorIdExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSalida", SqlDbType.Int).Value = idSalida;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Salidas");
                return new VOSalidaExtendida(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }
        public static VOSalida ConsultarSalidaPorId(int idSalida)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarSalidasPorId", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSalida", SqlDbType.Int).Value = idSalida;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Salidas");
                return new VOSalida(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }
    }
}
