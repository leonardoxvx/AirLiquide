<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ReporteMetas.aspx.cs" Inherits="Cobros30.ReporteMetas" %>
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
                    // valueFormatString:  "#.##0,##",   // move comma to change formatting  
                    //prefix: "Fecha"
                },
                toolTip: {
                    shared: "true"
                },
                data: [
                {        
                    type: "column", 
                    showInLegend: true,
                    name: "Pagos",
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
          name: "Meta",
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



    <section class="content">
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

            
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Reporte Metas
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Reportes</a></li>
            <li class="active">Reporte Metas</li>
          </ol>
        </section>
        <!--  -->


        
        <div class="box box-success">
                <%--<div class="box-header with-border">
                    <h3 class="box-title">Buscar</h3>
                </div>--%>
                <div class="box-body">
                    <div class="row">
                        <div class="col-xs-2">
                            <label for="">Año:</label>
                            <asp:DropDownList ID="ddlAno" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Text="2016"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <label for="">Mes:</label>
                            <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                                <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                                <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                                <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                                <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                                <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                                <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                                <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                                <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                                <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <label for="">Sucursal:</label>
                            <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                            </asp:DropDownList>
                        </div>
                        
                        <div class="col-xs-1">
                            <label></label>
                            <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-block" runat="server"
                                OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i>Buscar</asp:LinkButton>
                        </div>
                        
                    </div>
                </div>
            </div>


        
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
                    <asp:GridView ID="grvMetas" EmptyDataText="Selección realizada no obtuvo registros" runat="server" HeaderStyle-CssClass="active" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small panel table-responsive" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Cod Sucursal">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodSucursal" runat="server" Text='<%# Bind("cod_sucursal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sucursal">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Bind("NomSucursal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Pago">
                                <ItemTemplate>
                                    <asp:Label ID="lblPago" runat="server" Text='<%# Bind("pagos", "{0:n0}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Meta">
                                <ItemTemplate>
                                    <asp:Label ID="lblMeta" runat="server" Text='<%# Bind("meta", "{0:n0}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- /.box-body -->
                <div class="box-footer">
                </div>
            </div><!-- /.box -->


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


    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
