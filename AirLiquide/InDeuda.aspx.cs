using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Cobros30
{
    public partial class InDeuda : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    estadoDeuda2();

                    string _id = Convert.ToString(Request.QueryString["id"]);
                    if (_id != null)
                    {
                        DataTable dt = new DataTable();
                        dt = dal.getBuscarDeudaPorId(Convert.ToInt32(_id)).Tables[0];
                        foreach (DataRow item in dt.Rows)
                        {
                            hfIdDeuda.Value= item["IdDeuda"].ToString();
                            txtNroDocumento.Text = item["NroDocumento"].ToString();
                            if (item["IdEstadoDeuda2"].ToString()!=string.Empty)
                            {
                                ddlEstadoDeuda.SelectedValue = item["IdEstadoDeuda2"].ToString();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlEstadoDeuda_DataBound(object sender, EventArgs e)
        {
            ddlEstadoDeuda.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        protected void lbtnNuevaDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                int idDeuda = Convert.ToInt32(hfIdDeuda.Value);
                int estadoDeuda = Convert.ToInt32(ddlEstadoDeuda.SelectedValue);
                string obs = txtObservacion.Text;
                dal.setUpDeuda(idDeuda, estadoDeuda, obs);

                divAlerta.Visible = true;
                lblInfo.Text = "Deuda editada correctamente";

                Response.Redirect("Principal.aspx");
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void estadoDeuda2()
        {
            int? idPerfil = Convert.ToInt32(Session["variableIdPerfil"]);

            if (idPerfil==1)
            {
                idPerfil = null;
            }
            else
            {
                idPerfil = 0;
            }

            ddlEstadoDeuda.DataSource = dal.getBuscarEstadoDeuda2(1, idPerfil);
            ddlEstadoDeuda.DataTextField = "NomEstadoDeuda2";
            ddlEstadoDeuda.DataValueField = "IdEstadoDeuda2";
            ddlEstadoDeuda.DataBind();
        }
    }
}