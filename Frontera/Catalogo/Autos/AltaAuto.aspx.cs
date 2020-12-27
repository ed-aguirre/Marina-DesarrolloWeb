using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Autos
{
    public partial class AltaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (SubeImagen.Value != "")
            {
                string fileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    lblUrlFoto.InnerText = "Archivo no soportado";
                }
                else
                {
                    string path = Server.MapPath("~/Imagenes/Autos/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Autos/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoAuto.ImageUrl = url; //deberia ser fotoBarco
                    btnGuardar.Visible = true;

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOAuto auto = new VOAuto(txtMatricula.Text,
                    txtMarca.Text, 
                    txtAnio.Text,
                    true,
                    lblUrlFoto.InnerText);
                BLLAuto.Insertar(auto);
                LimpiarForm();
                Response.Redirect("ListarAutos.aspx");
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(),
                    "Mensaje de error",
                    "alert('Se registro un error al hacer la operacion"+ ex.Message +"')", true);
            }
        }
        protected void LimpiarForm()
        {
            txtMatricula.Text = "";
            txtMarca.Text = "";
            txtAnio.Text = "";
            lblUrlFoto.InnerText = "";
            imgFotoAuto.ImageUrl = "";
            btnGuardar.Visible = false;
        }
    }
}