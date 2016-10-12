using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;

namespace Cobros30
{
    public partial class Meta : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    divAlerta.Visible = false;
                    lblInfo.Text = "";
                    sucursal();
                    buscar();
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
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

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar(this.Controls);
                divSearch.Visible = false;
                divAddEdit.Visible = true;
                //hfIdTipoDocumento.Value = string.Empty;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblPeriodo = (Label)grvMeta.Rows[row.RowIndex].FindControl("lblPeriodo");

                Label _lblIdSucursal = (Label)grvMeta.Rows[row.RowIndex].FindControl("lblIdSucursal");
                Label _lblMeta = (Label)grvMeta.Rows[row.RowIndex].FindControl("lblMeta");

                string ano = _lblPeriodo.Text.Substring(0, 4);
                string mes = _lblPeriodo.Text.Substring(4, 2);

                ddlAno.SelectedValue = ano;
                ddlMes.SelectedValue = mes;

                ddlSucursal.SelectedValue = _lblIdSucursal.Text;
                txtMeta.Text = _lblMeta.Text;

                divSearch.Visible = false;
                divAddEdit.Visible = true;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblPeriodo = (Label)grvMeta.Rows[row.RowIndex].FindControl("lblPeriodo");
                Label _lblIdSucursal = (Label)grvMeta.Rows[row.RowIndex].FindControl("lblIdSucursal");

                dal.setDelMetas(_lblPeriodo.Text, _lblIdSucursal.Text);

                lblInfo.Text = "meta eliminada correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;

                buscar();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string periodo = ddlAno.SelectedValue + ddlMes.SelectedValue;
                dal.setInUpMetas(periodo, ddlSucursal.SelectedValue, txtMeta.Text.Trim());
                buscar();

                lblInfo.Text = "Meta grabada correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;

                divSearch.Visible = true;
                divAddEdit.Visible = false;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar();
                divSearch.Visible = true;
                divAddEdit.Visible = false;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
                divAlerta.Visible = true;
            }
        }

        void buscar()
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMetas(null).Tables[0];
            grvMeta.DataSource = dt;
            grvMeta.DataBind();
            grvMeta.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        void sucursal() {
            Sucursal su = new Sucursal();
            su.Activo = 1;
            ddlSucursal.DataSource = dal.getBuscarSucursal(su);
            ddlSucursal.DataTextField = "NomSucursal";
            ddlSucursal.DataValueField = "IdSucursal";
            ddlSucursal.DataBind();
        }
    }
}