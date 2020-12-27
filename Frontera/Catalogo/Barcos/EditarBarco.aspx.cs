using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Barcos
{
    public partial class EditarBarco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoOwners(ddlOwner);
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ListarBarcos.aspx");
                }
                else
                {
                    bool disponibilidad = true;
                    string idBarco = Request.QueryString["id"].ToString();
                    VOBarco barco = BLLBarco.ConsultarBarco(idBarco);
                    CargarFormulario(barco);
                    disponibilidad = (bool)barco.Disponibilidad;
                    if (disponibilidad)
                    {
                        lblBarco.ForeColor = System.Drawing.Color.Green;
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        lblBarco.ForeColor = System.Drawing.Color.Red;
                        btnEliminar.Visible = false;
                    }
                }
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
                    lblUrlFoto.InnerText = "Archivo no soportado";
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
        public void CatalogoOwners(DropDownList dll)
        {
            int[] cargo = { 1, 3 };
            List<VOPersona> owners = BLLPersona.CatalogoPersona(cargo, true);
            foreach (VOPersona persona in owners)
            {
                dll.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOBarco barco = new VOBarco(int.Parse(lblBarco.Text), 
                    txtMatricula.Text,
                    txtNoAmarre.Text,
                    txtNombre.Text, 
                    double.Parse(txtCuota.Text), 
                    int.Parse(ddlOwner.SelectedValue),
                    lblUrlFoto.InnerText, 
                    null);
                BLLBarco.Actualizar(barco);
                LimpiarForm();
                Response.Redirect("ListarBarcos.aspx");

            }catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(),
                    "Mensaje de error",
                    "alert('Se registro un error al hacer la operacion " +ex.Message +"')'", true);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLBarco.Eliminar(lblBarco.Text);
                LimpiarForm();
                Response.Redirect("ListarBarcos.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(),
                    "Mensaje de error",
                    "alert('Se registro un error al hacer la operacion " + ex.Message + "')'", true);
            }
        }

        public void LimpiarForm()
        {
            lblBarco.Text = "";
            txtMatricula.Text = "";
            txtNoAmarre.Text = "";
            txtNombre.Text = "";
            txtCuota.Text = "";
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoBarco.ImageUrl = "";
        }

        public void CargarFormulario(VOBarco barco)
        {
            lblBarco.Text = barco.IdBarco.ToString();
            txtMatricula.Text = barco.Matricula;
            txtNoAmarre.Text = barco.NoAmarre;
            txtNombre.Text = barco.Nombre;
            txtCuota.Text = barco.Cuota.ToString();
            ddlOwner.SelectedValue = barco.IdPersona.ToString();
            lblUrlFoto.InnerText = barco.UrlFoto;
            imgFotoBarco.ImageUrl = barco.UrlFoto;
        }

        protected void btnSubeImagen_Click1(object sender, EventArgs e)
        {
            //no sirve jeje
        }
    }
}