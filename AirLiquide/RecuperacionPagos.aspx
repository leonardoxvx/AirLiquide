<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="RecuperacionPagos.aspx.cs" Inherits="Cobros30.RecuperacionPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" rel="stylesheet" />
   <%-- <link href="assets/pace/dataurl.css" rel="stylesheet" />--%>
<%--    <script src="assets/pace/pace.min.js"></script>--%>
    <%--<script data-pace-options='{ "ajax": true }' src='assets/pace/pace.min.js'></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //prm.add_initializeRequest(InitializeRequest);
            //prm.add_endRequest(EndRequest);

            paceOptions = {
                ajax: false, // Monitors all ajax requests on the page
                document: false, // Checks for the existance of specific elements on the page
                eventLag: false, // Checks the document readyState
                startOnPageLoad: false,
                elements: {
                    selectors: ['.my-page'] // Checks for event loop lag signaling that javascript is being executed
                }
            };
        });
        //function InitializeRequest(sender, args) {
        //    Pace.start();
        //}

        //function EndRequest(sender, args) {
        //    Pace.stop();
        //};
     </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Informe de Pagos
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Informe de Pagos</li>
          </ol>
        </section>
        <!--  -->

    <section class="content">

        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">Informe de Pagos
                        <div class="pull-right">
                            <asp:LinkButton ID="lbtnVerSucursales" CssClass="btn btn-success btn-xs" runat="server" ToolTip="Ver Sucursal"
                            OnClick="lbtnVerSucursales_Click"><i aria-hidden="true" class="glyphicon glyphicon-modal-window"></i></asp:LinkButton>
                        </div>
                    </div>
                    <table class="table">
                        <tr>
                            <td>
                                <strong>Cod Cliente</strong>
                                <asp:TextBox ID="txtCodCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td>
                                <strong>Referencia</strong>
                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td>
                                <strong>Tipo Documento</strong>
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoDocumento_DataBound">
                                </asp:DropDownList>
                            </td>
                            <td><strong>Sucursal</strong>
                                <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                </asp:DropDownList>
                            </td>
                            <td><strong>Ejecutivo</strong>
                                <asp:DropDownList ID="ddlEjecutivo" runat="server" CssClass="form-control input-sm" OnDataBound="ddlEjecutivo_DataBound">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>Fecha desde</strong>
                                <asp:TextBox ID="txtFechaDesde" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                            </td>
                            <td>
                                <strong>Fecha hasta</strong>
                                <asp:TextBox ID="txtFechaHasta" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                            </td>
                            <td>
                                <br />
                                <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm" Visible="false" runat="server" OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i> Buscar</asp:LinkButton>
                                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-sm" Text="Buscar" OnClick="lbtnBuscar_Click" />
                            </td>
                            <td>
                                <br />
                                <asp:LinkButton ID="lbtnBuscarExcel" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lbtnBuscarExcel_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                
                            </td>
                        </tr>
                    </table>



                    
                    <asp:GridView ID="grvRecupacionPagos"  EmptyDataText="Selección realizada no obtuvo registros" ClientIDMode="Static" EmptyDataRowStyle-CssClass="danger" runat="server" 
                        HeaderStyle-CssClass="info" PagerStyle-CssClass="active" 
                        CssClass="table table-bordered table-hover table-condensed table small panel table-responsive" 
                        AutoGenerateColumns="false" OnRowDataBound="grvRecupacionPagos_RowDataBound"  ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Sucursal">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Bind("NomSucursal") %>' Visible="true"></asp:Label>
                                    <asp:Label ID="lblIdSucursal" runat="server" Text='<%# Bind("IdSucursal") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="IdTipoDocumento" runat="server" Text='<%# Bind("IdTipoDocumento") %>' Visible="false"></asp:Label>
                                    
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


                
            <asp:Panel ID="Panel1" runat="server" CssClass="modal fade bs-example-modal-lg " TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                <div class="modal-dialog modal-sm panel" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-info">
                                    <div class="panel-heading">Sucursales

                                    </div>
                                    <div class="table-responsive">
                                        <asp:GridView ID="grvSucursal" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Cod Sucursal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCodSucursal" runat="server" Visible="true" Text='<%# Bind("COD_SUCURSAL") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sucursal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombreSucursal" runat="server" Visible="true" Text='<%# Bind("NomSucursal") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dias promedio cobro">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDias" runat="server" Text='<%# Bind("DIAS") %>'></asp:Label>
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

    
<!-- DataTables -->
<script src="assets/template/AdminLTE-2.3.0/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/template/AdminLTE-2.3.0/plugins/datatables/dataTables.bootstrap.min.js"></script>

<script>
$(document).ready( function () {
    jQuery('#grvRecupacionPagos').DataTable({

    "language": {
           "sProcessing":     "Procesando...",
    "sLengthMenu":     "Mostrar _MENU_ registros",
    "sZeroRecords":    "No se encontraron resultados",
    "sEmptyTable":     "Ningún dato disponible en esta tabla",
    "sInfo":           "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty":      "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered":   "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix":    "",
    "sSearch":         "Buscar:",
    "sUrl":            "",
    "sInfoThousands":  ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst":    "Primero",
        "sLast":     "Último",
        "sNext":     "Siguiente",
        "sPrevious": "Anterior"
    }
        },
            "iDisplayLength": 25
        /**,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'csvHtml5',
            'pdfHtml5'
        ] **/
    });
});

</script>



</asp:Content>
