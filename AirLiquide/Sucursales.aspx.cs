using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;

namespace Cobros30
{
    public partial class Sucursales : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Sucursal suc = new Sucursal();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = "";
                if (!this.Page.IsPostBack)
                {
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
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdSucursal = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdSucursal");
                txtIdSucursal.Text = _lblIdSucursal.Text;
                Label _lblNomSucursal = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblNomSucursal");
                txtNombreSucursal.Text = _lblNomSucursal.Text;
                Label _lblActivo = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblActivo");
                ddlActivo.SelectedValue = _lblActivo.Text;

                divSearch.Visible = false;
                divAddEdit.Visible = true;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdSucursal = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdSucursal");
                suc.IdSucursal = _lblIdSucursal.Text;

                dal.setDelSucursal(suc);

                lblInfo.Text = "La Sucursal se eliminó correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;

                buscar();
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
                suc.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                suc.NomSucursal = txtNombreSucursal.Text;
                suc.IdSucursal = txtIdSucursal.Text;

                if (txtIdSucursal.Text == string.Empty)
                {
                    string existe = dal.setInUpSucursal(suc);
                    if (existe == "1")
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "El nombre del tipo de documento ya existe en la BD";
                        return;
                    }
                    buscar();
                }
                else
                {
                    string existe = dal.setInUpSucursal(suc);
                    buscar();
                }

                lblInfo.Text = "La sucursal grabado correctamente";
                divAlerta.Attributes["class"] = "alert alert-success";
                divAlerta.Visible = true;

                divSearch.Visible = true;
                divAddEdit.Visible = false;
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
                divSearch.Visible = true;
                divAddEdit.Visible = false;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            grvTipoDocumento.DataSource = dal.getBuscarSucursal(suc);
            grvTipoDocumento.DataBind();
            grvTipoDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
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
    }
}