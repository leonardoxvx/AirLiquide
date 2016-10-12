using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;
using System.Data;
using System.IO;
using System.Text;

namespace Cobros30
{
    public partial class CargasGenerales : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Deudor deudor = new Deudor();
        Deuda deuda = new Deuda();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                divAlerta.Visible = false;
                //hlDescargar.NavigateUrl = "";
                //hlDescargar.Text = "";

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.aDescargar);

                if (!this.Page.IsPostBack)
                {
                    cliente();
                    tipoDocumento();
                    tipoPersona();
                    probabilidadCobro();
                    asignacion();
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
                if (fuArchivo.HasFile)
                {
                    string idUsuario = Session["variableIdUsuario"].ToString();
                    string idMandante = Session["IdMandante"].ToString();
                    // se verifica si la extension del archivo
                    string tipoArchivo = fuArchivo.FileName;
                    tipoArchivo = tipoArchivo.Substring(tipoArchivo.LastIndexOf(".") + 1).ToLower();
                    // se valida el archivo si es PDF

                    
                    if (tipoArchivo == "csv")
                    {
                        fuArchivo.SaveAs(Server.MapPath("assets/formatosCarga/temp/" + fuArchivo.FileName));

                        DataTable dt = new DataTable();
                        List<string[]> testParse = parseCSV(Server.MapPath("assets/formatosCarga/temp/" + fuArchivo.FileName));

                        foreach (string column in testParse[0])
                        {
                            dt.Columns.Add(column);
                        }

                        for (int n = 1; n < testParse.Count; n++)
                        {
                            string[] row = testParse[n];
                            dt.Rows.Add(row);
                        }

                        if (ddlTipoProceso.SelectedValue == "CARGA_DEUDOR")
                        {
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("NOMBRE;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");
                            //
                            foreach (DataRow item in dt.Rows)
                            {
                                string rut = item["CODCLIENTE"].ToString();
                                string nombre = item["NOMBRE"].ToString();
                                string rutRepLegal = item["RUT_REP_LEGAL"].ToString();
                                string nomRepLegal = item["NOM_REP_LEGAL"].ToString();
                                string adic1 = item["ADIC1"].ToString();
                                string adic2 = item["ADIC2"].ToString();
                                string adic3 = item["ADIC3"].ToString();
                                string adic4 = item["ADIC4"].ToString();
                                string adic5 = item["ADIC5"].ToString();
                                string idProbCobro = item["ID_PROB_COBRO"].ToString();
                                string idTipoPersona = item["ID_TIPO_PERSONA"].ToString();

                                deudor.RutDeudor = rut;
                                deudor.NombreDeudor = nombre;
                                deudor.RepLegalRut = rutRepLegal;
                                deudor.RepLegalNombre = nomRepLegal;
                                deudor.Adic1 = adic1;
                                deudor.Adic2 = adic2;
                                deudor.Adic3 = adic3;
                                deudor.Adic4 = adic4;
                                deudor.Adic5 = adic5;
                                if (idProbCobro!=string.Empty)
                                {
                                    deudor.IdProbabilidadCobro = Convert.ToInt32(idProbCobro);
                                }
                                if (idTipoPersona!=string.Empty)
                                {
                                    deudor.IdTipoPersona = Convert.ToInt32(idTipoPersona);
                                }
                                deudor.IdUsuarioIngreso = idUsuario;
                                deudor.IdMandante= Convert.ToInt32(idMandante);
                                string valor = dal.setInDeudor(deudor);
                                if (valor == "1")
                                {
                                    //contador += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(nombre + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    contador++;
                                }
                                else
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(nombre + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Rut)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                //In.setIngresarTelefono(rutDeudor, codArea, telefono, "", idUsuario);
                                //In.setIngresarCargaTelefono(rutDeudor,codArea,,telefono,idUsuario,"");
                                contadorGeneral ++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            //string csvFilePath = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close(); 
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                            //divAlerta.Visible = true;
                        }

                        if (ddlTipoProceso.SelectedValue == "CARGA_DEUDA")
                        {
                            //
                            if (ddlAsignacion.SelectedValue == "0")
                            {
                                divAlerta.Visible = true;
                                lblInfo.Text = "Favor seleccionar una asignación";
                                return;
                            }

                            Deuda deuda = new Deuda();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("NRO DOCUMENTO;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");

                            foreach (DataRow item in dt.Rows)
                            {
                                //RutDeudor	NroDocumento	NroCuota	IdTipoDocumento	FechaVencimiento	FechaEmision	FechaProtesto	DeudaOriginal	MontoProtesto	
                                //NumCliente	Sucursal	CentroCosto	RutSubCliente	NombreSubCliente	Observacion	Adic1	Adic2	Adic3	Adic4	Adic5	Adic6	Adic7	Adic8	Adic9	Adic10

                                string rut = item["CodCliente"].ToString();
                                string nroDoc = item["NroDocumento"].ToString();
                                string nroCuota = item["NroCuota"].ToString();
                                string idTipoDoc = item["IdTipoDocumento"].ToString();
                                string fechaVenc = item["FechaVencimiento"].ToString();
                                string fechaEmision = item["FechaEmision"].ToString();
                                string fechaProtesto = item["FechaProtesto"].ToString();
                                string monto = item["DeudaOriginal"].ToString();
                                string montoProtesto = item["MontoProtesto"].ToString();
                                string nroCliente = item["NumCliente"].ToString();
                                string sucursal = item["Sucursal"].ToString();
                                string centroCosto = item["CentroCosto"].ToString();
                                string rutSubCliente = item["RutSubCliente"].ToString();
                                string nombreSubCliente = item["NombreSubCliente"].ToString();
                                string observacion = item["Observacion"].ToString();
                                string adic1 = item["Adic1"].ToString();
                                string adic2 = item["Adic2"].ToString();
                                string adic3 = item["Adic3"].ToString();
                                string adic4 = item["Adic4"].ToString();
                                string adic5 = item["Adic5"].ToString();
                                string adic6 = item["Adic6"].ToString();
                                string adic7 = item["Adic7"].ToString();
                                string adic8 = item["Adic8"].ToString();
                                string adic9 = item["Adic9"].ToString();
                                string adic10 = item["Adic10"].ToString();
                                string cuenta = item["Cuenta"].ToString();

                                deuda.RutDeudor = rut;
                                deuda.NroDocumento = nroDoc;
                                if (nroCuota != string.Empty)
                                {
                                    deuda.NroCuota = Convert.ToInt32(nroCuota);
                                }
                                if (idTipoDoc != string.Empty)
                                {
                                    deuda.IdTipoDocumento = idTipoDoc;
                                }
                                if (fechaVenc.Trim()!=string.Empty)
                                {
                                    deuda.FechaVencimiento = Convert.ToDateTime(fechaVenc);
                                }
                                else
                                {
                                    deuda.FechaVencimiento = null;
                                }
                                if (fechaEmision.Trim()!=string.Empty)
                                {
                                    deuda.FechaEmision = Convert.ToDateTime(fechaEmision);
                                }
                                else
                                {
                                    deuda.FechaEmision = null;
                                }
                                if (fechaProtesto.Trim()!=string.Empty)
                                {
                                    deuda.FechaProtesto = Convert.ToDateTime(fechaProtesto);
                                }
                                else
                                {
                                    deuda.FechaProtesto = null;
                                }
                                if (monto.Trim()!=string.Empty)
                                {
                                    deuda.DeudaOriginal = Convert.ToDouble(monto);
                                    deuda.Saldo = Convert.ToDouble(monto);
                                }
                                if (montoProtesto.Trim()!=string.Empty)
                                {
                                    deuda.MontoProtesto = Convert.ToDouble(montoProtesto);
                                }
                                deuda.NumCliente = nroCliente;
                                deuda.Sucursal = sucursal;
                                deuda.CentroCosto = centroCosto;
                                deuda.RutSubCliente = rutSubCliente;
                                deuda.NombreSubCliente = nombreSubCliente;
                                deuda.Observacion = observacion;
                                deuda.Adic1 = adic1;
                                deuda.Adic2 = adic2;
                                deuda.Adic3 = adic3;
                                deuda.Adic4 = adic4;
                                deuda.Adic5 = adic5;
                                deuda.Adic6 = adic6;
                                deuda.Adic7 = adic7;
                                deuda.Adic8 = adic8;
                                deuda.Adic9 = adic9;
                                deuda.Adic10 = adic10;
                                deuda.UsuarioCreacion = Convert.ToInt32(idUsuario);
                                deuda.IdMandante = Convert.ToInt32(idMandante);
                                deuda.IdTipoCarga = 3;

                                deuda.Cuenta = cuenta;

                                //asignacion
                                deuda.IdAsignacion = Convert.ToInt32(ddlAsignacion.SelectedValue);
                                //finAsignacion//
                                string valor = dal.setInDeuda(deuda);
                                if (valor == "1")
                                {
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(nroDoc + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    //contador += Convert.ToInt32(valor);
                                    contador++;
                                }
                                else
                                {
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(nroDoc + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Rut)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("~/assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                        }
                        if (ddlTipoProceso.SelectedValue == "CARGA_GESTIONES")
                        {
                            Gestiones ges = new Gestiones();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            //StringBuilder tmpCsvNoCargados = new StringBuilder();
                            //tmpCsvNoCargados.Append("ID;");
                            //tmpCsvNoCargados.Append("ID;");
                            //tmpCsvNoCargados.Append("NRO DOCUMENTO;");
                            //tmpCsvNoCargados.Append("ESTADO");
                            //tmpCsvNoCargados.Append("\r\n");

                            foreach (DataRow item in dt.Rows)
                            {
                                //RutDeudor	NroDocumento	NroCuota	IdTipoDocumento	FechaVencimiento	FechaEmision	FechaProtesto	DeudaOriginal	MontoProtesto	
                                //NumCliente	Sucursal	CentroCosto	RutSubCliente	NombreSubCliente	Observacion	Adic1	Adic2	Adic3	Adic4	Adic5	Adic6	Adic7	Adic8	Adic9	Adic10

                                string rut = item["CODCLIENTE"].ToString();
                                string idTipificacion = item["ID_TIPIFICACION"].ToString();
                                string fechaIngreso = item["FECHA_INGRESO"].ToString();
                                string horaIngreso = item["HORA_INGRESO"].ToString();
                                string fechaCompromiso = item["FECHA_COMPROMISO"].ToString();
                                string montoCompromiso = item["MONTO_COMPROMISO"].ToString();
                                string fechaAgendamiento = item["FECHA_AGENDAMIENTO"].ToString();
                                string horaAgendamiento = item["HORA_AGENDAMIENTO"].ToString();
                                string observacion = item["OBSERVACIONES"].ToString();
                                string idUsuarioIngreso = item["ID_USUARIO"].ToString();

                                ges.RutDeudor = rut;
                                ges.IdTipificacion = Convert.ToInt32(idTipificacion);
                                if (fechaIngreso!=string.Empty)
                                {
                                    ges.FechaIngreso = Convert.ToDateTime(fechaIngreso);
                                }
                                else
                                {
                                    ges.FechaIngreso = DateTime.Now;
                                }
                                
                                ges.HoraIngreso = horaIngreso;
                                if (fechaCompromiso!=string.Empty)
                                {
                                    ges.FechaCompromiso = Convert.ToDateTime(fechaCompromiso);
                                }

                                if (montoCompromiso!=string.Empty)
                                {
                                    ges.MontoCompromiso = Convert.ToInt32(montoCompromiso);
                                }

                                if (fechaAgendamiento != string.Empty)
                                {
                                    ges.FechaAgendamiento = Convert.ToDateTime(fechaAgendamiento);
                                }
                                
                                ges.HoraAgendamiento = horaAgendamiento;
                                ges.Observaciones = observacion;
                                ges.IdUsuario = Convert.ToInt32(idUsuarioIngreso);
                                ges.IdMandante = Convert.ToInt32(idMandante);

                                //finAsignacion
                                string valor = dal.setInGestion(ges);
                                //if (valor != string.Empty)
                                //{

                                //    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                //    tmpCsvNoCargados.Append(rut + ";");
                                //    tmpCsvNoCargados.Append(nroDoc + ";");
                                //    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                //}
                                //else
                                //{
                                //    contadorNoCargados += Convert.ToInt32(valor);
                                //    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                //    tmpCsvNoCargados.Append(rut + ";");
                                //    tmpCsvNoCargados.Append(nroDoc + ";");
                                //    tmpCsvNoCargados.Append("No cargado (Existe Rut)" + "\r\n");
                                //}
                                contador++;
                                contadorGeneral++;
                            }
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                        }
                        if (ddlTipoProceso.SelectedValue == "CARGA_TELEFONO")
                        {
                            UbicTelefono tel = new UbicTelefono();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("COD_AREA;");
                            tmpCsvNoCargados.Append("TELEFONO;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");

                            foreach (DataRow item in dt.Rows)
                            {
                                string rut = item["CODCLIENTE"].ToString();
                                //string idArea = item["COD_AREA"].ToString();
                                string idArea = "0";
                                string telefono = item["TELEFONO"].ToString();

                                tel.Rut = rut;
                                tel.IdArea = idArea;
                                tel.Telefono = telefono;
                                tel.IdProveedorUbic = 1;

                                string valor = dal.setInUbicTelefono(tel);
                                if (valor == "0")
                                {
                                    //contador += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(idArea + ";");
                                    tmpCsvNoCargados.Append(telefono + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    contador++;
                                }
                                else
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(idArea + ";");
                                    tmpCsvNoCargados.Append(telefono + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Telefono)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("~/assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;

                            lblInfo.Text = "Su archivo no es de tipo .csv";
                            divAlerta.Visible = true;

                        }
                        if (ddlTipoProceso.SelectedValue == "CARGA_EMAIL")
                        {
                            UbicEmail email = new UbicEmail();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("EMAIL;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");
                            foreach (DataRow item in dt.Rows)
                            {
                                string rut = item["CODCLIENTE"].ToString();
                                string emailstr = item["EMAIL"].ToString();
                                email.Email = emailstr;
                                email.Rut = rut;

                                string valor = dal.setInUbicEmail(email);
                                if (valor == "0")
                                {
                                    //contador += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(emailstr + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    contador++;
                                }
                                else if (valor == "2")
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(emailstr + ";");
                                    tmpCsvNoCargados.Append("No cargado (El Cod Cliente y telefono son obligatorios)" + "\r\n");
                                    contadorNoCargados++;
                                }
                                else
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(emailstr + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Email)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("~/assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                        }
                        if (ddlTipoProceso.SelectedValue == "CARGA_DIRECCION")
                        {
                            //RUT;CALLE;NUMERO;RESTO;COMUNA;CIUDAD
                            UbicDireccion dir = new UbicDireccion();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("CALLE;");
                            tmpCsvNoCargados.Append("NUMERO;");
                            tmpCsvNoCargados.Append("RESTO;");
                            tmpCsvNoCargados.Append("COMUNA;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");
                            foreach (DataRow item in dt.Rows)
                            {
                                string rut = item["CODCLIENTE"].ToString();
                                string calle = item["CALLE"].ToString();
                                string numero = item["NUMERO"].ToString();
                                string resto = item["RESTO"].ToString();
                                string comuna = item["COMUNA"].ToString();

                                dir.Rut = rut;
                                dir.Calle = calle;
                                dir.Numero = numero;
                                dir.Resto = resto;
                                dir.Comuna = comuna;
                                dir.IdProveedorUbic = 1;
                                dir.IdUsuarioIngreso = Convert.ToInt32(idUsuario);

                                string valor = dal.setInUbicDireccion(dir);
                                if (valor == "0")
                                {
                                    //contador += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(calle + ";");
                                    tmpCsvNoCargados.Append(numero + ";");
                                    tmpCsvNoCargados.Append(resto + ";");
                                    tmpCsvNoCargados.Append(comuna + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    contador++;
                                }
                                else if (valor == "2")
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(calle + ";");
                                    tmpCsvNoCargados.Append(numero + ";");
                                    tmpCsvNoCargados.Append(resto + ";");
                                    tmpCsvNoCargados.Append(comuna + ";");
                                    tmpCsvNoCargados.Append("No cargado (El Cod Cliente, calle y comuna son obligatorios)" + "\r\n");
                                    contadorNoCargados++;
                                }
                                else
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(rut + ";");
                                    tmpCsvNoCargados.Append(calle + ";");
                                    tmpCsvNoCargados.Append(numero + ";");
                                    tmpCsvNoCargados.Append(resto + ";");
                                    tmpCsvNoCargados.Append(comuna + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Direccion)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("~/assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                        }

                        if (ddlTipoProceso.SelectedValue == "CARGA_CLIENTE_AL")
                        {
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("NOMBRE;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");

                            foreach (DataRow item in dt.Rows)
                            {
                                string codCliente = item["COD_CLIENTE"].ToString();
                                string nombre = item["NOMBRE"].ToString();
                                string rut = item["RUT"].ToString();
                                string sector = item["SECTOR"].ToString();
                                string descripcionSector = item["DESC_SECTOR"].ToString();
                                string fechaIngreso = item["FECHA_INGRESO"].ToString();
                                string estado = item["ESTADO"].ToString();

                                deudor.RutDeudor = codCliente;
                                deudor.NombreDeudor = nombre;
                                deudor.rut = rut;
                                deudor.IdSector = sector;
                                deudor.Adic2 = descripcionSector;
                                deudor.Adic3 = fechaIngreso;
                                deudor.Adic4 = estado;
                                deudor.IdTipoCarga = 3;
                                
                                deudor.IdUsuarioIngreso = idUsuario;
                                deudor.IdMandante = Convert.ToInt32(idMandante);

                                string valor = dal.setInDeudor(deudor);
                                if (valor == "1")
                                {
                                    //contador += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(codCliente + ";");
                                    tmpCsvNoCargados.Append(nombre + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    contador++;
                                }
                                else
                                {
                                    //contadorNoCargados += Convert.ToInt32(valor);
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(codCliente + ";");
                                    tmpCsvNoCargados.Append(nombre + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe Rut)" + "\r\n");
                                    contadorNoCargados++;
                                }

                                //In.setIngresarTelefono(rutDeudor, codArea, telefono, "", idUsuario);
                                //In.setIngresarCargaTelefono(rutDeudor,codArea,,telefono,idUsuario,"");
                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            //string csvFilePath = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;

                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                            //divAlerta.Visible = true;
                        }

                        if (ddlTipoProceso.SelectedValue == "CARGA_DEUDA_AL")
                        {
                            //if (ddlAsignacion.SelectedValue == "0")
                            //{
                            //    divAlerta.Visible = true;
                            //    lblInfo.Text = "Favor seleccionar una asignación";
                            //    return;
                            //}

                            Deuda deuda = new Deuda();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;
                            StringBuilder tmpCsvNoCargados = new StringBuilder();
                            tmpCsvNoCargados.Append("ID;");
                            tmpCsvNoCargados.Append("CODCLIENTE;");
                            tmpCsvNoCargados.Append("NRO DOCUMENTO;");
                            tmpCsvNoCargados.Append("ESTADO");
                            tmpCsvNoCargados.Append("\r\n");

                            if (ddlTipoCarga.SelectedValue == "BORRAR_CARGAR")
                            {
                                dal.setDelDeuda(Convert.ToInt32(idMandante));
                            }
                            int error = 0;
                            foreach (DataRow item in dt.Rows)
                            {
                                string codSucursal = item["COD_SUCURSAL"].ToString();
                                string codCliente = item["COD_CLIENTE"].ToString();
                                string serie = item["SERIE"].ToString();
                                string codTipoDoc = item["COD_TIPO_DOCUMENTO"].ToString();
                                string doc = item["DOCUMENTO"].ToString();
                                string fechaEmision = item["FECHA_EMISION"].ToString();
                                string fechaVencimiento = item["FECHA_VENCIMIENTO"].ToString();
                                string saldo = item["SALDO"].ToString();
                                string mora = item["MORA"].ToString();

                                deuda.Sucursal = codSucursal;
                                deuda.RutDeudor = codCliente;
                                deuda.Adic2 = serie;
                                deuda.IdTipoDocumento = codTipoDoc;
                                deuda.NroDocumento = doc;
                                
                                if (fechaVencimiento.Trim() != string.Empty)
                                {
                                    deuda.FechaVencimiento = Convert.ToDateTime(fechaVencimiento);
                                }
                                else
                                {
                                    deuda.FechaVencimiento = null;
                                }
                                if (fechaEmision.Trim() != string.Empty)
                                {
                                    deuda.FechaEmision = Convert.ToDateTime(fechaEmision);
                                }
                                else
                                {
                                    deuda.FechaEmision = null;
                                }

                                if (saldo.Trim() != string.Empty)
                                {
                                    deuda.DeudaOriginal = Convert.ToDouble(saldo);
                                    deuda.Saldo = Convert.ToDouble(saldo);
                                }
                                
                                deuda.UsuarioCreacion = Convert.ToInt32(idUsuario);
                                deuda.IdMandante = Convert.ToInt32(idMandante);
                                deuda.IdTipoCarga = 3;

                                //deuda.Cuenta = cuenta;
                                //asignacion
                                //deuda.IdAsignacion = Convert.ToInt32(ddlAsignacion.SelectedValue);
                                deuda.IdAsignacion = 1;

                                
                                string valor = dal.setInDeuda(deuda);
                                if (valor == "1")
                                {
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(codCliente + ";");
                                    tmpCsvNoCargados.Append(doc + ";");
                                    tmpCsvNoCargados.Append("Cargado" + "\r\n");
                                    //contador += Convert.ToInt32(valor);
                                    contador++;
                                }
                                else
                                {
                                    tmpCsvNoCargados.Append(contadorGeneral.ToString() + ";");
                                    tmpCsvNoCargados.Append(codCliente + ";");
                                    tmpCsvNoCargados.Append(doc + ";");
                                    tmpCsvNoCargados.Append("No cargado (Existe cod cliente)" + "\r\n");
                                    contadorNoCargados++;
                                }
                                error++;
                                contadorGeneral++;
                            }

                            string csvFile = "LogCargados.csv";
                            string csvFilePath = Server.MapPath("~/assets/formatosCarga/temp/" + csvFile);
                            string path = "assets/formatosCarga/temp/" + csvFile;
                            using (StreamWriter sw = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8))
                            {
                                sw.Write(tmpCsvNoCargados.ToString());
                                sw.Close();
                            }

                            //hlDescargar.NavigateUrl = csvFilePath;
                            //hlDescargar.Text = "Descargar archivo log";
                            aDescargar.HRef = path;
                            aDescargar.Visible = true;
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;

                        }
                        if (ddlTipoProceso.SelectedValue == "CARGA_PAGOS_AL")
                        {
                            PagosAirLiquide pago = new PagosAirLiquide();
                            int contador = 0;
                            int contadorNoCargados = 0;
                            int contadorGeneral = 1;

                            foreach (DataRow item in dt.Rows)
                            {
                                /*[COD_SUCURSAL]
                                   ,[COD_CLIENTE]
                                   ,[NOMBRE_CLIENTE]
                                   ,[SERIE]
                                   ,[ESP]
                                   ,[DOCUMENTO]
                                   ,[MODALIDAD]
                                   ,[FECHA_EMISION]
                                   ,[FECHA_VENCIMIENTO]
                                   ,[REFERENCIA]
                                   ,[FECHA_REFERENCIA]
                                   ,[MONTO_TITULO]
                                   ,[BANCO]
                                   ,[NRO_CHEQUE]
                                   ,[VALOR_BAJA]
                                   ,[FECHA_VENCIMIENTO_CHEQUE]
                                   ,[MONTO_TOTAL]
                                   ,[PORTADOR]*/
                                string codSucursal = item["COD_SUCURSAL"].ToString();
                                string codCliente = item["COD_CLIENTE"].ToString();
                                string nombreCliente = item["NOMBRE_CLIENTE"].ToString();
                                string serie = item["SERIE"].ToString();
                                string esp = item["ESP"].ToString();
                                string documento =  item["DOCUMENTO"].ToString();
                                string modalidad = item["MODALIDAD"].ToString();
                                string fechaEmision = item["FECHA_EMISION"].ToString();
                                string fechaVencimiento = item["FECHA_VENCIMIENTO"].ToString();
                                string referencia = item["REFERENCIA"].ToString();
                                string fechaReferencia = item["FECHA_REFERENCIA"].ToString();
                                string montoTitulo = item["MONTO_TITULO"].ToString();
                                string banco = item["BANCO"].ToString();
                                string nroCheque = item["NRO_CHEQUE"].ToString();
                                string valorBaja = item["VALOR_BAJA"].ToString();
                                string fechaVencimientoCheque = item["FECHA_VENCIMIENTO_CHEQUE"].ToString();
                                string montoTotal = item["MONTO_TOTAL"].ToString();
                                string portador = item["PORTADOR"].ToString();

                                pago.COD_SUCURSAL = codSucursal;
                                pago.COD_CLIENTE = Convert.ToInt32(codCliente);
                                pago.NOMBRE_CLIENTE = nombreCliente;
                                pago.SERIE = serie;
                                pago.ESP = esp;
                                pago.DOCUMENTO = documento;
                                pago.MODALIDAD = modalidad;
                                if (fechaEmision!=string.Empty)
                                {
                                    pago.FECHA_EMISION = Convert.ToDateTime(fechaEmision);
                                }

                                if (fechaVencimiento!=string.Empty)
                                {
                                    pago.FECHA_VENCIMIENTO = Convert.ToDateTime(fechaVencimiento);
                                }
                                
                                pago.REFERENCIA = referencia;

                                if (fechaReferencia!=string.Empty)
                                {
                                    pago.FECHA_REFERENCIA = Convert.ToDateTime(fechaReferencia);
                                }

                                if (montoTitulo.Trim() != string.Empty)
                                {
                                    pago.MONTO_TITULO = Convert.ToDouble(montoTitulo);
                                }
                                
                                pago.BANCO = banco;
                                pago.NRO_CHEQUE = nroCheque;

                                if (valorBaja.Trim() != string.Empty)
                                {
                                    pago.VALOR_BAJA = Convert.ToDouble(valorBaja);
                                }

                                if (fechaVencimientoCheque.Trim() != string.Empty)
                                {
                                    pago.FECHA_VENCIMIENTO_CHEQUE = Convert.ToDateTime(fechaVencimientoCheque);
                                }

                                if (montoTotal.Trim() != string.Empty)
                                {
                                    pago.MONTO_TOTAL = Convert.ToDouble(montoTotal);
                                }
                                
                                pago.PORTADOR = portador;

                                string valor = dal.setInPagosAL(pago, Convert.ToInt32(idUsuario), Convert.ToInt32(idMandante));
                                contador++;
                                contadorGeneral++;

                            }
                            lblResultado.Text = "Proceso realizado correctamente <br> Total registros: " + dt.Rows.Count.ToString() + "<br> Registros cargados: " + contador.ToString() + "<br> Registros no cargados: " + contadorNoCargados.ToString();
                            divResultado.Visible = true;
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Su archivo no es de tipo .csv";
                        divAlerta.Visible = true;
                    }
                }
                else
                {
                    lblInfo.Text = "Favor de adjuntar un archivo .csv";
                    divAlerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        void tipoPersona() {
            grvTipoPersona.DataSource = dal.getBuscarTipoPersona(1);
            grvTipoPersona.DataBind();
        }

        void tipoDocumento(){
            grvTipoDocumento.DataSource = dal.getBuscarTipoDocumento(1);
            grvTipoDocumento.DataBind();
        }
        void probabilidadCobro(){
            grvProbabilidadCobro.DataSource = dal.getBuscarProbabilidadCobro(1);
            grvProbabilidadCobro.DataBind();
        }

        void cliente() {
            Mandante man = new Mandante();
            man.Activo = 1;
            ddlClientePorUsuario.DataSource = dal.getBuscarMandante(man);
            ddlClientePorUsuario.DataValueField = "IdMandante";
            ddlClientePorUsuario.DataTextField = "NomMandante";
            ddlClientePorUsuario.DataBind();
        }

        void asignacion() {
            ddlAsignacion.DataSource = dal.getBuscarAsignacion(1, Convert.ToInt32(Session["IdMandante"]));
            ddlAsignacion.DataValueField = "IdAsignacion";
            ddlAsignacion.DataTextField = "NomAsignacion";
            ddlAsignacion.DataBind();
        }

        public List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(';');
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }

        protected void ddlAsignacion_DataBound(object sender, EventArgs e)
        {
            ddlAsignacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        protected void ddlTipoProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoProceso.SelectedValue == "CARGA_DEUDA")
                {
                    trAsignacion.Visible = true;
                }
                else
                {
                    trAsignacion.Visible = false;
                }

                if (ddlTipoProceso.SelectedValue == "CARGA_DEUDA_AL")
                {
                    trTipoCarga.Visible = true;
                    
                }
                else
                {
                    trTipoCarga.Visible = false;
             
                }
            }
            catch (Exception ex)
            {
                divAlerta.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }
        
    }
}