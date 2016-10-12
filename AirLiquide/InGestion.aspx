<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="InGestion.aspx.cs" Inherits="Cobros30.InGestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" />

    <link href="assets/template/plugins/jquery-ui-timepicker-0.3.3/include/ui-1.10.0/ui-lightness/jquery-ui-1.10.0.custom.min.css" rel="stylesheet" />
    <link href="assets/template/plugins/jquery-ui-timepicker-0.3.3/jquery.ui.timepicker.css" rel="stylesheet" />

<%--    <script type="text/javascript" src="include/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.position.min.js"></script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Ingresar Gestión
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Gestión</a></li>
            <li class="active">Ingresar Gestión</li>
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

                <div class="row">
                    <div class="col-lg-12">
                        
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-lg-12">
                                    Ingreso de gestiones extrajudiciales
                                </div>
                            </div>
                            
                        </div>

                        <table class="table table-condensed small">
                            <tr class="active">
                                <td>
                                    <strong>Cod Cliente</strong><br />
                                    <asp:Label ID="lblRutDeudor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <strong>Nombre o Razón Social</strong><br />
                                    <asp:Label ID="lblNombreORazonSocial" runat="server"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <strong>Ejecutivo Asignado</strong><br />
                                    <asp:Label ID="lblEjecutivoAsig" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="active">
                                <td>
                                    <strong>Categoría</strong>
                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control input-sm" OnDataBound="ddlCategoria_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>

                                </td>
                                <td colspan="2">
                                    <strong>SubCategoria</strong>
                                    <asp:DropDownList ID="ddlSubCategoria" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSubCategoria_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCategoria_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td colspan="1">
                                    <strong>Gestión</strong>
                                    <asp:DropDownList ID="ddlGestion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlGestion_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlGestion_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td runat="server" visible="false" id="tdNivel4">
                                    <strong>Nivel 4</strong>
                                    <asp:DropDownList ID="ddlNivel4" runat="server" CssClass="form-control input-sm" OnDataBound="ddlNivel4_DataBound" OnSelectedIndexChanged="ddlNivel4_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:HiddenField ID="hfIdTipificacion" runat="server" />
                                </td>
                            </tr>
                            <tr class="active">
                                <td>
                                    <strong>Fecha Compromiso</strong>
                                    <asp:TextBox ID="txtFechaCompromiso" Enabled="false"  runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Monto Compromiso</strong>
                                    <asp:TextBox ID="txtMontoCompromiso" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Fecha Agendamiento</strong>
                                    <asp:TextBox ID="txtFechaAgendamiento" Enabled="false" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                                </td>
                                <td colspan="1">
                                    <strong>Hora Agendamiento</strong>
                                    <input id="txtHoraAgendamiento" runat="server" type="text" class="form-control input-sm" disabled="true" style="width:20%" data-inputmask='"mask": "99:99"' data-mask>
                                    <%--<asp:TextBox ID="txtHoraAgendamiento" Enabled="false" runat="server" Width="50%" MaxLength="5" CssClass="form-control input-sm timepicker"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr class="active">
                                <td>
                                    <strong>Telefono</strong>
                                    <asp:DropDownList ID="ddlTelefonoRutDeudor" Enabled="false" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTelefonoRutDeudor_DataBound"></asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Dirección Asoc</strong>
                                    <asp:DropDownList ID="ddlDireccionAsociada" Enabled="false" runat="server" CssClass="form-control input-sm" OnDataBound="ddlDireccionAsociada_DataBound"></asp:DropDownList>
                                </td>
                                <td colspan="3">
                                    <strong>Observación</strong>
                                    <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control input-sm" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <div class="panel-footer">
                            <asp:LinkButton ID="lbtnGrabarGestion" OnClick="lbtnGrabarGestion_Click" runat="server" CssClass="btn btn-sm btn-google">Grabar <span class="glyphicon glyphicon-file"></span></asp:LinkButton>
                        </div>

                    </div>

                        </div>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>

    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
        <!-- DataTables -->
    <script src="assets/template/AdminLTE-2.3.0/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/template/AdminLTE-2.3.0/plugins/datatables/dataTables.bootstrap.min.js"></script>

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

    <script type="text/javascript" src="assets/template/plugins/jquery-ui-timepicker-0.3.3/include/ui-1.10.0/jquery.ui.core.min.js"></script>
    <script src="assets/template/plugins/jquery-ui-timepicker-0.3.3/include/ui-1.10.0/jquery.ui.position.min.js"></script>
    <script src="assets/template/plugins/jquery-ui-timepicker-0.3.3/jquery.ui.timepicker.js?v=0.3.3"></script>

    
<script src="assets/template/AdminLTE-2.3.0/plugins/input-mask/jquery.inputmask.js"></script>
<script src="assets/template/AdminLTE-2.3.0/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="assets/template/AdminLTE-2.3.0/plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <%--<script type="text/javascript" src="jquery.ui.timepicker.js?v=0.3.3"></script>--%>
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>


    <script type="text/javascript">
            $(document).ready(function() {
                $('.timepicker').timepicker( {
                    //showAnim: 'blind'
                } );

                $("[data-mask]").inputmask();

            });
        </script>
</asp:Content>
