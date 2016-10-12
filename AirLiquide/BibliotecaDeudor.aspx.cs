using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Data;
using System.IO;

namespace Cobros30
{
    public partial class BibliotecaDeudor : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Deudor deudor = new Deudor();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    string _rut = Convert.ToString(Request.QueryString["rut"]);
                    if (_rut == null)
                    {
                        Response.Redirect("Principal.aspx");
                    }

                    deudor.RutDeudor = _rut;
                    deudor.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                    buscarArchivos(deudor, deudor.IdMandante);
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        void buscarArchivos(Deudor deudor, int idMandante)
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarDeudorArchivo(deudor, idMandante).Tables[0];
            grvDetalleBiblioteca.DataSource = dt;
            grvDetalleBiblioteca.DataBind();
        }

        protected void imgVisualizar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosDeudor/";

                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblId = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblId");
                Label _lblRutaArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblRutaArchivo");

                string url = Server.MapPath(carpeta + _lblRutaArchivo.Text);

                FileInfo fi = new FileInfo(url);
                string extension = fi.Extension.ToString().ToLower();

                Response.ContentType = extension;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fi.Name);
                Response.TransmitFile(fi.FullName);
                Response.End();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void grvDetalleBiblioteca_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}