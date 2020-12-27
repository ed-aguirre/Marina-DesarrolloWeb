using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOTramite
    {
        private int idTramite;
        private DateTime fechaHoraOperacion;
        private double monto;
        private int idAuto;
        private String matricula;
        private string nombreCliente;
        private int idPersona;
        private String tipoTramite;
        private string urlFotoAuto;
        private string urlFotoCliente;

        public VOTramite( DateTime fechaHoraOperacion, double monto, int idAuto, int idPersona, string tipoTramite)
        {
            this.fechaHoraOperacion = fechaHoraOperacion;
            this.monto = monto;
            this.idAuto = idAuto;
            this.idPersona = idPersona;
            this.tipoTramite = tipoTramite;
        }
        public VOTramite()
        {
            this.idTramite = 0;
            this.fechaHoraOperacion = DateTime.Now;
            this.monto = 0.00;
            this.idAuto = 0;
            this.idPersona = 0;
            this.tipoTramite = "";
        }
        public VOTramite(DataRow dr)
        {
            this.idTramite = int.Parse(dr["IdTramite"].ToString());
            this.fechaHoraOperacion = DateTime.Parse(dr["FechaHoraOperacion"].ToString());
            this.monto = double.Parse(dr["Monto"].ToString());
            this.matricula = dr["Matricula"].ToString();
            this.nombreCliente = dr["NombreCliente"].ToString();
            this.tipoTramite = dr["TipoTramite"].ToString();
            this.urlFotoAuto = dr["UrlFotoAuto"].ToString();
            this.urlFotoCliente = dr["UrlFotoCliente"].ToString();
        }
        public int IdTramite { get => idTramite; set => idTramite = value; }
        public DateTime FechaHoraOperacion { get => fechaHoraOperacion; set => fechaHoraOperacion = value; }
        public double Monto { get => monto; set => monto = value; }
        public int IdAuto { get => idAuto; set => idAuto = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string TipoTramite { get => tipoTramite; set => tipoTramite = value; }
    }
}
