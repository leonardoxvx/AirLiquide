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
    public partial class CambioContrasena : System.Web.UI.Page
    {
        Usuario user = new Usuario();
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAlerta.Visible = false;
                lblInfo.Text = "";

                if (!this.Page.IsPostBack)
                {
                    lblUsuario.Text = Session["variableUsuario"].ToString();
                    buscarUsuario();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string contrasena = txtContrasena.Text;
                string idUsuario = Session["variableIdUsuario"].ToString();

                user.IdUsuario = Convert.ToInt32(idUsuario);
                user.Clave = contrasena;

                if (txtContrasena.Text != txtContrasenaNueva.Text)
                {
                    divAlerta.Visible = true;
                    divAlerta.Attributes["class"] = "alert alert-danger";
                    lblInfo.Text = "Las claves proporcionadas no coinciden";
                    return;
                }

                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuario(user).Tables[0];
                string pass1 = string.Empty;
                foreach (DataRow item in dt.Rows)
                {
                    pass1 = item["CLAVE"].ToString();
                }

                if (pass1!=txtContrasena.Text)                  
                {
                    divAlerta.Visible = true;
                    divAlerta.Attributes["class"] = "alert alert-danger";
                    lblInfo.Text = "La clave anterior no coincide, favor intentar nuevamente";
                    return;
                }

                dal.setUpContrasena(user);

                divAlerta.Visible = true;
                divAlerta.Attributes["class"] = "alert alert-success";
                lblInfo.Text = "Se editó correctamente la contraseña";
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        void buscarUsuario()
        {
            DataTable dt = new DataTable();
            user.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
            dt = dal.getBuscarUsuario(user).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                lblNombre.Text = item["NOMBRE"].ToString();
                string clave = item["CLAVE"].ToString();
                txtContrasena.Attributes.Add("Value", clave);
                txtContrasenaNueva.Attributes.Add("Value", clave);
            }
        }
    }
}