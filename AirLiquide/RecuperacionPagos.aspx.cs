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
    public partial class RecuperacionPagos : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.lbtnBuscarExcel);
                scriptManager.RegisterPostBackControl(this.btnBuscar);

                if (!this.Page.IsPostBack)
                {

                    btnBuscar.Attributes.Add("OnClick", string.Format("this.disabled = true; {0};", ClientScript.GetPostBackEventReference(btnBuscar, null)));


                    DateTime Hoy = DateTime.Today;
                    string fechaActual = Hoy.ToString("dd-MM-yyyy");

                    txtFechaDesde.Text = Hoy.AddDays(-7).ToString("dd-MM-yyyy");
                    //txtFechaDesde.Text = fechaActual;
                    txtFechaHasta.Text = fechaActual;

                    ejecutivo();
                    sucursal();
                    tipoDocumento();
                    //buscar();
                }
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

        void ejecutivo()
        {
            ddlEjecutivo.DataSource = dal.getBuscarUsuarioConGestion(Convert.ToInt32(Session["IdMandante"]));
            ddlEjecutivo.DataTextField = "LoginUsuario";
            ddlEjecutivo.DataValueField = "IdUsuario";
            ddlEjecutivo.DataBind();
        }

        void sucursal()
        {
            Sucursal su = new Sucursal();
            su.Activo = 1;
            ddlSucursal.DataSource = dal.getBuscarSucursal(su);
            ddlSucursal.DataTextField = "NomSucursal";
            ddlSucursal.DataValueField = "IdSucursal";
            ddlSucursal.DataBind();
        }

        void tipoDocumento()
        {
            ddlTipoDocumento.DataSource = dal.getBuscarTipoDocumento(1);
            ddlTipoDocumento.DataTextField = "NomTipoDocumento";
            ddlTipoDocumento.DataValueField = "IdTipoDocumento";
            ddlTipoDocumento.DataBind();
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

        void buscar() {
            DataTable dt = new DataTable();
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            dt = dal.getBuscarDetallePago(ddlSucursal.SelectedValue, ddlTipoDocumento.SelectedValue, Convert.ToInt32(ddlEjecutivo.SelectedValue), txtFechaDesde.Text, txtFechaHasta.Text, txtCodCliente.Text,txtReferencia.Text).Tables[0];
            Session["DataDetallePago"] = dt;
            grvRecupacionPagos.DataSource = dt;
            grvRecupacionPagos.DataBind();
            //grvRecupacionPagos.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private decimal _montoTitulo = 0;
        private decimal _valorBaja = 0;

        protected void grvRecupacionPagos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label _lblMontoTitulo = (Label)e.Row.FindControl("lblMontoTitulo");
                    _montoTitulo += Convert.ToDecimal(_lblMontoTitulo.Text);

                    Label _lblValorBaja = (Label)e.Row.FindControl("lblValorBaja");
                    _valorBaja += Convert.ToDecimal(_lblValorBaja.Text);
                    
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total:";

                    e.Row.Cells[7].Text = _montoTitulo.ToString("n0");
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;

                    e.Row.Cells[10].Text = _valorBaja.ToString("n0");
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                    
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void lbtnBuscarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Session["DataDetallePago"] as DataTable;
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
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnVerSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarverDiasPagosAirLiquide().Tables[0];
                grvSucursal.DataSource = dt;
                grvSucursal.DataBind();
                
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", true);
                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}