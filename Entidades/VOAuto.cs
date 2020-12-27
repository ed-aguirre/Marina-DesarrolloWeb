using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOAuto
    {
        private int idAuto;
        private String matricula;
        private String marca;
        private String anio;
        private bool? disponibilidad;
        private String urlFoto;

        public VOAuto(int idAuto, string matricula, string marca, string anio, bool? disponibilidad, string urlFoto)
        {
            this.idAuto = idAuto;
            this.matricula = matricula;
            this.marca = marca;
            this.anio = anio;
            this.disponibilidad = disponibilidad;
            this.urlFoto = urlFoto;
        }
        public VOAuto(int idAuto, string matricula, string marca, string anio, bool disponibilidad, string urlFoto)
        {
            this.idAuto = idAuto;
            this.matricula = matricula;
            this.marca = marca;
            this.anio = anio;
            this.disponibilidad = disponibilidad;
            this.urlFoto = urlFoto;
        }
        public VOAuto(string matricula, string marca, string anio, bool disponibilidad, string urlFoto)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.anio = anio;
            this.disponibilidad = disponibilidad;
            this.urlFoto = urlFoto;
        }
        public VOAuto(DataRow fila)
        {
            IdAuto= int.Parse(fila["IdAuto"].ToString());
            this.Matricula = (fila["Matricula"].ToString());
            this.Marca = (fila["Marca"].ToString());
            this.Anio = (fila["Anio"].ToString());
            this.Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
            this.UrlFoto = fila["UrlFoto"].ToString();
        }
        public int IdAuto { get => idAuto; set => idAuto = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Anio { get => anio; set => anio = value; }
        public bool? Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public string UrlFoto { get => urlFoto; set => urlFoto = value; }
    }
}
