using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;

namespace Cobros30
{
    public partial class InformeGestionesDiarias : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    buscar();
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

            

            string mes = string.Empty;
            string mesNombre = string.Empty;
            string anio = string.Empty;
            string dia = string.Empty;

            DateTime hoy = DateTime.Now;

            anio = hoy.Year.ToString();
            mes = hoy.Month.ToString();
            mesNombre = FirstCharToUpper(nombreMes(hoy.Month));
            dia = hoy.Day.ToString();

            lblMes1.Text = mesNombre + " " + anio;

            //string lastDay = hoy.AddMonths(-2).AddDays(-hoy.Day).Day.ToString();

            DataTable dt = new DataTable();
            dt = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, dia + "-" + mes + "-" + anio).Tables[0];
            //dt.Columns.Add("Total");
            //dt.Columns.Add("Promedio");
            //foreach (DataColumn column in dt.Columns)
            //{
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        decimal total = 0;
            //        if (it)
            //        {

            //        }
            //    }
            //}

            grvInformeRecupero1.DataSource = dt;
            grvInformeRecupero1.DataBind();

            mes = hoy.Date.AddMonths(-1).Month.ToString();
            anio = hoy.Date.AddMonths(-1).Year.ToString();
            mesNombre = nombreMes(hoy.Date.AddMonths(-1).Month);
            lblMes2.Text = FirstCharToUpper(mesNombre) + " " + anio;
            string ultimoDia = hoy.Date.AddDays(-hoy.Day).Day.ToString();

            grvInformeRecupero2.DataSource = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, ultimoDia + "-" + mes + "-" + anio);
            grvInformeRecupero2.DataBind();




            mes = hoy.Date.AddMonths(-2).Month.ToString();
            anio = hoy.Date.AddMonths(-2).Year.ToString();
            mesNombre = nombreMes(hoy.Date.AddMonths(-2).Month);
            lblMes3.Text = FirstCharToUpper(mesNombre) + " " + anio;
            ultimoDia = hoy.Date.AddMonths(-1).AddDays(-hoy.Day).Day.ToString();

            grvInformeRecupero3.DataSource = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, ultimoDia + "-" + mes + "-" + anio);
            grvInformeRecupero3.DataBind();


            mes = hoy.Date.AddMonths(-3).Month.ToString();
            anio = hoy.Date.AddMonths(-3).Year.ToString();
            mesNombre = nombreMes(hoy.Date.AddMonths(-3).Month);
            lblMes4.Text = FirstCharToUpper(mesNombre) + " " + anio;
            ultimoDia = hoy.Date.AddMonths(-2).AddDays(-hoy.Day).Day.ToString();

            grvInformeRecupero4.DataSource = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, ultimoDia + "-" + mes + "-" + anio);
            grvInformeRecupero4.DataBind();



            mes = hoy.Date.AddMonths(-4).Month.ToString();
            anio = hoy.Date.AddMonths(-4).Year.ToString();
            mesNombre = nombreMes(hoy.Date.AddMonths(-4).Month);
            lblMes5.Text = FirstCharToUpper(mesNombre) + " " + anio;
            ultimoDia = hoy.Date.AddMonths(-3).AddDays(-hoy.Day).Day.ToString();

            grvInformeRecupero5.DataSource = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, ultimoDia + "-" + mes + "-" + anio);
            grvInformeRecupero5.DataBind();

            mes = hoy.Date.AddMonths(-5).Month.ToString();
            anio = hoy.Date.AddMonths(-5).Year.ToString();
            mesNombre = nombreMes(hoy.Date.AddMonths(-5).Month);
            lblMes6.Text = FirstCharToUpper(mesNombre) + " " + anio;
            ultimoDia = hoy.Date.AddMonths(-4).AddDays(-hoy.Day).Day.ToString();

            grvInformeRecupero6.DataSource = dal.getInformeGestionesDiarias(mes, anio, "01-" + mes + "-" + anio, ultimoDia + "-" + mes + "-" + anio);
            grvInformeRecupero6.DataBind();

        }


        protected void paginacion1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero1.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero1.HeaderRow.Cells.Count; i++)
                {
                    String header = grvInformeRecupero1.HeaderRow.Cells[i].Text;
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }

                string promedio = (_total / columnasConDatos).ToString("0.#");

                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
                //_total += Convert.ToDecimal(_lbtnTotal.Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Total:";
                //Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                //_total += Convert.ToDecimal(_lbtnTotal.Text);


                //e.Row.Cells[1].Text = _TotalRsa.ToString("n0");
                //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[2].Text = _TotalChilena.ToString("n0");
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[3].Text = _TotalLiberty.ToString("n0");
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[4].Text = _TotalHertz.ToString("n0");
                //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[5].Text = _TotalConsorcio.ToString("n0");
                //e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[6].Text = _TotalBci.ToString("n0");
                //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[7].Text = _TotalTotal.ToString("n0");
                //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;
            }
        }

        protected void paginacion2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero2.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero2.HeaderRow.Cells.Count; i++)
                {

                    String header = grvInformeRecupero2.HeaderRow.Cells[i].ToString();
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }
                string promedio = (_total / columnasConDatos).ToString("0.##");
                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
                //_total += Convert.ToDecimal(_lbtnTotal.Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Total:";
                //Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                //_total += Convert.ToDecimal(_lbtnTotal.Text);


                //e.Row.Cells[1].Text = _TotalRsa.ToString("n0");
                //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[2].Text = _TotalChilena.ToString("n0");
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[3].Text = _TotalLiberty.ToString("n0");
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[4].Text = _TotalHertz.ToString("n0");
                //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[5].Text = _TotalConsorcio.ToString("n0");
                //e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[6].Text = _TotalBci.ToString("n0");
                //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[7].Text = _TotalTotal.ToString("n0");
                //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Font.Bold = true;
            }
        }



        protected void paginacion3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero3.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero3.HeaderRow.Cells.Count; i++)
                {

                    String header = grvInformeRecupero3.HeaderRow.Cells[i].ToString();
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }
                string promedio = (_total / columnasConDatos).ToString("0.##");
                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                
            }
        }



        protected void paginacion4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero4.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero4.HeaderRow.Cells.Count; i++)
                {

                    String header = grvInformeRecupero4.HeaderRow.Cells[i].ToString();
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }
                string promedio = (_total / columnasConDatos).ToString("0.##");
                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }


        protected void paginacion5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero5.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero5.HeaderRow.Cells.Count; i++)
                {

                    String header = grvInformeRecupero5.HeaderRow.Cells[i].ToString();
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }
                string promedio = (_total / columnasConDatos).ToString("0.##");
                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }

        protected void paginacion6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //private decimal _TotalTotal2 = 0;
            decimal _total = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numeroColumnas = grvInformeRecupero6.HeaderRow.Cells.Count;
                int columnasConDatos = 0;
                for (int i = 3; i < grvInformeRecupero6.HeaderRow.Cells.Count; i++)
                {

                    String header = grvInformeRecupero6.HeaderRow.Cells[i].ToString();
                    String cellText = e.Row.Cells[i].Text;

                    if (cellText != "&nbsp;")
                    {
                        columnasConDatos++;
                        _total += Convert.ToDecimal(cellText);
                    }
                    else
                    {
                        e.Row.Cells[i].Text = "0";
                    }
                }
                string promedio = (_total / columnasConDatos).ToString("0.##");
                Label _lbtnTotal = (Label)e.Row.FindControl("lblTotal");
                _lbtnTotal.Text = _total.ToString();
                Label _lblPromedio = (Label)e.Row.FindControl("lblPromedio");
                _lblPromedio.Text = promedio;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }


        public string nombreMes(int mes)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(mes);
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}