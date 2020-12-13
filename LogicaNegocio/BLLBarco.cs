using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class BLLBarco
    {
        public static void Insertar(VOBarco barco)
        {
            try
            {
                DALBarco.Insertar(barco);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("erros al insertat el registro");
            }
        }
        public static void Eliminar(string idBarco)
        {
            try
            {
                DALBarco.Eliminar(int.Parse(idBarco));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("errores al eliminar el registro");
            }
        }
        public static void Actualizar(VOBarco barco)
        {
            try
            {
                DALBarco.Actualizar(barco);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar el registro "+ ex.Message);
            }
        }
        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            List<VOBarco> barcos = null;
            try
            {
                barcos = DALBarco.ConsultarBarcos(disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro " +ex.Message);
            }
            return barcos;
        }
        public static VOBarco ConsultarBarco(string idBarco)
        {
            VOBarco barco = null;
            try
            {
                barco = DALBarco.ConsultarBarco(int.Parse(idBarco));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro " + ex.Message);
            }
            return barco;
        }
        public static List<VOBarco> ConsultarBarcosPorOwner(string idOwner, bool? disponibilidad)
        {
            List<VOBarco> barcos = null;
            try
            {
                barcos = DALBarco.ConsultarBarcoPorOwner(int.Parse(idOwner), disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro"+ ex.Message);
            }
            return barcos;
        }
    }
}
