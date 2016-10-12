using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Text.RegularExpressions;
using System.Data;

namespace Cobros30
{
    public partial class AsignacionAsistida : System.Web.UI.Page
    {

        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    usuario();
                    tipo();
                    resumen();
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
                string idLogin = Session["variableIdUsuario"].ToString();
                string idMandante = Session["IdMandante"].ToString();
                
                String[] nroDocumentos = Regex.Split(txtNroDocumento.Text.Trim(), "\n");
                String[] ruts = Regex.Split(txtRut.Text.Trim(), "\n");
                String[] codigoUsuarios = Regex.Split(txtCodigosUsuario.Text.Trim(), "\n");

                int cantidadDeDocs = nroDocumentos.Count();
                int cantidadDeRuts = ruts.Count();
                int cantidadDeUsuarios = codigoUsuarios.Count();


                if (ddlTipo.SelectedValue=="CLIENTE")
                {
                    if (cantidadDeRuts != cantidadDeUsuarios)
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "La cantidad de registros de las 2 cajas no coinciden.";
                        return;
                    }
                }
                else
                {
                    if (cantidadDeDocs != cantidadDeUsuarios)
                    {
                        divAlerta.Visible = true;
                        lblInfo.Text = "La cantidad de registros de las 2 cajas no coinciden.";
                        return;
                    }
                }

                

                DataTable dt = new DataTable();
                DataColumn rut = dt.Columns.Add("RUT", typeof(string));
                DataColumn codigoUsuario = dt.Columns.Add("ID_USUARIO", typeof(string));
                DataColumn nroDocumento = dt.Columns.Add("NRO_DOCUMENTO", typeof(string));

                //string primera = "";
                //string tercera = "";

                //for (int i = 0; i < ruts.Length; i++)
                //{
                //    primera = ruts[i].Trim();
                //    for (int r = i; r < codigoUsuarios.Length; r++)
                //    {
                //        tercera = codigoUsuarios[r].Trim();
                //        dt.Rows.Add(primera, tercera);
                //        break;
                //    }
                //}

                string primera = "";
                string segunda = "";
                string tercera = "";

                for (int i = 0; i < ruts.Length; i++)
                {
                    primera = ruts[i].Trim();
                    for (int r = i; r < nroDocumentos.Length; r++)
                    {
                        segunda = nroDocumentos[r].Trim();

                        for (int y = i; y < codigoUsuarios.Length; y++)
                        {
                            tercera = codigoUsuarios[y].Trim();

                            dt.Rows.Add(primera, tercera, segunda);
                            break;
                        }
                        break;
                    }
                }

                Deuda deu = new Deuda();
                deu.IdMandante = Convert.ToInt32(idMandante);
                int idUsuarioAsignadoPor = Convert.ToInt32(Session["variableIdUsuario"]);
                foreach (DataRow item in dt.Rows)
                {
                    string idUsuario = item["ID_USUARIO"].ToString();
                    string rutDeudor = item["RUT"].ToString();
                    string nroDoc = item["NRO_DOCUMENTO"].ToString();

                    deu.RutDeudor = rutDeudor;
                    
                    deu.IdUsuarioAsig = Convert.ToInt32(idUsuario);
                    deu.IdUsuarioAsigPor = idUsuarioAsignadoPor;
                    deu.NroDocumento = nroDoc;

                    dal.setUpAsignacionAsistida(deu, ddlTipo.SelectedValue);
                }

                divAlerta.Visible = true;
                lblInfo.Text = "Se modificó correctamente.";
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void usuario() {
            int idMandante = Convert.ToInt32(Session["IdMandante"]);
            grvUsuarios.DataSource = dal.getBuscarUsuarioAsignacion(idMandante, 1);
            grvUsuarios.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tipo();
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void tipo()
        {
            if (ddlTipo.SelectedValue == "CLIENTE")
            {
                tdNroDocumento.Visible = false;
                tdRut.Visible = true;
            }
            else
            {
                tdNroDocumento.Visible = true;
                tdRut.Visible = false;
            }
        }


        void resumen()
        {
            /*@maxDeuda as maxDeuda ,
             @minDeuda as minDeuda ,
             @promDeuda as promDeuda ,
             @cantRut as cantRut ,
             @montoTotal as montoTotal,
             @cantRutAsignado as cantRutAsignado ,
             @montoTotalAsignado as montoTotalAsignado ,
             @cantEjeAsig as cantEjeAsig,
             @cantRutNoAsignado as cantRutNoAsignado,
             @montoTotalNoAsignado as montoTotalNoAsignado*/
            DataTable dt = new DataTable();
            dt = dal.getBuscarResumenAsignacionAutomatica(Convert.ToInt32(Session["IdMandante"]), 0).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                lblMaxDeuda.Text = Convert.ToDecimal(item["maxDeuda"]).ToString("n0");
                lblMinDeuda.Text = Convert.ToDecimal(item["minDeuda"]).ToString("n0");
                lblPromedioDeuda.Text = Convert.ToDecimal(item["promDeuda"]).ToString("n0");
                lblCantidadRut.Text = item["cantRut"].ToString();
                lblMontoTotal.Text = Convert.ToDecimal(item["montoTotal"]).ToString("n0");
                lblCantidadRutAsignado.Text = item["cantRutAsignado"].ToString();
                lblMontoTotalAsignado.Text = Convert.ToDecimal(item["montoTotalAsignado"]).ToString("n0");
                lblCantidadEjecutivoAsignado.Text = item["cantEjeAsig"].ToString();
                lblCantidadRutNoAsignado.Text = item["cantRutNoAsignado"].ToString();
                lblMontoTotalNoAsignado.Text = Convert.ToDecimal(item["montoTotalNoAsignado"]).ToString("n0");
                lblCantidadDocs.Text = Convert.ToDecimal(item["cantDocs"]).ToString("n0");
                lblCantidadDocAsignado.Text = Convert.ToDecimal(item["cantDocsAsignados"]).ToString("n0");
                lblCantidadDocsNoAsignado.Text = Convert.ToDecimal(item["cantDocsNoAsignados"]).ToString("n0");

            }
        }

    }
}