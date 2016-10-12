using DataTableToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cobros30
{
    public partial class DetalleTipificaciones : System.Web.UI.Page
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(this.ibtnExportalExcel);

            if (!Page.IsPostBack)
            {
                buscar();
            }
        }

        void buscar()
        {
            ds = Session["detalleGestiones"] as DataSet;

            grvDetalleGestiones.DataSource = ds;
            grvDetalleGestiones.DataBind();
        }


        protected void ibtnExportalExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsGestion = Session["detalleGestiones"] as DataSet;
                DataTable dt = new DataTable();
                dt = dsGestion.Tables[0];
                //Utilidad.ExportDataTableToExcel(dt, "exporte.xls", "", "", "", "");
                //Utilidad.ExportDataTableToExcel(dt, "exporte.xls", "", "", "", "");
                Response.ContentType = "Application/x-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=" + "detalle_gestiones_extrajudiciales" + ".csv");
                Response.ContentEncoding = Encoding.Unicode;
                Response.Write(Utilidad.ExportToCSVFile(dt));
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                //lblInformacion.Text = ex.Message;
                //mdlInformacion.Show();
            }
        }

    }
}