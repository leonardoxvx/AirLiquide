using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Cobros30
{
    public partial class ModEmailNew : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";

                if (!this.Page.IsPostBack)
                {
                    ejecutivo();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEjecutivo.SelectedValue=="0")
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "Favor seleccionar un usuario";
                    return;
                }
                if (txtAsunto.Value==string.Empty)
                {
                    divAlerta.Visible = true;
                    lblInfo.Text = "El campo asunto es obligatorio";
                    return;
                }

                
                if (!email_bien_escrito(txtEmail.Text.Trim()))
                {
                    lblInfo.Text = "El email del cliente interno está mal escrito.";
                    divAlerta.Visible = true;
                    return;
                }


                Mensaje mensaje = new Mensaje();

                string para = ddlEjecutivo.SelectedValue;
                string asunto = txtAsunto.Value.Trim();
                string msj = txtMensaje.Text.Trim();

                mensaje.Asunto = asunto;
                mensaje.MensajeObs = msj;
                mensaje.IdUsuarioPara = Convert.ToInt32(para);
                mensaje.IdUsuarioDe = Convert.ToInt32(Session["variableIdUsuario"]);
                
                dal.setInMensaje(mensaje);

                divAlerta.Visible = true;
                lblInfo.Text = "Mensaje enviador correctamente";
                
                string body = txtMensaje.Text;
                enviarEmail(txtEmail.Text.Trim(), body.Replace("\r\n", "<br>"), asunto);
                
                limpiar();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        private void enviarEmail(string email, string body, string sub)
        {
            MailMessage correo = new MailMessage();

            correo.From = new MailAddress("<ldiaz@interweb.cl>");
            string bodyEmail = body;

            String[] AMailto = email.Split(';');
            foreach (String mail in AMailto)
            {
                correo.To.Add(new MailAddress(mail));
            }

            correo.Subject = sub;
            correo.IsBodyHtml = true;
            correo.Body = bodyEmail;


            SmtpClient client = new SmtpClient();

            client.Send(correo);
        }


        protected void ddlEjecutivo_DataBound(object sender, EventArgs e)
        {
            ddlEjecutivo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        void ejecutivo()
        {
            Usuario user = new Usuario();
            user.Activo = 1;
            
            ddlEjecutivo.DataSource = dal.getBuscarUsuario(user);
            //ddlEjecutivo.DataSource = dal.getBuscarUsuarioConGestion(Convert.ToInt32(Session["IdMandante"]));
            ddlEjecutivo.DataTextField = "LoginUsuario";
            ddlEjecutivo.DataValueField = "IdUsuario";
            ddlEjecutivo.DataBind();
        }

        void limpiar() {
            ddlEjecutivo.ClearSelection();
            txtAsunto.Value = string.Empty;
            txtMensaje.Text = string.Empty;
        }

        protected void lbtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModEmail.aspx");
        }

        protected void ddlEjecutivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                user.IdUsuario = Convert.ToInt32(ddlEjecutivo.SelectedValue);
                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuario(user).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    txtEmail.Text = item["Email"].ToString();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}