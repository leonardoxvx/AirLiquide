<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="GeneralMandantes.aspx.cs" Inherits="Cobros30.GeneralMandantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    title: "Sucursales"
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
                    name: "Total Deuda",
                    
                    // markerSize: 0,        
                    // color: "rgba(54,158,173,.6)",
                    dataPoints: 
                    <%=montoAsignadoStr %> 
        //[{label: '21', y: parseInt('2')},{label: '22', y: parseInt('1')}] 
                    },
          {        
          type: "column", 
          showInLegend: true,
          // markerSize: 0,
          name: "Nro Clientes",
          color: "Black",
              
          dataPoints: 
          <%=deudaActivaStr %> 
        //[{label: '21', y: parseInt('0')},{label: '22', y: parseInt('0')}] 
          },
          {        
          type: "column", 
          showInLegend: true,
          // markerSize: 0,
          name: "Deuda Prescrita",
          color: "red",
          dataPoints: 
          <%=retiroCastigoStr %> 
        //[{label: '21', y: parseInt('0')},{label: '22', y: parseInt('0')}] 
          },
          {        
          type: "column", 
          showInLegend: true,
          // markerSize: 0,
          name: "Pagos Abono",
          color: "green",
          dataPoints: 
          <%=pagosAbonoStr %> 
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
          <h3>
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Estatus General</li>
          </ol>
        </section>
        <!--  -->

    <section class="content">
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="box box-danger">
            <div class="box-header with-border">
                <h3 class="box-title">Estatus General</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <asp:GridView ID="grvMandantes" runat="server" CssClass="table table-bordered small"
                    PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="150px">
                            <ItemTemplate>
                                
                                <asp:Label ID="lblIdMandante" runat="server" Text='<%# Bind("IdSucursal") %>' Visible="false"></asp:Label>

                                
                                <div class="small-box bg-gray">
                                    <div class="inner">
                                        <h4>
                                            <asp:Label ID="lblNombreMandante" runat="server" Text='<%# Bind("NomSucursal") %>' Visible="true"></asp:Label>
                                            <sup style="font-size: 20px"></sup></h4>
                                    </div>
                                    
                                </div>

                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente Asignados">
                            <ItemTemplate>

                                <div class="small-box bg-green">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblRutAsignado" runat="server" Text='<%# Bind("RUT_ASIGNADOS","{0:n0}") %>'></asp:Label>
                                            <sup style="font-size: 20px"></sup></h3>
                                        <p>Clientes Asignados</p>
                                    </div>
                                    <div class="icon">
                                        
                                    </div>
                                    <asp:LinkButton ID="lbtnVerMasRutAsignados" CssClass="small-box-footer" runat="server" OnClick="lbtnVerMasRutAsignados_Click">Ver mas <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>

                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Monto Asignados">
                            <ItemTemplate>

                                <div class="small-box bg-yellow">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblMontoAsignado" runat="server" Text='<%# Bind("Monto_Asignado","{0:n0}") %>'></asp:Label></h3>
                                        <p>Total Deuda</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-person-add"></i>
                                    </div>
                                    <asp:LinkButton ID="lbtnVerMasMontoAsignado" CssClass="small-box-footer" runat="server" OnClick="lbtnVerMasMontoAsignado_Click">Ver mas <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>

                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pagos Abono">
                            <ItemTemplate>

                                <div class="small-box bg-red">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblPagosAbono" runat="server" Text='<%# Bind("PAGOS_ABONO","{0:n0}") %>'></asp:Label></h3>
                                        <p>Pagos Abono</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-pie-graph"></i>
                                    </div>
                                    <asp:LinkButton ID="lbtnVerMasPagosAbono" CssClass="small-box-footer" runat="server" OnClick="lbtnVerMasPagosAbono_Click">Ver mas <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>

                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>

                        
                        <asp:TemplateField HeaderText="Retiro">
                            <ItemTemplate>

                                <div class="small-box bg-light-blue">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblRetiro" runat="server" Text='<%# Bind("Retiro","{0:n0}") %>'></asp:Label></h3>
                                        <p>Deuda prescrita</p>
                                    </div>
                                    <div class="icon">
                                        <i class="fa fa-shopping-cart"></i>
                                    </div>
                                    <asp:LinkButton ID="lbtnVerMasRetiro" CssClass="small-box-footer" runat="server" OnClick="lbtnVerMasRetiro_Click">Ver mas <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>

                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Saldo Activo" Visible="false">
                            <ItemTemplate>
                                <div class="small-box bg-aqua">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblSaldoActivo" runat="server" Text='<%# Bind("Saldo_Activo","{0:n0}") %>'></asp:Label></h3>
                                        <p>Nro Clientes</p>
                                    </div>
                                    <div class="icon">
                                        <i class="fa fa-shopping-cart"></i>
                                    </div>
                                    <asp:LinkButton ID="lbtnVerMasSaldo" CssClass="small-box-footer" runat="server" OnClick="lbtnVerMasSaldo_Click">Ver mas <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="box box-danger">
            <div class="box-header with-border">
                <h3 class="box-title">Gráfico</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div id="chartContainer" style="height: 300px; width: 100%;"></div>
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
            </div>
        </div><!-- /.box -->

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
</asp:Content>
