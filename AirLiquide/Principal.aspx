<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Cobros30.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Principal
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Gestión</a></li>
            <li class="active">Principal</li>
          </ol>
        </section>
     <!--  -->

    <section class="content">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                        <!-- Alertas -->
                <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
                    <strong>Atención!: </strong>
                    <asp:Label Text="" ID="lblInfo" runat="server" />
                </div>

                <asp:Panel ID="pnlPrincipal" runat="server" DefaultButton="btnBuscar">


                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <div class="form-inline">

                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <input runat="server" type="text" style="width:100px;" class="form-control input-sm" id="txtRutDeudor" placeholder="Código Cliente" />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" CssClass="btn btn-sm btn-success"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                        </span>
                                                    </div>
                                                    <asp:LinkButton ID="btnLimpiar" Visible="false" OnClick="btnLimpiar_Click" runat="server" ToolTip="Limpiar" CssClass="btn btn-sm btn-default"> <span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                                </div>
                                                
                                            </div>
                                        </div>
                                        <div class="col-sm-8">
                                            <asp:Label ID="lblNombreDeudor" runat="server" CssClass="lead"></asp:Label>
                                        </div>
                                        <%--<div class="col-sm-2">
                                        <div class="form-inline">
                                        </div>
                                    </div>--%>
                                        <div class="col-sm-2 pull-right">
                                            <div class="pull-right">
                                                <asp:LinkButton ID="btnPagoEnCliente" OnClick="btnPagoEnCliente_Click" Visible="false" runat="server" CssClass="btn btn-sm btn-adn">Pago <span class="glyphicon glyphicon-user"></span></asp:LinkButton>
                                                <asp:LinkButton ID="btnBiblioteca" OnClick="btnBiblioteca_Click" runat="server" CssClass="btn btn-sm btn-dropbox">Biblioteca<span class="glyphicon glyphicon-book"></span></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnCarteraAsignada" OnClick="lbtnCarteraAsignada_Click" Visible="false" runat="server" CssClass="btn btn-sm btn-bitbucket">Cartera Asignada<span class="glyphicon glyphicon-align-justify"></span></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnIrDeudor" OnClick="lbtnIrDeudor_Click" runat="server" ToolTip="Ir a Deudor" CssClass="btn btn-sm btn-success"> <span class="glyphicon glyphicon-user"></span></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- Aqui -->
                                <div id="divContenido" runat="server" visible="false">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-condensed table-hover small">
                                            <tr class="active">
                                                <td>
                                                    <strong>Rut</strong>
                                                    <asp:Label ID="lblRutDeudor" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblRutDeudor2" runat="server" Visible="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Nombre</strong>
                                                    <asp:Label ID="lblNombreDeudor2" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Condición de Pago:</strong>
                                                    <asp:Label ID="lblCondicionPago" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Sector:</strong>
                                                    <asp:Label ID="lblSector" runat="server"></asp:Label>
                                                </td>
                                                
                                                <%--<td>
                                            <strong>Campaña Cliente:</strong>
                                            <asp:Label ID="lblCampanaCliente" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <strong>Usuario Asignado:</strong>
                                            <asp:Label ID="lblUsuarioAsignado" runat="server"></asp:Label>
                                        </td>--%>
                                            </tr>
                                            <%--<tr class="active" id="trAdicionales" runat="server" visible="true">
                                                <td id="divAdic1" runat="server">
                                                    <strong>
                                                        <asp:Label ID="lblAdic1" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lblAdic1Deudor" runat="server"></asp:Label>
                                                </td>
                                                <td id="divAdic2" runat="server">
                                                    <strong>
                                                        <asp:Label ID="lblAdic2" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lblAdic2Deudor" runat="server"></asp:Label>
                                                </td>
                                                <td id="divAdic3" runat="server">
                                                    <strong>
                                                        <asp:Label ID="lblAdic3" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lblAdic3Deudor" runat="server"></asp:Label>
                                                </td>
                                                <td id="divAdic4" runat="server">
                                                    <strong>
                                                        <asp:Label ID="lblAdic4" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lblAdic4Deudor" runat="server"></asp:Label>
                                                </td>
                                                <td id="divAdic5" runat="server">
                                                    <strong>
                                                        <asp:Label ID="lblAdic5" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lblAdic5Deudor" runat="server"></asp:Label>
                                                </td>
                                            </tr>--%>

                                            <tr>
                                                <td>
                                                    <strong>Fecha Ingreso:</strong>
                                                    <asp:Label ID="lblFechaIngresoDeudor" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Fecha Termino Contrato:</strong>
                                                    <asp:Label ID="lblFechaTerminoContrato" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Renovable</strong>
                                                    <asp:Label ID="lblRenovable" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <strong>Responsable Comercial</strong>
                                                    <asp:Label ID="lblResponsableComercial" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFlagDeudaCastigada" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlagQuiebra" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlagJudicial" runat="server"></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>

                                    </div>


                                    <%--          <div class="panel ">--%>
                                    <div class="panel-primary" id="divDetalleDeuda" runat="server" visible="false">
                                        <div class="panel-prumary panel-heading">Información Deudas</div>

                                        <%--  </div>--%>
                                        <asp:GridView ID="grvDeudasDeudor" runat="server" CssClass="table table-responsive table-hover table-condensed table-bordered table-striped small"
                                            HeaderStyle-CssClass="active" OnRowDataBound="grvDeudasDeudor_RowDataBound" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Mandante" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdMandante" runat="server" Text='<%# Bind("IdMandante") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblIdSucursal" runat="server" Text='<%# Bind("IdSucursal") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="NomSucursal" HeaderText="Sucursal" />
                                                <asp:TemplateField HeaderText="Fec.Venc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaVencimientoMin" runat="server" Text='<%# Bind("fechaVencimientoMin", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                        
                                                <asp:TemplateField HeaderText="Mora">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAntiguedad" runat="server" Text='<%# Bind("Antiguedad","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Capital" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCapital" runat="server" Text='<%# Bind("Capital","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Saldo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Docs">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalDocs" runat="server" Text='<%# Bind("C_DOC","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDetalleDeuda" OnClick="btnDetalleDeuda_Click" runat="server" CssClass="btn btn-xs btn-primary" ToolTip="Detalle Deuda"><span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="btnDetalleDeudaTotal" OnClick="btnDetalleDeudaTotal_Click" runat="server" CssClass="btn btn-xs btn-primary" ToolTip="Detalle Deuda"><span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>




                                    <div class="panel-primary">
                                        <div class="panel-prumary panel-heading">
                                            Información de Pagos
                                        </div>

                                        <asp:GridView ID="grvPagos" runat="server" CssClass="table table-responsive table-hover table-condensed table-bordered table-striped small"
                                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" OnRowDataBound="grvPagos_RowDataBound" ShowHeaderWhenEmpty="true" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sucursal" Visible="true" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdSucursal" runat="server" Text='<%# Bind("COD_SUCURSAL") %>' Visible="false"></asp:Label>

                                                        <asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Bind("NOMSUCURSAL") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Cant Doc" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCantidadDocumentos" runat="server" Text='<%# Bind("CANT_DOC","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pagos" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPagos" runat="server" Text='<%# Bind("PAGOS","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="70%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDetallePagos" OnClick="btnDetallePagos_Click" runat="server" CssClass="btn btn-xs btn-primary" ToolTip="Detalle Pagos"><span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="btnDetallePagosTotal" OnClick="btnDetallePagosTotal_Click" runat="server" CssClass="btn btn-xs btn-primary" ToolTip="Detalle Deuda"><span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>


                                    <div class="panel-primary">
                                        <div class="panel-prumary panel-heading">
                                            <div class="row">
                                                <div class="col-lg-8">
                                                    Ultima Gestión
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="pull-right">
                                                        <asp:LinkButton ID="lbtnHistorialGestiones" OnClick="lbtnHistorialGestiones_Click" runat="server" CssClass="btn btn-xs btn-google" ToolTip="Nueva Gestión">Historial de Gestiones <span class="glyphicon glyphicon-th-list" ></span></asp:LinkButton>
                                                        <asp:LinkButton ID="lbtnNuevaGestion" OnClick="lbtnNuevaGestion_Click" runat="server" CssClass="btn btn-xs btn-google" ToolTip="Nueva Gestión">Nueva Gestión <span class="glyphicon glyphicon-pencil" ></span></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <table class="table table-condensed table-hover small">
                                            <tr class="active">
                                                <td>Fecha</td>
                                                <td>Hora</td>
                                                <td>Gestión</td>
                                                <td>F.Comprom.</td>
                                                <td>F.Agend.</td>
                                                <td>Observaciones</td>
                                                <td>Fono</td>
                                                <td>Ejecutivo</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFechaUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblHoraUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGestionUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFechaCompromisoUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFechaAgendamientoUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblObservacionUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFonoUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEjecutivoUltimaGestion" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>


                                    <div class="panel-primary">
                                        <div class="panel-primary panel-heading">Datos del Contacto</div>
                                        <table class="table table-condensed small">
                                            <tr class="active">
                                                <td>
                                                    <strong>Teléfono</strong>
                                                </td>
                                                <td>
                                                    <strong>Email</strong>
                                                </td>
                                                <td>
                                                    <strong>Dirección</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUltimoTelefonoDeudor" runat="server"></asp:Label>
                                                    <asp:ImageButton ID="ibtnAgregarTelefonoDeudor" ToolTip="Ingresar nuevo teléfono" runat="server" ImageUrl="~/assets/img/phone_add.png" OnClick="ibtnAgregarTelefonoDeudor_Click" />
                                                    <asp:ImageButton ID="ibtnListarTelefonoDeudor" ToolTip="Ver teléfonos ingresados" runat="server" ImageUrl="~/assets/img/phone.png" OnClick="ibtnListarTelefonoDeudor_Click" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUltimoEmailDeudor" runat="server"></asp:Label>
                                                    <asp:ImageButton ID="ibtnAgregarEmailDeudor" ToolTip="Ingresar nuevo email" runat="server" ImageUrl="~/assets/img/email_add.png" OnClick="ibtnAgregarEmailDeudor_Click" />
                                                    <asp:ImageButton ID="ibtnListarrEmailDeudor" ToolTip="Ver email ingresados" runat="server" ImageUrl="~/assets/img/email.png" OnClick="ibtnListarrEmailDeudor_Click" />
                                                    <asp:ImageButton ID="ibtnEnviarEmailDeudor" ToolTip="Enviar email" Visible="false" runat="server" ImageUrl="~/assets/img/email_go.png" OnClick="ibtnEnviarEmailDeudor_Click" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUltimoDireccionDeudor" runat="server"></asp:Label>
                                                    <asp:ImageButton ID="ibtnAgregarDireccionDeudor" ToolTip="Ingresar nueva dirección" runat="server" ImageUrl="~/assets/img/house_go.png" OnClick="ibtnAgregarDireccionDeudor_Click" />
                                                    <asp:ImageButton ID="ibtnListarrDireccionDeudor" ToolTip="Ver direcciones ingresadas" runat="server" ImageUrl="~/assets/img/house.png" OnClick="ibtnListarrDireccionDeudor_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>





            <asp:Panel ID="Panel1" runat="server" CssClass="modal fade bs-example-modal-lg " TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-lg panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-info">
                                    <div class="panel-heading">Detalle Deuda

                                        <div class="pull-right">
                                            <asp:LinkButton ID="btnExcelDetalleDeuda" Text="text" OnClick="btnExcelDetalleDeuda_Click" CssClass="btn btn-xs" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="table-responsive">
                                        <asp:GridView ID="grvDetalleDeuda" runat="server" CssClass="table table-bordered table-hover table-condensed small" OnRowDataBound="grvDetalleDeuda_RowDataBound" HeaderStyle-CssClass="active" AutoGenerateColumns="false" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdDeuda" runat="server" Visible="true" Text='<%# Bind("IdDeuda") %>'></asp:Label>
                                                        <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Sucursal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSucursal" runat="server" Text='<%# Bind("NomSucursal") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Tipo Doc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text='<%# Bind("NomTipoDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Nro Doc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNroDocumento" runat="server" Visible="true" Text='<%# Bind("NroDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                
                                                <asp:TemplateField HeaderText="Fec Emisión">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaEmision" runat="server" Text='<%# Bind("FechaEmision", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fec Venc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaVencimiento" runat="server" Text='<%# Bind("FechaVencimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mora">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAntiguedad" runat="server" Text='<%# Bind("ANTIG") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Capital" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCapital" runat="server" Text='<%# Bind("DeudaOriginal","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Saldo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo","{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Estado">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEstadoDeuda" runat="server" ToolTip='<%# Bind("ObsEstadoDeuda2") %>' Text='<%# Bind("NomEstadoDeuda") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tipo Deuda">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipoDeuda" runat="server" Text='<%# Bind("TipoDeuda") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnEditarDeuda" CssClass="btn btn-success btn-xs" runat="server" ToolTip="Editar Estado Deuda"
                                                        OnClick="lbtnEditarDeuda_Click" OnClientClick="aspnetForm.target ='_blank';"><i aria-hidden="true"  class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fec Estado" Visible="false">
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



                
            <asp:Panel ID="Panel2" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-lg panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <%--<div class="modal-header">
                                    <h4 class="modal-title" id=" myLabel ">Observación del Ticket</h4>
                                </div>
                                <div class="modal-body">
                                    kkkkkkkkkkkkkkkkkkk
                                </div>--%>

                                <div class="panel-info">
                                    <div class="panel-heading">Datos adicionales documento</div>
                                    
                                    <asp:GridView ID="grvDetalleDeudaAdicionales" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
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
                                                        <asp:Label ID="lblNroDoc" runat="server" Visible="true" Text='<%# Bind("NroDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic1" runat="server" Visible="true" Text='<%# Bind("Adic1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic2" runat="server" Visible="true" Text='<%# Bind("Adic2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic3" runat="server" Visible="true" Text='<%# Bind("Adic3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic4" runat="server" Visible="true" Text='<%# Bind("Adic4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 5">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic5" runat="server" Visible="true" Text='<%# Bind("Adic5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 6">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic6" runat="server" Visible="true" Text='<%# Bind("Adic6") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 7">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic7" runat="server" Visible="true" Text='<%# Bind("Adic7") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 8">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic8" runat="server" Visible="true" Text='<%# Bind("Adic8") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 9">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic9" runat="server" Visible="true" Text='<%# Bind("Adic9") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adic 10">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdic10" runat="server" Visible="true" Text='<%# Bind("Adic10") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                        </asp:GridView>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>




                
                
            <asp:Panel ID="Panel3" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-info">
                                    <div class="panel-heading">Agregar teléfono</div>
                                    <div class="table-responsive">
                                        <table class="table table-condensed small">
                                            <tr>
                                                <td runat="server" visible="false"><strong>Código Área</strong></td>
                                                <td><strong>Teléfono</strong></td>
                                                <td runat="server" visible="false"><strong>Origen</strong></td>
                                                <td><strong>Contacto</strong></td>
                                                <td><strong>Cargo</strong></td>
                                                <td><strong>Tipo Telefono</strong></td>
                                                <td runat="server" visible="false"><strong>Usuario</strong></td>
                                            </tr>
                                            <tr>
                                                <td runat="server" visible="false">
                                                    <asp:DropDownList ID="ddlCodigoArea" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                        <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                        <asp:ListItem Value="32" Text="32"></asp:ListItem>
                                                        <asp:ListItem Value="33" Text="33"></asp:ListItem>
                                                        <asp:ListItem Value="34" Text="34"></asp:ListItem>
                                                        <asp:ListItem Value="35" Text="35"></asp:ListItem>
                                                        <asp:ListItem Value="41" Text="41"></asp:ListItem>
                                                        <asp:ListItem Value="42" Text="42"></asp:ListItem>
                                                        <asp:ListItem Value="43" Text="43"></asp:ListItem>
                                                        <asp:ListItem Value="44" Text="44"></asp:ListItem>
                                                        <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                        <asp:ListItem Value="51" Text="51"></asp:ListItem>
                                                        <asp:ListItem Value="52" Text="52"></asp:ListItem>
                                                        <asp:ListItem Value="53" Text="53"></asp:ListItem>
                                                        <asp:ListItem Value="55" Text="55"></asp:ListItem>
                                                        <asp:ListItem Value="57" Text="57"></asp:ListItem>
                                                        <asp:ListItem Value="58" Text="58"></asp:ListItem>
                                                        <asp:ListItem Value="61" Text="61"></asp:ListItem>
                                                        <asp:ListItem Value="63" Text="63"></asp:ListItem>
                                                        <asp:ListItem Value="64" Text="64"></asp:ListItem>
                                                        <asp:ListItem Value="65" Text="65"></asp:ListItem>
                                                        <asp:ListItem Value="67" Text="67"></asp:ListItem>
                                                        <asp:ListItem Value="71" Text="71"></asp:ListItem>
                                                        <asp:ListItem Value="72" Text="72"></asp:ListItem>
                                                        <asp:ListItem Value="73" Text="73"></asp:ListItem>
                                                        <asp:ListItem Value="75" Text="75"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTelefono" runat="server" MaxLength="9" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td runat="server" visible="false">
                                                    <asp:DropDownList ID="ddlProveedorUbicTelefono" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNombreContactoTelefono" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCargoContactoTelefono" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipoTelefono" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="COBRANZA"></asp:ListItem>
                                                        <asp:ListItem Value="GENERAL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td runat="server" visible="false">
                                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>

                                        <div class="panel-footer">
                                            <asp:Button ID="btnAgregarTelefono" runat="server" Text="Guardar" CssClass="btn btn-danger btn-sm"  OnClick="btnAgregarTelefono_Click" />
                                        </div>

                                    </div>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>






                
            <asp:Panel ID="Panel4" runat="server" CssClass="modal fade bs-example-modal-lg " TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Auditar teléfonos</strong>
                                    </div>

                                    <asp:GridView ID="grvTelefonos" runat="server" HeaderStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small" AutoGenerateColumns="false" EmptyDataText="No se encontraron teléfonos asociados al Cod Cliente" EmptyDataRowStyle-CssClass="alert alert-danger" OnRowDataBound="paginacion_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdTelefono" runat="server" Visible="true" Text='<%# Bind("IdTelefono") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cod Area" ItemStyle-Width="7%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodArea" runat="server" Text='<%# Bind("IdArea") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Teléfono" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Ingreso">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FECHAINGRESO", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Proveedor" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProveedor" runat="server" Text='<%# Bind("NOMPROVEEDORUBIC") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Contacto">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNombreContactoTelefono" runat="server" MaxLength="50" Text='<%# Bind("NombreContacto") %>' CssClass="form-control input-sm"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tipo Telefono">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdTipoTelefono" runat="server" Text='<%# Bind("TipoTelefono") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlTipoTelefono" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="COBRANZA"></asp:ListItem>
                                                        <asp:ListItem Value="GENERAL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdEstado" runat="server" Visible="false" Text='<%# Bind("IDESTADOUbic") %>'></asp:Label>
                                                    <asp:RadioButtonList ID="rbtnEstado" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="VA" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="NV" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="SA" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    
                                    <div class="panel-footer">
                                        <asp:LinkButton ID="lbtnGrabarEstados" CssClass="btn btn-danger btn-sm" runat="server"
                                            OnClick="lbtnGrabarEstados_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Grabar</asp:LinkButton>
                                    </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>


                
            <asp:Panel ID="Panel5" runat="server" CssClass="modal fade bs-example-modal-lg " TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Agregar Dirección</strong>
                                    </div>
                                    
                                    <table class="table table-condensed small">
                                        <tr>
                                            <td><strong>Calle</strong></td>
                                            <td><strong>Número</strong></td>
                                            <td><strong>Resto</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumero" MaxLength="6" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResto" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Comuna</strong>
                                            </td>
                                            <td runat="server" visible="false"><strong>Origen</strong></td>
                                            <td><strong>Usuario</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlComunaDireccion" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                            <td runat="server" visible="false">
                                                <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUsuarioDireccion" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Contacto</strong>
                                            </td>
                                            <td>
                                                <strong>Cargo</strong>
                                            </td>
                                            <td></td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtNomContactoDireccion" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCargoContactoDireccion" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        
                                    </table>

                                        <div class="panel-footer">
                                            <asp:Button ID="btnGrabarDireccion" runat="server" Text="Guardar" CssClass="btn btn-danger btn-sm" onclick="btnGrabarDireccion_Click" />
                                        </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>





            
            <asp:Panel ID="Panel6" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Auditar Direcciones</strong>
                                    </div>
                                    
                                    <asp:GridView ID="grvDirecciones" runat="server" HeaderStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small" AutoGenerateColumns="false" EmptyDataText="No se encontraron direcciones asociados al Cod Cliente" EmptyDataRowStyle-CssClass="alert alert-danger" OnRowDataBound="paginacion2_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Calle">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdDireccion" runat="server" Visible="false" Text='<%# Bind("IDDIRECCION") %>'></asp:Label>
                                                    <asp:Label ID="lblCalle" runat="server" Text='<%# Bind("CALLE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Número" ItemStyle-Width="7%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumero" runat="server" Text='<%# Bind("NUMERO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Resto">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResto" runat="server" Text='<%# Bind("RESTO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comuna">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComuna" runat="server" Text='<%# Bind("COMUNA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Ingreso">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FECHAINGRESO", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Origen" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProveedor" runat="server" Text='<%# Bind("NOMPROVEEDORUBIC") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdEstado" runat="server" Visible="false" Text='<%# Bind("IDESTADOubic") %>'></asp:Label>
                                                    <asp:RadioButtonList ID="rbtnEstado" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="VA" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="NV" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="SA" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <div class="panel-footer">
                                        <asp:LinkButton ID="lbtnGrabarDireccionesEstados" CssClass="btn btn-danger btn-sm" runat="server"
                                            OnClick="lbtnGrabarDireccionesEstados_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Grabar</asp:LinkButton>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>





                
                
            <asp:Panel ID="Panel7" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Ingresar 

                                        </strong>
                                    </div>

                                    <table class="table table-condensed small">
                                        <tr>
                                            <td><strong>Correo</strong></td>
                                            <td><strong>Usuario</strong></td>
                                            <td runat="server" visible="false"><strong>Origen</strong></td>
                                            <td><strong>Contacto</strong></td>
                                            <td><strong>Cargo</strong></td>
                                            <td><strong>Tipo Email</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control input-sm" Width="300px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUsuarioEmail" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td runat="server" visible="false">
                                                <asp:DropDownList ID="ddlOrigenEmail" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                    <asp:TextBox ID="txtNombreContactoEmail" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            <td>
                                                    <asp:TextBox ID="txtCargoContactoEmail" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipoEmail" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="COBRANZA"></asp:ListItem>
                                                        <asp:ListItem Value="GENERAL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                        </tr>
                                    </table>

                                    <div class="panel-footer">
                                        <asp:Button ID="btnGrabarEmail" runat="server" Text="Guardar" CssClass="btn btn-danger btn-sm" OnClick="btnGrabarEmail_Click" />
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>

                
                
            <asp:Panel ID="Panel8" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Auditar Email</strong>
                                    </div>
                                    
                                    <asp:GridView ID="grvEmail" runat="server" HeaderStyle-CssClass="active" 
                                        CssClass="table table-bordered table-hover table-condensed table small" AutoGenerateColumns="false" 
                                        EmptyDataText="No se encontraron email asociados al Cod Cliente" 
                                        EmptyDataRowStyle-CssClass="alert alert-danger" OnRowDataBound="paginacion3_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Correo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdEmail" runat="server" Visible="false" Text='<%# Bind("IdEmail") %>'></asp:Label>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Ingreso">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FECHAINGRESO", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Origen" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProveedor" runat="server" Text='<%# Bind("NOMPROVEEDORUBIC") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Contacto" Visible="true">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNombreContactoEmail" runat="server" MaxLength="50" Text='<%# Bind("NombreContacto") %>' CssClass="form-control input-sm"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tipo Email" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdTipoEmail" runat="server" Visible="false" Text='<%# Bind("TipoEmail") %>'></asp:Label>
                                                    <asp:DropDownList ID="ddlTipoEmail" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="COBRANZA"></asp:ListItem>
                                                        <asp:ListItem Value="GENERAL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdEstado" runat="server" Visible="false" Text='<%# Bind("IDESTADOubic") %>'></asp:Label>
                                                    <asp:RadioButtonList ID="rbtnEstado" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="VA" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="NV" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="SA" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="panel-footer">
                                        <asp:LinkButton ID="lbtnGrabarEmailEstados" CssClass="btn btn-danger btn-sm" runat="server"
                                            OnClick="lbtnGrabarEmailEstados_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Grabar</asp:LinkButton>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
            


            <asp:Panel ID="Panel9" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-lg modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Historial Gestiones</strong>
                                    </div>

                                    <asp:GridView ID="grvHistorialGestiones" runat="server" HeaderStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small" AutoGenerateColumns="false" EmptyDataText="No se encontraron email asociados al Cod Cliente" EmptyDataRowStyle-CssClass="alert alert-danger" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id Gestión">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdGestion" runat="server" Visible="true" Text='<%# Bind("IdGestion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FECHAINGRESO", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Hora">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHora" runat="server" Text='<%# Bind("HoraIngreso") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="F.Comprom.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaCompromiso" runat="server" Text='<%# Bind("FechaCompromiso", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="F.Agend.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaAgendamiento" runat="server" Text='<%# Bind("FechaAgendamiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fono">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Gestión">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGestion" runat="server" Text='<%# Bind("Gestion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Observaciones">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ejecutivo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEjecutivo" runat="server" Text='<%# Bind("Login") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                   

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>



                <asp:Panel ID="Panel10" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-lg modal-open panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-primary">
                                    <div class="panel-heading">
                                        <button class="close" data-dismiss="modal">
                                            ×
                                        </button>
                                        <strong>Otras Deudas</strong>
                                    </div>

                                    <asp:GridView ID="grvOtrasDeudas" runat="server" HeaderStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small" AutoGenerateColumns="false" EmptyDataText="No se encontraron deudas asociados al Cod Cliente" EmptyDataRowStyle-CssClass="alert alert-danger" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Mandante">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                                    <asp:Label ID="lblNombreMandante" runat="server" Visible="true" Text='<%# Bind("NomMandante") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saldo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo","{0:n0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right"/>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                   

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>









                <asp:Panel ID="Panel11" runat="server" CssClass="modal fade bs-example-modal-lg" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                    <div class="modal-dialog modal-lg modal-open panel" role="document">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="panel-primary">
                                        <div class="panel-heading">
                                            <button class="close" data-dismiss="modal">
                                                ×
                                            </button>
                                            <strong>Detalle Pagos</strong>
                                            <div class="pull-right">
                                                <asp:LinkButton ID="lbtnExcelDetallePago" Text="text" OnClick="lbtnExcelDetallePago_Click" CssClass="btn btn-xs" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                        <asp:GridView ID="grvDetallePagos" runat="server" HeaderStyle-CssClass="active" 
                                            CssClass="table table-bordered table-hover table-condensed table small" 
                                            AutoGenerateColumns="false" EmptyDataText="No se encontraron deudas asociados al Cod Cliente" 
                                            EmptyDataRowStyle-CssClass="alert alert-danger" OnRowDataBound="grvDetallePagos_RowDataBound" ShowHeaderWhenEmpty="true" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sucursal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Bind("NomSucursal") %>' Visible="true"></asp:Label>
                                                        <asp:Label ID="lblIdSucursal" runat="server" Text='<%# Bind("IdSucursal") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Cod Cliente">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCodCliente" runat="server" Text='<%# Bind("Cod_Cliente") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Nombre Cliente">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombreCliente" runat="server" Text='<%# Bind("Nombre_Cliente") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tipo Documento">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text='<%# Bind("NomTipoDocumento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Documento">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDocumento" runat="server" Text='<%# Bind("Documento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                            
                                                <asp:TemplateField HeaderText="Fecha Emisión">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaEmision" runat="server" Text='<%# Bind("Fecha_Emision", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fecha Vencimiento">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaVencimiento" runat="server" Text='<%# Bind("Fecha_Vencimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Monto Doc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMontoTitulo" runat="server" Text='<%# Bind("Monto_Titulo", "{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                            
                                                <asp:TemplateField HeaderText="Referencia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReferencia" runat="server" Text='<%# Bind("Referencia") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                            
                                                <asp:TemplateField HeaderText="Fecha Pago">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaReferencia" runat="server" Text='<%# Bind("Fecha_Referencia", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Valor Baja">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblValorBaja" runat="server" Text='<%# Bind("Valor_Baja", "{0:n0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                            
                                                <asp:TemplateField HeaderText="Portador">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPortador" runat="server" Text='<%# Bind("NomPortador") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </asp:Panel>







            </ContentTemplate>
        </asp:UpdatePanel>

    </section>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="assets/template/AdminLTE-2.3.0/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script src="assets/template/AdminLTE-2.3.0/plugins/select2/select2.full.min.js"></script>

    <script type="text/javascript">
    function fixform() {
        if (opener.document.getElementById("aspnetForm").target != "_blank") return;
        opener.document.getElementById("aspnetForm").target = "";
        opener.document.getElementById("aspnetForm").action = opener.location.href;
    }
</script>

</asp:Content>
