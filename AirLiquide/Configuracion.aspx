<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="Cobros30.Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Ion Slider -->
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/ionslider/ion.rangeSlider.css"/>
    <!-- ion slider Nice -->
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/ionslider/ion.rangeSlider.skinNice.css"/>
    <!-- bootstrap slider -->
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/bootstrap-slider/slider.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Configuración
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Configuración</li>
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
                    <div class="panel-heading">Configuración</div>
                    
                    <table class="table">
                        <tr class="active">
                            <td width="150px">
                                <strong>Tipo Tipificación</strong>
                                <asp:DropDownList ID="ddlTipoTipificacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoTipificacion_DataBound">
                                </asp:DropDownList>
                            </td>
                            <td width="100px"><br />
                                <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i> Buscar</asp:LinkButton>
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtnExportarExcel" ImageUrl="~/assets/img/file_extension_xls.png" runat="server" OnClick="ibtnExportarExcel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                    <asp:HiddenField ID="hfNivel1" runat="server" />
                     <asp:HiddenField ID="hfNivel2" runat="server" />
                     <asp:HiddenField ID="hfNivel3" runat="server" />
                     <asp:HiddenField ID="hfNivel4" runat="server" />
                     <asp:HiddenField ID="hfIdTipificacion" runat="server" />

                     <div runat="server" id="divGrilla" class="box box-danger" visible="true">

                         <asp:GridView ID="grvConfiguracion" runat="server" ClientIDMode="Static"  CssClass="table table-hover table-condensed table-bordered small" AutoGenerateColumns="false">
                             <Columns>
                                 <asp:TemplateField HeaderText="Id">
                                     <ItemTemplate>
                                         <asp:Label ID="lblId" runat="server" Text='<%# Bind("IdTipificacion") %>'></asp:Label>
                                         <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                         <asp:Label ID="lblPrioridad" runat="server" Visible="false" Text='<%# Bind("Prioridad") %>'></asp:Label>
                                         <asp:Label ID="lblGestionMandante" runat="server" Visible="false" Text='<%# Bind("CodMandante") %>'></asp:Label>

                                         <asp:Label ID="lblValidaFono" runat="server" Visible="false" Text='<%# Bind("ValidaFono") %>'></asp:Label>
                                         <asp:Label ID="lblInvalidaFono" runat="server" Visible="false" Text='<%# Bind("InvalidaFono") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Nivel 1">
                                     <ItemTemplate>
                                         <asp:Label ID="lblNivel1" runat="server" Visible="true" Text='<%# Bind("Nivel1") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Nivel 2">
                                     <ItemTemplate>
                                         <asp:Label ID="lblNivel2" runat="server" Visible="true" Text='<%# Bind("NIVEL2") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Nivel 3">
                                     <ItemTemplate>
                                         <asp:Label ID="lblNivel3" runat="server" Visible="true" Text='<%# Bind("NIVEL3") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Nivel 4">
                                     <ItemTemplate>
                                         <asp:Label ID="lblNivel4" runat="server" Visible="true" Text='<%# Bind("NIVEL4") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Tipo Gestión">
                                     <ItemTemplate>
                                         <asp:Label ID="lblIdTipoGestion" runat="server" Visible="false" Text='<%# Bind("IdTipoGestion") %>'></asp:Label>
                                         <asp:Label ID="lblTipoGestion" runat="server" Visible="true" Text='<%# Bind("NomTipoGestion") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Agendable">
                                     <ItemTemplate>
                                         <asp:Label ID="lblEsAgendable" runat="server" Visible="false" Text='<%# Bind("EsAgendable") %>'></asp:Label>
                                         <asp:Label ID="lblAgendable" runat="server" Visible="true" Text='<%# Bind("Agendable") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Compromiso Pago">
                                     <ItemTemplate>
                                         <asp:Label ID="lblEsCompPago" runat="server" Visible="false" Text='<%# Bind("EsCompPago") %>'></asp:Label>
                                         <asp:Label ID="lblCompromisoPago" runat="server" Visible="true" Text='<%# Bind("ComPago") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText="Modificar">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="btnEditar" Text="" OnClick="btnEditar_Click" CssClass="btn btn-sm btn-success btn-xs" runat="server"><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" />
                                 </asp:TemplateField>

                             </Columns>
                         </asp:GridView>
                     </div>

                     <div runat="server" id="divEditarConfiguracion" class="box box-danger" visible="false">
                         <div class="box-header">
                             Editar Configuración
                         </div>
                         <div class="box-body">
                             <div class="row">
                                 <div class="col-md-4">

                                     <div class="form-group">
                                         <label for="">Nivel 1</label>
                                         <asp:TextBox ID="txtNivel1" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Nivel 2</label>
                                         <asp:TextBox ID="txtNivel2" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Nivel 3</label>
                                         <asp:TextBox ID="txtNivel3" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Nivel 4</label>
                                         <asp:TextBox ID="txtNivel4" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                     </div>
                                 </div>
                                 <div class="col-md-2">
                                     <div class="form-group">
                                         <label for="">Tipo Gestión</label>
                                         <asp:DropDownList ID="ddlTipoGestion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoGestion_DataBound">
                                         </asp:DropDownList>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Agendable</label>
                                         <asp:DropDownList ID="ddlAgendable" runat="server" CssClass="form-control input-sm">
                                             <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                         </asp:DropDownList>
                                     </div>
                                     <div class="form-group">
                                         <label for="ddlPerfil">Compromiso de Pago</label>
                                         <asp:DropDownList ID="ddlCompromisoPago" runat="server" CssClass="form-control input-sm">
                                             <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                         </asp:DropDownList>

                                     </div>
                                     <div class="form-group">
                                         <label for="ddlPerfil">Gestión Mandante</label>
                                         <asp:TextBox ID="txtGestionMandante" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                     </div>
                                 </div>
                                 <div class="col-md-2">
                                     <div class="form-group">
                                        <label for="ddlPerfil">Prioridad</label>
                                        <asp:TextBox ID="txtPrioridad" runat="server" TextMode="Number" CssClass="form-control input-sm"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Valida Telefono</label>
                                         <asp:DropDownList ID="ddlValidaTelefono" runat="server" CssClass="form-control input-sm">
                                             <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                         </asp:DropDownList>
                                     </div>
                                     <div class="form-group">
                                         <label for="">Invalida Telefono</label>
                                         <asp:DropDownList ID="ddlInvalidaTelefono" runat="server" CssClass="form-control input-sm">
                                             <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                         </asp:DropDownList>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         <div class="box-footer">
                             <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" runat="server" />
                             <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" runat="server" />
                         </div>
                     </div>

            </ContentTemplate>
         </asp:UpdatePanel>

    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    <!-- Ion Slider -->
    <script src="../../plugins/ionslider/ion.rangeSlider.min.js"></script>
    <script src="assets/template/AdminLTE-2.3.0/plugins/ionslider/ion.rangeSlider.min.js"></script>
    <!-- Bootstrap slider -->
    <script src="assets/template/AdminLTE-2.3.0/plugins/bootstrap-slider/bootstrap-slider.js"></script>

    <script>
      $(function () {
        /* BOOTSTRAP SLIDER */
        $('.slider').slider();

        /* ION SLIDER */
        $("#range_1").ionRangeSlider({
          min: 0,
          max: 5000,
          from: 1000,
          to: 4000,
          type: 'double',
          step: 1,
          prefix: "$",
          prettify: false,
          hasGrid: true
        });
        $("#range_2").ionRangeSlider();

        $("#range_5").ionRangeSlider({
          min: 0,
          max: 10,
          type: 'single',
          step: 0.1,
          postfix: " mm",
          prettify: false,
          hasGrid: true
        });
        $("#range_6").ionRangeSlider({
          min: -50,
          max: 50,
          from: 0,
          type: 'single',
          step: 1,
          postfix: "°",
          prettify: false,
          hasGrid: true
        });

        $("#range_4").ionRangeSlider({
          type: "single",
          step: 100,
          postfix: " light years",
          from: 55000,
          hideMinMax: true,
          hideFromTo: false
        });
        $("#range_3").ionRangeSlider({
          type: "double",
          postfix: " miles",
          step: 10000,
          from: 25000000,
          to: 35000000,
          onChange: function (obj) {
            var t = "";
            for (var prop in obj) {
              t += prop + ": " + obj[prop] + "\r\n";
            }
            $("#result").html(t);
          },
          onLoad: function (obj) {
            //
          }
        });
      });
    </script>

</asp:Content>
