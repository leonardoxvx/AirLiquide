<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="AsignacionManual.aspx.cs" Inherits="Cobros30.AsignacionManual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<script type="text/javascript">

    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            //Get the Cell To find out ColumnIndex
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    //If the header checkbox is checked
                    //check all checkboxes
                    //and highlight all rows
                    //row.style.backgroundColor = "aqua";
                    inputList[i].checked = true;
                }
                else {
                    //If the header checkbox is checked
                    //uncheck all checkboxes
                    //and change rowcolor back to original
                    if (row.rowIndex % 2 == 0) {
                        //Alternating Row Color
                        //row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }


</script>


    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h3>
            Asignación Automática
        </h3>
        <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
        <li class="active">Asignación Automática</li>
        </ol>
    </section>
    <!--  -->

    <section class="content">
        
        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">Asignación Automática</div>

            <table class="table small">
                <tr class="active">
                    <td width="250px">
                        <strong>Tipo Proceso</strong>
                        <asp:DropDownList ID="ddlTipoProceso" runat="server" CssClass="form-control input-sm" >
                            <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Asignar solo casos sin asignación" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reasignar Todo" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Eliminar Asignación" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="250px">
                        <strong>Asignación</strong>
                        <asp:DropDownList ID="ddlAsignacion" runat="server" CssClass="form-control input-sm" OnDataBound="ddlAsignacion_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlAsignacion_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <br />
                        <asp:LinkButton ID="lbtnGrabar" CssClass="btn btn-danger btn-sm" runat="server" OnClick="lbtnGrabar_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Procesar</asp:LinkButton>
                    </td>
                </tr>
            </table>
         </div>
            
        <div class="panel panel-primary">
            <div class="panel-heading">
                <strong>Resumen</strong>
            </div>

             <%--@maxDeuda as maxDeuda ,
             @minDeuda as minDeuda ,
             @promDeuda as promDeuda ,
             @cantRut as cantRut ,
             @montoTotal as montoTotal,
             @cantRutAsignado as cantRutAsignado ,
             @montoTotalAsignado as montoTotalAsignado ,
             @cantEjeAsig as cantEjeAsig,
             @cantRutNoAsignado as cantRutNoAsignado,
             @montoTotalNoAsignado as montoTotalNoAsignado--%>

            <table class="table small">
                <tr class="info">
                    <td>
                        <strong>
                            Max Deuda
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Min Deuda
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Promedio Deuda
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Casos
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Docs
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Monto Total
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Casos Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Docs Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Monto Total Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Ejecutivo Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Casos No Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Cantidad Docs No Asignado
                        </strong>
                        
                    </td>
                    <td>
                        <strong>
                            Monto Total No Asignado
                        </strong>
                        
                    </td>
                    
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="lblMaxDeuda" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblMinDeuda" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblPromedioDeuda" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadRut" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadDocs" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblMontoTotal" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadRutAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadDocAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblMontoTotalAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadEjecutivoAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadRutNoAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblCantidadDocsNoAsignado" runat="server"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label ID="lblMontoTotalNoAsignado" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

    <div class="panel-heading panel-info">Usuarios</div>
            <asp:GridView ID="grvUsuarios" runat="server" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="info" PagerStyle-CssClass="active" AutoGenerateColumns="false">
                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccionar" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="55px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cod Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblRut" runat="server" Text='<%# Bind("Rut") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EJECUTIVO" HeaderText="Nombre" />
                        <asp:BoundField DataField="crut" HeaderText="Rut Asig" />
                        <asp:TemplateField HeaderText="Monto Asignado">
                            <ItemTemplate>
                                <asp:Label ID="lblCMonto" runat="server" Visible="true" Text='<%# Bind("cmonto","{0:n0}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
