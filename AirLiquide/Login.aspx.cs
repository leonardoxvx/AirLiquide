using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;
using System.Data;

namespace Cobros30
{
    public partial class Login : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Usuario user = new Usuario();
        Perfil perfil = new Perfil();

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                if (!this.Page.IsPostBack){

                }
            }
            catch (Exception ex){
                divAlerta.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try{
                DataTable dt = new DataTable();
                string usuario = inpUsuario.Value;
                string pass = inpPassword.Value;
                user.Login = usuario;
                user.Clave = pass;
                dt = dal.getBuscarUsuario(user).Tables[0];

                if (dt.Rows.Count == 0){
                    //error de usuario
                    divAlerta.Visible = true;
                    lblError.Text = "Nombre de usuario y/o contraseña no valida";
                }
                else{
                    foreach (DataRow item in dt.Rows){
                        user.IdUsuario = Convert.ToInt32(item["IdUsuario"]);
                        user.Login = item["Login"].ToString();
                        user.Rut = item["Rut"].ToString();
                        user.Nombre = item["Nombre"].ToString();
                        user.Email = item["Email"].ToString();
                        user.IdPerfil = Convert.ToInt32(item["IdPerfil"]);
                        user.AreaCargo = item["AreaCargo"].ToString();
                        user.Activo = Convert.ToInt32(item["Activo"]);
                        perfil.NomPerfil = item["nomPerfil"].ToString();
                        user.Foto = item["Foto"].ToString();
                        user.FechaCreacion = Convert.ToDateTime(item["FechaCreacion"]);
                        break;
                    }

                    if (user.Foto == string.Empty){
                        user.Foto = "assets/template/AdminLTE-2.3.0/dist/img/user-blank.jpg";
                    }
                    Session["variableIdUsuario"] = user.IdUsuario;
                    Session["variableUsuario"] = user.Login;
                    Session["variableImagenUsuario"] = user.Foto;
                    Session["variablePerfil"] = perfil.NomPerfil;
                    Session["variableIdPerfil"] = user.IdPerfil;
                    Session["variableFechaSession"] = DateTime.Now.ToString("G");
                    Session["variableNomUsuario"] = user.Nombre;
                    Session["variableImagenMandante"] = string.Empty;
                    Session["variableFechaCreacionUsuario"] = user.FechaCreacion;

                    if (user.Activo == 0){
                        divAlerta.Visible = true;
                        lblError.Text = "El usuario no se encuentra activo. Favor comunicarse con el administrador.";
                        return;
                    }
                    else{
                        
                        if (dal.getBuscarUsuarioMandante(user).Tables[0].Rows.Count == 0)
                        {
                            divAlerta.Visible = true;
                            lblError.Text = "El usuario no tiene mandantes asociados, favor comunicarse con el administrador";
                            return;
                        }
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                }
            }
            catch (Exception ex){
                //error de usuario
                divAlerta.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}