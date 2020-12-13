using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Personas
{
    public partial class ListarPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void gvPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string idPersona = gvPersonas.DataKeys[index].Values["IdPersona"].ToString();
                Response.Redirect("DetallePersona.aspx?id=" + idPersona);
            }
        }
        public void CargarGrid()
        {
            gvPersonas.DataSource = BLLPersona.ConsultarPersonas(null);
            gvPersonas.DataBind();
        }
    }
}