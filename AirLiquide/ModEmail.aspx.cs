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
    public partial class ModEmail : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            
            if (!this.Page.IsPostBack)
            {
                buscarMensajes();
            }
        }

        void buscarMensajes()
        {
            Usuario user = new Usuario();
            DataTable dt = new DataTable();
            user.IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
            dt = dal.getBuscarMensajes(user, null).Tables[0];

            grvUsuarios.DataSource = dt;
            grvUsuarios.DataBind();
            grvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
            //foreach (DataRow item in dt.Rows)
            //{
            //    //imgLogo.Src = item["foto"].ToString();
            //}
        }

        protected void grvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string idMandante = Session["IdMandante"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lblLeido = (Label)e.Row.FindControl("lblLeido");

                if (_lblLeido.Text == "1")
                {
                    e.Row.CssClass = "";
                }
                else if (_lblLeido.Text == "0")
                {
                    e.Row.CssClass = "warning";
                }
            }
        }

        protected void btnNewMsj_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ModEmailNew.aspx");
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ModEmail.aspx");
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnDe_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMensaje = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdMensaje");

                Session["IdMensaje"] = _lblIdMensaje.Text;
                Response.Redirect("ModEmailRead.aspx");
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}