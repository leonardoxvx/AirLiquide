using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;

namespace Cobros30
{
    public partial class AgendamientosCompromisos : System.Web.UI.Page
    {

        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {

                    DateTime Hoy = DateTime.Today;
                    string fechaActual = Hoy.ToString("dd-MM-yyyy");

                    //txtFechaDesde.Text = Hoy.AddDays(-7).ToString("dd-MM-yyyy");
                    txtFechaDesde.Text = fechaActual;
                    txtFechaHasta.Text = fechaActual;

                    ejecutivo();
                    //buscar();
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
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void ddlEjecutivo_DataBound(object sender, EventArgs e)
        {
            ddlEjecutivo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        void ejecutivo() {
            ddlEjecutivo.DataSource = dal.getBuscarUsuarioConGestion(Convert.ToInt32(Session["IdMandante"]));
            ddlEjecutivo.DataTextField = "LoginUsuario";
            ddlEjecutivo.DataValueField = "IdUsuario";
            ddlEjecutivo.DataBind();
        }

        void buscar() {
            DataTable dt = new DataTable();
            dt = dal.getBuscarAgendamientosCompromisos(Convert.ToInt32(Session["IdMandante"].ToString()), Convert.ToInt32(ddlTipo.SelectedValue), Convert.ToInt32(ddlEjecutivo.SelectedValue), txtFechaDesde.Text, txtFechaHasta.Text).Tables[0];
            grvAgrendamientosCompromisos.DataSource = dt;
            grvAgrendamientosCompromisos.DataBind();
        }

        protected void lbtnRutDeudor_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblRutDeudor = (Label)grvAgrendamientosCompromisos.Rows[row.RowIndex].FindControl("lblRutDeudor");
                Response.Redirect("Principal.aspx?rut=" + _lblRutDeudor.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}