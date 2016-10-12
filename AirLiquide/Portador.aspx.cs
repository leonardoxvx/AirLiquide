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
    public partial class Portador : System.Web.UI.Page
    {
        Datos dal = new Datos();
        ENT.Portador port = new ENT.Portador();

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
                Label _lblIdPortador = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdPortador");
                txtIdPortador.Text = _lblIdPortador.Text;
                Label _lblNomPortador = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblNomPortador");
                txtNombrePortador.Text = _lblNomPortador.Text;
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
                Label _lblIdPortador = (Label)grvTipoDocumento.Rows[row.RowIndex].FindControl("lblIdPortador");
                port.IdPortador = _lblIdPortador.Text;
                dal.setDelPortador(port);

                lblInfo.Text = "Portador eliminado correctamente";
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

                port.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                port.NomPortador = txtNombrePortador.Text;
                port.IdPortador = txtIdPortador.Text;

                if (txtIdPortador.Text == string.Empty)
                {
                    string existe = dal.setInUpPortador(port);
                    if (existe == "1")
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "El nombre del portador ya existe en la BD";
                        return;
                    }
                    buscar();
                }
                else
                {
                    string existe = dal.setInUpPortador(port);
                    buscar();
                }

                lblInfo.Text = "El portador grabado correctamente";
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
            grvTipoDocumento.DataSource = dal.getBuscarPortador(port);
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