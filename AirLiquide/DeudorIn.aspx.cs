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
using System.Collections.Specialized;

namespace Cobros30
{
    public partial class DeudorIn : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Mandante man = new Mandante();
        Deudor deudor = new Deudor();
        Comun comunes = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = string.Empty;

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnGrabarArchivo);

                if (!this.IsPostBack)
                {
                    mandante();
                    etapaCobranza();
                    probabilidadCobro();
                    tipoPersona();
                    sector();
                    cambioMandante();

                    tipoDocumento();
                    asignacion();

                    permisos();

                    condicionPago();

                    string _rut = Convert.ToString(Request.QueryString["rut"]);
                    if (_rut != null)
                    {
                        txtRutDeudor.Text = _rut;
                        
                        buscar();
                    }
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
                btnGuardar.Visible = false;
                lbtnNuevaDeuda.Visible = false;
            }
        }

        void tipoDocumento() {
            ddlTipoDocumento.DataSource = dal.getBuscarTipoDocumento(1);
            ddlTipoDocumento.DataValueField = "IdTipoDocumento";
            ddlTipoDocumento.DataTextField = "NomTipoDocumento";
            ddlTipoDocumento.DataBind();
        }
        void asignacion() {
            ddlAsignacion.DataSource = dal.getBuscarAsignacion(1, Convert.ToInt32(Session["IdMandante"]));
            ddlAsignacion.DataValueField = "IdAsignacion";
            ddlAsignacion.DataTextField = "NomAsignacion";
            ddlAsignacion.DataBind();
        }

        protected void txtRutDeudor_TextChanged(object sender, EventArgs e)
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

        protected void lbtnBuscarDeudor_Click(object sender, EventArgs e)
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

        void buscar()
        {
            if (txtRutDeudor.Text == string.Empty)
            {
                return;
            }
            
            Deudor deu = new Deudor();
            deu.RutDeudor = txtRutDeudor.Text;
            Session["VarRutDeudor"] = txtRutDeudor.Text;
            //deu.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
            deu.IdMandante = Convert.ToInt32(Session["IdMandante"]);
            DataTable dt = new DataTable();
            dt = dal.getBuscarDeudor(deu).Tables[0];
            
            if (dt.Rows.Count==0)
            {
                divAlerta.Visible = true;
                lblInfo.Text = "Rut no se encuentra ingresado, el rut será creado como nuevo deudor para el cliente seleccionado.";
                divAlerta.Attributes["class"] = "alert alert-danger";

                limpiar(this.Controls);
                lbtnNuevaDeuda.Visible = false;
                divDeuda.Visible = false;
                return;
            }
            else
            {
                divDeuda.Visible = true;
                lbtnNuevaDeuda.Visible = true;
            }

            foreach (DataRow item in dt.Rows)
            {
                txtAdic1.Text = item["adic1"].ToString();
                txtAdic2.Text = item["adic2"].ToString();
                txtAdic3.Text = item["adic3"].ToString();
                txtAdic4.Text = item["adic4"].ToString();
                txtAdic5.Text = item["adic5"].ToString();

                txtCampanaCliente.Text = item["CampanaCliente"].ToString();
                txtNombreDeudor.Text = item["NombreDeudor"].ToString();
                txtNombreRepresentanteLegal.Text = item["RepLegalNombre"].ToString();
                txtObservacion.Text = item["observacion"].ToString();
                txtRutRepresentanteLegal.Text = item["RepLegalRut"].ToString();

                if (item["IdEtapaCobranza"].ToString() != string.Empty)
                {
                    ddlEtapaCobranza.SelectedValue = item["IdEtapaCobranza"].ToString();
                }

                //if (item["IdMandante"].ToString() != string.Empty)
                //{
                //    ddlMandante.SelectedValue = item["IdMandante"].ToString();
                //}

                if (item["IdProbabilidadCobro"].ToString() != string.Empty)
                {
                    ddlProbCobro.SelectedValue = item["IdProbabilidadCobro"].ToString();
                }

                if (item["IdTipoPersona"].ToString() != string.Empty)
                {
                    ddlTipoPersona.SelectedValue = item["IdTipoPersona"].ToString();
                }

                if (item["IdCondicionPago"].ToString() != string.Empty)
                {
                    ddlCondicionPago.SelectedValue = item["IdCondicionPago"].ToString();
                }

                if (item["IdSector"].ToString() != string.Empty)
                {
                    ddlSector.SelectedValue = item["IdSector"].ToString();
                }

                txtFechaTerminoContrato.Text = item["FechaTerminoContrato"].ToString();

                if (item["Renovable"].ToString() != string.Empty)
                {
                    ddlRenovable.SelectedValue = item["Renovable"].ToString();
                }

                if (item["FechaIngresoERP"].ToString() != string.Empty)
                {
                    txtFechaIngreso.Text = Convert.ToDateTime((item["FechaIngresoERP"])).ToString();
                } 

                txtResponsableComercial.Text = item["ResponsableComercial"].ToString();
                

            }

            //buscarArchivos(deu, Convert.ToInt32(ddlMandante.SelectedValue));
            buscarArchivos(deu, Convert.ToInt32(Session["IdMandante"]));
            divArchivos.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                deudor.Adic1 = txtAdic1.Text;
                deudor.Adic2 = txtAdic2.Text;
                deudor.Adic3 = txtAdic3.Text;
                deudor.Adic4 = txtAdic4.Text;
                deudor.Adic5 = txtAdic5.Text;

                deudor.CampanaCliente = txtCampanaCliente.Text;
                deudor.IdEtapaCobranza = Convert.ToInt32(ddlEtapaCobranza.SelectedValue);
                //deudor.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
                deudor.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                deudor.IdProbabilidadCobro = Convert.ToInt32(ddlProbCobro.SelectedValue);

                deudor.IdTipoPersona = Convert.ToInt32(ddlTipoPersona.SelectedValue);
                deudor.IdUsuarioAsig = Convert.ToInt32(Session["variableIdUsuario"]);
                deudor.IdUsuarioIngreso = Session["variableIdUsuario"].ToString();
                deudor.IdUsuarioModif = Session["variableIdUsuario"].ToString();
                deudor.NombreDeudor = txtNombreDeudor.Text;
                deudor.Observacion = txtObservacion.Text;
                deudor.RepLegalNombre = txtRutRepresentanteLegal.Text;
                deudor.RepLegalRut = txtRutRepresentanteLegal.Text;
                deudor.RutDeudor = txtRutDeudor.Text;

                deudor.IdCondicionPago = Convert.ToInt32(ddlCondicionPago.SelectedValue);

                //****
                deudor.rut = "";
                //****
                if (txtFechaIngreso.Text != string.Empty)
                {
                    deudor.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                }
                else
                {
                    deudor.FechaIngreso = null;
                }

                if (ddlRenovable.SelectedValue == "9999")
                {
                    deudor.Renovable = null;
                }
                else
                {
                    deudor.Renovable = ddlRenovable.SelectedValue;
                }

                if (txtFechaTerminoContrato.Text != string.Empty)
                {
                    deudor.FechaTerminoContrato = Convert.ToDateTime(txtFechaTerminoContrato.Text);
                }
                else
                {
                    deudor.FechaTerminoContrato = null;
                }

                if (ddlSector.SelectedValue != "0")
                {
                    deudor.IdSector = ddlSector.SelectedValue;
                }

                deudor.ResponsableComercial = txtResponsableComercial.Text;

                dal.setInDeudor(deudor);

                lblInfo.Text = "Deudor grabado Correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;

                //limpiar(this.Controls);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void mandante() {
            man.Activo = 1;
            ddlMandante.DataSource = dal.getBuscarMandante(man);
            ddlMandante.DataTextField = "NomMandante";
            ddlMandante.DataValueField = "IdMandante";
            ddlMandante.DataBind();
        }

        void etapaCobranza(){
            ddlEtapaCobranza.DataSource = dal.getBuscarEtapaCobranza(1);
            ddlEtapaCobranza.DataValueField = "IdEtapaCobranza";
            ddlEtapaCobranza.DataTextField = "NomEtapaCobranza";
            ddlEtapaCobranza.DataBind();
        }

        void probabilidadCobro() {
            ddlProbCobro.DataSource = dal.getBuscarProbabilidadCobro(1);
            ddlProbCobro.DataValueField = "IdProbabilidadCobro";
            ddlProbCobro.DataTextField = "NomProbabilidadCobro";
            ddlProbCobro.DataBind();
        }

        void tipoPersona(){
            ddlTipoPersona.DataSource = dal.getBuscarTipoPersona(1);
            ddlTipoPersona.DataValueField = "IdTipoPersona";
            ddlTipoPersona.DataTextField = "NomTipoPersona";
            ddlTipoPersona.DataBind();
        }
        
        protected void ddlEtapaCobranza_DataBound(object sender, EventArgs e)
        {
            ddlEtapaCobranza.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlProbCobro_DataBound(object sender, EventArgs e)
        {
            ddlProbCobro.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }
        protected void ddlTipoPersona_DataBound(object sender, EventArgs e)
        {
            ddlTipoPersona.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void btnGrabarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosDeudor/";
                if (fuArchivo.HasFile)
                {
                    string idUsuario = Session["variableIdUsuario"].ToString();
                    //string idMandante = ddlMandante.SelectedValue;
                    string idMandante = Session["IdMandante"].ToString();
                    deudor.RutDeudor = txtRutDeudor.Text;
                    string filepath = Server.MapPath(carpeta + idMandante + "_" + txtRutDeudor.Text + "_" + fuArchivo.FileName);
                    string usuario = Session["variableUsuario"].ToString();

                    if (System.IO.File.Exists(filepath))
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "El archivo ya existe. Sube un archivo con diferente nombre";
                        return;
                    }

                    fuArchivo.SaveAs(filepath);

                    string nombreOriginal = "";

                    if (txtNombreArchivo.Text == string.Empty)
                    {
                        nombreOriginal = fuArchivo.FileName;
                    }
                    else
                    {
                        nombreOriginal = txtNombreArchivo.Text; ;
                    }

                    string nombreArchivo = idMandante + "_" + txtRutDeudor.Text + "_" + fuArchivo.FileName;
                    //dal.setInDeudorArchivos(deudor, Convert.ToInt32(ddlMandante.SelectedValue), nombreArchivo, Convert.ToInt32(idUsuario), txtDescripcion.Text, nombreOriginal);
                    dal.setInDeudorArchivos(deudor, Convert.ToInt32(Session["IdMandante"]), nombreArchivo, Convert.ToInt32(idUsuario), txtDescripcion.Text, nombreOriginal);

                    //buscar();
                    //asyncLinkButton();
                    //limpiar(this.Controls);

                    //buscarArchivos(deudor, Convert.ToInt32(ddlMandante.SelectedValue));
                    buscarArchivos(deudor, Convert.ToInt32(Session["IdMandante"]));
                }
                else
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "Favor seleccionar un archivo";
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void grvDetalleBiblioteca_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosDeudor/";

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Perfil per = new Perfil();

                    ImageButton _imgVisualizar = (ImageButton)e.Row.FindControl("imgVisualizar");
                    Label _lblNombreArchivo = (Label)e.Row.FindControl("lblRutaArchivo");
                    ImageButton _imgEliminar = (ImageButton)e.Row.FindControl("imgEliminarArchivo");
                    Label _lblUsuario = (Label)e.Row.FindControl("lblUsuario");

                    //PERFILES
                    DataTable dt = new DataTable();
                    per.IdPerfil = Convert.ToInt32(Session["variableIdUsuario"].ToString());
                    dt = dal.getBuscarPerfil(per).Tables[0];
                    string usuario = Session["variableUsuario"].ToString();

                    foreach (DataRow item in dt.Rows)
                    {
                        string perfil = item["IDPERFIL"].ToString();

                        if (perfil == "1")
                        {
                            break;
                        }

                        if (perfil == "2")
                        {
                            if (usuario == _lblUsuario.Text)
                            {
                                _imgEliminar.Visible = true;
                            }
                            else
                            {
                                _imgEliminar.Visible = false;
                            }
                            break;
                        }

                        if (perfil == "3")
                        {
                            _imgEliminar.Visible = false;
                            break;
                        }
                    }
                    //FIN PERFILES
                    if (usuario == _lblUsuario.Text)
                    {
                        _imgEliminar.Visible = true;
                    }
                    else
                    {
                        _imgEliminar.Visible = false;
                    }
                    
                    ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

                    string nombreArchivo = _lblNombreArchivo.Text;
                    string tipoArchivo = nombreArchivo;
                    tipoArchivo = tipoArchivo.Substring(tipoArchivo.LastIndexOf(".") + 1).ToLower();

                    FileInfo fi = new FileInfo(Server.MapPath(carpeta + _lblNombreArchivo.Text));
                    string extension = fi.Extension.ToString().ToLower();

                    NameValueCollection imageExtensions = new NameValueCollection();
                    imageExtensions.Add(".jpg", "image/jpeg");
                    imageExtensions.Add(".gif", "image/gif");
                    imageExtensions.Add(".png", "image/png");
                    imageExtensions.Add(".tiff", "image/tiff");
                    imageExtensions.Add(".bmp", "image/bmp");

                    if (imageExtensions.AllKeys.Contains(extension))
                    {
                        _imgVisualizar.ImageUrl = carpeta + _lblNombreArchivo.Text;
                        _imgVisualizar.Height = 32;
                    }
                    else
                    {
                        scriptManager.RegisterPostBackControl(_imgVisualizar);
                    }

                    if (tipoArchivo == "xls")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_xls.png";
                    }
                    if (tipoArchivo == "xlsx")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_xls.png";
                    }
                    if (tipoArchivo == "doc")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_doc.png";
                    }
                    if (tipoArchivo == "docx")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_doc.png";
                    }
                    if (tipoArchivo == "rar")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_rar.png";
                    }
                    if (tipoArchivo == "zip")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_zip.png";
                    }
                    if (tipoArchivo == "pdf")
                    {
                        _imgVisualizar.ImageUrl = "assets/img/file_extension_pdf.png";
                    }
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
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

        protected void imgEliminarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosDeudor/";
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;
                //string idCliente = Session["idCliente"].ToString();
                Label _lblId = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblId");
                Label _lblIdMandante = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblIdMandante");
                Label _lblRutaArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblRutaArchivo");
                deudor.RutDeudor = txtRutDeudor.Text;
                dal.setDelDeudorArchivo(deudor, Convert.ToInt32(_lblIdMandante.Text), Convert.ToInt32(_lblId.Text));
                File.Delete(Server.MapPath(carpeta + _lblRutaArchivo.Text));

                buscarArchivos(deudor,Convert.ToInt32(_lblIdMandante.Text));
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

        protected void ddlMandante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cambioMandante();
                limpiar(this.Controls);
                //buscar();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void cambioMandante()
        {
            //man.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
            man.IdMandante = Convert.ToInt32(Session["IdMandante"]);
            man.Activo = 1;
            DataTable dt = new DataTable();
            dt = dal.getBuscarMandante(man).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                if (item["DeudorNomAdic1"].ToString() == string.Empty)
                {
                    divAdicc1.Visible = false;
                }
                else
                {
                    divAdicc1.Visible = true;
                    lblAdic1.Text = item["DeudorNomAdic1"].ToString();
                }

                if (item["DeudorNomAdic2"].ToString() == string.Empty)
                {
                    divAdicc2.Visible = false;
                }
                else
                {
                    divAdicc2.Visible = true;
                    lblAdic2.Text = item["DeudorNomAdic2"].ToString();
                }

                if (item["DeudorNomAdic3"].ToString() == string.Empty)
                {
                    divAdicc3.Visible = false;
                }
                else
                {
                    divAdicc3.Visible = true;
                    lblAdic3.Text = item["DeudorNomAdic3"].ToString();
                }

                if (item["DeudorNomAdic4"].ToString() == string.Empty)
                {
                    divAdicc4.Visible = false;
                }
                else
                {
                    divAdicc4.Visible = true;
                    lblAdic4.Text = item["DeudorNomAdic4"].ToString();
                }

                if (item["DeudorNomAdic5"].ToString() == string.Empty)
                {
                    divAdicc5.Visible = false;
                }
                else
                {
                    divAdicc5.Visible = true;
                    lblAdic5.Text = item["DeudorNomAdic5"].ToString();
                }
            }
        }


        public void limpiar(ControlCollection controles)
        {
            //foreach (Control control in controles)
            //{
            //    if (control is TextBox)
            //        ((TextBox)control).Text = string.Empty;
            //    else if (control is DropDownList)
            //        ((DropDownList)control).ClearSelection();
            //    else if (control is RadioButtonList)
            //        ((RadioButtonList)control).ClearSelection();
            //    else if (control is CheckBoxList)
            //        ((CheckBoxList)control).ClearSelection();
            //    else if (control is RadioButton)
            //        ((RadioButton)control).Checked = false;
            //    else if (control is CheckBox)
            //        ((CheckBox)control).Checked = false;
            //    else if (control.HasControls())
            //        //Esta linea detécta un Control que contenga otros Controles
            //        //Así ningún control se quedará sin ser limpiado.
            //        limpiar(control.Controls);
            //}

            txtAdic1.Text = string.Empty;
            txtAdic2.Text = string.Empty;
            txtAdic3.Text = string.Empty;
            txtAdic4.Text = string.Empty;
            txtAdic5.Text = string.Empty;
            txtCampanaCliente.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombreArchivo.Text = string.Empty;
            txtNombreDeudor.Text = string.Empty;
            txtNombreRepresentanteLegal.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtRutRepresentanteLegal.Text = string.Empty;
            txtRutDeudor.Text = string.Empty;

            ddlEtapaCobranza.ClearSelection();
            ddlProbCobro.ClearSelection();
            ddlTipoPersona.ClearSelection();
        }

        protected void lbtnNuevaDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                string idUsuario = Session["variableIdUsuario"].ToString();
                string idMandante = Session["IdMandante"].ToString();

                Deuda deuda = new Deuda();
                string rut = txtRutDeudor.Text.Trim();
                string nroDoc = txtNroDocumento.Text.Trim();
                string nroCuota = txtNroCuota.Text.Trim();
                string idTipoDoc = ddlTipoDocumento.SelectedValue;
                string fechaVenc = txtFechaVencimiento.Text;
                string fechaEmision = txtFechaEmision.Text;
                string fechaProtesto = txtFechaProtesto.Text;
                string monto = txtMonto.Text;
                string montoProtesto = txtMontoProtesto.Text;
                string nroCliente = txtNroCliente.Text;
                string sucursal = txtSucursal.Text;
                string centroCosto = txtCentroCosto.Text;
                string rutSubCliente = txtRutSubCliente.Text.Trim();
                string nombreSubCliente = txtNombreSubCliente.Text.Trim();
                string observacion = txtObservacion.Text.Trim();
                string adic1 = txtAdicional1.Text.Trim();
                string adic2 = txtAdicional2.Text.Trim();
                string adic3 = txtAdicional3.Text.Trim();
                string adic4 = txtAdicional4.Text.Trim();
                string adic5 = txtAdicional5.Text.Trim();
                string adic6 = txtAdicional6.Text.Trim();
                string adic7 = txtAdicional7.Text.Trim();
                string adic8 = txtAdicional8.Text.Trim();
                string adic9 = txtAdicional9.Text.Trim();
                string adic10 = txtAdicional10.Text.Trim();

                deuda.RutDeudor = rut;
                deuda.NroDocumento = nroDoc;
                if (nroCuota != string.Empty)
                {
                    deuda.NroCuota = Convert.ToInt32(nroCuota);
                }
                if (idTipoDoc != string.Empty)
                {
                    deuda.IdTipoDocumento = idTipoDoc;
                }
                if (fechaVenc.Trim() != string.Empty)
                {
                    deuda.FechaVencimiento = Convert.ToDateTime(fechaVenc);
                }
                else
                {
                    deuda.FechaVencimiento = null;
                }
                if (fechaEmision.Trim() != string.Empty)
                {
                    deuda.FechaEmision = Convert.ToDateTime(fechaEmision);
                }
                else
                {
                    deuda.FechaEmision = null;
                }
                if (fechaProtesto.Trim() != string.Empty)
                {
                    deuda.FechaProtesto = Convert.ToDateTime(fechaProtesto);
                }
                else
                {
                    deuda.FechaProtesto = null;
                }
                if (monto.Trim() != string.Empty)
                {
                    deuda.DeudaOriginal = Convert.ToDouble(monto);
                    deuda.Saldo = Convert.ToDouble(monto);
                }
                if (montoProtesto.Trim() != string.Empty)
                {
                    deuda.MontoProtesto = Convert.ToDouble(montoProtesto);
                }
                deuda.NumCliente = nroCliente;
                deuda.Sucursal = sucursal;
                deuda.CentroCosto = centroCosto;
                deuda.RutSubCliente = rutSubCliente;
                deuda.NombreSubCliente = nombreSubCliente;
                deuda.Observacion = observacion;
                deuda.Adic1 = adic1;
                deuda.Adic2 = adic2;
                deuda.Adic3 = adic3;
                deuda.Adic4 = adic4;
                deuda.Adic5 = adic5;
                deuda.Adic6 = adic6;
                deuda.Adic7 = adic7;
                deuda.Adic8 = adic8;
                deuda.Adic9 = adic9;
                deuda.Adic10 = adic10;
                deuda.UsuarioCreacion = Convert.ToInt32(idUsuario);
                deuda.IdMandante = Convert.ToInt32(idMandante);
                deuda.IdTipoCarga = 1;

                //asignacion

                deuda.IdAsignacion = Convert.ToInt32(ddlAsignacion.SelectedValue);
                //finAsignacion
                string valor = dal.setInDeuda(deuda);

                limpiarDeuda();

                divAlerta2.Visible = true;
                lblInformacion.Text = "Deuda ingresada correctamente";
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        protected void ddlAsignacion_DataBound(object sender, EventArgs e)
        {
            ddlAsignacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        void limpiarDeuda() {
            txtRutDeudor.Text = string.Empty;
            txtNroDocumento.Text = string.Empty;
            txtNroCuota.Text = string.Empty;
            txtFechaVencimiento.Text = string.Empty;
            txtFechaEmision.Text=string.Empty;
            txtFechaProtesto.Text=string.Empty;
            txtMonto.Text=string.Empty;
            txtMontoProtesto.Text=string.Empty;
            txtNroCliente.Text=string.Empty;
            txtSucursal.Text=string.Empty;
            txtCentroCosto.Text=string.Empty;
            txtRutSubCliente.Text = string.Empty;
            txtNombreSubCliente.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtAdicional1.Text = string.Empty;
            txtAdicional2.Text = string.Empty;
            txtAdicional3.Text = string.Empty;
            txtAdicional4.Text = string.Empty;
            txtAdicional5.Text = string.Empty;
            txtAdicional6.Text = string.Empty;
            txtAdicional7.Text = string.Empty;
            txtAdicional8.Text = string.Empty;
            txtAdicional9.Text = string.Empty;
            txtAdicional10.Text = string.Empty;
            ddlAsignacion.ClearSelection();
            ddlTipoDocumento.ClearSelection();
            txtObservacionDeuda.Text = string.Empty;
        }

        protected void btnDetalleDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                Deuda deuda = new Deuda();

                string rut = txtRutDeudor.Text;

                deuda.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                deuda.IdEstadoDeuda = 0;
                deuda.IdTipoDocumento = "0";
                deuda.RutDeudor = rut;

                DataTable dt = new DataTable();
                dt = dal.getBuscarDeudaDetalle(deuda).Tables[0];
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

        protected void ddlCondicionPago_DataBound(object sender, EventArgs e)
        {
            //ddlCondicionPago.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        void condicionPago() {
            ddlCondicionPago.DataSource = dal.getBuscarCondicionPago(1);
            ddlCondicionPago.DataValueField = "IdCondicionPago";
            ddlCondicionPago.DataTextField = "NomCondicionPago";
            ddlCondicionPago.DataBind();
        }

        protected void ddlSector_DataBound(object sender, EventArgs e)
        {
            ddlSector.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        protected void ddlRenovable_DataBound(object sender, EventArgs e)
        {

        }

        void sector() {
            ddlSector.DataSource = dal.getBuscarSector(1);
            ddlSector.DataValueField = "IdSector";
            ddlSector.DataTextField = "NomSector";
            ddlSector.DataBind();

        }
    }
}