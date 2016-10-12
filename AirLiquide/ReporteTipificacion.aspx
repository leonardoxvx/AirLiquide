<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ReporteTipificacion.aspx.cs" Inherits="Cobros30.ReporteTipificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="assets/template/AdminLTE-2.3.0/plugins/canvasjs.min.js"></script>
     <script type="text/javascript">
        function ejemplo()
        {
            var chart = new CanvasJS.Chart("chartContainer",
            {  
                theme:"theme2",
                exportEnabled: true,
                title:{
                    text: ""
                },
                animationEnabled: true,
                axisY :{
                    title: "Cantidad"
                    //includeZero: true,
                    //suffix: " Q",
                    //valueFormatString: "#,,.",
                    //suffix: " mm"
                    //valueFormatString:  "#.##0,##"
                },
                axisX :{
                    title: "Fecha"
                    // valueFormatString:  "#.##0,##", // move comma to change formatting  
                    //prefix: "Fecha"
                },
                toolTip: {
                    shared: "true"
                },
                data: [
                {        
                    type: "column", 
                    showInLegend: true,
                    name: "Gestiones",
                    // markerSize: 0,
                    // color: "rgba(54,158,173,.6)",
                    dataPoints: 
                    <%=gestionesStr %> 
        //[{label: '21', y: parseInt('2')},{label: '22', y: parseInt('1')}]
                    },
      {        
          type: "column", 
          showInLegend: true,
          // markerSize: 0,
          name: "Casos",
          dataPoints: 
          <%=casosStr %> 
        //[{label: '21', y: parseInt('0')},{label: '22', y: parseInt('0')}] 
          }

                ],
                legend:{
                    cursor:"pointer",
                    itemclick : function(e) {
                        if (typeof(e.dataSeries.visible) === "undefined" || e.dataSeries.visible ){
                            e.dataSeries.visible = false;
                        }
                        else {
                            e.dataSeries.visible = true;
                        }
                        chart.render();
                    }
        
                },
            });

    chart.render();

}
    </script>

    <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Reporte de Tipificaciones
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Reportes</a></li>
            <li class="active">Reporte de Tipificaciones</li>
          </ol>
        </section>

            <asp:HiddenField ID="hfConsulta" runat="server" />
            <asp:HiddenField ID="hfSolicitud" runat="server" />
            <asp:HiddenField ID="hfReclamo" runat="server" />
            <asp:HiddenField ID="hfIncidencia" runat="server" />
                    

        <section class="content">
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="box box-success">
                <%--<div class="box-header with-border">
                    <h3 class="box-title">Buscar</h3>
                </div>--%>
                <div class="box-body">
                    <div class="row">
                        <div class="col-xs-2">
                            <label for="">Usuario:</label>
                            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control input-sm" OnDataBound="ddlUsuario_DataBound">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <label for="">Fecha Desde:</label>
                            <asp:TextBox ID="txtFechaDesde" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <label for="">Fecha Hasta:</label>
                            <asp:TextBox ID="txtFechaHasta" ClientIDMode="Static" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                        </div>

                        <div class="col-xs-1">
                            <label></label>
                            <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm btn-block" runat="server"
                                OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i>Buscar</asp:LinkButton>
                        </div>
                        
                        <div class="col-xs-1">
                            <label></label>
                             <asp:LinkButton ID="btnExcel" Text="text" OnClick="btnExcel_Click" CssClass="btn btn-success btn-sm btn-block" runat="server"><i class="fa fa-lg fa-file-excel-o"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <div class="box box-danger">
            <div class="box-header with-border">
              <h3 class="box-title">Gráfico</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
              </div>
            </div><!-- /.box-header -->
            <div class="box-body">
                   <div id="chartContainer" style="height: 300px; width: 100%;"></div>
            </div><!-- /.box-body -->
            <div class="box-footer">
              
            </div>
          </div><!-- /.box -->

            
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">Detalle</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:GridView ID="grvCantidadDeGestiones" EmptyDataText="Selección realizada no obtuvo registros" runat="server" HeaderStyle-CssClass="active" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small panel table-responsive" AutoGenerateColumns="false" OnDataBound="grvCantidadDeGestiones_DataBound" OnRowDataBound="grvCantidadDeGestiones_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdTipificacion" runat="server" Visible="false" Text='<%# Bind("IDTIPIFICACION") %>'></asp:Label>
                                    <asp:Label ID="lblNivel1" runat="server" Text='<%# Bind("NIVEL1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SubCategoria">
                                <ItemTemplate>
                                    <asp:Label ID="lblNivel2" runat="server" Text='<%# Bind("NIVEL2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Gestión">
                                <ItemTemplate>
                                    <asp:Label ID="lblNivel3" runat="server" Text='<%# Bind("NIVEL3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Detalle de la categoría">
                                <ItemTemplate>
                                    <asp:Label ID="lblNivel4" runat="server" Text='<%# Bind("NIVEL4") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("GESTIONES") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lbtnCantidad" Text='<%# Bind("GESTIONES") %>' OnClick="lbtnCantidad_Click" Visible="true" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />

                                <FooterTemplate>
                                    <div style="float: right">
                                        <strong>Total: </strong>
                                        <asp:LinkButton ID="lbtnTotalCantidad" OnClick="lbtnTotalCantidad_Click" Visible="true" runat="server"></asp:LinkButton>
                                        <asp:Label ID="lblTotalCantidad" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- /.box-body -->
                <div class="box-footer">
                </div>
            </div><!-- /.box -->
  

        </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="assets/template/AdminLTE-2.3.0/plugins/datepicker/bootstrap-datepicker.js"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
        <script type="text/javascript">
        $(document).ready(function () {
            var dp = $(".class-date");
                dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd-mm-yyyy",
                language: "es"
            });
        });
        </script>
</asp:Content>
