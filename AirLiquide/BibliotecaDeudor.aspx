<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="BibliotecaDeudor.aspx.cs" Inherits="Cobros30.BibliotecaDeudor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Principal
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Gestión</a></li>
            <li class="active">Biblioteca Deudor</li>
          </ol>
        </section>
        <!--  -->


    <section class="content">

        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>
        
    <div class="row" id="divArchivos" runat="server" visible="true">
                            <div class="col-md-12">
                            <div class="panel-primary">
                                <div class="panel-heading">
                                    <strong>Archivos deudor</strong>
                                </div>

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
                                </Columns>
                            </asp:GridView>
            
                                </div>
                            </div>
                        </div>
    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">




</asp:Content>
