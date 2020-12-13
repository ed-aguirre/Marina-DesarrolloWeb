using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOSalida
    {
        private int idSalida;
        private DateTime fechaHoraSalida;
        private string destino;
        private string estado;
        private int idBarco;
        private int idCapitan;

        #region Constructores
        public VOSalida(DateTime fechaHoraSalida, string destino, string estado, int idBarco, int idCapitan)
        {
            FechaHoraSalida = fechaHoraSalida;
            Destino = destino;
            Estado = estado;
            IdBarco = idBarco;
            IdCapitan = idCapitan;
        }
        public VOSalida()
        {
            IdSalida = 0;
            FechaHoraSalida = DateTime.Now;
            Destino = "";
            Estado = "";
            IdBarco = 0;
            IdCapitan = 0;
        }
        public VOSalida(DataRow dr)
        {
            IdSalida = int.Parse(dr["IdSalida"].ToString());
            FechaHoraSalida = DateTime.Parse(dr["FechaHoraSalida"].ToString());
            Destino = dr["Destino"].ToString();
            Estado = dr["Estado"].ToString();
            IdBarco = int.Parse(dr["IdBarco"].ToString());
            IdCapitan = int.Parse(dr["IdPersona"].ToString());
        }
        #endregion

        #region Propiedades
        public int IdSalida
        {
            get
            {
                return idSalida;
            }

            set
            {
                idSalida = value;
            }
        }

        public DateTime FechaHoraSalida
        {
            get
            {
                return fechaHoraSalida;
            }

            set
            {
                fechaHoraSalida = value;
            }
        }

        public string Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int IdBarco
        {
            get
            {
                return idBarco;
            }

            set
            {
                idBarco = value;
            }
        }

        public int IdCapitan
        {
            get
            {
                return idCapitan;
            }

            set
            {
                idCapitan = value;
            }
        }
        #endregion
    }
}
