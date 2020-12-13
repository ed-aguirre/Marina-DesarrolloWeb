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
    public class DALBarco
    {
        public static bool Insertar(VOBarco barco)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarBarco", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = barco.Matricula;
                cmd.Parameters.Add("@NoAmarre", SqlDbType.VarChar).Value = barco.NoAmarre;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = barco.Nombre;
                cmd.Parameters.Add("@Cuota", SqlDbType.Decimal).Value = barco.Cuota;
                cmd.Parameters.Add("@IdOwner", SqlDbType.Int).Value = barco.IdPersona;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = barco.UrlFoto;
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
        public static bool Eliminar(int idBarco)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarBarco", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IdBarco", SqlDbType.Int).Value = idBarco;
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
        public static VOBarco ConsultarBarco(int idBarco)
        {
            VOBarco barco = null;
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            SqlDataReader datos;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ConsultarBarco", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdBarco", SqlDbType.Int).Value = idBarco;
                datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    barco = new VOBarco(Convert.ToInt32(datos.GetValue(0).ToString()),
                        datos.GetValue(1).ToString(), datos.GetValue(2).ToString(),
                        datos.GetValue(3).ToString(), Convert.ToDouble(datos.GetValue(4).ToString()),
                        Convert.ToInt32(datos.GetValue(5).ToString()), datos.GetValue(7).ToString(),
                        Convert.ToBoolean(datos.GetValue(6).ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("no se pudo completar la busqueda "+ ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return barco;
        }
        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            List<VOBarco> lista = new List<VOBarco>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarBarcos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Barcos");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOBarco(registro));
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException("error al consultar barcos "+ ex.Message);
            }
            return lista;
        }
        public static List<VOBarco> ConsultarBarcoPorOwner(int idOwner, bool? disponibilidad)
        {
            List<VOBarco> lista = new List<VOBarco>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarBarcoPorOwner", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdOwner", SqlDbType.Bit).Value = idOwner;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Barcos");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VOBarco(registro));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar barcos" + ex.Message);
            }
            return lista;
        }
        public static bool Actualizar(VOBarco barco)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            int r = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_ActualizarBarco", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdBarco", SqlDbType.Int).Value = barco.IdBarco;
                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = barco.Matricula;
                cmd.Parameters.Add("@NoAmarre", SqlDbType.VarChar).Value = barco.NoAmarre;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = barco.Nombre;
                cmd.Parameters.Add("@Cuota", SqlDbType.Decimal).Value = barco.Cuota;
                cmd.Parameters.Add("@IdOwner", SqlDbType.Int).Value = barco.IdPersona;
                cmd.Parameters.Add("@UrlFoto", SqlDbType.VarChar).Value = barco.UrlFoto;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = barco.Disponibilidad;
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
