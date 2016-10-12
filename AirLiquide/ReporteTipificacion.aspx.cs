using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;
using System.Data;
using System.Text;
using System.Drawing;
using DataTableToExcel;

namespace Cobros30
{
    public partial class ReporteTipificacion : System.Web.UI.Page
    {
        Datos dal = new Datos();

        public string gestionesStr;
        public string casosStr;
        int totalGridview = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                divAlerta.Visible = false;
                
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnExcel);

                if (!this.Page.IsPostBack)
                {
                    usuario();

                    DateTime Hoy = DateTime.Today;
                    string fechaActual = Hoy.ToString("dd-MM-yyyy");

                    txtFechaDesde.Text = Hoy.AddDays(-7).ToString("dd-MM-yyyy");
                    txtFechaHasta.Text = fechaActual;


                    buscar();
                    buscarGrilla();
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar();
                buscarGrilla();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int idMandante = Convert.ToInt32(Session["IdMandante"]);
                int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);

                dt = dal.getBuscarGestionesExporte(idMandante, idUsuario, txtFechaDesde.Text, txtFechaHasta.Text).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                Response.ContentType = "Application/x-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=" + "exporte" + ".csv");
                Response.ContentEncoding = Encoding.Unicode;
                Response.Write(Utilidad.ExportToCSVFile(dt));
                Response.End();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void ddlUsuario_DataBound(object sender, EventArgs e)
        {
            ddlUsuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        void buscar() {
            DataTable dt = new DataTable();
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);

            dt = dal.getBuscarContadorGestiones(idMandante, idUsuario, txtFechaDesde.Text, txtFechaHasta.Text).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }

            StringBuilder sbGestiones = new StringBuilder();
            StringBuilder sbCasos = new StringBuilder();
            
            foreach (DataRow item in dt.Rows)
            {
                string gestiones = item["Contador"].ToString();
                string casos = item["ContRutDeudor"].ToString();

                sbGestiones.Append("{label: '" + item["FECHA"].ToString() + "', y: parseInt('" + gestiones + "')},");
                sbCasos.Append("{label: '" + item["FECHA"].ToString() + "', y: parseInt('" + casos + "')},");
            }

            //inicializa los valores en vacio para el grafico
            string strGestiones = "[{label: '0', y: parseInt('0')}]";
            string strCasos = "[{label: '0', y: parseInt('0')}]";

            if (sbGestiones.ToString() != "")
            {
                strGestiones = "[" + sbGestiones.ToString().Remove(sbGestiones.ToString().Length - 1) + "]";
            }

            if (sbCasos.ToString() != "")
            {
                strCasos = "[" + sbCasos.ToString().Remove(sbCasos.ToString().Length - 1) + "]";
            }
            
            hfConsulta.Value = strGestiones;
            gestionesStr = strGestiones;
            
            hfSolicitud.Value = strCasos;
            casosStr = strCasos;
            
            string script3;
            script3 = "<script type=text/javascript>ejemplo();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ejemplo", script3, false);
        }

        void buscarGrilla() {
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
            DataTable dt = new DataTable();
            dt = dal.getContarGestiones(idMandante, idUsuario, txtFechaDesde.Text, txtFechaHasta.Text).Tables[0];

            grvCantidadDeGestiones.DataSource = dt;
            grvCantidadDeGestiones.DataBind();
        }

        void usuario() {
            Usuario user = new Usuario();
            user.Activo = 1;
            ddlUsuario.DataSource = dal.getBuscarUsuario(user);
            ddlUsuario.DataValueField = "IdUsuario";
            ddlUsuario.DataTextField = "Login";
            ddlUsuario.DataBind();
        }

        protected void lbtnCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtnCantidad = sender as LinkButton;
                GridViewRow row = (GridViewRow)lbtnCantidad.NamingContainer;

                Label _lblIdTipificacion = (Label)grvCantidadDeGestiones.Rows[row.RowIndex].FindControl("lblIdTipificacion");
                int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
                string fechaDesde = txtFechaDesde.Text;
                string fechaHasta = txtFechaHasta.Text;

                DataSet ds = new DataSet();

                ds = dal.getBuscarDetalleGestiones(Convert.ToInt32(_lblIdTipificacion.Text), idUsuario, fechaDesde, fechaHasta);
                Session["detalleGestiones"] = ds;

                Response.Redirect("DetalleTipificaciones.aspx");

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Attributes["class"] = "alert alert-warning";
                divAlerta.Visible = true;
            }
        }

        protected void lbtnTotalCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtnTotalCantidad = sender as LinkButton;
                GridViewRow row = (GridViewRow)lbtnTotalCantidad.NamingContainer;
                //Label _lblIdTipificacion = (Label)grvCantidadDeGestiones.Rows[row.RowIndex].FindControl("lblIdTipificacion");
                int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
                string fechaDesde = txtFechaDesde.Text;
                string fechaHasta = txtFechaHasta.Text;

                DataSet ds = new DataSet();
                ds = dal.getBuscarDetalleGestiones(null, idUsuario, fechaDesde, fechaHasta);
                Session["detalleGestiones"] = ds;

                Response.Redirect("DetalleTipificaciones.aspx");
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Attributes["class"] = "alert alert-warning";
                divAlerta.Visible = true;
            }
        }

        protected void grvCantidadDeGestiones_DataBound(object sender, EventArgs e)
        {
            string tempColumnValue = "Categoría";
            foreach (GridViewRow row in grvCantidadDeGestiones.Rows)
            {
                Label lblMyControl = row.FindControl("lblNivel1") as Label;
                if (tempColumnValue == lblMyControl.Text)
                {
                    lblMyControl.Text = "";
                }
                else
                {
                    tempColumnValue = lblMyControl.Text;
                    row.BackColor = Color.AntiqueWhite;
                }
            }
        }

        protected void grvCantidadDeGestiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string rightBonus = ((Label)e.Row.FindControl("lblCantidad")).Text;
                totalGridview += Convert.ToInt32(rightBonus);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton _lbtnTotalCantidad = (LinkButton)e.Row.FindControl("lbtnTotalCantidad");
                _lbtnTotalCantidad.Text = totalGridview.ToString("n0");

                Label _lblTotalCantidad = (Label)e.Row.FindControl("lblTotalCantidad");
                _lblTotalCantidad.Text = totalGridview.ToString("n0");
            }
        }
    }
}