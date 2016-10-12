<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="DeudorIn.aspx.cs" Inherits="Cobros30.DeudorIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h5>
            
          </h5>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Ingreso Deudor</li>
          </ol>
        </section>
        <!--  -->
    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>
        
        <div class="panel panel-primary" id="divSearch" runat="server">
            <div class="panel-heading">
                <strong>Ingreso Deudor</strong>
                
            </div>
                   
                        <div class="row" runat="server" visible="false">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="ddlMandante">Mandante</label>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlMandante" runat="server" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlMandante_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <table class="table table-bordered table-condensed small">
                            <tr class="active">
                                <td>
                                    <label for="ddlMandante">Cod Cliente</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRutDeudor" runat="server" MaxLength="10" CssClass="form-control input-sm"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtnBuscarDeudor" CssClass="btn btn-success btn-sm" Visible="true" runat="server"
                                                OnClick="lbtnBuscarDeudor_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                    
                                </td>
                                <td>
                                    <label for="ddlTipoPersona">Tipo Persona</label>
                                    <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoPersona_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="txtNombres">Nombre o Razón Social</label>
                                    <asp:TextBox ID="txtNombreDeudor" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="txtRutRepresentanteLegal">Rut Rep Legal</label>
                                    <asp:TextBox ID="txtRutRepresentanteLegal" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="txtNombreRepresentanteLegal">Nombre Rep Legal</label>
                                    <asp:TextBox ID="txtNombreRepresentanteLegal" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="active">
                                <td>
                                    <label for="ddlProbCobro">Probabilidad de Cobro</label>
                                    <asp:DropDownList ID="ddlProbCobro" runat="server" CssClass="form-control input-sm" OnDataBound="ddlProbCobro_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="ddlEtapaCobranza">Etapa Cobranza</label>
                                    <asp:DropDownList ID="ddlEtapaCobranza" runat="server" CssClass="form-control input-sm" OnDataBound="ddlEtapaCobranza_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="txtAdic5">Campana Cliente</label>
                                    <asp:TextBox ID="txtCampanaCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <label for="txtAdic5">Condición de Pago</label>
                                    <asp:DropDownList ID="ddlCondicionPago" runat="server" CssClass="form-control input-sm" OnDataBound="ddlCondicionPago_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="ddlSector">Sector</label>
                                    <asp:DropDownList ID="ddlSector" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSector_DataBound">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="active">
                                <td>
                                    <label for="txtFechaIngreso">Fecha Ingreso</label>
                                    <asp:TextBox ID="txtFechaIngreso" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="txtFechaTerminoContrato">Fecha Termino Contrato</label>
                                    <asp:TextBox ID="txtFechaTerminoContrato" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="ddlRenovable">Renovable</label>
                                    <asp:DropDownList ID="ddlRenovable" runat="server" CssClass="form-control input-sm" OnDataBound="ddlRenovable_DataBound">
                                        <asp:ListItem Text="Seleccionar" Value="9999"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="txtResponsableComercial">Responsable Comercial</label>
                                    <asp:TextBox ID="txtResponsableComercial" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="active">
                                <td id="divAdicc1" visible="false" runat="server">
                                    <label for="txtAdic1">
                                    <asp:Label ID="lblAdic1" runat="server" Text="Adic 1"></asp:Label></label>
                                    <asp:TextBox ID="txtAdic1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td id="divAdicc2" visible="false" runat="server">
                                    <label for="txtAdic2">
                                    <asp:Label ID="lblAdic2" runat="server" Text="Adic 2"></asp:Label></label>
                                    <asp:TextBox ID="txtAdic2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td id="divAdicc3" visible="false" runat="server">
                                    <label for="txtAdic3">
                                    <asp:Label ID="lblAdic3" runat="server" Text="Adic 3"></asp:Label></label>
                                    <asp:TextBox ID="txtAdic3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td id="divAdicc4" visible="false" runat="server">
                                    <label for="txtAdic4">
                                    <asp:Label ID="lblAdic4" runat="server" Text="Adic 4"></asp:Label></label>
                                    <asp:TextBox ID="txtAdic4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td id="divAdicc5" visible="false" runat="server">
                                    <label for="txtAdic5">
                                    <asp:Label ID="lblAdic5" runat="server" Text="Adic 5"></asp:Label></label>
                                    <asp:TextBox ID="txtAdic5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="active">
                                <td colspan="5">
                                    <label for="txtObservacion">Observación</label>
                                    <asp:TextBox ID="txtObservacion" TextMode="MultiLine" Height="100px" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                    



            <div class="panel-footer">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-sm btn-success" OnClick="btnGuardar_Click" runat="server" />
                
            </div>

                        <div class="row" id="divArchivos" runat="server" visible="false">
                            <div class="col-md-12">
                            <div class="panel-primary">
                                <div class="panel-heading">
                                    <strong>Archivos deudor</strong>
                                </div>
                                        <table class="table small">
                                            <tr class="active">
                                                <td>
                                                    <strong>Nombre</strong>
                                                    <asp:TextBox ID="txtNombreArchivo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Descripción</strong>
                                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Archivo</strong>
                                                    <asp:FileUpload ID="fuArchivo" runat="server" CssClass="form-control input-sm" />
                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:Button ID="btnGrabarArchivo" runat="server" CssClass="btn btn-danger btn-sm"
                                                        Text="Guardar Archivo" OnClick="btnGrabarArchivo_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                                                        
                            <asp:GridView ID="grvDetalleBiblioteca" HeaderStyle-CssClass="active" runat="server" CssClass="table table-bordered table-hover table-condensed small" AutoGenerateColumns="false" onrowdatabound="grvDetalleBiblioteca_RowDataBound" EmptyDataText="No se encontraron registros asociados">
                                <Columns>
                                    <asp:TemplateField HeaderText="Archivo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgVisualizar" CausesValidation="False" runat="server"  Visible="true" ImageUrl="~/assets/img/file_manager.png"  ToolTip="Seleccionar" OnClick="imgVisualizar_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Visible="false"  Text='<%# Bind("idArchivo") %>'></asp:Label>
                                            <asp:Label ID="lblIdMandante" runat="server" Visible="false"  Text='<%# Bind("IdMandante") %>'></asp:Label>
                                            <asp:Label ID="lblNombre" runat="server"  Text='<%# Bind("NOMBRE") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre archivo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRutaArchivo" runat="server" Visible="true"  Text='<%# Bind("RutaArchivo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Ingreso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuario Ingreso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuario" runat="server"  Text='<%# Bind("LOGIN") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEliminarArchivo" runat="server" ImageUrl="~/assets/img/delete.png" OnClick="imgEliminarArchivo_Click" onclientclick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
            
                                </div>
                            </div>
                        </div>


           
                        <div class="row" id="divDeuda" runat="server" visible="false">
                            <div class="col-md-12">
                            <div class="panel-primary">
                                <div class="panel-heading">
                                    <strong>Ingresar Deuda</strong>
                                    <asp:LinkButton ID="btnDetalleDeuda" OnClick="btnDetalleDeuda_Click" runat="server" CssClass="btn btn-xs btn-info" ToolTip="Detalle Deuda"><span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                </div>

                                    <div id="divAlerta2" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Atención!: </strong>
                                        <asp:Label Text="" ID="lblInformacion" runat="server" />
                                    </div>
                                        <table class="table small">
                                            <tr class="active">
                                                <%--@rut varchar(12),@IdMandante int, @nroDoc varchar(25), @nroCuota int, @idTipoDoc int, 
                                                @fecVenc varchar(20),@fecEmision varchar(20),@fecProtesto varchar(20),@monto decimal, @montoProtesto decimal,
                                                @nroCliente varchar(25),@sucursal varchar(40),@centroCosto varchar(40),@rutSubCliente varchar(12),@nombreSubCliente varchar(80),
                                                @observacion varchar(50),@adic1 varchar(50),@adic2 varchar(50),@adic3 varchar(50),@adic4 varchar(50),@adic5 varchar(50),
                                                @adic6 varchar(50),@adic7 varchar(50),@adic8 varchar(50),@adic9 varchar(50),@adic10 varchar(50),@idUsuario int,@idTipoCarga int,
                                                @idAsignacion int--%>
                                                <td>
                                                    <strong>Nº Documento</strong>
                                                    <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Nº Cuota</strong>
                                                    <asp:TextBox ID="txtNroCuota" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Tipo Documento</strong>
                                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoDocumento_DataBound" ></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <strong>Asignación</strong>
                                                    <asp:DropDownList ID="ddlAsignacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlAsignacion_DataBound"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <strong>Fec Venc</strong>
                                                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Fec Emision</strong>
                                                    <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Fec Protesto</strong>
                                                    <asp:TextBox ID="txtFechaProtesto" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Saldo Cap</strong>
                                                    <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Monto Protesto</strong>
                                                    <asp:TextBox ID="txtMontoProtesto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Nº Cliente</strong>
                                                    <asp:TextBox ID="txtNroCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="active">
                                                <td>
                                                    <strong>Sucursal</strong>
                                                    <asp:TextBox ID="txtSucursal" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Centro Costo</strong>
                                                    <asp:TextBox ID="txtCentroCosto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    <strong>Rut Sub Cliente</strong>
                                                    <asp:TextBox ID="txtRutSubCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    <strong>Nombre Sub Cliente</strong>
                                                    <asp:TextBox ID="txtNombreSubCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr class="active">
                                                <td>
                                                    <strong>Adicional 1</strong>
                                                    <asp:TextBox ID="txtAdicional1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 2</strong>
                                                    <asp:TextBox ID="txtAdicional2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 3</strong>
                                                    <asp:TextBox ID="txtAdicional3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 4</strong>
                                                    <asp:TextBox ID="txtAdicional4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 5</strong>
                                                    <asp:TextBox ID="txtAdicional5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 6</strong>
                                                    <asp:TextBox ID="txtAdicional6" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 7</strong>
                                                    <asp:TextBox ID="txtAdicional7" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 8</strong>
                                                    <asp:TextBox ID="txtAdicional8" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 9</strong>
                                                    <asp:TextBox ID="txtAdicional9" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Adicional 10</strong>
                                                    <asp:TextBox ID="txtAdicional10" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="10">
                                                    <strong>Observacion</strong>
                                                    <asp:TextBox ID="txtObservacionDeuda" Height="100px" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                <div class="panel-footer">
                                    <asp:LinkButton ID="lbtnNuevaDeuda" OnClick="lbtnNuevaDeuda_Click" runat="server" Visible="false" CssClass="btn btn-sm btn-google" ToolTip="Nueva Deuda">Nueva Deuda <span class="glyphicon glyphicon-floppy-disk" ></span></asp:LinkButton>
                                </div>

                                </div>
                            </div>
                        </div>






            

            <asp:Panel ID="Panel1" runat="server" CssClass="modal fade bs-example-modal-lg " TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-lg panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <%--<div class="modal-header">
                                    <h4 class="modal-title" id=" myLabel ">Observación del Ticket</h4>
                                </div>
                                <div class="modal-body">
                                    kkkkkkkkkkkkkkkkkkk
                                </div>--%>

                                <div class="panel-info">
                                    <div class="panel-heading">Detalle Deuda</div>
                                    <div class="table-responsive">
                                        <asp:GridView ID="grvDetalleDeuda" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdGestion" runat="server" Visible="true" Text='<%# Bind("IdDeuda") %>'></asp:Label>
                                                        <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cod Cliente">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRut" runat="server" Visible="true" Text='<%# Bind("RutDeudor") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Nro Doc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNroDocumento" runat="server" Visible="true" Text='<%# Bind("NroDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fec Venc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaVencimiento" runat="server" Text='<%# Bind("FechaVencimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Antig">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAntiguedad" runat="server" Text='<%# Bind("ANTIG") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Fec Protes">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaProtesto" runat="server" Text='<%# Bind("FechaProtesto", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Tipo Doc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text='<%# Bind("NomTipoDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Asig">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdAsignacion" runat="server" Text='<%# Bind("IdAsignacion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Capital">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCapital" runat="server" Text='<%# Bind("DeudaOriginal","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Interes">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInteres" runat="server" Text='<%# Bind("Interes","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>--%>
                                                <%--<asp:TemplateField HeaderText="Honorarios">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHonorarios" runat="server" Text='<%# Bind("Honorarios","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>--%>

<%--                                                <asp:TemplateField HeaderText="Protesto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMontoProtesto" runat="server" Text='<%# Bind("MontoProtesto","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Saldo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Estado">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEstadoDeuda" runat="server" Text='<%# Bind("NomEstadoDeuda") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fec Estado">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaEstado" runat="server" Text='<%# Bind("FechaEstado", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>


        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
    <script src="assets/template/AdminLTE-2.3.0/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script type="text/javascript">
      
        $(document).ready(function () {
            cargar();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            cargar();
        });

        function cargar() {
            //agregar jquery de las funciones...
            var dp = $(".class-date");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                format: "dd-mm-yyyy",
                language: "es",
                // Primer dia de la semana El lunes
                firstDay: 1,
                // Dias Largo en castellano
                dayNames: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"],
                // Dias cortos en castellano
                dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                // Nombres largos de los meses en castellano
                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                // Nombres de los meses en formato corto 
                monthNamesShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec"]
            });
        }
    </script>
</asp:Content>
