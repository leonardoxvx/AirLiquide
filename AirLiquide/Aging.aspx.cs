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
    public partial class Aging : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = string.Empty;

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnExcel);
                scriptManager.RegisterPostBackControl(this.btnBuscar);

                btnBuscar.Attributes.Add("OnClick", string.Format("this.disabled = true; {0};", ClientScript.GetPostBackEventReference(btnBuscar, null)));
                
                if (!this.Page.IsPostBack)
                {
                    sucursal();
                    ejecutivo();
                    sector();
                    //buscar();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlSector_DataBound(object sender, EventArgs e)
        {
            ddlSector.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void ddlUsuarioAsignado_DataBound(object sender, EventArgs e)
        {
            ddlUsuarioAsignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
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

        void ejecutivo()
        {
            Usuario user = new Usuario();
            user.Activo = 1;
            ddlUsuarioAsignado.DataSource = dal.getBuscarUsuario(user);
            ddlUsuarioAsignado.DataValueField = "IdUsuario";
            ddlUsuarioAsignado.DataTextField = "Login";
            ddlUsuarioAsignado.DataBind();
        }

        void sector()
        {
            ddlSector.DataSource = dal.getBuscarSector(1);
            ddlSector.DataTextField = "Sector";
            ddlSector.DataValueField = "IdSector";
            ddlSector.DataBind();
        }

        void buscar()
        {
            int idMandate = Convert.ToInt32(Session["IdMandante"]);
            DataTable dt = new DataTable();
            dt = dal.getBuscarAging(idMandate, Convert.ToInt32(ddlUsuarioAsignado.SelectedValue), txtCodCliente.Text.Trim(), ddlSector.SelectedValue, ddlSucursal.SelectedValue).Tables[0];
            grvResultado.DataSource = dt;
            grvResultado.DataBind();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
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

        protected void lbtnCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblCodigo = (Label)grvResultado.Rows[row.RowIndex].FindControl("lblCodigo");

                Response.Redirect("Principal.aspx?rut=" + _lblCodigo.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void grvResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblT130 = (Label)e.Row.FindControl("lblT130");
                if (Convert.ToDecimal(_lblT130.Text) < 0)
                {
                    e.Row.Cells[3].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[3].CssClass = "success";
                }

                Label _T_31_60 = (Label)e.Row.FindControl("T_31_60");
                if (Convert.ToDecimal(_T_31_60.Text) < 0)
                {
                    e.Row.Cells[4].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[4].CssClass = "success";
                }

                Label _T_61_90 = (Label)e.Row.FindControl("T_61_90");
                if (Convert.ToDecimal(_T_61_90.Text) < 0)
                {
                    e.Row.Cells[5].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[5].CssClass = "success";
                }

                Label _T_91_120 = (Label)e.Row.FindControl("T_91_120");
                if (Convert.ToDecimal(_T_91_120.Text) < 0)
                {
                    e.Row.Cells[6].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[6].CssClass = "success";
                }

                Label _T_121_180 = (Label)e.Row.FindControl("T_121_180");
                if (Convert.ToDecimal(_T_121_180.Text) < 0)
                {
                    e.Row.Cells[7].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[7].CssClass = "success";
                }

                
                Label _T_180 = (Label)e.Row.FindControl("T_180");
                if (Convert.ToDecimal(_T_180.Text) < 0)
                {
                    e.Row.Cells[8].CssClass = "danger";
                }
                else
                {
                    e.Row.Cells[8].CssClass = "success";
                }

            }
        }
    }
}