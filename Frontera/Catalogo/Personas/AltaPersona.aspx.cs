using Entidades;
using Frontera.Utilerias;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Frontera.Utilerias.Enumeradores;

namespace Frontera.Catalogo.Personas
{
    public partial class AltaPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Enumeradores.EnumToListBox(typeof(CargoPersona), ddlCargo, true);
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (SubeImagen.Value != "")
            {
                string fileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    lblUrlFoto.InnerText = "Archivo no válido";
                }
                else
                {
                    string path = Server.MapPath("~/Imagenes/Personas/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Personas/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoPersona.ImageUrl = url;
                    btnGuardar.Visible = true;
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOPersona persona = new VOPersona(txtTelefono.Text, txtDireccion.Text, txtNombre.Text, txtCorreo.Text, int.Parse(ddlCargo.SelectedValue), null, lblUrlFoto.InnerText);
                BLLPersona.Insertar(persona);
                LimpiarFormulario();
                Response.Redirect("ListarPersonas.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de Error", "alert('Se registró un error al realizar la operación');", true);
            }
        }
        public void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            ddlCargo.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoPersona.ImageUrl = "";
            btnGuardar.Visible = false;
        }
    }
}