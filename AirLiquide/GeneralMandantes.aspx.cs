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

namespace Cobros30
{
    public partial class GeneralMandantes : System.Web.UI.Page
    {
        Datos dal = new Datos();
        public string deudaActivaStr;
        public string montoAsignadoStr;
        public string retiroCastigoStr;
        public string pagosAbonoStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    buscar();
                    grafico();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void buscar() {
            grvMandantes.DataSource = dal.getBuscarMandantesGeneral(1,Convert.ToInt32(Session["variableIdUsuario"]));
            grvMandantes.DataBind();
        }

        void grafico() {
            DataTable dt = new DataTable();
            dt = dal.getBuscarMandantesGeneral(1, Convert.ToInt32(Session["variableIdUsuario"])).Tables[0];

            if (dt.Rows.Count == 0)
            {
                return;
            }

            StringBuilder sbMontoAsignado = new StringBuilder();
            StringBuilder sbDeudaActiva = new StringBuilder();
            StringBuilder sbRetiroCastigo = new StringBuilder();
            StringBuilder sbPagosAbono = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string montoAsignado = item["monto_asignado"].ToString();
                string deudaActiva = item["Saldo_activo"].ToString();
                string retiroCastigo = item["retiro"].ToString();
                string pagosAbono = item["Pagos_Abono"].ToString();

                sbMontoAsignado.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + montoAsignado + "')},");
                sbDeudaActiva.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + deudaActiva + "')},");
                sbRetiroCastigo.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + retiroCastigo + "')},");
                sbPagosAbono.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + pagosAbono + "')},");
            }

            //inicializa los valores en vacio para el grafico
            string strMontoAsignado = "[{label: '0', y: parseInt('0')}]";
            string strDeudaActiva = "[{label: '0', y: parseInt('0')}]";
            string strRetiroCastigo = "[{label: '0', y: parseInt('0')}]";
            string strPagosAbono = "[{label: '0', y: parseInt('0')}]";


            if (sbMontoAsignado.ToString() != "")
            {
                strMontoAsignado = "[" + sbMontoAsignado.ToString().Remove(sbMontoAsignado.ToString().Length - 1) + "]";
            }

            if (sbDeudaActiva.ToString() != "")
            {
                strDeudaActiva = "[" + sbDeudaActiva.ToString().Remove(sbDeudaActiva.ToString().Length - 1) + "]";
            }

            if (sbRetiroCastigo.ToString() != "")
            {
                strRetiroCastigo = "[" + sbRetiroCastigo.ToString().Remove(sbRetiroCastigo.ToString().Length - 1) + "]";
            }

            if (sbPagosAbono.ToString() != "")
            {
                strPagosAbono = "[" + sbPagosAbono.ToString().Remove(sbPagosAbono.ToString().Length - 1) + "]";
            }

            montoAsignadoStr = strMontoAsignado;
            deudaActivaStr = strDeudaActiva;
            retiroCastigoStr = strRetiroCastigo;
            pagosAbonoStr = strPagosAbono;

            string script3;
            script3 = "<script type=text/javascript>ejemplo();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ejemplo", script3, false);
        }

        protected void lbtnVerMasRutAsignados_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");

                Response.Redirect("CarteraAsignada.aspx?Tipo=RutAsignado&Mandante=1&idSucursal="+ _lblIdMandante.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnVerMasMontoAsignado_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");

                Response.Redirect("CarteraAsignada.aspx?Tipo=MontoAsignado&Mandante=1&idSucursal=" + _lblIdMandante.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnVerMasPagosAbono_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");

                Response.Redirect("CarteraAsignada.aspx?Tipo=PagosAbono&Mandante=1&idSucursal=" + _lblIdMandante.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnVerMasRetiro_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");

                Response.Redirect("CarteraAsignada.aspx?Tipo=Retiro&Mandante=1&idSucursal=" + _lblIdMandante.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void lbtnVerMasSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdMandante = (Label)grvMandantes.Rows[row.RowIndex].FindControl("lblIdMandante");

                Response.Redirect("CarteraAsignada.aspx?Tipo=Saldo&Mandante=1&idSucursal=" + _lblIdMandante.Text);
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}