using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Data;
using System.Text;
using DataTableToExcel;

namespace Cobros30
{
    public partial class Exportes : System.Web.UI.Page
    {
        Datos dal = new Datos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    exporte(null);
                    visible();
                    asignacion();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void asignacion()
        {
            ddlAsignacion.DataSource = dal.getBuscarAsignacion(1, Convert.ToInt32(Session["IdMandante"]));
            ddlAsignacion.DataValueField = "IdAsignacion";
            ddlAsignacion.DataTextField = "NomAsignacion";
            ddlAsignacion.DataBind();
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarConfiguracionExporte(Convert.ToInt32(ddlTipoExporte.SelectedValue)).Tables[0];
                string nombreArchivo = string.Empty;
                foreach (DataRow item in dt.Rows)
                {
                    nombreArchivo = item["NomArchivo"].ToString();
                }

                buscar(nombreArchivo);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlAsignacion_DataBound(object sender, EventArgs e)
        {
            ddlAsignacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        void exporte(int? idExporte) {
            ddlTipoExporte.DataSource = dal.getBuscarConfiguracionExporte(idExporte);
            ddlTipoExporte.DataTextField = "NomExporte";
            ddlTipoExporte.DataValueField = "IdExporte";
            ddlTipoExporte.DataBind();
        }

        void buscar(string nombreExporte)
        {
            DataTable dt = new DataTable();

            int? idAsignacion=0;
            string fechaDesde="";
            string fechaHasta="";

            if (tdAsignacion.Visible==true)
            {
                idAsignacion = Convert.ToInt32(idAsignacion);
            }

            if (tdFechaDesde.Visible==true)
            {
                fechaDesde = txtFechaDesde.Text;
            }

            if (tdFechaHasta.Visible == true)
            {
                fechaHasta = txtFechaHasta.Text;
            }

            dt = dal.getBuscarExporte(Convert.ToInt32(Session["IdMandante"]), Convert.ToInt32(ddlTipoExporte.SelectedValue),idAsignacion,fechaDesde,fechaHasta, ddlTipoTelefono.SelectedValue).Tables[0];
            //dt = Bus.getBuscarExporte(ddlClientePorUsuario.SelectedValue, ddlTipoExporte.SelectedValue, hfIdProveedor.Value).Tables[0];
            //Utilidad.ExportDataTableToExcel(dt, nombreExporte + ".xls", "", "", "", "");

            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=" + nombreExporte);
            //Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Unicode;
            Response.Write(Utilidad.ExportToCSVFile(dt));
            Response.End();
        }

        protected void ddlTipoExporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                visible();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void visible()
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarConfiguracionExporte(Convert.ToInt32(ddlTipoExporte.SelectedValue)).Tables[0];
            string nombreArchivo = string.Empty;
            foreach (DataRow item in dt.Rows)
            {
                string asignacion = item["asignacion"].ToString();
                string fechaDesde = item["fechaDesde"].ToString();
                string fechaHasta = item["fechaHasta"].ToString();
                string tipoTelefono = item["TipoTelefono"].ToString();

                nombreArchivo = item["NomArchivo"].ToString();

                if (asignacion == "1")
                {
                    ddlAsignacion.Visible = true;
                    tdAsignacion.Visible = true;
                }
                else
                {
                    ddlAsignacion.Visible = false;
                    tdAsignacion.Visible = false;
                }

                if (fechaDesde == "1")
                {
                    txtFechaDesde.Visible = true;
                    tdFechaDesde.Visible = true;
                }
                else
                {
                    txtFechaDesde.Visible = false;
                    tdFechaDesde.Visible = false;
                }

                if (fechaHasta == "1")
                {
                    txtFechaHasta.Visible = true;
                    tdFechaHasta.Visible = true;
                }
                else
                {
                    txtFechaHasta.Visible = false;
                    tdFechaHasta.Visible = false;
                }

                if (tipoTelefono=="1")
                {
                    tdTipoTelefono.Visible = true;
                }
                else
                {
                    tdTipoTelefono.Visible = false;
                }
            }
        }
        
    }
}