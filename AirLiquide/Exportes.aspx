<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Exportes.aspx.cs" Inherits="Cobros30.Exportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/template/AdminLTE-2.3.0/plugins/datepicker/datepicker3.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Exportes
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Exportes</li>
          </ol>
        </section>
        <!--  -->

    <section class="content">

        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">Exportes</div>
            
            <table class="table small">
                <tr class="active">
                    <td>
                        <strong>Tipo Exporte</strong>
                        <asp:DropDownList ID="ddlTipoExporte" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlTipoExporte_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td id="tdAsignacion" runat="server" visible="false">
                        <strong>Asignación</strong>
                        <asp:DropDownList ID="ddlAsignacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlAsignacion_DataBound">
                        </asp:DropDownList>
                    </td>
                    <td id="tdFechaDesde" runat="server" visible="false" width="150px">
                        <strong>Fecha desde</strong>
                        <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                    </td>
                    <td id="tdFechaHasta" runat="server" visible="false" width="150px">
                        <strong>Fecha hasta</strong>
                        <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control input-sm class-date"></asp:TextBox>
                    </td>
                    <td id="tdTipoTelefono" runat="server" visible="false" width="150px">
                        <strong>Estado</strong>
                        <asp:DropDownList ID="ddlTipoTelefono" runat="server" CssClass="form-control input-sm">
                            <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Solo Validos" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Sin Auditar" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <br />
                        <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-danger btn-sm" runat="server" onclick="lbtnBuscar_Click" ><i aria-hidden="true" class="glyphicon glyphicon-download-alt"></i> Exportar</asp:LinkButton>
                    </td>
                </tr>
            </table>
            
        </div>


    </section>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
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
