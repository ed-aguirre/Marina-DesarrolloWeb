using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOSalidaExtendida: VOSalida
    {
        private string nombreCapitan;
        private string urlFotoCapitan;
        private string nombreBarco;
        private string urlFotoBarco;

        public VOSalidaExtendida(string nombreCapitan, string urlFotoCapitan, string nombreBarco, string urlFotoBarco)
        {
            NombreCapitan = nombreCapitan;
            UrlFotoCapitan = urlFotoCapitan;
            NombreBarco = nombreBarco;
            UrlFotoBarco = urlFotoBarco;
        }
        public VOSalidaExtendida() : base()
        {
            NombreCapitan = "";
            UrlFotoCapitan = "";
            NombreBarco = "";
            UrlFotoBarco = "";
        }
        public VOSalidaExtendida(DataRow dr) : base(dr)
        {
            NombreCapitan = dr["NombreCapitan"].ToString();
            UrlFotoCapitan = dr["UrlFotoCapitan"].ToString();
            NombreBarco = dr["NombreBarco"].ToString();
            UrlFotoBarco = dr["UrlFotoBarco"].ToString();
        }

        public string NombreCapitan
        {
            get
            {
                return nombreCapitan;
            }

            set
            {
                nombreCapitan = value;
            }
        }

        public string UrlFotoCapitan
        {
            get
            {
                return urlFotoCapitan;
            }

            set
            {
                urlFotoCapitan = value;
            }
        }

        public string NombreBarco
        {
            get
            {
                return nombreBarco;
            }

            set
            {
                nombreBarco = value;
            }
        }

        public string UrlFotoBarco
        {
            get
            {
                return urlFotoBarco;
            }

            set
            {
                urlFotoBarco = value;
            }
        }
    }
}
