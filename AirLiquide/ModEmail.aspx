<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ModEmail.aspx.cs" Inherits="Cobros30.ModEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Mensajes
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Mensajes</li>
          </ol>
        </section>
        <!--  -->

    <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

    <section class="content">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Mensajes</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="mailbox-controls">
                        <!-- Check all button -->
                        
                        <asp:LinkButton ID="btnNewMsj" OnClick="btnNewMsj_Click" runat="server" CssClass="btn btn-sm btn-success"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                        <asp:LinkButton ID="lbtnRefresh" OnClick="lbtnRefresh_Click" runat="server" CssClass="btn btn-sm btn-default"><span class="fa fa-refresh"></span></asp:LinkButton>
                        
                    </div>
                    <div class="mailbox-messages">
                        <asp:GridView ID="grvUsuarios" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            EmptyDataText="No hay mensajes en su buzon" EmptyDataRowStyle-CssClass="danger"
                             HeaderStyle-CssClass="info" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowDataBound="grvUsuarios_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img runat="server" id="imgFotoUserMsj" src='<%# Bind("Fotografia") %>' class="img-circle" style="height:7%" alt="User Image"/>
                                        <asp:Label ID="lblIdMensaje" runat="server" Text='<%# Bind("IdMensaje") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="De" ControlStyle-CssClass="mailbox-name" ItemStyle-CssClass="mailbox-name" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblDe" runat="server" Text='<%# Bind("Nombre") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="lbtnDe" runat="server" Text='<%# Bind("Nombre") %>' OnClick="lbtnDe_Click"></asp:LinkButton>
                                        <asp:Label ID="lblLeido" runat="server" Visible="false" Text='<%# Bind("leido") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           
                                <asp:TemplateField HeaderText="Asunto" ControlStyle-CssClass="mailbox-subject">
                                    <ItemTemplate>
                                        <b><asp:Label ID="lblAsunto" runat="server" Visible="true" Text='<%# Bind("Asunto") %>'></asp:Label></b>
                                        -
                                        <asp:Label ID="lblMsj" runat="server" Visible="true" Text='<%# Bind("Msj") %>'></asp:Label>
                                        ...
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField  ControlStyle-CssClass="mailbox-date">
                                    <ItemTemplate>
                                        Hace 
                                        <b><asp:Label ID="lblDias" runat="server" Visible="true" Text='<%# Bind("dias") %>'></asp:Label></b>
                                        dias
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                    <!-- /.mail-box-messages -->
                </div>
                <!-- /.box-body -->

            </div>
            <!-- /. box -->
        </div><!-- /.col -->

    </section>
      


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
        <!-- DataTables -->
    <script src="assets/template/AdminLTE-2.3.0/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/template/AdminLTE-2.3.0/plugins/datatables/dataTables.bootstrap.min.js"></script>

<script>
$(document).ready( function () {
    jQuery('#grvUsuarios').DataTable({

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
} );

</script>
</asp:Content>
