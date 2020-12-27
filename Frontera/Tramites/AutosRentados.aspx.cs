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
    public partial class AutosRentados : System.Web.UI.Page
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
            List<VOTramiteExtendida> tramites = BLLTramite.ConsultarTramitePorTipoExtendida("EN_RENTA");
            gvTramites.DataSource = tramites;
            if (tramites.Count > 0)
            {
                lblTitle.Text = "Autos en Renta:";
            }
            else
            {
                lblTitle.Text = "No hay autos en Renta.";
            }
            gvTramites.DataBind();
        }

        protected void gvTramites_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    string idTramite = gvTramites.DataKeys[index].Values["IdTramite"].ToString();
                    BLLTramite.FinalizarDevolucion(idTramite);
                    Response.Redirect("AutosRentados.aspx");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this,
                        GetType(),
                        "Mensaje de Error", "alert('Se registró un error al realizar la operación');",
                        true);
                }
            }
        }
    }
}