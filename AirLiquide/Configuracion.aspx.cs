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
    public partial class Configuracion : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = "";

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.ibtnExportarExcel);

                if (!this.Page.IsPostBack)
                {
                    tipoGestion();
                    tipoTipificacion();
                    ddlTipoGestion.SelectedValue = "1";
                    buscar();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int idTipoTipificacion = Convert.ToInt32(ddlTipoTipificacion.SelectedValue);
                dt = dal.getBuscarTipificacion(null, null, null, null, null, idTipoTipificacion).Tables[0];
                //Utilidad.ExportDataTableToExcel(dt, "exporte.xls", "", "", "", "");
                //Utilidad.ExportDataTableToExcel(dt, "exporte.xls", "", "", "", "");
                Response.ContentType = "Application/x-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=" + "exporte" + ".csv");
                Response.ContentEncoding = Encoding.Unicode;
                Response.Write(Utilidad.ExportToCSVFile(dt));
                Response.End();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            int idTipoTipificacion = Convert.ToInt32(ddlTipoTipificacion.SelectedValue);
            grvConfiguracion.DataSource = dal.getBuscarTipificacion(null, null, null, null, null, idTipoTipificacion);
            grvConfiguracion.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                divEditarConfiguracion.Visible = true;
                divGrilla.Visible = false;

                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                Label _lblId = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblId");
                Label _lblNivel1 = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblNivel1");
                Label _lblNivel2 = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblNivel2");
                Label _lblNivel3 = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblNivel3");
                Label _lblNivel4 = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblNivel4");
                Label _lblIdTipoGestion = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblIdTipoGestion");
                Label _lblEsAgendable = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblEsAgendable");
                Label _lblEsCompPago = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblEsCompPago");
                Label _lblPrioridad = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblPrioridad");
                Label _lblGestionMandante = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblGestionMandante");

                Label _lblValidaFono = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblValidaFono");
                Label _lblInvalidaFono = (Label)grvConfiguracion.Rows[row.RowIndex].FindControl("lblInvalidaFono");

                hfIdTipificacion.Value = _lblId.Text;
                txtNivel1.Text = _lblNivel1.Text;
                txtNivel2.Text = _lblNivel2.Text;
                txtNivel3.Text = _lblNivel3.Text;
                txtNivel4.Text = _lblNivel4.Text;

                if (_lblIdTipoGestion.Text != string.Empty)
                {
                    ddlTipoGestion.SelectedValue = _lblIdTipoGestion.Text;
                }

                if (_lblValidaFono.Text != string.Empty)
                {
                    ddlValidaTelefono.SelectedValue = _lblValidaFono.Text;
                }
                else
                {
                    ddlValidaTelefono.ClearSelection();
                }

                if (_lblInvalidaFono.Text != string.Empty)
                {
                    ddlInvalidaTelefono.SelectedValue = _lblInvalidaFono.Text;
                }
                else
                {
                    ddlInvalidaTelefono.ClearSelection();
                }

                if (_lblEsAgendable.Text != string.Empty)
                {
                    if (_lblEsAgendable.Text == "0")
                    {
                        ddlAgendable.SelectedValue = "2";
                    }
                    if (_lblEsAgendable.Text == "1")
                    {
                        ddlAgendable.SelectedValue = "1";
                    }
                }

                if (_lblEsCompPago.Text != string.Empty)
                {
                    if (_lblEsCompPago.Text == "0")
                    {
                        ddlCompromisoPago.SelectedValue = "2";
                    }
                    if (_lblEsCompPago.Text == "1")
                    {
                        ddlCompromisoPago.SelectedValue = "1";
                    }
                }

                txtPrioridad.Text = _lblPrioridad.Text;
                txtGestionMandante.Text = _lblGestionMandante.Text;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlTipoGestion_DataBound(object sender, EventArgs e)
        {
            ddlTipoGestion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTipificacion = Convert.ToInt32(hfIdTipificacion.Value);
                int? idTipoGestion = Convert.ToInt32(ddlTipoGestion.SelectedValue);
                int? agendable = Convert.ToInt32(ddlAgendable.SelectedValue);
                int? compromisoPago = Convert.ToInt32(ddlCompromisoPago.SelectedValue);
                int? validaFono = Convert.ToInt32(ddlValidaTelefono.SelectedValue);
                int? invalidaFono = Convert.ToInt32(ddlInvalidaTelefono.SelectedValue);
                
                if (compromisoPago == 2)
                {
                    compromisoPago = 0;
                }
                if (agendable==2)
                {
                    agendable = 0;
                }
                int? prioridad = null;
                if (txtPrioridad.Text != string.Empty)
                {
                    prioridad = Convert.ToInt32(ddlCompromisoPago.SelectedValue);
                }

                dal.setUpTipificacion(idTipificacion, txtNivel1.Text, txtNivel2.Text, txtNivel3.Text, txtNivel4.Text, idTipoGestion, agendable, compromisoPago,prioridad, txtGestionMandante.Text, validaFono,invalidaFono);

                buscar();

                divEditarConfiguracion.Visible = false;
                divGrilla.Visible = true;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                divEditarConfiguracion.Visible = false;
                divGrilla.Visible = true;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void tipoGestion()
        {
            ddlTipoGestion.DataSource = dal.getBuscarTipoGestion(1);
            ddlTipoGestion.DataValueField = "IdTipoGestion";
            ddlTipoGestion.DataTextField = "NomTipoGestion";
            ddlTipoGestion.DataBind();
        }

        void tipoTipificacion() {
            ddlTipoTipificacion.DataSource = dal.getBuscarTipoTipificacion(1);
            ddlTipoTipificacion.DataValueField = "IdTipoTipificacion";
            ddlTipoTipificacion.DataTextField = "NomTipoTipificacion";
            ddlTipoTipificacion.DataBind();
        }

        protected void ddlTipoTipificacion_DataBound(object sender, EventArgs e)
        {
            //ddlTipoTipificacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}