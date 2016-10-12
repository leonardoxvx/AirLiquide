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
    public partial class Asignaciones : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Asignacion asig = new Asignacion();
        Mandante man = new Mandante();

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
                Label _lblIdAsignacion = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblIdAsignacion");
                hfIdAsignacion.Value = _lblIdAsignacion.Text;
                Label _lblIdMandante = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblIdMandante");
                //ddlMandante.SelectedValue = _lblIdMandante.Text;
                Label _lblFechaAsignacion = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblFechaAsignacion");
                txtFechaAsignacion.Text = _lblFechaAsignacion.Text;
                Label _lblFechaInicio = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblFechaInicio");
                if (_lblFechaInicio.Text != string.Empty)
                {
                    txtFechaInicio.Text = _lblFechaInicio.Text;
                }
                Label _lblFechaTermino = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblFechaTermino");
                if (_lblFechaTermino.Text != string.Empty)
                {
                    txtFechaTermino.Text = _lblFechaTermino.Text;
                }
                Label _lblNombreAsignacion = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblNombreAsignacion");
                txtNombreAsignacion.Text = _lblNombreAsignacion.Text;
                Label _lblActivo = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblActivo");
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
                Label _lblIdAsignacion = (Label)grvAsignaciones.Rows[row.RowIndex].FindControl("lblIdAsignacion");
                asig.IdAsignacion = Convert.ToInt32(_lblIdAsignacion.Text);
                dal.setDelAsignacion(asig);

                lblInfo.Text = "Asignación eliminado correctamente";
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
                hfIdAsignacion.Value = string.Empty;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar()
        {
            grvAsignaciones.DataSource = dal.getBuscarAsignacion(1,Convert.ToInt32(Session["IdMandante"]));
            grvAsignaciones.DataBind();
            grvAsignaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfIdAsignacion.Value == string.Empty)
                {
                    asig.Activa = Convert.ToInt32(ddlActivo.SelectedValue);
                    asig.FechaAsignacion = Convert.ToDateTime(txtFechaAsignacion.Text);
                    if (txtFechaInicio.Text != string.Empty)
                    {
                        asig.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                    }
                    else
                    {
                        asig.FechaInicio = null;
                    }

                    if (txtFechaTermino.Text != string.Empty)
                    {
                        asig.FechaTermino = Convert.ToDateTime(txtFechaTermino.Text);
                    }
                    else
                    {
                        asig.FechaTermino = null;
                    }

                    asig.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                    asig.NomAsignacion = txtNombreAsignacion.Text;

                    string existe = dal.setInAsignacion(asig);
                    if (existe == "1")
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "El nombre de la asignación ya existe en la BD";
                        return;
                    }
                    buscar();
                }
                else
                {
                    asig.IdAsignacion = Convert.ToInt32(hfIdAsignacion.Value);
                    asig.Activa = Convert.ToInt32(ddlActivo.SelectedValue);
                    asig.FechaAsignacion = Convert.ToDateTime(txtFechaAsignacion.Text);
                    if (txtFechaInicio.Text != string.Empty)
                    {
                        asig.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                    }
                    if (txtFechaTermino.Text != string.Empty)
                    {
                        asig.FechaTermino = Convert.ToDateTime(txtFechaTermino.Text);
                    }
                    asig.IdMandante = Convert.ToInt32(Session["IdMandante"]);
                    asig.NomAsignacion = txtNombreAsignacion.Text;

                    dal.setUpAsignacion(asig);
                    buscar();
                }

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
    }
}