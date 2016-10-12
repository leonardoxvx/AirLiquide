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
    public partial class Mandantes : System.Web.UI.Page
    {
        Datos dal = new Datos();
        //Usuario user = new Usuario();
        Mandante mand = new Mandante();

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                lblInfo.Text = "";
                divAlerta.Visible = false;

                if (!this.Page.IsPostBack)
                {
                    comuna();
                    tipoCliente();
                    tipoInteres();
                    moneda();
                    tipoTipificacion();
                    buscar();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try{
                limpiar(this.Controls);

                hfNewOrEdit.Value = "E";
                divArchivos.Visible = true;
                
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");
                Mandante ma = new Mandante();
                ma.IdMandante = Convert.ToInt32(_lblIdMandante.Text);
                DataTable dt = new DataTable();
                dt = dal.getBuscarMandante(ma).Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    txtIdMandante.Text = item["IdMandante"].ToString();
                    txtIdMandante.Enabled = false;
                    txtNombre.Text = item["NomMandante"].ToString();
                    txtRazonSocial.Text = item["RazonSocial"].ToString();
                    txtGiro.Text = item["Giro"].ToString();
                    txtRut.Text = item["Rut"].ToString();
                    txtDireccion.Text = item["Direccion"].ToString();
                    if (item["IdComuna"].ToString() != string.Empty)
                    {
                        ddlComuna.SelectedValue = item["IdComuna"].ToString();
                    }
                    txtTelefono.Text = item["Telefono"].ToString();
                    txtRepresentanteLegalNombre.Text = item["RepLegalNombre"].ToString();
                    txtRepresentanteLegalRut.Text = item["RepLegalRut"].ToString();
                    txtContactoNombre.Text = item["ContactoNombre"].ToString();
                    txtContactoEmail.Text = item["ContactoEmail"].ToString();
                    txtAdicional1.Text = item["DeudaNomAdic1"].ToString();
                    txtAdicional2.Text = item["DeudaNomAdic2"].ToString();
                    txtAdicional3.Text = item["DeudaNomAdic3"].ToString();
                    txtAdicional4.Text = item["DeudaNomAdic4"].ToString();
                    txtAdicional5.Text = item["DeudaNomAdic5"].ToString();
                    txtAdicional6.Text = item["DeudaNomAdic6"].ToString();
                    txtAdicional7.Text = item["DeudaNomAdic7"].ToString();
                    txtAdicional8.Text = item["DeudaNomAdic8"].ToString();
                    txtAdicional9.Text = item["DeudaNomAdic9"].ToString();
                    txtAdicional10.Text = item["DeudaNomAdic10"].ToString();
                    txtDeudorNomAdic1.Text = item["DeudorNomAdic1"].ToString();
                    txtDeudorNomAdic2.Text = item["DeudorNomAdic2"].ToString();
                    txtDeudorNomAdic3.Text = item["DeudorNomAdic3"].ToString();
                    txtDeudorNomAdic4.Text = item["DeudorNomAdic4"].ToString();
                    txtDeudorNomAdic5.Text = item["DeudorNomAdic5"].ToString();
                    txtTasaMaxConv.Text = item["TasaMaxConv"].ToString();
                    if (item["IdTipoInteres"].ToString() != string.Empty)
                    {
                        ddlTipoInteres.SelectedValue = item["IdTipoInteres"].ToString();
                    }
                    if (item["IdTipoCliente"].ToString() != string.Empty)
                    {
                        ddlTipoCliente.SelectedValue = item["IdTipoCliente"].ToString();
                    }
                    txtInteresesMora.Text = item["InteresMora"].ToString();
                    //
                    if (item["IdMoneda"].ToString() != string.Empty)
                    {
                        ddlMoneda.SelectedValue = item["IdMoneda"].ToString();
                    }
                    if (item["Activo"].ToString() != string.Empty)
                    {
                        ddlActivo.SelectedValue = item["Activo"].ToString();
                    }
                    imgLogo.Src = item["RutaLogo"].ToString();
                    if (item["Skin"].ToString() != string.Empty)
                    {
                        ddlSkins.SelectedValue = item["Skin"].ToString();
                    }

                    if (item["IdTipoTipificacion"].ToString() != string.Empty)
                    {
                        ddlTipoTipificacion.SelectedValue = item["IdTipoTipificacion"].ToString();
                    }
                    //txtRut.Text = item["Skin"].ToString();

                    break;
                }

                buscarArchivos(ma);
                divSearch.Visible = false;
                divAddEdit.Visible = true;
            }
            catch (Exception ex){
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try{
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");
                mand.IdMandante = Convert.ToInt32(_lblIdMandante.Text);
                dal.setDelMandante(mand);

                buscar();

                lblInfo.Text = "Mandante Eliminado Correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;
            }
            catch (Exception ex){
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMandante(mand).Tables[0];
            grvMandantes.DataSource = dt;
            grvMandantes.DataBind();
            grvMandantes.HeaderRow.TableSection = TableRowSection.TableHeader;

            foreach (DataRow item in dt.Rows)
            {
                hfIdMandante.Value = item["IdMandante"].ToString();
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuLogo.HasFile)
                {
                    string carpeta = "assets/img/mandante/" + "logo_" + txtIdMandante.Text + "_" + fuLogo.FileName;
                    fuLogo.SaveAs(Server.MapPath(carpeta));
                    //int IdUsuario = Convert.ToInt16(hfIdUsuario.Value);
                    mand.RutaLogo = carpeta;
                    mand.IdMandante = Convert.ToInt32(txtIdMandante.Text);
                    dal.setUpLogoMandante(mand);
                    //string idUsuario = Session["variableIdUsuario"].ToString();

                    //cambia inmediatamente si es el usuario actual.
                    //if (idUsuario == hfIdUsuario.Value)
                    //{
                    //    Session["variableImagenUsuario"] = carpeta;
                    //    imgUsuario.Src = carpeta;
                    //}
                    imgLogo.Src = carpeta;
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Mandante ma = new Mandante();
                ma.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                ma.ContactoEmail = txtContactoEmail.Text;
                ma.ContactoNombre = txtContactoNombre.Text;
                ma.DeudaNomAdic1 = txtAdicional1.Text;
                ma.DeudaNomAdic2 = txtAdicional2.Text;
                ma.DeudaNomAdic3 = txtAdicional3.Text;
                ma.DeudaNomAdic4 = txtAdicional4.Text;
                ma.DeudaNomAdic5 = txtAdicional5.Text;
                ma.DeudaNomAdic6 = txtAdicional6.Text;
                ma.DeudaNomAdic7 = txtAdicional7.Text;
                ma.DeudaNomAdic8 = txtAdicional8.Text;
                ma.DeudaNomAdic9 = txtAdicional9.Text;
                ma.DeudaNomAdic10 = txtAdicional10.Text;
                ma.DeudorNomAdic1 = txtDeudorNomAdic1.Text;
                ma.DeudorNomAdic2 = txtDeudorNomAdic2.Text;
                ma.DeudorNomAdic3 = txtDeudorNomAdic3.Text;
                ma.DeudorNomAdic4 = txtDeudorNomAdic4.Text;
                ma.DeudorNomAdic5 = txtDeudorNomAdic5.Text;
                ma.Direccion = txtDireccion.Text;
                ma.Giro = txtGiro.Text;
                ma.IdComuna = ddlComuna.SelectedValue;
                ma.IdMandante = Convert.ToInt32(txtIdMandante.Text);
                ma.IdMoneda = Convert.ToInt32(ddlMoneda.SelectedValue);
                ma.IdTipoCliente = Convert.ToInt32(ddlTipoCliente.SelectedValue);
                ma.IdTipoInteres = Convert.ToInt32(ddlTipoInteres.SelectedValue);
                if (txtInteresesMora.Text.Trim() != string.Empty)
                {
                    ma.InteresMora = Convert.ToDouble(txtInteresesMora.Text);
                }
                ma.NomMandante = txtNombre.Text;
                ma.RazonSocial = txtRazonSocial.Text;
                ma.RepLegalNombre = txtRepresentanteLegalNombre.Text;
                ma.RepLegalRut = txtRepresentanteLegalRut.Text;
                ma.Rut = txtRut.Text;
                ma.Skin = ddlSkins.SelectedValue;
                if (ddlTipoTipificacion.SelectedValue != "0")
                {
                    ma.IdTipoTipificacion = Convert.ToInt32(ddlTipoTipificacion.SelectedValue);
                }
                else
                {
                    ma.IdTipoTipificacion = null;
                }
                
                if (txtTasaMaxConv.Text.Trim() != string.Empty)
                {
                    ma.TasaMaxConv = Convert.ToDouble(txtTasaMaxConv.Text);
                }

                ma.Telefono = txtTelefono.Text;

                if (fuLogo.HasFile)
                {
                    string carpeta = "assets/img/mandante/logo_" + txtIdMandante.Text + "_" + fuLogo.FileName;
                    ma.RutaLogo = carpeta;
                }

                if (hfNewOrEdit.Value == "N")
                {
                    DataTable dtMan = new DataTable();
                    Mandante maVal = new Mandante();
                    maVal.IdMandante = Convert.ToInt32(txtIdMandante.Text);
                    dtMan = dal.getBuscarMandante(maVal).Tables[0];
                    if (dtMan.Rows.Count!=0)
                    {
                        lblInfo.Text = "El codido del mandante " + txtIdMandante.Text + " ya existe en la bd";
                        divAlerta.Attributes["class"] = "alert alert-danger";
                        divAlerta.Visible = true;
                        return;
                    }
                    else
                    {
                        dal.setInUpMandante(ma);
                    }
                }
                else if (hfNewOrEdit.Value == "E")
                {
                    dal.setInUpMandante(ma);
                }
               
                buscar();

                divSearch.Visible = true;
                divAddEdit.Visible = false;

                lblInfo.Text = "Mandante Guardado Correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar(this.Controls);
                divSearch.Visible = false;
                divAddEdit.Visible = true;
                hfNewOrEdit.Value = "N";

                divArchivos.Visible = false;

                if (hfIdMandante.Value != string.Empty)
                {
                    txtIdMandante.Text = (Convert.ToInt32(hfIdMandante.Value) + 1).ToString();
                }
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
                buscar();
                //limpiar();
                divSearch.Visible = true;
                divAddEdit.Visible = false;
                
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        public void limpiar(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    limpiar(control.Controls);
            }
        }

        void moneda() {
            Moneda mon = new Moneda();
            mon.Activo = 1;
            ddlMoneda.DataSource = dal.getBuscarMoneda(mon);
            ddlMoneda.DataTextField = "NomMoneda";
            ddlMoneda.DataValueField = "IdMoneda";
            ddlMoneda.DataBind();
        }
        void comuna()
        {
            Comuna com = new Comuna();
            ddlComuna.DataSource = dal.getBuscarComuna(com);
            ddlComuna.DataTextField = "NomComuna";
            ddlComuna.DataValueField = "idComuna";
            ddlComuna.DataBind();
        }
        void tipoInteres()
        {
            TipoInteres ti = new TipoInteres();
            ti.Activo = 1;
            ddlTipoInteres.DataSource = dal.getBuscarTipoIntereses(ti);
            ddlTipoInteres.DataTextField = "nomTipoInteres";
            ddlTipoInteres.DataValueField = "idTipoInteres";
            ddlTipoInteres.DataBind();
        }
        void tipoCliente()
        {
            TipoCliente tc = new TipoCliente();
            tc.Activo = 1;
            ddlTipoCliente.DataSource = dal.getBuscarTipoCliente(tc);
            ddlTipoCliente.DataValueField = "idTipoCliente";
            ddlTipoCliente.DataTextField = "nomTipoCliente";
            ddlTipoCliente.DataBind();
        }
        protected void ddlTipoInteres_DataBound(object sender, EventArgs e)
        {
            ddlTipoInteres.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlComuna_DataBound(object sender, EventArgs e)
        {
            ddlComuna.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlTipoCliente_DataBound(object sender, EventArgs e)
        {
            ddlTipoCliente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlMoneda_DataBound(object sender, EventArgs e)
        {
            ddlMoneda.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void imgEliminarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosMandante/";
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;
                //string idCliente = Session["idCliente"].ToString();
                Label _lblId = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblId");
                Label _lblIdMandante = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblIdMandante");
                Label _lblRutaArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblRutaArchivo");
                
                dal.setDelMandanteArchivo(mand, _lblId.Text);
                File.Delete(Server.MapPath(carpeta + _lblRutaArchivo.Text));

                buscarArchivos(mand);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void grvDetalleBiblioteca_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string carpeta = "assets/img/archivosMandante/";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Perfil per = new Perfil();

                ImageButton _imgVisualizar = (ImageButton)e.Row.FindControl("imgVisualizar");
                Label _lblNombreArchivo = (Label)e.Row.FindControl("lblNombre");
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

                //DataTable dt = new DataTable();
                //dt = Bus.getBuscarPerfilPorUsuario(Session["variableIdUsuario"].ToString()).Tables[0];

                //foreach (DataRow item in dt.Rows)
                //{
                //string perfil = item["ID_PERFIL"].ToString();
                //if (perfil == "1")
                //{
                //    break;
                //}

                //if (perfil == "4")
                //{
                //    string usuarioGrv = _lblUsuario.Text;
                //    string usuarioSession = Session["variableUsuario"].ToString();

                //    if (usuarioSession == usuarioGrv)
                //    {
                //        _imgEliminar.Visible = true;
                //    }
                //    else
                //    {
                //        _imgEliminar.Visible = false;
                //    }

                //    break;
                //}

                //if (perfil == "5")
                //{
                //    _imgEliminar.Visible = false;
                //    break;
                //}
                //}
            }
        }

        protected void btnGrabarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosMandante/";
                if (fuArchivo.HasFile)
                {
                    string idUsuario = Session["variableIdUsuario"].ToString();
                    mand.IdMandante = Convert.ToInt32(txtIdMandante.Text);
                    string filepath = Server.MapPath(carpeta + txtIdMandante.Text + "_" + fuArchivo.FileName);
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

                    string nombreArchivo = txtIdMandante.Text + "_" + fuArchivo.FileName;

                    dal.setInMandanteArchivo(mand, txtNombreArchivo.Text, txtDescripcion.Text, nombreArchivo, idUsuario);

                    //buscar();
                    //asyncLinkButton();
                    //limpiar(this.Controls);

                    buscarArchivos(mand);
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

        void buscarArchivos(Mandante man)
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMandanteArchivo(man).Tables[0];
            grvDetalleBiblioteca.DataSource = dt;
            grvDetalleBiblioteca.DataBind();
        }

        protected void imgVisualizar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string carpeta = "assets/img/archivosMandante/";

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

        protected void ddlTipoTipificacion_DataBound(object sender, EventArgs e)
        {
            ddlTipoTipificacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        void tipoTipificacion() {
            ddlTipoTipificacion.DataSource = dal.getBuscarTipoTipificacion(1);
            ddlTipoTipificacion.DataValueField = "IdTipoTipificacion";
            ddlTipoTipificacion.DataTextField = "NomTipoTipificacion";
            ddlTipoTipificacion.DataBind();
        }
    }
}