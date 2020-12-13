using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class BLLSalida
    {
        public static void InsertarSalida(VOSalida salida)
        {
            try
            {
                VOPersona capitan = new VOPersona(salida.IdCapitan, null, null, null, null, null, false, null);
                BLLPersona.Actualizar(capitan);
                VOBarco barco = new VOBarco(salida.IdBarco, null, null, null, null, null, null, false);
                BLLBarco.Actualizar(barco);
                DALSalida.InsertarSalida(salida);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al insertar el registro de salida");
            }
        }
        public static void FinalizarSalida(string idSalida)
        {
            try
            {
                int id = int.Parse(idSalida);
                DALSalida.FinalizarSalida(id, Enum.GetName(typeof(EstadoSalida), EstadoSalida.FINALIZADA));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al finalizar la salida");
            }
        }
        public static List<VOSalida> ConsultarSalidaPorEstado(string estado)
        {
            try
            {
                return DALSalida.ConsultarSalidaPorEstado(estado);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida");
            }
        }
        public static List<VOSalidaExtendida> ConsultarSalidaPorEstadoExtendida(string estado)
        {
            try
            {
                return DALSalida.ConsultarSalidaPorEstadoExtendida(estado);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida");
            }
        }
        public static VOSalidaExtendida ConsultarSalidaPorIdExtendida(string idSalida)
        {
            try
            {
                int id = int.Parse(idSalida);
                return DALSalida.ConsultarSalidaPorIdExtendida(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida");
            }
        }
        public static VOSalida ConsultarSalidaPorId(string idSalida)
        {

            try
            {
                int id = int.Parse(idSalida);
                return DALSalida.ConsultarSalidaPorId(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida");
            }
        }
        public enum EstadoSalida
        {
            EN_PROCESO,
            FINALIZADA
        }
    }
}
