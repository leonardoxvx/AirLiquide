<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Mandantes.aspx.cs" Inherits="Cobros30.Mandantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Header (Page header) -->
        <section class="content-header">
          <h5>
            Mandantes
          </h5>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Mandantes</li>
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
                 <asp:GridView ID="grvMandantes" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIdMandante" runat="server" Text='<%# Bind("IdMandante") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nom Mandante">
                            <ItemTemplate>
                                <asp:Label ID="lblRutaFoto" runat="server" Text='<%# Bind("rutalogo") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblNomMandante" runat="server" Text='<%# Bind("NomMandante") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Razon Social">
                            <ItemTemplate>
                                <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rut">
                            <ItemTemplate>
                                <asp:Label ID="lblRut" runat="server" Visible="true" Text='<%# Bind("Rut") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comuna">
                            <ItemTemplate>
                                <asp:Label ID="lblNomComuna" runat="server" Text='<%# Bind("NomComuna") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Telefono">
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Logo">
                            <ItemTemplate>
                                <asp:Label ID="lblRutalogo" runat="server" Visible="false" Text='<%# Bind("rutalogo") %>'></asp:Label>
                                <img id="imgLogo" runat="server" alt="" src='<%# Bind("rutalogo") %>' class="img-circle img-responsive" width="100"  />
                            </ItemTemplate>
                        </asp:TemplateField>

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
                                    <label for="txtId">ID:</label>
                                    <asp:HiddenField ID="hfNewOrEdit" runat="server" />
                                    <asp:HiddenField ID="hfIdMandante" runat="server" />
                                    <asp:TextBox ID="txtIdMandante" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIdMandante" ErrorMessage="Debe ingresar un identificador del mandante" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtNombre">Nombre Mandante:</label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtRazonSocial">Razon Social:</label>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Debe ingresar una razon social" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                    <label for="txtContactoNombre">Contacto Nombre</label>
                                    <asp:TextBox ID="txtContactoNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtContactoEmail">Contacto Email</label>
                                    <asp:TextBox ID="txtContactoEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                
                                <div class="form-group">
                                    <label for="txtRepresentanteLegak">Rep Legal Rut</label>
                                    <asp:TextBox ID="txtRepresentanteLegalRut" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtRepresentanteLegalNombre">Rep Legal</label>
                                    <asp:TextBox ID="txtRepresentanteLegalNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional1">Deuda Adicional 1</label>
                                    <asp:TextBox ID="txtAdicional1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional2">Deuda Adicional 2</label>
                                    <asp:TextBox ID="txtAdicional2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional3">Deuda Adicional 3</label>
                                    <asp:TextBox ID="txtAdicional3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional4">Deuda Adicional 4</label>
                                    <asp:TextBox ID="txtAdicional4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtRut">Rut</label>
                                    <asp:TextBox ID="txtRut" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtClave">Giro</label>
                                    <asp:TextBox ID="txtGiro" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtDireccion">Direccion</label>
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlComuna">Comuna</label>
                                    <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control input-sm" OnDataBound="ddlComuna_DataBound">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="txtTelefono">Telefono</label>
                                    <asp:TextBox ID="txtTelefono" TextMode="Phone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                
                                <div class="form-group">
                                    <label for="txtAdicional5">Deuda Adicional 5</label>
                                    <asp:TextBox ID="txtAdicional5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional6">Deuda Adicional 6</label>
                                    <asp:TextBox ID="txtAdicional6" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional7">Deuda Adicional 7</label>
                                    <asp:TextBox ID="txtAdicional7" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional8">Deuda Adicional 8</label>
                                    <asp:TextBox ID="txtAdicional8" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional9">Deuda Adicional 9</label>
                                    <asp:TextBox ID="txtAdicional9" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAdicional10">Deuda Adicional 10</label>
                                    <asp:TextBox ID="txtAdicional10" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlTipoTipificacion">Tipo Tipificación</label>
                                    <asp:DropDownList ID="ddlTipoTipificacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoTipificacion_DataBound">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <label for="txtDeudorNomAdic1">Deudor Adicional 1</label>
                                    <asp:TextBox ID="txtDeudorNomAdic1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtDeudorNomAdic2">Deudor Adicional 2</label>
                                    <asp:TextBox ID="txtDeudorNomAdic2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtDeudorNomAdic3">Deudor Adicional 3</label>
                                    <asp:TextBox ID="txtDeudorNomAdic3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtDeudorNomAdic4">Deudor Adicional 4</label>
                                    <asp:TextBox ID="txtDeudorNomAdic4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtDeudorNomAdic5">Deudor Adicional 5</label>
                                    <asp:TextBox ID="txtDeudorNomAdic5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="txtTasaMaxConv">Tasa Max Conv</label>
                                    <asp:TextBox ID="txtTasaMaxConv" TextMode="Number" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlTipoInteres">Tipo Interes</label>
                                    <asp:DropDownList ID="ddlTipoInteres" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoInteres_DataBound">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="ddlTipoCliente">Tipo Cliente</label>
                                    <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="form-control input-sm" OnDataBound="ddlTipoCliente_DataBound">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="txtInteresesMora">Intereses Mora</label>
                                    <asp:TextBox ID="txtInteresesMora" TextMode="Number" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlMoneda">Moneda</label>
                                    <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control input-sm" OnDataBound="ddlMoneda_DataBound">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="ddlSkins">Skins</label>
                                    <asp:DropDownList ID="ddlSkins" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="skin-blue" Value="skin-blue"></asp:ListItem>
                                        <asp:ListItem Text="skin-blue-light" Value="skin-blue-light"></asp:ListItem>
                                        <asp:ListItem Text="skin-black" Value="skin-black"></asp:ListItem>
                                        <asp:ListItem Text="skin-black-light" Value="skin-black-light"></asp:ListItem>
                                        <asp:ListItem Text="skin-purple" Value="skin-purple"></asp:ListItem>
                                        <asp:ListItem Text="skin-purple-light" Value="skin-purple-light"></asp:ListItem>
                                        <asp:ListItem Text="skin-yellow" Value="skin-yellow"></asp:ListItem>
                                        <asp:ListItem Text="skin-yellow-light" Value="skin-yellow-light"></asp:ListItem>
                                        <asp:ListItem Text="skin-red" Value="skin-red"></asp:ListItem>
                                        <asp:ListItem Text="skin-red-light" Value="skin-red-light"></asp:ListItem>
                                        <asp:ListItem Text="skin-green" Value="skin-green"></asp:ListItem>
                                        <asp:ListItem Text="skin-green-light" Value="skin-green-light"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" >
                                    <label for="ddlActivo">Activo:</label>
                                    <asp:DropDownList ID="ddlActivo" runat="server" Width="150px" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>

                            
                           
                                                
                       </div>

                         <div class="panel panel-danger">
                                <div class="panel-heading">
                                    <strong>Logo</strong>
                                </div>
                                <div class="panel-body active">
                                    <div id="divImagenLogo" runat="server" visible="true">
                                    <div class="form-group">
                                        <label style="text-align:center">Logo:</label>
                                        <img runat="server" id="imgLogo" src="/" class="img-responsive img-rounded img-thumbnail" width="160" alt="" />
                                    </div>                              
                                    <div class="form-group">
                                        <label></label>
                                        <asp:FileUpload runat="server" CssClass="form-control" ID="fuLogo" Width="50%" />
                                    </div>
                                    <div class="form-group">
                                        <label></label>
                                        <asp:Button ID="btnSubirImagen" OnClick="btnSubirImagen_Click" CausesValidation="false" CssClass="btn btn-info btn-sm" Text="Subir Imagen" runat="server" />
                                    </div>
                                    </div>
                                </div>
                            </div>
                        
                        <div class="row" id="divArchivos" runat="server" visible="false">


                            <div class="col-md-12">
                                <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <strong>Archivos</strong>
                                </div>
                                        <table class="table small">
                                            <tr class="active">
                                                <td>
                                                    <strong>Nombre</strong>
                                                    <asp:TextBox ID="txtNombreArchivo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Descripción</strong>
                                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <strong>Archivo</strong>
                                                    <asp:FileUpload ID="fuArchivo" runat="server" CssClass="form-control input-sm" />
                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:Button ID="btnGrabarArchivo" runat="server" CssClass="btn btn-danger btn-sm"
                                                        Text="Guardar Archivo" OnClick="btnGrabarArchivo_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                                                        
                            <asp:GridView ID="grvDetalleBiblioteca" HeaderStyle-CssClass="active" runat="server" CssClass="table table-bordered table-hover table-condensed small" AutoGenerateColumns="false" onrowdatabound="grvDetalleBiblioteca_RowDataBound" EmptyDataText="No se encontraron registros asociados">
                                <Columns>
                                    <asp:TemplateField HeaderText="Archivo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgVisualizar" CausesValidation="False" runat="server"  Visible="true" ImageUrl="~/assets/img/file_manager.png"  ToolTip="Seleccionar" OnClick="imgVisualizar_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Visible="false"  Text='<%# Bind("idArchivo") %>'></asp:Label>
                                            <asp:Label ID="lblIdMandante" runat="server" Visible="false"  Text='<%# Bind("IdMandante") %>'></asp:Label>
                                            <asp:Label ID="lblNombre" runat="server"  Text='<%# Bind("NOMBRE") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre archivo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRutaArchivo" runat="server" Visible="true"  Text='<%# Bind("RutaArchivo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Ingreso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuario Ingreso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuario" runat="server"  Text='<%# Bind("LOGIN") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEliminarArchivo" runat="server" ImageUrl="~/assets/img/delete.png" OnClick="imgEliminarArchivo_Click" onclientclick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
            
                                </div>



                            </div>
                        </div>

                    </div>

                    <div class="box-footer">
                        <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" runat="server" />
                        <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnCancelar_Click" runat="server" />
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
    jQuery('#grvMandantes').DataTable({

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
