using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOBarco
    {
        private int idBarco;
        private string matricula;
        private string noAmarre;
        private String nombre;
        private double? cuota;
        private int? idPersona;
        private string urlFoto;
        private bool? disponibilidad;

        public VOBarco(int idBarco, string matricula, string noAmarre, string nombre, double? cuota, int? idPersona, string urlFoto, bool? disponibilidad)
        {
            this.IdBarco = idBarco;
            this.Matricula = matricula;
            this.NoAmarre = noAmarre;
            this.Nombre = nombre;
            this.Cuota = cuota;
            this.IdPersona = idPersona;
            this.UrlFoto = urlFoto;
            this.Disponibilidad = disponibilidad;
        }
        public VOBarco(string matricula, string noAmarre, string nombre, double cuota, int idPersona, string urlFoto, bool disponibilidad)
        {
            this.Matricula = matricula;
            this.NoAmarre = noAmarre;
            this.Nombre = nombre;
            this.Cuota = cuota;
            this.IdPersona = idPersona;
            this.UrlFoto = urlFoto;
            this.Disponibilidad = disponibilidad;
        }
        public VOBarco(DataRow fila)
        {
            IdBarco = int.Parse(fila["IdBarco"].ToString());
            this.Matricula = (fila["Matricula"].ToString());
            this.NoAmarre = (fila["NoAmarre"].ToString());
            this.Nombre = (fila["Nombre"].ToString());
            this.Cuota = double.Parse(fila["Cuota"].ToString());
            this.IdPersona = int.Parse(fila["IdOwner"].ToString());
            this.UrlFoto = fila["UrlFoto"].ToString();
            this.Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
        }

        public int IdBarco { get => idBarco; set => idBarco = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string NoAmarre { get => noAmarre; set => noAmarre = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double? Cuota { get => cuota; set => cuota = value; }
        public int? IdPersona { get => idPersona; set => idPersona = value; }
        public string UrlFoto { get => urlFoto; set => urlFoto = value; }
        public bool? Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
    }
}
