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
    public class DALTramite
    {
        public static void InsertarRenta(VOTramite tramite)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarRenta", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaHoraOperacion", SqlDbType.DateTime).Value = tramite.FechaHoraOperacion;
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = tramite.Monto;
                cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = tramite.IdAuto;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = tramite.IdPersona;
                cmd.Parameters.Add("@TipoTramite", SqlDbType.VarChar).Value = tramite.TipoTramite;
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
        public static void FinalizarDevolucion(int idTramite, string tipoTramite)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_FinalizarDevolucion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Value = idTramite;
                cmd.Parameters.Add("@TipoTramite", SqlDbType.VarChar).Value = tipoTramite;
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al finalizar el registro de salida: " + ex.Message);
            }
        }
        public static List<VOTramiteExtendida> ConsultarTramitePorTipoExtendida(string tipoTramite)
        {
            List<VOTramiteExtendida> tramite = new List<VOTramiteExtendida>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarTramitePorTipoExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TipoTramite", SqlDbType.VarChar).Value = tipoTramite;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tramites");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    tramite.Add(new VOTramiteExtendida(registro));
                }
                return tramite;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de tramites: " + ex.Message);
            }
        }
        public static VOTramiteExtendida ConsultarTramitePorIdExtendida(int idTramite)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarTramitePorIdExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Value = idTramite;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tramites");
                return new VOTramiteExtendida(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Tramites: " + ex.Message);
            }
        }
        public static VOTramite ConsultarTramitePorId(int idTramite)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarTramitePorId", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Value = idTramite;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tramites");
                return new VOTramite(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Tramite: " + ex.Message);
            }
        }
    }
}
