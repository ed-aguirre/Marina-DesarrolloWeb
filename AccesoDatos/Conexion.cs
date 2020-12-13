using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Conexion
    {
        private string cadenaConexion;
        private static DbProviderFactory proveedor = null;
        public Conexion()
        {
            Configurar();
        }
        public string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }
        }
        public void Configurar()
        {
            try
            {
                string cadenaProveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADONET");
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
                proveedor = DbProviderFactories.GetFactory(cadenaProveedor);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error al configurar cadena de conexion");
            }
        }
    }
}
