<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Cobros30.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Asignaciones
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Asignaciones</li>
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
                <asp:GridView ID="grvAsignaciones" runat="server" ClientIDMode="Static" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIdAsignacion" runat="server" Text='<%# Bind("IdAsignacion") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre Mandante">
                            <ItemTemplate>
                                <asp:Label ID="lblIdMandante" runat="server" Visible="false" Text='<%# Bind("IdMandante") %>'></asp:Label>
                                <asp:Label ID="lblNomMandante" runat="server" Text='<%# Bind("NomMandante") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre Asignación">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreAsignacion" runat="server" Visible="true" Text='<%# Bind("NomAsignacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Asignacion">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaAsignacion" runat="server" Visible="true" Text='<%# Bind("FechaAsignacion", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Inicio">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaInicio" runat="server" Visible="true" Text='<%# Bind("FechaInicio", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Termino">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaTermino" runat="server" Visible="true" Text='<%# Bind("FechaTermino", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:Label ID="lblActivo" runat="server" Visible="false" Text='<%# Bind("Activa") %>'></asp:Label>
                                <asp:Label ID="lblActivo2" runat="server" Text='<%# Bind("Activa2") %>'></asp:Label>
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
                                <div class="form-group"><asp:HiddenField ID="hfIdAsignacion" runat="server" />
                                    <label>Nombre Asignación</label>
                                    <asp:TextBox ID="txtNombreAsignacion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreAsignacion" ErrorMessage="Debe ingresar un nombre" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Fecha Asignación</label>
                                    <asp:TextBox ID="txtFechaAsignacion" runat="server" CssClass="form-control input-sm class-date" Width="150px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtFechaAsignacion" ErrorMessage="Debe ingresar una asignación" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Fecha Inicio</label>
                                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control input-sm class-date" Width="150px" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <label>Fecha Termino</label>
                                    <asp:TextBox ID="txtFechaTermino" runat="server" CssClass="form-control input-sm class-date" Width="150px" ></asp:TextBox>
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
    jQuery('#grvAsignaciones').DataTable({

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
