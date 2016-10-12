using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Data;
using System.Text;
using DataTableToExcel;

namespace Cobros30
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                divAlerta.Visible = false;
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.lbtExportar);

                if (!this.Page.IsPostBack)
                {
                    buscar();
                    buscarMandantes();
                    buscarPerfil();
                    //buscarSucursal();
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
                limpiar(this.Controls);
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdUsuario = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdUsuario");

                user.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                hfIdUsuario.Value = _lblIdUsuario.Text;

                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuario(user).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    txtRut.Text = item["Rut"].ToString();
                    txtNombre.Text = item["Nombre"].ToString();
                    txtLogin.Text = item["Login"].ToString();
                    txtEmail.Text = item["Email"].ToString();
                    txtClave.Attributes.Add("Value", item["Clave"].ToString());
                    txtAreaCargo.Text = item["AreaCargo"].ToString();
                    if (item["IdPerfil"].ToString() != string.Empty)
                    {
                        ddlPerfil.SelectedValue = item["IdPerfil"].ToString();
                    }
                    if (item["Activo"].ToString() != string.Empty)
                    {
                        ddlActivo.SelectedValue = item["Activo"].ToString();
                    }
                    //if (item["IdSucursal"].ToString() != string.Empty)
                    //{
                    //    ddlSucursal.SelectedValue = item["IdSucursal"].ToString();
                    //}
                    imgLogo.Src = item["foto"].ToString();

                }
                
                foreach (DataRow item in dal.getBuscarUsuarioMandante(user).Tables[0].Rows)
                {
                    string idCliente = Convert.ToString(item["IdMandante"]);
                    
                    foreach (ListItem fila in chkMandantes.Items)
                    {
                        if (idCliente == fila.Value.ToString())
                        {
                            fila.Selected = true;
                        }
                    }
                }
                
                foreach (DataRow item in dal.getBuscarUsuarioSucursal(user).Tables[0].Rows)
                {
                    string idCliente = Convert.ToString(item["IdSucursal"]);
                    
                    foreach (ListItem fila in chkSucursales.Items)
                    {
                        if (idCliente == fila.Value.ToString())
                        {
                            fila.Selected = true;
                        }
                    }
                }

                divImagenLogo.Visible = true;

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
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdUsuario = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdUsuario");
                user.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                userMan.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                dal.setDelUsuarioMandante(userMan);
                dal.setDelUsuarioSucursal(user.IdUsuario);
                dal.setDelUsuario(user);

                lblInfo.Text = "Usuario Eliminado Correctamente";
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

        void buscar() {
            Usuario user = new Usuario();
            //user.IdUsuario = null;
            grvUsuarios.DataSource = dal.getBuscarUsuario(user);
            grvUsuarios.DataBind();
            grvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar(this.Controls);
                divSearch.Visible = false;
                divAddEdit.Visible = true;
                hfIdUsuario.Value = string.Empty;
                divImagenLogo.Visible = false;
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
        
        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuLogo.HasFile)
                {
                    Usuario user = new Usuario();
                    string carpeta = "assets/img/usuario/" + "logo_" + hfIdUsuario.Value + "_" + fuLogo.FileName;
                    fuLogo.SaveAs(Server.MapPath(carpeta));
                    //int IdUsuario = Convert.ToInt16(hfIdUsuario.Value);
                    user.Foto = carpeta;
                    user.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
                    dal.setUpFotoUsuario(user);
                    //string idUsuario = Session["variableIdUsuario"].ToString();

                    //cambia inmediatamente si es el usuario actual.
                    if (Session["variableIdUsuario"].ToString() == hfIdUsuario.Value)
                    {
                        Session["variableImagenUsuario"] = carpeta;
                        imgLogo.Src = carpeta;
                    }
                    imgLogo.Src = carpeta;
                }
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

            chkMandantes.ClearSelection();
            chkSucursales.ClearSelection();
        }

        protected void ddlPerfil_DataBound(object sender, EventArgs e)
        {
            ddlPerfil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();

                user.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                user.AreaCargo = txtAreaCargo.Text;
                user.Clave = txtClave.Text;
                user.Email = txtEmail.Text;
                
                user.IdPerfil = Convert.ToInt32(ddlPerfil.SelectedValue);
                //user.IdSucursal = ddlSucursal.SelectedValue;
                //user.IdUsuario 
                user.Login = txtLogin.Text;
                user.Nombre = txtNombre.Text;
                user.Rut = txtRut.Text;
                //if (txtIdUsuarioDiscador.Text != string.Empty)
                //{
                //    user.IdUsuarioDiscador = Convert.ToInt32(txtIdUsuarioDiscador.Text);
                //}

                //Nuevo o Editar
                if (hfIdUsuario.Value == string.Empty)
                {
                    DataTable dtUser = new DataTable();
                    dtUser = dal.getBuscarValUsuario(user).Tables[0];

                    if (dtUser.Rows.Count != 0)
                    {
                        lblInfo.Text = "El usuario " + user.Login + " existe en la bd";
                        divAlerta.Attributes["class"] = "alert alert-danger";
                        divAlerta.Visible = true;
                        return;
                    }

                    user.IdUsuario = Convert.ToInt32(dal.setInUpUsuario(user));
                    userMan.IdUsuario = user.IdUsuario;

                    //foreach (ListItem item in chkMandantes.Items)
                    //{
                    //    if (item.Selected == true)
                    //    {
                    //        //string valorCheckIdCliente = item.Value;
                    //        string valorCheckIdCliente = "1";
                    //        userMan.IdMandante = Convert.ToInt32(valorCheckIdCliente);
                    //        dal.setInUsuarioMandante(userMan);
                    //    }
                    //}
                    
                    userMan.IdMandante = 1;
                    dal.setInUsuarioMandante(userMan);

                    foreach (ListItem item in chkSucursales.Items)
                    {
                        if (item.Selected == true)
                        {
                            string valorCheckIdCliente = item.Value;
                            dal.setInUsuarioPorSucursal(user.IdUsuario, valorCheckIdCliente);
                        }
                    }
                    
                }
                else
                {
                    user.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
                    Convert.ToInt32(dal.setInUpUsuario(user));
                    userMan.IdUsuario = user.IdUsuario;
                    //dal.setDelUsuarioMandante(userMan);
                    dal.setDelUsuarioSucursal(user.IdUsuario);
                    foreach (ListItem item in chkMandantes.Items)
                    {
                        if (item.Selected == true)
                        {
                            string valorCheckIdCliente = item.Value;
                            userMan.IdMandante = Convert.ToInt32(valorCheckIdCliente);
                            dal.setInUsuarioMandante(userMan);
                        }
                    }

                    foreach (ListItem item in chkSucursales.Items)
                    {
                        if (item.Selected == true)
                        {
                            string valorCheckIdCliente = item.Value;
                            dal.setInUsuarioPorSucursal(user.IdUsuario, valorCheckIdCliente);
                        }
                    }
                }

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

        void buscarMandantes()
        {
            //Mandante man = new Mandante();
            //man.Activo = 1;
            //chkMandantes.DataSource = dal.getBuscarMandante(man);
            //chkMandantes.DataTextField = "NomMandante";
            //chkMandantes.DataValueField = "IdMandante";
            //chkMandantes.DataBind();
            Sucursal su = new Sucursal();
            su.Activo = 1;
            chkSucursales.DataSource=dal.getBuscarSucursal(su);
            chkSucursales.DataTextField = "NomSucursal";
            chkSucursales.DataValueField = "IdSucursal";
            chkSucursales.DataBind();
        }

        void buscarPerfil()
        {
            Perfil per = new Perfil();
            ddlPerfil.DataSource = dal.getBuscarPerfil(per);
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataTextField = "NomPerfil";
            ddlPerfil.DataBind();
        }

        //void buscarSucursal()
        //{
        //    Sucursal su = new Sucursal();
        //    su.Activo = 1;
            
        //    ddlSucursal.DataSource = dal.getBuscarSucursal(su);
        //    ddlSucursal.DataValueField = "IdSucursal";
        //    ddlSucursal.DataTextField = "NomSucursal";
        //    ddlSucursal.DataBind();
        //}

        //protected void ddlSucursal_DataBound(object sender, EventArgs e)
        //{
        //    ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        //}

        protected void lbtExportar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuarioExporte().Tables[0];
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                Response.ContentType = "Application/x-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=" + "exporte" + ".csv");
                Response.ContentEncoding = Encoding.Unicode;
                Response.Write(Utilidad.ExportToCSVFile(dt));
                Response.End();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}