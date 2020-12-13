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
    public partial class AltaSalidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoOwners(ddlCapitan, new int[] { 2, 3 });
                CatalogoOwners(ddlCapitan, new int[] { 1, 3 });
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOSalida salida = new VOSalida(DateTime.Parse(FechaSalida.Value.ToString()), txtDestino.Text,"EN_PROCESO",int.Parse(ddlBarco.SelectedValue),int.Parse(ddlCapitan.SelectedValue));
                BLLSalida.InsertarSalida(salida);
                LimpiarFormulario();
                Response.Redirect("SalidasProceso.aspx");
            }catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, 
                    GetType(), 
                    "Mensaje de Error", "alert('Se registró un error al realizar la operación "
                    +ex.Message+"');",
                    true);
            }
        }

        protected void ddlOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlOwner.SelectedValue;
            CatalogoBarcos(id);
        }
        public void CatalogoOwners(DropDownList ddl, int[] cargo)
        {
            List<VOPersona> owner = BLLPersona.CatalogoPersona(cargo, true);
            foreach(VOPersona persona in owner)
            {
                ddlOwner.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
                ddl.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }
        public void CatalogoBarcos(string idOwner)
        {
            ddlBarco.Items.Clear();
            List<VOBarco> barcos = BLLBarco.ConsultarBarcosPorOwner(idOwner,true);//solo bascos disponibles, por eso el true
            foreach(VOBarco barco in barcos)
            {
                ddlBarco.Items.Add(new ListItem(barco.Matricula, barco.IdBarco.ToString()));
            }
        }
        public void LimpiarFormulario()
        {
            txtDestino.Text = "";
            FechaSalida.Value = "";
            ddlCapitan.SelectedIndex = 0;
            ddlOwner.SelectedIndex = 0;
            ddlBarco.SelectedIndex = 0;
        }
    }
}