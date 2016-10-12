<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Meta.aspx.cs" Inherits="Cobros30.Meta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Metas
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administración</a></li>
            <li class="active">Metas</li>
          </ol>
        </section>
        <!--  -->

    <section class="content">
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        
        <div class="panel panel-primary" id="divSearch" runat="server">
            <div class="panel-heading">
                <asp:LinkButton ID="btnNew" OnClick="btnNew_Click" runat="server" CssClass="btn btn-xs btn-success"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
            </div>
            <div class="panel-body">
                <asp:GridView ID="grvMeta" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-hover table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Periodo">
                            <ItemTemplate>
                                <asp:Label ID="lblPeriodo" runat="server" Text='<%# Bind("Periodo") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sucursal">
                            <ItemTemplate>
                                <asp:Label ID="lblIdSucursal" runat="server" Visible="false" Text='<%# Bind("IdSucursal") %>'></asp:Label>
                                <asp:Label ID="lblSucursal" runat="server" Text='<%# Bind("NomSucursal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Meta">
                            <ItemTemplate>
                                <asp:Label ID="lblMeta" runat="server" Visible="true" Text='<%# Bind("Meta") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-Width="7%">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEditar" OnClick="btnEditar_Click" runat="server" CssClass="btn btn-xs btn-primary"><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" runat="server" CssClass="btn btn-xs btn-danger"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


                <div runat="server" id="divAddEdit" class="box box-danger" visible="false">
                    <div class="box-header">
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Periodo</label>

                                    <asp:DropDownList ID="ddlAno" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="2016"></asp:ListItem>
                                    </asp:DropDownList>
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
                                <div class="form-group">
                                    <label>Sucursal</label>
                                    <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="ddlActivo">Meta</label>
                                    <asp:TextBox ID="txtMeta" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                       </div>
                    </div>

                    <div class="box-footer">
                        <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" runat="server" />
                        <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" runat="server" CausesValidation="false" />
                    </div>
                </div>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    
<!-- DataTables -->
<script src="assets/template/AdminLTE-2.3.0/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/template/AdminLTE-2.3.0/plugins/datatables/dataTables.bootstrap.min.js"></script>

<script>
$(document).ready( function () {
    jQuery('#grvMeta').DataTable({

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
