<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="AsignacionAsistida.aspx.cs" Inherits="Cobros30.AsignacionAsistida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h3>
            Asignación Asistida
        </h3>
        <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
        <li class="active">Asignación Asistida</li>
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
            <div class="panel-heading">Asignación asistida</div>
            <table class="table small">

                <tr>
                    <td colspan="4">
                        <asp:DropDownList ID="ddlTipo" Width="30%" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem Value="CLIENTE" Text="Asignar por Código Cliente"></asp:ListItem>
                            <asp:ListItem Value="DOCUMENTO" Text="Asignar por Código Cliente – Documento"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="active">
                    <td runat="server" id="tdNroDocumento">
                        <strong>Nro Documento</strong>
                        <asp:TextBox ID="txtNroDocumento" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="200px"></asp:TextBox>
                    </td>
                    <td runat="server" id="tdRut">
                        <strong>Cod Cliente</strong>
                        <asp:TextBox ID="txtRut" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="200px"></asp:TextBox>
                    </td>
                    <td>
                        <strong>Usuario(Código)</strong>
                        <asp:TextBox ID="txtCodigosUsuario" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="200px"></asp:TextBox>
                    </td>
                    <td>
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



            <div class="panel-heading">Usuarios</div>
            <asp:GridView ID="grvUsuarios" runat="server" CssClass="table table-responsive table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="info" PagerStyle-CssClass="active" AutoGenerateColumns="false">
                    <Columns>


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