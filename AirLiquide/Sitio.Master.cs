using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using DAL;

namespace Cobros30
{
    public partial class Sitio : System.Web.UI.MasterPage
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                if (!this.Page.IsPostBack){
                    Usuario user = new Usuario();
                    Mandante man = new Mandante();
                    if (Session["variableUsuario"] == null){
                        Response.Redirect("Login.aspx");
                    }
                    else{
                        //visible();
                        //perfiles();
                        user.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
                        if (Session["IdMandante"] == null)
                        {
                            buscarMandante(user);
                            Session["IdMandante"] = ddlMandante.SelectedValue;
                            man.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
                            buscarImagen(man);
                            buscarMensajes();
                        }
                        else
                        {
                            buscarMandante(user);
                            ddlMandante.SelectedValue = Session["IdMandante"].ToString();
                            man.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
                            buscarImagen(man);
                            buscarMensajes();
                        }
                        lblFechaUsuarioDesde.Text = "Usuario desde " + Session["variableFechaCreacionUsuario"].ToString();

                        

                    }
                }
            }
            catch (Exception ex){
                Response.Write(ex.Message);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try{
                Session["variableUsuario"] = null;
                Session.Clear();
                Session.Abandon();

                Response.Redirect("Login.aspx");
            }
            catch (Exception ex){
                Response.Write(ex.Message);
            }
        }

        protected void ddlMandante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Mandante man = new Mandante();
                man.IdMandante = Convert.ToInt32(ddlMandante.SelectedValue);
                Session["IdMandante"] = man.IdMandante;
                buscarImagen(man);
                //body.Style.Add("", "");
                
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        void buscarMandante(Usuario user)
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarUsuarioMandante(user).Tables[0];

            if (dt.Rows.Count == 0)
            {
                Response.Redirect("Login.aspx");
            }
            
            ddlMandante.DataSource = dt;
            ddlMandante.DataValueField = "IdMandante";
            ddlMandante.DataTextField = "NomMandante";
            ddlMandante.DataBind();
        }

        void buscarImagen(Mandante man)
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMandante(man).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                string ruta = item["RutaLogo"].ToString();
                string skin = item["skin"].ToString();
                string idTipoTipificacion = item["IdTipoTipificacion"].ToString();
                if (ruta == string.Empty)
                {
                    ruta = "assets/template/AdminLTE-2.3.0/dist/img/boxed-bg.jpg";
                }
                if (skin.Trim() == string.Empty)
                {
                    body.Attributes.Add("class", "hold-transition skin-blue-light sidebar-mini");
                }
                else
                {
                    body.Attributes.Add("class", "hold-transition " + skin + " sidebar-mini");
                }
                Session["variableImagenMandante"] = ruta;
                Session["variableIdTipoTipificacion"] = idTipoTipificacion;
            }
        }

        void buscarMensajes()
        {
            Usuario user = new Usuario();
            DataTable dt = new DataTable();
            user.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
            dt = dal.getBuscarMensajes(user,0).Tables[0];

            lvMensajes.DataSource = dt;
            lvMensajes.DataBind();

            lblCantidadMensajesNoLeidos.Text = dt.Rows.Count.ToString();
            lblCantidadMensajesNoLeidos2.Text = lblCantidadMensajesNoLeidos.Text;

            //foreach (DataRow item in dt.Rows)
            //{
            //    //imgLogo.Src = item["foto"].ToString();
            //}
        }

        protected void lvMensajes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                //ImageButton img = (ImageButton)sender;
                //ListViewItem item = (ListViewItem)img.NamingContainer;
                
                //Label _lblIdMensaje = (Label)lvMensajes.Items[item.DataItemIndex].FindControl("lblIdMensaje");
                //Session["IdMensaje"] = _lblIdMensaje.Text;
                //Response.Redirect("ModEmailRead.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lbtnCambioContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CambioContrasena.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lbtnVerTodosLosMensajes_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ModEmail.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnNewEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ModEmailNew.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lbtnVerMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton img = (LinkButton)sender;
                ListViewItem item = (ListViewItem)img.NamingContainer;

                Label _lblIdMensaje = (Label)lvMensajes.Items[item.DataItemIndex].FindControl("lblIdMensaje");

                Session["IdMensaje"] = _lblIdMensaje.Text;
                Response.Redirect("ModEmailRead.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}