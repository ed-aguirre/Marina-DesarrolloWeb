using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Tramites
{
    public partial class DevolucionesFinalizadas : System.Web.UI.Page
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
            List<VOTramiteExtendida> tramites = BLLTramite.ConsultarTramitePorTipoExtendida("DEVOLUCION_COMPLETADA");
            gvTramites.DataSource = tramites;
            if (tramites.Count > 0)
            {
                lblTitle.Text = "Devoluciones finalizadas:";
            }
            else
            {
                lblTitle.Text = "No existen devoluciones";
            }
            gvTramites.DataBind();
        }
    }
}