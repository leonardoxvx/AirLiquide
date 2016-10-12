using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;
using System.Data;
using System.Text.RegularExpressions;
using DataTableToExcel;
using System.Text;

namespace Cobros30
{
    public partial class CarteraAsignada : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Usuario us = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = string.Empty;

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnExcel);

                if (!this.Page.IsPostBack)
                {
                    us.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
                    asignacion();
                    campana();
                    ejecutivo();
                    estadoDeuda();
                    tipoDeuda();
                    sucursal();

                    string _tipo = Convert.ToString(Request.QueryString["Tipo"]);
                    if (_tipo != null)
                    {
                        string _IdMandante = Convert.ToString(Request.QueryString["Mandante"]);

                        DropDownList ddlMandante = Page.Master.FindControl("ddlMandante") as DropDownList;
                        string idMandante = Session["IdMandante"].ToString();
                        ddlMandante.SelectedValue = idMandante;

                        if (_tipo == "RutAsignado")
                        {
                            Session["IdMandante"] = _IdMandante;
                            buscar();
                        }

                        if (_tipo == "MontoAsignado")
                        {
                            Session["IdMandante"] = _IdMandante;
                            buscar();
                        }

                        if (_tipo == "PagosAbono")
                        {

                        }

                        if (_tipo == "Retiro")
                        {

                        }

                        if (_tipo == "Saldo")
                        {
                            Session["IdMandante"] = _IdMandante;
                            ddlEstadoDeuda.SelectedValue = "1";
                            buscar();
                        }
                    }

                }
                
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
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
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar() {
            //grvResultado.DataSource = dal.getBuscarCarteraAsignada()
            Deuda deuda = new Deuda();
            Deudor deudor = new Deudor();
            //deuda.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
            deuda.IdMandante = Convert.ToInt32(Session["IdMandante"]);
            deuda.IdAsignacion = Convert.ToInt32(ddlAsignacion.SelectedValue);
            deuda.IdCampana = Convert.ToInt32(ddlCampana.SelectedValue);
            deuda.IdEstadoDeuda = Convert.ToInt32(ddlEstadoDeuda.SelectedValue);
            deuda.IdUsuarioAsig = Convert.ToInt32(ddlEjecutivo.SelectedValue);
            deuda.TipoDeuda = ddlTipoDeuda.SelectedValue;
            deudor.NombreDeudor = txtNombreRazonSocial.Text;
            deudor.RutDeudor = txtRut.Text.Trim();
            deuda.Sucursal = ddlSucursal.SelectedValue;

            //deuda.IdEstadoDeuda

            int? montoDesde = null;
            int? montoHasta = null;
            if (IsNumeric(txtMontoDesde.Text))
            {
                montoDesde = Convert.ToInt32(txtMontoDesde.Text);
            }
            if (IsNumeric(txtMontoHasta.Text))
            {
                montoHasta = Convert.ToInt32(txtMontoHasta.Text);
            }
            
            DataTable dt = new DataTable();
            dt = dal.getBuscarCarteraAsignada(deuda, deudor, montoDesde, montoHasta).Tables[0];
            Session["DatosCarteraAsignada"] = dt;
            grvResultado.DataSource = Session["DatosCarteraAsignada"];
            grvResultado.DataBind();
        }

        private bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void ddlAsignacion_DataBound(object sender, EventArgs e)
        {
            ddlAsignacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        protected void ddlCampana_DataBound(object sender, EventArgs e)
        {
            ddlCampana.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        protected void ddlEstadoDeuda_DataBound(object sender, EventArgs e)
        {
            ddlEstadoDeuda.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        protected void ddlEjecutivo_DataBound(object sender, EventArgs e)
        {
            ddlEjecutivo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        protected void ddlTipoDeuda_DataBound(object sender, EventArgs e)
        {
            ddlTipoDeuda.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }
        //void buscarMandante(Usuario user)
        //{
        //    DataTable dt = new DataTable();
        //    dt = dal.getBuscarUsuarioMandante(user).Tables[0];

        //    ddlMandante.DataSource = dt;
        //    ddlMandante.DataValueField = "IdMandante";
        //    ddlMandante.DataTextField = "NomMandante";
        //    ddlMandante.DataBind();
        //}

        void asignacion() {
            ddlAsignacion.DataSource = dal.getBuscarAsignacion(1, Convert.ToInt32(Session["IdMandante"]));
            ddlAsignacion.DataValueField = "IdAsignacion";
            ddlAsignacion.DataTextField = "NomAsignacion";
            ddlAsignacion.DataBind(); 
        }

        void campana(){
            ddlCampana.DataSource = dal.getBuscarCampana(1);
            ddlCampana.DataValueField = "IdCampana";
            ddlCampana.DataTextField = "NomCampana";
            ddlCampana.DataBind();
        }

        void estadoDeuda() {

            //ddlEstadoDeuda.DataSource = dal.getBuscarEstadoDeuda(1);
            ddlEstadoDeuda.DataSource = dal.getBuscarEstadoDeuda2(1, null);
            ddlEstadoDeuda.DataValueField = "IdEstadoDeuda2";
            ddlEstadoDeuda.DataTextField = "NomEstadoDeuda2";
            ddlEstadoDeuda.DataBind();
        }

        void tipoDeuda() {
            //ddlTipoDeuda.DataSource = dal.getBuscarTipoDeuda(1);
            //ddlTipoDeuda.DataValueField = "IdTipoDeuda";
            //ddlTipoDeuda.DataTextField = "NomTipoDeuda";
            //ddlTipoDeuda.DataBind();
        }

        void sucursal()
        {
            Sucursal su = new Sucursal();
            su.Activo = 1;
            ddlSucursal.DataSource = dal.getBuscarSucursal(su);
            ddlSucursal.DataValueField = "IdSucursal";
            ddlSucursal.DataTextField = "NomSucursal";
            ddlSucursal.DataBind();
        }

        void ejecutivo() {
            Usuario user = new Usuario();
            user.Activo = 1;
            //ddlEjecutivo.DataSource = dal.getBuscarUsuarioPorPerfil("2,3",1);
            ddlEjecutivo.DataSource = dal.getBuscarUsuarioAsignadoMandante(Convert.ToInt32(Session["IdMandante"]));
            //ddlEjecutivo.DataValueField = "IdUsuario";
            //ddlEjecutivo.DataTextField = "Login";
            ddlEjecutivo.DataValueField = "IdUsuarioAsignado";
            ddlEjecutivo.DataTextField = "LoginUsuario";
            ddlEjecutivo.DataBind();
        }

        private decimal _TotalSaldo = 0;
        protected void paginacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblSaldo = (Label)e.Row.FindControl("lblSaldo");
                _TotalSaldo += Convert.ToDecimal(_lblSaldo.Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";

                e.Row.Cells[2].Text = _TotalSaldo.ToString("n0");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }

            if (e.Row.RowType == DataControlRowType.Pager)
            {
                Label _lblPagina = (Label)e.Row.FindControl("lblPagina");
                Label _lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label _lblTotalRegistros = (Label)e.Row.FindControl("lblTotalRegistros");
                _lblPagina.Text = Convert.ToString(grvResultado.PageIndex + 1);
                _lblTotal.Text = Convert.ToString(grvResultado.PageCount);

                DataTable dt = new DataTable();
                dt = Session["DatosCarteraAsignada"] as DataTable;
                _lblTotalRegistros.Text = dt.Rows.Count.ToString();
            }
        }
        protected void imgFirst_Click(object sender, EventArgs e)
        {
            //buscar();
            if (Session["DatosCarteraAsignada"] != null)
            {
                grvResultado.DataSource = Session["DatosCarteraAsignada"];
                grvResultado.DataBind();
            }
            else
            {
                buscar();
            }
            grvResultado.PageIndex = 0;
            grvResultado.DataBind();
        }

        protected void imgPrev_Click(object sender, EventArgs e)
        {
            //buscar();
            if (Session["DatosCarteraAsignada"] != null)
            {
                grvResultado.DataSource = Session["DatosCarteraAsignada"];
                grvResultado.DataBind();
            }
            else
            {
                buscar();
            }
            if (grvResultado.PageIndex != 0)
                grvResultado.PageIndex--;
            grvResultado.DataBind();
        }

        protected void imgNext_Click(object sender, EventArgs e)
        {
            //buscar();
            if (Session["DatosCarteraAsignada"] != null)
            {
                grvResultado.DataSource = Session["DatosCarteraAsignada"];
                grvResultado.DataBind();
            }
            else
            {
                buscar();
            }

            if (grvResultado.PageIndex != (grvResultado.PageCount - 1))
                grvResultado.PageIndex++;
            grvResultado.DataBind();
        }

        protected void imgLast_Click(object sender, EventArgs e)
        {
            //buscar();
            if (Session["DatosCarteraAsignada"] != null)
            {
                grvResultado.DataSource = Session["DatosCarteraAsignada"];
                grvResultado.DataBind();
            }
            else
            {
                buscar();
            }

            grvResultado.PageIndex = grvResultado.PageCount - 1;
            grvResultado.DataBind();
        }

        protected void lbtnRutDeudor_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblRutDeudor = (Label)grvResultado.Rows[row.RowIndex].FindControl("lblRutDeudor");
                Response.Redirect("Principal.aspx?rut="+ _lblRutDeudor.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //grvResultado.DataSource = dal.getBuscarCarteraAsignada()
                Deuda deuda = new Deuda();
                Deudor deudor = new Deudor();
                //deuda.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
                deuda.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                deuda.IdAsignacion = Convert.ToInt32(ddlAsignacion.SelectedValue);
                deuda.IdCampana = Convert.ToInt32(ddlCampana.SelectedValue);
                deuda.IdUsuarioAsig = Convert.ToInt32(ddlEjecutivo.SelectedValue);
                deuda.IdTipoDeuda = Convert.ToInt32(ddlTipoDeuda.SelectedValue);
                deudor.NombreDeudor = txtNombreRazonSocial.Text;
                deudor.RutDeudor = txtRut.Text;

                deuda.IdEstadoDeuda = Convert.ToInt32(ddlEstadoDeuda.SelectedValue);

                int? montoDesde = null;
                int? montoHasta = null;
                if (IsNumeric(txtMontoDesde.Text))
                {
                    montoDesde = Convert.ToInt32(txtMontoDesde.Text);
                }
                if (IsNumeric(txtMontoHasta.Text))
                {
                    montoHasta = Convert.ToInt32(txtMontoHasta.Text);
                }

                DataTable dt = new DataTable();
                dt = dal.getBuscarCarteraAsignadaExporte(deuda, deudor, montoDesde, montoHasta).Tables[0];

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


    }
}