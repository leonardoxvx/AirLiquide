<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Cobros30.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Usuarios
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Usuarios</li>
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
                <asp:LinkButton ID="lbtExportar" OnClick="lbtExportar_Click" runat="server" CssClass="btn btn-xs btn-success"><span class="fa fa-file-excel-o">Exportar</span></asp:LinkButton>
            </div>
            <div class="panel-body">
                <asp:GridView ID="grvUsuarios" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rut">
                            <ItemTemplate>
                                <asp:Label ID="lblFoto" runat="server" Text='<%# Bind("foto") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblRut" runat="server" Text='<%# Bind("Rut") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                        <asp:TemplateField HeaderText="Login">
                            <ItemTemplate>
                                <asp:Label ID="lblLogin" runat="server" Visible="true" Text='<%# Bind("Login") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="NomPerfil" HeaderText="Perfil" />
                        <asp:BoundField DataField="AreaCargo" HeaderText="Area Cargo" />

                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:Label ID="lblActivo" runat="server" Visible="false" Text='<%# Bind("Activo") %>'></asp:Label>
                                <asp:Label ID="lblActivo2" runat="server" Text='<%# Bind("Activo2") %>'></asp:Label>
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
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rut</label>
                                    <asp:TextBox ID="txtRut" MaxLength="12" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:HiddenField ID="hfIdUsuario" runat="server" />
                                    
                                </div>
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                    <label for="txtEmail">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlPerfil">Perfil</label>
                                    <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control input-sm" OnDataBound="ddlPerfil_DataBound">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1"  runat="server" Display="Dynamic"  ControlToValidate="ddlPerfil" InitialValue="0"  ErrorMessage="Debe seleccionar un perfil" CssClass="label label-danger" />
                                </div>
                                <%--<div class="form-group">
                                    <label for="ddlPerfil">Sucursal</label>
                                    <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                    </asp:DropDownList>
                                    
                                </div>--%>
                                
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtLogin">Login</label>
                                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLogin" ErrorMessage="Debe ingresar un Login" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtClave">Clave</label>
                                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control input-sm"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClave"  ErrorMessage="Debe ingresar una Password" CssClass="label label-danger"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group">
                                    <label for="txtAreaCargo">Area Cargo</label>
                                    <asp:TextBox ID="txtAreaCargo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <%--<div class="form-group">
                                    <label for="txtAreaCargo">Id Usuario Discador</label>
                                    <asp:TextBox ID="txtIdUsuarioDiscador" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>--%>
                                <div class="form-group">
                                    <label for="ddlActivo">Activo:</label>
                                    <asp:DropDownList ID="ddlActivo" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="divImagenLogo" runat="server" visible="false">
                                <div class="form-group">
                                    <label style="text-align:center">Fotografia:</label>
                                    <img runat="server" id="imgLogo" src="/" class="img-circle img-responsive" style="height:160px;width:160px" alt="" />
                                </div>                              
                                <div class="form-group">
                                    <label></label>
                                    <asp:FileUpload runat="server" CssClass="form-control" ID="fuLogo" />
                                </div>
                                <div class="form-group">
                                    <label></label>
                                    <asp:Button ID="btnSubirImagen" OnClick="btnSubirImagen_Click" CssClass="btn btn-info btn-sm" Text="Subir Imagen" runat="server" CausesValidation="false" />
                                </div>
                            </div>                        
                       </div>
                        <div class="row" runat="server" visible="false">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="well well-sm">
                                        <label for="chkMandantes">Mandantes</label>
                                        <asp:CheckBoxList ID="chkMandantes" runat="server" Width="100%" 
                                           RepeatColumns="6"
                                           RepeatDirection="Horizontal"
                                           TextAlign="Right">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="well well-sm">
                                        <label for="chkMandantes">Sucursales</label>
                                        <asp:CheckBoxList ID="chkSucursales" runat="server" Width="100%" 
                                           RepeatColumns="6"
                                           RepeatDirection="Horizontal"
                                           TextAlign="Right">
                                        </asp:CheckBoxList>
                                    </div>
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
