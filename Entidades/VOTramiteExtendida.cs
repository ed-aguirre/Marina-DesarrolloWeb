using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOTramiteExtendida:VOTramite
    {
        private string nombreCliente;
        private string urlFotoPersona;
        private string matricula;
        private string urlFotoAuto;

        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string UrlFotoPersona { get => urlFotoPersona; set => urlFotoPersona = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string UrlFotoAuto { get => urlFotoAuto; set => urlFotoAuto = value; }

        public VOTramiteExtendida(string nombreCliente, string urlFotoPersona, string matricula, string urlFotoAuto)
        {
            this.nombreCliente = nombreCliente;
            this.urlFotoPersona = urlFotoPersona;
            this.matricula = matricula;
            this.urlFotoAuto = urlFotoAuto;
        }
        public VOTramiteExtendida(): base()
        {
            this.nombreCliente = "";
            this.urlFotoPersona = "";
            this.matricula = "";
            this.urlFotoAuto = "";
        }
        public VOTramiteExtendida(DataRow dr) : base(dr)
        {
            this.nombreCliente = dr["NombreCliente"].ToString();
            this.urlFotoPersona = dr["UrlFotoCliente"].ToString();
            this.matricula = dr["Matricula"].ToString();
            this.urlFotoAuto = dr["UrlFotoAuto"].ToString();
        }
    }
}
