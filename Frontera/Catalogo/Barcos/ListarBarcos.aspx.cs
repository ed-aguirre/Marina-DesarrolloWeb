using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Barcos
{
    public partial class ListarBarcos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();

        }

        protected void gvBarcos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string idBarco = gvBarcos.DataKeys[index].Values["IdBarco"].ToString();
                Response.Redirect("EditarBarco.aspx?id=" + idBarco);
            }
        }
        public void CargarGrid()
        {
            gvBarcos.DataSource = BLLBarco.ConsultarBarcos(null);
            gvBarcos.DataBind();
        }
    }
}