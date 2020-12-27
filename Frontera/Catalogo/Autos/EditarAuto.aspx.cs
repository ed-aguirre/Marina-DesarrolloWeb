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
    public partial class EditarAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ListarAutos.aspx");
                }
                else
                {
                    bool disponibilidad = true;
                    string idAuto = Request.QueryString["id"].ToString();
                    VOAuto auto = BLLAuto.ConsultarAuto(idAuto);
                    CargarFormulario(auto);
                    disponibilidad = (bool)auto.Disponibilidad;
                    if (disponibilidad)
                    {
                        lblDisponible.Text = "Disponible";
                        lblDisponible.ForeColor = System.Drawing.Color.Green;
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        lblDisponible.Text = "No Disponible";
                        lblDisponible.ForeColor = System.Drawing.Color.Red;
                        btnEliminar.Visible = false;
                    }
                }
            }
        }
        public void CargarFormulario(VOAuto auto)
        {
            lblAuto.Text = auto.IdAuto.ToString();
            txtMatricula.Text = auto.Matricula;
            txtMarca.Text = auto.Marca;
            txtAnio.Text = auto.Anio;
            lblUrlFoto.InnerText = auto.UrlFoto;
            imgFotoAuto.ImageUrl = auto.UrlFoto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOAuto auto = new VOAuto(int.Parse(lblAuto.Text),
                    txtMatricula.Text,
                    txtMarca.Text,
                    txtAnio.Text,
                    null,
                    lblUrlFoto.InnerText);
                BLLAuto.Actualizar(auto);
                LimpiarForm();
                Response.Redirect("ListarAutos.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(),
                    "Mensaje de error",
                    "alert('Se registro un error al hacer la operacion " + ex.Message + "')'", true);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLAuto.Eliminar(lblAuto.Text);
                LimpiarForm();
                Response.Redirect("ListarAutos.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(),
                    "Mensaje de error",
                    "alert('Se registro un error al hacer la operacion " + ex.Message + "')'", true);
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
                    string path = Server.MapPath("~/Imagenes/Autos/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Autos/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoAuto.ImageUrl = url;
                    btnGuardar.Visible = true;

                }
            }
        }
        public void LimpiarForm()
        {
            lblAuto.Text = "";
            txtMatricula.Text = "";
            txtMarca.Text = "";
            txtAnio.Text = "";
            lblUrlFoto.InnerText = "";
            imgFotoAuto.ImageUrl = "";
        }
    }
}