<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="Cobros30.Sucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Sucursal
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Sucursal</li>
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
                <asp:GridView ID="grvTipoDocumento" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-hover table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIdSucursal" runat="server" Text='<%# Bind("IdSucursal") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre Sucursal">
                            <ItemTemplate>
                                <asp:Label ID="lblNomSucursal" runat="server" Text='<%# Bind("NomSucursal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:Label ID="lblActivo" runat="server" Visible="false" Text='<%# Bind("Activo") %>'></asp:Label>
                                <asp:Label ID="lblActivo2" runat="server" Visible="true" Text='<%# Bind("Activo2") %>'></asp:Label>
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
                                    <label>Id Sucursal</label>
                                    <asp:TextBox ID="txtIdSucursal" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtIdSucursal" ErrorMessage="Debe ingresar el id de la sucursal" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Nombre Sucursal</label>
                                    <asp:TextBox ID="txtNombreSucursal" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtNombreSucursal" ErrorMessage="Debe ingresar un nombre" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="ddlActivo">Activo:</label>
                                    <asp:DropDownList ID="ddlActivo" runat="server" CssClass="form-control input-sm" Width="150px" >
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
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
    jQuery('#grvTipoDocumento').DataTable({

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
