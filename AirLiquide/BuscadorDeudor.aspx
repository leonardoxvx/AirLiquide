<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="BuscadorDeudor.aspx.cs" Inherits="Cobros30.BuscadorDeudor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Buscador Deudor
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Gestión</a></li>
            <li class="active">Buscador Deudor</li>
          </ol>
        </section>
        <!--  -->

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content">

                <!-- Alertas -->
                <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
                    <strong>Atención!: </strong>
                    <asp:Label Text="" ID="lblInfo" runat="server" />
                </div>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <strong>Busqueda del Deudor</strong>
                    </div>
                    <table class="table small">
                        <tr class="active">
                            <td width="10%">
                                <strong>Cod Cliente</strong>
                                <asp:TextBox ID="txtRut" runat="server" MaxLength="12" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td>
                                <strong>Nombre</strong>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td width="10%">
                                <strong>Documento</strong>
                                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td width="10%">
                                <strong>Cuenta</strong>
                                <asp:TextBox ID="txtCuenta" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td width="15%">
                                <strong>Telefono</strong>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td width="15%">
                                <strong>Sucursal</strong>
                                <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <div class="pull-right">
                                    <br />
                                    <asp:LinkButton ID="lbtnBuscarDeudor" OnClick="lbtnBuscarDeudor_Click" runat="server" CssClass="btn btn-sm btn-google"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </table>

                    

            <asp:GridView ID="grvBuscadorDeudor" runat="server" CssClass="table table-responsive table-hover table-condensed table-bordered table-striped small"
                            HeaderStyle-CssClass="active" PagerStyle-CssClass="active" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Mandante">
                            <ItemTemplate>
                                <asp:Label ID="lblIdMandante" runat="server" Text='<%# Bind("IdMandante") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblNombreMandante" runat="server" Text='<%# Bind("NomMandante") %>' Visible="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cod Cliente Deudor">
                            <ItemTemplate>
                                <asp:Label ID="lblRutDeudor" runat="server" Text='<%# Bind("RutDeudor") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre Deudor">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreDeudor" runat="server" Visible="true" Text='<%# Bind("NombreDeudor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-Width="7%">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnIr" OnClick="btnIr_Click" runat="server" CssClass="btn btn-xs btn-success">Ir <span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>



            </section>





        </ContentTemplate>
    </asp:UpdatePanel>
    



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
