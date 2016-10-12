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
    public partial class ModEmailRead : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";

                if (!this.Page.IsPostBack)
                {
                    if(Session["IdMensaje"] != null)
                    {
                        leerMensaje(Convert.ToInt32(Session["IdMensaje"]));
                    }
                    else
                    {
                        Response.Redirect("ModEmail.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void leerMensaje(int idMensaje)
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMensajePorId(idMensaje).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                lblDe.Text = item["Nombre"].ToString();
                lblAsunto.Text = item["Asunto"].ToString();
                txtMensaje.Text = item["Mensaje"].ToString();
            }

        }

        protected void lbtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModEmail.aspx");
        }
    }
}