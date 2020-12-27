using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class BLLTramite
    {
        public static void InsertarTramite(VOTramite tramite)
        {
            try
            {
                DALTramite.InsertarRenta(tramite);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al insertar el registro tramite: "+ ex.Message);
            }
        }
        public static void FinalizarDevolucion(String idTramite)
        {
            try
            {
                int id = int.Parse(idTramite);
                DALTramite.FinalizarDevolucion(id, Enum.GetName(typeof(TipoTramite), TipoTramite.DEVOLUCION_COMPLETADA));
            }catch(Exception ex)
            {
                throw new ArgumentException("Error al finalizar devolucion: " + ex.Message);
            }
        }
        public static List<VOTramiteExtendida> ConsultarTramitePorTipoExtendida(string tipoTramite)
        {
            try
            {
                return DALTramite.ConsultarTramitePorTipoExtendida(tipoTramite);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar tramite: "+ex.Message);
            }
        }
        public static VOTramiteExtendida ConsultarTramitePorIdExtendida(string idTramite)
        {
            try
            {
                int id = int.Parse(idTramite);
                return DALTramite.ConsultarTramitePorIdExtendida(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el tramite");
            }
        }
        public static VOTramite ConsultarTramitePorId(string idTramite)
        {
            try
            {
                int id = int.Parse(idTramite);
                return DALTramite.ConsultarTramitePorId(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar tramite");
            }
        }
        public enum TipoTramite
        {
            EN_RENTA,
            DEVOLUCION_COMPLETADA
        }
    }
}
