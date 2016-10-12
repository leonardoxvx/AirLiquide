using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Data;

namespace Cobros30
{
    public partial class AsignacionManual : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    asignacion();
                    usuario();
                    resumen();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoProceso.SelectedValue == "1")
                {
                    string usuarios = string.Empty;
                    foreach (GridViewRow grd_Row in grvUsuarios.Rows)
                    {
                        Label _lblIdUsuario = (Label)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("lblIdUsuario");
                        CheckBox chk = (CheckBox)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("chkSeleccionar");

                        if (chk.Checked == true)
                        {
                            usuarios += _lblIdUsuario.Text + ",";
                        }
                    }

                    dal.setProcesoAsignacion(1, Convert.ToInt32(Session["IdMandante"].ToString()), Convert.ToInt32(ddlAsignacion.SelectedValue), usuarios);

                }
                if (ddlTipoProceso.SelectedValue == "2")
                {

                }
                if (ddlTipoProceso.SelectedValue == "3")
                {

                }
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

        void asignacion() {
            ddlAsignacion.DataSource = dal.getBuscarAsignacion(1, Convert.ToInt32(Session["IdMandante"]));
            ddlAsignacion.DataValueField = "IdAsignacion";
            ddlAsignacion.DataTextField = "NomAsignacion";
            ddlAsignacion.DataBind();
        }

        void usuario() {
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            grvUsuarios.DataSource = dal.getBuscarUsuarioAsignacion(idMandante, 1);
            grvUsuarios.DataBind();
        }

        void resumen() {
            /*@maxDeuda as maxDeuda ,
             @minDeuda as minDeuda ,
             @promDeuda as promDeuda ,
             @cantRut as cantRut ,
             @montoTotal as montoTotal,
             @cantRutAsignado as cantRutAsignado ,
             @montoTotalAsignado as montoTotalAsignado ,
             @cantEjeAsig as cantEjeAsig,
             @cantRutNoAsignado as cantRutNoAsignado,
             @montoTotalNoAsignado as montoTotalNoAsignado*/
            DataTable dt = new DataTable();
            dt = dal.getBuscarResumenAsignacionAutomatica(Convert.ToInt32(Session["IdMandante"]), Convert.ToInt32(ddlAsignacion.SelectedValue)).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                lblMaxDeuda.Text = Convert.ToDecimal(item["maxDeuda"]).ToString("n0");
                lblMinDeuda.Text = Convert.ToDecimal(item["minDeuda"]).ToString("n0");
                lblPromedioDeuda.Text = Convert.ToDecimal(item["promDeuda"]).ToString("n0");
                lblCantidadRut.Text = item["cantRut"].ToString();
                lblMontoTotal.Text = Convert.ToDecimal(item["montoTotal"]).ToString("n0");
                lblCantidadRutAsignado.Text = item["cantRutAsignado"].ToString();
                lblMontoTotalAsignado.Text = Convert.ToDecimal(item["montoTotalAsignado"]).ToString("n0");
                lblCantidadEjecutivoAsignado.Text = item["cantEjeAsig"].ToString();
                lblCantidadRutNoAsignado.Text = item["cantRutNoAsignado"].ToString();
                lblMontoTotalNoAsignado.Text = Convert.ToDecimal(item["montoTotalNoAsignado"]).ToString("n0");
                lblCantidadDocs.Text = Convert.ToDecimal(item["cantDocs"]).ToString("n0");
                lblCantidadDocAsignado.Text = Convert.ToDecimal(item["cantDocsAsignados"]).ToString("n0");
                lblCantidadDocsNoAsignado.Text= Convert.ToDecimal(item["cantDocsNoAsignados"]).ToString("n0");

            }
        }

        protected void ddlAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                resumen();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


    }
}