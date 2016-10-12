<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CarteraAsignada.aspx.cs" Inherits="Cobros30.CarteraAsignada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Cartera Asignada
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Cartera Asignada</li>
          </ol>
        </section>
        <!--  -->

    <section class="content">
        
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
            <asp:HyperLink ID="hlDescargar" runat="server"></asp:HyperLink>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <asp:Panel ID="pnlCarteraAsignada" runat="server" DefaultButton="lbtnBuscar">
                    <div class="panel panel-warning">
                        <div class="panel-heading"><strong>Cartera Asignada</strong></div>
                        <table class="table">
                            <tr>
                                <%--<td><strong>Mandante</strong>
                                    <asp:DropDownList ID="ddlMandante" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                </td>--%>
                                <td runat="server" visible="false"><strong>Asignación</strong>
                                    <asp:DropDownList ID="ddlAsignacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlAsignacion_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td runat="server" visible="false"><strong>Campaña</strong>
                                    <asp:DropDownList ID="ddlCampana" runat="server" CssClass="form-control input-sm" OnDataBound="ddlCampana_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td><strong>Estado Deuda</strong>
                                    <asp:DropDownList ID="ddlEstadoDeuda" runat="server" CssClass="form-control input-sm" OnDataBound="ddlEstadoDeuda_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Usuario Asignado</strong>
                                    <asp:DropDownList ID="ddlEjecutivo" runat="server" CssClass="form-control input-sm" OnDataBound="ddlEjecutivo_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Tipo Deuda</strong>
                                    <asp:DropDownList ID="ddlTipoDeuda" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoDeuda_DataBound">
                                        <asp:ListItem Value="0" Text="Todas"></asp:ListItem>
                                        <asp:ListItem Value="Vigente"></asp:ListItem>
                                        <asp:ListItem Value="Preescrita"></asp:ListItem>
                                        <asp:ListItem Value="Prox.Preescribir"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Sucursal</strong>
                                    <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                    </asp:DropDownList>
                                </td><td></td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Nombre o Razon Social</strong>
                                    <asp:TextBox ID="txtNombreRazonSocial" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Cod Cliente</strong>
                                    <asp:TextBox ID="txtRut" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Monto Desde</strong>
                                    <asp:TextBox ID="txtMontoDesde" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Monto Hasta</strong>
                                    <asp:TextBox ID="txtMontoHasta" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Tipo Cartera</strong>
                                    <asp:DropDownList ID="ddlTipoCartera" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Pendientes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Gestionados" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <br />
                                    <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i> Buscar</asp:LinkButton>
                                </td>
                                <td><br />
                                    <asp:LinkButton ID="btnExcel" Text="text" OnClick="btnExcel_Click" CssClass="btn btn-success btn-sm btn-block" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                </td>

                            </tr>
                        </table>

                        <asp:GridView ID="grvResultado" runat="server" CssClass="table table-bordered table-hover table-condensed small" 
                            HeaderStyle-CssClass="warning" AutoGenerateColumns="false" AllowPaging="True" PageSize="100" ShowFooter="true" OnRowDataBound="paginacion_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Cod Cliente">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                        <asp:Label ID="lblRutDeudor" runat="server" Text='<%# Bind("RutDeudor") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="lbtnRutDeudor" runat="server" Text='<%# Bind("RutDeudor") %>' OnClick="lbtnRutDeudor_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre o Razón Social">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombreDeudor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saldo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Ult. Gestión">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUltimaGestion" runat="server" Text='<%# Bind("Fec_Ult_Gestion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="F. Agend">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaAgendamiento" runat="server" Text='<%# Bind("Fec_Ult_Gestion_Agend") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Usuario Asig" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsuarioAsignado" runat="server" Text='<%# Bind("UsuarioAsignado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btnColor" runat="server" CssClass='<%# Bind("COLOR") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerTemplate>
                                <div>
                                    <div style="float:left">
                                        <asp:ImageButton ID="imgFirst" runat="server"  
                                            ImageUrl="~/assets/img/grid/first.gif" onclick="imgFirst_Click" 
                                            style="height: 15px" title="Navegación: Ir a la Primera Pagina" Width="26px" />
                                        <asp:ImageButton ID="imgPrev" runat="server" 
                                            ImageUrl="~/assets/img/grid/prev.gif" onclick="imgPrev_Click" 
                                            title="Navegación: Ir a la Pagina Anterior" Width="26px" />
                                        <asp:ImageButton ID="imgNext" runat="server"
                                            ImageUrl="~/assets/img/grid/next.gif" onclick="imgNext_Click" 
                                            title="Navegación: Ir a la Siguiente Pagina" Width="26px" />
                                        <asp:ImageButton ID="imgLast" runat="server" 
                                            ImageUrl="~/assets/img/grid/last.gif" onclick="imgLast_Click" 
                                            title="Navegación: Ir a la Ultima Pagina" Width="26px" />
                                    </div>

                                    <div style="float:left">
                                    Registros por página: 100
                                    </div>

                                    <div style="float:right">
                                        Total Registros: 
                                        <asp:Label ID="lblTotalRegistros" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        Página
                                        <asp:Label ID="lblPagina" runat="server"></asp:Label>
                                        de
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>

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
</asp:Content>
