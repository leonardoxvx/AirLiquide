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
    public partial class TipoDocumentos : System.Web.UI.Page
    {
        Datos dal = new Datos();
        TipoDocumento tDoc = new TipoDocumento();

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
                Label _lblIdTipoDocumento = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdTipoDocumento");
                hfIdTipoDocumento.Value = _lblIdTipoDocumento.Text;
                Label _lblNomTipoDocumento = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblNomTipoDocumento");
                txtTipoDocumento.Text = _lblNomTipoDocumento.Text;
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
                Label _lblIdTipoDocumento = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdTipoDocumento");
                tDoc.IdTipoDocumento= Convert.ToInt32(_lblIdTipoDocumento.Text);
                dal.setDelTipoDocumento(tDoc);

                lblInfo.Text = "Tipo de documento eliminado correctamente";
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
                hfIdTipoDocumento.Value = string.Empty;
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
                if (hfIdTipoDocumento.Value == string.Empty)
                {
                    tDoc.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                    tDoc.NomTipoDocumento = txtTipoDocumento.Text;

                    string existe = dal.setInTipoDocumento(tDoc);
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
                    tDoc.IdTipoDocumento = Convert.ToInt32(hfIdTipoDocumento.Value);
                    tDoc.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                    tDoc.NomTipoDocumento = txtTipoDocumento.Text;

                    dal.setUpTipoDocumento(tDoc);
                    buscar();
                }

                lblInfo.Text = "Tipo de documento grabado correctamente";
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
            grvTipoDocumento.DataSource = dal.getBuscarTipoDocumento(2);
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