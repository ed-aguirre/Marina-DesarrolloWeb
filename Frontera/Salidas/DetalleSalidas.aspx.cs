using Entidades;
using LogicaNegocio;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Salidas
{
    public partial class DetalleSalidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("SalidasProceso.aspx");
                }
                else
                {
                    string idSalida = Request.QueryString["id"].ToString();
                    VOSalidaExtendida salida = BLLSalida.ConsultarSalidaPorIdExtendida(idSalida);
                    CargarFormulario(salida);
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLSalida.FinalizarSalida(lblIdSalida.Text);
                LimpiarFormulario();
                Response.Redirect("SalidasFinalizadas.aspx");
            }catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(),
                    "Mensaje de Error", "alert('Se registró un error al realizar la operación');",
                    true);
            }
        }
        public void CargarFormulario(VOSalidaExtendida salida)
        {
            lblIdSalida.Text = salida.IdSalida.ToString();
            lblFecha.Text = salida.FechaHoraSalida.ToString();
            lblDestino.Text = salida.Destino;
            lblNombreCapitan.Text = salida.NombreCapitan;
            imgFotoCapitan.ImageUrl = salida.UrlFotoCapitan;
            lblNombreBarco.Text = salida.NombreBarco;
            imgFotoBarco.ImageUrl = salida.UrlFotoBarco;
        }
        public void LimpiarFormulario()
        {
            lblIdSalida.Text = "";
            lblFecha.Text = "";
            lblDestino.Text = "";
            lblNombreCapitan.Text = "";
            imgFotoCapitan.ImageUrl = "";
            lblNombreBarco.Text = "";
            imgFotoBarco.ImageUrl = "";
        }
    }
}