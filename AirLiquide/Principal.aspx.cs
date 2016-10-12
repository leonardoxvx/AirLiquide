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
    public partial class Principal : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Deudor deudor = new Deudor();
        Deuda deuda = new Deuda();
        Mandante man = new Mandante();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = "";

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnAgregarTelefono);
                scriptManager.RegisterPostBackControl(this.lbtnGrabarEstados);
                scriptManager.RegisterPostBackControl(this.btnGrabarDireccion);
                scriptManager.RegisterPostBackControl(this.lbtnGrabarDireccionesEstados);
                scriptManager.RegisterPostBackControl(this.btnGrabarEmail);
                scriptManager.RegisterPostBackControl(this.lbtnGrabarEmailEstados);
                scriptManager.RegisterPostBackControl(this.btnExcelDetalleDeuda);
                scriptManager.RegisterPostBackControl(this.lbtnExcelDetallePago);
                

                if (!this.Page.IsPostBack)
                {

                    string _modo = Convert.ToString(Request.QueryString["MODO"]);
                    if (_modo != null)
                    {
                        string _discador = Convert.ToString(Request.QueryString["discador"]);
                        string _rut2 = Convert.ToString(Request.QueryString["RUT"]);
                        string _ani = Convert.ToString(Request.QueryString["ANI"]);

                        Session["telefonoAni"] = _ani;

                        string _agendId = Convert.ToString(Request.QueryString["AGENT_ID"]);
                        string _idProducto = Convert.ToString(Request.QueryString["id_producto"]);
                        string _intIdMandante = Convert.ToString(Request.QueryString["intIdMandante"]);

                        string rutOri = Dv(_rut2);
                        txtRutDeudor.Value = _rut2+"-"+rutOri;
                        Session["IdMandante"] = _intIdMandante;
                        buscar();
                    }
                    else
                    {
                        Session["telefonoAni"] = null;
                        
                        string _rut = Convert.ToString(Request.QueryString["rut"]);
                        
                        if (_rut != null)
                        {
                            txtRutDeudor.Value = _rut;
                            buscar();
                            //set la session para que no entre denuevo al metodo buscar...
                            Session["VarRutDeudor"] = null;
                            //fin set
                        }
                    }
                    
                    if (Session["VarRutDeudor"] != null)
                    {
                        txtRutDeudor.Value = Session["VarRutDeudor"].ToString();
                        buscar();
                    }

                    permisos();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        void permisos() {

            int idPerfil = Convert.ToInt32(Session["variableIdPerfil"]);
            if (idPerfil==2)
            {
                lbtnIrDeudor.Visible = false;
            }
        }

        public static string Dv(string r)
        {
            int suma = 0;
            for (int x = r.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(r[x]) ? r[x].ToString() : "0") * (((r.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            return digito;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["VarRutDeudor"] = txtRutDeudor.Value;
                Response.Redirect("Principal.aspx");
                //Response.Redirect("Principal.aspx?rut=" + Session["VarRutDeudor"].ToString());
                //buscar();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnPagoEnCliente_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnBiblioteca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BibliotecaDeudor.aspx?rut=" + txtRutDeudor.Value);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnCarteraAsignada_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnDetalleDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvDeudasDeudor.Rows[row.RowIndex].FindControl("lblIdMandante");
                Label _lblIdSucursal = (Label)grvDeudasDeudor.Rows[row.RowIndex].FindControl("lblIdSucursal");

                string rut = lblRutDeudor.Text;

                deuda.IdMandante = Convert.ToInt32(_lblIdMandante.Text);
                deuda.Sucursal = _lblIdSucursal.Text;
                deuda.RutDeudor = rut;

                DataTable dt = new DataTable();
                dt = dal.getBuscarDeudaDetalle(deuda).Tables[0];
                Session["sessionDetalleDeudaExcel"] = dt;
                grvDetalleDeuda.DataSource = dt;
                grvDetalleDeuda.DataBind();

                //if (string.IsNullOrEmpty(_lblObservacion.Text))
                //{
                //    lblObservacionTicket.Text = string.Empty;
                //}
                //else
                //{
                //    lblObservacionTicket.Text = _lblObservacion.Text;
                //}

                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", true);
                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            
            deudor.RutDeudor = txtRutDeudor.Value;
            deudor.IdMandante = Convert.ToInt32(Session["IdMandante"]);

            string idTipoTipificacion = Session["variableIdTipoTipificacion"].ToString();
            if (idTipoTipificacion == "1")
            {
                divDetalleDeuda.Visible = true;
            }
            else
            {
                divDetalleDeuda.Visible = false;
            }

            DataTable dt = new DataTable();
            dt = dal.getBuscarDeudaPorRutDeudor(deudor).Tables[0];

            grvDeudasDeudor.DataSource = dt;
            grvDeudasDeudor.DataBind();

            grvPagos.DataSource = dal.getBuscarPagosPorRutDeudor(deudor);
            grvPagos.DataBind();

            cambioMandante();

            DataTable dtDeudor = new DataTable();
            dtDeudor = dal.getBuscarDeudor(deudor).Tables[0];

            if (dtDeudor.Rows.Count != 0)
            {
                divContenido.Visible = true;
            }
            else
            {
                divContenido.Visible = false;
                divAlerta.Visible = true;
                lblInfo.Text = "Rut no existe para mandante seleccionado";
            }

            foreach (DataRow item in dtDeudor.Rows)
            {
                lblRutDeudor.Text = txtRutDeudor.Value;
                lblNombreDeudor.Text = item["NombreDeudor"].ToString().ToUpper();
                lblNombreDeudor2.Text = item["NombreDeudor"].ToString().ToUpper();
                lblRutDeudor2.Text = item["Rut"].ToString().ToUpper();
                lblCondicionPago.Text = item["NomCondicionPago"].ToString();
                lblSector.Text = item["NomSector"].ToString();

                if (item["Adic3"].ToString() != string.Empty)
                {
                    lblFechaIngresoDeudor.Text = item["Adic3"].ToString();
                }

                if (item["FechaTerminoContrato"].ToString() != string.Empty)
                {
                    lblFechaTerminoContrato.Text = item["FechaTerminoContrato"].ToString().Substring(0,10);
                }
                
                if (item["Renovable"].ToString() == "1")
                {
                    lblRenovable.Text = "Si";
                }
                else
                {
                    lblRenovable.Text = "No";
                }
                
                lblResponsableComercial.Text = item["ResponsableComercial"].ToString();

                if (item["FlagDeudaCastigada"].ToString() == "1")
                {
                    lblFlagDeudaCastigada.Text = "Cliente posee deuda castigada";
                    lblFlagDeudaCastigada.CssClass = "alert-danger";
                }
                else
                {
                    lblFlagDeudaCastigada.Visible = false;
                }

                if (item["FlagQuiebra"].ToString() == "1")
                {
                    lblFlagQuiebra.Text = "Cliente en Quiebra";
                    lblFlagQuiebra.CssClass= "alert-danger";
                }
                else
                {
                    lblFlagQuiebra.Visible = false;
                }

                if (item["FlagJudicial"].ToString() == "1")
                {
                    lblFlagJudicial.Text = "Cliente en Proceso Judicial";
                    lblFlagJudicial.CssClass = "alert-danger";
                }
                else
                {
                    lblFlagJudicial.Visible = false;
                }

                //lblRutRepresentanteLegal.Text = item["RepLegalRut"].ToString();
                //lblNombreRepresentanteLegal.Text = item["RepLegalNombre"].ToString();

                //lblProbabilidadCobro.Text = item["NomProbabilidadCobro"].ToString();
                //lblCampanaCliente.Text = item["CampanaCliente"].ToString();


                //lblAdic1Deudor.Text = item["Adic1"].ToString();
                //lblAdic2Deudor.Text = item["Adic2"].ToString();
                //lblAdic3Deudor.Text = item["Adic3"].ToString();
                //lblAdic4Deudor.Text = item["Adic4"].ToString();
                //lblAdic5Deudor.Text = item["Adic5"].ToString();

                //lblUsuarioAsignado.Text = item["Login"].ToString();
            }

            DataTable dtUltimaGestion = new DataTable();
            dtUltimaGestion = dal.getBuscarUltimaGestion(deudor).Tables[0];
            foreach (DataRow item in dtUltimaGestion.Rows)
            {
                lblFechaUltimaGestion.Text = item["FechaIngreso"].ToString();
                lblHoraUltimaGestion.Text = item["HoraIngreso"].ToString();
                lblGestionUltimaGestion.Text = item["Gestion"].ToString();
                lblFechaCompromisoUltimaGestion.Text = item["FechaCompromiso"].ToString();
                lblFechaAgendamientoUltimaGestion.Text = item["FechaAgendamiento"].ToString();
                lblObservacionUltimaGestion.Text = item["Observaciones"].ToString();
                lblFonoUltimaGestion.Text = item["Telefono"].ToString();
                lblEjecutivoUltimaGestion.Text = item["Login"].ToString();
            }

            verUltimoTelefono();
            verUltimoEmail();
            verUltimoDireccion();
        }

        void verUltimoTelefono()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            DataTable dtTelefonoDeudor = new DataTable();
            dtTelefonoDeudor = dal.getBuscarTelefonoPorRutMaximo(deudor).Tables[0];
            foreach (DataRow item in dtTelefonoDeudor.Rows)
            {
                lblUltimoTelefonoDeudor.Text = item["Telefono2"].ToString() + " - " + item["CargoContacto"].ToString();
            }
        }

        void verUltimoDireccion()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            DataTable dtDireccionDeudor = new DataTable();
            dtDireccionDeudor = dal.getBuscarDireccionPorRutMaximo(deudor).Tables[0];
            foreach (DataRow item in dtDireccionDeudor.Rows)
            {
                lblUltimoDireccionDeudor.Text = item["Direccion"].ToString() + " - " + item["NombreContacto"].ToString() + " - " + item["CargoContacto"].ToString();
            }
        }

        void verUltimoEmail()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            DataTable dtEmailDeudor = new DataTable();
            dtEmailDeudor = dal.getBuscarEmailPorRutMaximo(deudor).Tables[0];
            foreach (DataRow item in dtEmailDeudor.Rows)
            {
                lblUltimoEmailDeudor.Text = item["Email2"].ToString() + " - " + item["CargoContacto"].ToString();
            }
        }

        void cambioMandante()
        {
            Mandante man = new Mandante();
            man.IdMandante = Convert.ToInt32(Session["IdMandante"]);
            man.Activo = 1;
            //DataTable dt = new DataTable();
            //dt = dal.getBuscarMandante(man).Tables[0];
            //foreach (DataRow item in dt.Rows)
            //{
            //    if (item["DeudorNomAdic1"].ToString() == string.Empty)
            //    {
            //        divAdic1.Visible = false;
            //    }
            //    else
            //    {
            //        divAdic1.Visible = true;
            //        lblAdic1.Text = item["DeudorNomAdic1"].ToString();
            //    }

            //    if (item["DeudorNomAdic2"].ToString() == string.Empty)
            //    {
            //        divAdic2.Visible = false;
            //    }
            //    else
            //    {
            //        divAdic2.Visible = true;
            //        lblAdic2.Text = item["DeudorNomAdic2"].ToString();
            //    }

            //    if (item["DeudorNomAdic3"].ToString() == string.Empty)
            //    {
            //        divAdic3.Visible = false;
            //    }
            //    else
            //    {
            //        divAdic3.Visible = true;
            //        lblAdic3.Text = item["DeudorNomAdic3"].ToString();
            //    }

            //    if (item["DeudorNomAdic4"].ToString() == string.Empty)
            //    {
            //        divAdic4.Visible = false;
            //    }
            //    else
            //    {
            //        divAdic4.Visible = true;
            //        lblAdic4.Text = item["DeudorNomAdic4"].ToString();
            //    }

            //    if (item["DeudorNomAdic5"].ToString() == string.Empty)
            //    {
            //        divAdic5.Visible = false;
            //    }
            //    else
            //    {
            //        divAdic5.Visible = true;
            //        lblAdic5.Text = item["DeudorNomAdic5"].ToString();
            //    }
            //}
        }




        private decimal _TotalCapital = 0;
        private decimal _TotalSaldo = 0;
        private decimal _Total = 0;
        private decimal _TotalDocs = 0;

        protected void grvDeudasDeudor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string idMandante = Session["IdMandante"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblIdMandante = (Label)e.Row.FindControl("lblIdMandante");
                

                Label _lblCapital = (Label)e.Row.FindControl("lblCapital");
                _TotalCapital += Convert.ToDecimal(_lblCapital.Text);

                Label _lblSaldo = (Label)e.Row.FindControl("lblSaldo");
                _TotalSaldo += Convert.ToDecimal(_lblSaldo.Text);
                
                if (Convert.ToDecimal(_lblSaldo.Text) < 0)
                {
                    e.Row.CssClass = "danger";
                }
                else
                {
                    e.Row.CssClass = "success";
                }


                Label _lblTotal = (Label)e.Row.FindControl("lblTotal");
                _Total += Convert.ToDecimal(_lblTotal.Text);

                Label _lblTotalDocs = (Label)e.Row.FindControl("lblTotalDocs");
                _TotalDocs += Convert.ToDecimal(_lblTotalDocs.Text);
                

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";

                e.Row.Cells[4].Text = _TotalCapital.ToString("n0");
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[5].Text = _TotalSaldo.ToString("n0");
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[6].Text = _Total.ToString("n0");
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[7].Text = _TotalDocs.ToString("n0");
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
                
            }
        }

        
        private decimal _TotalSaldoDetalle = 0;
        private decimal _TotalCapitalDetalle = 0;

        protected void grvDetalleDeuda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string idMandante = Session["IdMandante"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblIdMandante = (Label)e.Row.FindControl("lblIdMandante");

                
                Label _lblCapital = (Label)e.Row.FindControl("lblCapital");
                _TotalCapitalDetalle += Convert.ToDecimal(_lblCapital.Text);

                Label _lblSaldo = (Label)e.Row.FindControl("lblSaldo");
                if (Convert.ToDecimal(_lblSaldo.Text) < 0)
                {
                    e.Row.CssClass = "danger";
                }
                else
                {
                    e.Row.CssClass = "success";
                }

                _TotalSaldoDetalle += Convert.ToDecimal(_lblSaldo.Text);
                
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";

                e.Row.Cells[7].Text = _TotalCapitalDetalle.ToString("n0");
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[8].Text = _TotalSaldoDetalle.ToString("n0");
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

            }
        }

        


        protected void lbtnVerAdicionales_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvDeudasDeudor.Rows[row.RowIndex].FindControl("lblIdMandante");
                Label _lblIdEstadoDeuda = (Label)grvDeudasDeudor.Rows[row.RowIndex].FindControl("lblIdEstadoDeuda");
                Label _IdTipoDocumento = (Label)grvDeudasDeudor.Rows[row.RowIndex].FindControl("IdTipoDocumento");
                string rut = lblRutDeudor.Text;

                deuda.IdMandante = Convert.ToInt32(_lblIdMandante.Text);
                deuda.IdEstadoDeuda = Convert.ToInt32(_lblIdEstadoDeuda.Text);
                deuda.IdTipoDocumento = _IdTipoDocumento.Text;
                deuda.RutDeudor = rut;

                DataTable dt = new DataTable();
                dt = dal.getBuscarDeudaDetalle(deuda).Tables[0];

                //grvDetalleDeudaAdicionales.HeaderRow.Cells[1].Text = "xxxx";
                //grvDetalleDeudaAdicionales.HeaderRow.

                //foreach (DataRow item in dt.Rows)
                //{
                //    lblAdicDeuda1.Text = item["Adic1"].ToString();
                //    lblAdicDeuda2.Text = item["Adic2"].ToString();
                //    lblAdicDeuda3.Text = item["Adic3"].ToString();
                //    lblAdicDeuda4.Text = item["Adic4"].ToString();
                //    lblAdicDeuda5.Text = item["Adic5"].ToString();
                //    lblAdicDeuda6.Text = item["Adic6"].ToString();
                //    lblAdicDeuda7.Text = item["Adic7"].ToString();
                //    lblAdicDeuda8.Text = item["Adic8"].ToString();
                //    lblAdicDeuda9.Text = item["Adic9"].ToString();
                //    lblAdicDeuda10.Text = item["Adic10"].ToString();
                //}

                man.IdMandante = Convert.ToInt32(_lblIdMandante.Text);
                man.Activo = 1;
                DataTable dtAdicionales = new DataTable();
                dtAdicionales = dal.getBuscarMandante(man).Tables[0];

                
                grvDetalleDeudaAdicionales.DataSource = dt;
                grvDetalleDeudaAdicionales.DataBind();

                foreach (DataRow item in dtAdicionales.Rows)
                {
                    if (item["DeudaNomAdic1"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[3].Text = item["DeudaNomAdic1"].ToString();
                    }
                    if (item["DeudaNomAdic2"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[4].Text = item["DeudaNomAdic2"].ToString();
                    }
                    if (item["DeudaNomAdic3"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[5].Text = item["DeudaNomAdic3"].ToString();
                    }
                    if (item["DeudaNomAdic4"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[6].Text = item["DeudaNomAdic4"].ToString();
                    }
                    if (item["DeudaNomAdic5"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[7].Text = item["DeudaNomAdic5"].ToString();
                    }
                    if (item["DeudaNomAdic6"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[8].Text = item["DeudaNomAdic6"].ToString();
                    }
                    if (item["DeudaNomAdic7"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[9].Text = item["DeudaNomAdic7"].ToString();
                    }
                    if (item["DeudaNomAdic8"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[10].Text = item["DeudaNomAdic8"].ToString();
                    }
                    if (item["DeudaNomAdic9"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[11].Text = item["DeudaNomAdic9"].ToString();
                    }
                    if (item["DeudaNomAdic10"].ToString() != string.Empty)
                    {
                        grvDetalleDeudaAdicionales.HeaderRow.Cells[12].Text = item["DeudaNomAdic10"].ToString();
                    }
                }

                ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "show", "$(function () { $('#" + Panel2.ClientID + "').modal('show'); });", true);
                UpdatePanel3.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
        

        protected void ibtnAgregarTelefonoDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                proveedorUbicabilidad();
                lblUsuario.Text = Session["variableUsuario"].ToString();
                txtTelefono.Text = string.Empty;
                ddlCodigoArea.ClearSelection();

                ScriptManager.RegisterStartupScript(UpdatePanel4, UpdatePanel4.GetType(), "show", "$(function () { $('#" + Panel3.ClientID + "').modal('show'); });", true);
                UpdatePanel4.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnListarTelefonoDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                buscarTelefono();
                ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "show", "$(function () { $('#" + Panel4.ClientID + "').modal('show'); });", true);
                UpdatePanel5.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscarTelefono()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            grvTelefonos.DataSource = dal.getBuscarTelefonoPorRut(deudor);
            grvTelefonos.DataBind();
        }

        void buscarDireccion()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            grvDirecciones.DataSource = dal.getBuscarDireccionPorRut(deudor);
            grvDirecciones.DataBind();
        }

        void buscarEmail()
        {
            deudor.RutDeudor = lblRutDeudor.Text;
            grvEmail.DataSource = dal.getBuscarEmailPorRut(deudor);
            grvEmail.DataBind();
        }

        protected void ibtnAgregarDireccionDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                proveedorUbicabilidad();
                comuna();
                lblUsuarioDireccion.Text = Session["variableUsuario"].ToString();

                txtCalle.Text = string.Empty;
                txtNumero.Text = string.Empty;
                txtResto.Text = string.Empty;
                
                ScriptManager.RegisterStartupScript(UpdatePanel6, UpdatePanel6.GetType(), "show", "$(function () { $('#" + Panel5.ClientID + "').modal('show'); });", true);
                UpdatePanel6.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnListarrDireccionDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                buscarDireccion();
                ScriptManager.RegisterStartupScript(UpdatePanel7, UpdatePanel7.GetType(), "show", "$(function () { $('#" + Panel6.ClientID + "').modal('show'); });", true);
                UpdatePanel7.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnGrabarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                UbicDireccion dir = new UbicDireccion();
                dir.Calle = txtCalle.Text;
                dir.Comuna = ddlComunaDireccion.SelectedItem.ToString();
                dir.Rut = lblRutDeudor.Text;
                dir.IdProveedorUbic = Convert.ToInt32(ddlOrigen.SelectedValue);
                dir.Numero = txtNumero.Text.Trim();
                dir.Resto = txtResto.Text.Trim();
                dir.IdUsuarioIngreso = Convert.ToInt32(Session["variableIdUsuario"]);
                dir.CargoContacto = txtCargoContactoDireccion.Text;
                dir.NombreContacto = txtNomContactoDireccion.Text;

                string existe = dal.setInUbicDireccion(dir);
                if (existe == "1")
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "La dirección ingresado ya existe en la BD";
                    return;
                }
                
                verUltimoDireccion();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnGrabarDireccionesEstados_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow item in grvDirecciones.Rows)
                {
                    Label _lblIdDireccion = (Label)grvDirecciones.Rows[item.RowIndex].FindControl("lblIdDireccion");
                    RadioButtonList _rbtnEstado = (RadioButtonList)grvDirecciones.Rows[item.RowIndex].FindControl("rbtnEstado");
                    string idDireccion = _lblIdDireccion.Text;
                    string idEstado = _rbtnEstado.SelectedValue;

                    UbicDireccion dir = new UbicDireccion();
                    dir.IdDireccion = Convert.ToInt32(idDireccion);
                    dir.IdEstadoUbic = Convert.ToInt32(idEstado);

                    dal.setUpDireccion(dir);
                }
                verUltimoDireccion();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnAgregarEmailDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                proveedorUbicabilidad();
                //comuna();
                lblUsuarioEmail.Text = Session["variableUsuario"].ToString();
                txtCorreo.Text = string.Empty;
                
                ScriptManager.RegisterStartupScript(UpdatePanel8, UpdatePanel8.GetType(), "show", "$(function () { $('#" + Panel7.ClientID + "').modal('show'); });", true);
                UpdatePanel8.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnListarrEmailDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                buscarEmail();
                ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "show", "$(function () { $('#" + Panel8.ClientID + "').modal('show'); });", true);
                UpdatePanel9.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ibtnEnviarEmailDeudor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnGrabarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                UbicEmail email = new UbicEmail();
                email.Email = txtCorreo.Text;
                email.IdusuarioIngreso = Convert.ToInt32(Session["variableIdUsuario"]);
                email.IdProveedorUbic = Convert.ToInt32(ddlOrigenEmail.SelectedValue);
                email.Rut = lblRutDeudor.Text;
                email.TipoEmail = ddlTipoEmail.SelectedValue;
                email.NombreContacto = txtNombreContactoEmail.Text;
                email.CargoContacto = txtCargoContactoEmail.Text;
                email.NombreContacto = txtNombreContactoEmail.Text;

                string existe = dal.setInUbicEmail(email);
                if (existe == "1")
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "El email ingresado ya existe en la BD";
                    return;
                }
                verUltimoEmail();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void proveedorUbicabilidad()
        {
            ddlProveedorUbicTelefono.DataSource = dal.getBuscarProveedorUbic(1);
            ddlProveedorUbicTelefono.DataValueField = "IdProveedorUbic";
            ddlProveedorUbicTelefono.DataTextField = "NomProveedorUbic";
            ddlProveedorUbicTelefono.DataBind();

            ddlOrigen.DataSource = dal.getBuscarProveedorUbic(1);
            ddlOrigen.DataValueField = "IdProveedorUbic";
            ddlOrigen.DataTextField = "NomProveedorUbic";
            ddlOrigen.DataBind();

            ddlOrigenEmail.DataSource = dal.getBuscarProveedorUbic(1);
            ddlOrigenEmail.DataValueField = "IdProveedorUbic";
            ddlOrigenEmail.DataTextField = "NomProveedorUbic";
            ddlOrigenEmail.DataBind();
        }

        void comuna()
        {
            Comuna com = new Comuna();
            ddlComunaDireccion.DataSource = dal.getBuscarComuna(com);
            ddlComunaDireccion.DataTextField = "NomComuna";
            ddlComunaDireccion.DataValueField = "idComuna";
            ddlComunaDireccion.DataBind();
        }

        protected void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            try
            {
                UbicTelefono tel = new UbicTelefono();
                tel.IdArea = ddlCodigoArea.SelectedValue;
                tel.IdProveedorUbic = Convert.ToInt32(ddlProveedorUbicTelefono.SelectedValue);

                if (txtTelefono.Text.Length != 9)
                {
                    lblInfo.Text = "No puede ingresar un numero de telefono menor o mayor a 9 digitos";
                    divAlerta.Visible = true;
                    return;
                }
                tel.Telefono = txtTelefono.Text.Trim();
                tel.Rut = lblRutDeudor.Text;
                tel.IdUsuarioIngreso = Convert.ToInt32(Session["variableIdUsuario"]);
                tel.TipoTelefono = ddlTipoTelefono.SelectedValue;
                tel.NombreContacto = txtNombreContactoTelefono.Text;
                tel.CargoContacto = txtCargoContactoTelefono.Text;

                string existe = dal.setInUbicTelefono(tel);
                if (existe == "1")
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "El teléfono ingresado ya existe en la BD";
                    return;
                }

                deudor.RutDeudor = lblRutDeudor.Text;
                verUltimoTelefono();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void paginacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList _rbtnEstado = (RadioButtonList)e.Row.FindControl("rbtnEstado");
                Label _lblIdEstado = (Label)e.Row.FindControl("lblIdEstado");
                _rbtnEstado.SelectedValue = _lblIdEstado.Text;

                DropDownList _ddlTipoTelefono = (DropDownList)e.Row.FindControl("ddlTipoTelefono");
                Label _lblIdTipoTelefono = (Label)e.Row.FindControl("lblIdTipoTelefono");
                if (_lblIdTipoTelefono.Text != string.Empty)
                {
                    _ddlTipoTelefono.SelectedValue = _lblIdTipoTelefono.Text;
                }
            }
        }

        protected void paginacion2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string solicitado = DataBinder.Eval(e.Row.DataItem, "SOLICITADO").ToString();
                //Button _btnSolicitarPermiso = (Button)e.Row.FindControl("btnSolicitarPermiso");
                //ImageButton _imgDescargar = (ImageButton)e.Row.FindControl("imgDescargar");

                RadioButtonList _rbtnEstado = (RadioButtonList)e.Row.FindControl("rbtnEstado");
                Label _lblIdEstado = (Label)e.Row.FindControl("lblIdEstado");
                _rbtnEstado.SelectedValue = _lblIdEstado.Text;
            }
        }

        protected void paginacion3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string solicitado = DataBinder.Eval(e.Row.DataItem, "SOLICITADO").ToString();
                //Button _btnSolicitarPermiso = (Button)e.Row.FindControl("btnSolicitarPermiso");
                //ImageButton _imgDescargar = (ImageButton)e.Row.FindControl("imgDescargar");

                RadioButtonList _rbtnEstado = (RadioButtonList)e.Row.FindControl("rbtnEstado");
                Label _lblIdEstado = (Label)e.Row.FindControl("lblIdEstado");
                _rbtnEstado.SelectedValue = _lblIdEstado.Text;

                DropDownList _ddlTipoEmail = (DropDownList)e.Row.FindControl("ddlTipoEmail");
                Label _lblIdTipoEmail = (Label)e.Row.FindControl("lblIdTipoEmail");
                if (_lblIdTipoEmail.Text != string.Empty)
                {
                    _ddlTipoEmail.SelectedValue = _lblIdTipoEmail.Text;
                }
            }
        }

        protected void lbtnGrabarEstados_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow item in grvTelefonos.Rows)
                {
                    Label _lblIdTelefono = (Label)grvTelefonos.Rows[item.RowIndex].FindControl("lblIdTelefono");
                    RadioButtonList _rbtnEstado = (RadioButtonList)grvTelefonos.Rows[item.RowIndex].FindControl("rbtnEstado");

                    TextBox _txtNombreContactoTelefono = (TextBox)grvTelefonos.Rows[item.RowIndex].FindControl("txtNombreContactoTelefono");
                    DropDownList _ddlTipoTelefono = (DropDownList)grvTelefonos.Rows[item.RowIndex].FindControl("ddlTipoTelefono");


                    string idTelefono = _lblIdTelefono.Text;
                    string idEstado = _rbtnEstado.SelectedValue;

                    UbicTelefono tel = new UbicTelefono();
                    tel.IdTelefono = Convert.ToInt32(idTelefono);
                    tel.IdEstadoUbic= Convert.ToInt32(idEstado);
                    tel.IdUsuarioModif = Convert.ToInt32(Session["variableIdUsuario"]);
                    tel.NombreContacto = _txtNombreContactoTelefono.Text;
                    tel.TipoTelefono = _ddlTipoTelefono.SelectedValue;

                    dal.setUpTelefono(tel);
                }

                verUltimoTelefono();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        protected void lbtnGrabarEmailEstados_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow item in grvEmail.Rows)
                {
                    Label _lblIdEmail = (Label)grvEmail.Rows[item.RowIndex].FindControl("lblIdEmail");
                    RadioButtonList _rbtnEstado = (RadioButtonList)grvEmail.Rows[item.RowIndex].FindControl("rbtnEstado");
                    TextBox _txtNombreContactoEmail = (TextBox)grvEmail.Rows[item.RowIndex].FindControl("txtNombreContactoEmail");
                    DropDownList _ddlTipoEmail = (DropDownList)grvEmail.Rows[item.RowIndex].FindControl("ddlTipoEmail");

                    string idEmail = _lblIdEmail.Text;
                    string idEstado = _rbtnEstado.SelectedValue;

                    UbicEmail email = new UbicEmail();
                    email.IdEmail = Convert.ToInt32(idEmail);
                    email.IdEstadoUbic = Convert.ToInt32(idEstado);
                    email.NombreContacto = _txtNombreContactoEmail.Text;
                    email.TipoEmail = _ddlTipoEmail.SelectedValue;

                    dal.setUpEmail(email);
                }

                verUltimoEmail();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Session["VarRutDeudor"] = null;
            Response.Redirect("Principal.aspx");
        }

        protected void lbtnNuevaGestion_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("InGestion.aspx?r=" + lblRutDeudor.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnHistorialGestiones_Click(object sender, EventArgs e)
        {
            try
            {
                buscarHistorialGestiones();
                ScriptManager.RegisterStartupScript(UpdatePanel10, UpdatePanel10.GetType(), "show", "$(function () { $('#" + Panel9.ClientID + "').modal('show'); });", true);
                UpdatePanel10.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscarHistorialGestiones()
        {
            grvHistorialGestiones.DataSource = dal.getBuscarHistorialGestiones(lblRutDeudor.Text, Convert.ToInt32(Session["IdMandante"].ToString()));
            grvHistorialGestiones.DataBind();
        }

        protected void lbtnIrDeudor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["VarRutDeudor"] != null)
                {
                    string rutDeudor = Session["VarRutDeudor"].ToString();
                    if (rutDeudor == null)
                    {
                        Response.Redirect("DeudorIn.aspx");
                    }
                    else
                    {
                        Response.Redirect("DeudorIn.aspx?rut=" + rutDeudor);
                    }
                }
                else
                {
                    Response.Redirect("DeudorIn.aspx");
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnDetalleDeudaTotal_Click(object sender, EventArgs e)
        {
            try
            {
                string rut = lblRutDeudor.Text;

                deuda.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                deuda.Sucursal = "0";
                deuda.RutDeudor = rut;

                DataTable dt = new DataTable();
                dt = dal.getBuscarDeudaDetalle(deuda).Tables[0];
                Session["sessionDetalleDeudaExcel"] = dt;
                grvDetalleDeuda.DataSource = dt;
                grvDetalleDeuda.DataBind();

                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", true);
                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnExcelDetalleDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Session["sessionDetalleDeudaExcel"] as DataTable;
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
        
        protected void lbtnExcelDetallePago_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Session["sessionDetallePagoExcel"] as DataTable;
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

        private decimal _TotalPagos = 0;
        private decimal _TotalDocsPagos = 0;

        protected void grvPagos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string idMandante = Session["IdMandante"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblCantidadDocumentos = (Label)e.Row.FindControl("lblCantidadDocumentos");
                _TotalDocsPagos += Convert.ToDecimal(_lblCantidadDocumentos.Text);

                Label _lblPagos = (Label)e.Row.FindControl("lblPagos");
                _TotalPagos += Convert.ToDecimal(_lblPagos.Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";

                e.Row.Cells[1].Text = _TotalDocsPagos.ToString("n0");
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = _TotalPagos.ToString("n0");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }

        protected void btnDetallePagos_Click(object sender, EventArgs e)
        {
            try
            {
                string rut = lblRutDeudor.Text;

                string idMandante = Session["IdMandante"].ToString();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                Label _lblIdSucursal = (Label)grvPagos.Rows[row.RowIndex].FindControl("lblIdSucursal");
                
                DataTable dt = new DataTable();
                dt = dal.getBuscarDetallePagoRut(_lblIdSucursal.Text, null, 0, null, null, rut).Tables[0];
                Session["sessionDetallePagoExcel"] = dt;
                grvDetallePagos.DataSource = dt;
                grvDetallePagos.DataBind();
                grvDetallePagos.HeaderRow.TableSection = TableRowSection.TableHeader;
                
                ScriptManager.RegisterStartupScript(UpdatePanel12, UpdatePanel12.GetType(), "show", "$(function () { $('#" + Panel11.ClientID + "').modal('show'); });", true);
                UpdatePanel12.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnDetallePagosTotal_Click(object sender, EventArgs e)
        {
            try
            {
                string rut = lblRutDeudor.Text;

                DataTable dt = new DataTable();
                dt = dal.getBuscarDetallePagoRut(null, null, 0, null, null, rut).Tables[0];
                grvDetallePagos.DataSource = dt;
                grvDetallePagos.DataBind();
                grvDetallePagos.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterStartupScript(UpdatePanel12, UpdatePanel12.GetType(), "show", "$(function () { $('#" + Panel11.ClientID + "').modal('show'); });", true);
                UpdatePanel12.Update();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        private decimal _TotalPagosDetalle = 0;
        protected void grvDetallePagos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblValorBaja = (Label)e.Row.FindControl("lblValorBaja");
                _TotalPagosDetalle += Convert.ToDecimal(_lblValorBaja.Text);
                
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";
                
                e.Row.Cells[10].Text = _TotalPagosDetalle.ToString("n0");
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }

        protected void lbtnEditarDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdDeuda = (Label)grvDetalleDeuda.Rows[row.RowIndex].FindControl("lblIdDeuda");
                Response.Redirect("InDeuda.aspx?id=" + _lblIdDeuda.Text);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "popup", "window.open('InDeuda.aspx?id='" + _lblIdDeuda.Text + "','_blank')", true);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}