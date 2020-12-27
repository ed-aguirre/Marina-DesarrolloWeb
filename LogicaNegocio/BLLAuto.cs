using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class BLLAuto
    {
        public static void Insertar(VOAuto auto)
        {
            try
            {
                DALAuto.Insertar(auto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("error al insertar el registro: "+ex.Message);
            }
        }
        public static void Eliminar(string idAuto)
        {
            try
            {
                DALAuto.Eliminar(int.Parse(idAuto));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("errores al eliminar el registro: "+ex.Message);
            }
        }
        public static void Actualizar(VOAuto auto)
        {
            try
            {
                DALAuto.Actualizar(auto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar el registro " + ex.Message);
            }
        }
        public static List<VOAuto> ConsultarAutos(bool? disponibilidad)
        {
            List<VOAuto> autos = null;
            try
            {
                autos = DALAuto.ConsultarAutos(disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro " + ex.Message);
            }
            return autos;
        }
        public static VOAuto ConsultarAuto(string idAuto)
        {
            VOAuto auto = null;
            try
            {
                auto = DALAuto.ConsultarAuto(int.Parse(idAuto));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro " + ex.Message);
            }
            return auto;
        }
        public static List<VOAuto> ConsultarAutoPorPersona(string idPersona, bool? disponibilidad)
        {
            List<VOAuto> autos = null;
            try
            {
                autos = DALAuto.ConsultarAutoPorPersona(int.Parse(idPersona), disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro" + ex.Message);
            }
            return autos;
        }
    }
}
