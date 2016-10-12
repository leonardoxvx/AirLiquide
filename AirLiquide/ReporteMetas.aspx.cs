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
    public partial class ReporteMetas : System.Web.UI.Page
    {
        public string gestionesStr;
        public string casosStr;
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    sucursal();
                    //ddlMes.SelectedValue = "10";
                    DateTime fechatemp = DateTime.Today;
                    int mes = fechatemp.Month;
                    ddlMes.SelectedValue = mes.ToString();
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }


        void buscar()
        {
            DataTable dt = new DataTable();
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            string sucursal = ddlSucursal.SelectedValue;
            string mes = ddlMes.SelectedValue;
            string ano = ddlAno.SelectedValue;
            
            dt = dal.getBuscarReporteMetas(ano, mes, sucursal).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }

            StringBuilder sbGestiones = new StringBuilder();
            StringBuilder sbCasos = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string gestiones = item["pagos"].ToString();
                string casos = item["meta"].ToString();

                sbGestiones.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + gestiones + "')},");
                sbCasos.Append("{label: '" + item["NomSucursal"].ToString() + "', y: parseInt('" + casos + "')},");
            }

            //inicializa los valores en vacio para el grafico
            string strGestiones = "[{label: '0', y: parseInt('0')}]";
            string strCasos = "[{label: '0', y: parseInt('0')}]";

            if (sbGestiones.ToString() != "")
            {
                strGestiones = "[" + sbGestiones.ToString().Remove(sbGestiones.ToString().Length - 1) + "]";
            }

            if (sbCasos.ToString() != "")
            {
                strCasos = "[" + sbCasos.ToString().Remove(sbCasos.ToString().Length - 1) + "]";
            }

            //hfConsulta.Value = strGestiones;
            gestionesStr = strGestiones;

            //hfSolicitud.Value = strCasos;
            casosStr = strCasos;

            string script3;
            script3 = "<script type=text/javascript>ejemplo();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ejemplo", script3, false);


            grvMetas.DataSource = dt;
            grvMetas.DataBind();
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", "0"));
        }

        void sucursal()
        {
            Sucursal su = new Sucursal();
            su.Activo = 1;
            ddlSucursal.DataSource = dal.getBuscarSucursal(su);
            ddlSucursal.DataTextField = "NomSucursal";
            ddlSucursal.DataValueField = "IdSucursal";
            ddlSucursal.DataBind();
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
    }
}