using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;

namespace Cobros30
{
    public partial class BuscadorDeudor : System.Web.UI.Page
    {
        Datos dal = new Datos();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    sucursal();
                }
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

        protected void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvBuscadorDeudor.Rows[row.RowIndex].FindControl("lblIdMandante");
                Label _lblRutDeudor = (Label)grvBuscadorDeudor.Rows[row.RowIndex].FindControl("lblRutDeudor");

                Session["IdMandante"] = _lblIdMandante.Text;

                Response.Redirect("Principal.aspx?rut="+_lblRutDeudor.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            grvBuscadorDeudor.DataSource = dal.getBuscarDeudorBuscador(txtRut.Text, txtNombre.Text, txtDocumento.Text, txtCuenta.Text, txtTelefono.Text, ddlSucursal.SelectedValue);
            grvBuscadorDeudor.DataBind();

        }
        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
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

    }
}