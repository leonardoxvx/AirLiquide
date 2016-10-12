<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="AgendamientosCompromisos.aspx.cs" Inherits="Cobros30.AgendamientosCompromisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h3>
        Agendamientos – Compromisos 
        </h3>
        <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li class="active">Agendamientos – Compromisos</li>
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
                    <div class="panel-heading">Agendamientos - Compromisos</div>
                    
                    <table class="table">
                        <tr>
                            <td>
                                <strong>Tipo</strong>
                                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control input-sm">
                                    <asp:ListItem Value="0" Text="Todos"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Agendamientos"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Compromisos"></asp:ListItem>
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
                                <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i> Buscar</asp:LinkButton>
                            </td>
                        </tr>
                    </table>

                    <asp:GridView ID="grvAgrendamientosCompromisos" EmptyDataText="Selección realizada no obtuvo registros" runat="server" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small panel table-responsive" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Cod Cliente">
                                <ItemTemplate>
                                    <asp:Label ID="lblRutDeudor" runat="server" Text='<%# Bind("RutDeudor") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lbtnRutDeudor" runat="server" Text='<%# Bind("RutDeudor") %>' OnClick="lbtnRutDeudor_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha U.G.">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaUltimaGestion" runat="server" Text='<%# Bind("FEC_ING_UG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha Ingreso">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FEC_ING_UG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Gestión">
                                <ItemTemplate>
                                    <asp:Label ID="lblGestion" runat="server" Text='<%# Bind("GESTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ejecutivo">
                                <ItemTemplate>
                                    <asp:Label ID="lblEjecutivo" runat="server" Text='<%# Bind("LOGIN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha Comp">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaCompromiso" runat="server" Text='<%# Bind("FECHACOMPROMISO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha Agendamiento">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaAgendamiento" runat="server" Text='<%# Bind("FECHAAGENDAMIENTO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Hora Agendamiento">
                                <ItemTemplate>
                                    <asp:Label ID="lblHoraAgendamiento" runat="server" Text='<%# Bind("HORAAGENDAMIENTO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Observación">
                                <ItemTemplate>
                                    <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("OBSERVACIONES") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

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
