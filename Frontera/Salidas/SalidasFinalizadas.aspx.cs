using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Salidas
{
    public partial class SalidasFinalizadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }
        public void CargarGrid()
        {
            List<VOSalidaExtendida> salidas = BLLSalida.ConsultarSalidaPorEstadoExtendida("FINALIZADA");
            gvSalidas.DataSource = salidas;
            gvSalidas.DataBind();
        }
    }
}