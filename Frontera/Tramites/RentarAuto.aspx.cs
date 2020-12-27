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
    public partial class RentarAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoClientes(ddlPersona, new int[] { 2, 3 });
                CatalogoAutos(ddlAuto, new int[] { 2, 3 });
                //CatalogoClientes(ddlPersona, new int[] { 1, 3 });
            }
        }

        private void CatalogoClientes(DropDownList ddl, int[] v)
        {
            List<VOPersona> owner = BLLPersona.ConsultarPersonas(true);
            foreach (VOPersona persona in owner)
            {
                ddl.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }
        public void CatalogoAutos(DropDownList ddl, int[] v)
        {
            //ddlAuto.Items.Clear();
            List<VOAuto> autos = BLLAuto.ConsultarAutos(true);//solo bascos disponibles, por eso el true
            foreach (VOAuto auto in autos)
            {
                ddlAuto.Items.Add(new ListItem(auto.Matricula, auto.IdAuto.ToString()));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOTramite tramite = new VOTramite(
                    DateTime.Parse(FechaSalida.Value.ToString()), 
                    double.Parse(txtMonto.Text), 
                    int.Parse(ddlAuto.SelectedValue), 
                    int.Parse(ddlPersona.SelectedValue),
                    "EN_RENTA");
                BLLTramite.InsertarTramite(tramite);
                LimpiarFormulario();
                Response.Redirect("AutosRentados.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(),
                    "Mensaje de Error", "alert('Se registró un error al realizar la operación "
                    + ex.Message + "');",
                    true);
            }
        }
        
        public void LimpiarFormulario()
        {
            txtMonto.Text = "";
            FechaSalida.Value = "";
            ddlAuto.SelectedIndex = 0;
            ddlPersona.SelectedIndex = 0;
        }
    }
}