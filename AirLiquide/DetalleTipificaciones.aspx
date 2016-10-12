<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="DetalleTipificaciones.aspx.cs" Inherits="Cobros30.DetalleTipificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <section class="content-header">
        <h1>Detalle Gestiones
          </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Reportes</a></li>
            <li><a href="#">Reporte de Gestion</a></li>
            <li class="active">Detalle de Tipificaciones</li>
        </ol>
    </section>

    <section class="content">

        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">Detalle de Tipificaciones</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
            <div class="box-body">
                <asp:GridView ID="grvDetalleGestiones" EmptyDataText="Selección realizada no obtuvo registros" runat="server" HeaderStyle-CssClass="active" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small panel table-responsive" AutoGenerateColumns="false" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblIdGestion" runat="server" Text='<%# Bind("IDGESTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha de Ingreso">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FechaIngreso","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hora Ingreso">
                            <ItemTemplate>
                                <asp:Label ID="lblHoraIngreso" runat="server" Text='<%# Bind("HoraIngreso") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario Ingreso">
                            <ItemTemplate>
                                <asp:Label ID="lblUsuario" runat="server" Text='<%# Bind("USUARIOINGRESO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>
                                <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("ESTATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sub Tipo">
                            <ItemTemplate>
                                <asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("SUB_ESTATUS") %>'></asp:Label>
                                <%--<asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("SUB_ESTATUS","{0:dd/MM/yyyy}") %>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Motivo">
                            <ItemTemplate>
                                <asp:Label ID="lblMotivo" runat="server" Text='<%# Bind("ESTATUS_SEGUIMIENTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Agendamiento">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaAgendamiento" runat="server" Text='<%# Bind("FechaAgendamiento","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hora Agendamiento">
                            <ItemTemplate>
                                <asp:Label ID="lblHoraAgendamiento" runat="server" Text='<%# Bind("HoraAgendamiento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Compromiso">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaCompromiso" runat="server" Text='<%# Bind("FechaCompromiso","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monto Compromiso">
                            <ItemTemplate>
                                <asp:Label ID="lblHoraAgendamiento" runat="server" Text='<%# Bind("MontoCompromiso") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        


                        <asp:TemplateField HeaderText="Obs">
                            <ItemTemplate>
                                <asp:Image ID="imgInfo" runat="server" ImageUrl="~/assets/img/page.png" ToolTip='<%# Bind("OBSERVACIONES") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                <!-- /.box-body -->
                <div class="box-footer">
                </div>
            </div><!-- /.box -->

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
