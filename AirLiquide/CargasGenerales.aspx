<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CargasGenerales.aspx.cs" Inherits="Cobros30.CargasGenerales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Cargas Generales
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Cargas Generales</li>
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
        <div class="panel-heading ">
            <strong>Modulo administración - Cargas generales</strong>
            
        </div>
        <table class="table table-condensed small">
            <tr class="active" id="isssds" runat="server" visible="false">
                <td width="150px"><strong>Cliente</strong></td>
                <td><asp:DropDownList ID="ddlClientePorUsuario" runat="server" CssClass="form-control input-sm" Width="200px">
                </asp:DropDownList></td>
            </tr>
            
            <tr class="active">
                <td width="150px"><strong>Tipo carga</strong></td>
                <td>
                    <asp:DropDownList ID="ddlTipoProceso" runat="server" CssClass="form-control input-sm" Width="200px" OnSelectedIndexChanged="ddlTipoProceso_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="CARGA_CLIENTE_AL" Text="Carga Cliente Air Liquide"></asp:ListItem>
                        <asp:ListItem Value="CARGA_DEUDA_AL" Text="Carga Deuda Air Liquide"></asp:ListItem>
                        <asp:ListItem Value="CARGA_PAGOS_AL" Text="Carga Pago Air Liquide"></asp:ListItem>

                        <asp:ListItem Value="CARGA_DEUDOR" Text="Carga Deudor" Enabled="false"></asp:ListItem>
                        <asp:ListItem Value="CARGA_DEUDA" Text="Carga Deuda" Enabled="false"></asp:ListItem>
                        <asp:ListItem Value="CARGA_GESTIONES" Text="Carga Gestiones"></asp:ListItem>
                        <asp:ListItem Value="CARGA_TELEFONO" Text="Carga Telefonos"></asp:ListItem>
                        <asp:ListItem Value="CARGA_EMAIL" Text="Carga Email"></asp:ListItem>
                        <asp:ListItem Value="CARGA_DIRECCION" Text="Carga Direcciones"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="active" id="trAsignacion" runat="server" visible="false">
                <td><strong>Asignación</strong></td>
                <td><asp:DropDownList ID="ddlAsignacion" runat="server" CssClass="form-control input-sm" Width="200px" OnDataBound="ddlAsignacion_DataBound">
                </asp:DropDownList></td>
            </tr>
            <tr class="active" id="trTipoCarga" runat="server" visible="false">
                <td><strong></strong></td>
                <td><asp:DropDownList ID="ddlTipoCarga" runat="server" CssClass="form-control input-sm" Width="200px">
                    <asp:ListItem Text="Solo Cargar" Value="CARGAR"></asp:ListItem>
                    <asp:ListItem Text="Borrar y Cargar" Value="BORRAR_CARGAR"></asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr class="active">
                <td><strong>Archivo de carga</strong></td>
                <td>
                    <asp:FileUpload ID="fuArchivo" runat="server" CssClass="btn btn-default" />
                </td>
            </tr>
            <tr class="active">
                <td><strong></strong></td>
                <td>
                    <div id="divResultado" runat="server" visible="false" class="well alert-warning alert-dismissable">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                        <strong>Resultado!</strong>
                        <asp:Label Text="" ID="lblResultado" runat="server" /><br />
                        <%--<asp:HyperLink ID="hlDescargar" runat="server"></asp:HyperLink>--%>
                        <a id="aDescargar" runat="server" visible="false">Descargar Log</a>
                    </div>
                    
                </td>
            </tr>
            <tr class="active">
                <td>
                    <asp:LinkButton ID="lbtnGrabar" CssClass="btn btn-danger btn-sm" runat="server" 
                    onclick="lbtnGrabar_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Procesar</asp:LinkButton>
                </td>
                <td></td>
            </tr>
        </table>

        

        <br />
        <table class="table table-condensed small">
<%--            <tr>
                <td width="200px"><strong>Formato de carga Deuda</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_DEUDA.csv">Descargar</a>
                </td>
            </tr>--%>
<%--            <tr class="active">
                <td width="200px"><strong>Formato de carga Deudor</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_DEUDOR.csv">Descargar</a>
                </td>
            </tr>--%>
            <tr class="active">
                <td width="200px"><strong>Formato de carga Gestiones</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_GESTIONES.CSV">Descargar</a>
                </td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga Telefonos</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_UBIC_TELEFONOS.CSV">Descargar</a>
                </td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga Email</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_UBIC_EMAIL.CSV">Descargar</a>
                </td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga Direcciones</strong></td>
                <td>
                    <a href="assets/formatosCarga/FORMATO_CARGA_UBIC_DIRECCIONES.CSV">Descargar</a>
                </td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga cliente Air Liquide</strong></td>
                <td><a href="assets/formatosCarga/FormatoCargaCliente_AIRLIQUIDE.csv">Descargar</a></td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga deuda Air Liquide</strong></td>
                
                <td><a href="assets/formatosCarga/FORMATO_DEUDA_AL.csv">Descargar</a></td>
            </tr>
            <tr class="active">
                <td width="200px"><strong>Formato de carga pagos Air Liquide</strong></td>
                
                <td>
                    <a href="assets/formatosCarga/FORMATO_PAGOS_AL.csv">Descargar</a>
                </td>
            </tr>
        </table>

        <br />
        <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <strong>Tipos de Documentos</strong>
                </div>
                <asp:GridView ID="grvTipoDocumento" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblIdProveedorUbicabilidad" runat="server" Text='<%# Bind("IdTipoDocumento") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("NomTipoDocumento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <strong>Tipo Persona</strong>
                </div>
                <asp:GridView ID="grvTipoPersona" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblIdProveedorUbicabilidad" runat="server" Text='<%# Bind("IdTipoPersona") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("NomTipoPersona") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="panel panel-danger">
                <div class="panel-heading">
                    <strong>Probabilidad de Cobro</strong>
                </div>
                <asp:GridView ID="grvProbabilidadCobro" runat="server" CssClass="table table-bordered table-hover table-condensed small" HeaderStyle-CssClass="active" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblIdProveedorUbicabilidad" runat="server" Text='<%# Bind("IdProbabilidadCobro") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("NomProbabilidadCobro") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>

    </div>

    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
