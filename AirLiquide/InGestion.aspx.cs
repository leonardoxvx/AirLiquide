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
    public partial class InGestion : System.Web.UI.Page
    {
        Deudor deudor = new Deudor();
        Mandante man = new Mandante();
        Datos dal = new Datos();
        Gestiones ges = new Gestiones();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = "";

                if (!this.Page.IsPostBack)
                {
                    string _rut = Convert.ToString(Request.QueryString["r"]);
                    if (_rut == null)
                    {
                        Response.Redirect("Principal.aspx");
                    }
                    lblEjecutivoAsig.Text = Session["variableUsuario"].ToString();

                    deudor.RutDeudor = _rut;
                    deudor.IdMandante = Convert.ToInt32(Session["IdMandante"]);

                    man.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                    DataTable dtMan = new DataTable();
                    dtMan = dal.getBuscarMandante(man).Tables[0];
                    foreach (DataRow item in dtMan.Rows)
                    {
                        string nivel = item["NivelGestion"].ToString();
                        if (nivel == "4")
                        {
                            tdNivel4.Visible = true;
                        }
                        else
                        {
                            tdNivel4.Visible = false;
                        }
                    }

                    lblRutDeudor.Text = _rut;
                    buscar();

                    categoria();
                    subCategoria();
                    gestion();
                    nivel4();

                    telefonoAsociado();
                    direccionAsociado();

                    //txtHoraAgendamiento.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarDeudor(deudor).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                lblNombreORazonSocial.Text = item["NombreDeudor"].ToString();
            }
        }

        void categoria() {
            int idTipoTipificacion = Convert.ToInt32(Session["variableIdTipoTipificacion"]);
            ddlCategoria.DataSource = dal.getBuscarNivel1(idTipoTipificacion);
            ddlCategoria.DataTextField = "Nivel1";
            ddlCategoria.DataValueField = "Nivel1";
            ddlCategoria.DataBind();
        }
        void subCategoria() {
            ddlSubCategoria.DataSource = dal.getBuscarNivel2(ddlCategoria.SelectedValue);
            ddlSubCategoria.DataTextField = "Nivel2";
            ddlSubCategoria.DataValueField = "Nivel2";
            ddlSubCategoria.DataBind();
        }
        void gestion() {
            ddlGestion.DataSource = dal.getBuscarNivel3(ddlSubCategoria.SelectedValue);
            ddlGestion.DataTextField = "Nivel3";
            ddlGestion.DataValueField = "Nivel3";
            ddlGestion.DataBind();
        }
        void nivel4(){
            ddlNivel4.DataSource = dal.getBuscarNivel4(ddlGestion.SelectedValue);
            ddlNivel4.DataTextField = "Nivel4";
            ddlNivel4.DataValueField = "Nivel4";
            ddlNivel4.DataBind();
        }
        void telefonoAsociado(){
            deudor.RutDeudor = lblRutDeudor.Text;
            ddlTelefonoRutDeudor.DataSource = dal.getBuscarTelefonoPorRut(deudor);
            ddlTelefonoRutDeudor.DataTextField = "telefono2";
            ddlTelefonoRutDeudor.DataValueField = "idTelefono";
            ddlTelefonoRutDeudor.DataBind();
        }
        void direccionAsociado(){
            deudor.RutDeudor = lblRutDeudor.Text;
            ddlDireccionAsociada.DataSource = dal.getBuscarDireccionPorRut(deudor);
            ddlDireccionAsociada.DataTextField = "direccion";
            ddlDireccionAsociada.DataValueField = "IdDireccion";
            ddlDireccionAsociada.DataBind();
        }

        protected void ddlCategoria_DataBound(object sender, EventArgs e)
        {
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlSubCategoria_DataBound(object sender, EventArgs e)
        {
            ddlSubCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlGestion_DataBound(object sender, EventArgs e)
        {
            ddlGestion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlNivel4_DataBound(object sender, EventArgs e)
        {
            ddlNivel4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                subCategoria();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gestion();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nivel4();
                DataTable dt = new DataTable();
                dt = dal.getBuscarTipificacion(null, ddlCategoria.SelectedValue, ddlSubCategoria.SelectedValue, ddlGestion.SelectedValue, null, null).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    string esComPago = item["EsCompPago"].ToString();
                    string esAgendable = item["EsAgendable"].ToString();
                    string idTipoGestion = item["IdTipoGestion"].ToString();

                    if (esComPago == "1")
                    {
                        txtFechaCompromiso.Enabled = true;
                        txtMontoCompromiso.Enabled = true;
                    }
                    else
                    {
                        txtFechaCompromiso.Enabled = false;
                        txtMontoCompromiso.Enabled = false;
                    }

                    if (esAgendable=="1")
                    {
                        txtFechaAgendamiento.Enabled = true;
                        txtHoraAgendamiento.Disabled = false;
                    }
                    else
                    {
                        txtFechaAgendamiento.Enabled = false;
                        txtHoraAgendamiento.Disabled = true;
                    }

                    if (idTipoGestion == "2")
                    {
                        ddlTelefonoRutDeudor.Enabled = true;
                        if (Session["telefonoAni"] != null)
                        {
                            string telefonoAni = Session["telefonoAni"].ToString();
                            ddlTelefonoRutDeudor.Items.FindByText(telefonoAni).Selected = true;
                        }
                        
                    }
                    else
                    {
                        ddlTelefonoRutDeudor.Enabled = false;
                    }

                    if (idTipoGestion=="3")
                    {
                        ddlDireccionAsociada.Enabled = true;
                    }
                    else
                    {
                        ddlDireccionAsociada.Enabled = false;
                    }

                    hfIdTipificacion.Value = item["IdTipificacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlNivel4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarTipificacion(null, ddlCategoria.SelectedValue, ddlSubCategoria.SelectedValue, ddlGestion.SelectedValue, ddlNivel4.SelectedValue, null).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    string esComPago = item["EsComPago"].ToString();
                    string esAgendable = item["EsComPago"].ToString();
                    string idTipoGestion = item["IdTipoGestion"].ToString();

                    if (esComPago == "1")
                    {
                        txtFechaCompromiso.Enabled = true;
                        txtMontoCompromiso.Enabled = true;
                    }
                    else
                    {
                        txtFechaCompromiso.Enabled = false;
                        txtMontoCompromiso.Enabled = false;
                    }

                    if (esAgendable == "1")
                    {
                        txtFechaAgendamiento.Enabled = true;
                        txtHoraAgendamiento.Disabled = false;
                    }
                    else
                    {
                        txtFechaAgendamiento.Enabled = false;
                        txtHoraAgendamiento.Disabled = true;
                    }

                    if (idTipoGestion == "2")
                    {
                        ddlTelefonoRutDeudor.Enabled = true;
                        if (Session["telefonoAni"] != null)
                        {
                            string telefonoAni = Session["telefonoAni"].ToString();
                            ddlTelefonoRutDeudor.Items.FindByText(telefonoAni).Selected = true;
                        }
                    }
                    else
                    {
                        ddlTelefonoRutDeudor.Enabled = false;
                    }

                    if (idTipoGestion == "3")
                    {
                        ddlDireccionAsociada.Enabled = true;
                    }
                    else
                    {
                        ddlDireccionAsociada.Enabled = false;
                    }

                    hfIdTipificacion.Value = item["IdTipificacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
        
        protected void lbtnGrabarGestion_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarTipificacion(null, ddlCategoria.SelectedValue, ddlSubCategoria.SelectedValue, ddlGestion.SelectedValue, ddlNivel4.SelectedValue, null).Tables[0];
                string idTipoGestion = string.Empty;
                foreach (DataRow item in dt.Rows)
                {
                    string esComPago = item["EsComPago"].ToString();
                    string esAgendable = item["EsComPago"].ToString();
                    idTipoGestion = item["IdTipoGestion"].ToString();
                }

                if (idTipoGestion == "2")
                {
                    if (ddlTelefonoRutDeudor.SelectedValue == "0")
                    {
                        lblInfo.Text = "El teléfono es obligatorio, favor de seleccionar.";
                        divAlerta.Visible = true;
                    }
                }


                if (txtFechaAgendamiento.Text.Trim() == string.Empty)
                {
                    ges.FechaAgendamiento = null;
                }
                else
                {
                    ges.FechaAgendamiento = Convert.ToDateTime(txtFechaAgendamiento.Text);
                }

                if (txtFechaCompromiso.Text.Trim() == string.Empty)
                {
                    ges.FechaCompromiso = null;
                }
                else
                {
                    ges.FechaCompromiso = Convert.ToDateTime(txtFechaCompromiso.Text);
                }
                
                ges.HoraAgendamiento = txtHoraAgendamiento.Value;

                if (ddlDireccionAsociada.SelectedValue == "0")
                {
                    ges.IdDireccionAsociada = null;
                }
                else
                {
                    ges.IdDireccionAsociada = Convert.ToInt32(ddlDireccionAsociada.SelectedValue);
                }
                
                ges.IdMandante= Convert.ToInt32(Session["IdMandante"]);

                if (ddlTelefonoRutDeudor.SelectedValue == "0")
                {
                    ges.IdTelefonoAsociado = null;
                }
                else
                {
                    ges.IdTelefonoAsociado = Convert.ToInt32(ddlTelefonoRutDeudor.SelectedValue);
                }
                
                ges.IdTipificacion = Convert.ToInt32(hfIdTipificacion.Value);
                ges.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);

                if (txtMontoCompromiso.Text == string.Empty)
                {
                    ges.MontoCompromiso = null;
                }
                else
                {
                    ges.MontoCompromiso = Convert.ToInt32(txtMontoCompromiso.Text);
                }
                
                ges.Observaciones = txtObservacion.Text;
                ges.RutDeudor = lblRutDeudor.Text;

                string idGestion = dal.setInGestion(ges);

                Response.Redirect("Principal.aspx?rut="+ lblRutDeudor.Text);

                //divAlerta.Visible = true;
                //divAlerta.Attributes["class"] = "alert alert-success";
                //lblInfo.Text = "Gestión ingresada correctamente, Id Gestión Nº " + idGestion;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlTelefonoRutDeudor_DataBound(object sender, EventArgs e)
        {
            ddlTelefonoRutDeudor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void ddlDireccionAsociada_DataBound(object sender, EventArgs e)
        {
            ddlDireccionAsociada.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }
    }
}