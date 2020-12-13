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
    public partial class SalidasProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void gvSalidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string idSalida = gvSalidas.DataKeys[index].Values["IdSalida"].ToString();
                Response.Redirect("DetalleSalidas.aspx?id="+idSalida);
            }
        }
        public void CargarGrid()
        {
            List<VOSalidaExtendida> listaSalida = BLLSalida.ConsultarSalidaPorEstadoExtendida("EN_PROCESO");
            gvSalidas.DataSource = listaSalida;
            gvSalidas.DataBind();
        }
    }
}