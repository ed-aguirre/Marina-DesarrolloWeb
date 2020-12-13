using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace Frontera.Catalogo.Barcos
{
    public partial class AltaBarcos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoOwners(ddlOwner);
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
                    lblUrlFoto.InnerText="Archivo no soportado";
                }
                else
                {
                    string path = Server.MapPath("~/Imagenes/Barcos/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Barcos/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoBarco.ImageUrl = url; //deberia ser fotoBarco
                    btnGuardar.Visible = true;

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOBarco barco = new VOBarco(txtMatricula.Text,
                    txtNoAmarre.Text, txtNombre.Text, 
                    Convert.ToDouble(txtCuota.Text),
                    Convert.ToInt32(ddlOwner.SelectedValue),
                    lblUrlFoto.InnerText, true);
                BLLBarco.Insertar(barco);
                LimpiarForm();
                Response.Redirect("ListarBarcos.aspx");
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), 
                    "Mensaje de error", 
                    "alert('Se registro un error al hacer la operacion')", true);
            }
        }

        public void CatalogoOwners(DropDownList dll)
        {
            int[] cargo = { 1, 3 };
            List<VOPersona> owners = BLLPersona.CatalogoPersona(cargo, true);
            foreach(VOPersona persona in owners)
            {
                dll.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }

        public void LimpiarForm()
        {
            txtMatricula.Text = "";
            txtNoAmarre.Text = "";
            txtNombre.Text = "";
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoBarco.ImageUrl = "";
            btnGuardar.Visible = false;

        }
    }
}